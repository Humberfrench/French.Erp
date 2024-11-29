using French.Erp.Domain.Entities.Support;

namespace French.Erp.Domain.Interfaces.Repository
{
    public interface IConvertKey
    {
        Chave Decript(byte[] chave);
        Chave Encript(string chave);
    }
}
