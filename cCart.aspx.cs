using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using paytm;


namespace MyProject
{
    public partial class cCart : System.Web.UI.Page
    {
        string url,s4,s5,s6,s2;
        decimal grandTotal = 0;
        string custid,orderid;
        
        protected void Page_Load(object sender, EventArgs e)
        {
             s2 = System.Web.HttpContext.Current.User.Identity.Name;
            Response.Cookies["uname"].Value = s2;


            //string s3 = Request.Cookies["price"].Value;
            //Label1.Text = grandTotal.ToString();
            grandTotal = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shopingConnectionString1"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from completeCart",con);
            //SqlCommand command = new SqlCommand(cmd, con);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                SqlDataReader dtr = cmd.ExecuteReader();
                while (dtr.Read())
                {


                   // orderid = dtr[0].ToString();
                    custid = dtr[1].ToString();
                    Response.Cookies["custid"].Value = custid;


                }

                    
            }
           
        }


        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal rowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "price")) * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "quantity"));
                grandTotal = grandTotal + rowTotal;


            }
            Response.Cookies["price"].Value = grandTotal.ToString();
            TextBox2.Text = grandTotal.ToString();
            
          
            


        }
        










           protected void btnPaytm_Click(object sender, EventArgs e)
        {

           string orderid = generateID();
            

            string s3 = Request.Cookies["price"].Value;
            string s4 = Request.Cookies["custid"].Value;
            string r1 = TextBox3.Text;
            string r2 = TextBox4.Text;
            string callback = "http://shoppster.somee.com/timer.aspx";
          ///  Textbox7.Text = orderid;




            SqlConnection a = new SqlConnection(ConfigurationManager.ConnectionStrings["shopingConnectionString1"].ConnectionString);
            string cmd = "insert into purchase values('" + orderid + "','" + s4 + "','" + TextBox3.Text + "','" + "paytm" + "','" +s3  + "')";
                SqlCommand b = new SqlCommand(cmd, a);
                a.Open();

                b.ExecuteNonQuery();

            a.Close();
            

             PaytmPay(TextBox4.Text, TextBox3.Text, s4, orderid, s3,callback);


            }

        
    
        public void PaytmPay(string EMAIL, string MOBILE_NO, string CUST_ID,string ORDER_ID , string TXN_AMOUNT,string CALLBACK_URL)
        {
            String merchantKey = "xw5xw0o97g2nwG5z";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MID", "shopps11631241477240");
            parameters.Add("CHANNEL_ID", "WEB");
            parameters.Add("INDUSTRY_TYPE_ID", "Retail");
            parameters.Add("WEBSITE", "WEB_STAGING");
            parameters.Add("EMAIL", EMAIL);
            parameters.Add("MOBILE_NO", MOBILE_NO);
            parameters.Add("CUST_ID", CUST_ID);
            parameters.Add("ORDER_ID", ORDER_ID);
            parameters.Add("TXN_AMOUNT", TXN_AMOUNT);
            parameters.Add("CALLBACK_URL", CALLBACK_URL);
           
            //This parameter is not mandatory. Use this to pass the callback url dynamically.

            string checksum = CheckSum.generateCheckSum(merchantKey, parameters);

            string paytmURL = "https://pguat.paytm.com/oltp-web/processTransaction?orderid=" + ORDER_ID;

            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>Merchant Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
            outputHTML += "<table border='1'>";
            outputHTML += "<tbody>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
            outputHTML += "</tbody>";
            outputHTML += "</table>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);
        }

    
    
    





        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Response.Redirect("cCart.aspx");
        }
       

        
    }
    
}