$(document).ready(function () {

    $('[data-toggle="tooltip"]').tooltip();

    $("#demo-dt-basic1").dataTable({
        responsive: true,
        destroy: true,
        ordering: false
    });

    //$("#submitBtn").prop('disabled', true);
});

$("#file").on("change", function () {
    // get uploaded file ext
    var ext = $(this).val().split('.').pop().toLowerCase();

    // ext we accept
    //var vaildFileExt = ['doc', 'docx', 'pdf', 'png', 'jpg', 'mov', 'avi', 'mp4', 'pptx'];
    var vaildFileExt = ['doc', 'docx', 'pdf', 'jpg'];
    // check file ext
    if ($.inArray(ext, vaildFileExt) == -1) {
        alert("Sorry!! Upload only 'doc', 'docx', 'pdf', 'jpg' files at the moment! More to come!")

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

$('#deletePaperBtn').submit(function () {
    if (!confirm("Are you sure you want to delete this paper?")) {
        return false; //Cancel the submit if the user clicked Cancel button
    }
});

function NoPaper(paperid, studentid, evalid, courseid) {
    $("#Paper_PaperID").val(paperid);
    $("#Paper_StudentID").val(studentid);
    $("#Paper_EvaluationPeriodID").val(evalid);
    $("#Paper_CourseID").val(courseid);
}

