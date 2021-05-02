using Poc.EntityFrameworkCore.Console.ValueObjects;
using System;
using System.Collections.Generic;

namespace Poc.EntityFrameworkCore.Console.Domains
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Iniciado { get; set; }
        public DateTime Finalizado { get; set; }
        public TipoFrete TipoFrete { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public string Observacao { get; set; }
        public ICollection<PedidoItem> Itens { get; set; }
    }
}
