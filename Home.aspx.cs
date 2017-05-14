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


    protected void Page_Load(object sender, EventArgs e)
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