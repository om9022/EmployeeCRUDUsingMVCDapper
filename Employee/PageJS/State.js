$(document).ready(function () {
    $("#TxtContryName").change(function () {
        var selectItem = $(this).val();
        //var LoadingProcess = $("#LoadingProcess");
        //LoadingProcess.show();

        $.ajax({
            type: "GET",
            url: "/State/GetStateList?ContryId=" + selectItem,
            //dataType: "JSON",
            //data: {id: $("TxtContryName") },
            success: function (result) {
                for (var i = 0; i < result.StateModelList.length; i++) {
                    $("#TxtStateName").append('<option value="' + result.StateModelList[i].StateId + '">' + result.StateModelList[i].StateName + '</option>')
                }
            }
        });
    })
});

$(document).ready(function () {
    $("#TxtStateName").change(function () {
        var selectItem = $(this).val();
        //var LoadingProcess = $("#LoadingProcess");
        //LoadingProcess.show();
        $.ajax({
            type: "GET",
            url: "/State/GetCityList?StateId=" + selectItem,
            //dataType: "JSON",
            //data: {id: $("TxtContryName") },
            success: function (result) {
                $("#TxtCityName").append('<option value=""></option>')
                for (var i = 0; i < result.CityModelList.length; i++) {
                    $("#TxtCityName").append('<option id="state" value="' + result.CityModelList[i].CityId + '">' + result.CityModelList[i].CityName + '</option>')
                }
                
            }
            
        });
        removecity();
    })

    $(document).ready(function () {
        $("#TxtStateName").click(function () {
            var index = $("#TxtCityName").get(0).selectedIndex;
            $('#TxtCityName opton:eq('+index+')').remove();
        });
    });
        
    


    function removecity() {
        var target = document.getElementById('TxtCityName');
        while (target.firstChild) {
            target.removeChild(target.firstChild);
        }
    }
});