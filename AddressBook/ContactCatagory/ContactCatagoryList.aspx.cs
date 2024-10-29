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
    public partial class ContactCategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getContactCatagoryData();
            }
        }
        private void getContactCatagoryData()
        {
            SqlConnection obj = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
            obj.Open();
            //2. Create Commond

            SqlCommand objCmd = obj.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectAll";
            //3. Read Data
            SqlDataReader sdr = objCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            obj.Close();
            rptContactCategoryList.DataSource = dt;
            rptContactCategoryList.DataBind();
        }
        protected void rptContactCategoryList_IteamCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

                try
                {
                    SqlConnection obj = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
                    obj.Open();
                    SqlCommand objCmd = obj.CreateCommand();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_ContactCategory_Delete";
                    objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(e.CommandArgument));
                    objCmd.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                   
                }
                Response.Redirect("~/ContactCatagory/ContactCatagoryList.aspx");
            }

            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/ContactCatagory/ContactCatagoryAdd.aspx?ContactCategoryID=" + e.CommandArgument);

            }
        }

    }
}