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
            "url": rootPath + "prod/js/dataTables.bgBG.json"
        },
        filter: true,
        fnDrawCallback: function (settings) {
            $(this).parent().toggle(settings.fnRecordsDisplay() > 0);
        },
        "bLengthChange": false,
        "serverSide": true,
        "processing": true,
        "paging": true,
        "pageLength": 20,
        "stateSave": false,
        "stateDuration": -1
    });

    AttachUIpluggins();

    //$('.summernote').summernote({
    //    height: 200,
    //    minHeight: null,
    //    maxHeight: null
    //});

    //$('.datetime-picker').datetimepicker({
    //    format: 'DD.MM.YYYY HH:mm',
    //    locale: 'bg-BG'
    //});



})();


function AttachUIpluggins() {
    $('.date-picker').datepicker({
        format: 'dd.mm.yyyy',
        todayBtn: "linked",
        language: 'bg',
        autoclose: true
    });

    $('.datetime-with-empty').each(function (i, e) {
        $(e).find('input[type="checkbox"]').change(function () {
            if ($(this).is(':checked')) {
                $(e).find('input[type="text"]').attr('disabled', 'disabled').val('');
            } else {
                $(e).find('input[type="text"]').removeAttr('disabled').val($(this).data('val'));
            }
        }).trigger('change');
        $(e).parents('form:first').submit(function () {
            dateTimeWithEmptySetValues(e);
        });
    });
    $('.dateyear-with-empty').each(function (i, e) {
        $(e).find('input[type="checkbox"]').change(function () {
            if ($(this).is(':checked')) {
                $(e).find('input[type="text"]').attr('disabled', 'disabled').val('');
            } else {
                $(e).find('input[type="text"]').removeAttr('disabled').val($(this).data('val'));
            }
        }).trigger('change');
        $(e).parents('form:first').submit(function () {
            dateYearWithEmptySetValues(e);
        });
    });
}

function dateTimeWithEmptySetValues(e) {
    var checkBox = $(e).find('input[type="checkbox"]');
    if ($(checkBox).is(':checked')) {
        $(e).find('input[type="hidden"]').val('01.01.9999');
    } else {
        $(e).find('input[type="hidden"]').val($(e).find('input[type="text"]').val());
    }
}
function dateYearWithEmptySetValues(e) {
    var checkBox = $(e).find('input[type="checkbox"]');
    if ($(checkBox).is(':checked')) {
        $(e).find('input[type="hidden"]').val('01.01.9999');
    } else {
        $(e).find('input[type="hidden"]').val('01.01.'+$(e).find('input[type="text"]').val());
    }
}