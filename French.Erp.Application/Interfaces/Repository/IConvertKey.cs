using French.Erp.Domain.Entities.Support;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface IConvertKey
    {
        Chave Decript(byte[] chave);
        Chave Encript(string chave);
    }
}
