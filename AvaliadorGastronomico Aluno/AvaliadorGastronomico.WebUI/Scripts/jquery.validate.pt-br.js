﻿/*
 * Translated default messages for the jQuery validation plugin.
 * Locale: PT (Portuguese; portuguÃªs)
 * Region: BR (Brazil)
 */
$.extend($.validator.messages, {

    // Core
    required: "Este campo &eacute; requerido",
    remote: "Por favor, corrija este campo.",
    email: "Por favor, forne&ccedil;a um endere&ccedil;o de email v&aacute;lido.",
    url: "Por favor, forne&ccedil;a uma URL v&aacute;lida.",
    date: "Por favor, forne&ccedil;a uma data v&aacute;lida.",
    dateISO: "Por favor, forne&ccedil;a uma data v&aacute;lida (ISO).",
    number: "Forne&ccedil;a um n&uacute;mero v&aacute;lido",
    digits: "Forne&ccedil;a somente d&iacute;gitos",
    creditcard: "Por favor, forne&ccedil;a um cart&atilde;o de cr&eacute;dito v&aacute;lido.",
    equalTo: "Por favor, forne&ccedil;a o mesmo valor novamente.",
    maxlength: $.validator.format("Por favor, forne&ccedil;a n&atilde;o mais que {0} caracteres."),
    minlength: $.validator.format("Por favor, forne&ccedil;a ao menos {0} caracteres."),
    rangelength: $.validator.format("Por favor, forne&ccedil;a um valor entre {0} e {1} caracteres de comprimento."),
    range: $.validator.format("Por favor, forne&ccedil;a um valor entre {0} e {1}."),
    max: $.validator.format("Forne&ccedil;a um valor menor ou igual a {0}"),
    min: $.validator.format("Forne&ccedil;a um valor maior ou igual a {0}")

});

jQuery.extend(jQuery.validator.methods, {
    date: function (value, element) {
        return this.optional(element) || /^\d\d?\/\d\d?\/\d\d\d?\d?$/.test(value);
    },
    number: function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(value);
    }
});