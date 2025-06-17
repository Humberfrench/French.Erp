/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />


const Tributo = {
    init: function ()
    {
        //Tributo.initFormValidation(); // Chama o método para inicializar a validação do formulário
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
        opcoes.url = "/Tributo/Excluir/" + id;
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
        const token = $('input[name="__RequestVerificationToken"]').val();

        const opcoes = {
            url: "/Tributo/Gravar/",
            headers: {
                "__RequestVerificationToken": token
            },
            type: "POST",
            dadoEnvio: {
                TributoId: id,
                Nome: nome,
                Codigo: codigo,
                Apelido: apelido,
                Status: statusField === '1'
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
        const codigoCol = element.closest("div").querySelector("[data-parent='codigo']");
        const descricaoCol = element.closest("div").querySelector("[data-parent='descricao']");
        const percentualCol = element.closest("div").querySelector("[data-parent='percentual']");
        const retencaoCol = element.closest("div").querySelector("[data-parent='retencao']");
        const faixainicialCol = element.closest("div").querySelector("[data-parent='faixainicial']");
        const faixafinalCol = element.closest("div").querySelector("[data-parent='faixafinal']");
        const valordeducaoCol = element.closest("div").querySelector("[data-parent='valordeducao']");

        const id = codigoCol.querySelector("#TributoId");
        const descricao = descricaoCol.querySelector("#Nome");
        const percentual = percentualCol.querySelector("#Percentual");
        const retencao = retencaoCol.querySelector("#RetemNaNota");
        const faixainicial = faixainicialCol.querySelector("#FaixaInicial");
        const faixafinal = faixafinalCol.querySelector("#FaixaFinal");
        const valordeducao = valordeducaoCol.querySelector("#ValorDeducao");

        if (!Tributo.validateInputs(id, descricao, percentual, retencao, faixainicial, faixafinal, valordeducao))
        {
            return;
        }

        Tributo.saveAll(id.value, descricao.value, percentual.value, retencao.value, faixainicial.value, faixafinal.value, valordeducao.value)

    },
    gravar: function (element)
    {
        const idCol = element.closest("tr").querySelector("[data-parent='descricao']");

        const id = idCol.querySelector("#TributoId");
        const descricao = nomeCol.querySelector("#Descricao");

        if (!Tributo.validateInputs(id, descricao))
        {
            return;
        }

        Tributo.saveAll(id.value, descricao.value)

    },
    validateInputs: function (id, descricao, percentual, retencao, faixainicial, faixafinal, valordeducao)
    {
        var valid = true;
        var mensagem = "";

        id.classList.add('is-valid');
        descricao.classList.remove('is-invalid');

        if (descricao.value === '0' || descricao.value === '')
        {
            mensagem += "Selecione uma descrição para o Tributo!<br />";
            descricao.classList.add('is-invalid');
            valid = false;
        }

        if (percentual.value === '0' || percentual.value === '')
        {
            mensagem += "Selecione um percentual!<br />";
            percentual.classList.add('is-invalid');
            valid = false;
        }

        if (retencao.value === '')
        {
            mensagem += "Selecione um valor de retenção!<br />";
            retencao.classList.add('is-invalid');
            valid = false;
        }
        if (faixainicial.value === '')
        {
            mensagem += "Selecione um valor de faixa inicial! O Valor pode ser R$ 0,00<br />";
            faixainicial.classList.add('is-invalid');
            valid = false;
        }

        if (faixafinal.value === '')
        {
            mensagem += "Selecione um valor de faixa final! O Valor pode ser R$ 0,00<br />";
            faixafinal.classList.add('is-invalid');
            valid = false;
        }

        if (valordeducao.value === '')
        {
            mensagem += "Selecione um valor de dedução! O Valor pode ser R$ 0,00<br />";
            valordeducao.classList.add('is-invalid');
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

