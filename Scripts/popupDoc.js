

$(".cl").hide();
$(".dim").hide();

$(".dim").click(function (event) {
    event.preventDefault();
    $(this).hide();
    $(".cl").hide();
    $(".bluring").css("filter", "blur(0)", "-webkit-filter", "blur(0)", "-moz-filter", "blur(0)", "-o-filter", "blur(0)", "-ms-filter", "blur(0)", "filter", "blur(0)");
});



$(".lnkbuttons").click(function (event) {
    event.preventDefault();
    $(".dim").show();

    $(".bluring").css("filter", "blur(3px)", "-webkit-filter", "blur(5px)","-moz-filter", "blur(5px)","-o-filter", "blur(5px)","-ms-filter", "blur(5px)","filter", "blur(5px)");

    $(".cl-head").html("<center><b><h4 style='position:relative;top:10px;padding:0;margin:0;'>" + this.textContent + "</h4></b></center>");
    
    $(".cl").show();
});
