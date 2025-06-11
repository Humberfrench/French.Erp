/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />

const Login = {
    init: function ()
    {
        Login.initFormValidation(); // Chama o método para inicializar a validação do formulário
    },
    recuperarSenha: function (id)
    {
        var opcoes = {};
        opcoes.url = "/Tarefa/Excluir/" + id;
        opcoes.headers = {};
        opcoes.callBackSuccess = function (response)
        {
            var dataObj = JSON.parse(response); // Usar JSON.parse em vez de eval
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
    },
    initFormValidation: function ()
    {
        'use strict';
        // Busca todos os formulários que queremos aplicar estilos de validação do Bootstrap
        const forms = document.querySelectorAll('.needs-validation');
        // Loop sobre eles e prevenir a submissão
        Array.from(forms).forEach(form =>
        {
            form.addEventListener('submit', event =>
            {
                if (!form.checkValidity())
                {
                    $body.removeClass("loading");
                    event.preventDefault();
                    event.stopPropagation();
                    Mensagens.Erro('Existe campos não prrenchidos corretamente. Favor verificar', 'Erros')
                }
                form.classList.add('was-validated');
            }, false);
        });
    }

};

$(document).ready(function ()
{
    Login.init();
});
