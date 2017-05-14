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
    public DataTable ShowMovies()
    {

        using (SqlConnection co = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Name, Genre, Description FROM Movie"))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd.Connection = co;
                    da.SelectCommand = cmd;
                    using (DataTable table = new DataTable())
                    {
                        table.TableName = "Movies";
                        da.Fill(table);
                        return table;
                    }

                }
            }
        }
    }
}
