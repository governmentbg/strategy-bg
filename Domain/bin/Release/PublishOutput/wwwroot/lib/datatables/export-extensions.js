function dataTablesButtonExcel(e, dt, button, config) {
    var html5Excel = $.fn.DataTable.ext.buttons.excel();
    if (html5Excel === 'excelHtml5') {
        $.fn.dataTable.fileSave.prototype.onwriteend = function (e) {
            if (e.readyState === e.DONE) {
                dt.draw();
            }
        };
        dt.one('preXhr', function (e, s, data) {
            data.length = -1;
        }).one('draw', function (e, settings, json, xhr) {
            var excelButtonConfig = $.fn.DataTable.ext.buttons.excelHtml5;
            var addOptions = { exportOptions: { "columns": "thead th:not(.noExport)" } };

            $.extend(true, excelButtonConfig, addOptions);
            excelButtonConfig.action(e, dt, button, excelButtonConfig);
        }).draw();
    } else {
        alert('Вашият браузър не поддържа експорт!');
    }
}
function dataTablesButtonPrint(e, dt, button, config) {

    dt.one('preXhr', function (e, s, data) {
        data.length = -1;
    }).one('draw', function (e, settings, json, xhr) {
        //debugger;
        var printButtonConfig = $.fn.DataTable.ext.buttons.print;
        var addOptions = { exportOptions: { "columns": "thead th:not(.noExport)" } };

        $.extend(true, printButtonConfig, addOptions);
        printButtonConfig.action(e, dt, button, printButtonConfig);
        window.location.href = window.location.href;
    }).draw();
}

//    function (e, dt, button, config) {
                        //    var html5Excel = $.fn.DataTable.ext.buttons.excel();
                        //    if (html5Excel === 'excelHtml5') {
                        //        $.fn.dataTable.fileSave.prototype.onwriteend = function (e) {
                        //            if (e.readyState === e.DONE) {
                        //                dt.draw();
                        //            }
                        //        };
                        //        dt.one('preXhr', function (e, s, data) {
                        //            data.length = -1;
                        //        }).one('draw', function (e, settings, json, xhr) {
                        //            var excelButtonConfig = $.fn.DataTable.ext.buttons.excelHtml5;
                        //            var addOptions = { exportOptions: { "columns": "thead th:not(.noExport)" } };

                        //            $.extend(true, excelButtonConfig, addOptions);
                        //            excelButtonConfig.action(e, dt, button, excelButtonConfig);
                        //        }).draw();
                        //    } else {
                        //        alert('Вашият браузър не поддържа експорт!');
                        //    }
                        //}

//    {
                //        text: 'PDF',
                //        action: function (e, dt, button, config) {
                //            var html5Pdf = $.fn.DataTable.ext.buttons.pdf();
                //            var _length = 0;
                //            if (html5Pdf === 'pdfHtml5') {
                //                $.fn.dataTable.fileSave.prototype.onwriteend = function (e) {
                //                    if (e.readyState === e.DONE) {
                //                        dt.draw();
                //                    }
                //                };

                //                dt.one('preXhr', function (e, s, data) {
                //                    _length = data.length;
                //                    data.length = -1;
                //                }).one('draw', function (e, settings, json, xhr) {
                //                    var html5Pdf = $.fn.DataTable.ext.buttons.pdf();
                //                    var pdfButtonConfig = $.fn.DataTable.ext.buttons.pdfHtml5;
                //                    var addOptions = { exportOptions: { "columns": "thead th:not(.noExport)" } };
                //                    $.extend(true, pdfButtonConfig, addOptions);
                //                    pdfButtonConfig.action(e, dt, button, pdfButtonConfig);
                //                }).draw();
                //            } else {
                //                alert('Вашият браузър не поддържа експорт!');
                //            }
                //        }
                //    }
                //   


//    //,
                //    //{
                //    //    text: 'Print',
                //    //    action: function (e, dt, button, config) {
                //    //        dt.one('preXhr', function (e, s, data) {
                //    //            data.length = -1;
                //    //        }).one('draw', function (e, settings, json, xhr) {
                //    //            //debugger;
                //    //            var printButtonConfig = $.fn.DataTable.ext.buttons.print;
                //    //            var addOptions = { exportOptions: { "columns": "thead th:not(.noExport)" } };

                //    //            $.extend(true, printButtonConfig, addOptions);
                //    //            printButtonConfig.action(e, dt, button, printButtonConfig);
                //    //            window.location.href = window.location.href;
                //    //        }).draw();
                //    //    }
                //    //}