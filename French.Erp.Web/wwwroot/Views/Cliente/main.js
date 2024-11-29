﻿/// <reference path="../generics/main.js" />
/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />


var Cliente = new function () { }


$(document).ready(function ()
{

});

$("#Gravar").click(function ()
{
    if (!Cliente.Consistir())
    {
        return;
    }
    Cliente.Gravar();
});

Cliente.Limpar = function ()
{
    $("#Id").val('0');
    $("#Nome").val('');
    $("#RazaoSocial").val('');
    $("#Documento").val('');
    $("#TipoDeClienteId").val('');
    $("#TipoDePessoaId").val('');
    $("#Telefone").val('');
    $("#Contato").val('');
    $("#Email").val('');
    $("#InscricaoEstadual").val('');
    $("#CadastroMunicipal").val('');
    $("#Endereco").val('');
    $("#Numero").val('');
    $("#Complemento").val('');
    $("#Bairro").val('');
    $("#Cep").val('');
    $("#CidadeId").val('');
    $("#CidadeId").html('');
    $("#CidadeId").selectpicker('refresh')
    $("#EstadoId").val('0');
}



Cliente.Edit = function (id, nome, razaoSocial, documento,
    tipoDeCliente, tipoDePessoa, telefone,
    contato, email, inscricaoEstadual,
    cadastroMunicipal, endereco, numero,
    complemento, bairro, cep, cidade, estado)
{

    Cliente.Limpar();
    $("#Nome").focus();
    $("#Id").val(id);
    $("#Nome").val(nome);
    $("#RazaoSocial").val(razaoSocial);
    $("#Documento").val(documento);
    $("#Contato").val(contato);
    $("#TipoDeClienteId").val(tipoDeCliente);
    $("#TipoDeClienteId").selectpicker('val', tipoDeCliente);
    $("#TipoDePessoaId").val(tipoDePessoa);
    $("#TipoDePessoaId").selectpicker('val', tipoDePessoa);
    $("#Telefone").val(telefone);
    $("#Email").val(email);
    $("#InscricaoEstadual").val(inscricaoEstadual);
    $("#CadastroMunicipal").val(cadastroMunicipal);
    $("#Endereco").val(endereco);
    $("#Numero").val(numero);
    $("#Complemento").val(complemento);
    $("#Bairro").val(bairro);
    $("#Cep").val(cep);
    $("#EstadoId").val(estado);
    $("#EstadoId").selectpicker('val',estado);
    Cliente.RenderizarComboCidades(estado);
    $("#CidadeId").val(cidade);
    $("#CidadeId").selectpicker('val', cidade);
   $("#modalEdicao").modal('show');
}

Cliente.Novo = function ()
{
    Cliente.Limpar()
    $("#Nome").focus();
    $("#modalEdicao").modal('show');
}

Cliente.Gravar = function ()
{

    var token = $('input[name="__RequestVerificationToken"]').val();
    var opcoes = new Object;
    opcoes.url = "/Cliente/Gravar/";
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
        Cliente.Limpar()
        $("#modalEdicao").modal('hide');
        setTimeout(function ()
        {
            location.reload();
        }, 1500);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.ClienteId = $("#ClienteId").val();
    opcoes.dadoEnvio.Nome = $("#Nome").val();
    opcoes.dadoEnvio.RazaoSocial = $("#RazaoSocial").val();
    opcoes.dadoEnvio.Documento = $("#Documento").val();
    opcoes.dadoEnvio.TipoDeClienteId = $("#TipoDeClienteId").val();
    opcoes.dadoEnvio.TipoDePessoaId = $("#TipoDePessoaId").val();
    opcoes.dadoEnvio.Telefone = $("#Telefone").val();
    opcoes.dadoEnvio.Email = $("#Email").val();
    opcoes.dadoEnvio.Contato = $("#Contato").val();
    opcoes.dadoEnvio.InscricaoEstadual = $("#InscricaoEstadual").val();
    opcoes.dadoEnvio.CadastroMunicipal = $("#CadastroMunicipal").val();
    opcoes.dadoEnvio.Endereco = $("#Endereco").val();
    opcoes.dadoEnvio.Numero = $("#Numero").val();
    opcoes.dadoEnvio.Complemento = $("#Complemento").val();
    opcoes.dadoEnvio.Bairro = $("#Bairro").val();
    opcoes.dadoEnvio.Cep = $("#Cep").val();
    opcoes.dadoEnvio.EstadoId = $("#EstadoId").val();
    opcoes.dadoEnvio.CidadeId = $("#CidadeId").val();

    opcoes.type = "POST";
    opcoes.async = false;

    Ajax.Execute(opcoes);

}

Cliente.Consistir = function ()
{

    if ($("#Nome").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Nome!", "Erro.");
        $("#Nome").focus();
        return false;
    }
    if ($("#RazaoSocial").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Razão Social!", "Erro.");
        $("#RazaoSocial").focus();
        return false;
    }
    if ($("#Documento").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Documento!", "Erro.");
        $("#Documento").focus();
        return false;
    }
    if ($("#TipoDeClienteId").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Tipo De Cliente!", "Erro.");
        $("#TipoDeClienteId").focus();
        return false;
    }
    if ($("#TipoDePessoaId").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Tipo De Pessoa!", "Erro.");
        $("#TipoDePessoaId").focus();
        return false;
    }
    if ($("#Telefone").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Telefone!", "Erro.");
        $("#Telefone").focus();
        return false;
    }
    if ($("#Email").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Email!", "Erro.");
        $("#Email").focus();
        return false;
    }

    return true;

}

Cliente.Excluir = function (id)
{

    var opcoes = new Object;
    opcoes.url = "/Cliente/Excluir/" + id;
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

$("#EstadoId").change(function ()
{
    Cliente.RenderizarComboCidades($("#EstadoId").val());
});

Cliente.RenderizarComboCidades = function (id)
{
    Generics.ObterCidades(id);
    var cidades = Generics.Cidades;
    var opcoes = '<option value="0">Selecione</option>';
    for (var i = 0; i < cidades.length; i++)
    {
        opcoes += Util.ObterLista(cidades[i].cidadeId, cidades[i].nome) + '\n';
    }

    $("#CidadeId").html(opcoes);
    $("#CidadeId").selectpicker('refresh')
}

