namespace Poc.EntityFrameworkCore.Console.ValueObjects
{
    public enum TipoFrete
    {
        CIF, //remetente paga o frete
        FOB, //destinatário paga o frete
        SemFrete, //cliente vai até à loja
    }
}
