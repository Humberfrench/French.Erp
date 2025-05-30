﻿using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.DataObject
{
    public partial class ClienteDto
    {
        public ClienteDto()
        {
            Faturamento = new List<FaturamentoDto>();
            NotaFiscal = new List<NotaFiscalDto>();
            Tarefa = new List<TarefaDto>();
        }

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Documento { get; set; }
        public byte TipoDeClienteId { get; set; }
        public byte TipoDePessoaId { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CadastroMunicipal { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int UsuarioId { get; set; }
        public int? EstadoId { get; set; }
        public int? CidadeId { get; set; }

        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual CidadeDto Cidade { get; set; }
        public virtual TipoDeClienteDto TipoDeCliente { get; set; }
        public virtual TipoDePessoaDto TipoDePessoa { get; set; }
        public virtual IList<FaturamentoDto> Faturamento { get; set; }
        public virtual IList<NotaFiscalDto> NotaFiscal { get; set; }
        public virtual IList<TarefaDto> Tarefa { get; set; }
    }
}