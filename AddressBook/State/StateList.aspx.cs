using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace AddressBook
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getStateData();
            }
        }

        private void getStateData()
        {
            //Step 1 : create Connection
            SqlConnection StateDB = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
            StateDB.Open();

            //2. Create Command
            SqlCommand objCmd = StateDB.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectAll";


            //3. Read Data
            SqlDataReader sdr = objCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            StateDB.Close();
            rptStateList.DataSource = dt;
            rptStateList.DataBind();
        }

        protected void rptStateList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

                SqlConnection StateDB = new SqlConnection("Data Source=AASTHABHOJANI\\SQLEXPRESS; Initial Catalog=AddressBook; Integrated Security=true;");
                StateDB.Open();
                SqlCommand objCmd = StateDB.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_State_DeleteByPK";
                objCmd.Parameters.AddWithValue("@StateID", e.CommandArgument);
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/State/StateList.aspx");

            }

            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/State/StateAdd.aspx?StateID=" + e.CommandArgument);
            }

        }
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/State/SateList.aspx", false);
    }



}
