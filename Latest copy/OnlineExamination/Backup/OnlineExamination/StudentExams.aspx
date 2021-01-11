<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="StudentExams.aspx.cs" Inherits="OnlineExamination.StudentExams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
<br /><br />
<h1>View Student Exam Details</h1>
<br /><br />
    <asp:Panel ID="pnlStudentExam" runat="server">

    
    <asp:GridView ID="gvStudentExam" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="StudentId" ForeColor="#333333" Width="800px" 
            onrowcommand="gvStudentExam_RowCommand" 
            onrowediting="gvStudentExam_RowEditing">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="StudentName" HeaderText="Student_Name" 
                ReadOnly="True" />
            <asp:BoundField DataField="MobileNumber" HeaderText="Mobile_No" 
                ReadOnly="True" />
            <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="True" />
            <asp:BoundField DataField="CourseName" HeaderText="Course" ReadOnly="True" />
            <asp:ButtonField ButtonType="Button" CommandName="View" Text="View" />
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
