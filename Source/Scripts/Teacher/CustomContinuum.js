function shiftLeft() {
    var table = $('#customCriteriaTable');
    var heading = table.find('thead tr th.active');
    var content = table.find('tbody tr td.active');
    var foot = table.find('tfoot tr td.active');
    var col = heading.index();
    $.fn.removeClassLeftCase = function () {
        //Remove active classes
        $(this).prev().removeClass("prevActive");
        $(this).removeClass("active");
        $(this).next().removeClass("postActive");
        //Place active classes
        $(this).prev().addClass("active");
        $(this).addClass("postActive");
        $(this).next().addClass("postPostActive");
    }
    $.fn.removeClassMiddleCase = function () {
        //Remove active classes
        $(this).prev().removeClass("prevActive");
        $(this).removeClass("active");
        $(this).next().removeClass("postActive");
        //Place active classes
        $(this).addClass("postActive");
        $(this).prev().addClass("active");
        $(this).prev().prev().addClass("prevActive");
    }
    $.fn.removeClassRightCase = function () {
        //Remove active classes
        $(this).prev().prev().removeClass("prevPrevActive");
        $(this).prev().removeClass("prevActive");
        $(this).removeClass("active");
        //Place active classes
        $(this).prev().prev().addClass("prevActive");
        $(this).prev().addClass("active");
        $(this).addClass("postActive");
    }
    //For edge case left
    if (col == 1) {
        heading.removeClassLeftCase();
        content.removeClassLeftCase();
        foot.removeClassLeftCase();
    }
    //For when the column is not at an edge case
    else if (col > 1 && col < 13) {
        heading.removeClassMiddleCase();
        content.removeClassMiddleCase();
        foot.removeClassMiddleCase();
    }
    //For when the column is end right
    else if (col == 13) {
        heading.removeClassRightCase();
        content.removeClassRightCase();
        foot.removeClassRightCase();
    }

};

function shiftRight() {
    var table = $('#customCriteriaTable');
    var heading = table.find('thead tr th.active');
    var content = table.find('tbody tr td.active');
    var foot = table.find('tfoot tr td.active');
    var col = heading.index();
    $.fn.removeClassLeftCase = function () {
        //Remove active classes
        $(this).removeClass("active");
        $(this).next().removeClass("postActive");
        $(this).next().next().removeClass("postPostActive");
        //Place active classes
        $(this).addClass("prevActive");
        $(this).next().addClass("active");
        $(this).next().next().addClass("postActive");
    }
    $.fn.removeClassMiddleCase = function () {
        //Remove active classes
        $(this).prev().removeClass("prevActive");
        $(this).removeClass("active");
        $(this).next().removeClass("postActive");
        //Place active classes
        $(this).addClass("prevActive");
        $(this).next().addClass("active");
        $(this).next().next().addClass("postActive");
    }
    $.fn.removeClassRightCase = function () {
        //Remove active classes
        $(this).prev().removeClass("prevActive");
        $(this).removeClass("active");
        $(this).next().removeClass("postActive");
        //Place active classes
        $(this).prev().addClass("prevPrevActive");
        $(this).addClass("prevActive");
        $(this).next().addClass("active");
    }
    //Edge case left
    if (col == 0) {
        heading.removeClassLeftCase();
        content.removeClassLeftCase();
        foot.removeClassLeftCase();
    }
    //Middle case
    else if (col > 0 && col < 12) {
        heading.removeClassMiddleCase();
        content.removeClassMiddleCase();
        foot.removeClassMiddleCase();
    }
    //Edge case right
    else if (col == 12) {
        heading.removeClassRightCase();
        content.removeClassRightCase();
        foot.removeClassRightCase();
    }
}



//Script for shifting the continuum left or right with chevron buttons

$(function () {
    // Handles shifting to the left.
    $('#btn-shift-left').on('click',
        function () {
            shiftLeft();
        });

    // Handles shifting to the right.
    $('.btn-shift-right').on('click',
        function () {
            shiftRight();
        });
});

function hasCustomCriteria() {
    $("#customCriteriaPartial").removeClass('hidden');
}

function hasCustomCriteriaFalse() {
    $("#customCriteriaPartial").addClass('hidden');
}
