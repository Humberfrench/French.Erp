/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />


const Servico = {
    init: function ()
    {
        //Servico.initFormValidation(); // Chama o método para inicializar a validação do formulário
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
        opcoes.url = "/Servico/Excluir/" + id;
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
    saveAll: function (id, nome, descricao)
    {
        const token = $('input[name="__RequestVerificationToken"]').val();

        const opcoes = {
            url: "/Servico/Gravar/",
            headers: {
                "__RequestVerificationToken": token
            },
            type: "POST",
            dadoEnvio: {
                ServicoId: id,
                Nome: nome,
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
        const nomeCol = element.closest("div").querySelector("[data-parent='nome']");
        const descricaoCol = element.closest("div").querySelector("[data-parent='descricao']");

        const id = nomeCol.querySelector("#ServicoId");
        const nome = nomeCol.querySelector("#Nome");
        const descricao = descricaoCol.querySelector("#Descricao");

        if (!Servico.validateInputs(nome, descricao))
        {
            return;
        }

        Servico.saveAll(id.value, nome.value, descricao.value)

    },
    gravar: function (element)
    {
        const idCol = element.closest("tr").querySelector("[data-parent='id']");
        const nomeCol = element.closest("div").querySelector("[data-parent='nome']");
        const descricaoCol = element.closest("div").querySelector("[data-parent='descricao']");

        const id = idCol.querySelector("#ServicoId");
        const nome = nomeCol.querySelector("#Nome");
        const descricao = descricaoCol.querySelector("#Descricao");

        if (!Servico.validateInputs(nome, descricao))
        {
            return;
        }

        Servico.saveAll(id.value, nome.value, descricao.value)

    },
    validateInputs: function (nome, descricao)
    {
        var valid = true;
        var mensagem = "";

        nome.classList.remove('is-invalid');
        descricao.classList.remove('is-invalid');

        if (nome.value === '')
        {
            mensagem += "Preencher corretamente com o nome do Servico!<br />";
            nome.classList.add('is-invalid');
            valid = false;
        }

        if (descricao.value === '')
        {
            mensagem += "Preencher corretamente com a descrição do Servico!<br />";
            descricao.classList.add('is-invalid');
            valid = false;
        }

        if (valid)
        {
            nome.classList.add('is-valid');
            descricao.classList.add('is-valid');
        }
        else
        {
            Mensagens.Erro(mensagem, "Erro.");
        }

        return valid;

    }
};
