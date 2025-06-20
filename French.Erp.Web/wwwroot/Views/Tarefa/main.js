/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />
var Tarefa = new function () { }

const Feriado = {
    init: function ()
    {
        //Feriado.initFormValidation(); // Chama o método para inicializar a validação do formulário
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
    obter: function ()
    {
        const cliente = document.getElementById("Cliente");
        const mes = document.getElementById("Mes");
        const ano = document.getElementById("Ano");

        if (cliente.value === "" || cliente.value === "0" ) {
            Mensagens.alerta("Preencha o campo de cliente.");
            return;
        }

        // Usando template literals para interpolar as variáveis
        location.href = `/Feriado/Cliente/${cliente.value}/Ano/${ano.value}/Mes/${mes.value}`;

    }
}
