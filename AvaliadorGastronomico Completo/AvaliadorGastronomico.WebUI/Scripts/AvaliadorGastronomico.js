$(document).ready(function () {

    $(":input[data-autocomplete]").each(function () {
        $(this).autocomplete({
            source: $(this).attr("data-autocomplete")
        });
    });

    $(":input[data-datepicker]").datepicker();

    $("#formBuscarRestaurantesJson").on("submit", function (e) {
        e.preventDefault();
        $("#progress").show();
        $.getJSON(
            $(this).attr("action"),
            $(this).serialize(),
            function (data) {
                $("#progress").hide();
                var resultado = $("#resultadoBuscaTemplate").tmpl(data);
                $("#ResultadoBuscaContainerJson").empty().append(resultado);
            }
        );
    });
});