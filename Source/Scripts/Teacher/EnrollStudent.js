function fetchCourses() {
    var YearId = $("#academicYearDropdown").val();
    $.ajax({
        type: "GET",
        url: "/Teacher/GetClassesByTeacherIDandYearID",
        data: { YearID: YearId },
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select a Course</option>';
            var isCurrentCourseSelected;
            for (var i = 0; i < data.length; i++) {
                if (data[i].IsDefault) {
                    optionHTML += '<option value="' + data[i].ID + '" selected>' + data[i].CourseTitle + '</option>';
                    isCurrentCourseSelected = true;
                }
                else {
                    optionHTML += '<option value="' + data[i].ID + '">' + data[i].CourseTitle + '</option>';

                }
            }
            $("#coursesDropdown").html(optionHTML);
            if (isCurrentCourseSelected) {
                loadClass();
            }
        },
        error: function (error) {
            alert(error);
        }        
    });
}

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

// when a class gets selected
$("#coursesDropdown").on("change", function () {
    loadClass();
});

function loadClass() {
    var courseid = $("#coursesDropdown").val();
    $('#ClassRosterTable').DataTable({
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
            { "data": "StudentNumber" },
            {
                "data": "StudentID", "render": function (data) {
                    // add to on click  JS FUNCTION(url.action ("action", "controller"))
                    return "<button class='btn btn-outline-primary' onclick=UnenrollStudent(" + data + "," + courseid + ")>Unenroll</button>"
                },
                "orderable": false,
                "width": "auto"
            }
        ],
        "language": {
            "emptyTable": "No students are enrolled in this class, enroll a student from the district roster"
        }
    });
    GetDistrictRoster();
    document.getElementById("DistrictRosterPanel").style.display = 'block';
    document.getElementById("ClassRosterPanel").style.display = 'block';
}

// functions ////////////////////////
function GetDistrictRoster() {
    var yearid = $("#academicYearDropdown").val();
    var courseid = $("#coursesDropdown").val();
    var model = new Object();
    model.CourseID = courseid;
    $('#DistrictRoster').DataTable({
        destroy: true,
        "ajax": {
            type: "GET",
            url: "/Teacher/GetStudentsToEnroll",
            data: model,
            datatype: "json"
        },
        "columns": [
            { "data": "LastName" },
            { "data": "MiddleName" },
            { "data": "FirstName" },
            { "data": "StudentNumber" },
            {
                "data": "StudentID", "render": function (data) {
                    // add to on click  JS FUNCTION(url.action ("action", "controller"))
                    return "<button class='btn btn-outline-primary' onclick=EnrollStudent(" + data + "," + yearid + "," + courseid + ")>Enroll</button>"
                },
                "orderable": false,
                "width": "auto"
            }
        ]
    });
};

function UnenrollStudent(data, courseid) {
    var model = new Object();
    model.StudentID = data;
    model.CourseID = courseid;
    $.ajax({
        url: '/Teacher/Unenroll',
        type: "POST",
        data: model,
        success: function (data) {
            alert("Student Removed from class.")
            loadClass();
            GetDistrictRoster();
        },
        error: {

        }
    });
};

function EnrollStudent(data, yearid, courseid) {
    var model = new Object();
    model.StudentID = data;
    model.CourseID = courseid;
    console.log(JSON.stringify(model));
    $.ajax({
        url: '/Teacher/EnrollStudentPost',
        type: "POST",
        data: model,
        success: function (data) {
            alert("Student Enrolled.")
            loadClass();
        },
        error: {

        }
    });
    //alert("data needed to enroll student: " + data + " year: " + yearid + " course: " + courseid + "  working on enrolling student to current selected course");
};