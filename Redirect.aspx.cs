using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Redirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String message = "Your payement was accepted, your seat number is " + Session["Seat"] + " you will receive your ticket by mail";
        HttpContext.Current.Response.Write(message);
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Home.aspx");
    } 
}