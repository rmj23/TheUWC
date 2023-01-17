// once document loads
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
        error: function (err) {
            alert(err);
        }
    });
});

// get courses when a year is selected
$("#academicYearDropdown").on("change", function () {
    fetchCourses(); 
});

function fetchCourses() {
    var YearId = $("#academicYearDropdown").val();
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetClasses",
        data: { YearID: YearId },
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select a Course</option>';
            for (var i = 0; i < data.length; i++) {
                if (data[i].IsDefault) {
                    optionHTML += '<option value="' + data[i].ID + '" selected>' + data[i].CourseTitle + '</option>';                    
                }
                else {
                    optionHTML += '<option value="' + data[i].ID + '">' + data[i].CourseTitle + '</option>';

                }
            }
            $("#coursesDropdown").html(optionHTML);
            fetchStudents();
        },
        error: function (error) {
            alert(error);
        }
    });
    
}

// gets students when course is selected
$("#coursesDropdown").on("change", function () {
    fetchStudents();   
});

function fetchStudents() {
    var Courseid = $("#coursesDropdown").val();
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetStudents",
        data: { CourseID: Courseid },
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select a Student</option>';
            for (var i = 0; i < data.length; i++) {
                optionHTML += '<option value="' + data[i].StudentID + '">' + data[i].FirstName + " " + data[i].LastName + '</option>';
            }
            $("#studentDropdown").html(optionHTML);
        },
        error: function (error) {
            alert(error);
        }
    });
}
