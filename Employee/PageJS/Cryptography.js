function PlainText() {
    var submit = $("#encBtn").val();
    var encrypt = $("#encTxt").val();

    var formdata = new FormData();
    formdata.append("Submit", submit);
    formdata.append("PlainText", encrypt);
    $.ajax({
        type:"POST",
        url:'/Cryptography/EncryptText',
        data: formdata,
        processData: false,
        contentType: false,
        success: function (response) {
            
            if (response != null) {
                $("#encValue").val(response);
            } else {
                alert("Error");
            }
        }
    });
}
function cipherText() {
    
    var submit = $("#decBtn").val();
    var decrypt = $("#decTxt").val();
    var formdata = new FormData();
    formdata.append("Submit", submit);
    formdata.append("cipherText", decrypt);
    $.ajax({
        type: "POST",
        url: '/Cryptography/EncryptText',
        data: formdata,
        processData: false,
        contentType: false,
        success: function (response) {
            console.log(response);
            if (response != null) {
                $("#decValue").val(response);
            } else {
                alert("Error");
            }
        }
    });
}


function ResetFromData() {
    $("#encTxt").val('');
    $("#encValue").val('');
    $("#decTxt").val('');
    $("#decValue").val('');
}