using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net;

namespace OnlineExamination
{
    public partial class AddStudentsDetails : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string password = txtPassword.Text.ToString();
            txtPassword.Attributes.Add("Value", password);
            txtConfirmPassword.Attributes.Add("Value", password);
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string studentName = txtStudentName.Text.ToString();
            string rollNumber = txtRollNo.Text.ToString();
            string address = txtAddress.Text.ToString();

            string dateOfbirth = DateTime.Parse(txtDateOfBirth.Text).ToString("MM/dd/yyyy");
            string dateOfJoin = DateTime.Parse(txtDateOfJoin.Text).ToString("MM/dd/yyyy");

            string mobileNumber = txtMobileNo.Text.ToString();
            string emailId = txtEmailId.Text.ToString();
            int courseId = int.Parse(ddlCourse.SelectedValue.ToString());
            string fatherName = txtFatherName.Text.ToString();
            string motherName = txtMotherName.Text.ToString();
            string bloodgroup = ddlBloodGroup.SelectedValue.ToString();
            string gender = rblGender.SelectedValue.ToString();
            decimal paidfees = decimal.Parse(txtPaidFees.Text.ToString());
            string admissionNumber = txtAdmissionNumber.Text.ToString();
            string userName = txtUserName.Text.ToString();
            string password = txtPassword.Text.ToString();

            string fileName = string.Empty;
            if (fuStudentImage.HasFile)
            {
                fileName = Path.GetFileName(fuStudentImage.FileName);
                fuStudentImage.SaveAs(Server.MapPath("~/StudentImage/" + fileName));
            }

            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = String.Empty;
            if (btnSubmit.Text == "Submit")
            {

                sQuery = "insert into StudentDetails(StudentName,RollNumber,Address,DateOfBirth,MobileNumber,EmailId,CourseId,FatherName,MotherName,BloodGroup,Gender,PaidFees,AdmissionNumber,DateOfJoin,IsActive,UserName,PassWord,StudentImage) values ('" + studentName + "','" + rollNumber + "','" + address + "','" + dateOfbirth + "','" + mobileNumber + "','" + emailId + "'," + courseId + ",'" + fatherName + "','" + motherName + "','" + bloodgroup + "','" + gender + "'," + paidfees + ",'" + admissionNumber + "','" + dateOfJoin + "',1,'" + userName + "','" + password + "','" + fileName + "')";
            }
            else if (btnSubmit.Text == "Update")
            {
                int studentId = int.Parse(Application["StudentID"].ToString());
                sQuery = "update  StudentDetails set RollNumber='" + rollNumber + "',StudentName='" + studentName + "',Address='" + address + "',MobileNumber='" + mobileNumber + "',AdmissionNumber='" + admissionNumber + "',FatherName='" + fatherName + "',MotherName='" + motherName + "',BloodGroup='" + bloodgroup + "',PaidFees=" + paidfees + ",Gender='" + gender + "',DateOfJoin='" + dateOfJoin + "' ,DateOfBirth='" + dateOfbirth + "',UserName='" + userName + "',PassWord='" + password + "'";

                if (fileName != string.Empty)
                {
                    sQuery = sQuery + " ,StudentImage='" + fileName + "'";
                }
                sQuery = sQuery + " where StudentId=" + studentId;
            }
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();


            //SENDING SMS
            string msg = "Dear " + studentName + " You are Registered Successfully. Now you Can write Exam through Online"; //Mobile number:" + mobileno + "Subject is:" + subject;
            Application["msg"] = msg;
            string url = "http://59.162.167.52/api/MessageCompose?admin=sms4projects.com@gmail.com&user=jayashreek248@yahoo.in:JAYU&senderID=TEST SMS&receipientno=" + mobileNumber + "&msgtxt=" + msg + "&state=4";

            var req = (HttpWebRequest)WebRequest.Create(url);
            var res = (HttpWebResponse)req.GetResponse();

            //SENDING MAIL
            var fromAddress = "deepashankar1994@gmail.com";
            var toAddress = emailId;
            string subject = "Online Examination System";
            const string fromPassword = "babyshankar";
            string body = "To : " + studentName + " \n";
            body += "Mobile No : " + mobileNumber + "\n";
            body += "Subject : Online Examination System";
            body += "Description : Dear " + studentName + ", You are successfully registered in Online Examination System. Your login details are Username : " + userName + " and Password : " + password;
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
            
            _sConn.Close();
            ClearAll();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            string password= string.Empty;
            txtPassword.Attributes.Add("Value", password);
            txtConfirmPassword.Attributes.Add("Value", password);
            txtAddress.Text = string.Empty;
            txtAdmissionNumber.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtDateOfBirth.Text = string.Empty;
            txtDateOfJoin.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtMotherName.Text = string.Empty;
            txtPaidFees.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtRollNo.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            txtUserName.Text = string.Empty;
        }

        protected void btnViewStudent_Click(object sender, EventArgs e)
        {

            pnlAddStudent.Visible = false;
            pnlViewStudent.Visible = true;
            BindStudentDetails();
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            pnlAddStudent.Visible = true;
            pnlViewStudent.Visible = false;
            btnSubmit.Text = "Submit";
            ClearAll();
        }

        private void BindStudentDetails()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }

            string sQuery = "select StudentId,StudentName,RollNumber,MobileNumber, Address from StudentDetails";
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                gvStudentRegistration.DataSource = dt;
                gvStudentRegistration.DataBind();
                lblNoRecords.Visible = false;
            }
            else
            {
                gvStudentRegistration.DataSource = null;
                gvStudentRegistration.DataBind();
                lblNoRecords.Visible = true;

            }
            _sConn.Close();
        }

        protected void gvStudentRegistration_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvStudentRegistration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int StudentId = int.Parse(gvStudentRegistration.DataKeys[index]["StudentId"].ToString());
                Application["StudentID"] = StudentId;
                BindStudents(StudentId);
                txtRollNo.Text = gvStudentRegistration.Rows[index].Cells[0].Text.ToString();
                txtStudentName.Text = gvStudentRegistration.Rows[index].Cells[1].Text.ToString();
                txtMobileNo.Text = gvStudentRegistration.Rows[index].Cells[2].Text.ToString();
                txtAddress.Text = gvStudentRegistration.Rows[index].Cells[3].Text.ToString();
                btnSubmit.Text = "Update";
                pnlAddStudent.Visible = true;
                pnlViewStudent.Visible = false;



            }
        }

        private void BindStudents(int StudentId)
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }

            string sQuery = "select StudentName,RollNumber,MobileNumber,Address,UserName,DateOfBirth,FatherName,MotherName,EmailId,CourseId,Gender,BloodGroup,DateOfJoin,PaidFees,AdmissionNumber from StudentDetails  where StudentId=" + StudentId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtStudentName.Text = dr["StudentName"].ToString();
                    txtRollNo.Text = dr["RollNumber"].ToString();
                    txtMobileNo.Text = dr["MobileNumber"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    txtUserName.Text = dr["UserName"].ToString();
                    txtDateOfBirth.Text = dr["DateOfBirth"].ToString();
                    txtDateOfJoin.Text = dr["DateOfJoin"].ToString();
                    txtEmailId.Text = dr["EmailId"].ToString();
                    txtFatherName.Text = dr["FatherName"].ToString();
                    txtMotherName.Text = dr["MotherName"].ToString();
                    txtPaidFees.Text = dr["PaidFees"].ToString();
                    txtAdmissionNumber.Text = dr["AdmissionNumber"].ToString();
                    
                }
            }

        }

    }
}