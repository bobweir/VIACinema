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

public partial class Home : System.Web.UI.Page
{
    //private string userID;

    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            try
            {
                userID = userID = Membership.GetUser().ProviderUserKey.ToString();
                lbl_id.Text = Membership.GetUser().ProviderUserKey.ToString();
            }
            catch (Exception)
            { }
        }
         * */
    }

    /*
    protected void Join(Object sender, CommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());

        string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        SqlConnection con = new SqlConnection(connString);


        string commandText = "INSERT INTO [JOINEVENT] ([Event], [User]) VALUES(@EVENT, @USER)";

        SqlCommand command = new SqlCommand(commandText, con);

        command.Parameters.AddWithValue("@EVENT", ID);
        command.Parameters.AddWithValue("@USER", new Guid(userID));

        con.Open();
        command.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);
    }

    protected void Leave(Object sender, CommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());

        string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        SqlConnection con = new SqlConnection(connString);


        string commandText = "DELETE FROM [JoinEvent] WHERE [Event] = @ID AND [User] = @USER";

        SqlCommand command = new SqlCommand(commandText, con);

        command.Parameters.AddWithValue("@ID", ID);
        command.Parameters.AddWithValue("@USER", new Guid(userID));

        con.Open();
        command.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);
    }
    protected void Unnamed_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Button button_join = (Button)e.Item.FindControl("button_join");
        Button button_leave = (Button)e.Item.FindControl("button_leave");

        int event_id = int.Parse(((Label)e.Item.FindControl("lbl_eventid")).Text);

        button_join.Visible = false;
        button_leave.Visible = false;

        Label areGoing = (Label)e.Item.FindControl("areGoing");

        string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        SqlConnection con = new SqlConnection(connString);
        string commandText = "SELECT COUNT(*) FROM [JoinEvent] WHERE [Event] = @EVENT";

        SqlCommand command = new SqlCommand(commandText, con);
        command.Parameters.AddWithValue("@EVENT", event_id);

        con.Open();
        SqlDataReader reader = command.ExecuteReader();

        reader.Read();

        int nbr = reader.GetInt32(0);

        if (nbr == 0)
        { areGoing.Text = "Nobody is coming..."; }
        else if (nbr > 1)
        { areGoing.Text = nbr + " are coming!"; }
        else
        { areGoing.Text = nbr + " is coming!"; }

        con.Close();
        




        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            commandText = "SELECT COUNT(*) FROM [JoinEvent] WHERE [Event] = @EVENT AND [User] = @USER GROUP BY [Event]";

            command = new SqlCommand(commandText, con);

            command.Parameters.AddWithValue("@EVENT", event_id);
            command.Parameters.AddWithValue("@USER", new Guid(userID));

            con.Open();
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                nbr = reader.GetInt32(0);
                button_leave.Visible = true;
                button_leave.CommandArgument = event_id.ToString(); 
            }
            else
            {
                button_join.Visible = true;
                button_join.CommandArgument = event_id.ToString();
            }  
            con.Close();
        }
    }*/

    protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       // if()

        Response.Redirect("~/SeatAndPayment.aspx");

    }

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}