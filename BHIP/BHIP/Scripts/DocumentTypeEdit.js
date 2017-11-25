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
   
    $("#frmDocument").validate({
        rules: {
            txtName: {
                required: true
           }
        },
        messages: {
            txtName: {
                required: "Please enter a Document Type."
            }
        }
    });
});