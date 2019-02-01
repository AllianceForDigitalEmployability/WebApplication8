namespace WebApplication7.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; private set; }
        public string password { get; private set; }

        public User(int id, string name, string username, string password)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
        }

        public User GetUser()
        {
            return new User(this.id, this.name, this.username, this.password);
        }

        public string ToString()
        {
            return "Id: " + id + "\tName: " + name + "\tUsername: " + username + "\tPassword: " + password;
        }
    }

}