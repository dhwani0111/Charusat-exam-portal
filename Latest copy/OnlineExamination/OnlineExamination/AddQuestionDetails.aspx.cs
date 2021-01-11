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
    public partial class AddQuestionDetails : System.Web.UI.Page
    {

        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCourse();
                BindSubject();
                BindQuestionDetails();
                CheckForTotalQuestions();
                pnlAddQuestion.Visible = false;
            }
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

        public void BindSubject()
        {

            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int courseId = 0;
            if (ddlCourse.Items.Count > 0)
            {
                courseId = int.Parse(ddlCourse.SelectedValue.ToString());
            }
            string semester = ddlSemester.SelectedValue.ToString();
            string sQuery = "select SubjectId,SubjectName from SubjectDetails where CourseId=" + courseId + " and Semester='" + semester + "'";
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlSubject.DataSource = dt;
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectId";
            ddlSubject.DataBind();

            _sConn.Close();


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String Question = txtQuestion.Text.ToString();
            int SubjectId = int.Parse(ddlSubject.SelectedValue.ToString());
            string Semester = ddlSemester.SelectedValue.ToString();
            int courseId = int.Parse(ddlCourse.SelectedValue.ToString());
            
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = String.Empty;
            if (btnSubmit.Text == "Submit")
            {
               sQuery = "insert into QuestionDetails(Question,SubjectId,Semester,CourseId) values ('" + Question + "'," + SubjectId + ",'" + Semester + "'," + courseId + ")";
            }
            else if (btnSubmit.Text == "Update")
            {
            
                int questionId = int.Parse(Application["QuestionID"].ToString());
                sQuery = "update QuestionDetails set Question='" + Question + "' where QuestionId=" + questionId;
            }
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
            _sConn.Close();
            ClearAll();
            pnlAddQuestion.Visible = false;
            pnlViewQuestion.Visible = true;
            BindQuestionDetails();
            CheckForTotalQuestions();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
            
        }

        private void ClearAll()
        {
            txtQuestion.Text = String.Empty;

        }

        protected void btnViewQuestion_Click(object sender, EventArgs e)
        {
            pnlAddQuestion.Visible = false;
            pnlViewQuestion.Visible = true;
            BindQuestionDetails();
            lblComplete.Visible = false;
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            pnlViewQuestion.Visible = false;
            pnlAddQuestion.Visible = true;
            btnSubmit.Text = "Submit";
            ClearAll();
            CheckForTotalQuestions();
        }

        private void BindQuestionDetails()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int subjectId = 0;
            if (ddlSubject.Items.Count > 0)
            {
                subjectId = int.Parse(ddlSubject.SelectedValue.ToString());
                int courseId = int.Parse(ddlCourse.SelectedValue.ToString());
                string semester = ddlSemester.SelectedValue.ToString();
                string sQuery = "select QuestionId,Question  from QuestionDetails where SubjectId=" + subjectId + " and CourseId=" + courseId + " and semester='" + semester + "'";
                SqlCommand cmd = new SqlCommand(sQuery, _sConn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gvQuestionDetails.DataSource = dt;
                    gvQuestionDetails.DataBind();
                    lblNoRecords.Visible = false;
                }
                else
                {
                    gvQuestionDetails.DataSource = null;
                    gvQuestionDetails.DataBind();
                    lblNoRecords.Visible = true;
                }
                _sConn.Close();
            }
        }

        protected void gvQuestionDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvQuestionDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int QuestionId = int.Parse(gvQuestionDetails.DataKeys[index]["QuestionId"].ToString());
                Application["QuestionID"] = QuestionId;
                txtQuestion.Text = gvQuestionDetails.Rows[index].Cells[0].Text.ToString();
                btnSubmit.Text = "Update";
                pnlAddQuestion.Visible = true;
                pnlViewQuestion.Visible = false;
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();
            BindQuestionDetails();
            CheckForTotalQuestions();
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindQuestionDetails();
            CheckForTotalQuestions();
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();
            BindQuestionDetails();
            CheckForTotalQuestions();
        }

        private void CheckForTotalQuestions()
        {
            int subjectId = 0;
            if (ddlSubject.Items.Count > 0)
            {
                subjectId = int.Parse(ddlSubject.SelectedValue.ToString());
            }
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = "select QuestionId,Question from QuestionDetails where SubjectId=" + subjectId;
            SqlCommand cmd = new SqlCommand(sQuery,_sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count >= 10)
            {
                pnlAddQuestion.Visible = false;
                lblComplete.Visible = true;
            }
            else
            {
                pnlAddQuestion.Visible = true;
                lblComplete.Visible = false;
            }
        }
    }
}
   




    