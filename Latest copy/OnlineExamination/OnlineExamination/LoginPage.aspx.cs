using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.NetworkInformation;

namespace OnlineExamination
{
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection _sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String userType = ddlUserType.SelectedValue.ToString();
            String username = txtUsername.Text.ToString();
            String passWord = txtPassword.Text.ToString();
            String sQuery = String.Empty;
            if (userType == "Admin")
            {
                sQuery = "select AdminId from AdminDetails where UserName='" + username + "' and PassWord='" + passWord + "'";

            }
            else if (userType == "Staff")
            {
                sQuery = "select TeachersId from TeachersDetails  where EmailId='" + username + "' and PassWord='" + passWord + "'";

            }
            else if (userType == "Student")
            {
                sQuery = "select StudentId,StudentName,EmailId from StudentDetails where UserName='" + username + "' and PassWord='" + passWord + "'";
            }
            if (_sconn.State != ConnectionState.Open)
            {
                _sconn.Open();
            }
            SqlCommand cmd = new SqlCommand(sQuery, _sconn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblInvalid.Visible = false;
                foreach (DataRow dr in dt.Rows)
                {
                    if (userType == "Admin")
                    {
                        Session["LoggedUser"] = "Admin";
                        Session["AdminID"] = dr["AdminId"].ToString();
                        Response.Redirect("Home.aspx");

                    }
                    else if (userType == "Staff")
                    {
                        Session["LoggedUser"] = "Staff";
                        Session["TeachersID"] = dr["TeachersId"].ToString();
                        Response.Redirect("Home.aspx");

                    }
                    else if (userType == "Student")
                    {
                        bool isRight = true;
                        if (isRight == true)
                        {
                            Session["LoggedUser"] = "Student";
                            Session["StudentID"] = dr["StudentId"].ToString();
                            Session["StudentName"] = dr["StudentName"].ToString();
                            Session["EmailId"] = dr["EmailId"].ToString();
                            Response.Redirect("Home.aspx");

                        }
                        else
                        {
                            lblInvalid.Visible = true;
                            txtUsername.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            txtUsername.Focus();
                        }
                    }
                }
            }
            else
            {
                lblInvalid.Visible = true;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUsername.Focus();
            }
        }

        
    }
}