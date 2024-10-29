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
    public partial class CountryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getCountryData();
            }
        }

        private void getCountryData()
        {
            //Step 1 : create Connection
            SqlConnection StateDB = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
            StateDB.Open();

            //2. Create Command
            SqlCommand objCmd = StateDB.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_SelectAllCountries";


            //3. Read Data
            SqlDataReader sdr = objCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            StateDB.Close();
            rptCountryList.DataSource = dt;
            rptCountryList.DataBind();
        }

        protected void rptCountryList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                try
                {
                    SqlConnection StateDB = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
                    StateDB.Open();
                    SqlCommand objCmd = StateDB.CreateCommand();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Country_DeleteByPK";
                    objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(e.CommandArgument));
                    objCmd.ExecuteNonQuery();

                    lblMessage.Text = "Record Deleted";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();
                }
                finally {
                    Response.Redirect("~/Country/CountryList.aspx");
                }
            
            }
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/Country/CountryAdd.aspx?CountryID=" + e.CommandArgument);
            }

        }

        //protected void rptContactCategoryList_IteamCommand(object source, RepeaterCommandEventArgs e)
        //   {
        //       if (e.CommandName == "Delete")
        //       {

        //           try
        //           {
        //               SqlConnection obj = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
        //               obj.Open();
        //               SqlCommand objCmd = obj.CreateCommand();
        //               objCmd.CommandType = CommandType.StoredProcedure;
        //               objCmd.CommandText = "PR_ContactCategory_Delete";
        //               objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(e.CommandArgument));
        //               objCmd.ExecuteNonQuery();

        //           }
        //           catch (Exception ex)
        //           {

        //           }
        //           Response.Redirect("~/ContactCatagory/ContactCatagoryList.aspx");
        //       }

        //       if (e.CommandName == "Edit")
        //       {
        //           Response.Redirect("~/ContactCatagory/ContactCatagoryAdd.aspx?ContactCategoryID=" + e.CommandArgument);

        //       }
        //   }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Country/CountryAdd.aspx");
        }
    }

}