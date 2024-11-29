/// <reference path="../../js/ajax.js" />
/// <reference path="../../js/mensagens.js" />
var Tarefa = new function () { }


$(document).ready(function ()
{
    $("#Cliente").val($("#ClienteId").val());
    $("#Cliente").selectpicker('refresh');

    // new Task
    if ($("#TarefaId").val() === '0')
    {
        $("#ValorOrcado").val(id)
        $("#TotalHoras").val(id)
        $("#ValorHora").val(id)
        $("#ValorBruto").val(id)
        $("#ValorDesconto").val(id)
        $("#ValorCobrado").val(id)
        $("#Comissao").val(id)
    }


    $("#DataInicio").datepicker({
        language: "pt-BR",
        format: "dd/mm/yyyy",
        startDate: "01-01-1990",
        endDate: "31-12-2030",
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true,
        clearBtn: true,
        daysOfWeekHighlighted: "0,6"
    });

    $("#DataFim").datepicker({
        language: "pt-BR",
        format: "dd/mm/yyyy",
        startDate: "01-01-1990",
        endDate: "31-12-2030",
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true,
        clearBtn: true,
        daysOfWeekHighlighted: "0,6"
    });
});

$("#Cliente").change(function ()
{
    var id = $("#Cliente").val();
    $("#ClienteId").val(id)
});

Tarefa.CalcularValorOrcado = function ()
{
    var valorHora = parseFloat($("#ValorHora").val().toString().replace(',', '.'));
    var totalHoras = parseFloat($("#TotalHoras").val().toString().replace(',', '.'));

    var valorOrcado = valorHora * totalHoras
    $("#ValorOrcado").val(valorOrcado.toFixed(2).toString().replace('.', ','));

}

Tarefa.Gravar = function ()
{
    if ($("#ClienteId").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Cliente!", "Erro.");
        $("#Cliente").focus();
        return;
    }

    if ($("#Nome").val() === '')
    {
        Mensagens.Erro("Preencher o campo de Cliente!", "Erro.");
        $("#Cliente").focus();
        return;
    }

    $("#formTarefa").submit();
}

Tarefa.Voltar = function ()
{
    var idCliente = $("#ClienteId").val();

    location.href = '/Tarefa/' + idCliente;
}
