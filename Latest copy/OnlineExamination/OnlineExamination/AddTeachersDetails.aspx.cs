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
            string EmailId = txtEmailId.Text.ToString();            
            string password = txtPassword.Text.ToString();
           
            int CourseId = int.Parse(ddlCourse.SelectedValue.ToString());

            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            string sQuery = string.Empty;
            if (btnSubmit.Text == "Submit")
            {
                sQuery = " insert into TeachersDetails(TeachersName,EmailId,CourseId,Password) values ('" + TeachersName + "','" + EmailId + "'," + CourseId + ",'" + password + "')";
              

            }
            else if (btnSubmit.Text == "Update")
            {
                int TeachersId = int.Parse(Application["TeachersID"].ToString());
                sQuery = "update TeachersDetails set TeachersName='" + TeachersName + "',EmailId='" + EmailId + "',Password='" + password + "' where TeachersId=" + TeachersId;
                
            }
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            cmd.ExecuteNonQuery();       

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
            string sQuery = "select TeachersId,TeachersName from TeachersDetails where courseId=" + courseId;
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
                btnSubmit.Text = "Update";
                pnlAddTeachers.Visible = true;
                pnlViewTeachers.Visible = false;
            }
        }

        private void BindTeacherDetails(int teacherId)
        {
            string sQuery = "select TeachersName,EmailId from TeachersDetails where TeachersId=" + teacherId;
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
                    txtEmailId.Text = dr["EmailId"].ToString();
                    txtTeacher.Text = dr["TeachersName"].ToString();
                                    
                                    
                }
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAllTeachers();
        }


    }
}