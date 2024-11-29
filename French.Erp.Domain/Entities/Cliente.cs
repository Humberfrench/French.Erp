﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace French.Erp.Domain.Entities
{
    public partial class Cliente
    {
        private readonly ValidationResult validationResult;
        private bool? isValid;

        public Cliente()
        {
            validationResult = new ValidationResult();
            isValid = null;
            Faturamento = new List<Faturamento>();
            NotaFiscal = new List<NotaFiscal>();
            Tarefa = new List<Tarefa>();
        }

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Documento { get; set; }
        public byte TipoDeClienteId { get; set; }
        public byte TipoDePessoaId { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CadastroMunicipal { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int UsuarioId { get; set; }
        public int? EstadoId { get; set; }
        public int? CidadeId { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual TipoDeCliente TipoDeCliente { get; set; }
        public virtual TipoDePessoa TipoDePessoa { get; set; }
        public virtual IList<Faturamento> Faturamento { get; set; }
        public virtual IList<NotaFiscal> NotaFiscal { get; set; }
        public virtual IList<Tarefa> Tarefa { get; set; }

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

        public virtual ValidationResult Validar(Cliente entity)
        {
            var entidadeNomeValidate = new ClienteEstaConsistente();
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