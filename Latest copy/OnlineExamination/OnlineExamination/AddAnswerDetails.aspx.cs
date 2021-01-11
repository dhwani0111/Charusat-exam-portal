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
    public partial class AddAnswerDetails : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCourse();
                BindSubject();
                BindQuestion();
                BindAnswerDetails();
                CheckForTotalAnswers();
                pnlAddAnswer.Visible = false;
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

        public void BindQuestion()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int subjectId = 0;
            if (ddlSubject.Items.Count > 0)
            {
                subjectId = int.Parse(ddlSubject.SelectedValue.ToString());
            }

            string sQuery = "select QuestionId,Question from QuestionDetails where SubjectId=" + subjectId + " ";
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlQuestions.DataSource = dt;
            ddlQuestions.DataTextField = "Question";
            ddlQuestions.DataValueField = "QuestionId";
            ddlQuestions.DataBind();

            _sConn.Close();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string answer = txtAnswer.Text.ToString();
            int questionId = int.Parse(ddlQuestions.SelectedValue.ToString());
            int isRight = int.Parse(ddlIsright.SelectedValue.ToString());

            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = string.Empty;
            if (btnSubmit.Text == "submit")
            {
                sQuery = "insert into AnswerDetails(Answer,QuestionId,IsRight) values ('" + answer + "'," + questionId + "," + isRight + ")";

            }
            else if (btnSubmit.Text == "update")
            {
                int answerId = int.Parse(Application["AnswerID"].ToString());
                sQuery = "update AnswerDetails set Answer='" + answer + "',IsRight='" + isRight + "' where AnswerId=" + answerId;
            }

            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
            _sConn.Close();
            ClearAll();
            pnlAddAnswer.Visible = false;
            pnlViewAnswer.Visible = true;
            BindAnswerDetails();
            CheckForTotalAnswers();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();

        }
        private void ClearAll()
        {
            txtAnswer.Text = string.Empty;
        }

        protected void btnViewAnswer_Click(object sender, EventArgs e)
        {
            pnlAddAnswer.Visible = false;
            pnlViewAnswer.Visible = true;
            BindAnswerDetails();
            lblComplete.Visible = false;

        }

        protected void btnAddAnswer_Click(object sender, EventArgs e)
        {
            pnlAddAnswer.Visible = true;
            pnlViewAnswer.Visible = false;
            btnSubmit.Text = "submit";
            ClearAll();
            CheckForTotalAnswers();
        }

        private void BindAnswerDetails()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int QuestionId = 0;
            if (ddlQuestions.Items.Count > 0)
            {
                QuestionId = int.Parse(ddlQuestions.SelectedValue.ToString());
            }
            string sQuery = "select AnswerId,Answer,IsRight from AnswerDetails where QuestionId=" + QuestionId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                gvAnswerDetails.DataSource = dt;
                gvAnswerDetails.DataBind();
                lblNoRecords.Visible = false;
            }
            else
            {
                gvAnswerDetails.DataSource = null;
                gvAnswerDetails.DataBind();
                lblNoRecords.Visible = true;
            }
            _sConn.Close();

        }

        protected void gvAnswerDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvAnswerDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int AnswerId = int.Parse(gvAnswerDetails.DataKeys[index]["AnswerId"].ToString());
                Application["AnswerID"] = AnswerId;
                txtAnswer.Text = gvAnswerDetails.Rows[index].Cells[0].Text.ToString();
                //ddlIsright.SelectedValue=
                string isRight = gvAnswerDetails.Rows[index].Cells[1].Text.ToString();
                if (isRight == "True")
                {
                    ddlIsright.SelectedValue = "1";
                }
                else
                {
                    ddlIsright.SelectedValue = "0";
                }
                btnSubmit.Text = "update";
                pnlAddAnswer.Visible = true;
                pnlViewAnswer.Visible = false;
            }
        }

        protected void ddlQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAnswerDetails();
            CheckForTotalAnswers();
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindQuestion();
            BindAnswerDetails();
            CheckForTotalAnswers();
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();
            BindQuestion();
            BindAnswerDetails();
            CheckForTotalAnswers();
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();
            BindQuestion();
            BindAnswerDetails();
            CheckForTotalAnswers();
        }
        private void CheckForTotalAnswers()
        {

            int questionId = 0;
            if (ddlQuestions.Items.Count > 0)
            {
                questionId = int.Parse(ddlQuestions.SelectedValue.ToString());
            }
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = "select AnswerId,Answer from AnswerDetails where QuestionId=" + questionId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count >= 4)
            {
                pnlAddAnswer.Visible = false;
                lblComplete.Visible = true;
            }
            else
            {
                pnlAddAnswer.Visible = true;
                lblComplete.Visible = false;
            }
        }
    }
}