$(document).ready(function () {
    refreshDataTable();
});

function SaveFromData() {
    var Location = $("#TxtLocationName").val();
    if (Location == " ") {
        $('.help-block').html('');
        $('#DivLocationName').addClass('has-error');
        $('#ErrorLocationName').html('Please Enter Location Name.');
        $('#TxtLocationName').focus();
        return;
    }
    else {
        
        var formdata = new FormData();
        formdata.append("Location", Location);
        $.ajax({
            type: "POST",
            url:  '/Location/AddLocationName',
            data: formdata,
            datatype: "json",
            processData: false,
            contentType: false,
            success: function (return_Data) {
                 if (return_Data.n == 1) {
                    ResetFromData();
                    refreshDataTable();
                    bootbox.alert(return_Data.Msg);

                } else {
                    ResetFromData();
                    refreshDataTable();
                    bootbox.alert(return_Data.Msg);
                }
            },
            complete: function () {
                $('#btnSave').attr('disabled', false);
                $('#btnSave').html('Save');
            }
        });
    }
}

function ViewFromData(Id) {
    $("#TxtId").val(Id);
    $.ajax({
        type: "GET",
        url: '/Location/ViewLocationName?Id=' + Id,
        success: function (return_Data) {
            if (return_Data.LocModel != null) {
                $("#TxtLocationName").val(return_Data.LocModel.Location);
                $("#PageTitle").text('Update Location Name');
                $('#btnSave').text('Update');
                $('#btnSave').attr('onclick', 'UpdateFromData(' + Id + ');');
            }
            else {
                bootbox.alert(return_Data.Msg);
            }
        }
    });
}


//update
function UpdateFromData() {
    var Id = $("#TxtId").val();
    var Location = $("#TxtLocationName").val();
    if (Location == "") {
        $('.help-block').html('');
        $('#DivLocationName').addClass('has-error');
        $('#ErrorLocationName').html('Please Enter Location Name.');
        $('#TxtLocationName').focus();
        return;
    }
    else {
        var formdata = new FormData();
        formdata.append("Id", Id);
        formdata.append("Location", Location);
        $.ajax({
            type: "POST",
            url: '/Location/UpdateLocationName',
            data: formdata,
            datatype: "json",
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
                $("#PageTitle").text('Add New Location ');
                $('#btnSave').attr('disabled', false);
                $('#btnSave').html('Save');

            }
        });
    }
}


//delete
function RemoveFromData(Id) {
    bootbox.confirm({
        message: "do you want to remove this record?",
        buttons: {
            confirm: {
                label: 'yes',
                classname: 'btn-success'
            },
            cancel: {
                label: 'no',
                classname: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result == true) {
                $.ajax({
                    type: 'GET',
                    url: '/Location/RemoveLocationName?Id=' + Id,
                    success: function (return_Data) {
                        if (return_Data.n == 1) {
                            bootbox.alert(return_Data.Msg, function () {
                                ResetFromData();
                                refreshDataTable();
                            });
                        } else {
                            bootbox.alert(return_Data.Msg, function () {
                                ResetFromData();
                                refreshDataTable();
                            });
                        }
                    }
                });
            }
        }
    });
}

function ResetFromData() {
    $("#TxtLocationName").val('');
    $(".form-group").removeClass('has-error');
    $(".form-group > span").html('');
    $("#PageTitle").text('Add New Location');
    $('#btnSave').text('Save');
    $('#btnSave').attr('onclick', 'SaveFromData();');
}