using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
namespace MyProject
{
    public partial class Register : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            if (Page.IsValid)
            {
                string Email, UserId;//roleid="user";
                Email = TextBox3.Text;
                UserId = TextBox7.Text;
               
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shopingConnectionString1"].ConnectionString);
                string valCmd = "select UserId,Email from UDetail";
                SqlCommand CMD = new SqlCommand(valCmd, con);
                con.Open();
                string cmd = "insert into UDetail values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + UserId + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + Email + "','" + TextBox8.Text + "') ";
                SqlCommand Cmd = new SqlCommand(cmd, con);
                

                Cmd.ExecuteNonQuery();
               // con.Close();
                
                //Cmd.CommandText = "insert into login values('" + TextBox7.Text + "','" + Email + "','"+"user"+"')";
                //SqlCommand Cmd1 = new SqlCommand(cmd, con1);
                
                //Cmd1.ExecuteNonQuery();
                Response.Cookies["uname"].Value = TextBox7.Text;
                Response.Cookies["pwd"].Value = TextBox4.Text;
                Response.Cookies["role"].Value = "user";
                FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, true);
                con.Close();
            }


        }

       protected void val(object source, ServerValidateEventArgs args)
        {
            SqlConnection valcon = new SqlConnection(ConfigurationManager.ConnectionStrings["shopingConnectionString1"].ConnectionString);
            string valcom = "select * from login";
            SqlCommand ValCOM = new SqlCommand(valcom, valcon);
            valcon.Open();
            if (valcon.State == ConnectionState.Open)
            {
                SqlDataReader valrd = ValCOM.ExecuteReader();
                while (valrd.Read())
                {
                    if (valrd[0].ToString().Equals(TextBox7.Text))
                    { args.IsValid = false; }
                    else { args.IsValid = true; }
                }



            }

            valcon.Close();
        }

        //protected void val(object sender, EventArgs e)
        //{
        //    SqlConnection valcon = new SqlConnection(ConfigurationManager.ConnectionStrings["shopingConnectionString1"].ConnectionString);
        //    string valcom = "select * from login";
        //    SqlCommand ValCOM = new SqlCommand(valcom, valcon);
        //    valcon.Open();
        //    if (valcon.State == ConnectionState.Open)
        //    {
        //        SqlDataReader valrd = ValCOM.ExecuteReader();
        //        while (valrd.Read())
        //        {
        //            if (valrd[0].ToString().Equals(TextBox7.Text))
        //            { ImageButton1.Enabled = false; Label1.Text = "not available";  }
        //            else {  Label1.Text = " available"; }
        //        }
            
            
            
        //    }

        //    valcon.Close();
        
        //}



       
        
    
    }
}