$(document).ready(function () {
    $("#evalPeriods").on("change", function () {
        var courseid = $("#CourseID").val();
        var paperid = $("#paperType").val();
        var element = $("#evalPeriods").val();
        GetContinuum(courseid, paperid, element);
    });

    fetchClasses();
});

function fetchClasses() {
    var YearId = $("#CurrentYear").val();
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
            $("#CourseID").val($("#classDropdown").val());

            if (DefaultSelected) {
                fetchPaperTypes();
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}

function fetchPaperTypes() {
    $.ajax({
        type: "GET",
        url: "/Instruction/getPaperTypes",
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select a Paper Type</option>';
            for (var x = 0; x < data.length; x++) {
                optionHTML += '<option value="' + data[x].ID + '">' + data[x].paperType + '</option>';
            }
            $("#paperType").html(optionHTML);
        },
        error: function (error) {
            alert(error);
        }
    });
}

function fetchWritingElements() {
    $.ajax({
        type: "GET",
        url: "/Instruction/getWritingElements",
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select an Element</option>';
            for (let item of data) {
                optionHTML += '<option value="' + item.ID + '">' + item.Title + '</option>';
            }
            $("#evalPeriods").html(optionHTML);
        },
        error: function (error) {
            alert(error);
        }
    });
}

function GetContinuum(courseid, paperid, element) {
    $.ajax({
        type: "GET",
        url: "/Instruction/getContinuum",
        datatype: "json",
        data: {
            CourseID: courseid,
            EvalID: element,
            PaperTypeID: paperid
        },
        success: function (data) {            
            var th = "";
            var td = "";
            for (var x = 0; x < data.length; x++) {
                if (data.length == 3) {
                    if (x == 0) {
                        th += "<th>" + data[x].Letter + " (Basic)</th>";
                    }
                    else if (x == 1) {
                        th += "<th>" + data[x].Letter + " (Proficient)</th>";
                    }
                    else if (x == 2) {
                        th += "<th>" + data[x].Letter + " (Advanced)</th>";
                    }
                }
                else {
                    if (x == 0) {
                        th += "<th>" + data[x].Letter + " (Proficient)</th>";
                    }
                    else if (x == 1) {
                        th += "<th>" + data[x].Letter + " (Advanced)</th>";
                    }
                }
                td += "<td>" + data[x].Guidelines + "</td>";
            }
            $("#tableRow").html(th);
            $("#tableData").html(td);
            $("#EvalTitleTemp").val(data[0].Title);
            
            document.getElementById("continuum").style.display = 'block';

            $("#continuumTable").dataTable({
                destroy: true
            });
        },
        error: function (err) {
            alert(err);
        }
    });
}

$("#paperType").change(function () {
    fetchWritingElements();
});