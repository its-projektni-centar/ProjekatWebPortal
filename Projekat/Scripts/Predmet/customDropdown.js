$(document).ready(function () {
    $(".skole").change( function () {

        var skolaId = $(".skole").val();

        $.ajax({
            method: 'GET',
            url: '/Predmet/DodajPredmet',
            data: {
                skolaId: skolaId,
            },
            success: function (data) {
                $('#_predmetiNaSmeru').html('');
                $('#_predmetiNaSmeru').html(data);
            },
            error: function () {
                console.log("ne valja");
            }
        });
    })
});