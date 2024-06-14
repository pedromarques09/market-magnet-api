namespace market_magnet_api.Models
{
    public class PaymentMethod
    {
        public PaymentMethod(string descricao, string userId)
        {
            _id = Guid.NewGuid().ToString();
            Descricao = descricao;
            UserId = userId;
        }

        public string _id { get; set; }
        public string Descricao { get; set; }
        public string UserId { get; set; }
    }
}
