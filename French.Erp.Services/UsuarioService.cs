using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository repository;
        //private readonly ValidationResult<Usuario> typedResult;
        private readonly ValidationResult<Usuario> validationResult;
        private readonly IConvertKey convertKey;

        public UsuarioService(IBaseRepository<Usuario> baseRepository,
                              IUsuarioRepository repository,
                              IConvertKey convertKey) : base(baseRepository)
        {
            this.repository = repository;
            this.convertKey = convertKey;
            validationResult = new ValidationResult<Usuario>();

        }

        public async Task<ValidationResult<Usuario>> Excluir(int id)
        {
            var usuario = await ObterPorId(id);
            if (usuario == null)
            {
                validationResult.Add("Usuario inexistente.");
                return validationResult;
            }

            await base.Remover(usuario);

            return validationResult;
        }

        public async Task<ValidationResult<Usuario>> Gravar(Usuario usuario)
        {
            //validate
            if (!usuario.IsValid())
            {
                validationResult.GetErros(usuario.ValidationResult.Erros);
                return validationResult;
            }

            //add or update
            if (usuario.UsuarioId == 0)
            {
                //just add
                usuario.Senha = convertKey.Encript(usuario.SenhaText).ChaveEncript;
                await base.Adicionar(usuario);
            }
            else
            {
                //recuperar user:
                var user = await base.ObterPorId(usuario.UsuarioId);
                if (user == null)
                {
                    validationResult.Add("Usuario inexistente.");
                    return validationResult;
                }

                user.Nome = usuario.Nome;
                user.Login = usuario.Login;
                user.Email = usuario.Email;
                user.Celular = usuario.Celular;
                user.DataAtualizacao = DateTime.Now;
                user.Admin = user.Admin;

                await base.Atualizar(user);
            }

            return validationResult;
        }

        public async Task<ValidationResult<Usuario>> AlterarSenha(int usuarioId, string senhaAnterior, string senhaNova)
        {
            var usuario = await ObterPorId(usuarioId);

            if (usuario == null)
            {
                validationResult.Add("Usuario inexistente.");
                return validationResult;
            }

            usuario.Senha = convertKey.Encript(senhaNova).ChaveEncript;
            usuario.DataAtualizacao = DateTime.Now;
            usuario.ValidadeSenha = DateTime.Now.AddDays(90);

            await base.Atualizar(usuario);

            return validationResult;

        }
        public async Task<ValidationResult<Usuario>> Login(string login, string senha)
        {
            var usuario = await repository.ObterUsuarioPorLogin(login);

            var senhaBanco = convertKey.Decript(usuario.Senha).ChaveDecript;

            if (senha != senhaBanco)
            {
                validationResult.Add("Usuário ou senha inválidos");
                validationResult.Retorno = new Usuario
                {
                    Login = login,
                };
                return validationResult;
            }
            validationResult.Retorno = usuario;
            return validationResult;
        }
    }
}
