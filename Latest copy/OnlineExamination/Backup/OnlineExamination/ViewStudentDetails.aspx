<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="ViewStudentDetails.aspx.cs" Inherits="OnlineExamination.ViewStudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
<br /><br />
<h1>VIEW STUDENT DETAILS</h1>
<br /><br />
<table width="800" bgcolor="#BCC7D8" align="center" style="color: #000000" 
            frame="box">
    <tr>
    <td>Select Course</td>
    <td>
        
        <asp:DropDownList ID="ddlSelectCourse" runat="server" 
            AppendDataBoundItems="True" AutoPostBack="True" 
            onselectedindexchanged="ddlSelectCourse_SelectedIndexChanged" Width="150px">
            <asp:ListItem Value="0">All</asp:ListItem>
        </asp:DropDownList>
        
        </td></tr></table>
<br /><br />

    <asp:GridView ID="gvStudentDetails" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" Width="800px" 
            onrowcommand="gvStudentDetails_RowCommand" 
            onrowediting="gvStudentDetails_RowEditing" DataKeyNames="StudentId" 
            AllowPaging="True" onpageindexchanging="gvStudentDetails_PageIndexChanging" 
            PageSize="5" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="RollNumber" HeaderText="Roll_No" />
            <asp:BoundField DataField="StudentName" HeaderText="Student_Name" />
            <asp:BoundField DataField="MobileNumber" HeaderText="Mobile_No" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="CourseName" HeaderText="Course" />
            <asp:BoundField DataField="HODName" HeaderText="HOD" />
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

<br /><br />

        <asp:Button ID="btnGetReport" runat="server" Text="Get Report" 
            onclick="btnGetReport_Click" />

<br /><br />
        <asp:Label ID="lblNorecords" runat="server" Text="Sorry No Records Found"
         Font-Bold="True" Font-Size="XX-Large"  Visible="False"
            ForeColor="Red"></asp:Label>
            <br /><br /><br />

</div>
</asp:Content>
