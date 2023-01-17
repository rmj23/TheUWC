$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetYear",
        success: function (data) {
            var optionTag = '<option value="-1">Please Select a Year</option>';
            data.forEach(function (item, index) {
                optionTag += '<option value="' + item.ID + '">' + item.SchoolYear + '</option>';
            });
            $("#academicYearDropdown").html(optionTag);
        },
        error: function (error) {
            alert('Error: ' + error);
        }
    });
});

// get classes when a year is selected
$("#academicYearDropdown").on("change", function () {
    var yearid = $("#academicYearDropdown").val();
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetClasses",
        data: { YearID: yearid },
        success: function (data) {
            var optionTag = '<option value="-1">Please Select a Class</option>';
            data.forEach(function (item, index){
                optionTag += '<option value="' + item.ID + '">' + item.CourseTitle + '</option>';
            });
            $("#classDropdown").html(optionTag);
        },
        error: function (error) {
            alert('Error: ' + error);
        }
    });
});

// get eval period once class is selected and view the panels
$("#classDropdown").on("change", function () {
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetEvalMonths",
        success: function (data) {
            var optionTag = '<option value="-1">Please Select a Month</option>';
            data.forEach(function (item, index) {
                optionTag += '<option value="' + item.ID + '">' + item.evalDescription + '</option>';
            });
            $("#evalDropdown").html(optionTag);
        },
        error: function (error) {
            alert('Error: ' + error);
        }
    });
});