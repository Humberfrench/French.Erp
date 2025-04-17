using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.Lead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace French.Erp.Domain.Entities
{
    [Table("Lead")]
    public partial class Lead
    {
        private readonly Validation.ValidationResult validationResult;
        private bool isValid;

        public Lead()
        {
            validationResult = new Validation.ValidationResult();
            isValid = false;
            Descricao = string.Empty;
            Empresa = string.Empty;
            Contato = string.Empty;
            Documento = string.Empty;
            Telefone = string.Empty;
            Email = string.Empty;
            Efetivada = false;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeadId { get; set; }

        public string Descricao { get; set; }

        public string Empresa { get; set; }

        public string Contato { get; set; }

        public string Documento { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public int UsuarioId { get; set; }

        public bool Efetivada { get; set; }

        public byte TipoDePessoaId { get; set; }

        public byte TipoDeClienteId { get; set; }

        #region De Lead para Cliente
        public  Cliente ToCliente()
        {
            var cliente = new Cliente
            {
                UsuarioId = UsuarioId,
                Nome = Empresa,
                RazaoSocial = Empresa,
                Contato = Contato,
                Documento = Documento,
                Telefone = Telefone,
                Email = Email,
                TipoDePessoaId = TipoDePessoaId,
                TipoDeClienteId = TipoDeClienteId,
                DataCriacao = DataDeCriacao,
                DataAlteracao = DateTime.Now
            };
            return cliente;
        }
        public Cliente ToCliente(string razaoSocial, string inscricaoEstadual = "", string cadastroMunicipal = "",
                                 string endereco = "", string numero = "", string bairro = "", string complemento = "", 
                                 int cidadeId = 0, int estadoId = 0, string cep = "")
        {
            var cliente = ToCliente();
            cliente.RazaoSocial = razaoSocial;
            cliente.InscricaoEstadual = inscricaoEstadual;
            cliente.CadastroMunicipal = cadastroMunicipal;
            cliente.Endereco = endereco;
            cliente.Numero = numero;
            cliente.Bairro = bairro;
            cliente.Complemento = complemento;
            cliente.CidadeId = cidadeId;
            cliente.EstadoId = estadoId;
            cliente.Cep = cep;

            return cliente;

        }
        #endregion

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

        public virtual Validation.ValidationResult Validar(Lead entity)
        {
            var entidadeNomeValidate = new LeadEstaConsistente();
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
