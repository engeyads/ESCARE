
jQuery(document).ready(function ($) {

    $.backstretch([
        //"../IMG/bg06.jpg",
        "../IMG/bg05.jpg",
        "../IMG/bg04.jpg",
        "../IMG/bg02.jpg",
        "../IMG/bg03.jpg",
        "../IMG/bg01.jpg"
    ], { duration: 19000, fade: 900 });

});




//$(document).ready(function (e) {
//    try {
//        $("#DropDownList_lang").msDropDown();
//    } catch (e) {
//        alert(e.message);
//    }
//});


        //Users_Login

        //function getCookie(cname) {
        //    var name = cname + "=";
        //    var ca = document.cookie.split(';');
        //    for (var i = 0; i < ca.length; i++) {
        //        var c = ca[i];
        //        while (c.charAt(0) == ' ') {
        //            c = c.substring(1);
        //        }
        //        if (c.indexOf(name) == 0) {
        //            return c.substring(name.length, c.length);
        //        }
        //    }
        //    return "";
        //}

        //var UsNm = getCookie('UsNm');
        //var BrsTyp = getCookie('BrsTyp');
        //var IPAdrs = getCookie('IPAdrs');

        //var proxy = $.connection.usersLogginHub;
        //var start = (function () {
        //    proxy.server.checkUser(UsNm, BrsTyp, IPAdrs);

        //});
        //$.connection.hub.start();

