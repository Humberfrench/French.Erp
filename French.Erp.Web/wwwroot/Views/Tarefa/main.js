/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />
var Tarefa = new function () { }

const Tarefa = {
    Excluir: function (id)
    {
        var opcoes = {};
        opcoes.url = "/Tarefa/Excluir/" + id;
        opcoes.headers = {};
        opcoes.callBackSuccess = function (response)
        {
            var dataObj = JSON.parse(response); // Usar JSON.parse em vez de eval
            if (dataObj.erro)
            {
                Mensagens.Erro(dataObj.mensagem, "Erro!");
                return;
            }
            Mensagens.Sucesso(dataObj.mensagem, "Sucesso!");
            setTimeout(function ()
            {
                location.reload();
            }, 1500);
        };
        opcoes.dadoEnvio = {};
        opcoes.type = "POST";
        opcoes.async = false;
        Ajax.Execute(opcoes);
    },
    Novo: function ()
    {
        location.href = '/Tarefa/New';
    }
};

// Código para manipulação do DOM
$(function ()
{
    $("#Cliente").val($("#ClienteId").val());
});

$("#Cliente").change(function ()
{
    var uri = '/Tarefa/';
    var id = $("#Cliente").val();
    $("#ClienteId").val(id);
    if (id === '0')
    {
        location.href = uri;
    }
    location.href = uri + id;
});

