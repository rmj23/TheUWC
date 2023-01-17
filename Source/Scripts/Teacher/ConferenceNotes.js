$("#studentDropdown").on("change", function () {
    var yearid = $("#academicYearDropdown").val();
    var courseid = $("#coursesDropdown").val();
    var studentid = $("#studentDropdown").val();
    $("#tableConferenceNotes").dataTable({
        destroy: true,
        ajax: {
            type: "GET",
            url: "/Instruction/GetStudentConferenceNotes",
            data: {
                CourseID: courseid,
                StudentID: studentid
            }
        },
        columns: [
            {
                "data": "Date",
                "render": function (data) {
                    if (data == null) {
                        return "N/A";
                    }
                    else {
                        var date = moment.utc(data);
                        return date.format('MM/DD/YYYY');
                    }
                }
            },
            { "data": "Description" },
            { "data": "StageOrDraft" },
            { "data": "Comments" },
            {
                "data": "ConferenceID",
                "render": function (data) {
                    return "<div class='btn-group'><a href='/Instruction/EditConferenceNotes/?conID=" + data + "&yearID=" + yearid + "' class='btn btn-outline-primary'><i class='fas fa-pencil-alt'></i></a>"
                        + "<a href='/Instruction/DeleteConferenceNotes/?con=" + data + "&yearID=" + yearid + "&courseID=" + courseid + "&studentID=" + studentid + "' class='btn btn-outline-secondary'><i class='fas fa-trash-alt'></i></a></div>";
                },
                "orderable": false
            }
        ]
    });
    document.getElementById("studentGoalsPanel").style.display = 'flex';
});

$("#PrintBtn").on("click", function () {
    var courseid = $("#coursesDropdown").val();
    var studentid = $("#studentDropdown").val();
    window.location.href = "/Instruction/PrintConferenceNotes/?courseID=" + courseid + "&studentID=" + studentid;
});

$("#AddBtn").on("click", function () {
    var yearid = $("#academicYearDropdown").val();
    var courseid = $("#coursesDropdown").val();
    var studentid = $("#studentDropdown").val();
    window.location.href = "/Instruction/InsertConferenceNotes/?YearID=" + yearid + "&CourseID=" + courseid + " &StudentID=" + studentid;
});