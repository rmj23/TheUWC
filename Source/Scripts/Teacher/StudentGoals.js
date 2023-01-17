$("#studentDropdown").on("change", function () {
    var studentid = $("#studentDropdown").val();
    var yearid = $("#academicYearDropdown").val();
    var courseid = $("#coursesDropdown").val();
    $("#tableStudentGoals").DataTable({
        destroy: true,
        ajax: {
            type: "GET",
            url: "/Instruction/GetStudentGoals",
            data: {
                StudentID: studentid
            }
        },
        columns: [
            { "data": "GoalPaperTitle" },
            { "data": "GoalScoreType" },
            { "data": "Description" },
            {
                "data": "DateAdded",
                "render": function (data) {
                    var date = moment.utc(data);
                    return date.format('MM/DD/YYYY');
                }
            },
            {
                "data": "DeadlineDate",
                "render": function (data) {
                    var date = moment.utc(data);
                    return date.format('MM/DD/YYYY');
                }
            },
            {
                "data": "DateFinished",
                "render": function (data) {
                    if (data == null) {
                        return "Not Completed";
                    }
                    else {
                        var date = moment.utc(data);
                        return date.format('MM/DD/YYYY');
                    }
                }
            },
            {
                "data": "GoalID",
                "render": function (data) {
                    return "<div class='btn-group'><a href='/Instruction/EditStudentGoals/?studentGoalModel=" + data + "&yearID=" + yearid + "&courseID=" + courseid + "' class='btn btn-outline-primary' title ='Edit Goal'>"
                        + "<i class='fas fa-pencil-alt'></i></a>"
                        + "<a href='/Instruction/DeleteStudentGoal/?goalID=" + data + "&yearID=" + yearid + "&courseID=" + courseid + "' class='btn btn-outline-secondary' title ='Delete Goal' onclick ='return confirm('Are you sure that you would like to delete this goal?')'>"
                        + "<i class='fas fa-trash-alt'></i></a></div>"
                },
                "orderable": false
            }
        ],
        buttons: [
            'print'
        ]
    });

    document.getElementById("studentGoalsPanel").style.display = "block";
});

// print student goals button
$("#printStudentGoalsBtn").on('click', function () {
    var studentid = $("#studentDropdown").val();
    var courseid = $("#coursesDropdown").val();
    window.location.href = "/Instruction/PrintStudentGoals/?studentID=" + studentid + "&courseID=" + courseid;
});

// add student goal button
$("#addGoalBtn").on('click', function () {
    var studentid = $("#studentDropdown").val();
    var courseid = $("#coursesDropdown").val();
    var yearid = $("#academicYearDropdown").val();
    window.location.href = "/Instruction/InsertStudentGoals/?YearID=" + yearid + "&CourseID=" + courseid + "&StudentID=" + studentid;
});