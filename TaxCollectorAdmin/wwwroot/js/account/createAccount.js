var HeaderName = "Create Account";
var activeView = "generalInfo";

$(document).ready(function () {
    $("#pgHeader").text(HeaderName);
});

var openDivForTab = function (evt, divId) {
    activeView = divId;
    if (divId === "contactInfo" || divId === "databaseInfo")
        $("#backBtn").show()
    else if (divId === "generalInfo")
        $("#backBtn").hide()
    let i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(divId).style.display = "block";
    evt.currentTarget.className += " active";
};

$("#backBtn").click(function () {
    if (activeView === "contactInfo") {
        $("#generalInfo").show();
        $("#contactInfo").hide();
        $("#databaseInfo").hide();
        $("#backBtn").hide();
        $('.tablinks2').removeClass('active');  
        $('.tablinks1').addClass('active');
        activeView = "generalInfo";
    } else if (activeView === "databaseInfo") {
        $("#generalInfo").hide();
        $("#contactInfo").show();
        $("#databaseInfo").hide();
        $("#backBtn").show();
        $('.tablinks3').removeClass('active');  
        $('.tablinks2').addClass('active');
        activeView = "contactInfo";
    }
});