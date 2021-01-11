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
<td align="left"></td>
<td></td>
</tr>
<tr>
<td style="color: #000000; " align="left">Student name</td>
<td>
    <asp:TextBox ID="txtStudentName" runat="server" Width="150px"></asp:TextBox>
    </td>
<td style="color: #000000; " align="left">UserName</td>
<td>
    <asp:TextBox ID="txtUserName" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtStudentName" ErrorMessage="Enter Student name" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtUserName" ErrorMessage="Enter User Name" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">Password</td>
<td>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
    </td>
<td style="color: #000000; " align="left">Confirm Password</td>
<td style="margin-left: 40px">
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" 
        Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtPassword" ErrorMessage="Enter PassWord" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
<td align="left">&nbsp;</td>
<td style="margin-left: 40px">
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToValidate="txtConfirmPassword" 
        ErrorMessage="PassWord Does not match" ForeColor="Red" 
        ControlToCompare="txtPassword"></asp:CompareValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">RollNo</td>
<td>
    <asp:TextBox ID="txtRollNo" runat="server" Width="150px"></asp:TextBox>
    </td>
<td style="color: #000000; " align="left">Address</td>
<td style="margin-left: 40px">
    <asp:TextBox ID="txtAddress" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtRollNo" ErrorMessage="Enter RollNo" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
<td align="left">&nbsp;</td>
<td style="margin-left: 40px">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtAddress" ErrorMessage="Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">DateOfBirth</td>
<td>
    <asp:TextBox ID="txtDateOfBirth" runat="server" Width="150px"></asp:TextBox>
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateOfBirth" Format="dd/MMM/yyyy">
    </asp:CalendarExtender>
    </td>
<td style="color: #000000; " align="left">MobileNo</td>
<td style="margin-left: 120px">
    <asp:TextBox ID="txtMobileNo" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="txtDateOfBirth" ErrorMessage="Enter DateOfBirth" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
<td align="left">&nbsp;</td>
<td style="margin-left: 120px">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
        ControlToValidate="txtMobileNo" ErrorMessage="Enter MobileNo" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">EmailId</td>
<td>
    <asp:TextBox ID="txtEmailId" runat="server" Width="150px"></asp:TextBox>
    </td>
<td style="color: #000000; " align="left">Course</td>
<td style="margin-left: 240px">
    <asp:DropDownList ID="ddlCourse" runat="server" Width="150px" >
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
        ControlToValidate="txtEmailId" ErrorMessage="Enter EmailId" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
<td align="left">&nbsp;</td>
<td style="margin-left: 240px">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
        ControlToValidate="ddlCourse" ErrorMessage="Enter Course" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">Father Name</td>
<td>
    <asp:TextBox ID="txtFatherName" runat="server" Width="150px"></asp:TextBox>
    </td>
<td style="color: #000000; " align="left">MotherName</td>
<td style="margin-left: 240px">
    <asp:TextBox ID="txtMotherName" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
        ControlToValidate="txtFatherName" ErrorMessage="Enter Father Name" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
<td align="left">&nbsp;</td>
<td style="margin-left: 240px">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
        ControlToValidate="txtMotherName" ErrorMessage="Enter MotherName" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000; " align="left">Blood Group</td>
<td>
    <asp:DropDownList ID="ddlBloodGroup" runat="server" Width="150px">
        <asp:ListItem Value="O +">O +ve</asp:ListItem>
        <asp:ListItem Value="O -">O -ve</asp:ListItem>
        <asp:ListItem Value="A +">A +ve</asp:ListItem>
        <asp:ListItem Value="A -">A -ve</asp:ListItem>
        <asp:ListItem Value="AB +">AB +ve</asp:ListItem>
        <asp:ListItem Value="AB -">AB -ve</asp:ListItem>
        <asp:ListItem Value="B +">B +ve</asp:ListItem>
        <asp:ListItem Value="B -">B -ve</asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </asp:DropDownList>
    </td>
<td style="color: #000000" align="left">Gender</td>
<td style="margin-left: 280px">
    <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True">Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
        ControlToValidate="ddlBloodGroup" ErrorMessage="Enter Blood Group" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
<td align="left">&nbsp;</td>
<td style="margin-left: 280px">
    &nbsp;</td>
</tr>
<tr>
<td style="color: #000000; " align="left">Paid Fees</td>
<td>
    <asp:TextBox ID="txtPaidFees" runat="server" Width="150px"></asp:TextBox>
    </td>
<td style="color: #000000; " align="left">AdmissionNumber</td>
<td style="margin-left: 440px">
    <asp:TextBox ID="txtAdmissionNumber" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
        ControlToValidate="txtPaidFees" ErrorMessage="Enter Paid Fees" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
<td align="left">&nbsp;</td>
<td style="margin-left: 320px">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
        ControlToValidate="txtAdmissionNumber" ErrorMessage="Enter AdmissionNumber" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td align="left">DateOfJoin</td>
<td>
    <asp:TextBox ID="txtDateOfJoin" runat="server" Width="150px"></asp:TextBox>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateOfJoin" Format="dd/MMM/yy">

    </asp:CalendarExtender>
    </td>
<td align="left">Student Image</td>
<td style="margin-left: 320px">
    <asp:FileUpload ID="fuStudentImage" runat="server" />
    </td>
</tr>
<tr>
<td align="left">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
        ControlToValidate="txtDateOfJoin" ErrorMessage="Enter DateOfJoin" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
<td align="left">&nbsp;</td>
<td style="margin-left: 320px">
    &nbsp;</td>
</tr>
<tr>
<td style="color: #000000; font-size: medium" align="left">&nbsp;</td>
<td>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" 
        onclick="btnSubmit_Click"  />
    </td>
<td align="left">
    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="100px" 
        onclick="btnReset_Click" CausesValidation="False" />
    </td>
<td style="margin-left: 320px">
    </td>
</tr>
<tr>
<td style="color: #000000; font-size: medium" align="left">&nbsp;</td>
<td>
    &nbsp;</td>
<td align="left">
    &nbsp;</td>
<td style="margin-left: 320px">
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
                <asp:BoundField DataField="MobileNumber" HeaderText="Mobile_No" 
                    ReadOnly="True" />
                <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="True" />
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
