using Poc.EntityFrameworkCore.Console.Domains;

namespace Poc.EntityFrameworkCore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            InserirProdutos();
            
        }

        public static void InserirProdutos()
        {
            var produtos = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567890",
                Valor = 10m,
                TipoProduto = ValueObjects.TipoProduto.Embalagem,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();
            db.Set<Produto>().Add(produtos);

            var registros = db.SaveChanges();
        }
    }
}
