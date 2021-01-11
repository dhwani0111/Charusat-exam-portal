<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="OnlineExamination.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div align="center">

<br /><br /><br />

    <asp:Label ID="Label1" runat="server" Text="Admin Login Page" Font-Bold="True" 
        Font-Size="XX-Large"></asp:Label>

<br /><br /><br />

<table width="400" bgcolor="#BCC7D8">
    <tr>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td style="color: #000000">Username</td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox>
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
        <td style="color: #000000">Password</td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtPassword" ErrorMessage="Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnLogin" runat="server" Text="Login" Width="100px" 
                onclick="btnLogin_Click" />
        </td>
    </tr>
</table>

<br /><br /><br /><br /><br />

</div>


</asp:Content>
