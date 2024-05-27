namespace market_magnet_api.Models
{
    public class User
    {
        public User(string name, string email, string password)
        {
            _id = Guid.NewGuid().ToString();
            Name = name;
            Email = email;
            Password = password;
        }

        public string _id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ?RefreshToken { get; set; }
        public DateTime ?RefreshTokenExpiryTime { get; set; }
    }

}