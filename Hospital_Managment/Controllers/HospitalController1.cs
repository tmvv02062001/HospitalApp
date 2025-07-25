using Hospital_Managment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Hospital_Managment.Controllers
{
    public class HospitalController1 : Controller
    {
        public string cString = "server=VISHNUVAMSI-TM\\SQLEXPRESS; DataBase=Hospital_Managment; Integrated Security=true";

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult HMOverView()
        {
            return View();
        }
        public ActionResult BillingDetails()
        {
            return View();
        }

        public ActionResult GetbDetails(Billings bs)
        {
            SqlConnection sconnection = new SqlConnection(cString);
            SqlCommand scommand = new SqlCommand("Insert_Billing", sconnection);
            scommand.CommandType = CommandType.StoredProcedure;
            scommand.Parameters.AddWithValue("@Patient_Name", bs.PName);
            scommand.Parameters.AddWithValue("@Patient_Gender", bs.PGender);
            scommand.Parameters.AddWithValue("@Patient_Cause", bs.PCause);
            scommand.Parameters.AddWithValue("@Doctor_Name", bs.DName);
            scommand.Parameters.AddWithValue("@Doctor_Specs", bs.DSpecs);
            scommand.Parameters.AddWithValue("@Hospital_Name", bs.HName);
            scommand.Parameters.AddWithValue("@Hospital_Address", bs.HAddress);
            scommand.Parameters.AddWithValue("@Hospital_PhoneNo", bs.HPhone);
            scommand.Parameters.AddWithValue("@Billing_Amount", bs.BAmount);
            scommand.Parameters.AddWithValue("@Billing_Mode", bs.BMode);
            sconnection.Open();
            scommand.ExecuteNonQuery();
            sconnection.Close();
            return View("ReadPatient");
        }

        public ActionResult ReadPatient()
        {
            return View();
        }

        public JsonResult PatientDetails()
        {
            List<Billings> bls = new List<Billings>();
            SqlConnection con = new SqlConnection(cString);
            SqlCommand com = new SqlCommand("get_Patient_Billing", con);
            com.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Billings b = new Billings();
                    b.BId = Convert.ToInt32(reader["Billing_Id"]);
                    b.PName = reader["Patient_Name"].ToString();
                    b.PGender = reader["Patient_Gender"].ToString();
                    b.PCause = reader["Patient_Cause"].ToString();
                    b.DName = reader["Doctor_Name"].ToString();
                    b.DSpecs = reader["Doctor_Specs"].ToString();
                    b.HName = reader["Hospital_Name"].ToString();
                    b.HAddress = reader["Hospital_Address"].ToString();
                    b.HPhone = reader["Hospital_PhoneNo"].ToString();
                    b.BAmount = Convert.ToInt32(reader["Billing_Amount"]);
                    b.BMode = reader["Billing_Mode"].ToString();

                    bls.Add(b);
                }

                con.Close();
            }
            catch(Exception ex)
            {
                throw;
            }
            return Json(bls);
        }

        public ActionResult DeleteBP(int id)
        {
            SqlConnection sc = new SqlConnection(cString);
            SqlCommand scd = new SqlCommand("Delete_PD", sc);
            scd.CommandType = CommandType.StoredProcedure;
            scd.Parameters.AddWithValue("@Billing_Id", id);
            sc.Open();
            scd.ExecuteNonQuery();
            sc.Close();
            return Json("Deleted Successfully");

        }

        public ActionResult editView(int id)
        {
            var edit = EditData(id);
            return View("editView" , edit);
        }

        public Billings EditData(int id)
        {
            Billings bs = new Billings();
            SqlConnection scn = new SqlConnection(cString);
            SqlCommand scd = new SqlCommand("Get_By_Patient", scn);
            scd.CommandType= CommandType.StoredProcedure;
            scd.Parameters.AddWithValue("@Billing_Id", id);

            scn.Open();
            SqlDataReader reader = scd.ExecuteReader();

            if (reader.Read())
            {
                bs.BId = Convert.ToInt32(reader["Billing_Id"]);
                bs.PName = reader["Patient_Name"].ToString();
                bs.PGender = reader["Patient_Gender"].ToString();
                bs.PCause = reader["Patient_Cause"].ToString();
                bs.DName = reader["Doctor_Name"].ToString();
                bs.DSpecs = reader["Doctor_Specs"].ToString();
                bs.HName = reader["Hospital_Name"].ToString();
                bs.HAddress = reader["Hospital_Address"].ToString();
                bs.HPhone = reader["Hospital_PhoneNo"].ToString();
                bs.BAmount = Convert.ToInt32(reader["Billing_Amount"]);
                bs.BMode = reader["Billing_Mode"].ToString();
            }
            scn.Close();

            return bs;
        }

        public ActionResult UpdateData(Billings b)
        {
            SqlConnection sqlc = new SqlConnection(cString);
            SqlCommand sqlcd = new SqlCommand("Update_Patient_Details", sqlc);
            sqlcd.CommandType= CommandType.StoredProcedure;
            sqlcd.Parameters.AddWithValue("@Billing_Id", b.BId);
            sqlcd.Parameters.AddWithValue("@Patient_Name", b.PName);
            sqlcd.Parameters.AddWithValue("@Patient_Gender", b.PGender);
            sqlcd.Parameters.AddWithValue("@Patient_Cause", b.PCause);
            sqlcd.Parameters.AddWithValue("@Doctor_Name", b.DName);
            sqlcd.Parameters.AddWithValue("@Doctor_Specs", b.DSpecs);
            sqlcd.Parameters.AddWithValue("@Hospital_Name", b.HName);
            sqlcd.Parameters.AddWithValue("@Hospital_Address", b.HAddress);
            sqlcd.Parameters.AddWithValue("@Hospital_PhoneNo", b.HPhone);
            sqlcd.Parameters.AddWithValue("@Billing_Amount", b.BAmount);
            sqlcd.Parameters.AddWithValue("@Billing_Mode", b.BMode);
            sqlc.Open();
            sqlcd.ExecuteNonQuery();
            sqlc.Close();
            
            return RedirectToAction("ReadPatient");
        }
    }

}
