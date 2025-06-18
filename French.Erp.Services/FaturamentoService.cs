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
    public class FaturamentoService : IFaturamentoService
    {
        private readonly IFaturamentoRepository faturamentoRepository;
        private readonly ValidationResult validationResult;

        public FaturamentoService(IFaturamentoRepository faturamentoRepository)
        {
            this.faturamentoRepository = faturamentoRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var faturamento = await faturamentoRepository.ObterPorId(id);

            if (faturamento == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            await faturamentoRepository.Remover(faturamento);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(FaturamentoDto faturamentoDados)
        {
            //add or update
            if (faturamentoDados.FaturamentoId == 0)
            {
                var faturamento = new Faturamento()
                {
                    Mes = faturamentoDados.Mes,
                    Ano = faturamentoDados.Ano,
                    ClienteId = faturamentoDados.ClienteId,
                    Valor = faturamentoDados.Valor,
                    UsuarioId = faturamentoDados.UsuarioId,
                    Faturado = faturamentoDados.Faturado
                };

                //validate
                if (!faturamento.IsValid())
                {
                    return faturamento.ValidationResult;
                }

                await faturamentoRepository.Adicionar(faturamento);
            }
            else
            {
                var faturamento = await faturamentoRepository.ObterPorId(faturamentoDados.FaturamentoId);
                faturamento.Mes = faturamentoDados.Mes;
                faturamento.Ano = faturamentoDados.Ano;
                faturamento.ClienteId = faturamentoDados.ClienteId;
                faturamento.Valor = faturamentoDados.Valor;
                faturamento.UsuarioId = faturamentoDados.UsuarioId;
                faturamento.Faturado = faturamentoDados.Faturado;

                //validate
                if (!faturamento.IsValid())
                {
                    return faturamento.ValidationResult;
                }

                await faturamentoRepository.Atualizar(faturamento);
            }

            return validationResult;
        }

        public async Task<FaturamentoDto> ObterPorId(int id)
        {
            var clientes = await faturamentoRepository.ObterPorId(id);

            return clientes.ConvertObjects<FaturamentoDto>();
        }

        public async Task<List<FaturamentoDadosDto>> Obter(int usuario, int cliente = 0, int mes = 0, int ano = 0, bool faturado = true)
        {
            var clientes = await faturamentoRepository.Obter(usuario, cliente, mes, ano, faturado);

            return clientes;
        }
    }
}
