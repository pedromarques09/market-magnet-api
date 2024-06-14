namespace market_magnet_api.Models
{
    public class Payload

    {
        public Payload(
                 List<Item> itens, bool isIncrement)
        {
            Itens = itens;
            IsIncrement = isIncrement;
        }
        public List<Item> Itens { get; set; }
        public bool IsIncrement { get; set; }
    }
}
