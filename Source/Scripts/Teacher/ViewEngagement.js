$(document).ready(function () {
    var table = $("#tableEngagements").dataTable({
        "columnDefs": [
            {
                "targets": [1, 2, 3],
                "orderable": false
            },
            {
                "targets": [1, 3],
                "width": "9%"
            },
            {
                "targets": [0],
                "width": "20%"
            }
            
        ]
    });

    $('#mySelect').on('change', function () {
        var selectedValue = $(this).val();
        table.fnFilter(selectedValue, 1, true); //Exact value, column, reg
    });

});