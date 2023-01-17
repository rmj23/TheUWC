$(document).ready(function () {

    // get paper types
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetPaperType",
        success: function (data) {
            var s = '<option value="-1">Please Select a Paper Type</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].paperType + '</option>';
            }
            $("#Paper_paperTypeID").html(s);
        },
        error: function (err) {
            alert(err);
        }
    });

    // get eval periods
    $.ajax({
        type: "GET",
        url: "/Evaluation/GetEvalMonths",
        success: function (data) {
            var s = '<option value="-1">Please Select a Evaluation Period</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].evalDescription + '</option>';
            }
            $("#Paper_EvaluationPeriodID").html(s);
        },
        error: function (err) {
            alert(err);
        }
    });

});

$("#fileInput").on("change", function () {
    // get uploaded file ext
    var ext = $(this).val().split('.').pop().toLowerCase();

    // ext we accept
    var vaildFileExt = ['doc', 'docx', 'pdf', 'png', 'jpg'];

    // check file ext
    if ($.inArray(ext, vaildFileExt) == -1) {
        alert("Sorry!! Upload only 'doc', 'docx', 'pdf', 'png', and 'jpg' files")

        // clear file upload selected file
        $(this).replaceWith($(this).val('').clone(true));

        //disable submit button
        $('#submitBtn').prop('disabled', true);
    }
    else {
        // check and restict file to 5 mb
        if ($(this).get(0).files[0].size > (5000000)) {
            alert("Sorry!! Max allowed file size is 5 mb");

            // clear file upload slected file
            $(this).replaceWith($(this).val('').clone(true));

            // disable submit btn
            $('#submitBtn').prop('disabled', true);
        }
        else {
            // enable submit btn
            $('#submitBtn').prop('disabled', false);
        }
    }

});

$("#studentDropdown").on("change", function () {
    document.getElementById("PaperDetailsPanel").style.display = 'block';
    document.getElementById("SelectPaperPanel").style.display = 'block';
});

$("#submitBtn").on("click", function () {
    var studentid = $("#studentDropdown").val();
    var courseid = $("#coursesDropdown").val();
    var yearid = $("#academicYearDropdown").val();

    $("#Paper_StudentID").val(studentid);
    $("#Paper_CourseID").val(courseid);
    $("#Paper_YearID").val(yearid);
});
