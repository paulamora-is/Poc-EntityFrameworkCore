using Poc.EntityFrameworkCore.Console.Data;
using Poc.EntityFrameworkCore.Console.Domains;
using Poc.EntityFrameworkCore.Console.ValueObjects;
using System.Linq;
using console = System;

namespace Poc.EntityFrameworkCore.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            InserirDados();
            InserirDadosEmMassa();
            ConsultarDados();
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
            console.Console.WriteLine($"Total registros {registros}");
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

            var db = new ApplicationContext();
            db.AddRange(produtos, cliente); //forma de adicionar tipos de objetos
            db.AddRange(listaClientes); 
            var registros = db.SaveChanges();
            console.Console.WriteLine($"Total registros {registros}");
        }

        private static void ConsultarDados()
        {
            var db = new ApplicationContext();
            var clientes = db.Clientes.Where(c => c.Id > 0)
                .OrderBy(c => c.Id)
                .ToList();
            foreach (var cliente in clientes)
            {
                console.Console.WriteLine($"Consulta: {cliente.Id}");
                //db.Clientes.Find(cliente.Id); //retornar registros em memória
                db.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
            };
          
               
        }
    }
}
