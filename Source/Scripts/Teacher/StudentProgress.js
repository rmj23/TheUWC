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
            $("#coursesDropdown").html(optionHTML);
            if (DefaultSelected) {
                loadTable($("#coursesDropdown").val(), YearId);
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}


function loadTable(courseId, yearId) {
    //call ajax here
    $('#StudentsTable').DataTable({
        responsive: true,
        destroy: true,
        "ajax": {
            type: "GET",
            url: "/Teacher/GetStudentsByYearandCourse",
            data: { CourseID: courseId }
        },
        "columns": [
            { "data": "LastName" },
            { "data": "FirstName" },
            { "data": "MiddleName" },
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    return renderTaskButtons(data.StudentID, courseId, yearId);
                }
            }
        ]
    });
    document.getElementById("StudentsPanel").style.display = 'block';
}

function renderTaskButtons(studentId, courseId, yearId) {
    return "<div class='btn-group'><a class='btn btn-outline-secondary' title='View Papers' href='/Evaluation/ViewPapers?studentID=" + studentId + "&courseID=" + courseId + "&yearID=" + yearId + "'><i class='far fa-file-alt'></i></a>" +
        "<a class='btn btn-outline-secondary' title='View Goals' href='/Instruction/ViewStudentGoals?YearID=" + yearId + "&CourseID=" + courseId + "&StudentID=" + studentId + "'> <i class='fas fa-bullseye'></i></a >" +
        "<a class='btn btn-outline-secondary' title='View History' href='/Evaluation/ViewPaperHistory?studentID=" + studentId + "&courseID=" + courseId + "&yearID=" + yearId + "'><i class='fas fa-folder'></i></a>" +
        "<a class='btn btn-outline-secondary' title='View Conference Notes' href='/Instruction/ConferenceNotes?YearID=" + yearId + "&CourseID=" + courseId + "&StudentID=" + studentId + "'><i class='far fa-edit'></i></a></div>";
}

// get courses when a year is selected
$("#academicYearDropdown").on("change", function () {
    fetchCourses();
});

$("#coursesDropdown").on("change", function () {
    loadTable($("#coursesDropdown").val(), $("#academicYearDropdown").val());
});