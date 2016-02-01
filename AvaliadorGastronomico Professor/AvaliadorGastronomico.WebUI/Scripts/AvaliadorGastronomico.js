$(document).ready(function () {

    // slide 45
    $(":input[data-autocomplete]").each(function () {
        $(this).autocomplete({
            source: $(this).attr("data-autocomplete")
        });
    });
    // fim slide 45

    // Slide 46
    $(":input[data-datepicker]").datepicker();
    // fim slide 46

    // Slide 47
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
    // Fim Slide 47
});