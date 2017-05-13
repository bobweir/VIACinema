using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditUser : System.Web.UI.Page
{
    private string connString;

    protected void Page_Load(object sender, EventArgs e)
    {
        connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
    }
    protected void Delete(Object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();

        if (id != Membership.GetUser().ProviderUserKey.ToString())
        {
            deleteJoinEvents(id);
            deleteEvents(id);

            deleteUser(id);
        }

        Response.Redirect("~/Admin/EditUser.aspx");
    }

    private void deleteEvents(string id)
    {
        SqlConnection con = new SqlConnection(connString);
        string commandText = "DELETE  FROM [Event] WHERE [User] = @ID";

        SqlCommand command = new SqlCommand(commandText, con);
        command.Parameters.AddWithValue("@ID", id);

        con.Open();
        command.ExecuteNonQuery();
        con.Close();
    }

    private void deleteJoinEvents(string id)
    {
        SqlConnection con = new SqlConnection(connString);
        string commandText = "DELETE  FROM [JoinEvent] WHERE [User] = @ID";

        SqlCommand command = new SqlCommand(commandText, con);
        command.Parameters.AddWithValue("@ID", id);

        con.Open();
        command.ExecuteNonQuery();
        con.Close();
    }

    private void deleteUser(string id)
    {
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        SqlCommand cmd = new SqlCommand("Delete_ASPNET_Member", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserToDelete", new Guid(id));
        cmd.ExecuteReader();
    }   
}