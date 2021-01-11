<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="AddStudentsDetails.aspx.cs" Inherits="OnlineExamination.AddStudentsDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ToolkitScriptManager ID="Test" runat="server"></asp:ToolkitScriptManager>

<div align="center">

<br /><br />

<asp:Label ID="Label1" runat="server" Text="Manage Student Regisration" Font-Bold="True" 
        Font-Size="XX-Large"></asp:Label>

<br /><br />
    <asp:Button ID="btnViewStudent" runat= "server"  Text="ViewStudent" 
        CausesValidation="False" onclick="btnViewStudent_Click" />
    <asp:Button ID="btnAddStudent"  runat= "server"  Text="AddStudent" 
        CausesValidation="False" onclick="btnAddStudent_Click" />

    <br /><br />



    <asp:Panel ID="pnlAddStudent" runat="server" visible="false">
    
<table width="800" bgcolor="#BCC7D8" align="center" style="color: #000000" frame="box">
<tr>
<td align="left"></td>
<td></td>
</tr>
<tr>
<td style="color: #000000; " align="left">Student name</td>
<td>
    <asp:TextBox ID="txtStudentName" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtStudentName" ErrorMessage="Enter Student name" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">Password</td>
<td>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtPassword" ErrorMessage="Enter PassWord" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">RollNo</td>
<td>
    <asp:TextBox ID="txtRollNo" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtRollNo" ErrorMessage="Enter RollNo" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">UserName</td>
<td>
    <asp:TextBox ID="txtUserName0" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtUserName0" ErrorMessage="Enter User Name" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">EmailId</td>
<td>
    <asp:TextBox ID="txtEmailId" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
        ControlToValidate="txtEmailId" ErrorMessage="Enter EmailId" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">Course</td>
<td style="margin-left: 240px">
    <asp:DropDownList ID="ddlCourse" runat="server" Width="150px">
    </asp:DropDownList>
    </td>
</tr>
    <tr>
        <td align="left">&nbsp;</td>
        <td style="margin-left: 240px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Enter Course" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
<tr>
<td style="color: #000000; font-size: medium" align="left">
    <asp:Button ID="btnSubmit0" runat="server" onclick="btnSubmit_Click" Text="Submit" Width="100px" />
    </td>
<td>
    <asp:Button ID="btnReset0" runat="server" CausesValidation="False" onclick="btnReset_Click" Text="Reset" Width="100px" />
    </td>
</tr>
<tr>
<td style="color: #000000; font-size: medium" align="left">&nbsp;</td>
<td>
    &nbsp;</td>
</tr>
</table>
</asp:Panel>
<br /><br />


    <asp:Panel ID="pnlViewStudent" runat="server">
        <asp:GridView ID="gvStudentRegistration" runat="server" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Width="800px" 
            onrowcommand="gvStudentRegistration_RowCommand" 
            onrowediting="gvStudentRegistration_RowEditing" DataKeyNames="StudentId">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="RollNumber" HeaderText="Roll_No" ReadOnly="True" />
                <asp:BoundField DataField="StudentName" HeaderText="Student_Name" 
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
        <br /><br />
        <asp:Label ID="lblNoRecords" runat="server" Text="Sorry No Records Found"
         Font-Bold="True" Font-Size="XX-Large"  Visible="False" ForeColor="Red">
        </asp:Label>
    </asp:Panel>

<br />
    <br />
    <br />
</div>

</asp:Content>
