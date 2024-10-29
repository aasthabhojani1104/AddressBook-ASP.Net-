using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressBook.Country
{
    public partial class CountryAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CountryID"] != null)
                {
                    EditCountry(Convert.ToInt32(Request.QueryString["CountryID"].ToString()));
                }
            }


        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string CountryName = String.Empty;
                string CountryCode;

                CountryName = txtCountryName.Text.Trim();
                CountryCode = txtCountryCode.Text.Trim();


                //Step 1: Create DB Connection
                SqlConnection objConn = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
                objConn.Open();

                //2. Create Command and Pass parameters to SP
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                if (Request.QueryString["CountryID"] == null)
                {
                    objCmd.CommandText = "PR_Country_Insert";
                }
                else
                {
                    objCmd.CommandText = "PR_Country_UpdateByPK";
                    objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(Request.QueryString["CountryID"].ToString()));
                }
                objCmd.Parameters.AddWithValue("@CountryName", CountryName);
                objCmd.Parameters.AddWithValue("@CountryCode", CountryCode);

                //3. Insert Data
                if (objCmd.ExecuteNonQuery() > 0)
                {
                    if (Request.QueryString["CountryID"] != null)
                    {
                        lblMessage.Text = "Record Updated";
                    }
                    else
                    {
                        lblMessage.Text = "Record Inserted";
                    }

                }

                objConn.Close();


            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }


            ClearControls();

            //if (Request.QueryString["CountryID"] != null)
            //{
            //    Response.Redirect("~/Country/CountryList.aspx");
            //}
        }


        private void EditCountry(int CountryID)
        {
            //Step 1: Create DB Connection
            SqlConnection CountryDB = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
            CountryDB.Open();

            //2. Create Command
            SqlCommand MyCmd = CountryDB.CreateCommand();
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.CommandText = "PR_Country_SelectByPK";
            MyCmd.Parameters.AddWithValue("@CountryID", CountryID);

            //Step 3. Read Data
            SqlDataReader sdr = MyCmd.ExecuteReader();

            if (sdr.HasRows)
            {

                while (sdr.Read())
                {
                    txtCountryCode.Text = sdr["CountryCode"].ToString();
                    txtCountryName.Text = sdr["CountryName"].ToString();

                }
            }

            CountryDB.Close();


        }





        private void ClearControls()
        {

            txtCountryName.Text = String.Empty;
            txtCountryCode.Text = String.Empty;

        }


    }
}