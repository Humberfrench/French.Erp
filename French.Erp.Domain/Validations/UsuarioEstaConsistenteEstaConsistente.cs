using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class UsuarioEstaConsistente : Validator<Usuario>
    {
        public UsuarioEstaConsistente()
        {
            var nomePreenchido = new PropriedadeStringPreenchida<Usuario>(f => f.Nome);
            var loginPreenchido = new PropriedadeStringPreenchida<Usuario>(f => f.Login);
            var emailPreenchido = new PropriedadeStringPreenchida<Usuario>(f => f.Email);
            var celularPreenchido = new PropriedadeStringPreenchida<Usuario>(f => f.Celular);
            var senhaPreenchido = new PropriedadeStringPreenchida<Usuario>(f => f.SenhaText);
            var emailValido = new PropriedadeEmailValido<Usuario>(f => f.Email);

            //implementação regras
            base.AdicionarRegra(nameof(nomePreenchido), new Rule<Entities.Usuario>(nomePreenchido, "Preencher o nome."));
            base.AdicionarRegra(nameof(loginPreenchido), new Rule<Entities.Usuario>(loginPreenchido, "Preencher o login."));
            base.AdicionarRegra(nameof(emailPreenchido), new Rule<Entities.Usuario>(emailPreenchido, "Preencher o e-mail."));
            base.AdicionarRegra(nameof(celularPreenchido), new Rule<Entities.Usuario>(celularPreenchido, "Preencher o celular."));
            base.AdicionarRegra(nameof(emailValido), new Rule<Entities.Usuario>(emailValido, "O e-mail é inválido."));
            base.AdicionarRegra(nameof(senhaPreenchido), new Rule<Entities.Usuario>(senhaPreenchido, "Preencher a senha."));
        }

    }
}
