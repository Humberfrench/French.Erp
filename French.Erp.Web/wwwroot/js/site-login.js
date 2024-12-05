if (typeof jQuery === 'undefined')
{
    console.error('jQuery não está carregado!');
} else
{
    console.log('jQuery está carregado!');
}
const $body = $("body");

$(function ()
{
    $('[data-toggle="tooltip"]').tooltip();

    $("form").on('submit', function ()
    {
        $body.addClass("loading");
    });

});

$(document).on(
    {
        ajaxStart: function ()
        {
            $body.addClass("loading");

        },

        ajaxStop: function ()
        {
            $body.removeClass("loading");

        },
        load: function () //not working
        {
            $body.addClass("loading");

        },

        loadend: function () //not working
        {
            $body.removeClass("loading");

        },

    });