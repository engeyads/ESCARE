
$(".butos #btnAppo p").text("المواعيد");
$(".butos #btnAdmin p").text("المدير");
$(".butos #btnRad p").text("الأشعة");
$(".butos #btnLab p").text("المختبر");
$(".butos #btnPat p").text("تسجيل المرضى");
$(".butos #btnCPat p").text("مرضى الشركات");
$(".butos #btnServ p").text("الخدمات");
$(".butos #btnFPat p").text("مريض العائلة");
$(".butos #btnMaster p").text("المعلومات المرجعية");
$(".butos #btnRep p").text("التقارير");
$(".butos #btnER p").text("الطوارئ");
$(".butos #btnCWD p").text("نقدي مع الخصم");
$(".butos #btnDoc p").text("شاشة الطبيب");
$(".butos #btnBill p").text("الفواتير");
$(".butos #btnIns p").text("عقود الشركات");
$(".butos #btnSR p").text("غرفة المخزون");
$(".butos #btnOp p").text("العمليات");

$(".lang #btnLang p").text("English");
$(".lang #btnLang").css("background-image", "url('../icons/En.png')");

$(".cl").hide();
$(".navbar").hide();
$(".dim").hide();

$(".dim").click(function (event) {
    event.preventDefault();
    $(this).hide();
    $(".cl").hide();
    $(".bluring").css("filter", "blur(0)", "-webkit-filter", "blur(0)", "-moz-filter", "blur(0)", "-o-filter", "blur(0)", "-ms-filter", "blur(0)", "filter", "blur(0)");
});

$(".lang .pl").click(function (event) {
    if ($(".lang").css("left") == "0px") {
        $(".lang").css("left", "-100px");
    } else {
        $(".lang").css("left", "0px");
    }
});

$(".lang li").click(function (event) {

    if ($(this).is(':contains("اللغة العربية")')) {
        $(".butos #btnAppo p").text("المواعيد");
        $(".butos #btnAdmin p").text("المدير");
        $(".butos #btnRad p").text("الأشعة");
        $(".butos #btnLab p").text("المختبر");
        $(".butos #btnPat p").text("تسجيل المرضى");
        $(".butos #btnCPat p").text("مرضى الشركات");
        $(".butos #btnServ p").text("الخدمات");
        $(".butos #btnFPat p").text("مريض العائلة");
        $(".butos #btnMaster p").text("المعلومات المرجعية");
        $(".butos #btnRep p").text("التقارير");
        $(".butos #btnER p").text("الطوارئ");
        $(".butos #btnCWD p").text("نقدي مع الخصم");
        $(".butos #btnDoc p").text("شاشة الطبيب");
        $(".butos #btnBill p").text("الفواتير");
        $(".butos #btnIns p").text("عقود الشركات");
        $(".butos #btnSR p").text("غرفة المخزون");
        $(".butos #btnOp p").text("العمليات");

        $(".lang #btnLang p").text("English");
        $(".lang #btnLang").css("background-image","url('../icons/En.png')");

    } else if ($(this).is(':contains("English")')) {
        $(".butos #btnAppo p").text("Appointment");
        $(".butos #btnAdmin p").text("Administrator");
        $(".butos #btnRad p").text("Radiology");
        $(".butos #btnLab p").text("Lab");
        $(".butos #btnPat p").text("Patient");
        $(".butos #btnCPat p").text("Company Patient");
        $(".butos #btnServ p").text("Service");
        $(".butos #btnFPat p").text("Family Patient");
        $(".butos #btnMaster p").text("Master");
        $(".butos #btnRep p").text("Reports");
        $(".butos #btnER p").text("Emergency");
        $(".butos #btnCWD p").text("Cash with Discount");
        $(".butos #btnDoc p").text("Doctor");
        $(".butos #btnBill p").text("Billing");
        $(".butos #btnIns p").text("Insurance");
        $(".butos #btnSR p").text("Stock Room");
        $(".butos #btnOp p").text("Operations");

        $(".lang #btnLang p").text("اللغة العربية");
        $(".lang #btnLang").css("background-image", "url('../icons/Ar.png')");
    }
});

