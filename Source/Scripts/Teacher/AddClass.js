$(document).ready(function() {
    fetchGrades();
    fetchYears();
    fetchSemesters();
    fetchSubjects();
    fetchPeriods();
});

// when grade is choosen
$("#GradeID").on('change', function() {
    fetchYears();    
});


//when year is choosen
$("#YearID").on('change', function () {
    fetchSemesters();   
});


//when course is choosen
$("#SemesterID").on('change', function () {
    fetchSubjects();
});


//when subject is choosen
$("#SubjectID").on('change', function () {
    fetchPeriods();
});

function fetchPeriods() {
    var optionTag = '<option value="0">N/A</option>';
    for (var x = 1; x < 9; x++) {
        optionTag += '<option value="' + x + '">' + x + '</option>';
    }
    $("#Period").html(optionTag);
}

function fetchSemesters() {
    $.ajax({
        type: "GET",
        url: "/Teacher/GetSemestersDropdown",
        success: function (data) {
            var optionTag = '<option value="-1">Please Select a Length of Course</option>';
            data.forEach(function (item, index) {
                optionTag += '<option value="' + item.SemesterID + '">' + item.SemesterDescription + '</option>';
            });
            $("#SemesterID").html(optionTag);
        },
        error: function (error, ex) {
            alert("Error: " + error.status);

        }
    });
}

function fetchSubjects() {
    $.ajax({
        type: "GET",
        url: "/Teacher/GetSubjectsDropdown",
        success: function (data) {
            var optionTag = '<option value="-1">Please Select a Subject</option>';
            data.forEach(function (item, index) {
                optionTag += '<option value="' + item.ID + '">' + item.Subject + '</option>';
            });
            $("#SubjectID").html(optionTag);
        },
        error: function (error, ex) {
            alert("Error: " + error.status);

        }
    });

    //enable button
    $("#submitBtn").removeClass("disabled");
    document.getElementById("submitBtn").disabled = false;
}

function fetchYears() {
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
            $("#YearID").html(s);
            if (isCurrentClassSelected) {
                //fetchSemesters();
                //fetchSubjects();
                //fetchPeriods();
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function fetchGrades() {
    $.ajax({
        type: "GET",
        url: "/Teacher/GetGradesDropdown",
        success: function (data) {
            var optionTag = '<option value="-1">Please Select a Grade</option>';
            data.forEach(function (item, index) {
                optionTag += '<option value="' + item.GradeID + '">' + item.GradeDescription + '</option>';
            });
            $("#GradeID").html(optionTag);
        },
        error: function (error, ex) {
            alert("Error: " + error.status);

        }
    });
}
