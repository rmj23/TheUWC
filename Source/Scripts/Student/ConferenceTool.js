$(document).ready(function () {
    getSource();
});

function getSource() {
    var conferenceID = parseInt($('#ConferenceTypeID').val());
    var option = '<option value="">--- Please Select Paper/Project ---</option>';

    // reset data inside dropdown list
    $("#SourceDropdown").html(option);

    switch (conferenceID) {
        case 1:
            $.ajax({
                type: "GET",
                url: "/AJAX/getPaper",
                data: {
                    ConferenceID: conferenceID
                },
                success: function (data) {
                    data.forEach(function (item, index) {
                        option += '<option value="' + item.PaperID + '">' + item.PaperTitle + '</option>';
                    });
                    $("#SourceDropdown").html(option);
                    document.getElementById("SourceDropdown").removeAttribute("disabled");
                    getNeedHelpWith(conferenceID);
                    document.getElementById("RoleHelpDropdown").removeAttribute("disabled");
                    document.getElementById("ConfToolSpecifics").removeAttribute("disabled");
                    document.getElementById("submitBtn").classList.remove("disabled");
                },
                error: function (error, ex) {
                    alert("Error" + error.status);
                }
            });
            break;
        case 2:
            $.ajax({
                type: "GET",
                url: "/AJAX/getProject",
                data: {
                    ConferenceID: conferenceID
                },
                success: function (data) {
                    data.forEach(function (item, index) {
                        console.log(item);
                    });
                    document.getElementById("SourceDropdown").removeAttribute("disabled");
                    getNeedHelpWith(conferenceID);
                    document.getElementById("RoleHelpDropdown").removeAttribute("disabled");
                    document.getElementById("ConfToolSpecifics").removeAttribute("disabled");
                    document.getElementById("submitBtn").classList.remove("disabled");
                },
                error: function (error, ex) {
                    alert("Error" + error.status)
                }
            });
            break;
        default:
            $("#SourceDropdown").html(option);
            document.getElementById("SourceDropdown").setAttribute("disabled", "disabled");
            getNeedHelpWith(conferenceID);
            document.getElementById("RoleHelpDropdown").setAttribute("disabled", "disabled");
            document.getElementById("ConfToolSpecifics").setAttribute("disabled", "disabled");
            document.getElementById("submitBtn").classList.add("disabled");
    }
}

function getNeedHelpWith(conferenceID) {

    var defaultOption = '<option value="">--- Please Select Element ---</option>';

    // RESET HTML INSIDE OF ELEMENT DROPDOWN
    $("#ElementDropdown").html(defaultOption);

    switch (conferenceID) {
        case 1:
            $.ajax({
                type: "GET",
                url: "/AJAX/getElementEval",
                success: function (data) {
                    data.forEach(function (item, index) {
                        defaultOption += '<option value="' + item.ID + '">' + item.Title + '</option>';
                    });
                    $("#ElementDropdown").html(defaultOption);
                    document.getElementById("ElementDropdown").removeAttribute("disabled");
                },
                error: function (error, ex) {
                    alert("Error: " + error.status);
                }
            });
            break;
        case 2:
            $.ajax({
                type: "GET",
                url: "/AJAX/getElementProject",
                success: function (data) {
                    data.forEach(function (item, index) {
                        defaultOption += '<option value="' + item.ID + '">' + item.Element + '</option>';
                    });
                    $("#ElementDropdown").html(defaultOption);
                    document.getElementById("ElementDropdown").removeAttribute("disabled");
                },
                error: function (error, ex) {
                    alert("Error: " + error.status);
                }
            });
            break;
        default:
            $("#ElementDropdown").html(defaultOption);
            document.getElementById("ElementDropdown").setAttribute("disabled", "disabled");
    }
}

