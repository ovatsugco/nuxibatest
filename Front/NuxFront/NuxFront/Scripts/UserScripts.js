
$(function () {
    $(".anchorDetail").click(function () {
        debugger;
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: "/User/Details",
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                debugger;
                //alert("regresó datos");
             $('#modalDescription').html(data);
                $('#myModalContent').modal(options);
                $('#myModalContent').modal('show');

            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
    //$("#closebtn").on('click',function(){  
    //    $('#myModal').modal('hide');    

    $("#closbtn").click(function () {
        debugger;
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: "/User/Details",
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                debugger;
                //alert("regresó datos");
                $('#modalDescription').html(data);
                $('#myModalContent').modal(options);
                $('#myModalContent').modal('show');

            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
});  

function UserChecked() {
    alert("working");
}