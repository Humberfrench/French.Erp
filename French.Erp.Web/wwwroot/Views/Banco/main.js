/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />
var Banco = new function () { }


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
    if ($("#Codigo").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Codigo!", "Erro.");
        $("#Codigo").focus();
        return false;
    }
    if ($("#Apelido").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Apelido!", "Erro.");
        $("#Apelido").focus();
        return false;
    }
    if ($("#Descricao").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Descrição!", "Erro.");
        $("#Descricao").focus();
        return false;
    }
    Banco.Gravar();
});

Banco.Limpar = function ()
{
    $("#BancoId").val('0');
    $("#Codigo").val('');
    $("#Apelido").val('');
    $("#Nome").val('');
    $("#Status").prop("checked", false);
}

Banco.Edit = function (id, codigo, apelido, nome, status)
{
    $("#Nome").focus();
    $("#BancoId").val(id);
    $("#Codigo").val(codigo);
    $("#Apelido").val(apelido);
    $("#Nome").val(nome);
    if (status === 'True')
        $("#Status").prop("checked", true);
    else
        $("#Status").prop("checked", false);

    $("#modalEdicao").modal('show');
}

Banco.Novo = function ()
{
    Banco.Limpar()
    $("#Nome").focus();
    $("#modalEdicao").modal('show');
}

Banco.Gravar = function ()
{

    var token = $('input[name="__RequestVerificationToken"]').val();
    var opcoes = new Object;
    opcoes.url = "/Banco/Gravar/";
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
        Banco.Limpar()
        $("#modalEdicao").modal('hide');
        setTimeout(function ()
        {
            location.reload();
        }, 1500);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.BancoId = $("#BancoId").val();
    opcoes.dadoEnvio.Nome = $("#Nome").val();
    opcoes.dadoEnvio.Codigo = $("#Codigo").val();
    opcoes.dadoEnvio.Apelido = $("#Apelido").val();
    opcoes.dadoEnvio.Status = $("#Status").prop("checked");

    opcoes.type = "POST";
    opcoes.async = false;

    Ajax.Execute(opcoes);

}

Banco.Excluir = function (id)
{

    var opcoes = new Object;
    opcoes.url = "/Banco/Excluir/" + id;
    opcoes.headers = {};
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
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

}

