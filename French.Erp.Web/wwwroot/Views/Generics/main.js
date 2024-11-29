/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />

var Generics = new function () { }

Generics.Cidades = [];

Generics.ObterCidades = function (id)
{
    var opcoes = new Object;
    opcoes.url = "/Cliente/ObterCidades/" + id;
    opcoes.headers = {};
    opcoes.callBackSuccess = function (response)
    {
        Generics.Cidades = response;
    };

    opcoes.dadoEnvio = {};

    opcoes.type = "GET";
    opcoes.async = false;

    Ajax.Execute(opcoes);
}
