namespace market_magnet_api.Models
{
    public class Customer
    {
        public Customer(string userId, int codigo, string cpfCnpj, string rgIe, string tipoPessoa, string nomeRazaoSocial, string apelidoNomeFantasia, Adress ?endereco)
        {
            _id = Guid.NewGuid().ToString();
            Codigo = codigo;
            CpfCnpj = cpfCnpj;
            RgIe = rgIe;
            TipoPessoa = tipoPessoa;
            NomeRazaoSocial = nomeRazaoSocial;
            ApelidoNomeFantasia = apelidoNomeFantasia;
            Endereco = endereco;
            UserId = userId;
        }
        public string _id { get; set; }
        public int Codigo { get; set; }
        public string CpfCnpj { get; set; }
        public string RgIe { get; set; }
        public string TipoPessoa { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string ApelidoNomeFantasia { get; set; }
        public Adress ?Endereco { get; set; }
        public string UserId { get; set; }

    }
}
