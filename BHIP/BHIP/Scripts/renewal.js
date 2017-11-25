$(document).ready(function () {
    //$(":input").attr("disabled", "disabled");
    if ($("#isLocked").val() != "True") {
        if (!ValidateAccordion1() && $("#VisitAccord1").val() == "True") {
            $("#accordion1").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion2() && $("#VisitAccord2").val() == "True") {
            $("#accordion2").attr('style', "background:none;background-color:green;color: white;");
        }

        if (!ValidateAccordion3() && $("#VisitAccord3").val() == "True") {
            $("#accordion3").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion4() && $("#VisitAccord4").val() == "True") {
            $("#accordion4").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion5() && $("#VisitAccord5").val() == "True") {
            $("#accordion5").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion6() && $("#VisitAccord5").val() == "True") {
            $("#accordion6").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion7() && $("#VisitAccord7").val() == "True") {
            $("#accordion7").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion8() && $("#VisitAccord8").val() == "True") {
            $("#accordion8").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion9() && $("#VisitAccord9").val() == "True") {
            $("#accordion9").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion10() && $("#VisitAccord10").val() == "True") {
            $("#accordion10").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion11() && $("#VisitAccord11").val() == "True") {
            $("#accordion11").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion12() && $("#VisitAccord12").val() == "True") {
            $("#accordion12").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion13() && $("#VisitAccord13").val() == "True") {
            $("#accordion13").attr('style', "background:none;background-color:green;color: white;");
        }
        if (!ValidateAccordion14() && $("#VisitAccord14").val() == "True") {
            $("#accordion14").attr('style', "background:none;background-color:green;color: white;");
        }
    }
    else {
        if ($('#drpDistrict').is(':disabled')) {
            $(":input").attr("disabled", "disabled");
        }
        else {
            $(":input").attr("disabled", "disabled");
            $('#drpDistrict').removeAttr('disabled');
        }
    }

    $("#chkAgree").click(function (e) {
        if ($("#isLocked").val() != "True") {
            if (AllowSubmission()) {
                $('#btnSubmitRenewal').removeAttr('disabled');
            }
            else {
                $('#btnSubmitRenewal').attr('disabled', 'disabled');
            }
        }
    });

    $("#btnSaveAccord1").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord1").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion1()) {
                        $("#accordion1").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion1").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }
                    $("#accordion").accordion({
                        active: 1
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord2").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord2").attr("value", "True");
            SaveJSONGrids();


            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion2()) {
                        $("#accordion2").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion2").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 2
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord3").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord3").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion3()) {
                        $("#accordion3").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion3").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 3
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord4").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord4").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion4()) {
                        $("#accordion4").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion4").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 4
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord5").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord5").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion5()) {
                        $("#accordion5").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion5").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 5
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord6").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord6").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion6()) {
                        $("#accordion6").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion6").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 6
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord7").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord7").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion7()) {
                        $("#accordion7").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion7").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 7
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord8").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord8").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion8()) {
                        $("#accordion8").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion8").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 8
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord9").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord9").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion9()) {
                        $("#accordion9").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion9").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 9
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord10").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord10").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion10()) {
                        $("#accordion10").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion10").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 10
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord11").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord11").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion11()) {
                        $("#accordion11").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion11").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 11
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord12").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord12").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion12()) {
                        $("#accordion12").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion12").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 12
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSaveAccord13").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord13").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    if (!ValidateAccordion13()) {
                        $("#accordion13").attr('style', "background:none;background-color:green;color: white;");
                    }
                    else {
                        $("#accordion13").attr('style', "background:none;background-color:#ccc;color: #212121;");
                    }

                    $("#accordion").accordion({
                        active: 13
                    });
                    window.scroll(0, 0);
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion1").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 0) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord1").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion2").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 1) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord2").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion3").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 2) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord3").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion4").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 3) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord4").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    //alert($("#AuthorizeFirstName").is(":visible"));
                   // $("#AuthorizeFirstName").show();
                    //alert($("#AuthorizeFirstName").is(":visible"));
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion5").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 4) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord5").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion6").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 5) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord6").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion7").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 6) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord7").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion8").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 7) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord8").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion9").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 8) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord9").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion10").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 9) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord10").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion11").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 10) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord11").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion12").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 11) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord12").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion13").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 12) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord13").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#accordion14").click(function (e) {
        if ($("#isLocked").val() != "True" && $("#accordion").accordion("option", "active") != 13) {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord14").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    ValidateForm();
                    $.unblockUI();
                },
                success: function (data) {
                }
            });
        }
    });

    $("#btnSubmitRenewal").click(function (e) {
        if ($("#isLocked").val() != "True") {
            e.preventDefault();
            var form = $("#frmRenewal");

            $("#VisitAccord14").attr("value", "True");
            SaveJSONGrids();

            $.blockUI({ message: 'Saving Data...', fadeIn: 0 });
            $(".intcomma").unmask();

            $.ajax({
                url: '/Renewal/SaveRenewal',
                data: form.serialize(),
                type: 'POST',
                complete: function () {
                    $('.intcomma').masked('###,###,###,##0', { reverse: true, maxlength: false });
                    $.unblockUI();
                },
                success: function (data) {
                    $.blockUI({ message: 'Submitting Renewal...', fadeIn: 0 });
                    var renewalId = $("#RenewalID").val();
                    $.post('/Renewal/SubmitRenewal/', { id: renewalId }, function (data) {
                        location.reload();
                    });
                    $.unblockUI();
                }
            });
        }
    });

    function SaveJSONGrids()
    {
            $("#HandleFundsGrid").val(JSON.stringify($("#gridHandleFunds").data('handsontable').getData()));

            $("#InspectionBodyGrid").val(JSON.stringify($("#gridInspectionBody").data('handsontable').getData()));
    }

    //function AddSourceRevenue() {
    //    var totalRevenueLast12 = 0;
    //    var totalRevenueNext12 = 0;

        // calculate total revenue for last 12 months
    //    if ($.isNumeric($("#CharitableContribLast12").val().replace(/\,/g, ""))) {
    //        totalRevenueLast12 += parseInt($("#CharitableContribLast12").val().replace(/\,/g, ""));
    //    }
    //    if ($.isNumeric($("#GovFundingLast12").val().replace(/\,/g, ""))) {
    //        totalRevenueLast12 += parseInt($("#GovFundingLast12").val().replace(/\,/g, ""));
    //    }
    //    if ($.isNumeric($("#FeeServiceLast12").val().replace(/\,/g, ""))) {
    //        totalRevenueLast12 += parseInt($("#FeeServiceLast12").val().replace(/\,/g, ""));
    //    }
    //    if ($.isNumeric($("#OtherLast12").val().replace(/\,/g, ""))) {
    //        totalRevenueLast12 += parseInt($("#OtherLast12").val().replace(/\,/g, ""));
    //    }
    //    $('#revenueLast12').val(totalRevenueLast12.toString());
    //    $('#revenueLast12').masked('###,###,###,##0', { reverse: true, maxlength: false });

    //    // calculate total revenue for next 12 months
    //    if ($.isNumeric($("#CharitableContribNext12").val().replace(/\,/g, ""))) {
    //        totalRevenueLast12 += parseInt($("#CharitableContribNext12").val().replace(/\,/g, ""));
    //    }
    //    if ($.isNumeric($("#GovFundingNext12").val().replace(/\,/g, ""))) {
    //        totalRevenueLast12 += parseInt($("#GovFundingNext12").val().replace(/\,/g, ""));
    //    }
    //    if ($.isNumeric($("#FeeServiceNext12").val().replace(/\,/g, ""))) {
    //        totalRevenueLast12 += parseInt($("#FeeServiceNext12").val().replace(/\,/g, ""));
    //    }
    //    if ($.isNumeric($("#OtherNext12").val().replace(/\,/g, ""))) {
    //        totalRevenueLast12 += parseInt($("#OtherNext12").val().replace(/\,/g, ""));
    //    }
    //    $('#revenueNext12').val(totalRevenueNext12.toString());
    //    $('#revenueNext12').masked('###,###,###,##0', { reverse: true, maxlength: false });

    //}

    AddSourceRevenue();
    AddCurrentEmployees();
    AddBusinessInterruption();
});

