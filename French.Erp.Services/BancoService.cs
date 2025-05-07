using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository bancoRepository;
        private readonly ValidationResult validationResult;

        public BancoService(IBancoRepository bancoRepository)
        {
            this.bancoRepository = bancoRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var banco = await bancoRepository.ObterPorId(id);

            if (banco == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            await bancoRepository.Remover(banco);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(BancoDto bancoDados)
        {
            //add or update
            if (bancoDados.BancoId == 0)
            {
                var banco = new Banco()
                {
                    Codigo = bancoDados.Codigo,
                    Nome = bancoDados.Nome,
                    Status = bancoDados.Status,
                };

                //validate
                if (!banco.IsValid())
                {
                    return banco.ValidationResult;
                }

                await bancoRepository.Adicionar(banco);
            }
            else
            {
                var banco = await bancoRepository.ObterPorId(bancoDados.BancoId);
                banco.Codigo = bancoDados.Codigo;
                banco.Nome = bancoDados.Nome;

                //validate
                if (!banco.IsValid())
                {
                    return banco.ValidationResult;
                }

                await bancoRepository.Atualizar(banco);
            }

            return validationResult;
        }

        public async Task<BancoDto> ObterPorId(int id)
        {
            var bancos = await bancoRepository.ObterPorId(id);

            return bancos.ConvertObjects<BancoDto>();
        }

        public async Task<List<BancoDto>> ObterTodos()
        {
            var bancos = await bancoRepository.ObterTodos();

            return bancos.ConvertObjects<List<BancoDto>>();
        }

        public async Task<ValidationResult> AlterarStatus(int banco, bool status)
        {
            var bancos = await bancoRepository.ObterPorId(banco);
            if (bancos == null)
            {
                validationResult.Add("Banco inexistente");
                return validationResult;
            }

            bancos.Status = status;

            await bancoRepository.Atualizar(bancos);

            return validationResult;

        }
    }
}
