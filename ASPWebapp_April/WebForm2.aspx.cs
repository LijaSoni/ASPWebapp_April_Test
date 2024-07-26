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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-NQSQA0KQ\SQLEXPRESS;database=AprilNewDB;Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string strsel = "select Id,Name from UserRegister";
                SqlDataAdapter da = new SqlDataAdapter(strsel, con);//values
                DataSet ds = new DataSet();
                da.Fill(ds);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0,"-select-");
            }           
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Label1.Text = DropDownList1.SelectedItem.Text;
            //Label2.Text = DropDownList1.SelectedItem.Value;
            string s = "select * from UserRegister where Id="+DropDownList1.SelectedItem.Value+"";
            SqlDataAdapter da = new SqlDataAdapter(s, con);//values
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GridBind_Fn();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = "select * from UserRegister";
            SqlDataAdapter da = new SqlDataAdapter(s, con);//values
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;//page index
            GridBind_Fn();
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
    }
}