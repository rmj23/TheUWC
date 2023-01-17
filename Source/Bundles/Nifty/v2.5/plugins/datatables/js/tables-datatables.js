
// Tables-DataTables.js
// ====================================================================
// This file should not be included in your project.
// This is just a sample how to initialize plugins or components.
//
// - ThemeOn.net -



$(window).on('load', function () {

    // Basic Data Tables with responsive plugin
    // -----------------------------------------------------------------
    $('#demo-dt-basic').dataTable({
        "responsive": true,
        "language": {
            "paginate": {
                "previous": '<i class="fa fa-caret-left"></i>',
                "next": '<i class="fa fa-caret-right"></i>'
            }
        }
    });

    // Basic Data Tables with responsive plugin
    // -----------------------------------------------------------------
    $('#demo-dt-basic1').dataTable({
        "responsive": true,
        "order": [[2, "desc"]],
        "language": {
            "paginate": {
                "previous": '<i class="fa fa-caret-left"></i>',
                "next": '<i class="fa fa-caret-right"></i>'
            }
        }
    });



    // Row selection (single row)
    // -----------------------------------------------------------------
    var rowSelection = $('#demo-dt-selection').DataTable({
        "responsive": true,
        "language": {
            "paginate": {
                "previous": '<i class="demo-psi-arrow-left"></i>',
                "next": '<i class="demo-psi-arrow-right"></i>'
            }
        }
    });

    $('#demo-dt-selection').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            rowSelection.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });






    // Row selection and deletion (multiple rows)
    // -----------------------------------------------------------------
    var rowDeletion = $('#demo-dt-delete').DataTable({
        "responsive": true,
        "language": {
            "paginate": {
                "previous": '<i class="demo-psi-arrow-left"></i>',
                "next": '<i class="demo-psi-arrow-right"></i>'
            }
        },
        "dom": '<"toolbar">frtip'
    });
    $('#demo-custom-toolbar').appendTo($("div.toolbar"));

    $('#demo-dt-delete tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });

    $('#demo-dt-delete-btn').click(function () {
        rowDeletion.row('.selected').remove().draw(false);
    });






    // Add Row
    // -----------------------------------------------------------------
    var t = $('#demo-dt-addrow').DataTable({
        "responsive": true,
        "language": {
            "paginate": {
                "previous": '<i class="demo-psi-arrow-left"></i>',
                "next": '<i class="demo-psi-arrow-right"></i>'
            }
        },
        "dom": '<"newtoolbar">frtip'
    });
    $('#demo-custom-toolbar2').appendTo($("div.newtoolbar"));

    $('#demo-dt-addrow-btn').on('click', function () {
        t.row.add([
            'Adam Doe',
            'New Row',
            'New Row',
            nifty.randomInt(1, 100),
            '2015/10/15',
            '$' + nifty.randomInt(1, 100) + ',000'
        ]).draw();
    });


});