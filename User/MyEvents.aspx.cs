using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MyEvents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_id.Text = Membership.GetUser().ProviderUserKey.ToString();
    }

    protected void Modify(Object sender, CommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());

    }

    protected void Delete(Object sender, CommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());

        string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        SqlConnection con = new SqlConnection(connString);
        string commandText = "DELETE FROM [EVENT] WHERE [EventId] = @ID";

        SqlCommand command = new SqlCommand(commandText, con);

        command.Parameters.Add("@ID", SqlDbType.Int);
        command.Parameters["@ID"].Value = ID;
        
        con.Open();
        command.ExecuteNonQuery();
        con.Close();

        Response.Redirect(Request.RawUrl);
    }
    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}