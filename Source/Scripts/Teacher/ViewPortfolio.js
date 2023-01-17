// when doc load get years

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
        }
    });

    $('[data-toggle="tooltip"]').tooltip();
});

// get course when a year is selected
$("#academicYearDropdown").on("change", function () {
    fetchCourses();
});

function fetchCourses() {
    var Yearid = $("#academicYearDropdown").val();
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetClasses",
        data: { YearID: Yearid },
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
};

// get eval months when a class is selected
$("#classDropdown").on("change", function () {
    fetchEvalPeriods();  
});

function fetchEvalPeriods() {
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetEvalMonths",
        success: function (data) {
            var optionTag = '<option value="-1">Please Select a Evaluation Month</option>';
            for (var i = 0; i < data.length; i++) {
                optionTag += '<option value="' + data[i].ID + '">' + data[i].evalDescription + '</option>';
            }

            $("#evalDropdown").html(optionTag);
        },
        error: function (error) {
            alert('Error: ' + error);
        }
    });
}

// populate table when a month is selected

$("#evalDropdown").on("change", function () {
        
    document.getElementById("TablePanel").style.display = 'block';
    GetProfolio();

});

///////////////////
/// FUNCTIONS /////
///////////////////

// get profolio 
function GetProfolio() {
    var Courseid = $("#classDropdown").val();
    var Evalmonth = $("#evalDropdown").val();
    var Yearid = $("#academicYearDropdown").val();

    $('#portfolioTable').DataTable({
        destroy: true,
        "ajax": {
            type: "GET",
            url: "/Evaluation/GetStudentsWithCourseAndMonth",
            data: { CourseID: Courseid, EvalMonth: Evalmonth },
            datatype: "json"
        },
        "columns": [
            { "data": "lastName" },
            { "data": "firstName" },
            { "data": "middleName" },
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    // no paper uploaded
                    if (data.Paper == null) {
                        // check if theres a paper title
                        if (data.PaperTitle == null) {
                            return "*No Paper Title* <br/><br/><b>No Paper Uploaded</b>"
                        }
                        else {
                            return data.PaperTitle + "<br/><br/><b>No Paper Uploaded</b>";
                        }
                    }
                    else
                        return data.PaperTitle;
                },
                "defaultContent": "<b>No Paper Uploaded Yet</b>"

            },
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    //has paper but not evaluated
                    if (data.Paper != null && data.EvaluationID == 0) {
                        return "<div class='btn-group'><a href='/Evaluation/ViewPapers?studentID=" + data.StudentID + "&CourseID=" + Courseid + "&YearID=" + Yearid + "' class='btn btn-warning' data-toggle='tooltip' data-placement='bottom' title='No paper'><i class='far fa-file-alt'></i></a>" +
                            RenderButtons(data.StudentID, Courseid, Yearid);
                        //return "paper id: " + data.PaperID + " evalID: " + data.EvaluationID;
                    }
                    // has no paper but is evaluated
                    else if (data.Paper == null && data.EvaluationID != 0) {
                        return "<div class='btn-group'><a href='/Evaluation/ViewPapers?studentID=" + data.StudentID + "&CourseID=" + Courseid + "&YearID=" + Yearid + "' class='btn btn-warning' data-toggle='tooltip' data-placement='bottom' title='not graded'><i class='far fa-file-alt'></i></a>" +
                            RenderButtons(data.StudentID, Courseid, Yearid);
                    }
                    // has paper and its graded
                    else if (data.Paper != null && data.EvaluationID != 0) {
                        return "<div class='btn-group'><a href='/Evaluation/ViewPapers?studentID=" + data.StudentID + "&CourseID=" + Courseid + "&YearID=" + Yearid + "' class='btn btn-success' data-toggle='tooltip' data-placement='bottom' title='View Papers.'><i class='far fa-file-alt'></i></a>" +
                            RenderButtons(data.StudentID, Courseid, Yearid);
                    }
                    // has no paper and not evaluated
                    else if (data.Paper == null && data.EvaluationID == 0) {
                        return "<div class='btn-group'><a href='/Evaluation/ViewPapers?studentID=" + data.StudentID + "&CourseID=" + Courseid + "&YearID=" + Yearid + "' class='btn btn-danger' data-toggle='tooltip' data-placement='bottom' title='View Papers.'><i class='far fa-file-alt'></i></a>" +
                            RenderButtons(data.StudentID, Courseid, Yearid);
                    }
                   
                },
                "defaultContent" : "Error",
                "orderable": false,
                "width": "auto"
            }
        ],
        "language": {
            "emptyTable": "No Students for this Benchmark month"
        }

    });
};

function RenderButtons(studentid, courseid, yearid) {
    return "<a class='btn btn-outline-secondary' href='/Instruction/ViewStudentGoals/?YearID=" + yearid + "&CourseID=" + courseid + "&StudentID=" + studentid + "' title='View goals.'><i class='fa fa-bullseye'></i></a> " +
        "<a class='btn btn-outline-secondary' href='/Evaluation/ViewPaperHistory/?studentID=" + studentid + "&courseID=" + courseid + "&yearID=" + yearid + "'><i class='fa fa-folder' title='View history.'></i></a>" +
        "<a class='btn btn-outline-secondary' href='/Instruction/ConferenceNotes/?YearID=" + yearid + "&CourseID=" + courseid + "&StudentID=" + studentid + "'><i class='far fa-edit' title='View conference notes.'></i></a></div>";
};

