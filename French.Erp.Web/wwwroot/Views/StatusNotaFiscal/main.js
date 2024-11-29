/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />
var StatusNotaFiscal = new function () { }


$(document).ready(function ()
{

});

$("#Gravar").click(function ()
{
    if ($("#Descricao").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Descrição!", "Erro.");
        $("#Descricao").focus();
        return false;
    }
    StatusNotaFiscal.Gravar();
});

StatusNotaFiscal.Limpar = function ()
{
    $("#StatusNotaFiscalId").val('0');
    $("#Descricao").val('');
}

StatusNotaFiscal.Edit = function (id, descricao)
{
    $("#StatusNotaFiscalId").val(id);
    $("#Descricao").val(descricao);
    $("#Descricao").focus();
    $("#modalEdicao").modal('show');
}

StatusNotaFiscal.Novo = function ()
{
    StatusNotaFiscal.Limpar()
    $("#Descricao").focus();
    $("#modalEdicao").modal('show');
}

StatusNotaFiscal.Gravar = function ()
{

    var token = $('input[name="__RequestVerificationToken"]').val();
    var opcoes = new Object;
    opcoes.url = "/StatusNotaFiscal/Gravar/";
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
        StatusNotaFiscal.Limpar()
        $("#modalEdicao").modal('hide');
        setTimeout(function ()
        {
            location.reload();
        }, 1500);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.StatusNotaFiscalId = $("#StatusNotaFiscalId").val();
    opcoes.dadoEnvio.Descricao = $("#Descricao").val();

    opcoes.type = "POST";
    opcoes.async = false;

    Ajax.Execute(opcoes);

}

StatusNotaFiscal.Excluir = function (id) {

    var opcoes = new Object;
    opcoes.url = "/StatusNotaFiscal/Excluir/" + id;
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

