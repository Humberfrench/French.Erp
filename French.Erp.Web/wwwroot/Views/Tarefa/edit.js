/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />
const Tarefa = {
    init: function ()
    {
        //Tarefa.initFormValidation(); // Chama o método para inicializar a validação do formulário
    },
    changeCliente: function ()
    {
        const id = $("#Cliente").val();
        $("#ClienteId").val(id);
    },
    voltar: function ()
    {
        location.href = '/Tarefa/';
    },
    calcularValorOrcado: function ()
    {
        const valorHora = document.getElementById("ValorHora");
        const quantidade = document.getElementById("TotalHoras");

        const valorOrcado = document.getElementById("ValorOrcado");
        const valorBruto = document.getElementById("ValorBruto");
        const valorCobrado = document.getElementById("ValorCobrado");

        valorHora.classList.remove('is-valid');
        quantidade.classList.remove('is-valid');

        if (valorHora.value === "" || quantidade.value === "") 
        {
            valorHora.classList.remove('is-invalid');
            quantidade.classList.remove('is-invalid');

            Mensagens.Erro("Preencha os campos de valor orçado e quantidade de horas.");
            return;
        }
        const valorHoraCalc = parseFloat(valorHora.value.toString().replace(',', '.'));
        const totalHorasCalc = parseFloat(quantidade.value.toString().replace(',', '.'));
        const valorOrcadoCalc = valorHoraCalc * totalHorasCalc

        valorOrcado.value = valorOrcadoCalc.toFixed(2).toString().replace('.', ',');
        valorBruto.value = valorOrcadoCalc.toFixed(2).toString().replace('.', ',');
        valorCobrado.value = valorOrcadoCalc.toFixed(2).toString().replace('.', ',');

        return;
    },
    validateInputs: function (clienteId, nome, valorOrcado, valorHora, totalHoras, valorBruto, valorCobrado, dataInicio, dataFim)
    {
        var valid = true;
        var mensagem = "";

        clienteId.classList.remove('is-invalid');
        nome.classList.remove('is-invalid');
        valorOrcado.classList.remove('is-invalid');
        valorHora.classList.remove('is-invalid');
        totalHoras.classList.remove('is-invalid');
        valorBruto.classList.remove('is-invalid');
        valorCobrado.classList.remove('is-invalid');
        dataInicio.classList.remove('is-invalid');
        dataFim.classList.remove('is-invalid');
        //clienteId.classList.remove('is-valid');
        //nome.classList.remove('is-valid');
        //valorOrcado.classList.remove('is-valid');
        //valorHora.classList.remove('is-valid');
        //totalHoras.classList.remove('is-valid');
        //valorBruto.classList.remove('is-valid');
        //valorCobrado.classList.remove('is-valid');
        //dataInicio.classList.remove('is-valid');
        //dataFim.classList.remove('is-valid');

        if (clienteId.value === '0')
        {
            mensagem += "Selecione um Cliente!<br />";
            clienteId.classList.add('is-invalid');
            valid = false;
        }
        if (nome.value === '')
        {
            mensagem += "Selecione um Nome!<br />";
            nome.classList.add('is-invalid');
            valid = false;
        }
        if (valorOrcado.value === '0' || valorOrcado.value === '')
        {
            mensagem += "Selecione um Valor Orçado!<br />";
            valorOrcado.classList.add('is-invalid');
            valid = false;
        }
        if (valorHora.value === '0' || totalHoras.value === '')
        {
            mensagem += "Selecione Valor Hora!<br />";
            valorHora.classList.add('is-invalid');
            valid = false;
        }
        if (totalHoras.value === '0' || totalHoras.value === '')
        {
            mensagem += "Selecione Total de Horas!<br />";
            totalHoras.classList.add('is-invalid');
            valid = false;
        }
        if (valorBruto.value === '0' || valorBruto.value === '')
        {
            mensagem += "Selecione um Valor Bruto!<br />";
            valorBruto.classList.add('is-invalid');
            valid = false;
        }
        if (valorCobrado.value === '0' || valorCobrado.value === '')
        {
            mensagem += "Selecione um Valor Cobrado!<br />";
            valorCobrado.classList.add('is-invalid');
            valid = false;
        }

        if (dataInicio.value === '01/01/0001' || dataInicio.value === '')
        {
            mensagem += "Selecione uma Data de Início Válida!<br />";
            dataInicio.classList.add('is-invalid');
            valid = false;
        }
        if (dataFim.value === '01/01/0001' || dataFim.value === '')
        {
            mensagem += "Selecione uma Data de Fim Válida!<br />";
            dataFim.classList.add('is-invalid');
            valid = false;
        }
        if (valid)
        {
            clienteId.classList.add('is-invalid');
            nome.classList.add('is-valid');
            valorOrcado.classList.add('is-valid');
            valorHora.classList.add('is-valid');
            totalHoras.classList.add('is-valid');
            valorBruto.classList.add('is-valid');
            valorCobrado.classList.add('is-valid');
            dataInicio.classList.add('is-valid');
            dataFim.classList.add('is-valid');
        }
        else
        {
            Mensagens.Erro(mensagem, "Erro.");
        }

        return valid;

    },
    gravar: function ()
    {
        const tarefaId = document.getElementById("TarefaId");
        const clienteId = document.getElementById("ClienteId");
        const notaFiscalId = document.getElementById("NotaFiscalId");
        const nome = document.getElementById("Nome");
        const observacao = document.getElementById("Observacao");
        const valorOrcado = document.getElementById("ValorOrcado");
        const valorHora = document.getElementById("ValorHora");
        const totalHoras = document.getElementById("TotalHoras");
        const valorDesconto = document.getElementById("ValorDesconto");
        const valorBruto = document.getElementById("ValorBruto");
        const valorCobrado = document.getElementById("ValorCobrado");
        const comissao = document.getElementById("Comissao");
        const dataInicio = document.getElementById("DataInicio");
        const dataFim = document.getElementById("DataFim");
        const gerarItems = document.getElementById("GerarItems");

        var dadosValidate = Tarefa.validateInputs(clienteId, nome, valorOrcado, valorHora, totalHoras, valorBruto, valorCobrado, dataInicio, dataFim)
        if (!dadosValidate)
        {
            return;
        }

        if (valorDesconto.value === '')
        {
            valorDesconto.value = '0,00';
        }

        if (comissao.value === '')
        {
            comissao.value = '0,00';
        }

        const token = $('input[name="__RequestVerificationToken"]').val();

        const gerarItemsValue = gerarItems.checked ? true : false;

        const clienteIds = parseInt(clienteId.value.toString());
        var notaFiscalIds = parseInt(notaFiscalId.value.toString());
        if (notaFiscalId.value.toString() === '')
        {
            notaFiscalIds = 0;
        }
        const valorHoras = parseFloat(valorHora.value.toString().replace(',', '.'));
        const valorOrcados = parseFloat(valorOrcado.value.toString().replace(',', '.'));
        const totalHorass = parseFloat(totalHoras.value.toString().replace(',', '.'));
        const valorDescontos = parseFloat(valorDesconto.value.toString().replace(',', '.'));
        const valorBrutos = parseFloat(valorBruto.value.toString().replace(',', '.'));
        const valorCobrados = parseFloat(valorCobrado.value.toString().replace(',', '.'));
        const comissaos = parseFloat(comissao.value.toString().replace(',', '.'));

        const opcoes = {
            url: "/Tarefa/Gravar/",
            headers: {
                "__RequestVerificationToken": token
            },
            type: "POST",
            dadoEnvio: {
                TarefaId: tarefaId.value, 
                ClienteId: clienteIds,
                NotaFiscalId: notaFiscalIds,
                Nome: nome.value,
                Observacao: observacao.value,
                ValorOrcado: valorOrcados,
                TotalHoras: totalHorass,
                ValorDesconto: valorDescontos,
                ValorBruto: valorBrutos,
                ValorHora: valorHoras,
                ValorCobrado: valorCobrados,
                Comissao: comissaos,
                DataInicio: dataInicio.value,
                DataFim: dataFim.value,
                GerarItems: gerarItemsValue
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

    }
}
