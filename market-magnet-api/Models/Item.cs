namespace market_magnet_api.Models
{
    public class Item
    {
        public Item(
            string idProduto,
            string descricao,
            int quantidade,
            string unidadeMedida,
            decimal valorDesconto,
            decimal valorOutrasDespesas,
            decimal valorFrete,
            decimal valorUnitario,
            decimal valorTotal
        )
        {
            IdProduto = idProduto;
            Descricao = descricao;
            Quantidade = quantidade;
            UnidadeMedida = unidadeMedida;
            ValorDesconto = valorDesconto;
            ValorOutrasDespesas = valorOutrasDespesas;
            ValorFrete = valorFrete;
            ValorUnitario = valorUnitario;
            ValorTotal = valorTotal;
        }

        public string IdProduto { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorOutrasDespesas { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
