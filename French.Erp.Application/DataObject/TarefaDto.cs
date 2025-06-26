using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace French.Erp.Application.DataObject
{
    public class TarefaDto
    {
        [JsonPropertyName("tarefaId")]
        public int TarefaId { get; set; }

        [JsonPropertyName("clienteId")]
        public int ClienteId { get; set; }

        [JsonPropertyName("notaFiscalId")]
        public int? NotaFiscalId { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = string.Empty;

        [JsonPropertyName("observacao")]
        public string Observacao { get; set; } = string.Empty;

        [JsonPropertyName("valorOrcado")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? ValorOrcado { get; set; }

        [JsonPropertyName("totalHoras")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal TotalHoras { get; set; }

        [JsonPropertyName("valorDesconto")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? ValorDesconto { get; set; }

        [JsonPropertyName("valorBruto")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal ValorBruto { get; set; }

        [JsonPropertyName("valorHora")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal ValorHora { get; set; }

        [JsonPropertyName("valorCobrado")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal ValorCobrado { get; set; }

        [JsonPropertyName("comissao")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? Comissao { get; set; }

        [JsonPropertyName("dataInicio")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime DataInicio { get; set; }

        [JsonPropertyName("dataFim")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime DataFim { get; set; }

        [JsonPropertyName("gerarItems")]
        public bool GerarItems { get; set; }

        // Propriedades de navegação (ignoradas na serialização)
        [JsonIgnore]
        public virtual ClienteDto? Cliente { get; set; }

        [JsonIgnore]
        public virtual ICollection<ComposicaoNotaFiscalDto> ComposicaoNotaFiscal { get; set; } = new HashSet<ComposicaoNotaFiscalDto>();

        [JsonIgnore]
        public virtual ICollection<TarefaItemDto> TarefaItem { get; set; } = new HashSet<TarefaItemDto>();
    }

}

