using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;

namespace OnlineExamination
{
    public partial class WriteExam : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSubject();
                BindQuestions();
                bool isWritten = CheckForExam();
                if (isWritten == true)
                {
                    btnViewResult.Visible = true;
                    divIsWritten.Visible = false;
                    btnTimeout.Visible = false;
                    btnSubmit.Visible = false;
                    lblWritten.Visible = true;
                    lblWritten.Text = "You are already written this exam.";
                }
            }
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();
            bool isWritten = CheckForExam();
            if (isWritten == true)
            {
                btnViewResult.Visible = true;
                divIsWritten.Visible = false;
                btnTimeout.Visible = false;
                btnSubmit.Visible = false;
                lblWritten.Visible = true;
                lblWritten.Text = "You are already written this exam.";
            }
            else
            {
                BindQuestions();
            }
        }

        private int GetCourseId()
        {
            int courseId = 0;
            if (Session["StudentID"] != null)
            {
                if (_sConn.State != ConnectionState.Open)
                {
                    _sConn.Open();
                }
                int studentId = int.Parse(Session["StudentID"].ToString());
                string sQuery = "select CourseId from StudentDetails where StudentId=" + studentId;
                SqlCommand cmd = new SqlCommand(sQuery, _sConn);
                courseId = int.Parse(cmd.ExecuteScalar().ToString());
            }
            return courseId;
        }

        private void BindSubject()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int courseId = GetCourseId();
            string semester = ddlSemester.SelectedValue.ToString();
            string sQuery = "select SubjectId,SubjectName from SubjectDetails where Semester='" + semester + "' and CourseId=" + courseId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlSubject.Items.Clear();
            ddlSubject.Items.Insert(0, new ListItem("Select Subject", "0"));
            if (dt.Rows.Count > 0)
            {
                ddlSubject.DataSource = dt;
                ddlSubject.DataTextField = "SubjectName";
                ddlSubject.DataValueField = "SubjectId";
                ddlSubject.DataBind();
            }
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isWritten = CheckForExam();
            if (isWritten == true)
            {
                btnViewResult.Visible = true;
                divIsWritten.Visible = false;
                btnTimeout.Visible = false;
                btnSubmit.Visible = false;
                lblWritten.Visible = true;
                lblWritten.Text = "You are already written this exam.";
            }
            else
            {
                BindQuestions();
            }
        }

        private bool CheckForExam()
        {
            btnViewResult.Visible = false;
            divIsWritten.Visible = true;
            btnTimeout.Visible = true;
            btnSubmit.Visible = true;
            lblWritten.Visible = false;
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            bool isWritten = false;
            int subjectId = int.Parse(ddlSubject.SelectedValue.ToString());
            int studentId = int.Parse(Session["StudentID"].ToString());
            string sQuery = "select ExamId,ExamDate,IsPassed from  ExamMaster where StudentId=" + studentId + " and SubjectId=" + subjectId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                btnViewResult.Visible = true;
                divIsWritten.Visible = false;
                btnTimeout.Visible = false;
                btnSubmit.Visible = false;
                lblWritten.Visible = true;
                lblWritten.Text = "You are already written this exam.";

                isWritten = true;
                foreach (DataRow dr in dt.Rows)
                {
                    int examId = int.Parse(dr["ExamId"].ToString());
                    Session["ExamID"] = examId;
                    bool isPassed = bool.Parse(dr["IsPassed"].ToString());
                    if (isPassed == false)
                    {
                        DateTime examDate = DateTime.Parse(dr["ExamDate"].ToString());
                        bool canWrite = CheckForExamDate(examDate);
                        if (canWrite == true)
                        {
                            isWritten = false;
                            DeleteExam(examId);
                        }
                    }
                }
            }
            return isWritten;
        }

        private void DeleteExam(int examId)
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = "delete from ResultDetails where ExamId=" + examId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
            sQuery = "delete from ExamDetails where ExamId=" + examId;
            cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
            sQuery = "delete from ExamMaster where ExamId=" + examId;
            cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
        }

        private bool CheckForExamDate(DateTime examDate)
        {
            bool canWrite=false;
            DateTime nowDate = DateTime.Now;
            string days = (nowDate - examDate).TotalDays.ToString();
            decimal diffDays = decimal.Parse(days);
            if (diffDays > 10)
            {
                canWrite = true;
            }
            return canWrite;
        }

        private void BindQuestions()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int subjectId = int.Parse(ddlSubject.SelectedValue.ToString());
            string sQuery = "select QuestionId,Question from QuestionDetails where SubjectId=" + subjectId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                divIsWritten.Visible = true;
                dlExam.DataSource = dt;
                dlExam.DataBind();
                lblWritten.Text = "You are already written this exam.";
                lblWritten.Visible = false;
            }
            else
            {
                divIsWritten.Visible = false;
                dlExam.DataSource = null;
                dlExam.DataBind();
                lblWritten.Text = "Sorry this exam is not generated.";
                lblWritten.Visible = true;
            }
        }

        protected void dlExam_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            RadioButtonList rblAnswers = (RadioButtonList)e.Item.FindControl("rblAnswers");
            int questionId = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "QuestionID"));

            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = "select AnswerId,Answer from AnswerDetails where QuestionId=" + questionId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rblAnswers.DataSource = dt;
                rblAnswers.DataTextField = "Answer";
                rblAnswers.DataValueField = "AnswerId";
                rblAnswers.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int totalMarks = 0;
            int studentId = int.Parse(Session["StudentID"].ToString());
            int subjectId = int.Parse(ddlSubject.SelectedValue.ToString());
            string semester = ddlSemester.SelectedValue.ToString();
            Session["SubjectID"] = subjectId;
            Session["Semester"] = semester;
            DateTime nowdate = DateTime.Now;
            string examDate = nowdate.ToString("MM/dd/yyyy");
            string sQuery = "insert into ExamMaster (ExamDate,StudentId,SubjectId) output inserted.ExamId values ('" + examDate + "'," + studentId + "," + subjectId + ")";
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            int examId = int.Parse(cmd.ExecuteScalar().ToString());
            foreach (DataListItem item in dlExam.Items)
            {
                Label lblQuestionId = (Label)item.FindControl("lblQuestionId");
                int questionId = int.Parse(lblQuestionId.Text.ToString());

                RadioButtonList rblAnswers = (RadioButtonList)item.FindControl("rblAnswers");
                int answerId = 0;
                string selectedValue = rblAnswers.SelectedValue.ToString();
                if (selectedValue != "")
                {
                    answerId = int.Parse(rblAnswers.SelectedValue.ToString());
                }
                else
                {
                    answerId = GetAnswerId(questionId);
                }

                sQuery = "select * from AnswerDetails where AnswerId=" + answerId + " and QuestionId=" + questionId;
                cmd = new SqlCommand(sQuery, _sConn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string isRight = "No";
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["IsRight"].ToString() == "True")
                        {
                            isRight = "Yes";
                        }
                    }
                }

                if (isRight == "Yes")
                {
                    totalMarks = totalMarks + 10;
                    sQuery = "insert into ExamDetails (AnswerId,ExamId,QuestionId,IsRight,Marks) values (" + answerId + "," + examId + "," + questionId + ",1,10)";
                }
                else
                {
                    sQuery = "insert into ExamDetails (AnswerId,ExamId,QuestionId,IsRight,Marks) values (" + answerId + "," + examId + "," + questionId + ",0,0)";
                }
                cmd = new SqlCommand(sQuery, _sConn);
                cmd.ExecuteNonQuery();

                //SendSms();
                //SendMail();
            }

            AddResult(totalMarks, examId);
            Session["SubjectID"] = subjectId;
            Session["Semester"] = semester;

            //Response.Redirect("ViewStudentResult.aspx");
            pnlResult.Visible = true;
            pnlWriteExam.Visible = false;
            btnViewResult.Visible = true;
            _sConn.Close();
        }

        private void SendSms()
        {
            string studentName = Session["StudentName"].ToString();
            string mobile = Session["MobileNumber"].ToString();

            string msg = "Dear " + studentName + " You are successfully written "+ddlSubject.SelectedItem.Text.ToString()+" exam. Check your mail for result."; 
            string url = "http://59.162.167.52/api/MessageCompose?admin=sms4projects.com@gmail.com&user=jayashreek248@yahoo.in:JAYU&senderID=TEST SMS&receipientno=" + mobile + "&msgtxt=" + msg + "&state=4";
            Response.Redirect(url);
        }

        private void SendMail()
        {
            var fromAddress = "deepashankar1994@gmail.com";
            string emailId = Session["EmailId"].ToString();
            var toAddress = emailId;
            string studentName = Session["StudentName"].ToString();
            string mobileNumber = Session["MobileNumber"].ToString();
            string subject = "Exam Result";
            const string fromPassword = "babyshankar";
            string body = "To : " + studentName + " \n";
            body += "From: Online Examination System \n";
            body += "Mobile No : " + mobileNumber + "\n";
            body += "Subject : Exam Result \n";
            body += "Description : Dear " + studentName + " your " + ddlSubject.SelectedItem.Text.ToString() + " exam result is like this \n";
            body += "Result :" + Session["Result"].ToString() + ". \n";
            body += "Toral Marks : " + Session["Marks"].ToString() + ". \n";
            body += "Percentage : " + Session["Percentage"].ToString() + ". \n";
            body += "Grade : " + Session["Grade"].ToString() + ". \n";
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            smtp.Send(fromAddress, toAddress, subject, body);
        }

        private int GetAnswerId(int questionId)
        {
            int answerId = 0;
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = "select max(AnswerId) as AnswerId from AnswerDetails where QuestionId=" + questionId + " and IsRight=0";
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    answerId = int.Parse(dr["AnswerId"].ToString());
                }
            }
            return answerId;
        }

        private void AddResult(int totalMarks, int examId)
        {
            int studentId = 0;
            int subjectId = 0;
            string result = "Fail";
            string grade = "C";
            string percentage = totalMarks + " %";

            if (Session["StudentID"] != null)
            {
                studentId = int.Parse(Session["StudentID"].ToString());
            }
            subjectId = int.Parse(ddlSubject.SelectedValue.ToString());
            if (totalMarks >= 80)
            {
                result = "Distinction";
                grade = "A+";
            }
            else if (totalMarks >= 70)
            {
                result = "1st Class";
                grade = "A";
            }
            else if (totalMarks >= 60)
            {
                result = "2nd Class";
                grade = "B+";
            }
            else if (totalMarks >= 50)
            {
                result = "3rd Class";
                grade = "B";
            }
            else if (totalMarks >= 40)
            {
                result = "Pass";
                grade = "C+";
            }
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            Session["Result"] = result;
            Session["Percentage"] = percentage;
            Session["Grade"] = grade;
            Session["Marks"] = totalMarks;

            string sQuery = "insert into ResultDetails(StudentId,SubjectId,Result,ObtainedMark,Grade,Percentage,ExamId) values (" + studentId + "," + subjectId + ",'" + result + "'," + totalMarks + ",'" + grade + "','" + percentage + "'," + examId + ")";
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
            if (result == "Fail")
            {
                sQuery = "update ExamMaster set IsPassed=0 where ExamId=" + examId;
            }
            else
            {
                sQuery = "update ExamMaster set IsPassed=1 where ExamId=" + examId;
            }

            cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
            _sConn.Close();

        }

        protected void btnTimeout_Click(object sender, EventArgs e)
        {

        }

        protected void btnViewResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewStudentResult.aspx");
        }
    }
}