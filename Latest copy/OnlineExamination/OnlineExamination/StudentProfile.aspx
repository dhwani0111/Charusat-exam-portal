<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="OnlineExamination.StudentProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 18px;
            margin-left: 120px;
        }
        .auto-style1 {
            width: 254px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
<br /><br /><br />
<h1>View Student Profile</h1>
<br /><br />
<table width="600"  >
<tr>
<td align="left" class="auto-style1">Name</td>
<td align="left">
    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></td>
 </tr>
 <tr>
 <td align="left" class="auto-style1">RollNo</td>
 <td align="left">
     <asp:Label ID="lblRollNo" runat="server" Text="Label"></asp:Label></td></tr>
     </table>
<br />

<table width="600" >
     
     <tr>
    
         <td align="left" width="130">EmailId</td>
         <td align="left" width="170">
             <asp:Label ID="lblEmailId" runat="server" Text="Label"></asp:Label>
         </td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1">Course</td>
     <td align="left" width="170" class="style1">
         <asp:Label ID="lblCourse" runat="server" Text="Label"></asp:Label>
         </td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1">
             <asp:Button ID="btncancel" runat="server" onclick="btncancel_Click" 
                 Text="Cancel" />
         </td>
     <td align="left" width="170" class="style1">
         &nbsp;</td>
 </tr>

</table>
<br /><br /><br />

</div>

</asp:Content>
