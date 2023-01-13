
$(document).ready(function () {
    refreshDataTable();
});

function SaveFromData() {
 
    var Name = $("#TxtEmpName").val();
    var abc = $("#TxtEmpContact").val();
    var Location = $("#TxtLocationName").val();
    var FilePath = $("#TxtEmpFile")[0].files[0].name;
    var image = $("#TxtEmpFile").get(0).files;
    var multiFiles = $("#TxtEmpFile").get(0).files;

    var patharray = [];
    var namearray = [];
    Object.keys(multiFiles).forEach(function (key) {
        var patha = location.origin + '/Models/' + multiFiles[key]["name"];
        var namea = multiFiles[key]["name"]
        patharray.push(patha);
       namearray.push(namea);
    });

    var pattern = /^[a-zA-Z]+$/;
    //if (Name == "") {
    //    $('.help-block').html('');
    //    $('#DivEmpName').addClass('has-error');
    //    $('#ErrorEmpname').html('Please Enter Name.');
    //    $('#TxtEmpName').focus();
    //    return;
    //}
    //else if (!pattern.test(Name) && Name != '') {
    //    $('#DivEmpName').addClass('has-error');
    //    $('#ErrorEmpname').html('Numbers are not allowed in Name');
    //    $('#TxtEmpName').focus();
    //    return false;
    //}
    //else if (abc == "") {
    //    $('.help-block').html('');
    //    $('#DivEmpContact').addClass('has-error');
    //    $('#ErrorEmpContact').html('Please Enter Mobile Number.');
    //    $('#TxtEmpContact').focus();
    //    return;
    //} else if (abc.length < 10 || abc.length > 10) {
    //    $('.help-block').html('');
    //    $('#DivEmpContact').addClass('has-error');
    //    $('#ErrorEmpContact').html('Please Enter Valid Mobile Number.');
    //    $('#TxtEmpContact').focus();
    //    return;
    //} else if (Location == "") {
    //    $('.help-block').html('');
    //    $('#DivEmpLocation').addClass('has-error');
    //    $('#ErrorLocationName').html('Please Enter Location Name.');
    //    $('#TxtLocationName').focus();
    //    return;
    //} else if (FilePath == "" ) {
    //    $('.help-block').html('');
    //    $('#DivEmpFile').addClass('has-error');
    //    $('#ErrorFile').html('Please Add File');
    //    $('#TxtEmpFile').focus();
    //    return;
    //}
    //else {
        var formdata = new FormData();
        formdata.append("Name", Name);        
        formdata.append("Contact", abc);
        formdata.append("Location", Location);
        formdata.append("FilePath", patharray);
        formdata.append("ImageFile", image[0]);
        formdata.append("FileName", namearray);




        for (var i = 0; i < multiFiles.length; i++) {
            formdata.append("multiFiles", multiFiles[i])
        }
        $.ajax({
            type: "POST",
            url: '/Employee/AddEmployeeName',
            data: formdata,
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
    //}
}

function ViewFromData(Id) {

    $("#TxtId").val(Id);
    $.ajax({
        type: "GET",
        url: '/Employee/ViewemployeeName?Id=' + Id,
        success: function (return_Data) {
            if (return_Data != null) {
                $("#TxtEmpName").val(return_Data.EmpModels.Name);
                $("#TxtEmpContact").val(return_Data.EmpModels.Contact);
                $("#TxtLocationName").val(return_Data.EmpModels.Location);
                $("#TxtEmpFile").val(return_Data.EmpModels.FilePath).path;
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
    var FilePath = $("#TxtEmpFile")[0].files[0].name;
    var image = $("#TxtEmpFile").get(0).files;
    var multiFiles = $("#TxtEmpFile").get(0).files;
    var path = location.origin + '/Models/' + FilePath;

    var patharray = [];
    var namearray = [];
    Object.keys(multiFiles).forEach(function (key) {
        var patha = location.origin + '/Models/' + multiFiles[key]["name"];
        var namea = multiFiles[key]["name"]
        patharray.push(patha);
        namearray.push(namea);
    });
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
    } else if(FilePath == ""){
        $('.help-block').html('');
        $('#DivEmpFile').addClass('has-error');
        $('#ErrorFile').html('Please Add File.');
        $('#TxtEmpFile').focus();
        return;
    }
    else {
        var formdata = new FormData();
        formdata.append("Id", Id);
        formdata.append("Name", Name);
        formdata.append("Contact", abc);
        formdata.append("Location", Location);
        formdata.append("FilePath", patharray);
        formdata.append("ImageFile", image[0]);
        formdata.append("FileName", namearray);

        for (var i = 0; i < multiFiles.length; i++) {
            formdata.append("multiFiles", multiFiles[i])
        }
        $.ajax({
            type: "POST",
            url: '/Employee/UpdateEmployee',
            data: formdata,
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

//function viewfiles(el) {   
//    var parent = el.parentElement.parentElement;
//    var trchilds = parent.children;
//    var child3 = trchilds[3].innerText;
//    var array = child3.split(',');
//    var fpath = location.origin + '/Models/';
//    array.forEach(function(value, index){
//        htmltag = `<li> <a href="${fpath}${value}" value="${value} target="_blank">${value}</a> </li>`;
//        parent.insertAdjacentHTML("afterend",htmltag);
//    });
//}

function ResetFromData() {
    $("#TxtEmpName").val('');
    $("#TxtEmpContact").val('');
    $("#TxtLocationName").val('');
    $("#TxtEmpFile").val('');
    $(".form-group").removeClass('has-error');
    $(".form-group > span").html('');
    $("#PageTitle").text('Add New Employee');
    $('#btnSave').text('Save');
    $('#btnSave').attr('onclick', 'SaveFromData();');
}
