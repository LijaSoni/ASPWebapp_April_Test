using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace ASPWebapp_April
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-NQSQA0KQ\SQLEXPRESS;database=AprilNewDB;Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select count(Id) from UserRegister where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(sel,con);
            con.Open();
            string cid = cmd.ExecuteScalar().ToString();
            con.Close();
            if(cid=="1")
            {
                string selid = "select Id from UserRegister where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                SqlCommand cmd1= new SqlCommand(selid, con);
                con.Open();
                string id = cmd1.ExecuteScalar().ToString();
                con.Close();
                Session["uid"] = id;
                Response.Redirect("ViewUserProfile.aspx");
                //Label1.Text = "Success";
            }
            else
            {
                Label1.Text = "Inavalid username and password";
            }
        }
    }
}