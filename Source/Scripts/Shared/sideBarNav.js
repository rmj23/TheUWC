$(document).ready(function () {
    var manageClassMenu = $("#classMenu");
    var evalMenu = $("#evalMenu");
    var reportsMenu = $("#reportsMenu");
    var instructionMenu = $('#instructionMenu');
    var bookshelfMenu = $('#bookshelfMenu');
    var resourcesMenu = $('#resourcesMenu');
    var helpMenu = $('#helpMenu');
    var anchorPaperMenu = $('#anchorPaperMenu');
  
    // papers
    var apapers = $('#apapers');
    var bpapers = $('#bpapers');
    var cpapers = $('#cpapers');
    var dpapers = $('#dpapers');
    var epapers = $('#epapers');
    var fpapers = $('#fpapers');
    var gpapers = $('#gpapers');
    var hpapers = $('#hpapers');
    var ipapers = $('#ipapers');
    var jpapers = $('#jpapers');
    var kpapers = $('#kpapers');


    $("#sidebar").mCustomScrollbar({
        theme: "minimal",
        mouseWheel: { scrollAmount: 150 }
    });

    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
        $('.mainContent').toggleClass('active');
    });

    // when a link is clicked
    manageClassMenu.on('click', function () {
        $("#ManageClassMenu").toggleClass('active');
    });

    evalMenu.on('click', function () {
        $("#EvalMenu").toggleClass("active");
    });

    reportsMenu.on('click', function () {
        $('#ReportsMenu').toggleClass('active');
    });

    instructionMenu.on('click', function () {
        $('#InstructionMenu').toggleClass('active');
    });

    bookshelfMenu.on('click', function () {
        $('#BookshelfMenu').toggleClass('active');
    });

    resourcesMenu.on('click', function () {
        $('#ResourcesMenu').toggleClass('active');
    });

    helpMenu.on('click', function () {
        $('#HelpMenu').toggleClass('active');
    });

    // anchor paper
    anchorPaperMenu.on('click', function () {
        $('#AnchorPapers').toggleClass('active');
    });

    apapers.on('click', function () {
        $('#APapers').toggleClass('active');
    });

    bpapers.on('click', function () {
        $('#BPapers').toggleClass('active');
    });

    cpapers.on('click', function () {
        $('#CPapers').toggleClass('active');
    });

    dpapers.on('click', function () {
        $('#DPapers').toggleClass('active');
    });

    epapers.on('click', function () {
        $('#EPapers').toggleClass('active');
    });

    fpapers.on('click', function () {
        $('#FPapers').toggleClass('active');
    });

    gpapers.on('click', function () {
        $('#GPapers').toggleClass('active');
    });

    hpapers.on('click', function () {
        $('#HPapers').toggleClass('active');
    });

    ipapers.on('click', function () {
        $('#IPapers').toggleClass('active');
    });

    jpapers.on('click', function () {
        $('#JPapers').toggleClass('active');
    });

    kpapers.on('click', function () {
        $('#KPapers').toggleClass('active');
    });
});