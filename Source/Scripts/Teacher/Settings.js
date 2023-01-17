$(document).ready(function () {

    $("#classDropdown").change(function () {
        var CourseID = $("#classDropdown").val();
        setDefaultClass(CourseID);
    });

    fetchCourses();

});

function setDefaultClass(CourseID) {
    $.ajax({
        type: "POST",
        url: "/Teacher/SetDefaultClass",
        data: { CourseID: CourseID },
        success: function (data) {
            if (!(data.Success)) {
                alert(data.ErrorMessage);
            }
            else {
                alert("Default class set!");
                fetchCourses();
            }
        }
    })
}

function fetchCourses() {
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
        },
        error: function (error) {
            alert(error);
        }
    });
}