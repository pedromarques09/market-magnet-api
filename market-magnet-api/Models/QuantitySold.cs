namespace market_magnet_api.Models
{
    public class QuantitySold
    {
        public QuantitySold(
                       string idProduto,
                                  int quantidade
                   )
        {
            IdProduto = idProduto;
            Quantidade = quantidade;
        }
        public string IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
