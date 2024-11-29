$body = $("body");

$(function ()
{
    $('[data-toggle="tooltip"]').tooltip();

    $("form").submit(function ()
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