using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SeatChooser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Write(DropDownList1.SelectedItem.Text);

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True");
        String sql = "UPDATE Seat SET taken = 1 WHERE seatid = @seatida";
        try
        {
            SqlCommand cmd = new SqlCommand(sql,con);
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

        Response.Redirect("~/SeatChooser.aspx");
        

    }
}