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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-NQSQA0KQ\SQLEXPRESS;database=AprilNewDB;Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
GridBind_Fn();
            }
                
            
        }
        public void GridBind_Fn()
        {
            string s = "select * from UserRegister";
            SqlDataAdapter da = new SqlDataAdapter(s, con);//values
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];//rw=row index..eg rw=2
            Label1.Text = rw.Cells[2].Text;
            Label2.Text = rw.Cells[3].Text;
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from UserRegister where Id=" + getid + "";
            SqlCommand cmd = new SqlCommand(del,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GridBind_Fn();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridBind_Fn();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridBind_Fn();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);

            TextBox txtage = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtaddr = (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            string strup = "update UserRegister set Age=" + txtage.Text + ",Address='" + txtaddr.Text + "' where Id=" + getid + "";
            SqlCommand cmd = new SqlCommand(strup, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridView1.EditIndex = -1;
            GridBind_Fn();

        }
    }
}