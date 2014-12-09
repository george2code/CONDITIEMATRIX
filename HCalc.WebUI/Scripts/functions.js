$(document).ready(function () {
    $('#Hvh, #spinEditTotal').spinedit();


});


function reloadCalculator() {
    if ($("#Total").val() != "0") {
        var url = "/Page/GetCalendarCostList";
        //            var strDate = "01.12.2014 0:00:00".split(" ");
        //            var dateParts = strDate[0].split(".");
        //            var date = new Date(dateParts[2], (dateParts[1] - 1), dateParts[0]);
        $.get(url, {
            total: $("#Total").val(),
            taxe: $("#TaxeId").val(),
            cycle: $("#Cycle").val(),
            year: $("#StartYear").val()
        }, function (data) {
            $("ul.calendar").html(data);
        });
    };
}

function updateCondition() {
    var url = "/Page/GetCondition";

    $.get(url, {
        extent: $("#DefectExtentsId").val(),
        intencity: $("#DefectIntencitiesId").val(),
        importance: $("#DefectImportancesId").val()
    }, function (data) {
        $("#Cond").html(data);
        $("#Condition").val(data);
    });
}

function updateTotalCost() {
    var url = "/Page/GetTotalCost";

    $.get(url, {
        count: $("#Hvh").val(),
        percentId: $("#Percent").val(),
        cost: $("#Cost").val()
    }, function (data) {
        $("#TotalCost").html(data + " &euro;");
        $("#Total").val(data);

        // reload
        reloadCalculator();
    });
}