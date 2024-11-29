﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.StatusNotaFiscals;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace French.Erp.Domain.Entities
{
    public partial class StatusNotaFiscal
    {
        private readonly ValidationResult validationResult;
        private bool? isValid;

        public StatusNotaFiscal()
        {
            NotaFiscal = new HashSet<NotaFiscal>();
            validationResult = new ValidationResult();
            isValid = null;
        }

        public byte StatusNotaFiscalId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<NotaFiscal> NotaFiscal { get; set; }
        #region Dados de Validação
        public virtual ValidationResult ValidationResult => validationResult;

        public virtual bool IsValid()
        {
            if (!isValid.HasValue)
            {
                var validationDados = Validar(this);
                if (!validationDados.Valid)
                {
                    validationDados.Erros.ToList().ForEach(e => validationResult.Add(e));
                }
                return validationResult.Valid;
            }
            return isValid.Value;

        }

        public virtual ValidationResult Validar(StatusNotaFiscal entity)
        {
            var entidadeNomeValidate = new StatusNotaFiscalEstaConsistente();
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