
if (typeof jQuery === 'undefined')
{
    console.error('jQuery não está carregado!');
} else
{
    console.log('jQuery está carregado!');
}
const $body = jQuery("body");

$(function ()
{
    $('[data-toggle="tooltip"]').tooltip();

    $("form").on('submit', function ()
    {
        $body.addClass("loading");
    });

    $(".sidebar-dropdown > a").click(function ()
    {
        $(".sidebar-submenu").slideUp(200);
        if (
            $(this)
                .parent()
                .hasClass("active")
        )
        {
            $(".sidebar-dropdown").removeClass("active");
            $(this)
                .parent()
                .removeClass("active");
        } else
        {
            $(".sidebar-dropdown").removeClass("active");
            $(this)
                .next(".sidebar-submenu")
                .slideDown(200);
            $(this)
                .parent()
                .addClass("active");
        }
    });

    $("#close-sidebar").click(function ()
    {
        $(".page-wrapper").removeClass("toggled");
    });
    $("#show-sidebar").click(function ()
    {
        $(".page-wrapper").addClass("toggled");
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


