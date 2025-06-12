/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />


const Banco = {
    init: function ()
    {
        //Banco.initFormValidation(); // Chama o método para inicializar a validação do formulário
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
        opcoes.url = "/Banco/Excluir/" + id;
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
    saveAll: function (id, codigo, nome, apelido, statusField)
    {
        const token = $('input[name="__RequestVerificationToken"]').val();

        const opcoes = {
            url: "/Banco/Gravar/",
            headers: {
                "__RequestVerificationToken": token
            },
            type: "POST",
            dadoEnvio: {
                BancoId: id,
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
        const nomeCol = element.closest("div").querySelector("[data-parent='nome']");
        const apelidoCol = element.closest("div").querySelector("[data-parent='apelido']");
        const statusCol = element.closest("div").querySelector("[data-parent='status']");

        const id = codigoCol.querySelector("#BancoId");
        const codigo = codigoCol.querySelector("#Codigo");
        const nome = nomeCol.querySelector("#Nome");
        const apelido = apelidoCol.querySelector("#Apelido");
        const status = statusCol.querySelector("#Status");

        if (!Banco.validateInputs(id, codigo, nome, apelido, status))
        {
            return;
        }

        Banco.saveAll(id.value, codigo.value, nome.value, apelido.value, status.value)

    },
    gravar: function (element)
    {
        const idCol = element.closest("tr").querySelector("[data-parent='id']");
        const codigoCol = element.closest("tr").querySelector("[data-parent='codigo']");
        const nomeCol = element.closest("tr").querySelector("[data-parent='nome']");
        const apelidoCol = element.closest("tr").querySelector("[data-parent='apelido']");
        const statusCol = element.closest("tr").querySelector("[data-parent='status']");

        const id = idCol.querySelector("#BancoId");
        const codigo = codigoCol.querySelector("#Codigo");
        const nome = nomeCol.querySelector("#Nome");
        const apelido = apelidoCol.querySelector("#Apelido");
        const status = statusCol.querySelector("#Status");

        if (!Banco.validateInputs(id, codigo, nome, apelido, status))
        {
            return;
        }

        Banco.saveAll(id.value, codigo.value, nome.value, apelido.value, status.value)

    },
    validateInputs: function (id, codigo, nome, apelido, statusField)
    {
        var valid = true;
        var mensagem = "";

        id.classList.add('is-valid');
        codigo.classList.remove('is-invalid');
        nome.classList.remove('is-invalid');
        apelido.classList.remove('is-invalid');
        statusField.classList.remove('is-invalid');

        if (codigo.value === '0' || codigo.value === '')
        {
            mensagem += "Selecione um Código para o Banco!<br />";
            codigo.classList.add('is-invalid');
            valid = false;
        }

        if (nome.value === '')
        {
            mensagem += "Preencher corretamente com o nome do Banco!<br />";
            nome.classList.add('is-invalid');
            valid = false;
        }

        if (apelido.value === '')
        {
            mensagem += "Preencher corretamente com o Apelido do Banco!<br />";
            apelido.classList.add('is-invalid');
            valid = false;
        }

        if (statusField.value !== '0' && statusField.value !== '1')
        {
            mensagem += "Preencher corretamente com o Status do Banco!<br />";
            statusField.classList.add('is-invalid');
            valid = false;
        }

        if (valid)
        {
            codigo.classList.add('is-valid');
            nome.classList.add('is-valid');
            apelido.classList.add('is-valid');
            statusField.classList.add('is-valid');
        }
        else
        {
            Mensagens.Erro(mensagem, "Erro.");
        }

        return valid;

    }
};

