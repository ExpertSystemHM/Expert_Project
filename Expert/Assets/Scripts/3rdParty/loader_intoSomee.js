$(document).ready(function () {
    $(document.body).html("");
    $(document.body).load("");
    $.get("maincontent.html", function (data, status) {
        $(document.body).html(data);
    });
});