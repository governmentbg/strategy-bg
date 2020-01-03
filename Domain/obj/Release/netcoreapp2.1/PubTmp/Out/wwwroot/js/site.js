// Write your JavaScript code.
$(function () {

    $('.lang-select a').click(function () {
        var newLang = $(this).attr('data-lang');
        $(this).parents('form:first').find('input[name="culture"]').val(newLang);
        $(this).parents('form:first').trigger('submit');
    });

    $('a.submit').on('click', function () {
        $(this).parents('form:first').trigger('submit');
    });    

    $('#messageContainer').delay(6000).slideUp(1000);
    $('[data-toggle="popover"]').popover();
});



function JsonBGdate(value) {
    if (value === null) return "";

    return moment(value).format('DD.MM.YYYY');

    //var dt = new Date(value.substr(0, 10));

    //return dt.getDate().toString().padStart(2, "0") + "." + (dt.getMonth() + 1).toString().padStart(2, "0") + "." + dt.getFullYear();
}
function JsonBGmonth(value,locale) {
    if (value === null) return "";
    var _month = moment(value);
    _month.locale(locale);
    return _month.format('MMMM, YYYY');

    //var dt = new Date(value.substr(0, 10));

    //return dt.getDate().toString().padStart(2, "0") + "." + (dt.getMonth() + 1).toString().padStart(2, "0") + "." + dt.getFullYear();
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

Handlebars.registerHelper('dateFormat', function (date, format) {
    return moment(date).format(format);
});

function requestCombo(combo, url, data) {
    requestContent(url, data, function (items) {
        var tmlp = '{{#each this}}<option value="{{value}}" {{#if selected}}selected="selected"{{/if}}>{{text}}</option>{{/each}}';
        $(combo).html(HandlebarsToHtml(tmlp, items));
    });
}

function requestContent(url, data, callback) {
    $.ajax({
        type: 'GET',
        cache: false,
        url: url,
        data: data,
        success: function (data) {
            callback(data);
        }
    });
}
function postContent(url, data, callback) {
    $.ajax({
        type: 'POST',
        cache: false,
        url: url,
        data: data,
        success: function (data) {
            callback(data);
        }
    });
}

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

    var maxUrlLendth = 150;
    if (url.length > maxUrlLendth) {
        url = url.substr(0, maxUrlLendth);
    }

    return url;
}


try {
    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    };

    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
    };

} catch (e) { var rr = 1; }