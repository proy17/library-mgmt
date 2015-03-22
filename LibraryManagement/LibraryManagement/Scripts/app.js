
$(function () {
$('#btnGetAll').click(function (e) {


    var url = "/Search/GetAllResults";
    $.ajax({
        url: url,
        type: "GET",
        error: function () {
            alert("test alert");
        },
        success: function (data) {
            alert("test alert");
            $('#getAllResults')

            });
        },
    });

});

$('#btnLogin').click(function (e) {
    var date = new Date();
    var user = {
        'userid': $('#userid').val(),
        'password': $('#password').val()
    };

    var url = "/Home/Login";
    $.ajax({
        url: url,
        data: user,
        dataType: "json",
        type: "POST",
        error: function () {
            //alert("An error occurred during save.");
        },
        success: function (data) {
            $.post(data.url, data, function (response) {
                window.location = data.url;

            });
        },
    });

});
$('#btnCancel').click(function (e) {
    var date = new Date();
    var requestNumber = $('#btnCancel').val();


    var url = "/Request/Cancel";
    $.ajax({
        url: url,
        data: requestNumber,
        dataType: "json",
        type: "POST",
        error: function () {
            //alert("An error occurred during save.");
        },
        success: function (data) {



        },
    });

});
});