var scoreList = [];
//the continuum has three seperate for loops, one for the header, content, and footer. This forces changing a lot of classes in the css.
function shiftLeft() {
    var table = $('.tab-pane.active').find("[id^='tableCharacteristicType']:not([id$='foo-search'],[id$='filter-status'])");
    var heading = table.find('thead tr th.active');
    var content = table.find('tbody tr td.active');
    var foot = table.find('tfoot tr td.active');
    var col = heading.index();
    console.log(col);

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
    var table = $('.tab-pane.active').find("[id^='tableCharacteristicType']:not([id$='foo-search'],[id$='filter-status'])");
    var heading = table.find('thead tr th.active');
    var content = table.find('tbody tr td.active');
    var foot = table.find('tfoot tr td.active');
    var col = heading.index();
    console.log(col);
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
    $('.btn-shift-left').on('click',
        function () {

            shiftLeft();
        });

    // Handles shifting to the right.
    $('.btn-shift-right').on('click',
        function () {

            shiftRight();
        });
});

//Script for nav the elements
$(function () {
    var currentElement = "";//id of row ("row_1, row_2, etc) of the elements (outgoing) <li> item
    var lastElement = "";//id of row ("row_1, row_2, etc) of the elements (incoming) <li> item
    var currentChar = "";//id of characteristic ("char_1", "char_2", etc) <li> item
    var listOfElements = [];
    var listOfCharacteristics = [];

    $(document).ready(function () {

        if (currentElement == "") {//The page is a fresh load
            currentElement = $(".buttonElement.list-group-item").first().attr('id'); //Stores the ID of the first Element on the page
            $("#" + currentElement).addClass('active');//Add the active class to element
            $('.hidden' + currentElement).toggleClass('rowHidden rowProjectSeen');//Allow the element's characteristics to be seen
            currentChar = $('.hidden' + currentElement).children("ul:first").children("li:first").attr('id');//Store ID of first characteristic of element
            $("#" + currentChar).children("a:first").trigger('click');//Trigger a click of the first characteristic in the element
            //Populate listOfElements with all the Elements on the page
            $(".buttonElement.list-group-item").each(
                function (i) {
                    listOfElements.push($(this).attr('id'));
                });
            //Populate listOfCharacteristics with all the characteristics on the page
            for (var i = 0; i < listOfElements.length; i++) {
                var inList = [];
                $('.hidden' + listOfElements[i]).children().find('li').each(
                    function () {
                        inList.push($(this).attr('id'));
                    });
                listOfCharacteristics.push(inList);
            }
        }
    });


    $('.buttonElement').click(function () {
        var hrefID;
        //Remove active class from stored ID
        //Add hide it's characteristics
        if (currentElement != "") {//Traversing after load
            lastElement = currentElement;//set the outgoing element ot lstElement
            currentElement = $(this).attr('id');//Set the clicked element to newElement

            $("#" + lastElement).removeClass('active');//remove the active class from the last element
            $(".hidden" + lastElement).toggleClass('rowHidden rowProjectSeen');//Hide last element's characteristics
            $("#" + currentChar).removeClass('active');//remove the current Characteristics active designation on the side bar
            var hrefID = $('#' + currentChar).find('a').attr('href');//Retrieve href from active characteristic to ensure it is hidden MANUAL ACTIVE

            $("#" + currentElement).addClass('active');//Activate the new Element
            $('.hidden' + currentElement).toggleClass('rowHidden rowProjectSeen');//Allow the new elements characteristics to be seen
            currentChar = $('.hidden' + currentElement).children("ul:first").children("li:first").attr('id');//Store ID of first characteristic of element
            $("#" + currentChar).children("a:first").trigger('click');//Trigger a click of the first characteristic in the element
            $(hrefID).removeClass('active');//Manually remove active class from tab-content to ensure it is hidden MANUAL ACTIVE
        }
    });
});
