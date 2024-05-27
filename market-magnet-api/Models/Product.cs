namespace market_magnet_api.Models
{
    public class Product

    {
        public Product(string codigo, string referencias, string codigosBarras, string descricao, string unidadeMedida, decimal valorCusto, decimal markup, decimal valorVenda, decimal quantidadeEstoque, string userId)
        {
            _id = Guid.NewGuid().ToString();
            Codigo = codigo;
            Referencias = referencias;
            CodigosBarras = codigosBarras;
            Descricao = descricao;
            UnidadeMedida = unidadeMedida;
            ValorCusto = valorCusto;
            Markup = markup;
            ValorVenda = valorVenda;
            QuantidadeEstoque = quantidadeEstoque;
            UserId = userId;
        }

        public string _id { get; set; }
        public string Codigo { get; set; }
        public string Referencias { get; set; }
        public string CodigosBarras { get; set; }
        public string Descricao { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal Markup { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal QuantidadeEstoque { get; set; }
        public string UserId { get; set; }

    }
}
