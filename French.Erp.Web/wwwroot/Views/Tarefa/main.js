﻿/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />

const Tarefa = {
    init: function ()
    {
        //Tarefa.initFormValidation(); // Chama o método para inicializar a validação do formulário
    },
    novo: function ()
    {
        const cliente = document.getElementById("Cliente");
        if (cliente.value === "" || cliente.value === "0")
        {
            location.href = `/Tarefa/New/`;
            return;
        }

        location.href = `/Tarefa/New/` + cliente.value;


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
            Mensagens.Erro("Preencha o campo de cliente.");
            return;
        }

        // Usando template literals para interpolar as variáveis
        location.href = `/Tarefa/Cliente/${cliente.value}/Ano/${ano.value}/Mes/${mes.value}`;

    }
}
