using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack && User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Home.aspx");
        }
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        CreateUserWizard wiz = (CreateUserWizard)LoginViewLogin.FindControl("CreateUserWizard1");
        Roles.AddUserToRole(wiz.UserName, "User");
    }

}