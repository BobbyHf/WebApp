function ValidateAccordion1() {
    var isError = false;

    return isError;
}

function ValidateAccordion2() {
    var isError = false;

    var validator = $("#frmRenewal").data('validator');
    validator.settings.ignore = "";

    if (!$("#PhysicalAddress").valid())
    {
        isError = true;
    }

    if (!$("#PhysicalCity").valid()) {
        isError = true;
    }

    if (!$("#PhysicalStateID").valid()) {
        isError = true;
    }

    if (!$("#PhysicalZipcode").valid()) {
        isError = true;
    }

    if (!$("#MailingAddress").valid()) {
        isError = true;
    }

    if (!$("#MailingCity").valid()) {
        isError = true;
    }
    if (!$("#MailingStateID").valid()) {
        isError = true;
    }
    if (!$("#MailingZipcode").valid()) {
        isError = true;
    }

    if (!$("#PhoneNumber").valid()) {
        isError = true;
    }
    if (!$("#Website").valid()) {
        isError = true;
    }

    return isError;
}

function ValidateAccordion3() {
    var isError = false;
    var validator = $("#frmRenewal").data('validator');
    validator.settings.ignore = "";

    if (!$("#ContactFirstName").valid()) {
        isError = true;
    }

    if (!$("#ContactLastName").valid()) {
        isError = true;
    }

    if (!$("#ContactTitle").valid()) {
        isError = true;
    }

    if (!$("#AuthorizeFirstName").valid()) {
        isError = true;
    }

    if (!$("#AuthorizeLastName").valid()) {
        isError = true;
    }

    if (!$("#AuthorizeTitle").valid()) {
        isError = true;
    }
    return isError;
}

function ValidateAccordion4() {
    var isError = false;
    var validator = $("#frmRenewal").data('validator');
    validator.settings.ignore = "";

    $("[id^=Operations1]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    $("[id^=Operations2]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    $("[id^=Operations3]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    return isError;
}

function ValidateAccordion5() {
    var isError = false;

    var validator = $("#frmRenewal").data('validator');
    validator.settings.ignore = "";

    $("[id^=Licensing1]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    $("[id^=Licensing2]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    return isError;
}

function ValidateAccordion6() {
    var isError = false;

    var validator = $("#frmRenewal").data('validator');
    validator.settings.ignore = "";

    if (!$("#CharitableContribLast12").valid()) {
        isError = true;
    }

    if (!$("#CharitableContribNext12").valid()) {
        isError = true;
    }

    if (!$("#GovFundingLast12").valid()) {
        isError = true;
    }

    if (!$("#GovFundingNext12").valid()) {
        isError = true;
    }

    if (!$("#FeeServiceLast12").valid()) {
        isError = true;
    }

    if (!$("#FeeServiceNext12").valid()) {
        isError = true;
    }

    if (!$("#OtherLast12").valid()) {
        isError = true;
    }

    if (!$("#OtherNext12").valid()) {
        isError = true;
    }

    $("[id^=Financial]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    return isError;
}

function ValidateAccordion7() {
    var isError = false;

    var validator = $("#frmRenewal").data('validator');
    validator.settings.ignore = "";

    $("[id^=Staff]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });
    return isError;
}

function ValidateAccordion8() {
    var isError = false;

    var validator = $("#frmRenewal").data('validator');
    validator.settings.ignore = "";

    $("[id^=Procedures1]").each(function () {
        if (this.localName != "span") {
            //alert(this.val());
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    $("[id^=Procedures2]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    $("[id^=Procedures3]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    return isError;
}

function ValidateAccordion9() {
    var isError = false;

    var validator = $("#frmRenewal").data('validator');
    validator.settings.ignore = "";

    $("[id^=ProfLiab1]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    return isError;
}

function ValidateAccordion10() {
    var isError = false;

    var validator = $("#frmRenewal").data('validator');
    validator.settings.ignore = "";

    $("[id^=PropQ]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    return isError;
}

function ValidateAccordion11() {
    var isError = false;

    return isError;
}

function ValidateAccordion12() {
    var isError = false;

    var validator = $("#frmRenewal").data('validator');
    validator.settings.ignore = "";

    $("[id^=Auto]").each(function () {
        if (this.localName != "span") {
            if (!$(this).valid()) {
                isError = true;
            }
        }
    });

    return isError;
}

function ValidateAccordion13() {
    var isError = false;

    return isError;
}

function ValidateAccordion14() {
    var isError = false;

    return isError;
}
