/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />
var TipoDeCliente = new function () { }


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
    TipoDeCliente.Gravar();
});

TipoDeCliente.Limpar = function ()
{
    $("#TipoDeClienteId").val('0');
    $("#Descricao").val('');
}

TipoDeCliente.Edit = function (id, descricao)
{
    $("#TipoDeClienteId").val(id);
    $("#Descricao").val(descricao);
    $("#Descricao").focus();
    $("#modalEdicao").modal('show');
}

TipoDeCliente.Novo = function ()
{
    TipoDeCliente.Limpar()
    $("#Descricao").focus();
    $("#modalEdicao").modal('show');
}

TipoDeCliente.Gravar = function ()
{

    var token = $('input[name="__RequestVerificationToken"]').val();
    var opcoes = new Object;
    opcoes.url = "/TipoDeCliente/Gravar/";
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
        TipoDeCliente.Limpar()
        $("#modalEdicao").modal('hide');
        setTimeout(function ()
        {
            location.reload();
        }, 1500);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.TipoDeClienteId = $("#TipoDeClienteId").val();
    opcoes.dadoEnvio.Descricao = $("#Descricao").val();

    opcoes.type = "POST";
    opcoes.async = false;

    Ajax.Execute(opcoes);

}

TipoDeCliente.Excluir = function (id) {

    var opcoes = new Object;
    opcoes.url = "/TipoDeCliente/Excluir/" + id;
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