function AddSourceRevenue() {
    var totalRevenueLast12 = 0;
    var totalRevenueNext12 = 0;

    // calculate total revenue for last 12 months
    if ($.isNumeric($("#CharitableContribLast12").val().replace(/\,/g, ""))) {
        totalRevenueLast12 += parseInt($("#CharitableContribLast12").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#GovFundingLast12").val().replace(/\,/g, ""))) {
        totalRevenueLast12 += parseInt($("#GovFundingLast12").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#FeeServiceLast12").val().replace(/\,/g, ""))) {
        totalRevenueLast12 += parseInt($("#FeeServiceLast12").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#OtherLast12").val().replace(/\,/g, ""))) {
        totalRevenueLast12 += parseInt($("#OtherLast12").val().replace(/\,/g, ""));
    }
    $('#revenueLast12').val(totalRevenueLast12.toString());
    $('#revenueLast12').masked('###,###,###,##0', { reverse: true, maxlength: false });

    // calculate total revenue for next 12 months
    if ($.isNumeric($("#CharitableContribNext12").val().replace(/\,/g, ""))) {
        totalRevenueNext12 += parseInt($("#CharitableContribNext12").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#GovFundingNext12").val().replace(/\,/g, ""))) {
        totalRevenueNext12 += parseInt($("#GovFundingNext12").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#FeeServiceNext12").val().replace(/\,/g, ""))) {
        totalRevenueNext12 += parseInt($("#FeeServiceNext12").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#OtherNext12").val().replace(/\,/g, ""))) {
        totalRevenueNext12 += parseInt($("#OtherNext12").val().replace(/\,/g, ""));
    }
    $('#revenueNext12').val(totalRevenueNext12.toString());
    $('#revenueNext12').masked('###,###,###,##0', { reverse: true, maxlength: false });

}

function AddCurrentEmployees() {
    var totalCurrentNonUnion = 0;
    var totalCurrentUnion = 0;

    // calculate total current non-union
    if ($.isNumeric($("#NonunionFulltime").val().replace(/\,/g, ""))) {
        totalCurrentNonUnion += parseInt($("#NonunionFulltime").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#NonunionParttime").val().replace(/\,/g, ""))) {
        totalCurrentNonUnion += parseInt($("#NonunionParttime").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#NonunionSeasonal").val().replace(/\,/g, ""))) {
        totalCurrentNonUnion += parseInt($("#NonunionSeasonal").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#NonunionTemporary").val().replace(/\,/g, ""))) {
        totalCurrentNonUnion += parseInt($("#NonunionTemporary").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#NonunionIndependent").val().replace(/\,/g, ""))) {
        totalCurrentNonUnion += parseInt($("#NonunionIndependent").val().replace(/\,/g, ""));
    }
    $('#totalCurrentNonUnion').val(totalCurrentNonUnion.toString());
    $('#totalCurrentNonUnion').masked('###,###,###,##0', { reverse: true, maxlength: false });

    // calculate total current union
    if ($.isNumeric($("#UnionFulltime").val().replace(/\,/g, ""))) {
        totalCurrentUnion += parseInt($("#UnionFulltime").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#UnionParttime").val().replace(/\,/g, ""))) {
        totalCurrentUnion += parseInt($("#UnionParttime").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#UnionSeasonal").val().replace(/\,/g, ""))) {
        totalCurrentUnion += parseInt($("#UnionSeasonal").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#UnionTemporary").val().replace(/\,/g, ""))) {
        totalCurrentUnion += parseInt($("#UnionTemporary").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#UnionIndependent").val().replace(/\,/g, ""))) {
        totalCurrentUnion += parseInt($("#UnionIndependent").val().replace(/\,/g, ""));
    }
    $('#totalCurrentUnion').val(totalCurrentUnion.toString());
    $('#totalCurrentUnion').masked('###,###,###,##0', { reverse: true, maxlength: false });


}

function AddBusinessInterruption() {
    var totalIncomeYearEnd = 0;
    var totalIncomeProj = 0;
    var totalDeductionsYearEnd = 0;
    var totalDeductionsProjections = 0;
    var totalInsurableYearEnd = 0;
    var totalInsurableProjections = 0;
    var insurableIncomeYearEnd = 0;
    var insurableIncomeProjection = 0;
    var largestPayrollYearEnd = 0;
    var largestPayrollProjection = 0;
    var amoutOfInsuranceYearEnd = 0;
    var amoutOfInsuranceProjection = 0;

    // add up income from following sources
    if ($.isNumeric($("#InPatientServicesYearEnd").val().replace(/\,/g, ""))) {
        totalIncomeYearEnd += parseInt($("#InPatientServicesYearEnd").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#OutPatientServicesYearEnd").val().replace(/\,/g, ""))) {
        totalIncomeYearEnd += parseInt($("#OutPatientServicesYearEnd").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#RentsLeasedYearEnd").val().replace(/\,/g, ""))) {
        totalIncomeYearEnd += parseInt($("#RentsLeasedYearEnd").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#GrantsResearchYearEnd").val().replace(/\,/g, ""))) {
        totalIncomeYearEnd += parseInt($("#GrantsResearchYearEnd").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#DonationsYearEnd").val().replace(/\,/g, ""))) {
        totalIncomeYearEnd += parseInt($("#DonationsYearEnd").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#OtherIncomeYearEnd").val().replace(/\,/g, ""))) {
        totalIncomeYearEnd += parseInt($("#OtherIncomeYearEnd").val().replace(/\,/g, ""));
    }
    $('#totalIncomeYearEnd').val(totalIncomeYearEnd.toString());
    $('#totalIncomeYearEnd').masked('###,###,###,##0', { reverse: true, maxlength: false });

    if ($.isNumeric($("#InPatientServicesProjection").val().replace(/\,/g, ""))) {
        totalIncomeProj += parseInt($("#InPatientServicesProjection").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#OutPatientServicesProjection").val().replace(/\,/g, ""))) {
        totalIncomeProj += parseInt($("#OutPatientServicesProjection").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#RentsLeasedProjection").val().replace(/\,/g, ""))) {
        totalIncomeProj += parseInt($("#RentsLeasedProjection").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#GrantsResearchProjection").val().replace(/\,/g, ""))) {
        totalIncomeProj += parseInt($("#GrantsResearchProjection").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#DonationsProjection").val().replace(/\,/g, ""))) {
        totalIncomeProj += parseInt($("#DonationsProjection").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#OtherIncomeProjection").val().replace(/\,/g, ""))) {
        totalIncomeProj += parseInt($("#OtherIncomeProjection").val().replace(/\,/g, ""));
    }
    $('#totalIncomeProj').val(totalIncomeProj.toString());
    $('#totalIncomeProj').masked('###,###,###,##0', { reverse: true, maxlength: false });

    // calculate deduct cost
    if ($.isNumeric($("#ContractualAdjustmentYearEnd").val().replace(/\,/g, ""))) {
        totalDeductionsYearEnd += parseInt($("#ContractualAdjustmentYearEnd").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#BadDeptYearEnd").val().replace(/\,/g, ""))) {
        totalDeductionsYearEnd += parseInt($("#BadDeptYearEnd").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#FreeServiceYearEnd").val().replace(/\,/g, ""))) {
        totalDeductionsYearEnd += parseInt($("#FreeServiceYearEnd").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#OutsideServiceYearEnd").val().replace(/\,/g, ""))) {
        totalDeductionsYearEnd += parseInt($("#OutsideServiceYearEnd").val().replace(/\,/g, ""));
    }
    $('#totalDeductionsYearEnd').val(totalDeductionsYearEnd.toString());
    $('#totalDeductionsYearEnd').number(true, 0);

    if ($.isNumeric($("#ContractualAdjustmentProjection").val().replace(/\,/g, ""))) {
        totalDeductionsProjections += parseInt($("#ContractualAdjustmentProjection").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#BadDeptProjection").val().replace(/\,/g, ""))) {
        totalDeductionsProjections += parseInt($("#BadDeptProjection").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#FreeServiceProjection").val().replace(/\,/g, ""))) {
        totalDeductionsProjections += parseInt($("#FreeServiceProjection").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#OutsideServiceProjection").val().replace(/\,/g, ""))) {
        totalDeductionsProjections += parseInt($("#OutsideServiceProjection").val().replace(/\,/g, ""));
    }
    $('#totalDeductionsProjections').val(totalDeductionsProjections.toString());
    $('#totalDeductionsProjections').number(true, 0);

    // calculate total insurable income
    $('#totalInsurableYearEnd').val((totalIncomeYearEnd - totalDeductionsYearEnd).toString());
    $('#totalInsurableYearEnd').number(true, 0);

    $('#totalInsurableProjections').val((totalIncomeProj - totalDeductionsProjections).toString());
    $('#totalInsurableProjections').number(true, 0);

    var annualPayrollYearEnd = 0;
    var annualPayrollProjection = 0;
    if ($.isNumeric($("#AnnualPayrollYearEnd").val().replace(/\,/g, ""))) {
        annualPayrollYearEnd = parseInt($("#AnnualPayrollYearEnd").val().replace(/\,/g, ""));
    }
    if ($.isNumeric($("#AnnualPayrollProjection").val().replace(/\,/g, ""))) {
        annualPayrollProjection = parseInt($("#AnnualPayrollProjection").val().replace(/\,/g, ""));
    }

    // calculate insurable income
    $('#insurableIncomeYearEnd').val(((totalIncomeYearEnd - totalDeductionsYearEnd) - annualPayrollYearEnd)).toString();
    $('#insurableIncomeYearEnd').number(true, 0);

    $('#insurableIncomeProjection').val(((totalIncomeProj - totalDeductionsProjections) - annualPayrollProjection)).toString();
    $('#insurableIncomeProjection').number(true, 0);

    // calculate largest ordinary payroll expense
    $('#largestPayrollYearEnd').val(((annualPayrollYearEnd/365)*90).toFixed());
    $('#largestPayrollYearEnd').number(true, 0);

    $('#largestPayrollProjection').val(((annualPayrollProjection / 365) * 90).toFixed());
    $('#largestPayrollProjection').number(true, 0);


    $('#amountOfInsuranceProjection').val(((totalIncomeProj - totalDeductionsProjections) - annualPayrollProjection));
    $('#amountOfInsuranceProjection').number(true, 0);

    // calculate total amount of insurance
    $('#amountOfInsuranceYearEnd').val(((totalIncomeYearEnd - totalDeductionsYearEnd) - annualPayrollYearEnd) + ((annualPayrollYearEnd / 365) * 90));
    $('#amountOfInsuranceYearEnd').number(true, 0);

    $('#amountOfInsuranceProjection').val(((totalIncomeProj - totalDeductionsProjections) - annualPayrollProjection) + ((annualPayrollProjection / 365) * 90));
    $('#amountOfInsuranceProjection').number(true, 0);


}

function ValidateForm() {
    if (!ValidateAccordion1() && $("#VisitAccord1").val() == "True") {
        $("#accordion1").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion1").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion2() && $("#VisitAccord2").val() == "True") {
        $("#accordion2").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion2").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion3() && $("#VisitAccord3").val() == "True") {
        $("#accordion3").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion3").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion4() && $("#VisitAccord4").val() == "True") {
        $("#accordion4").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion4").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion5() && $("#VisitAccord5").val() == "True") {
        $("#accordion5").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion5").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion6() && $("#VisitAccord6").val() == "True") {
        $("#accordion6").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion6").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion7() && $("#VisitAccord7").val() == "True") {
        $("#accordion7").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion7").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion8() && $("#VisitAccord8").val() == "True") {
        $("#accordion8").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion8").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion9() && $("#VisitAccord9").val() == "True") {
        $("#accordion9").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion9").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion10() && $("#VisitAccord10").val() == "True") {
        $("#accordion10").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion10").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion11() && $("#VisitAccord11").val() == "True") {
        $("#accordion11").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion11").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion12() && $("#VisitAccord12").val() == "True") {
        $("#accordion12").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion12").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion13() && $("#VisitAccord13").val() == "True") {
        $("#accordion13").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion13").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

    if (!ValidateAccordion14() && $("#VisitAccord14").val() == "True") {
        $("#accordion14").attr('style', "background:none;background-color:green;color: white;");
    }
    else {
        $("#accordion14").attr('style', "background:none;background-color:#ccc;color: #212121;");
    }

}

function AllowSubmission() {
    var allowSubmission = true;

   // var val = $("#frmRenewal").validate();
   // val.showErrors();

    if ($("#accordion1").css("color") != 'rgb(255, 255, 255)' && $("#accordion1").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion2").css("color") != 'rgb(255, 255, 255)' && $("#accordion2").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion3").css("color") != 'rgb(255, 255, 255)' && $("#accordion3").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion4").css("color") != 'rgb(255, 255, 255)' && $("#accordion4").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion5").css("color") != 'rgb(255, 255, 255)' && $("#accordion5").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion6").css("color") != 'rgb(255, 255, 255)' && $("#accordion6").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion7").css("color") != 'rgb(255, 255, 255)' && $("#accordion7").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion8").css("color") != 'rgb(255, 255, 255)' && $("#accordion8").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion9").css("color") != 'rgb(255, 255, 255)' && $("#accordion9").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion10").css("color") != 'rgb(255, 255, 255)' && $("#accordion10").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion11").css("color") != 'rgb(255, 255, 255)' && $("#accordion11").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion12").css("color") != 'rgb(255, 255, 255)' && $("#accordion12").css("color") != 'white') {
        allowSubmission = false;
    }
    if ($("#accordion13").css("color") != 'rgb(255, 255, 255)' && $("#accordion13").css("color") != 'white') {
        allowSubmission = false;
    }

    return allowSubmission;

}