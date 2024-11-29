﻿$body = $("body");

$(function ()
{
    $('[data-toggle="tooltip"]').tooltip();

    $("form").submit(function ()
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


