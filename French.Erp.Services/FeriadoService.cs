using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class FeriadoService : IFeriadoService
    {
        private readonly IFeriadoRepository feriadoRepository;
        private readonly ValidationResult validationResult;

        public FeriadoService(IFeriadoRepository feriadoRepository)
        {
            this.feriadoRepository = feriadoRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var feriados = await feriadoRepository.ObterPorId(id);

            if (feriados == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            await feriadoRepository.Remover(feriados);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(FeriadoDto feriadoDados)
        {
            //add or update
            if (feriadoDados.FeriadoId == 0)
            {
                var feriados = new Feriado()
                {
                    FeriadoId = feriadoDados.FeriadoId,
                    Nome = feriadoDados.Nome,
                    Ano = feriadoDados.Ano,
                    Dia = feriadoDados.Dia,
                    Mes = feriadoDados.Mes,
                    CidadeId = feriadoDados.CidadeId,
                    EstadoId = feriadoDados.EstadoId,                    
                };

                //validate
                if (!feriados.IsValid())
                {
                    return feriados.ValidationResult;
                }

                await feriadoRepository.Adicionar(feriados);
            }
            else
            {
                var feriados = await feriadoRepository.ObterPorId(feriadoDados.FeriadoId);
                feriados.Nome = feriadoDados.Nome;
                feriados.Ano = feriadoDados.Ano;
                feriados.Dia = feriadoDados.Dia;
                feriados.Mes = feriadoDados.Mes;
                feriados.CidadeId = feriadoDados.CidadeId;
                feriados.EstadoId = feriadoDados.EstadoId;

                //validate
                if (!feriados.IsValid())
                {
                    return feriados.ValidationResult;
                }

                await feriadoRepository.Atualizar(feriados);
            }

            return validationResult;
        }

        public async Task<FeriadoDto> ObterPorId(int id)
        {
            var feriados = await feriadoRepository.ObterPorId(id);

            return feriados.ConvertObjects<FeriadoDto>();
        }

        public async Task<List<FeriadoDto>> ObterTodos()
        {
            var feriados = await feriadoRepository.ObterTodos();

            return feriados.ConvertObjects<List<FeriadoDto>>();
        }

        //Obter TODOS, FIXOS, MOVEIS, LOCAIS
        public async Task<List<FeriadoDto>> ObterFixos()
        {
            var feriados = (await feriadoRepository.ObterTodos()).Where(f =>
                                                    f.EstadoId == 0 &&
                                                    f.CidadeId == 0 &&
                                                    f.Ano == 0).ToList();

            
            return feriados.ConvertObjects<List<FeriadoDto>>();
        }

        public async Task<List<FeriadoDto>> ObterMoveis(int ano = 0)
        {
            if(ano == 0)
            {
                ano = DateTime.Now.Year;
            }
            var feriados = (await feriadoRepository.ObterTodos()).Where(f =>
                                                    f.Ano == ano).ToList();

            
            return feriados.ConvertObjects<List<FeriadoDto>>();
        }
        
        public async Task<List<FeriadoDto>> ObterLocais()
        {
            var feriados = (await feriadoRepository.ObterTodos()).Where(f =>
                                                    f.EstadoId > 0 &&
                                                    f.CidadeId >= 0 &&
                                                    f.Ano == 0).ToList();

            
            return feriados.ConvertObjects<List<FeriadoDto>>();
        }



    }
}
