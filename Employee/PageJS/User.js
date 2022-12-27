$(document).ready(function () {
    refreshDataTable();
});

function SaveFromData() {
    debugger;
    var filter = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var name = $("#TxtFirstName").val();
    var EmailId = $("#TxtEmailId").val();
    var Password = $("#TxtPassword").val();

    if (name == "") {
        $('.help-block').html('');
        $('#DivFirstName').addClass('has-error');
        $('#ErrorFirstName').html('Please Enter Your Name.');
        $('#TxtFirstName').focus();
        return;
    }
    else if (EmailId == "") {
        $('.help-block').html('');
        $('#DivEmailId').addClass('has-error');
        $('#ErrorEmailId').html('Please Enter Your Email Id.');
        $('#TxtEmailId').focus();
        return;
    }
    else if (!filter.test(EmailId)) {
        $('.help-block').html('');
        $('#DivEmailId').addClass('has-error');
        $('#ErrorEmailId').html('Please Enter Valid Email Id.');
        $('#TxtEmailId').focus();
        return;
    }
    else if (Password == "") {
        $('.help-block').html('');
        $('#DivPassword').addClass('has-error');
        $('#ErrorPassword').html('Please Enter Your Password.');
        $('#TxtPassword').focus();
        return;
    }
    else {
        var formData = new FormData();
        formData.append("Name", name); 
        formData.append("EmailId", EmailId);
        formData.append("Password", Password);

        $.ajax({
            type: "POST",
            url: '/Registration/AddUser',
            data: formData,
            processData: false,
            contentType: false,
            success: function (return_Data) {
                if (return_Data.n == 1) {
                    refreshDataTable();
                    ResetFromData();
                    bootbox.alert(return_Data.Msg);
                } else {
                    refreshDataTable();
                    ResetFromData();
                    bootbox.alert(return_Data.Msg);
                }
            },
            complete: function () {
                $('#btnSave').attr('disabled', false);
                $('#btnSave').html('Save');
                $('#btnsave').css('display', 'block');
                $('#btnreset').css('display', 'block');
            }
        });
    }
}

function ResetFromData() {
    $("#TxtTitle").val('');
    $("#TxtFirstName").val('');
    $("#TxtEmailId").val('');
    $("#TxtPassword").val('');
    $(".form-group").removeClass('has-error');
    $(".form-group > span").html('');
    $("#PageTitle").text('Add User');
    $('#btnSave').html('Save');
    $('#btnSave').attr('onclick', 'SaveFromData();');
}

