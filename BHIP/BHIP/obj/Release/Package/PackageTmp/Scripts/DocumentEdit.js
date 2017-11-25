$("#frmDocument").submit(function () {
    $("#frmDocument").validate();
    if (!$("#frmDocument").valid()) {
        return false;
    }
    else {
        return true;
    }
});

$(document).ready(function () {
    jQuery.validator.addMethod("money", function (value, element) {
        return this.optional(element) || /^-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$/.test(value);
    }, "Please provide a valid dollar amount (up to 2 decimal places)");

    // will except numeric with comma
    jQuery.validator.addMethod("comma", function (value, element) {
        return this.optional(element) || /^0$|^[1-9][0-9]*$|^[1-9][0-9]{0,2}(,[0-9]{3})$/.test(value);
    });

    $.validator.addMethod("valueNotEqual", function (value, element, arg) {
        return arg != value;
    }, "Value must not equal arg.");

    $.validator.addMethod('regex', function (value, element, param) {
        return this.optional(element) ||
            value.match(typeof param == 'string' ? new RegExp(param) : param);
    }, 'Please enter a value in the correct format.');

    $("#frmDocument").validate({
        rules: {
            txtEffectiveDate: {
                required: true
            },
            ddlDocumentType: {
                required: true
            },
            fileUpload: {
                required: true
            }
        },
        messages: {
            txtEffectiveDate: {
                required: "Please enter a Date."
            },
            ddlDocumentType: {
                required: "Please select a document type."
            },
            fileUpload: {
                required: "Please upload a valid document. [docx,pdf,ppt,xlsx]"
            }
        }
    });
});