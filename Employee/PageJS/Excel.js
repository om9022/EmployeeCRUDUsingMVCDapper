

function ExcelData() {
    $('#tableHead').show();
    var ExelF = document.getElementById('TxtExcelFile').files;
    var Excelfile = $("#TxtExcelFile")[0].files[0].name;
    if (ExelF== "") {
        $('.help-block').html('');
        $('#DivExcelFile').addClass('has-error');
        $('#ErrorExcelFile').html('Please Upload Excelfile');
        $('#TxtExcelFile').focus();
        return;
    }

    else {
        var formdata = new FormData();
        formdata.append("Excelfile", ExelF[0]);
        formdata.append("excelName", ExelF[0].name);

        $.ajax({
            type: "POST",
            url: '/ExcelRead/ShowExcel',
            data: formdata,
            cache: false,
            contentType: false,
            processData: false,
            beforeSend: function () {
                $("#btnSave").attr('disabled', true);
                var loader = "<i class='fa fa-spinner fa-spin'></i>Please wait.. ";
                $('#btnSave').html(loader);
            },
            success: function (return_Data) {
                

                for (var i = 0; i < return_Data.length; i++) {
                    $("#tbody").append(`
                        <tr id="tableRow" >
                            <td class="text-center">${return_Data[i].Name}</td>
                            <td class="text-center">${return_Data[i].RollNo}</td>
                            <td class="text-center">${return_Data[i].Email}</td>
                        </tr>
                    `)
                   
                }
                
               
            },
            complete: function () {
                $('#btnsave').attr('disabled', false);
                $('#btnsave').html('Save');

            }
        });
    }
    removecity();
}
function removecity() {
    var target = document.getElementById('tbody');
    while (target.firstChild) {
        target.removeChild(target.firstChild);
    }
}
