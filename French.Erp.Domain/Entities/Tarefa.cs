using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.TipoDePessoas;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using French.Erp.Domain.Validations.Tarefas;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("Tarefa")]
    public partial class Tarefa
    {
        private readonly Validation.ValidationResult validationResult;
        private bool isValid;

        public Tarefa()
        {
            validationResult = new Validation.ValidationResult();
            isValid = false;
            ComposicaoNotaFiscal = new HashSet<ComposicaoNotaFiscal>();
            TarefaItem = new HashSet<TarefaItem>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TarefaId { get; set; }
        public int ClienteId { get; set; }
        public int? NotaFiscalId { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public decimal? ValorOrcado { get; set; }
        public decimal? TotalHoras { get; set; }
        public decimal? ValorHora { get; set; }
        public decimal? ValorCobrado { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorBruto { get; set; }
        public decimal? Comissao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int UsuarioId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ComposicaoNotaFiscal> ComposicaoNotaFiscal { get; set; }
        public virtual ICollection<TarefaItem> TarefaItem { get; set; }

        #region Dados de Validação
        public virtual Validation.ValidationResult ValidationResult => validationResult;

        public virtual bool IsValid()
        {
            if (!isValid)
            {
                var validationDados = Validar(this);
                if (!validationDados.Valid)
                {
                    validationDados.Erros.ToList().ForEach(e => validationResult.Add(e));
                }
                return validationResult.Valid;
            }
            return isValid;

        }

        public virtual Validation.ValidationResult Validar(Tarefa entity)
        {
            var entidadeNomeValidate = new TarefaEstaConsistente();
            var validationResultEntidade = entidadeNomeValidate.Validar(entity);
            isValid = validationResultEntidade.Valid;
            if (!validationResultEntidade.Valid)
            {
                validationResultEntidade.Erros.ToList().ForEach(e => validationResult.Add(e));
            }

            return validationResult;
        }

        #endregion

    }
}