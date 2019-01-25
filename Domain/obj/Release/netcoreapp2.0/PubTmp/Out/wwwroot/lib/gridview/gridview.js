var gridViewState = new Object();

$.fn.gridView = function (options) {
    $(this).addClass('gridview-container');
    if (options.class) {
        $(this).addClass(options.class);
    }
    gridViewState.container = $(this);
    gridViewState.url = options.url;
    gridViewState.size = options.size;
    gridViewState.size_selector = options.size_selector;
    if (gridViewState.size_selector == true) {
        gridViewState.size = 10;
    }
    gridViewState.method = options.method;
    gridViewState.data = options.data;
    gridViewState.template = options.template;
    gridViewState.empty_text = options.empty_text;
    gridViewState.loader = options.loader;
    gridViewLoadData(1);
}

function gridViewLoadData(page) {
    gridViewState.page = page;
    var gridRequest = new Object();
    gridRequest.param = gridViewState.data;
    gridRequest.page = gridViewState.page;    
    gridRequest.size = gridViewState.size;
    if (gridViewState.loader) {
        $(gridViewState.container).html('<img src="' + gridViewState.loader + '" />');
    } else {
        $(gridViewState.container).html('Зареждане...');
    }
    $.ajax({
        url: gridViewState.url,
        type: gridViewState.method,
        data: JSON.stringify(gridRequest),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            //debugger;
            if (result.data.length == 0 && gridViewState.empty_text) {
                $(gridViewState.container).html(gridViewState.empty_text);
                return;
            }
            var pages = [];
            if (result.total_pages > 1) {
                for (var i = 1; i <= result.total_pages; i++) {
                    pages.push(i);
                }
            }
            var tmpl = '';
            if (gridViewState.size_selector == true) {
                tmpl += gridViewLoadData_templateSizeSelector(result.size);
            }
            if (gridViewState.template) {
                tmpl += gridViewLoadData_templateStart();
                tmpl += $(gridViewState.template).html();
                tmpl += gridViewLoadData_templateEnd();
            }
            if (gridViewState.full_template) {
                tmpl = $(gridViewState.template).html();
            }
            var hbars = Handlebars.compile(tmpl);
            $(gridViewState.container).html(hbars(
                {
                    data: result.data,
                    page: result.page,
                    pages: pages
                }));
        }
    });
}
function gridViewSetSize(newSize) {
    gridViewState.size = newSize;
    gridViewLoadData(1)
}
function gridViewLoadData_templateSizeSelector(selectedSize) {
    var sizes = [];
    sizes.push(10);
    sizes.push(20);
    sizes.push(50);
    sizes.push(1000000);
    var result = '<div class="gridView-size-selector pull-right">Покажи: ';
    for (var i = 0; i < sizes.length; i++) {
        var selected = '';
        if (selectedSize == sizes[i]) {
            selected = ' class="selected"';
        }
        var allText = sizes[i].toString();
        if (i == sizes.length - 1) {
            allText = "Всички";
        }
        result += '<a href="#" onclick="gridViewSetSize(' + sizes[i] + ');"' + selected + '>' + allText + '</a>';
    }
    result += '</div>';
    return result;
}
function gridViewLoadData_templateStart() {
    return '{{#each this.data}}';
}
function gridViewLoadData_templateEnd() {
    return '{{/each}}{{#if this.pages}}<div class="gridview-footer">{{#each this.pages}}<a href="#" onclick="gridViewLoadData({{this}});return false;" class="{{#ifCond this ../page}}selected{{/ifCond}}">{{this}}</a>{{/each}}</div>{{/if}}';
}

//<script type="text/x-handlebars-template" id="gridViewTemplate">
//    {{#each this.data}}
//    <div class="gridview-item">
//        {{ title }}
//    </div>
//    {{/ each}}
//    {{#if this.pages}}
//    <div class="gridview-footer">
//        {{#each this.pages}}
//        <a href="#" onclick="gridViewLoadData({{this}});return false;">{{ this}}</a>
//        {{/ each}}
//    </div>
//    {{/if}}
//</script>