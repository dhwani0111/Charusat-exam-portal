using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineExamination
{
    public partial class StudentExams : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            BindStudentDetails();
        }

        private void BindStudentDetails()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }

            string sQuery = "select a.StudentId,a.StudentName,a.Address,b.CourseName from StudentDetails a join CourseDetails b on a.CourseId=b.CourseId";
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                gvStudentExam.DataSource = dt;
                gvStudentExam.DataBind();
            }
            _sConn.Close();
        }

        protected void gvStudentExam_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvStudentExam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int StudentId = int.Parse(gvStudentExam.DataKeys[index]["StudentId"].ToString());
                Session["StudentID"] = StudentId;
                Response.Redirect("ViewStudentResult.aspx");
                    
                   
                
                
               

            }
        }
    }
}
    