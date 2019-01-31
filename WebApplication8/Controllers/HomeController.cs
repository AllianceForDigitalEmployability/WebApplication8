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
        // GET: Home
        //public ActionResult Index()
        public string Index(string name)
        {
            string xyz = "List of Employees: <br />";
            xyz += name;

            String connstring = "Data Source=\"ra1.anystream.eu,1010\";Initial Catalog=example_database;User ID=sa;Password=aDifficultPassword$";
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                string sql = "SELECT Id, Name, Location FROM Employees;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            xyz += reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + "<br />";
                        }
                    }
                }

            }


            string ss = "<!DOCTYPE html><html><body><h4>" + xyz + "</h4></body></html>";
            return ss; // View();
        }
    }
}