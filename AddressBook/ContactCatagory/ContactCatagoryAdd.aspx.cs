using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressBook.ContactCatagory
{
    public partial class ContactCategoryAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                FillCountryDropDown();
                if (Request.QueryString["ContactCategoryID"] != null)
                {
                    EditState(Convert.ToInt32(Request.QueryString["ContactCategoryID"].ToString()));
                }
            }
          
        }
        private void FillCountryDropDown()
        {
            //Step 1: Create DB Connection
            SqlConnection objConn = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");

            objConn.Open();
            //2. Create Commond

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.Text;
            objCmd.CommandText = "SELECT ContactCategoryID, ContactCategoryName FROM ContactCategory";

            //3. Read Data
            SqlDataReader sdr = objCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            objConn.Close();

            //4. Bind Data to Source
            //ddlCountry.DataSource = dt;
            //ddlCountry.DataTextField = "ContactCategoryName";
            //ddlCountry.DataValueField = "ContactCategoryID";
            //ddlCountry.DataBind();
            //ddlCountry.Items.Insert(0, new ListItem("--- Select ContactCategoryName ---", "-99"));
        }
        private void ClearControls()
        {
           // txtContactCategory.Text = String.Empty;
            //txtContactCategoryCode.Text = String.Empty;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ContactCategoryName = String.Empty;
                string ContactCategoryID;


                ContactCategoryName = txtContactCategory.Text.Trim();
                //ContactCategoryID = txtContactCategoryCode.Text.Trim();
                //CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

                //Step 1: Create DB Connection
                SqlConnection objConn = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
                objConn.Open();

                //2. Create Command and Pass parameters to SP
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                if (Request.QueryString["ContactCategoryID"] == null)
                {
                    objCmd.CommandText = "PR_ContactCategory_Insert";
                }
                else
                {
                    objCmd.CommandText = "PR_ContactCategory_Update";
                    objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
                }
                objCmd.Parameters.AddWithValue("@ContactCategoryName", ContactCategoryName);
              //objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);
             
                //3. Insert Data
                if (objCmd.ExecuteNonQuery() > 0)
                {
                    if (Request.QueryString["ContactCategoryID"] != null)
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
        private void EditState(int ContactCategoryID)
        {
            //Step 1: Create DB Connection
            SqlConnection stateDB = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
            stateDB.Open();

            //2. Create Command
            SqlCommand MyCmd = stateDB.CreateCommand();
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.CommandText = "PR_ContactCategory_SelectByPK";
            MyCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);

            //Step 3. Read Data
            SqlDataReader sdr = MyCmd.ExecuteReader();

            if (sdr.HasRows)
            {

                while (sdr.Read())
                {
                    // txtContactCategoryCode.Text = sdr["ContactCategoryID"].ToString();
                    txtContactCategory.Text = sdr["ContactCategoryName"].ToString();
                    //ddlCountry.SelectedValue = sdr["CountryID"].ToString();

                }
            }

            stateDB.Close();


        }
    }
}