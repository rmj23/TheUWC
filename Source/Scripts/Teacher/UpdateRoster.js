$(document).ready(function () {

    $('#tableSchoolRoster').DataTable({
        responsive: true,
        "columnDefs": [
            {
                "targets": [4],
                "orderable": false
            }
        ]
    });

});

// *************************** FUNCTIONS *********************************


//General functions
    function deleteStudent(studentID) {
        if (confirm('Are you sure that you would like to delete this student?')) {
            //postback to controller to delete student
            $.ajax({
                url: '/Teacher/DeleteStudent',
                type: 'POST',
                dataType: 'json', //this is the type of data that we're expecting back
                data: { StudentID: studentID },
                success: function (data) {
                    if (data.Success) {
                        console.log("success");
                        //$('#tableSchoolRoster').filter(function () {
                        //    return $(this).data('student') === studentID
                        //}).remove();
                        window.location.reload();
                    }
                },
                error: function () {
                    alert("error");
                }
            });
        }
    }