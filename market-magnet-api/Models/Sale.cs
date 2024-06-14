namespace market_magnet_api.Models
{
    public class Sale
    {
        public Sale(
            int codigo,
            string idCliente,
            DateTime dataEmissao,
            string status,
            string titulo,
            string dadosAdicionais,
            string idEspecie,
            string idCondicao,
            decimal valorDesconto,
            decimal valorFrete,
            decimal valorOutrasDespesas,
            decimal valorTotal,
            List<Item> itens,
            List<Installment> parcelas,
            string userId
        )
        {
            _id = Guid.NewGuid().ToString();
            Codigo = codigo;
            IdCliente = idCliente;
            DataEmissao = dataEmissao;
            Status = status;
            Titulo = titulo;
            DadosAdicionais = dadosAdicionais;
            IdEspecie = idEspecie;
            IdCondicao = idCondicao;
            ValorDesconto = valorDesconto;
            ValorFrete = valorFrete;
            ValorOutrasDespesas = valorOutrasDespesas;
            ValorTotal = valorTotal;
            Itens = itens;
            UserId = userId;
            Parcelas = parcelas;
        }
        public string _id { get; set; }
        public int Codigo { get; set; }
        public string IdCliente { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Status { get; set; }
        public string Titulo { get; set; }
        public string DadosAdicionais { get; set; }
        public string IdEspecie { get; set; }
        public string IdCondicao { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorOutrasDespesas { get; set; }
        public decimal ValorTotal { get; set; }
        public List<Item> Itens { get; set; }
        public List<Installment> Parcelas { get; set; }
        public string UserId { get; set; }
    }
}
