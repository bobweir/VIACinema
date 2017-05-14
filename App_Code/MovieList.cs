using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for MovieList
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class MovieList : System.Web.Services.WebService
{

    public MovieList()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<String> ShowMovies()
    {
        List<String> movieList = new List<String>();
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True");
        String sql = "SELECT Name FROM Movie";
        try
        {
            
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);

            foreach(DataRow row in table.Rows)
            {
                movieList.Add(row.Field<String>(0));
                
            }

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
        return movieList;
    }

}
