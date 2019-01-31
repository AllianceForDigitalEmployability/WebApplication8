namespace WebApplication7.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; private set; }
        public string password { get; private set; }
    }

}