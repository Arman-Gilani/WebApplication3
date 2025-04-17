using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication3.Controllers
{
	public class LOC_StateController : Controller
	{

        private readonly IConfiguration Configuration;
        public LOC_StateController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult LOC_State_List()
		{

            string str = this.Configuration.GetConnectionString("connectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_State_SelectAll";
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            conn.Close();

            return View(dt);
		}
		public IActionResult LOC_State_Add_Edit()
		{
			return View();
		}
		public IActionResult LOC_State_Update()
		{
			return View();
		}
	}
}
