/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />
var Tributo = new function () { }


$(document).ready(function ()
{

});

$("#Gravar").click(function ()
{
    if ($("#Nome").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Nome!", "Erro.");
        $("#Nome").focus();
        return false;
    }
    if ($("#Descricao").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Descrição!", "Erro.");
        $("#Descricao").focus();
        return false;
    }
    Tributo.Gravar();
});

Tributo.Limpar = function ()
{
    $("#TributoId").val('0');
    $("#Descricao").val('');
    $("#RetemNaNota").prop('checked', '');
    $("#Percentual").val('');
    $("#FaixaInicial").val('');
    $("#FaixaFinal").val('');
    $("#ValorRetido").val('');
}

Tributo.Edit = function (id, descricao, retemNaNota, percentual, faixaInicial, faixaFinal, valorDeducao)
{
    $("#Nome").focus();

    $("#TributoId").val(id);
    $("#Descricao").val(descricao);

    if (retemNaNota)
    {
        $("#RetemNaNota").prop('checked', 'checked');
    }

    $("#Percentual").val(percentual);
    $("#FaixaInicial").val(faixaInicial);
    $("#FaixaFinal").val(faixaFinal);
    $("#ValorDeducao").val(valorDeducao);
    
    $("#modalEdicao").modal('show');
}

Tributo.Novo = function ()
{
    Tributo.Limpar()
    $("#Nome").focus();
    $("#modalEdicao").modal('show');
}

Tributo.Gravar = function ()
{

    var token = $('input[name="__RequestVerificationToken"]').val();
    var opcoes = new Object;
    opcoes.url = "/Tributo/Gravar/";
    opcoes.headers = {};
    opcoes.headers["__RequestVerificationToken"] = token;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        if (dataObj.erro)
        {
            Mensagens.Erro(dataObj.mensagem, "Erro!");
            return;
        }
        Mensagens.Sucesso(dataObj.mensagem, "Sucesso!");
        Tributo.Limpar()
        $("#modalEdicao").modal('hide');
        setTimeout(function ()
        {
            location.reload();
        }, 1500);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.TributoId = $("#TributoId").val();
    opcoes.dadoEnvio.Descricao = $("#Descricao").val();
    opcoes.dadoEnvio.RetemNaNota = $("#RetemNaNota").prop('checked') === true;
    opcoes.dadoEnvio.Percentual = $("#Percentual").val();
    opcoes.dadoEnvio.FaixaInicial = $("#FaixaInicial").val();
    opcoes.dadoEnvio.FaixaFinal = $("#FaixaFinal").val();
    opcoes.dadoEnvio.ValorRetido = $("#ValorRetido").val();


    opcoes.type = "POST";
    opcoes.async = false;

    Ajax.Execute(opcoes);

}

Tributo.Excluir = function (id) {

    var opcoes = new Object;
    opcoes.url = "/Tributo/Excluir/" + id;
    opcoes.headers = {};
    opcoes.callBackSuccess = function (response) {
        var dataObj = eval(response);
        if (dataObj.erro) {
            Mensagens.Erro(dataObj.mensagem, "Erro!");
            return;
        }
        Mensagens.Sucesso(dataObj.mensagem, "Sucesso!");
        setTimeout(function () {
            location.reload();
        }, 1500);
    };

    opcoes.dadoEnvio = {};

    opcoes.type = "POST";
    opcoes.async = false;

    Ajax.Execute(opcoes);

}

