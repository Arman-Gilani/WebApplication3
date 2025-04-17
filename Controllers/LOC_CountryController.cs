using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
	public class LOC_CountryController : Controller
	{
		private readonly IConfiguration Configuration;
		public LOC_CountryController(IConfiguration _configuration)
		{
			Configuration = _configuration;
		}

		public IActionResult LOC_Country_List()
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();	
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Country_SelectAll";
			SqlDataReader rdr = cmd.ExecuteReader();	
			DataTable dt = new DataTable();	
			dt.Load(rdr);	
			conn.Close();

			return View(dt);
		}
		public IActionResult LOC_Country_Add_Edit(LOC_CountryModel model)
		{
            DateTime dateTime = DateTime.Now;

            string str = this.Configuration.GetConnectionString("connectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Country_Insert";

			cmd.Parameters.AddWithValue("CountryID",model.CountryId);
            cmd.Parameters.AddWithValue("CountryName", model.CountryId);
			cmd.Parameters.AddWithValue("CountryCode", model.CountryId);
            cmd.Parameters.AddWithValue("Created", dateTime);
            cmd.Parameters.AddWithValue("Modified", dateTime);
			
			cmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("LOC_Country_List");		
		}
		public IActionResult LOC_Country_Update()
		{
			return View();
		}
    }
}
