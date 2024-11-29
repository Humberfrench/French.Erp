using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Application.ViewModel;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository notaFiscalRepository;
        private readonly ValidationResult validationResult;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository)
        {
            this.notaFiscalRepository = notaFiscalRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDePessoa = await notaFiscalRepository.ObterPorId(id);
            if (tipoDePessoa == null)
            {
                validationResult.Add(" da Nota Fiscal inexistente");
                return validationResult;
            }

            await notaFiscalRepository.Remover(tipoDePessoa);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(NotaFiscalDto notaFiscaldados)
        {
            var validationResult = new ValidationResult();
            //add or update
            if (notaFiscaldados.NotaFiscalId == 0)
            {
                var notafiscal = new NotaFiscal()
                {
                    Descricao = notaFiscaldados.Descricao
                };

                AtualizaNotaFiscal(notaFiscaldados, ref notafiscal);

                //validate
                //if (!notafiscal.IsValid())
                //{
                //    return notafiscal.ValidationResult;
                //}

                await notaFiscalRepository.Adicionar(notafiscal);
            }
            else
            {
                var notafiscal = await notaFiscalRepository.ObterPorId(notaFiscaldados.NotaFiscalId);

                AtualizaNotaFiscal(notaFiscaldados, ref notafiscal);

                //validate
                //if (!notafiscal.IsValid())
                //{
                //    return notafiscal.ValidationResult;
                //}

                await notaFiscalRepository.Atualizar(notafiscal);
            }

            return validationResult;
        }

        void AtualizaNotaFiscal(NotaFiscalDto notaFiscalDto, ref NotaFiscal notaFiscal)
        {
            notaFiscal.Data = notaFiscalDto.Data;
            notaFiscal.Numero = notaFiscalDto.Numero;
            notaFiscal.ClienteId = notaFiscalDto.ClienteId;
            notaFiscal.CodigoVerificacao = notaFiscalDto.CodigoVerificacao;
            notaFiscal.ImpostoTotalRetido = notaFiscalDto.ImpostoTotalRetido;
            notaFiscal.Valor = notaFiscalDto.Valor;
            notaFiscal.ValorLiquido = notaFiscalDto.ValorLiquido;
            notaFiscal.Descricao = notaFiscalDto.Descricao;
            notaFiscal.StatusNotaFiscalId = notaFiscalDto.StatusNotaFiscalId;
            notaFiscal.UsuarioId = notaFiscalDto.UsuarioId;
        }


        public async Task<NotaFiscalDto> ObterPorId(int id)
        {
            var notaFiscal = await notaFiscalRepository.ObterTodos();

            return notaFiscal.ConvertObjects<NotaFiscalDto>();

        }
        public async Task<List<NotaFiscalDto>> ObterTodos()
        {
            var notaFiscal = await notaFiscalRepository.ObterTodos();

            return notaFiscal.ConvertObjects<List<NotaFiscalDto>>();

        }

    }
}
