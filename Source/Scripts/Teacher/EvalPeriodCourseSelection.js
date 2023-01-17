$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetYear",
        success: function (data) {
            var isCurrentClassSelected;
            var s = '<option value="-1">Please Select a Year</option>';
            for (var i = 0; i < data.length; i++) {
                if (data[i].IsCurrent == true) {
                    s += '<option value="' + data[i].ID + '" selected>' + data[i].SchoolYear + '</option>';
                    isCurrentClassSelected = true;
                }
                else {
                    s += '<option value="' + data[i].ID + '">' + data[i].SchoolYear + '</option>';
                }
            }
            $("#academicYearDropdown").html(s);
            if (isCurrentClassSelected) {
                fetchCourses();
            }
        },
        error: function (error) {
            alert('Error: ' + error);
        }
    });
});

// get classes when a year is selected
$("#academicYearDropdown").on("change", function () {
    fetchCourses();  
});

function fetchCourses() {
    var yearid = $("#academicYearDropdown").val();
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetClasses",
        data: { YearID: yearid },
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select a Course</option>';
            for (var i = 0; i < data.length; i++) {
                if (data[i].IsDefault) {
                    DefaultSelected = true;
                    optionHTML += '<option value="' + data[i].ID + '" selected>' + data[i].CourseTitle + '</option>';
                }
                else {
                    optionHTML += '<option value="' + data[i].ID + '">' + data[i].CourseTitle + '</option>';

                }
            }
            $("#classDropdown").html(optionHTML);
            if (DefaultSelected) {
                fetchEvalPeriods();
            }
        },
        error: function (error) {
            alert('Error: ' + error);
        }
    });
}

// get eval period once class is selected and view the panels
function fetchEvalPeriods() {
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetEvalPeriod",
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
}