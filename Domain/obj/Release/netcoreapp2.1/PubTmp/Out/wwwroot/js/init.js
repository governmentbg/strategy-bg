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
        "pagingType":"bootstrap",
        "paging": true,
        "pageLength": 15,
        "dom": "<'row'<'col-sm-6'l><'col-sm-6'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-12'p>>",
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


/* Set the defaults for DataTable initialisation */
$.extend(true, $.fn.dataTable.defaults, {
    "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
    "sPaginationType": "bootstrap",
    "oLanguage": {
        "sLengthMenu": "_MENU_ records per page"
    }
});


/* Default class modification */
$.extend($.fn.dataTableExt.oStdClasses, {
    "sWrapper": "dataTables_wrapper form-inline"
});


/* API method to get paging information */
$.fn.dataTableExt.oApi.fnPagingInfo = function (oSettings) {
    return {
        "iStart": oSettings._iDisplayStart,
        "iEnd": oSettings.fnDisplayEnd(),
        "iLength": oSettings._iDisplayLength,
        "iTotal": oSettings.fnRecordsTotal(),
        "iFilteredTotal": oSettings.fnRecordsDisplay(),
        "iPage": Math.ceil(oSettings._iDisplayStart / oSettings._iDisplayLength),
        "iTotalPages": Math.ceil(oSettings.fnRecordsDisplay() / oSettings._iDisplayLength)
    };
}
/* Bootstrap style pagination control */
$.extend($.fn.dataTableExt.oPagination, {
    "bootstrap": {
        "fnInit": function (oSettings, nPaging, fnDraw) {
            var oLang = oSettings.oLanguage.oPaginate;
            var fnClickHandler = function (e) {
                e.preventDefault();
                if (oSettings.oApi._fnPageChange(oSettings, e.data.action)) {
                    fnDraw(oSettings);
                }
            };

            $(nPaging).addClass('pagination').append(
                '<ul>' +
                '<li class="first disabled"><a href="#">' + oLang.sFirst + '</a></li>' +
                '<li class="prev  disabled"><a href="#">' + oLang.sPrevious + '</a></li>' +
                '<li class="next  disabled"><a href="#">' + oLang.sNext + '</a></li>' +
                '<li class="last  disabled"><a href="#">' + oLang.sLast + '</a></li>' +
                '</ul>'
            );
            var els = $('a', nPaging);
            $(els[0]).bind('click.DT', { action: "first" }, fnClickHandler);
            $(els[1]).bind('click.DT', { action: "previous" }, fnClickHandler);
            $(els[2]).bind('click.DT', { action: "next" }, fnClickHandler);
            $(els[3]).bind('click.DT', { action: "last" }, fnClickHandler);
        },

        "fnUpdate": function (oSettings, fnDraw) {
            var iListLength = 5;
            var oPaging = oSettings.oInstance.fnPagingInfo();
            var an = oSettings.aanFeatures.p;
            var i, j, sClass, iStart, iEnd, iHalf = Math.floor(iListLength / 2);

            if (oPaging.iTotalPages < iListLength) {
                iStart = 1;
                iEnd = oPaging.iTotalPages;
            }
            else if (oPaging.iPage <= iHalf) {
                iStart = 1;
                iEnd = iListLength;
            } else if (oPaging.iPage >= (oPaging.iTotalPages - iHalf)) {
                iStart = oPaging.iTotalPages - iListLength + 1;
                iEnd = oPaging.iTotalPages;
            } else {
                iStart = oPaging.iPage - iHalf + 1;
                iEnd = iStart + iListLength - 1;
            }

            for (i = 0, iLen = an.length; i < iLen; i++) {
                // Remove the middle elements
                $('li:gt(1)', an[i]).filter(':not(.next,.last)').remove();

                // Add the new list items and their event handlers
                for (j = iStart; j <= iEnd; j++) {
                    sClass = (j == oPaging.iPage + 1) ? 'class="active"' : '';
                    $('<li ' + sClass + '><a href="#">' + j + '</a></li>')
                        .insertBefore($('.next,.last', an[i])[0])
                        .bind('click', function (e) {
                            e.preventDefault();
                            oSettings._iDisplayStart = (parseInt($('a', this).text(), 10) - 1) * oPaging.iLength;
                            fnDraw(oSettings);
                        });
                }

                // Add / remove disabled classes from the static elements
                if (oPaging.iPage === 0) {
                    $('.first,.prev', an[i]).addClass('disabled');
                } else {
                    $('.first,.prev', an[i]).removeClass('disabled');
                }

                if (oPaging.iPage === oPaging.iTotalPages - 1 || oPaging.iTotalPages === 0) {
                    $('.next,.last', an[i]).addClass('disabled');
                } else {
                    $('.next,.last', an[i]).removeClass('disabled');
                }
            }
        }
    }
});

function AttachUIpluggins() {
    $('.month-picker').datepicker({
        format: "MM, yyyy",
        viewMode: "months",
        minViewMode: "months",
        language: 'bg'
    });



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
        $(e).find('input[type="hidden"]').val('01.01.' + $(e).find('input[type="text"]').val());
    }
}