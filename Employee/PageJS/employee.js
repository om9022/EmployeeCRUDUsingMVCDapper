$(document).ready(function () {
    refreshDataTable();
});
function SaveFromData() {
    var Name = $("#TxtEmpName").val();
    var abc = $("#TxtEmpContact").val();
    var Location = $("#TxtLocationName").val();
    if (Name == "") {
        $('.help-block').html('');
        $('#DivEmpName').addClass('has-error');
        $('#ErrorEmpname').html('Please Enter Name.');
        $('#TxtEmpName').focus();
        return;
    } else if (abc == "") {
        $('.help-block').html('');
        $('#DivEmpContact').addClass('has-error');
        $('#ErrorEmpContact').html('Please Enter Mobile Number.');
        $('#TxtEmpContact').focus();
        return;
    } else if (abc.length < 10 || abc.length > 10) {
        $('.help-block').html('');
        $('#DivEmpContact').addClass('has-error');
        $('#ErrorEmpContact').html('Please Enter Valid Mobile Number.');
        $('#TxtEmpContact').focus();
        return;
    } else if (Location == "") {
        $('.help-block').html('');
        $('#DivEmpLocation').addClass('has-error');
        $('#ErrorLocationName').html('Please Enter Location Name.');
        $('#TxtLocationName').focus();
        return;
    }
    else {
        var formdata = new FormData();
        formdata.append("Name", Name);        
        formdata.append("Contact", abc);
        formdata.append("Location", Location);
        $.ajax({
            type: "POST",
            url: '/Employee/AddEmployeeName',
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
                $('#btnSave').attr('disabled', false);
                $('#btnSave').html('Save');
                refreshDataTable();
                ResetFromData();
            }
        });
    }
}

function ViewFromData(Id) {
    $("#TxtId").val(Id);

    $.ajax({
        type: "GET",
        url: '/Employee/ViewemployeeName?id=' + Id,
        success: function (return_Data) {
            if (return_Data.n == 5) {
                window.location.href = ServerURL + "/Login/Index";
            } else if (return_Data.EmpModel != null) {
                $("#TxtEmpName").val(return_Data.EmpModel.Name);
                $("#TxtEmpContact").val(return_Data.EmpModel.Contact);
                $("#TxtLocationName").val(return_Data.EmpModel.Location);
                $("#PageTitle").text('Update Employee Name');
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
    var Name = $("#TxtEmpName").val();
    var abc = $("#TxtEmpContact").val();
    var Location = $("#TxtLocationName").val();
    if (Name == "") {
        $('.help-block').html('');
        $('#DivEmpName').addClass('has-error');
        $('#ErrorEmpname').html('Please Enter Name.');
        $('#TxtEmpName').focus();
        return;
    } else if (abc == "") {
        $('.help-block').html('');
        $('#DivEmpContact').addClass('has-error');
        $('#ErrorEmpContact').html('Please Enter Mobile Number.');
        $('#TxtEmpContact').focus();
        return;
    } else if (abc.length < 10 && abc.length > 10) {
        $('.help-block').html('');
        $('#DivEmpContact').addClass('has-error');
        $('#ErrorEmpContact').html('Please Enter Valid Mobile Number.');
        $('#TxtEmpContact').focus();
        return;
    } else if (Location == "") {
        $('.help-block').html('');
        $('#DivEmpLocation').addClass('has-error');
        $('#ErrorLocationName').html('Please Enter Location Name.');
        $('#TxtLocationName').focus();
        return;
    }
    else {
        var formdata = new FormData();
        formdata.append("Id", Id);
        formdata.append("Name", Name);
        formdata.append("Contact", abc);
        formdata.append("Location", Location);
        $.ajax({
            type: "POST",
            url: '/Employee/UpdateEmployee',
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
                $("#PageTitle").text('Add New Employee ');
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
                    url:  '/Employee/RemoveEmployeeName?Id=' + Id,
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
    $("#TxtEmpName").val('');
    $("#TxtEmpContact").val('');
    $("#TxtLocationName").val('');
    $(".form-group").removeClass('has-error');
    $(".form-group > span").html('');
    $("#PageTitle").text('Add New Employee');
    $('#btnSave').text('Save');
    $('#btnSave').attr('onclick', 'SaveFromData();');
}