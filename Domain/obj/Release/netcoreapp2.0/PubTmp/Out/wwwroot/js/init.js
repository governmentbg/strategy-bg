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
        "bLengthChange": false,
        "serverSide": true,
        "processing": true,
        "paging": true,
        "pageLength": 20,
        "stateSave": false,
        "stateDuration": -1
    });

    $('.date-picker').datepicker({
        format: 'dd.mm.yyyy',
        todayBtn: "linked",
        language: 'bg'
    });

    //$('.datetime-picker').datetimepicker({
    //    format: 'DD.MM.YYYY HH:mm',
    //    locale: 'bg-BG'
    //});

})();
