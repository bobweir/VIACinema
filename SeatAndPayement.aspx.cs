using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SeatAndPayement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 1; i < 13; i++)
        {
            if (i < 10)
            {
                DropDownList2.Items.Add("0" + i);
            }
            else
            {
                DropDownList2.Items.Add(i + "");
            }
        }
        for (int i = 0; i < 100; i++)
        {
            if (i < 10)
            {
                DropDownList4.Items.Add("0" + i);
            }
            else
            {
                DropDownList4.Items.Add(i + "");
            }
        }
        DropDownList3.Items.Add("MASTERCARD");
        DropDownList3.Items.Add("VISA");
        DropDownList3.Items.Add("AMEX");
        DropDownList3.Items.Add("DINERS");
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Write("The seat you choosed is the seat number " + DropDownList1.SelectedItem.Text + "<br>");

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True");
        String sql = "UPDATE Seat SET taken = 1 WHERE seatid = @seatida";


        com.ftipgw.secure.CreditCardValidator checker = new com.ftipgw.secure.CreditCardValidator();
        string cdNum = TextBox1.Text;
        string cdType = DropDownList3.SelectedItem.Text;
        int cdMonth = 0;
        Int32.TryParse(DropDownList2.SelectedItem.Text, out cdMonth);
        int cdYear = 0;
        Int32.TryParse(DropDownList4.SelectedItem.Text, out cdYear);

        int curYear = DateTime.Now.Year - 2000;
        int curMonth = DateTime.Now.Month;
        string curType = checker.GetCardType(cdNum);
        bool validNum = checker.ValidMod10(cdNum);

        if (curType == cdType && validNum == true && (cdYear == curYear && cdMonth >= curMonth) || cdYear > curYear)
        {
            HttpContext.Current.Response.Write("Good"); //To Change -> Validate and all
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@seatida", DropDownList1.SelectedItem.Text);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string error = "Error";
                error += ex.Message;
                throw new Exception(error);
            }
            finally
            {
                con.Close();
            }

            Session["seat"] = DropDownList1.SelectedItem.Text;
            //Session["movie"]
            Response.Redirect("~/Redirect.aspx");
        }
        else
        {
            HttpContext.Current.Response.Write("This credit card doesn't exist"); //To change

        }
    }

}