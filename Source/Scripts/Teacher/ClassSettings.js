$(document).ready(function () {
    fetchYears();

});

$("#academicYears").on('change', function () {
    var yearid = $("#academicYears").val();
    getTableData(yearid);
});

/////////////////////////////////
////////// FUNCTIONS ////////////
/////////////////////////////////

function fetchYears() {
    $.ajax({
        type: "GET",
        url: "/Teacher/GetAcademicYearsForDropDownList",
        success: function (data) {

            var optionTag = '<option value="-1">Please Select a Year</option>';
            var isCurrentYearSelected;

            for (var x = 0; x < data.length; x++) {
                if (data[x].IsCurrent == true) {
                    optionTag += '<option value="' + data[x].ID + '" selected>' + data[x].SchoolYear + '</option>';
                    isCurrentYearSelected = true
                }
                else {
                    optionTag += '<option value="' + data[x].ID + '">' + data[x].SchoolYear + '</option>';
                }
            }
         
            $("#academicYears").html(optionTag);
            if (isCurrentYearSelected) {
                // call ajaz to get table data
                var yearid = $("#academicYears").val();
                getTableData(yearid);
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}

function getTableData(yearid) {
    $("#listOfClasses").DataTable({
        destroy: true,
        "ajax": {
            type: "GET",
            url: "/Settings/GetClassesByTeacherAndYear",
            data: { yearid }
        },
        "columns": [
            { "data": "CourseTitle" },
            {
                "data": "ID", "render": function (data) {
                    return renderButtons(data);
                }
            }
        ]
    });
}

function renderButtons(courseID) {
    return "<div class='btn-group'><button onclick='editClass(" + courseID + ")' class='btn btn-outline-primary'><i class='far fa-edit'></i></button><button onclick='deleteClass(" + courseID + ")' class='btn btn-outline-secondary'><i class='far fa-trash-alt'></i></button></div>";
}

function editClass(courseID) {
    window.location.href = '/Settings/EditClass?CourseID=' + courseID;
}

function deleteClass(courseID) {
    var confirmance = confirm("DELETING THIS CLASS WILL REMOVE ANY PROJECTS, PROJECT EVALUATIONS, BOOKSHELF PAPERS, STUDENT GOALS, AND CLASS GOALS. ARE YOU SURE?");
    if (confirmance == true) {
        $.ajax({
            type: "POST",
            url: "/Settings/DeleteCourse",
            data: {
                courseID
            },
            success: function (data) {
                if (data == 0) {
                    alert("Sorry there was an error deleting this class.");
                }
                else {
                    $("#listOfClasses").DataTable().ajax.reload();
                }
            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });
    }
}