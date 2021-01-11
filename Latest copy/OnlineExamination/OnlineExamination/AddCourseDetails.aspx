<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="AddCourseDetails.aspx.cs" Inherits="OnlineExamination.AddCourseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
        .style2
        {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center">

    <br /><br /><br />

    <h1>MANAGE COURSE DETAILS</h1>
    <br /><br />
        <asp:Button ID="btnViewCourse" runat="server" Text="View Course" 
            CausesValidation="False" onclick="btnViewCourse_Click" Width="150px" />
        <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" 
            CausesValidation="False" onclick="btnAddCourse_Click" Width="150px" />
    <br /><br />
        <asp:Panel ID="pnlAddCourse" runat="server" Visible="false">
            <table width="400" bgcolor="#BCC7D8" style="color: #000000" dir="ltr" 
                frame="box">
    <tr>
<td align="left" style="color: #000000"></td>
<td></td>
</tr>
<tr>
<td style="color: #000000; " align="left">Course Name</td>
<td>
    <asp:TextBox ID="txtCourseName" runat="server" Width="200px"></asp:TextBox>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left" class="style1"></td>
<td class="style1">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtCourseName" ErrorMessage="Enter Course Name" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" 
        onclick="btnSubmit_Click" />
    &nbsp;</td>
<td>
    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="100px" 
        onclick="btnReset_Click" CausesValidation="False" />
    </td>
</tr></table>
        </asp:Panel>
        <br /><br />

        <asp:Panel ID="pnlViewCourse" runat="server">
            <asp:GridView ID="gvCourseDetails" runat="server" AutoGenerateColumns="False" 
                ForeColor="#333333" Width="600px" DataKeyNames="CourseId" 
                onrowcommand="gvCourseDetails_RowCommand" 
                onrowediting="gvCourseDetails_RowEditing">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="CourseName" HeaderText="Course_Name" 
                        ReadOnly="True" />
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </asp:Panel>
        <br /><br /><br />



</div>
</asp:Content>
