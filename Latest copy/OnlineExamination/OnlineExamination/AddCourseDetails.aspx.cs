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
    public partial class AddCourseDetails : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCourseDetails();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string courseName = txtCourseName.Text.ToString();

            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = string.Empty;
            if (btnSubmit.Text == "Submit")
            {
                sQuery = "insert into CourseDetails (CourseName) values ('" + courseName + "')";
            }
            else if (btnSubmit.Text == "Update")
            {
                int courseId = int.Parse(Application["CourseID"].ToString());
                sQuery = "update CourseDetails set CourseName='" + courseName + "' where CourseId=" + courseId;
                
            }
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
            _sConn.Close();
            ClearAll();
            pnlAddCourse.Visible = false;
            pnlViewCourse.Visible = true;
            BindCourseDetails();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtCourseName.Text = string.Empty;
        }

        protected void btnViewCourse_Click(object sender, EventArgs e)
        {
            pnlAddCourse.Visible = false;
            pnlViewCourse.Visible = true;
            BindCourseDetails();
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            pnlAddCourse.Visible = true;
            pnlViewCourse.Visible = false;
            btnSubmit.Text = "Submit";
            ClearAll();
        }

        private void BindCourseDetails()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = "select CourseId,CourseName from CourseDetails";
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                gvCourseDetails.DataSource = dt;
                gvCourseDetails.DataBind();
            }
            _sConn.Close();
        }

        protected void gvCourseDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvCourseDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int courseId = int.Parse(gvCourseDetails.DataKeys[index]["CourseId"].ToString());
                Application["CourseID"] = courseId;
               
                txtCourseName.Text = gvCourseDetails.Rows[index].Cells[0].Text.ToString();
                
                btnSubmit.Text = "Update";
                pnlAddCourse.Visible = true;
                pnlViewCourse.Visible = false;
            }
        }
    }
}