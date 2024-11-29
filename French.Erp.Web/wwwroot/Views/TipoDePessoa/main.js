/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />
var TipoDePessoa = new function () { }


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
    TipoDePessoa.Gravar();
});

TipoDePessoa.Limpar = function ()
{
    $("#TipoDePessoaId").val('0');
    $("#Descricao").val('');
}

TipoDePessoa.Edit = function (id, descricao)
{
    $("#TipoDePessoaId").val(id);
    $("#Descricao").focus();
    $("#Descricao").val(descricao);
    $("#modalEdicao").modal('show');
}

TipoDePessoa.Novo = function ()
{
    TipoDePessoa.Limpar()
    $("#Descricao").focus();
    $("#modalEdicao").modal('show');
}

TipoDePessoa.Gravar = function ()
{
    var token = $('input[name="__RequestVerificationToken"]').val();
    var opcoes = new Object;
    opcoes.url = "/TipoDePessoa/Gravar/";
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
        TipoDePessoa.LimparForm();
        $("#modalEdicao").modal('hide');
        setTimeout(function ()
        {
            location.reload();
        }, 1500);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.TipoDePessoaId = $("#TipoDePessoaId").val();
    opcoes.dadoEnvio.Descricao = $("#Descricao").val();

    opcoes.type = "POST";
    opcoes.async = false;

    Ajax.Execute(opcoes);
}

TipoDePessoa.Excluir = function (id) {

    var opcoes = new Object;
    opcoes.url = "/TipoDePessoa/Excluir/" + id;
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

