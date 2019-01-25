
var countriesData = [];
var areaData = [];

function comboLoadCountries(combo, selected) {
    var url = rootPath + 'ajax/countries';
    if (countriesData.length > 0) {
        comboFill(combo, selected, countriesData);
    }
    requestContent(url, null, function (data) {
        comboFill(combo, selected, data);
        countriesData = data;
    });
}
function comboLoadEkkate(combo, parent, selected, addAllItem) {
    if (addAllItem == undefined) {
        addAllItem = true;
    }
    var url = rootPath + 'ajax/ekkate';
    requestContent(url, { parentCode: parent, addAllItem: addAllItem }, function (data) {
        comboFill(combo, selected, data);
    });
}

function comboFill(combo, selected, data) {
    try {
        for (var i = 0; i < data.length; i++) {
            if (data[i].value == selected) {
                data[i].selected = true;
            }
        }
    } catch (e) { }
    var comboTemplate = '{{#each this }}<option value="{{value}}" {{#if selected}} selected="selected" {{/if}}>{{text}}</option>{{/each}}';
    var html = HandlebarsToHtml(comboTemplate, data);
    $(combo).html(html).trigger('change');
}

$(function () {

    var bulgariaCountryId = 155;
    //Load ekkate to adress templates
    $('.address-editor').each(function (i, editor) {
        //country select
        var countrySelect = $(editor).find('select.country')[0];
        var oblSelect = $(editor).find('select.obl')[0];
        var obstSelect = $(editor).find('select.obst')[0];
        var gradSelect = $(editor).find('select.grad')[0];
        var gradSelectRow = $(editor).find('div.grad-select')[0];
        var gradEditRow = $(editor).find('div.grad-edit')[0];


        comboLoadCountries(countrySelect, $(countrySelect).data('selected'));
        $(countrySelect).change(function () {
            if ($(this).val() == bulgariaCountryId) {
                $(gradSelectRow).show();
                $(gradEditRow).hide();
            } else {
                $(gradSelectRow).hide();
                $(gradEditRow).show();
            }
        }).trigger('change');
        if (oblSelect != undefined) {
            comboLoadEkkate(oblSelect, '-1', $(oblSelect).data('selected'));
            $(oblSelect).change(function () {
                comboLoadEkkate(obstSelect, $(this).val(), $(obstSelect).data('selected'));
            });
            $(obstSelect).change(function () {
                comboLoadEkkate(gradSelect, $(this).val(), $(gradSelect).data('selected'));
            });
        }
    });

    $('.person-editor').each(function (i, editor) {
        $(editor).find('.type-radio input[type="radio"]').change(function () {
            if ($(this).is(':checked')) {
                var forShowPersonNames = $(this).val() == '1';
                if (forShowPersonNames) {
                    $(this).parents('.person-editor:first').find('.person-edit-person').show();
                    $(this).parents('.person-editor:first').find('.person-edit-entity').hide();
                } else {
                    $(this).parents('.person-editor:first').find('.person-edit-person').hide();
                    $(this).parents('.person-editor:first').find('.person-edit-entity').show();
                }
            }
        }).trigger('change');
    });
})