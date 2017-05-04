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

public partial class User_CreateEvent : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {}

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        bool formCompleted = true;
        string information = "";

        if (txtName.Text == "")
        {
            formCompleted = false;
            information += "You need to enter a valid name<br/>";
        }

        if (txtPlace.Text == "")
        {
            formCompleted = false;
            information += "You need to enter a valid place<br/>";
        }

        if (txtDescription.Text == "")
        {
            formCompleted = false;
            information += "You need to enter a valid description";
        }

        if (formCompleted)
        {
            //Add event to database
            string userId = Membership.GetUser().ProviderUserKey.ToString();

            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(connString);


            string commandText = "INSERT INTO EVENT ([User], [Name], [Date], [Time], [Place], [Description]) VALUES(@USER, @NAME, @DATE, @TIME, @PLACE, @DESCRIPTION); SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(commandText, con);

            command.Parameters.Add("@USER", SqlDbType.UniqueIdentifier);
            command.Parameters.Add("@NAME", SqlDbType.VarChar);
            command.Parameters.Add("@DATE", SqlDbType.Date);
            command.Parameters.Add("@TIME", SqlDbType.VarChar);
            command.Parameters.Add("@PLACE", SqlDbType.VarChar);
            command.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar);

            command.Parameters["@USER"].Value = new Guid(userId);
            command.Parameters["@NAME"].Value = txtName.Text;
            command.Parameters["@DATE"].Value = CldrDate.SelectedDate;
            command.Parameters["@TIME"].Value = txtTime.Text;
            command.Parameters["@PLACE"].Value = txtPlace.Text;
            command.Parameters["@DESCRIPTION"].Value = txtDescription.Text;


            con.Open();
            command.ExecuteNonQuery();
            con.Close();


            information = "The event has been succesfully created!";
            //Redirect, event créé
            Response.Redirect("~/Home.aspx");
        }
        
        lblInformation.Text = information;
    }
}