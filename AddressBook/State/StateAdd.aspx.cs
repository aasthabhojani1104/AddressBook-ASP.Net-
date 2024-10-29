using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressBook
{
    public partial class StateAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillCountryDropDown();
                if (Request.QueryString["StateID"] != null)
                {
                    EditState(Convert.ToInt32(Request.QueryString["StateID"].ToString()));
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string StateName = String.Empty;
                string StateCode;
                int CountryID;

                StateName = txtStateName.Text.Trim();
                StateCode = txtStateCode.Text.Trim();
                CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

                //Step 1: Create DB Connection
                SqlConnection objConn = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
                objConn.Open();

                //2. Create Command and Pass parameters to SP
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                if (Request.QueryString["StateID"] == null)
                {
                    objCmd.CommandText = "PR_State_Insert";
                }
                else
                {
                    objCmd.CommandText = "PR_State_UpdateByPk";
                    objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(Request.QueryString["StateID"]));
                }
                objCmd.Parameters.AddWithValue("@StateName", StateName);
                objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                objCmd.Parameters.AddWithValue("@StateCode", StateCode);

                //3. Insert Data
                if (objCmd.ExecuteNonQuery() > 0)
                {
                    if (Request.QueryString["StateID"] != null)
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


        }

        private void EditState(int stateID)
        {
            //Step 1: Create DB Connection
            SqlConnection stateDB = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
            stateDB.Open();

            //2. Create Command
            SqlCommand MyCmd = stateDB.CreateCommand();
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.CommandText = "PR_State_SelectByPK";
            MyCmd.Parameters.AddWithValue("@StateID", stateID);

            //Step 3. Read Data
            SqlDataReader sdr = MyCmd.ExecuteReader();

            if (sdr.HasRows)
            {

                while (sdr.Read())
                {
                    txtStateCode.Text = sdr["StateCode"].ToString();
                    txtStateName.Text = sdr["StateName"].ToString();
                    ddlCountry.SelectedValue = sdr["CountryID"].ToString();

                }
            }

            stateDB.Close();


        }



        private void FillCountryDropDown()
        {
            //Step 1: Create DB Connection
            SqlConnection CountryDB = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");

            CountryDB.Open();
            //2. Create Command

            SqlCommand objCmd = CountryDB.CreateCommand();
            objCmd.CommandType = CommandType.Text;
            objCmd.CommandText = "SELECT CountryID, CountryName FROM Country";

            //3. Read Data
            SqlDataReader sdr = objCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            CountryDB.Close();

            //4. Bind Data to Source
            ddlCountry.DataSource = dt;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--- Select Country ---", "-99"));
        }


        private void ClearControls()
        {

            txtStateName.Text = String.Empty;
            txtStateCode.Text = String.Empty;
            ddlCountry.SelectedValue = "-99";

        }

    }
}