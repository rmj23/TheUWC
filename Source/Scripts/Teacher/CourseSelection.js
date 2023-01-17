$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Instruction/GetClasses",
        success: function (data) {
            var optionHTML = '<option value="-1">Please Select a Course</option>';
            for (var i = 0; i < data.length; i++) {
                if (data[i].IsDefault) {
                    s += '<option value="' + data[i].ID + '" selected>' + data[i].CourseTitle + '</option>';
                }
                else {
                    optionHTML += '<option value="' + data[i].ID + '">' + data[i].CourseTitle + '</option>';

                }
            }
            $("#courseDropdown").html(optionHTML);
        },
        error: function (err) {
            alert(err);
        }
    });
});
