using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ValidationResult<Usuario> validationResult1;
        private readonly IConvertKey convertKey;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              IConvertKey convertKey) 
        {
            this.usuarioRepository = usuarioRepository;
            this.convertKey = convertKey;
            validationResult1 = new ValidationResult<Usuario>();

        }

        public async Task<ValidationResult<bool>> Excluir(int id)
        {
            var validationResult = new ValidationResult<bool>();
            var usuario = await usuarioRepository.ObterPorId(id);
            if (usuario == null)
            {
                validationResult1.Add("Usuario inexistente.");
                return validationResult;
            }

            await usuarioRepository.Remover(usuario);

            return validationResult;
        }

        public async Task<ValidationResult<UsuarioDto>> Gravar(Usuario usuario)
        {
            var validationResult = new ValidationResult<UsuarioDto>();
            
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
                await usuarioRepository.Adicionar(usuario);
            }
            else
            {
                //recuperar user:
                var user = await usuarioRepository.ObterPorId(usuario.UsuarioId);
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

                await usuarioRepository.Atualizar(user);
            }

            validationResult.Retorno = AtualizaDadosUsuario(usuario);

            return validationResult;
        }

        public async Task<ValidationResult<UsuarioDto>> AlterarSenha(int usuarioId, string senhaAnterior, string senhaNova)
        {
            var validationResult = new ValidationResult<UsuarioDto>();
            var usuario = await usuarioRepository.ObterPorId(usuarioId);

            if (usuario == null)
            {
                validationResult.Add("Usuario inexistente.");
                validationResult.Retorno = new UsuarioDto
                {
                    UsuarioId = usuarioId,
                };
                return validationResult;
            }

            usuario.Senha = convertKey.Encript(senhaNova).ChaveEncript;
            usuario.DataAtualizacao = DateTime.Now;
            usuario.ValidadeSenha = DateTime.Now.AddDays(90);

            await usuarioRepository.Atualizar(usuario);

            validationResult.Retorno = AtualizaDadosUsuario(usuario);

            return validationResult;

        }
        public async Task<ValidationResult<UsuarioDto>> Login(string login, string senha)
        {
            var validationResult = new ValidationResult<UsuarioDto>();

            var usuario = await usuarioRepository.ObterUsuarioPorLogin(login);

            var senhaBanco = convertKey.Decript(usuario.Senha).ChaveDecript;

            if (senha != senhaBanco)
            {
                validationResult.Add("Usuário ou senha inválidos");
                validationResult.Retorno = new UsuarioDto
                {
                    Login = login,
                };
                return validationResult;
            }

            validationResult.Retorno = AtualizaDadosUsuario(usuario);

            return validationResult;
        }

        UsuarioDto AtualizaDadosUsuario(Usuario usuario)
        {
            return new UsuarioDto
            {
                Admin = usuario.Admin,
                Celular = usuario.Celular,
                ValidadeSenha = usuario.ValidadeSenha,
                Senha = usuario.SenhaText,
                DataAtualizacao = usuario.DataAtualizacao,
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Login = usuario.Login,
                Email = usuario.Email,
                DataCriacao = usuario.DataCriacao,
            };
        }

    }
}
