var HeaderName = "Devices";

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
            { field: "dCreateDate", title: "Date", width: '90px' },
            { field: "szUserName", title: "User Name", width: '25%' },
            { field: "assemblyName", title: "Assembly", width: '30%' },
            { field: "szBrand", title: "Brand", width: '15%' },
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

//var dummyArray = [{
//    "dCreateDate": "20/2/2020",
//    "szUserName": "Yusif Badmus",
//    "assemblyName": "Ablekumah",
//    "szBrand": "Huawei",

//}];