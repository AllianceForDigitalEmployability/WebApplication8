using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Data.SqlClient;


namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        private List<WebApplication7.Models.User> users = new List<WebApplication7.Models.User>();

        // GET: Home
        //public ActionResult Index()
        public string Index(string name)
        {
            string xyz = "List of Employees: <br />";
            xyz += name;

            string ss = "<!DOCTYPE html><html><body><h4>" + xyz + "</h4></body></html>";
            return ss; // View();
        }

        public ActionResult User()
        {
            users = GetUsers();
            ViewBag.theUsers = users;
            ViewBag.xxx = "XXX";
            ViewBag.user = users[1]; // .ToString();
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }

        public string InsertUser(string name, string username, string password)
        {
            return name+" " + username + " " + password;
        }

        private List<WebApplication7.Models.User> GetUsers()
        {
            List<WebApplication7.Models.User> theUsers = new List<WebApplication7.Models.User>();

            String connstring = "Data Source=\"ra1.anystream.eu,1010\";Initial Catalog=example_database;User ID=sa;Password=aDifficultPassword$";
            String connstring2 = "Data Source=NBD-LW03\\SQLEXPRESS;Initial Catalog=eShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connstring2))
            {
                connection.Open();
                string sql = "SELECT * FROM dbo.Users;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            theUsers.Add(new WebApplication7.Models.User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                            //reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + "<br />";
                        }
                    }
                }
            }
            return theUsers;
        }

    }
}