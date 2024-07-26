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
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-NQSQA0KQ\SQLEXPRESS;database=AprilNewDB;Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/Images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));

            string sel = "";
            for (int i=0;i<CheckBoxList1.Items.Count;i++)
            {
                if(CheckBoxList1.Items[i].Selected)
                {
                    sel += CheckBoxList1.Items[i].Text + ",";
                }
            }

            string strins = "insert into UserRegister values('" + TextBox1.Text + "'," + TextBox3.Text + ",'" + TextBox2.Text + "'," + TextBox4.Text + ",'" + TextBox5.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + sel + "','" + p + "','" + TextBox8.Text + "','" + TextBox6.Text + "')";
            SqlCommand cmd = new SqlCommand(strins, con);//cmd=query
            con.Open();
            int b = cmd.ExecuteNonQuery();
            con.Close();
            if (b == 1)
            {
                Label1.Text = "Inserted";
            }
        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}