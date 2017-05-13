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

public partial class Admin_ManageEvents : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Modify(Object sender, CommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());
        Response.Redirect("~/Admin/ModifyMovie.aspx?ID=" + ID);
    }

    protected void Delete(Object sender, CommandEventArgs e)
    { 
        int ID = int.Parse(e.CommandArgument.ToString());

        deleteMovie(ID);        

        Response.Redirect(Request.RawUrl);
    }


    private void deleteMovie(int id)
    {
        string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        SqlConnection con = new SqlConnection(connString);
        string commandText = "DELETE FROM [Movie] WHERE [MovieId] = @ID";

        SqlCommand command = new SqlCommand(commandText, con);
        command.Parameters.Add("@ID", SqlDbType.Int);
        command.Parameters["@ID"].Value = id;

        con.Open();
        command.ExecuteNonQuery();
        con.Close();
    }

}