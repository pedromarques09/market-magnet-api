namespace market_magnet_api.Models
{
    public class Installment
    {
        public Installment( 
            string dataVencimento,
            int numeroParcela,
            decimal valorParcela
        )
        {
            DataVencimento = dataVencimento;
            NumeroParcela = numeroParcela;
            ValorParcela = valorParcela;
        }
        public string DataVencimento { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
    }
}
