<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="OnlineExamination.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    

<div align="center">

<br /><br /><br />
   

<br /><br /><br />

<table width="400" style="color: #000000">
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>User Type</td>
        <td>
            <asp:DropDownList ID="ddlUserType" runat="server" Width="200px" 
                BackColor="Transparent">
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Student</asp:ListItem>
                <asp:ListItem>Staff</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>Username</td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" Width="200px" AutoComplete="off" 
                BackColor="Transparent"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1"></td>
        <td class="style1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtUsername" ErrorMessage="Enter Username" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Password</td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px" 
                AutoComplete="off" BackColor="Transparent"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="lblInvalid" runat="server" Font-Bold="False" Font-Size="Small" 
                ForeColor="Red" Text="Invalid Login" Visible="False"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtPassword" ErrorMessage="Enter Password" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnLogin" class="btn" runat="server" Text="Login" Width="100px" 
                onclick="btnLogin_Click" style ="background-color:aqua"/>
        </td>
    </tr>
</table>

<br /><br /><br /><br /><br />

</div>

</ContentTemplate>
    </asp:UpdatePanel>
  
</asp:Content>
