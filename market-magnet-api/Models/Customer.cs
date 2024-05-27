namespace market_magnet_api.Models
{
    public class Customer
    {
        public Customer(string userID, string codigo, string cpfCnpj, string rgIe, string tipoPessoa, string nomeRazaoSocial, string apelidoNomeFantasia, Adress endereco)
        {
            _id = Guid.NewGuid().ToString();
            Codigo = codigo;
            CpfCnpj = cpfCnpj;
            RgIe = rgIe;
            TipoPessoa = tipoPessoa;
            NomeRazaoSocial = nomeRazaoSocial;
            ApelidoNomeFantasia = apelidoNomeFantasia;
            Endereco = endereco;
            UserId = userID;
        }
        public string _id { get; set; }
        public string Codigo { get; set; }
        public string CpfCnpj { get; set; }
        public string RgIe { get; set; }
        public string TipoPessoa { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string ApelidoNomeFantasia { get; set; }
        public Adress Endereco { get; set; }
        public string UserId { get; set; }

    }
}
