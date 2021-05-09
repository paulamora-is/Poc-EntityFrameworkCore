using Poc.EntityFrameworkCore.Console.Data;
using Poc.EntityFrameworkCore.Console.Domains;
using Poc.EntityFrameworkCore.Console.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Poc.EntityFrameworkCore.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            InserirDados();
            InserirDadosEmMassa();
            ConsultarDados();
            CasdastrarPedido();
            CarregarProdutoAdiantado();
            AtualizarDado();
            RemoverRegistro();
        }
        private static void RemoverRegistro()
        {
            using var db = new ApplicationContext();
            //var cliente = db.Clientes.Find(2); //primeiro  localiza o registro pra depois executar o comando de deletar
            var cliente = new Cliente { Id = 3 }; //nesse caso, o EFC faz somente uma interação na bd que é o de deletar
            //db.Clientes.Remove(cliente); //uma forma de remover
            db.Entry(cliente).State = EntityState.Deleted; //outra forma de remover
            //db.Remove(cliente); // outra forma de remover
            db.SaveChanges();
        }

        private static void AtualizarDado()
        {
            using var db = new ApplicationContext();
            //var cliente = db.Clientes.Find(1); //uma forma de buscar o id do cliente
            var cliente = new Cliente
            {
                Id = 1
            };
            var exemploClienteDesconectado = new
            {
                Nome = "Cliente Desconectado 2",
                Telefone = "99877896"
            };
            db.Attach(cliente); 
            db.Entry(cliente).CurrentValues.SetValues(exemploClienteDesconectado);
            //cliente.Nome = "Nome atualizado dois"; //uma forma de setar o valor no campo nome
            //db.Clientes.Update(cliente); //atualiza toda a tabela
            db.SaveChanges();
            
        }

        private static void CarregarProdutoAdiantado()
        {
            using var db = new ApplicationContext();
            var pedidos = db.Pedidos.Include(pedidos => pedidos.Itens)
                    .ThenInclude(p => p.Produto)
                .ToList();

            //Console.WriteLine(pedidos.Count);

        }
        private static void CasdastrarPedido()
        {
            using var db = new ApplicationContext();
            var cliente = db.Clientes.FirstOrDefault();
            var produto = db.Produtos.FirstOrDefault();
            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                TipoFrete = TipoFrete.FOB,
                Iniciado = DateTime.Now,
                Finalizado = DateTime.Now,
                Status = StatusPedido.Analise,
                Itens = new List<PedidoItem>
                {
                    new PedidoItem
                    {
                        ProdutoId = produto.Id,
                        Desconto = 0,
                        Quantidade = 2,
                        Valor = 10
                    }
                }
            };
            db.Add(pedido);
            db.SaveChanges();
        }

        private static void InserirDados()
        {
            var produtos = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567890",
                Valor = 10m,
                TipoProduto = TipoProduto.Embalagem,
                Ativo = true
            };

            using var db = new ApplicationContext();
            db.Set<Produto>().Add(produtos);

            var registros = db.SaveChanges();
        }

        private static void InserirDadosEmMassa()
        {
            var produtos = new Produto
            {
                Descricao = "Produto Teste2",
                CodigoBarras = "19856567890",
                Valor = 20m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var cliente = new Cliente
            {
                Nome = "Fulano",
                CEP = "11111111",
                Cidade = "São Paulo",
                Estado = "SP",
                Telefone = "9999999999"
            };

            var listaClientes = new[]
            {
               new Cliente
               {
                    Nome = "Teste1",
                    CEP = "22222222",
                    Cidade = "São Paulo",
                    Estado = "SP",
                    Telefone = "8888888888"
               },

               new Cliente
               {
                    Nome = "Teste2",
                    CEP = "33333333",
                    Cidade = "São Paulo",
                    Estado = "SP",
                    Telefone = "7777777777"
               }
            };

            using var db = new ApplicationContext();
            db.AddRange(produtos, cliente); //forma de adicionar tipos de objetos
            db.AddRange(listaClientes); 
            var registros = db.SaveChanges();
        }

        private static void ConsultarDados()
        {
            using var db = new ApplicationContext();
            var clientes = db.Clientes.Where(c => c.Id > 0)
                .OrderBy(c => c.Id)
                .ToList();
            foreach (var cliente in clientes)
            {
                //db.Clientes.Find(cliente.Id); //retornar registros em memória
                db.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
            };
          
               
        }
    }
}
