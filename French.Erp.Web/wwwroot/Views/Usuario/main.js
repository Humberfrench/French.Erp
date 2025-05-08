/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />

const Usuario = {
    Limpar: function ()
    {
        $("#UsuarioId").val('0');
        $("#Descricao").val('');
        $("#Nome").val('');
    },

    Edit: function (id, descricao, nome, email, celular, documento, tentativas, dataLogin, dataCriacao, dataAtualizacao, validadeSenha, ativo, admin)
    {
        $("#UsuarioId").val(id);
        $("#Descricao").val(descricao);
        $("#Nome").val(nome);
        $("#modalEdicao").modal('show');
        $("#Nome").focus();
    },

    Novo: function ()
    {
        this.Limpar();
        $("#modalEdicao").modal('show');
        $("#Nome").focus();
    },

    Gravar: function ()
    {
        if (!this.validarCampos()) return;

        const token = $('input[name="__RequestVerificationToken"]').val();
        const opcoes = {
            url: "/Usuario/Gravar/",
            headers: {
                "__RequestVerificationToken": token
            },
            dadoEnvio: {
                UsuarioId: $("#UsuarioId").val(),
                Nome: $("#Nome").val(),
                Descricao: $("#Descricao").val()
            },
            type: "POST"
        };

        Ajax.Execute(opcoes).then(response =>
        {
            const dataObj = JSON.parse(response);
            if (dataObj.erro)
            {
                Mensagens.Erro(dataObj.mensagem, "Erro!");
                return;
            }
            Mensagens.Sucesso(dataObj.mensagem, "Sucesso!");
            this.Limpar();
            $("#modalEdicao").modal('hide');
            setTimeout(() => location.reload(), 1500);
        }).catch(error =>
        {
            Mensagens.Erro("Ocorreu um erro ao gravar os dados.", "Erro!");
            console.error(error);
        });
    },

    Excluir: function (id)
    {
        const opcoes = {
            url: `/Usuario/Excluir/${id}`,
            type: "POST"
        };

        Ajax.Execute(opcoes).then(response =>
        {
            const dataObj = JSON.parse(response);
            if (dataObj.erro)
            {
                Mensagens.Erro(dataObj.mensagem, "Erro!");
                return;
            }
            Mensagens.Sucesso(dataObj.mensagem, "Sucesso!");
            setTimeout(() => location.reload(), 1500);
        }).catch(error =>
        {
            Mensagens.Erro("Ocorreu um erro ao excluir o usuário.", "Erro!");
            console.error(error);
        });
    },

    validarCampos: function ()
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
        return true;
    }
};

$(document).ready(function ()
{
    $("#Gravar").click(function ()
    {
        Usuario.Gravar();
    });
});
