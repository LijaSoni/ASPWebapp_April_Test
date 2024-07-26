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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-NQSQA0KQ\SQLEXPRESS;database=AprilNewDB;Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string='"+ +"'
            //int="+ +"
            string str = "insert into tab1 values('" + TextBox1.Text + "'," + TextBox3.Text + ",'" + TextBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(str,con);//cmd=query
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();
            if(i==1)
            {
                Label1.Text = "Inserted";
            }
        }
    }
}