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
    public partial class Result : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCourse();
                BindStudentDetails();
            }
        }
        private void BindCourse()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            String SQuery = "select CourseId,CourseName from CourseDetails";
            SqlCommand cmd = new SqlCommand(SQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlSelectCourse.DataSource = dt;
            ddlSelectCourse.DataTextField = "CourseName";
            ddlSelectCourse.DataValueField = "CourseId";
            ddlSelectCourse.DataBind();

            _sConn.Close();
        }

        private void BindStudentDetails()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int courseId = int.Parse(ddlSelectCourse.SelectedValue.ToString());
            string sQuery = "select a.StudentId,a.StudentName,a.RollNumber,a.Address,a.MobileNumber,b.HODName from StudentDetails a join CourseDetails b on a.CourseId=b.CourseId  where a.CourseId=" + courseId + "";
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                gvresult.DataSource = dt;
                gvresult.DataBind();
            }
            _sConn.Close();
        }

        protected void gvresult_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvresult_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "View")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int StudentId = int.Parse(gvresult.DataKeys[index]["StudentId"].ToString());
                Session["StudentID"] = StudentId;
                Response.Redirect("ViewStudentResult.aspx");
            }
        }

        protected void ddlSelectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStudentDetails();
        }

    }
}