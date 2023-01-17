$(document).ready(function () {
    fetchYears();
})

// when eval period is selected
$("#evalDropdown").on("change", function () {
    document.getElementById("content").style.display = 'none';
    document.getElementById("loader").style.display = 'block';
    fetchEvalData();
});

$("#academicYearDropdown").on("change", function () {
    fetchCourses();
});



function fetchYears() {
    $.ajax({
        type: "GET",
        url: "/Teacher/GetAcademicYearsForDropDownList",
        success: function (data) {
            var s = '<option value="-1">Please Select a Year</option>';
            var isCurrentClassSelected;
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
        error: function (err) {
            alert(err);
        }
    });
}

function fetchCourses() {
    var YearId = $("#academicYearDropdown").val();
    $.ajax({
        type: "GET",
        url: "/Teacher/GetClassesByTeacherIDandYearID",
        data: { YearID: YearId },
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
                fetchEvalMonths();
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}

$("#classDropdown").on("change", function () {
    fetchEvalMonths();
});

function fetchEvalMonths() {
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
}

$("#evalDropDown").on("change", function () {
    fetchEvalData();
})

//final function
function fetchEvalData() {
    var courseid = $("#classDropdown").val();
    var evalperiod = $("#evalDropdown").val();
    var year = $("#academicYearDropdown").val();
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetClassData",
        data: { CourseID: courseid, EvalPeriod: evalperiod, Year: year },
        success: function (data) {
            data.forEach(function (item, index) {
                var student = "student_" + item.ScoreTypeID + item.ProficiencyTypeID;
                $("#notAvail_" + item.ScoreTypeID + item.ProficiencyTypeID).remove();
                $("#" + student + "").append("&nbsp;" + item.NameTitle + "<br />");
            });
            document.getElementById("loader").style.display = 'none';
            document.getElementById("content").style.display = 'block';
        },
        error: function (error) {
            alert('Error: ' + error);
        }
    });
}