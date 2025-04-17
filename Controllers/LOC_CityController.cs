using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication3.Controllers
{
	public class LOC_CityController : Controller
	{
        private readonly IConfiguration Configuration;
        public LOC_CityController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult LOC_City_List()
		{

            string str = this.Configuration.GetConnectionString("connectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_City_SelectAll";
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            conn.Close();

            return View(dt);
		}
		public IActionResult LOC_City_Add_Edit()
		{
			return View();
		}
		public IActionResult LOC_City_Update()
		{
			return View();
		}
	}
}
