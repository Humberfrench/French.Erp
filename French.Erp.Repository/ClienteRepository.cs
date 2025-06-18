using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository, IBaseRepository<Cliente>
    {
        public ClienteRepository(IMyContextManager<ThisDatabase<Cliente>> context) : base(context)
        {

        }

        public new async Task<IEnumerable<Cliente>> ObterTodos()
        {
            //var resultado = this.DbSet.Select(c => new
            //    {
            //        c.ClienteId,
            //        c.Nome,
            //        c.RazaoSocial,
            //        c.Documento,
            //        c.TipoDeClienteId,
            //        c.TipoDePessoaId,
            //        c.Telefone,
            //        c.Contato,
            //        c.Email,
            //        c.InscricaoEstadual,
            //        c.CadastroMunicipal,
            //        c.Endereco,
            //        c.Numero,
            //        c.Complemento,
            //        c.Bairro,
            //        c.Cep,
            //        c.UsuarioId,
            //        c.EstadoId,
            //        c.CidadeId,
            //        Tarefas = c.Tarefa.Select(t => new
            //        {
            //            t.TarefaId,
            //            t.ClienteId,
            //            t.NotaFiscalId,
            //            t.Nome,
            //            t.Observacao,
            //            t.ValorOrcado,
            //            t.TotalHoras,
            //            t.ValorDesconto,
            //            t.ValorBruto,
            //            t.ValorHora,
            //            t.ValorCobrado,
            //            t.Comissao,
            //            t.DataInicio,
            //            t.DataFim,
            //            Itens = t.TarefaItem.Select(ti => new // Projeção dos TarefaItem
            //            {
            //                ti.TarefaItemId,
            //                ti.TarefaId,
            //                ti.Ordem,
            //                ti.Descricao,
            //                ti.ServicoId,
            //                ti.Data,
            //                ti.HorasOrcadas,
            //                ti.HorasGastas,
            //                ti.ValorHora,
            //                ti.ValorItem,                            
            //            }).ToList()
            //        }).ToList(),
            //        NotaFiscal = c.NotaFiscal,
            //        Faturamento = c.Faturamento,
            //        Cidade = c.Cidade,
            //        TipoDeCliente = c.TipoDeCliente,
            //        TipoDePessoa = c.TipoDePessoa
            //    }).ToListAsync();

            //return await resultado.Result;

            try
            {
                return await Task.Run(() => this.DbSet.Include(c => c.Tarefas)
                                                      .Include(c => c.NotaFiscals)
                                                      .Include(c => c.Faturamentos)
                                                      .Include(c => c.Cidade)
                                                      .Include(c => c.TipoDeCliente)
                                                      .Include(c => c.TipoDePessoa)
                                                      .ToList());

            }
            catch (Exception ex)
            {

                var err = ex.Message;
                return null;
            }
        }

        public new async Task<Cliente> ObterPorId(int id)
        {

            return await Task.Run(() => this.DbSet.Include(c => c.TipoDeCliente)
                                                  .Include(c => c.TipoDePessoa)
                                                  .Include(c => c.Tarefas)
                                                  .Include(c => c.NotaFiscals)
                                                  .Include(c => c.Faturamentos)
                                                  .Include(c => c.Cidade)
                                                  .FirstOrDefaultAsync(c => c.ClienteId == id));
        }

    }
}
