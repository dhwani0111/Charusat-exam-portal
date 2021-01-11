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
            string emailId = txtEmailId.Text.ToString();
            int courseId = int.Parse(ddlCourse.SelectedValue.ToString());
            string userName = txtUserName0.Text.ToString();
            string password = txtPassword.Text.ToString();

            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = String.Empty;
            if (btnSubmit0.Text == "Submit")
            {

                sQuery = "insert into StudentDetails(StudentName,RollNumber,EmailId,CourseId,IsActive,UserName,PassWord) values ('" + studentName + "','" + rollNumber + "','" + emailId + "'," + courseId + ",1,'" + userName + "','" + password + "')";
            }
            else if (btnSubmit0.Text == "Update")
            {
                int studentId = int.Parse(Application["StudentID"].ToString());
                sQuery = "update  StudentDetails set RollNumber='" + rollNumber + "',StudentName='" + studentName + "',UserName='" + userName + "',PassWord='" + password + "'";

            }
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();
                   
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
                     
            txtEmailId.Text = string.Empty;           
            txtPassword.Text = string.Empty;
            txtRollNo.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            txtUserName0.Text = string.Empty;
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
            btnSubmit0.Text = "Submit";
            ClearAll();
        }

        private void BindStudentDetails()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }

            string sQuery = "select StudentId,StudentName,RollNumber from StudentDetails";
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
                btnSubmit0.Text = "Update";
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

            string sQuery = "select StudentName,RollNumber,UserName,EmailId,CourseId from StudentDetails  where StudentId=" + StudentId;
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
                    txtUserName0.Text = dr["UserName"].ToString();           
                    txtEmailId.Text = dr["EmailId"].ToString();
                    
                    
                }
            }

        }

    }
}