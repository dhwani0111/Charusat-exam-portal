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
    public partial class ViewStudentResult : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindStudentDetails();
                BindSubject();
                BindStudentResult();
                if (Session["ExamId"] != null)
                {
 
                }
            }
        }

        private void BindStudentDetails()
        {
            if (Session["StudentID"] != null)
            {
                int studentId = int.Parse(Session["StudentID"].ToString());
                if (_sConn.State != ConnectionState.Open)
                {
                    _sConn.Open();
                }
                string sQuery = "select a.StudentName,a.CourseId,b.CourseName from StudentDetails a join CourseDetails b on a.CourseId=b.CourseId where StudentId=" + studentId;
                SqlCommand cmd = new SqlCommand(sQuery, _sConn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblStudentName.Text = dr["StudentName"].ToString();
                        lblCourse.Text = dr["CourseName"].ToString();
                        Session["CourseID"] = dr["CourseId"].ToString();
                        
                        
                    }
                }
            }
        }

        private void BindSubject()
        {

            if (Session["CourseID"] != null)
            {
                if (_sConn.State != ConnectionState.Open)
                {
                    _sConn.Open();
                }
                int courseId = int.Parse(Session["CourseID"].ToString());
                string semester = ddlSemester.SelectedValue.ToString();
                string sQuery = "select SubjectId,SubjectName from SubjectDetails where semester='" + semester + "' and CourseId=" + courseId + "";
                SqlCommand cmd = new SqlCommand(sQuery, _sConn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ddlSelectSubject.Items.Clear();
                ddlSelectSubject.Items.Insert(0, new ListItem("Select Subject", "0"));
                if (dt.Rows.Count > 0)
                {
                    ddlSelectSubject.DataSource = dt;
                    ddlSelectSubject.DataTextField = "SubjectName";
                    ddlSelectSubject.DataValueField = "SubjectId";
                    ddlSelectSubject.DataBind();
                }

                _sConn.Close();

            }
        }

        private void BindStudentResult()
        {
            int subjectId = int.Parse(ddlSelectSubject.SelectedValue.ToString());
            int studentId = 0;
            studentId = int.Parse(Session["StudentID"].ToString());
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }

            string sQuery = "select c.Question,d.Answer,d.IsRight,b.Marks,convert(varchar(11),a.ExamDate,106) as ExamDate,e.ObtainedMark,e.Grade,e.Percentage from ExamMaster a left join ExamDetails b on a.ExamId=b.ExamId left join QuestionDetails c on b.QuestionId=c.QuestionId left join AnswerDetails d on b.AnswerId=d.AnswerId left join ResultDetails e on a.ExamId=e.ExamId where a.SubjectId=" + subjectId + " and a.StudentId=" + studentId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                pnlStudentResult.Visible = true;
                lblNotWrittenExam.Visible = false;
                gvStudentResult.DataSource = dt;
                gvStudentResult.DataBind();
                foreach (DataRow dr in dt.Rows)
                {
                    lblExamDate.Text = dr["ExamDate"].ToString();
                    lblTotal.Text = dr["ObtainedMark"].ToString();
                    lblGrade.Text = dr["Grade"].ToString();
                    lblPercentage.Text = dr["Percentage"].ToString();
                }
            }
            else
            {
                pnlStudentResult.Visible = false;
                lblNotWrittenExam.Visible = true;
            }
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();
        }

        protected void ddlSelectSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStudentResult();
        }

        protected void gvStudentResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string isRight = e.Row.Cells[2].Text.ToString();
                if (isRight == "True")
                {
                    e.Row.Cells[2].Text = "Yes";
                }
                else
                {
                    e.Row.Cells[2].Text = "No";
                    e.Row.Cells[2].BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}