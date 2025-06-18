/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />

const Generics = {
    init: function ()
    {

    },
    cidades: [],
    obterCidades: function (id)
    {
        const opcoes = {
            url: "/Cliente/ObterCidades/" + id,
            headers: {},
            callBackSuccess: function (response)
            {
                Generics.cidades = response;
            },
            dadoEnvio: {},
            type: "GET",
            async: false
        };

        Ajax.Execute(opcoes);

    }
}