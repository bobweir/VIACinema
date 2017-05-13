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


public partial class Admin_ModifyMovie : System.Web.UI.Page
{
    private string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(); //The connection String for the Database
    private int IDEvent;

    protected void Page_Load(object sender, EventArgs e)
    {
        string IDString = Request.QueryString["ID"];

        try
        {
            int ID = int.Parse(IDString);

            this.IDEvent = ID;

            if (!Page.IsPostBack)
                loadMovie(ID);      //We can load and put the event data into the form

        }
        catch (Exception)
        {
            //The ID is not correct so redirecting
            Response.Redirect("~/Home.aspx");
        }
        
    }
    protected void Save(Object sender, CommandEventArgs e)
    {
        bool formCompleted = true;
        string information = "";

        if (txtName.Text == "")
        {
            formCompleted = false;
            information += "You need to enter a valid name<br/>";
        }

        if (txtGenre.Text == "")
        {
            formCompleted = false;
            information += "You need to enter a valid place<br/>";
        }

        if (txtDescription.Text == "")
        {
            formCompleted = false;
            information += "You need to enter a valid description";
        }

        if (txtTime.Text == "")
        {
            formCompleted = false;
            information += "You need to enter a valid Time";
        }

        if (txtScreen.Text == "")
        {
            formCompleted = false;
            information += "You need to enter a valid Screen";
        }

        if (formCompleted)
        {
            SqlConnection con = new SqlConnection(connString);

            string commandText = "UPDATE [Movie] SET [Name] = @NAME, [Genre] = @GENRE, [Description] = @DESCRIPTION, [Date] = @DATE, [Time] = @TIME, [Screen] = @SCREEN WHERE [MovieId] = @ID";
            SqlCommand command = new SqlCommand(commandText, con);

            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters.Add("@NAME", SqlDbType.VarChar);
            command.Parameters.Add("@DATE", SqlDbType.Date);
            command.Parameters.Add("@GENRE", SqlDbType.VarChar);
            command.Parameters.Add("@TIME", SqlDbType.VarChar);
            command.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar);
            command.Parameters.Add("@SCREEN", SqlDbType.VarChar);

            command.Parameters["@ID"].Value = this.IDEvent;
            command.Parameters["@NAME"].Value = txtName.Text;
            command.Parameters["@DATE"].Value = CldrDate.SelectedDate;
            command.Parameters["@GENRE"].Value = txtGenre.Text;
            command.Parameters["@TIME"].Value = txtTime.Text;
            command.Parameters["@SCREEN"].Value = txtGenre.Text;
            command.Parameters["@DESCRIPTION"].Value = txtDescription.Text;

            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            //We updated the event, redirection to the list with all your events

            Response.Redirect("~/Admin/ManageMovies.aspx");
        }

        lblInformation.Text = information;
    }


    private void loadMovie(int ID)
    {
        SqlConnection con = new SqlConnection(connString);
        string commandText = "SELECT [Name], [Genre],  [Description], [Date], [Time], [Screen], [MovieId] FROM [Movie] WHERE [MovieId] = @ID";
        SqlCommand command = new SqlCommand(commandText, con);
        command.Parameters.Add("@ID", SqlDbType.Int);
        command.Parameters["@ID"].Value = ID;

        con.Open();
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();

        txtName.Text = reader.GetString(0);
        txtGenre.Text = reader.GetString(1);
        txtDescription.Text = reader.GetString(2);
        CldrDate.SelectedDate = reader.GetDateTime(3);
        txtTime.Text = reader.GetString(4);
        txtScreen.Text = reader.GetString(5);

        con.Close();
    }
}