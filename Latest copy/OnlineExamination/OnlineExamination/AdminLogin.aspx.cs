using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamination
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["AdminLogin"] = "Login";
            Panel pnlAdminMenu = (Panel)Master.FindControl("pnlAdminMenu");
            pnlAdminMenu.Visible = true;
            Response.Redirect("AddStudentDetails.aspx");
            

        }
    }
}