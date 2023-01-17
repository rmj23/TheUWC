
// UI-Modals.js
// ====================================================================
// This file should not be included in your project.
// This is just a sample how to initialize plugins or components.
//
// - ThemeOn.net -


$(document).ready(function () {

    // BOOTBOX - CUSTOM HTML FORM
    // =================================================================
    // Require Bootbox
    // http://bootboxjs.com/
    // =================================================================
    $('#bootbox-add-student').on('click', function () {
        bootbox.dialog({
            title: "Add New Student",
            message: '<div class="alert alert-danger">' + 
                        '<button class="close" data-dismiss="alert"><i class="pci-cross pci-circle"></i></button>' + 
                        '<strong>Note:</strong><br /> If you are adding students to the system for the first time, please use the Bulk Insert Tool.' + 
                    '</div>' +
                    '<form id="insertStudentForm" action="InsertStudent">' +
                        '<!-- Student First Name Field-->' +
                        '<div class="form-group">' +
                            '<label for="studentFirstName">First Name</label>' +
                            '<input type="text" class="form-control" id="studentFirstName" placeholder="First Name" name="FirstName">' +
                        '</div>' +
                        '<!-- Student Middle Name Field-->' +
                        '<div class="form-group">' +
                            '<label for="studentMiddleName">Middle Name</label>' +
                            '<input type="text" class="form-control" id="studentMiddleName" placeholder="Middle Name" name="MiddleName">' +
                        '</div>' +
                        '<!-- Student Last Name Field-->' +
                        '<div class="form-group">' +
                            '<label for="studentLastName">Last Name</label>' +
                            '<input type="text" class="form-control" id="studentLastName" placeholder="Last Name" name="LastName">' +
                        '</div>' +
                        '<!-- Student ID Field-->' +
                        '<div class="form-group">' +
                            '<label for="studentID">Student ID</label>' +
                            '<input type="text" class="form-control" id="studentID" placeholder="Student ID" name="StudentNumber">' +
                        '</div>' +
                    '</form>',
            buttons: {
                success: {
                    label: "Submit",
                    className: "btn-success",
                    callback: function () {
                        $("#insertStudentForm").submit();
                    }
                }
            }
        });
    });

    $('#bootbox-bulk-insert').on('click', function () {
        bootbox.dialog({
            title: "This is a form in a modal.",
            message: '<div class="well"><h4>Instructions</h4> <ol> <li>Download <a href="@Url.Content("~/")">this document</a>. Do NOT remove the first row in the file.</li> <li>Fill the Excel sheet with your students\' data. If there is not a student number, leave the cells blank.</li> <li>Save the modified Excel sheet as a .csv file. <a href="https://support.office.com/en-za/article/Import-or-export-text-txt-or-csv-files-5250ac4c-663c-47ce-937b-339e391393ba">Click here for additional instructions.</a></li> <li>Upload the Excel sheet by clicking the button. Upon uploading, you should receive a message indicating the status of the upload. If the upload is successful, it will display the details of the upload. If the upload is not successful, please read the instructions carefully and try again. If you are still experiencing issues please fill out a ticket <a href="@Url.Content("~/")">here</a>.</li> </ol></div>' +
                     '<form id="insertBulkStudentForm"><div class="bord-top pad-ver"><span class="btn btn-primary btn-file"> Browse... <input type="file" id="insertBulkStudentButton"> </span></div></form>',
            buttons: {
                success: {
                    label: "Submit",
                    className: "btn-purple",
                    callback: function () {
                        $("#insertBulkStudentForm").submit();
                    }
                }
            }
        });
    });

    $('#bootbox-upload-anchor-chart').on('click', function () {
        bootbox.dialog({
            title: "Upload Anchor Chart",
            message: '<p>Please select an anchor chart.</p><form id="uploadAnchorChartForm" action="/LessonPlans/Teacher" enctype="multipart/form-data" method="post"><div class="bord-top pad-ver"><span class="btn btn-primary btn-file"> Browse... <input type="file" id="file"> </span></div></form>',
            buttons: {
                success: {
                    label: "Submit",
                    className: "btn-purple",
                    callback: function () {
                        $("#uploadAnchorChartForm").submit();
                    }
                }
            }
        });
    });

})