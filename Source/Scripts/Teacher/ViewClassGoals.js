$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Instruction/GetClasses",
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select a Course</option>';
            var DefaultSelected = false;
            for (var i = 0; i < data.length; i++) {
                if (data[i].IsDefault) {
                    DefaultSelected = true;
                    optionHTML += '<option value="' + data[i].ID + '" selected>' + data[i].CourseTitle + '</option>';
                }
                else {
                    optionHTML += '<option value="' + data[i].ID + '">' + data[i].CourseTitle + '</option>';

                }
            }
            $("#courseDropdown").html(optionHTML);
            if (DefaultSelected) {
                loadTable();
            }
        },
        error: function (err) {
            alert(err);
        }
    });
});



$("#courseDropdown").on("change", function () {
    loadTable();    
});

function loadTable() {
    var courseid = $("#courseDropdown").val();
    $("#tableClassGoals").DataTable({
        destroy: true,
        ajax: {
            type: "GET",
            url: "/Instruction/GetClassGoals",
            data: {
                CourseID: courseid
            }
        },
        columns: [
            { "data": "ShortDescription" },
            { "data": "FullDescription" },
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
                "data": "ID",
                "render": function (data, type, row, meta) {
                    return "<a href='/Instruction/EditClassGoals/?goalID=" + data + "&courseID=" + courseid + "' class='btn btn-outline-primary' title='Edit Goal'>"
                        + "<i class= 'fas fa-pencil-alt'></i></a>"
                        + "<a href='/Instruction/DeleteClassGoal?goalID=" + data + "&courseID=" + courseid + "' class='btn btn-outline-secondary' title = 'Delete Goal' onclick = 'return confirm('Are you sure that you would like to delete this goal?')'>"
                        + "<i class='fas fa-trash-alt'></i></a >"
                },
                "orderable": false
            }
        ]
    });
    document.getElementById("classGoalsPanel").style.display = 'block';
}

// print class goals button
$("#printClassGoalsBtn").on('click', function () {
    // test
    window.location.href = "/Instruction/PrintClassGoals/?courseID=" + $("#courseDropdown").val();
});