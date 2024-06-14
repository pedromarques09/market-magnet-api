namespace market_magnet_api.Models
{
    public class PaymentCondition
    {
        public PaymentCondition(
            string descricao,
            int numeroParcela,
            int diasEntrada,
            int diasIntervalo,
            string userId
        )
        {
            _id = Guid.NewGuid().ToString();
            Descricao = descricao;
            NumeroParcela = numeroParcela;
            DiasEntrada = diasEntrada;
            DiasIntervalo = diasIntervalo;
            UserId = userId;
        }

        public string _id { get; set; }
        public string Descricao { get; set; }
        public int NumeroParcela { get; set; }
        public int DiasEntrada { get; set; }
        public int DiasIntervalo { get; set; }
        public string UserId { get; set; }
    }
}
