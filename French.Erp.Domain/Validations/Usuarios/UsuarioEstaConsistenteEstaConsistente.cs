using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications.Usuarios;

namespace French.Erp.Domain.Validations.Usuarios
{
    public class UsuarioEstaConsistente : Validator<Entities.Usuario>
    {
        public UsuarioEstaConsistente()
        {
            var nomePreenchido = new NomePreenchido();
            var loginPreenchido = new LoginPreenchido();
            var emailPreenchido = new EmailPreenchido();
            var celularPreenchido = new CelularPreenchido();
            var senhaPreenchido = new SenhaPreenchido();
            var emailValido = new EmailValido();

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
