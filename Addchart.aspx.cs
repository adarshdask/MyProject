using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MyProject
{
    public partial class Addchart : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            


            string s = @"~\img\chart" + FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath(s));
            SqlConnection a = new SqlConnection(ConfigurationManager.ConnectionStrings["shopingConnectionString1"].ConnectionString);
            String cmd = "insert into schart(day,image) values('" + textbox6.Text + "','" + s + "')";

            SqlCommand b = new SqlCommand(cmd, a);
            /*  b.Parameters.Add("@pn",nameText.Text);
              b.Parameters.Add("@br",brandText.Text);
              b.Parameters.Add("@img",s);
              b.Parameters.Add("@cat","lappy");
              b.Parameters.Add("@pr",priceText.Text);
              */
            a.Open();
            b.ExecuteNonQuery();
            a.Close();

        }
    }
}