$(".butos li").click(function (event) {
    event.preventDefault();
    $(".dim").show();

    $(".bluring").css("filter", "blur(3px)", "-webkit-filter", "blur(5px)","-moz-filter", "blur(5px)","-o-filter", "blur(5px)","-ms-filter", "blur(5px)","filter", "blur(5px)");

    $(".cl-head").html("<center><b><h4 style='position:relative;top:10px;padding:0;margin:0;'>" + this.textContent + "</h4></b></center>");


    if ($(this).is(':contains("Appointment")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-list-ul' ></i> <p>Scheduling</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-time' ></i> <p>Appointment</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-envelope-alt' ></i> <p>Send SMS</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-envelope'></i><p>SMS Templates</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-thumbs-down'></i><p>Undelivered SMS</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-list-alt'></i><p>Check Doctors' Schedueling</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-list-alt'></i><p>Appointment Request</p>   </li></a>  </ul> </td> </tr>");


    } else if ($(this).is(':contains("Administrator")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../EnAddNewEmployee.aspx'><li id='btn1'> <i class='icon-plus-sign-alt' ></i> <p>Create User</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='../Account/ResetPassword.aspx'><li id='btn2'>   <i class='icon-lock' ></i> <p>Change Password</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-user' ></i> <p>User Permission</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-user'></i><p>Recovor Deleted Bills</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-table'></i><p>Company Settings</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-folder-open'></i><p>Open Closed Patients</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-folder-open'></i><p>Post Account</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn8'>   <i class='icon-user'></i><p>Doctor Categories</p>   </li></a>  </ul> </td> </tr>");


    } else if ($(this).is(':contains("Radiology")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-hospital' ></i> <p>Radiology</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-medkit' ></i> <p>Radiology Services</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-file' ></i> <p>Radiology Request</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-reply-all'></i><p>Radiology Result Reprint</p>   </li></a>  </ul> </td> </tr>   ");


    } else if ($(this).is(':contains("Lab")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-beaker' ></i> <p>Lab Department</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-file-text-alt' ></i> <p>Lab Request</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-screenshot' ></i> <p>Lab Request Viewer</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-leaf'></i><p>Lab Test Group</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-print'></i><p>Lab Result Reprint</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-th'></i><p>Lab Unit</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-bar-chart'></i><p>Test Ranges</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn8'>   <i class='icon-paste'></i><p>Confirmation Lab</p>   </li></a>  </ul> </td> </tr><tr><td class='inhead' colspan='3' ><center><h4>Dental Lab</h4></center></td></tr>    <tr> <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-list-alt'></i><p>Stages Of Services Implementation</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn10'>   <i class='icon-beaker'></i><p>Lab Technician</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn11'>   <i class='icon-credit-card'></i><p>Order Execution</p>   </li></a>  </ul> </td> </tr>");


    } else if ($(this).is(':contains("Patient")') & !$(this).is(':contains("Company")') & !$(this).is(':contains("Family")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../EnaddCustomer.aspx'><li id='btn1'> <i class='icon-file-text' ></i> <p>Patient Registration</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-bullseye' ></i> <p>Out Patient</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-ban-circle' ></i> <p>Block Patient</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-book'></i><p>Patient Dictionary</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-book'></i><p>Patient Non Effective</p>   </li></a>  </ul> </td>    </tr>   ");


    } else if ($(this).is(':contains("Company Patient")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-user-md' ></i> <p>Company Patient Details</p>   </li></a>  </ul> </td> </tr>   ");


    } else if ($(this).is(':contains("Service")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../EnServices.aspx'><li id='btn1'> <i class='icon-cog' ></i> <p>Services</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-zoom-in' ></i> <p>View Service List</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-male' ></i> <p>Dermatology Service</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-th-large'></i><p>Dental Service</p>   </li></a>  </ul> </td> </tr>   ");


    } else if ($(this).is(':contains("Family Patient")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-plus-sign-alt' ></i> <p>Add Main Member</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-user' ></i> <p>Family Member Entry</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-minus-sign-alt' ></i> <p>Add Family Discount</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-zoom-in'></i><p>View Discount Details</p>   </li></a>  </ul> </td> </tr>   ");


    } else if ($(this).is(':contains("Master")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-code' ></i> <p>Gen. Type Code</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-file-text' ></i> <p>Generalized Codes</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-flag-checkered' ></i> <p>Nationality</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-hospital'></i><p>Clinic Entry</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-user-md'></i><p>Doctor</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-money'></i><p>Doctor Commission</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-stethoscope'></i><p>Doctor Percentage</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-tint'></i><p>ICD 10 DIG</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn10'>   <i class='icon-medkit'></i><p>Medical Program</p>   </li></a>  </ul> </td>    </tr>     <tr> <td> <ul>  <a href='#'><li id='btn11'> <i class='icon-cog' ></i> <p>DHS Settings</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn12'>   <i class='icon-leaf' ></i> <p>DHS Activator</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn13'>   <i class='icon-envelope' ></i> <p>SMS Server Settings</p>   </li></a>  </ul> </td> </tr>  <tr> <td> <ul>  <a href='#'><li id='btn14'> <i class='icon-envelope' ></i> <p>Cashier</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn15'>   <i class='icon-list-alt' ></i> <p>Services Management</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn16'>   <i class='icon-list-alt' ></i> <p>Services Offers</p>   </li></a>  </ul> </td> </tr>  <tr> <td> <ul>  <a href='#'><li id='btn17'> <i class='icon-th' ></i> <p>Clinic Department Management</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn18'>   <i class='icon-hospital' ></i> <p>Clinic Department Company</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn19'>   <i class='icon-hospital' ></i> <p>Users Cashiers</p>   </li></a>  </ul> </td> </tr>  <tr> <td> <ul>  <a href='#'><li id='btn20'>   <i class='icon-list'></i><p>Patient Questions</p>   </li></a>  </ul> </td>    </tr>");


    } else if ($(this).is(':contains("Reports")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-file-alt' ></i> <p>Reports</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn2'> <i class='icon-bar-chart' ></i> <p>Dashboard</p>   </li></a>  </ul> </td>    </tr>   ");


    } else if ($(this).is(':contains("Emergency")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-ambulance' ></i> <p>Emergency</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn2'> <i class='icon-user' ></i> <p>Inwalk Patient</p>   </li></a>  </ul> </td>    </tr>   ");


    } else if ($(this).is(':contains("Cash with Discount")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-user' ></i> <p>Cash with Discount</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn2'> <i class='icon-minus-sign-alt' ></i> <p>Cash Discount</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn3'> <i class='icon-zoom-in' ></i> <p>View Cash Discount</p>   </li></a>  </ul> </td>    </tr>   ");


    } else if ($(this).is(':contains("Doctor")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../DoctorDeskTop.aspx'><li id='btn1'> <i class='icon-user-md' ></i> <p>Doctor Desktop</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='../PatientTicket.aspx'><li id='btn2'>   <i class='icon-list-alt' ></i> <p>Doctor Waiting List</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-building' ></i> <p>Doctor Branching</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-zoom-in'></i><p>View Insurance Approval</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-th'></i><p>Manage Insurance Approval</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-laptop'></i><p>Nurse Page</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-laptop'></i><p>Vital Signs</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-laptop'></i><p>Sick Leave Requests</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn10'>   <i class='icon-laptop'></i><p>All Request of Doctor & Nursing</p>   </li></a>  </ul> </td>    </tr>    <tr> <td> <ul>  <a href='#'><li id='btn11'>   <i class='icon-laptop'></i><p>Request of Management</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn12'>   <i class='icon-laptop'></i><p>All Requests</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn13'>   <i class='icon-user-md'></i><p>Doctor Request</p>   </li></a>  </ul> </td>    </tr>");


    } else if ($(this).is(':contains("Billing")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../CreateNewReceipt.aspx'><li id='btn1'> <i class='icon-edit-sign' ></i> <p>Clinic Registration</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-credit-card' ></i> <p>Bill Payment</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='http://esserver/RptPrintOut?sRef=Receipt&ReceiptID=000001'><li id='btn3'>   <i class='icon-print' ></i> <p>Bill Reprint</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-stethoscope'></i><p>Switch Doctor in Bill</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-file'></i><p>Receipt Voucher</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-zoom-in'></i><p>View Receipt Voucher</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-paste'></i><p>Inwalk Patient Bill</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn8'>   <i class='icon-paste'></i><p>View Pay Voucher Receipt</p>   </li></a>  </ul> </td> </tr>");


    } else if ($(this).is(':contains("Insurance")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-th' ></i> <p>Tba</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-th-large' ></i> <p>Insurance Company</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-file-alt' ></i> <p>Insurance Contract</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-money'></i><p>Ins Company Special Price</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-folder-open'></i><p>Insurance Class</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-copy'></i><p>Copy Direct Price List</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-copy'></i><p>Copy Insurance Price List</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-file-text-alt'></i><p>Insurance Company Details</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn10'>   <i class='icon-file-text'></i><p>Direct Company</p>   </li></a>  </ul> </td>    </tr>    <tr> <td> <ul>  <a href='#'><li id='btn11'>   <i class='icon-bullseye'></i><p>Policy Management</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn12'>   <i class='icon-plus-sign-alt'></i><p>Add Policy</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn13'>   <i class='icon-list-ol'></i><p>Special Price Direct Company</p>   </li></a>  </ul> </td>    </tr>     <tr> <td> <ul>  <a href='#'><li id='btn14'>   <i class='icon-list-ol'></i><p>Company Payment</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn15'>   <i class='icon-copy'></i><p>Insurance Bill Transfer</p>   </li></a>  </ul> </td>     </tr>");


    } else if ($(this).is(':contains("Stock Room")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-money' ></i> <p>Stock Room</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-hospital' ></i> <p>Clinic Stores</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-th' ></i> <p>Service Items</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-th'></i><p>Exchange Medicines</p>   </li></a>  </ul> </td> </tr>   ");


    } else if ($(this).is(':contains("Operations")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-stethoscope' ></i> <p>Operations</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-group' ></i> <p>Medical Team</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-medkit' ></i> <p>Operation Link</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-resize-full'></i><p>Operation List</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-plus-sign-alt'></i><p>Operation Room</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-list-alt'></i><p>Operation Items</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-search'></i><p>Operation Search</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-search'></i><p>Patient Holder</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn10'>   <i class='icon-search'></i><p>Holder Search</p>   </li></a>  </ul> </td>    </tr>    <tr> <td> <ul>  <a href='#'><li id='btn11'>   <i class='icon-book'></i><p>Patient Non Effective</p>   </li></a>  </ul> </td>    </tr>");


    } else if ($(this).is(':contains("المواعيد")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-list-ul' ></i> <p>جدولة المواعيد</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-time' ></i> <p>المواعيد</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-envelope-alt' ></i> <p>ارسال الرسائل القصيرة</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-envelope'></i><p>نماذج الرسائل القصيرة</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-thumbs-down'></i><p>الرسائل القصيرة التي لم تصل</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-list-alt'></i><p>جدول مواعيد الاطباء</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-list-alt'></i><p>طلبات المواعيد</p>   </li></a>  </ul> </td> </tr>");


    } else if ($(this).is(':contains("المدير")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../AddNewEmployee.aspx'><li id='btn1'> <i class='icon-plus-sign-alt' ></i> <p>تسجيل مستخدم</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='../Account/ResetPassword.aspx'><li id='btn2'>   <i class='icon-lock' ></i> <p>تغيير كلمة المرور</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-user' ></i> <p>صلاحيات المستخدمين</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-user'></i><p>استعراض الفواتير المحذوفة</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-table'></i><p>اعدادات الشركة</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-folder-open'></i><p>فتح ملفات المرضى المغلقة</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-folder-open'></i><p>ترحيل الحسابات</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn8'>   <i class='icon-user'></i><p>أقسام الطبيب</p>   </li></a>  </ul> </td> </tr>");


    } else if ($(this).is(':contains("الأشعة")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-hospital' ></i> <p>الأشعة</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-medkit' ></i> <p>خدمات الأشعة</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-file' ></i> <p>طلبات فحوصات الأشعة</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-reply-all'></i><p>اعادة طباعة نتائج فحوصات الأشعة</p>   </li></a>  </ul> </td> </tr>   ");


    } else if ($(this).is(':contains("المختبر")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-beaker' ></i> <p>أقسام المعمل</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-file-text-alt' ></i> <p>طلب تحليل</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-screenshot' ></i> <p>عرض طلبات التحليل</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-leaf'></i><p>مجموعة فحوصات المعمل</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-print'></i><p>اعادة طباعة نتائج التحاليل</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-th'></i><p>وحدات المعمل</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-bar-chart'></i><p>معدلات الفحص</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn8'>   <i class='icon-paste'></i><p>تأكيد نتيجة التحليل</p>   </li></a>  </ul> </td> </tr><tr><td class='inhead' colspan='3' ><center><h4>مختبر الأسنان</h4></center></td></tr>    <tr> <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-list-alt'></i><p>مراحل تنفيذ الخدمة</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn10'>   <i class='icon-beaker'></i><p>الفنيين المختصين بالمعمل</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn11'>   <i class='icon-credit-card'></i><p>تنفيذ الطلبات</p>   </li></a>  </ul> </td> </tr>");


    } else if ($(this).is(':contains("تسجيل المرضى")') ) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../addCustomer.aspx'><li id='btn1'> <i class='icon-file-text' ></i> <p>تسجيل المرضى</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-bullseye' ></i> <p>مريض خارجي</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-ban-circle' ></i> <p>حظر المريض</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='../NamesDict.aspx'><li id='btn4'>   <i class='icon-book'></i><p>قاموس اسماء المرضى</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-book'></i><p>المرضى الغير فعالين</p>   </li></a>  </ul> </td>    </tr>   ");


    } else if ($(this).is(':contains("مرضى الشركات")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-user-md' ></i> <p>بيانات مرضى الشركات</p>   </li></a>  </ul> </td> </tr>   ");


    } else if ($(this).is(':contains("الخدمات")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../Services.aspx'><li id='btn1'> <i class='icon-cog' ></i> <p>الخدمات</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-zoom-in' ></i> <p>عرض قائمة الخدمات</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-male' ></i> <p>خدمات الجلدية</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-th-large'></i><p>خدمات الأسنان</p>   </li></a>  </ul> </td> </tr>   ");


    } else if ($(this).is(':contains("مريض العائلة")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-plus-sign-alt' ></i> <p>اضافة عضو اساسي</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-user' ></i> <p>تسجيل عضو عائلي</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-minus-sign-alt' ></i> <p>اضافة خصم عائلي</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-zoom-in'></i><p>عرض بيانات الخصم</p>   </li></a>  </ul> </td> </tr>   ");


    } else if ($(this).is(':contains("المعلومات المرجعية")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-code' ></i> <p>أنواع الأكواد العامة</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-file-text' ></i> <p>الأكواد العامة</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-flag-checkered' ></i> <p>الجنسية</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='../Clinics.aspx'><li id='btn4'>   <i class='icon-hospital'></i><p>تسجيل العيادات</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='../ClinicDoctor.aspx'><li id='btn5'>   <i class='icon-user-md'></i><p>الأطباء</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-money'></i><p>عمولات الأطباء</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-stethoscope'></i><p>نسب الأطباء</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-tint'></i><p>التشخيص الدولي ICD 10</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn10'>   <i class='icon-medkit'></i><p>الباقة الطبية</p>   </li></a>  </ul> </td>    </tr>     <tr> <td> <ul>  <a href='#'><li id='btn11'> <i class='icon-cog' ></i> <p>اعدادات DHS</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn12'>   <i class='icon-leaf' ></i> <p>تنشيط DHS</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn13'>   <i class='icon-envelope' ></i> <p>اعدادات خادم الرسائل القصيرة</p>   </li></a>  </ul> </td> </tr>  <tr> <td> <ul>  <a href='#'><li id='btn14'> <i class='icon-envelope' ></i> <p>تعريف الكاشير</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn15'>   <i class='icon-list-alt' ></i> <p>ادارة الخدمات للفرع</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn16'>   <i class='icon-list-alt' ></i> <p>عروض الخدمات</p>   </li></a>  </ul> </td> </tr>  <tr> <td> <ul>  <a href='#'><li id='btn17'> <i class='icon-th' ></i> <p>ادارة العيادات للفرع</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn18'>   <i class='icon-hospital' ></i> <p>ادارة العيادات للمستوصف</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn19'>   <i class='icon-hospital' ></i> <p>تسكين المستخدمين على الكاشير</p>   </li></a>  </ul> </td> </tr>  <tr> <td> <ul>  <a href='#'><li id='btn20'>   <i class='icon-list'></i><p>أسئلة المرضى</p>   </li></a>  </ul> </td>    </tr>");


    } else if ($(this).is(':contains("التقارير")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-file-alt' ></i> <p>التقارير</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn2'> <i class='icon-bar-chart' ></i> <p>لوحة الرسومات البيانية</p>   </li></a>  </ul> </td>    </tr>   ");


    } else if ($(this).is(':contains("الطوارئ")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-ambulance' ></i> <p>الطوارئ</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn2'> <i class='icon-user' ></i> <p>مرضى الطوارئ</p>   </li></a>  </ul> </td>    </tr>   ");


    } else if ($(this).is(':contains("نقدي مع الخصم")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-user' ></i> <p>مرضى النقدي مع الخصم</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn2'> <i class='icon-minus-sign-alt' ></i> <p>الخصم النقدي</p>   </li></a>  </ul> </td>     <td> <ul>  <a href='#'><li id='btn3'> <i class='icon-zoom-in' ></i> <p>عرض الخصم النقدي</p>   </li></a>  </ul> </td>    </tr>   ");


    } else if ($(this).is(':contains("شاشة الطبيب")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../DoctorDeskTop.aspx'><li id='btn1'> <i class='icon-user-md' ></i> <p>شاشة الطبيب</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='../PatientTicket.aspx'><li id='btn2'>   <i class='icon-list-alt' ></i> <p>قائمة انتظار الأطباء</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-building' ></i> <p>تسكين الطبيب</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-zoom-in'></i><p>عرض موافقات التأمين</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-th'></i><p>ادارة موافقات التأمين</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-laptop'></i><p>شاشة الممرضة</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-laptop'></i><p>المؤشرات الحيوية</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-laptop'></i><p>طلبات الإجازة المرضية</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn10'>   <i class='icon-laptop'></i><p>عرض طلبات الأطباء - تمريض</p>   </li></a>  </ul> </td>    </tr>    <tr> <td> <ul>  <a href='#'><li id='btn11'>   <i class='icon-laptop'></i><p>طلبات الإجازة</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn12'>   <i class='icon-laptop'></i><p>كل الطلبات</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn13'>   <i class='icon-user-md'></i><p>طلب الطبيب</p>   </li></a>  </ul> </td>    </tr>");


    } else if ($(this).is(':contains("الفواتير")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../CreateNewReceipt.aspx'><li id='btn1'> <i class='icon-edit-sign' ></i> <p>ادخال الفواتير</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-credit-card' ></i> <p>سداد الفواتير</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='http://esserver/RptPrintOut?sRef=Receipt&ReceiptID=000001'><li id='btn3'>   <i class='icon-print' ></i> <p>اعادة طباعة الفواتير</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-stethoscope'></i><p>تبديل الطبيب في الفاتورة</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-file'></i><p>ايصال الاستلام</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-zoom-in'></i><p>عرض ايصال الاستلام</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-paste'></i><p>دفع فواتير الطوارئ</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn8'>   <i class='icon-paste'></i><p>عرض سندات الصرف</p>   </li></a>  </ul> </td> <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-paste'></i><p>مراجعة فواتير التأمين</p>   </li></a>  </ul> </td></tr>");


    } else if ($(this).is(':contains("عقود الشركات")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-th' ></i> <p>الشركات القابضة</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-th-large' ></i> <p>شركات التأمين</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-file-alt' ></i> <p>عقد التأمين</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-money'></i><p>الاسعار الخاصة بشركات التأمين</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-folder-open'></i><p>درجات التأمين</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-copy'></i><p>نسخ قائمة الأسعار المباشرة</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-copy'></i><p>نسخ قائمة اسعار التامين</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-file-text-alt'></i><p>البيانات التفصيلية لشركات التأمين</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn10'>   <i class='icon-file-text'></i><p>الشركات المباشرة</p>   </li></a>  </ul> </td>    </tr>    <tr> <td> <ul>  <a href='#'><li id='btn11'>   <i class='icon-bullseye'></i><p>ادارة بوليصة التأمين</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn12'>   <i class='icon-plus-sign-alt'></i><p>اضافة بوليصة</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn13'>   <i class='icon-list-ol'></i><p>اسعار خدمات خاصة للشركات المباشة</p>   </li></a>  </ul> </td>    </tr>     <tr> <td> <ul>  <a href='#'><li id='btn14'>   <i class='icon-list-ol'></i><p>سداد العملاء</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn15'>   <i class='icon-copy'></i><p>تحويل فاتورة التأمين</p>   </li></a>  </ul> </td>     </tr>");


    } else if ($(this).is(':contains("غرفة المخزون")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='../store.aspx'><li id='btn1'> <i class='icon-money' ></i> <p>غرفة المخزون</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='../ClinStore.aspx'><li id='btn2'>   <i class='icon-hospital' ></i> <p>مخازن العيادات</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-th' ></i> <p>اصناف الخدمات</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-th'></i><p>صرف الادوية للخدمات</p>   </li></a>  </ul> </td> </tr>   ");


    } else if ($(this).is(':contains("العمليات")')) {
        $(".cl .inbutos table").html("<tr> <td> <ul>  <a href='#'><li id='btn1'> <i class='icon-stethoscope' ></i> <p>العمليات</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn2'>   <i class='icon-group' ></i> <p>الفريق الطبي</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn3'>   <i class='icon-medkit' ></i> <p>عناصر العمليات</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn4'>   <i class='icon-resize-full'></i><p>قائمة العمليات</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn5'>   <i class='icon-plus-sign-alt'></i><p>غرف العمليات</p>   </li></a>  </ul> </td>   <td> <ul>  <a href='#'><li id='btn6'>   <i class='icon-list-alt'></i><p>بنود العمليات</p>   </li></a>  </ul> </td> </tr>     <tr> <td> <ul>  <a href='#'><li id='btn7'>   <i class='icon-search'></i><p>بحث العمليات</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn9'>   <i class='icon-search'></i><p>حافظة المريض</p>   </li></a>  </ul> </td>    <td> <ul>  <a href='#'><li id='btn10'>   <i class='icon-search'></i><p>بحث عن الحافظات</p>   </li></a>  </ul> </td>    </tr>    <tr> <td> <ul>  <a href='#'><li id='btn11'>   <i class='icon-book'></i><p>Patient Non Effective</p>   </li></a>  </ul> </td>    </tr>");


    } else {
        $(".cl .inbutos table").html(" Error");
    }


    $(".cl").show();
});
