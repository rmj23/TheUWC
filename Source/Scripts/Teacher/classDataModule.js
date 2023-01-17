$(function () {

    var data = {
        labels: ['Below Basic', 'Basic', 'Proficient', 'Advanced', 'Advanced Plus'],
        series: [5, 3, 4, 12, 9]
    };

    var sum = function (a, b) { return a + b };

    /** Creates the Class Data Module chart **/
    new Chartist.Pie('.ct-chart', data, {
        labelInterpolationFnc: function (value) {
            //return Math.round(value / data.series.reduce(sum) * 100) + '%'; ** Returns a percentage.
            return value;
        }
    });

    /** Below Basic **/
    $(document).on("click", ".ct-series-a", function () {
        bootbox.dialog({
            title: "Student Roster - <span class='text-orangeRoughy'>Below Basic</span>",
            message: "<ul class='list-group'>" +
                        "<li class='list-group-item'>Cras justo odio</li>" + 
                        "<li class='list-group-item'>Dapibus ac facilisis in</li>" + 
                        "<li class='list-group-item'>Morbi leo risus</li>" +
                        "<li class='list-group-item'>Porta ac consectetur ac</li>" +
                        "<li class='list-group-item'>Vestibulum at eros</li>" +
                     "</ul>",
            buttons: {
                print: {
                    label: "<i class='fa fa-print'></i> Print",
                    className: "btn-default",
                    callback: function () {
                        window.print();
                    }
                },
                success: {
                    label: "Close",
                    className: "btn-default",
                    callback: function () {

                    }
                }
            }
        });
    });

    /** Basic **/
    $(document).on("click", ".ct-series-b", function () {
        bootbox.dialog({
            title: "Student Roster - <span class='text-yellowFuel'>Basic</span>",
            message: "<ul class='list-group'>" +
                        "<li class='list-group-item'>Cras justo odio</li>" +
                        "<li class='list-group-item'>Dapibus ac facilisis in</li>" +
                        "<li class='list-group-item'>Morbi leo risus</li>" +
                        "<li class='list-group-item'>Porta ac consectetur ac</li>" +
                        "<li class='list-group-item'>Vestibulum at eros</li>" +
                     "</ul>",
            buttons: {
                print: {
                    label: "<i class='fa fa-print'></i> Print",
                    className: "btn-default",
                    callback: function () {
                        window.print();
                    }
                },
                success: {
                    label: "Close",
                    className: "btn-default",
                    callback: function () {

                    }
                }
            }
        });
    });

    /** Proficient **/
    $(document).on("click", ".ct-series-c", function () {
        bootbox.dialog({
            title: "Student Roster - <span class='text-greenJewel'>Proficient</span>",
            message: "<ul class='list-group'>" +
                        "<li class='list-group-item'>Cras justo odio</li>" +
                        "<li class='list-group-item'>Dapibus ac facilisis in</li>" +
                        "<li class='list-group-item'>Morbi leo risus</li>" +
                        "<li class='list-group-item'>Porta ac consectetur ac</li>" +
                        "<li class='list-group-item'>Vestibulum at eros</li>" +
                     "</ul>",
            buttons: {
                print: {
                    label: "<i class='fa fa-print'></i> Print",
                    className: "btn-default",
                    callback: function () {
                        window.print();
                    }
                },
                success: {
                    label: "Close",
                    className: "btn-default",
                    callback: function () {

                    }
                }
            }
        });
    });

    /** Advanced **/
    $(document).on("click", ".ct-series-d", function () {
        bootbox.dialog({
            title: "Student Roster - <span class='text-blueTradewind'>Advanced</span>",
            message: "<ul class='list-group'>" +
                        "<li class='list-group-item'>Cras justo odio</li>" +
                        "<li class='list-group-item'>Dapibus ac facilisis in</li>" +
                        "<li class='list-group-item'>Morbi leo risus</li>" +
                        "<li class='list-group-item'>Porta ac consectetur ac</li>" +
                        "<li class='list-group-item'>Vestibulum at eros</li>" +
                     "</ul>",
            buttons: {
                print: {
                    label: "<i class='fa fa-print'></i> Print",
                    className: "btn-default",
                    callback: function () {
                        window.print();
                    }
                },
                success: {
                    label: "Close",
                    className: "btn-default",
                    callback: function () {

                    }
                }
            }
        });
    });

    /** Advanced Plus **/
    $(document).on("click", ".ct-series-e", function () {
        bootbox.dialog({
            title: "Student Roster - <span class='text-blueBluemine'>Advanced Plus</span>",
            message: "<ul class='list-group'>" +
                        "<li class='list-group-item'>Cras justo odio</li>" +
                        "<li class='list-group-item'>Dapibus ac facilisis in</li>" +
                        "<li class='list-group-item'>Morbi leo risus</li>" +
                        "<li class='list-group-item'>Porta ac consectetur ac</li>" +
                        "<li class='list-group-item'>Vestibulum at eros</li>" +
                     "</ul>",
            buttons: {
                print: {
                    label: "<i class='fa fa-print'></i> Print",
                    className: "btn-default",
                    callback: function () {
                        window.print();
                    }
                },
                success: {
                    label: "Close",
                    className: "btn-default",
                    callback: function () {

                    }
                }
            }
        });
    });

    /** View Data Button **/
    $(document).on("click", ".btn-displayClassDataModule", function () {
        bootbox.dialog({
            title: "Student Roster",
            message:
                    "<div class='tab-base'>" +
                        "<!--Nav tabs-->" + 
                        "<ul class='nav nav-tabs'>" + 
                            "<li class='active'><a data-toggle='tab' href='#demo-ico-lft-tab-1' class='text-orangeRoughy'>Below Basic</a></li>" +
                            "<li><a data-toggle='tab' href='#demo-ico-lft-tab-2' class='text-yellowFuel'>Basic</a></li>" +
                            "<li><a data-toggle='tab' href='#demo-ico-lft-tab-3' class='text-greenJewel'>Proficient</a></li>" +
                            "<li><a data-toggle='tab' href='#demo-ico-lft-tab-4' class='text-blueTradewind'>Advanced</a></li>" +
                            "<li><a data-toggle='tab' href='#demo-ico-lft-tab-5' class='text-blueBluemine'>Advanced Plus</a></li>" +
                        "</ul>" +
                        "<!-- Tabs Content -->" + 
                        "<div class='tab-content'>" +
                            "<div id='demo-ico-lft-tab-1' class='tab-pane fade active in'>" +
                                "<ul class='list-group'>" +
                                    "<li class='list-group-item'>Cras justo odio</li>" +
                                    "<li class='list-group-item'>Dapibus ac facilisis in</li>" +
                                    "<li class='list-group-item'>Morbi leo risus</li>" +
                                    "<li class='list-group-item'>Porta ac consectetur ac</li>" +
                                    "<li class='list-group-item'>Vestibulum at eros</li>" +
                                 "</ul>" +
                            "</div>" +
                            "<div id='demo-ico-lft-tab-2' class='tab-pane fade'>" +
                                "<ul class='list-group'>" +
                                    "<li class='list-group-item'>Cras justo odio</li>" +
                                    "<li class='list-group-item'>Dapibus ac facilisis in</li>" +
                                    "<li class='list-group-item'>Morbi leo risus</li>" +
                                    "<li class='list-group-item'>Porta ac consectetur ac</li>" +
                                    "<li class='list-group-item'>Vestibulum at eros</li>" +
                                 "</ul>" +
                            "</div>" +
                            "<div id='demo-ico-lft-tab-3' class='tab-pane fade'>" +
                                "<ul class='list-group'>" +
                                    "<li class='list-group-item'>Cras justo odio</li>" +
                                    "<li class='list-group-item'>Dapibus ac facilisis in</li>" +
                                    "<li class='list-group-item'>Morbi leo risus</li>" +
                                    "<li class='list-group-item'>Porta ac consectetur ac</li>" +
                                    "<li class='list-group-item'>Vestibulum at eros</li>" +
                                 "</ul>" +
                            "</div>" +
                            "<div id='demo-ico-lft-tab-4' class='tab-pane fade'>" +
                                "<ul class='list-group'>" +
                                    "<li class='list-group-item'>Cras justo odio</li>" +
                                    "<li class='list-group-item'>Dapibus ac facilisis in</li>" +
                                    "<li class='list-group-item'>Morbi leo risus</li>" +
                                    "<li class='list-group-item'>Porta ac consectetur ac</li>" +
                                    "<li class='list-group-item'>Vestibulum at eros</li>" +
                                 "</ul>" +
                            "</div>" +
                            "<div id='demo-ico-lft-tab-5' class='tab-pane fade'>" +
                                "<ul class='list-group'>" +
                                    "<li class='list-group-item'>Cras justo odio</li>" +
                                    "<li class='list-group-item'>Dapibus ac facilisis in</li>" +
                                    "<li class='list-group-item'>Morbi leo risus</li>" +
                                    "<li class='list-group-item'>Porta ac consectetur ac</li>" +
                                    "<li class='list-group-item'>Vestibulum at eros</li>" +
                                 "</ul>" +
                            "</div>" +
                        "</div>" +
                    "</div>",
            buttons: {
                print: {
                    label: "<i class='fa fa-print'></i> Print",
                    className: "btn-default",
                    callback: function () {
                        window.print();
                    }
                },
                success: {
                    label: "Close",
                    className: "btn-default",
                    callback: function () {

                    }
                }
            }
        });
    });

});