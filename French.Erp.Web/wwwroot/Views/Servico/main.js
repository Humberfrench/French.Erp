/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />
var Servico = new function () { }


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
    Servico.Gravar();
});

Servico.Limpar = function ()
{
    $("#ServicoId").val('0');
    $("#Descricao").val('');
    $("#Nome").val('');
}

Servico.Edit = function (id, descricao, nome)
{
    $("#Nome").focus();
    $("#ServicoId").val(id);
    $("#Descricao").val(descricao);
    $("#Nome").val(nome);
    $("#modalEdicao").modal('show');
}

Servico.Novo = function ()
{
    Servico.Limpar()
    $("#Nome").focus();
    $("#modalEdicao").modal('show');
}

Servico.Gravar = function ()
{

    var token = $('input[name="__RequestVerificationToken"]').val();
    var opcoes = new Object;
    opcoes.url = "/Servico/Gravar/";
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
        Servico.Limpar()
        $("#modalEdicao").modal('hide');
        setTimeout(function ()
        {
            location.reload();
        }, 1500);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.ServicoId = $("#ServicoId").val();
    opcoes.dadoEnvio.Nome = $("#Nome").val();
    opcoes.dadoEnvio.Descricao = $("#Descricao").val();

    opcoes.type = "POST";
    opcoes.async = false;

    Ajax.Execute(opcoes);

}

Servico.Excluir = function (id) {

    var opcoes = new Object;
    opcoes.url = "/Servico/Excluir/" + id;
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

