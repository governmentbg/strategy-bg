// Write your JavaScript code.
$(function () {
    $('.submit').click(function () {
        $(this).parents('form:first').trigger('submit');
    });


    $('.lang-set').click(function () {
        //debugger;
        var newLang = $(this).attr('data-lang');
        //alert(newLang);
        $(this).parents('form:first').find('input[name="culture"]').val(newLang);
        $(this).parents('form:first').trigger('submit');
    });

    $('#messageContainer').delay(6000).slideUp(1000);
});

(function () {
    // DataTables global settings
    $.extend(true, $.fn.dataTable.defaults, {
        "initComplete": function () {
            // Search form events
            var initSearchForm = $('.search-form');
            var initTable = $('.dataTable');

            if (initSearchForm.length > 0 && initTable.length > 0) {
                initSearchForm.on('submit', function () {
                    var t = initTable.DataTable();
                    t.state.clear();
                });
            }
        },
        "bAutoWidth": false,
        "language": {
            "url": "/lib/datatables/dataTables.bgBG.json"
        },
        filter: true,
        "bLengthChange": false,
        "serverSide": true,
        "processing": true,
        "paging": true,
        "pageLength": 20,
        "stateSave": true,
        "stateDuration": -1
    });

    //$('.date-picker').datepicker({
    //    todayHighlight: true,
    //    autoclose: true,
    //    format: 'dd.mm.yyyy',
    //    language: 'bg-BG',
    //});
})();

function JsonBGdate(value) {
    if (value === null) return "";

    var dt = new Date(value.substr(0, 10));

    return dt.getDate().toString().padStart(2, "0") + "." + (dt.getMonth() + 1).toString().padStart(2, "0") + "." + dt.getFullYear();
}

//Преобразува handlebars template, който е съдържание в контейнер с подадено име
function TemplateToHtml(countainer, data) {
    var source = $(countainer).html();

    return HandlebarsToHtml(source, data);
}

//Преобразува handlebars template, 
function HandlebarsToHtml(hbTemplate, data) {
    var template = Handlebars.compile(hbTemplate);

    return template(data);
}

Handlebars.registerHelper('eachData', function (context, options) {
    var fn = options.fn, inverse = options.inverse, ctx;
    var ret = "";

    if (context && context.length > 0) {
        for (var i = 0, j = context.length; i < j; i++) {
            ctx = Object.create(context[i]);
            ctx.index = i;
            ret = ret + fn(ctx);
        }
    } else {
        ret = inverse(this);
    }
    return ret;
});



Handlebars.registerHelper("math", function (lvalue, operator, rvalue, options) {
    lvalue = parseFloat(lvalue);
    rvalue = parseFloat(rvalue);

    return {
        "+": lvalue + rvalue
    }[operator];
});

Handlebars.registerHelper('ifCond', function (v1, v2, options) {
    if (v1 === v2) {
        return options.fn(this);
    }
    return options.inverse(this);
});

function generateUrl(title) {
    var url = title.toLowerCase();

    url = url
        .replace(/а/g, 'a')
        .replace(/б/g, 'b')
        .replace(/в/g, 'v')
        .replace(/г/g, 'g')
        .replace(/д/g, 'd')
        .replace(/е/g, 'e')
        .replace(/ж/g, 'zh')
        .replace(/з/g, 'z')
        .replace(/и/g, 'i')
        .replace(/й/g, 'y')
        .replace(/к/g, 'k')
        .replace(/л/g, 'l')
        .replace(/м/g, 'm')
        .replace(/н/g, 'n')
        .replace(/о/g, 'o')
        .replace(/п/g, 'p')
        .replace(/р/g, 'r')
        .replace(/с/g, 's')
        .replace(/т/g, 't')
        .replace(/у/g, 'u')
        .replace(/ф/g, 'f')
        .replace(/х/g, 'h')
        .replace(/ц/g, 'ts')
        .replace(/ч/g, 'ch')
        .replace(/ш/g, 'sh')
        .replace(/щ/g, 'sht')
        .replace(/ь/g, 'y')
        .replace(/ъ/g, 'a')
        .replace(/ю/g, 'yu')
        .replace(/я/g, 'ya')

        .replace(/\s\s+/g, ' ')
        .trim()
        .replace(/ /g, '-')
        .replace(/[&\/\\#,+()$~%.'":*?<>{}]/g, '');




    return url;
}