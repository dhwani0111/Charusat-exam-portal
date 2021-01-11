using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamination
{
    public partial class OnlineExaminationMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbLogin.Text = "Login";
            liTeacher.Visible = false;
            liStudent.Visible = false;
            liCourse.Visible = false;
            liSubject.Visible = false;
            liQuestion.Visible = false;
            liAnswer.Visible = false;
            liStudentProfile.Visible = false;
            liViewResult.Visible = false;
            liViewStudentResult.Visible = false;
            liViewStudent.Visible = false;
            liWriteExam.Visible = false;

            if (Session["LoggedUser"] != null)
            {
                lbLogin.Text = "Logout";
                string loggedUser = Session["LoggedUser"].ToString();
                if (loggedUser == "Admin")
                {
                    liTeacher.Visible = true;
                    liStudent.Visible = true;
                    liCourse.Visible = true;
                    liSubject.Visible = true;
                    liQuestion.Visible = false;
                    liAnswer.Visible = false;
                    liViewResult.Visible = true;
                    liViewStudent.Visible = true;
                }
                else if (loggedUser == "Staff")
                {
                    liStudent.Visible = true;
                    liCourse.Visible = true;
                    liSubject.Visible = true;
                    liQuestion.Visible = true;
                    liAnswer.Visible = true;
                    liViewResult.Visible = true;
                    liViewStudent.Visible = true;
                }
                else if (loggedUser == "Student")
                {
                    liStudentProfile.Visible = true;
                    liWriteExam.Visible = true;
                    liViewStudentResult.Visible = true;
                }
            }
        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            if (lbLogin.Text == "Login")
            {
                Response.Redirect("LoginPage.aspx");
            }
            else if (lbLogin.Text == "Logout")
            {
                Response.Redirect("Logout.aspx");
            }
        }
    }
}