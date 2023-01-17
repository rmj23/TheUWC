$(document).ready(function () {
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
});

// get courses when a year is selected
$("#academicYearDropdown").on("change", function () {
    fetchCourses();
});

function fetchCourses() {
    var YearId = $("#academicYearDropdown").val();
    $.ajax({
        type: "GET",
        url: "/Teacher/GetClassesByTeacherIDandYearID",
        data: { YearID: YearId },
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select a Course</option>';
            var DefaultSelected;
            for (var i = 0; i < data.length; i++) {
                if (data[i].IsDefault) {
                    DefaultSelected = true;
                    optionHTML += '<option value="' + data[i].ID + '" selected>' + data[i].CourseTitle + '</option>';
                }
                else {
                    optionHTML += '<option value="' + data[i].ID + '">' + data[i].CourseTitle + '</option>';

                }
            }
            $("#coursesDropdown").html(optionHTML);
            if (DefaultSelected) {
                fetchStudents();
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}
$("#coursesDropdown").on("change", function () {
    fetchStudents();   
});

function fetchStudents() {
    var courseid = $("#coursesDropdown").val();
    $('#AccountsTable').DataTable({
        destroy: true,
        "ajax": {
            type: "GET",
            url: "/Teacher/GetStudentsByYearandCourse",
            data: { CourseID: courseid },
            datatype: "json"
        },
        "columns": [
            { "data": "LastName" },
            { "data": "MiddleName" },
            { "data": "FirstName" },
            { "data": "Suffix" },
            { "data": "StudentNumber" },
            {
                "data": "StudentID", "render": function (data) {
                    // add to on click  JS FUNCTION(url.action ("action", "controller"))
                    return "<div class='row mx-auto'><button class='btn btn-outline-primary' onclick=ViewParents(" + data + "," + courseid + ")>Parent Accounts</button>" +
                        "<br/><button class='btn btn-outline-secondary ml-2' onclick=ViewStudents(" + data + "," + courseid + ")>Student Accounts</button></div>"
                },
                "orderable": false,
                "width": "auto"
            }
        ],
        "language": {
            "emptyTable": "No students are enrolled in this class, enroll a student from the district roster"
        }
    });
    document.getElementById("AccountsPanel").style.display = 'block';
}

function ViewParents(studentID, courseID) {
    window.location.href = "/Teacher/ParentAccountManagement?ID=" + studentID + "&courseID=" + courseID;
};

function ViewStudents(studentID, courseID) {
    window.location.href = "/Teacher/EditStudent?studentID=" + studentID + "&courseID=" + courseID;
};
