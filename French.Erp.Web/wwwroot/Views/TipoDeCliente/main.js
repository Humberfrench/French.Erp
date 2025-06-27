/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />


const TipoDeCliente = {
    init: function ()
    {
        //TipoDeCliente.initFormValidation(); // Chama o método para inicializar a validação do formulário
    },
    novo: function ()
    {
        const novo = document.getElementById("divNovo");
        const botaoNovo = document.getElementById("botaoNovo");
        botaoNovo.classList.add("d-none");
        novo.classList.remove("d-none");
    },
    limpar: function ()
    {
        const novo = document.getElementById("divNovo");
        const botaoNovo = document.getElementById("botaoNovo");
        botaoNovo.classList.remove("d-none");
        novo.classList.add("d-none");
    },
    excluir: function (id)
    {
        const opcoes = new Object;
        opcoes.url = "/TipoDeCliente/Excluir/" + id;
        opcoes.headers = {};
        opcoes.callBackSuccess = function (response)
        {
            const dataObj = eval(response);
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
    saveAll: function (id, descricao)
    {

        const opcoes = {
            url: "/TipoDeCliente/Gravar/",
            type: "POST",
            dadoEnvio: {
                TipoDeClienteId: id,
                Descricao: descricao
            },
            callBackSuccess: function (response)
            {
                if (response.erro)
                {
                    Mensagens.Erro(response.mensagem, "Erro!");
                    return;
                }
                Mensagens.Sucesso(response.mensagem, "Sucesso!");
                setTimeout(() =>
                {
                    location.reload();
                }, 1500);
            }
        };

        Ajax.Execute(opcoes);
    },
    novoGravar: function (element)
    {
        const descricaoCol = element.closest("div").querySelector("[data-parent='descricao']");

        const id = idCol.querySelector("#TipoDeClienteId");
        const descricao = descricaoCol.querySelector("#Descricao");

        if (!TipoDeCliente.validateInputs(id, descricao))
        {
            return;
        }

        TipoDeCliente.saveAll(id.value, descricao.value)

    },
    gravar: function (element)
    {
        const idCol = element.closest("tr").querySelector("[data-parent='id']");
        const descricaoCol = element.closest("tr").querySelector("[data-parent='descricao']");

        const id = idCol.querySelector("#TipoDeClienteId");
        const descricao = descricaoCol.querySelector("#Descricao");

        if (!TipoDeCliente.validateInputs(id, descricao))
        {
            return;
        }

        TipoDeCliente.saveAll(id.value, descricao.value)

    },
    validateInputs: function (id, descricao)
    {
        var valid = true;
        var mensagem = "";

        id.classList.add('is-valid');
        descricao.classList.remove('is-invalid');

        if (descricao.value === '0' || descricao.value === '')
        {
            mensagem += "Selecione uma descrição para o Tipo de Cliente!<br />";
            descricao.classList.add('is-invalid');
            valid = false;
        }

        if (valid)
        {
            descricao.classList.add('is-valid');
        }
        else
        {
            Mensagens.Erro(mensagem, "Erro.");
        }

        return valid;

    }
};

