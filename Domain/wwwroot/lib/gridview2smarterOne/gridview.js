$.fn.gridView = function (options) {
    $(this).html('');
    $(this).attr('class','');
    options.owner = $(this);
    if (options.filter) {
        var innerContainer = document.createElement('div');
        $(this).append(gridViewLoadData_filter());
        $(this).append(innerContainer);
        options.container = $(innerContainer);
    } else {
        options.container = $(this);
    }

    var state = new gridViewState(options);
    var id = 'grid' + (new Date()).getTime();

    $(this).addClass('gridview-container').addClass(id);
    if (options.class) {
        $(state.container).addClass(options.class);
    }

    $(document).find('.gridview-container a').off('click');

    $(document).on('click', '.' + id + ' .gridview-footer a', function () {
        state.loadData($(this).data('page'));
    });
    $(document).on('keyup', '.' + id + ' .gridView-filter', function () {
        if ($(this).val().length > gridViewLocals.minSearchLength) {
            state.filter_cleared = false;
            state.filter_text = $(this).val();
            state.loadData(1);
        } else {
            if (state.filter_cleared == false) {
                state.filter_text = '';
                state.filter_cleared = true;
                state.loadData(1);
            }
        }
    });
    $(document).on('click', '.' + id + ' .gridView-size-selector a', function () {
        state.setSize($(this).data('size'));
    });
    state.loadData(1);
}

var gridViewLocals = {
    loading: 'Зареждане...',
    show: 'Покажи',
    first: 'Първа',
    prev: '...',
    next: '...',
    last: 'Последна',
    minSearchLength: 3
};

var gridViewState = function (options) {
    this.owner = options.owner;
    this.container = options.container;
    this.url = options.url;
    this.size = 12;
    this.size_selector = true;
    if (options.size_selector) {
        this.size_selector = options.size_selector;
    }
    this.method = 'POST';
    if (options.method) {
        this.method = options.method;
    }
    this.filter = true;
    this.filter_text = null;
    if (options.filter == false) {
        this.filter = false;
    }
    this.data = options.data;
    this.template = options.template;
    this.empty_text = options.empty_text;
    this.loader = options.loader;
}
gridViewState.prototype.loadData = gridViewLoadData;
gridViewState.prototype.setSize = gridViewSetSize;

function gridViewLoadData(page) {
    this.page = page;
    var state = this;
    var gridRequest = {
        param: state.data,
        page: state.page,
        size: state.size,
        filter: state.filter_text
    };
    if (state.loader) {
        $(state.container).html('<img src="' + state.loader + '" />');
    } else {
        $(state.container).html(gridViewLocals.loading);
    }
    $.ajax({
        url: state.url,
        type: state.method,
        data: JSON.stringify(gridRequest),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            if (result.data.length == 0 && state.empty_text) {
                if (state.filter == true) {
                    tmpl += gridViewLoadData_filter();
                }
                $(state.container).html(state.empty_text);
                return;
            }
            //debugger;
            var tmpl = '';
            //if (state.filter == true) {
            //    tmpl = gridViewLoadData_filter();
            //}
            if (state.size_selector == true) {
                tmpl += gridViewLoadData_templateSizeSelector(result.size);
            }
            if (state.template) {
                tmpl += gridViewLoadData_templateStart();
                tmpl += $(state.template).html();
                tmpl += gridViewLoadData_templateEnd();
            }
            if (state.full_template) {
                tmpl = $(state.template).html();
            }
            var hbars = Handlebars.compile(tmpl);
            $(state.container).html(hbars(
                {
                    data: result.data,
                    page: result.page,
                    pages: gridViewMakePager(result.total_pages, page)
                }));
        }
    });
}


function gridViewMakePager(totalPages, page) {
    //debugger;
    var pages = [];
    if (page == 1) {
        pages.push({ page: 1, title: gridViewLocals.first, disabled: true });
    } else {
        pages.push({ page: 1, title: gridViewLocals.first });
    }

    var lowerPages = 3;
    var upperPages = 3;
    var isOk = false;
    do {
        if (page - lowerPages <= 0) {
            lowerPages--;
            upperPages++;
        } else {
            isOk = true;
        }
    } while (!isOk)
    isOk = false;
    do {
        if (page + upperPages > totalPages) {
            lowerPages++;
            upperPages--;
        } else {
            isOk = true;
        }
    } while (!isOk)
    lowerPages = Math.min(lowerPages, page - 1);

    if (page - (lowerPages + 1) > 0) {
        pages.push({ page: page - (lowerPages + 1), title: gridViewLocals.prev });
    }
    for (var i = lowerPages; i >= 1; i--) {
        pages.push({ page: page - i, title: (page - i).toString() });
    }
    pages.push({ page: page, title: page.toString(), selected: true });
    for (var i = 1; i <= upperPages; i++) {
        pages.push({ page: page + i, title: (page + i).toString() });
    }


    if (page + upperPages + 1 <= totalPages) {
        pages.push({ page: page + upperPages + 1, title: gridViewLocals.next });
    }
    if (page == totalPages) {
        pages.push({ page: totalPages, title: gridViewLocals.last, disabled: true });
    } else {
        pages.push({ page: totalPages, title: gridViewLocals.last });
    }
    //pages.push({ page: 0, title: lowerPages + '-' + upperPages });

    //debugger;
    return pages;
}

function gridViewSetSize(newSize) {
    var state = this;
    state.size = newSize;
    state.loadData(1);
}
function gridViewLoadData_filter() {
    return '<div class="pull-left"><input type="text" class="gridView-filter"/></div>';
}
function gridViewLoadData_templateSizeSelector(selectedSize) {
    var sizes = [];
    sizes.push(12);
    sizes.push(24);
    sizes.push(60);
    sizes.push(1000000);
    var result = '<div class="gridView-size-selector pull-right">' + gridViewLocals.show + ': ';
    for (var i = 0; i < sizes.length; i++) {
        var selected = '';
        if (selectedSize == sizes[i]) {
            selected = ' class="selected"';
        }
        var allText = sizes[i].toString();
        if (i == sizes.length - 1) {
            allText = "Всички";
        }
        result += '<a href="#" data-size="' + sizes[i] + '" ' + selected + '>' + allText + '</a>';
    }
    result += '</div>';
    return result;
}
function gridViewLoadData_templateStart() {
    return '<div class="row">{{#each this.data}}';
}
function gridViewLoadData_templateEnd() {
    return '{{/each}}</div>{{#if this.pages}}<div class="gridview-footer">{{#each this.pages}}<a href="#" data-page="{{page}}" class="gridViewPager {{#if selected}}selected{{/if}}">{{title}}</a>{{/each}}</div>{{/if}}';
}
