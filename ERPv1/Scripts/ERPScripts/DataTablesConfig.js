var languageDE = {
    "decimal": ",",
    "emptyTable": "Keine Daten vorhanden",
    "info": "Zeige _START_ bis _END_ von _TOTAL_ Einträgen",
    "infoEmpty": "Zeige 0 bis 0 von 0 Einträgen",
    "infoFiltered": "(gefiltert von insgesamt _MAX_ Einträgen)",
    "infoPostFix": "",
    "thousands": ".",
    "lengthMenu": "Zeige _MENU_ Einträge",
    "loadingRecords": "Lädt...",
    "processing": "Verarbeite...",
    "search": "Suchen:",
    "zeroRecords": "Keine passenden Einträge gefunden.",
    "paginate": {
        "first": "Erste",
        "last": "Letzte",
        "next": "Nächste",
        "previous": "Vorherige"
    },
    "aria": {
        "sortAscending": ": Aufsteigend sortieren",
        "sortDescending": ": Absteigend sortieren"
    }
};

$(document).ready(function () {

    $('#indexTable').DataTable({
        "language": languageDE,
        columnDefs: [
            { targets: "no-pointer", orderable: false },
            { targets: "no-sort", orderable: false }
        ],
        searching: true,
        "aaSorting": [] // Prevent initial sorting
    });

    $('#selectionTable').DataTable({
        "language": languageDE,
        columnDefs: [
            { targets: "no-pointer", orderable: false },
            { targets: "no-sort", orderable: false }
        ],
        searching: true,
        select: 'single',
        "aaSorting": [], // Prevent initial sorting
        buttons: [
            {
                text: 'Auswahl',
                action: function(e, dt, node, config) {

                }
            }],
        dom: 'Bfrtip'
    });

    $('#selectionTable2').DataTable({
        "language": languageDE,
        columnDefs: [
            { targets: "no-pointer", orderable: false },
            { targets: "no-sort", orderable: false }
        ],
        searching: true,
        "aaSorting": [] // Prevent initial sorting
    });
});