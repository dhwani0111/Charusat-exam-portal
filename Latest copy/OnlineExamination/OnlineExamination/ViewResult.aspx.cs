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
    public partial class ViewResult : System.Web.UI.Page
    {
        SqlConnection _sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["OES"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
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
            String SQuery = "select CourseId,CourseName from CourseDetails";
            SqlCommand cmd = new SqlCommand(SQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlSelectCourse.DataSource = dt;
            ddlSelectCourse.DataTextField = "CourseName";
            ddlSelectCourse.DataValueField = "CourseId";
            ddlSelectCourse.DataBind();

            _sConn.Close();
        }

        private void BindStudentDetails()
        {
            if (_sConn.State != ConnectionState.Open)
            {
                _sConn.Open();
            }
            int courseId = int.Parse(ddlSelectCourse.SelectedValue.ToString());
            string sQuery = "select a.StudentId,a.StudentName,a.RollNumber from StudentDetails a join CourseDetails b on a.CourseId=b.CourseId  where a.CourseId=" + courseId + "";
            SqlCommand cmd = new SqlCommand(sQuery, _sConn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["dt"] = dt;
                gvresult.DataSource = dt;
                gvresult.DataBind();
                lblNorecords.Visible = false;
                
            }
            else
            {
                gvresult.DataSource = null;
                gvresult.DataBind();
                lblNorecords.Visible = true;
                btnGetReport.Visible = false;

                _sConn.Close();
            }
        }

        protected void ddlSelectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStudentDetails();
        }

        protected void gvresult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int StudentId = int.Parse(gvresult.DataKeys[index]["StudentId"].ToString());
                Session["StudentID"] = StudentId;
                Response.Redirect("ViewStudentResult.aspx");
            }
        }
         protected void btnGetReport_Click(object sender, EventArgs e)
        {
            if (Session["dt"] != null)
            {
                DataTable dt = (DataTable)Session["dt"];
                ExportToExcel(dt);
            }
         }
        public void ExportToExcel(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string filename = "Result.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();

                dgGrid.DataSource = dt;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.AppendHeader(ConsoleColor.Blue.ToString(), "");
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;

                Response.Write(tw.ToString());
                Response.End();
            }
        }

       
        }

    }

