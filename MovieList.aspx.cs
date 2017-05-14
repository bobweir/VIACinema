using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MovieList : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }

    protected void BindGrid()
    {
        localhost.MovieList movieService = new localhost.MovieList();

        GridView1.DataSource = movieService.ShowMovies();
        GridView1.DataBind();

    }
}
