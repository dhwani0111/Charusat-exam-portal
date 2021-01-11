using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OnlineExamination
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["StudentId"] != null)
                {
                    string student = Session["StudentId"].ToString();
                    int studentId = int.Parse(student);
                    Application["StudentID "] = studentId;
                    BindStudentDetails(studentId);

                    if (Session["LoggedUser"] != null)
                    {
                        string loggedUser = Session["LoggedUser"].ToString();
                        if (loggedUser == "Student")
                        {
                            btncancel.Visible = false;
                        }
                        else
                        {
                            btncancel.Visible = true;
                        }
                    }
                }
            }
        }

        private void BindStudentDetails(int studentId)
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string query = "select a.StudentName,a.RollNumber,a.MobileNumber,convert(varchar(11),a.DateOfBirth,106) as DateOfBirth,convert(varchar(11),a.DateOfJoin,106) as DateOfJoin,a.MotherName,a.FatherName,a.Address,('~/StudentImage/'+a.StudentImage) as StudentImage,a.EmailId,a.PaidFees,a.AdmissionNumber,a.BloodGroup,a.Gender,a.CourseId,b.CourseName from StudentDetails a join CourseDetails b on a.CourseId=b.CourseId where StudentId=" + studentId;
            SqlCommand cmd = new SqlCommand(query, _sConn);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lblAddress.Text = dr["Address"].ToString();
                    lblName.Text = dr["StudentName"].ToString();
                    lblRollNo.Text = dr["RollNumber"].ToString();
                    lblDateOfJoin.Text = dr["DateOfJoin"].ToString();
                    lblDateOfBirth.Text = dr["DateOfBirth"].ToString();
                    lblEmailId.Text = dr["EmailId"].ToString();
                    lblFatherName.Text = dr["FatherName"].ToString();
                    lblMobileNo.Text = dr["MobileNumber"].ToString();
                    lblMotherName.Text = dr["MotherName"].ToString();
                    lblPaidFees.Text = dr["PaidFees"].ToString();
                    lblBloodGroup.Text = dr["BloodGroup"].ToString();
                    lblAdmissionNumber.Text = dr["AdmissionNumber"].ToString();
                    lblCourse.Text = dr["CourseName"].ToString();
                    lblGender.Text = dr["Gender"].ToString();
                    imgStudentImage.ImageUrl = dr["StudentImage"].ToString();
                    
                }
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewStudentDetails.aspx");
        }
    }
}