using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.Usuarios;
using System;
using System.Linq;

namespace French.Erp.Domain.Entities
{
    public class Usuario
    {
        private readonly ValidationResult validationResult;
        private bool? isValid;

        public Usuario()
        {
            validationResult = new ValidationResult();
            isValid = null;
        }

        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public byte[] Senha { get; set; }
        public string SenhaText { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime ValidadeSenha { get; set; }
        public bool Admin { get; set; }
        public int TentativasInvalidas { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime? DataLogin { get; set; }
        public bool Ativo { get; set; }

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

        public virtual ValidationResult Validar(Usuario entity)
        {
            var entidadeNomeValidate = new UsuarioEstaConsistente();
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
