using Poc.EntityFrameworkCore.Console.Data;
using Poc.EntityFrameworkCore.Console.Domains;
using Poc.EntityFrameworkCore.Console.ValueObjects;
using console = System;

namespace Poc.EntityFrameworkCore.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            InserirDados();
            InserirDadosEmMassa();
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

            var db = new ApplicationContext();
            db.AddRange(produtos, cliente);
            var registros = db.SaveChanges();
            console.Console.WriteLine($"Total registros {registros}");
        }
    }
}
