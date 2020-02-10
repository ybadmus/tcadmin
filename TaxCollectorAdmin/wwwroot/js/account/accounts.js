var HeaderName = "Accounts";

$(document).ready(function () {
    $("#pgHeader").text(HeaderName);
    initializeKendoGrid([], 1);
});

var initializeKendoGrid = function (data, stage) {
    if (data.length == 0 && stage !== 1) {
        return toastr.info("No Data");
    }

    $("#grid").kendoGrid({
        dataSource: { data: data, pageSize: 8 },
        sortable: false,
        selectable: false,
        pageable: { refresh: false, pageSizes: true, buttonCount: 5 },
        columns: [
            { field: "dateCreated", title: "Date", width: '90px' },
            { field: "accountName", title: "Assembly", width: '30%' },
            { field: "region", title: "Region", width: '15%' },
            { field: "district", title: "District", width: '25%' },
            {
                command: [{
                    name: "view",
                    template: "<button title='View item' class='btn btn-success btn-sm'><i class='fa fa-edit'></i></button>"
                }],
                title: "Actions",
                width: "7%"
            }
        ]
    });
};