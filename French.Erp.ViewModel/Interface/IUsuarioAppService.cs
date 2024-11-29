using Dietcode.Core.DomainValidator;
using French.Erp.ViewModel.ViewModel;

namespace French.Erp.ViewModel.Interface
{
    public interface IUsuarioAppService : IBaseApplication<UsuarioViewModel>
    {
        Task<ValidationResult<UsuarioViewModel>> Login(string login, string senha);
        Task<ValidationResult<UsuarioViewModel>> AlterarSenha(int usuarioId, string senhaAnterior, string senhaNova);
    }
}
