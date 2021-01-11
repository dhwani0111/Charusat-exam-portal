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
    public partial class AddTeachersDetails : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCourse();
                BindAllTeachers();
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
            ddlCourse.DataSource = dt;
            ddlCourse.DataTextField = "CourseName";
            ddlCourse.DataValueField = "CourseId";
            ddlCourse.DataBind();

            _sConn.Close();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string TeachersName = txtTeacher.Text.ToString();
            string Qualification = txtQualification.Text.ToString();
            string ContactNo = txtContactNumber.Text.ToString();
            string Address = txtAddress.Text.ToString();
            int salary = int.Parse(txtSalary.Text.ToString());
            string EmailId = txtEmailId.Text.ToString();
            string Gender = "Male";
            string password = txtPassword.Text.ToString();
            if (rbFemale.Checked == true)
            {
                Gender = "Female";
            }

            int CourseId = int.Parse(ddlCourse.SelectedValue.ToString());

            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = string.Empty;
            if (btnSubmit.Text == "Submit")
            {
                sQuery = " insert into TeachersDetails(TeachersName,Qualification,ContactNo,Address,Salary,EmailId,Gender,CourseId,Password) values ('" + TeachersName + "','" + Qualification + "','" + ContactNo + "','" + Address + "'," + salary + ",'" + EmailId + "','" + Gender + "'," + CourseId + ",'" + password + "')";
              

            }
            else if (btnSubmit.Text == "Update")
            {
                int TeachersId = int.Parse(Application["TeachersID"].ToString());
                sQuery = "update TeachersDetails set TeachersName='" + TeachersName + "', Qualification='" + Qualification + "',ContactNo='" + ContactNo + "',Address='" + Address + "',Salary=" + salary + ",EmailId='" + EmailId + "',Password='" + password + "' where TeachersId=" + TeachersId;
                
            }
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
            //SENDING SMS
            string msg = "Dear " + TeachersName + " You are Registered to Online Examination System. Check you email for login details.";
            Application["msg"] = msg;
            string url = "http://59.162.167.52/api/MessageCompose?admin=sms4projects.com@gmail.com&user=jayashreek248@yahoo.in:JAYU&senderID=TEST SMS&receipientno=" + ContactNo + "&msgtxt=" + msg + "&state=4";

            var req = (HttpWebRequest)WebRequest.Create(url);
            var res = (HttpWebResponse)req.GetResponse();




            //SENDING MAIL
            var fromAddress = "deepashankar1994@gmail.com";
            var toAddress = EmailId;
            string subject = "Online Examination System";
            const string fromPassword = "babyshankar";
            string body = "To : " + TeachersName + " \n";
            body += "Mobile No : " + ContactNo + "\n";
            body += "Subject : Online Examination System";
            body += "Description : Dear " + TeachersName + ", You are successfully registered in Online Examination System. Your login details are  Username : " + EmailId + " and Password : " + password;
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
            pnlAddTeachers.Visible = false;
            pnlViewTeachers.Visible = true;
            BindAllTeachers();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();

        }
        private void ClearAll()
        {
            txtTeacher.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtEmailId.Text = string.Empty;
        }

        protected void btnViewTeachers_Click(object sender, EventArgs e)
        {
            pnlAddTeachers.Visible = false;
            pnlViewTeachers.Visible = true;
            BindAllTeachers();

        }

        protected void btnAddTeachers_Click(object sender, EventArgs e)
        {
            pnlAddTeachers.Visible = true;
            pnlViewTeachers.Visible = false;
            btnSubmit.Text = "Submit";
            ClearAll();

        }

        private void BindAllTeachers()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int courseId = int.Parse(ddlCourse.SelectedValue.ToString());
            string sQuery = "select TeachersId,TeachersName,Qualification,ContactNo,Salary from TeachersDetails where courseId=" + courseId;
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                gvTeachersDetails.DataSource = dt;
                gvTeachersDetails.DataBind();
                lblNoRecords.Visible = false;
            }
            else
            {
                gvTeachersDetails.DataSource = null;
                gvTeachersDetails.DataBind();
                lblNoRecords.Visible = true;

            }
            _sConn.Close();
        }

        protected void gvTeachersDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvTeachersDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int teacherId = int.Parse(gvTeachersDetails.DataKeys[index]["TeachersId"].ToString());
                Application["TeachersID"] = teacherId;
                BindTeacherDetails(teacherId);
                //txtTeacher.Text = gvTeachersDetails.Rows[index].Cells[0].Text.ToString();
                //txtQualification.Text = gvTeachersDetails.Rows[index].Cells[1].Text.ToString();
                //txtContactNumber.Text = gvTeachersDetails.Rows[index].Cells[2].Text.ToString();
                //txtSalary.Text = gvTeachersDetails.Rows[index].Cells[3].Text.ToString();
                btnSubmit.Text = "Update";
                pnlAddTeachers.Visible = true;
                pnlViewTeachers.Visible = false;
            }
        }

        private void BindTeacherDetails(int teacherId)
        {
            string sQuery = "select TeachersName,Qualification,ContactNo,Address,Salary,EmailId,Gender from TeachersDetails where TeachersId=" + teacherId;
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtAddress.Text = dr["Address"].ToString();
                    txtEmailId.Text = dr["EmailId"].ToString();
                    txtQualification.Text = dr["Qualification"].ToString();
                    txtContactNumber.Text = dr["ContactNo"].ToString();
                    txtSalary.Text = dr["Salary"].ToString();
                    txtTeacher.Text = dr["TeachersName"].ToString();
                    rbMale.Checked = true;
                    string gender = dr["Gender"].ToString();
                    if (gender == "Female")
                    {
                        rbFemale.Checked = true;
                        rbMale.Checked = false;
                    }
                   
                }
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAllTeachers();
        }


    }
}