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
    public partial class AddSubjectsDetails : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCourse();
                BindTeacher();
                BindSubjectDetails();
            }
        }

        public void BindTeacher()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int courseId = int.Parse(ddlCourse.SelectedValue.ToString());
            String sQuery = "select TeachersId,TeachersName from TeachersDetails where CourseId=" + courseId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlTeacher.DataSource = dt;
            ddlTeacher.DataTextField = "TeachersName";
            ddlTeacher.DataValueField = "teachersId";
            ddlTeacher.DataBind();

            _sConn.Close();


        }


        public void BindCourse()
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
            ddlCourse.DataSource = dt;
            ddlCourse.DataTextField = "CourseName";
            ddlCourse.DataValueField = "CourseId";
            ddlCourse.DataBind();

            _sConn.Close();
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTeacher();
            BindSubjectDetails();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string SubjectName = txtSubjectName.Text.ToString();
            string SubjectCode = txtSubjectCode.Text.ToString();
            int TeachersId = int.Parse(ddlTeacher.SelectedValue.ToString());
            int CourseId = int.Parse(ddlCourse.SelectedValue.ToString());
            string semester = ddlSemester.SelectedValue.ToString();

            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = string.Empty;
            if (btnSubmit.Text == "Submit")
            {
                sQuery = "insert into SubjectDetails (SubjectCode,SubjectName,TeachersId,CourseId,Semester) values ('" + SubjectCode + "','" + SubjectName + "'," + TeachersId + "," + CourseId + ",'" + semester + "')";
            }
            else if (btnSubmit.Text == "Update")
            {
                int subjectId = int.Parse(Application["SubjectID"].ToString());
                sQuery = "update SubjectDetails set SubjectCode='" + SubjectCode + "', SubjectName='" + SubjectName + "', TeachersId=" + TeachersId + ", CourseId=" + CourseId + ",Semester='" + semester + "' where SubjectId=" + subjectId;
            }

            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
            _sConn.Close();
            ClearAll();
            pnlAddSubject.Visible = false;
            pnlviewSubject.Visible = true;
            BindSubjectDetails();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            txtSubjectName.Text = String.Empty;
            txtSubjectCode.Text = string.Empty;
        }

        protected void btnviewSubject_Click(object sender, EventArgs e)
        {
            pnlAddSubject.Visible = false;
            pnlviewSubject.Visible = true;
            BindSubjectDetails();           

        }

        protected void btnAddSubject_Click(object sender, EventArgs e)
        {
            pnlAddSubject.Visible = true;
            pnlviewSubject.Visible = false;
            btnSubmit.Text = "Submit";
            ClearAll();
            btnSubmit.Enabled = true;
            if (lblComplete.Visible == true)
            {
                btnSubmit.Enabled = false;
            }
        }

        private void BindSubjectDetails()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int courseId = int.Parse(ddlCourse.SelectedValue.ToString());
            string semester = ddlSemester.SelectedValue.ToString();
            string sQuery = "select a.SubjectId,a.SubjectCode,a.SubjectName,b.TeachersName,a.TeachersId from SubjectDetails a join TeachersDetails b on a.TeachersId=b.TeachersId where a.CourseId=" + courseId + " and a.Semester='" + semester + "'";
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                lblComplete.Visible = false;
                btnSubmit.Enabled = true;
                gvSubjectDetails.DataSource = dt;
                gvSubjectDetails.DataBind();
                lblNoRecords.Visible = false;
                if (dt.Rows.Count > 5)
                {
                    lblComplete.Visible = true;
                    btnSubmit.Enabled = false;
                }
            }
            else
            {
                gvSubjectDetails.DataSource = null;
                gvSubjectDetails.DataBind();
                lblNoRecords.Visible = true;
            }

        }

        protected void gvSubjectDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvSubjectDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int SubjectId = int.Parse(gvSubjectDetails.DataKeys[index]["SubjectId"].ToString());
                Application["SubjectID"] = SubjectId;
                txtSubjectName.Text = gvSubjectDetails.Rows[index].Cells[0].Text.ToString();
                txtSubjectCode.Text = gvSubjectDetails.Rows[index].Cells[1].Text.ToString();

                btnSubmit.Text = "Update";
                pnlAddSubject.Visible = true;
                pnlviewSubject.Visible = false;
                btnSubmit.Enabled = true;
            }
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubjectDetails();
        }
       
    }
}
