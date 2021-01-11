<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="AddStudentMarksDetails.aspx.cs" Inherits="OnlineExamination.AddStudentMarksDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="center">
<br /> <br />
<h1>Add StudentMarksDetails</h1>
<br /><br />
<table width="400" bgcolor="#BCC7D8" style="color: #000000">
<tr>
<td align="center"></td>
<td></td>
</tr>
<tr>
<td align="center">StudentId</td>
<td>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td align="center">&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center">SubjectId</td>
<td>
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td align="center">&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center">ObtainedMark</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
</tr></table>
</div>
</asp:Content>
