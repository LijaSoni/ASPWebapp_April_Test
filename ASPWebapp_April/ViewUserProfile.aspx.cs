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
    public partial class ViewUserProfile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-NQSQA0KQ\SQLEXPRESS;database=AprilNewDB;Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)//load
            {
                string strsel = "select Name,Age,Address,Phone,Photo from UserRegister where Id=" + Session["uid"] + "";
                SqlCommand cmd = new SqlCommand(strsel, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TextBox1.Text = dr["Name"].ToString();
                    TextBox2.Text = dr["Age"].ToString();
                    TextBox3.Text = dr["Address"].ToString();
                    TextBox4.Text = dr["Phone"].ToString();
                    Image1.ImageUrl = dr["Photo"].ToString();
                }
                con.Close();
            }            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strup= "update UserRegister set Age="+TextBox2.Text+",Address='"+TextBox3.Text+ "' where Id=" + Session["uid"] + "";
            SqlCommand cmd = new SqlCommand(strup, con);//cmd=query
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}