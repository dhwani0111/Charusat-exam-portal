<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="OnlineExamination.StudentProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 18px;
            margin-left: 120px;
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
<td rowspan="3" width="170">
    <asp:Image ID="imgStudentImage" runat="server" Height="150px" Width="150px" /></td>
<td align="left" width="150">Name</td>
<td align="left">
    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></td>
 </tr>
 <tr>
 <td align="left" width="150">RollNo</td>
 <td align="left">
     <asp:Label ID="lblRollNo" runat="server" Text="Label"></asp:Label></td></tr>
     <tr>
 <td align="left" width="150">MobileNo</td>
 <td align="left" width="300">
     <asp:Label ID="lblMobileNo" runat="server" Text="Label"></asp:Label></td></tr>
     </table>
<br />

<table width="600" >
     <tr>
    
     <td align="left" width="130">DateOfBirth</td>
     <td align="left" width="170">
         <asp:Label ID="lblDateOfBirth" runat="server" Text="Label"></asp:Label></td>
         <td align="left" width="130">FatherName</td>
         <td align="left" width="170">
             <asp:Label ID="lblFatherName" runat="server" Text="Label"></asp:Label></td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1"></td>
     <td align="left" width="170" class="style1">
         </td>
         <td align="left" width="130" class="style1"></td>
         <td align="left" width="170" class="style1">
             </td>
 </tr>

     <tr>
    
     <td align="left" width="130">MotherName</td>
     <td align="left" width="170">
         <asp:Label ID="lblMotherName" runat="server" Text="Label"></asp:Label>
         </td>
         <td align="left" width="130">Address</td>
         <td align="left" width="170">
             <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
         </td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1"></td>
     <td align="left" width="170" class="style1">
         </td>
         <td align="left" width="130" class="style1"></td>
         <td align="left" width="170" class="style1">
         </td>
 </tr>

     <tr>
    
     <td align="left" width="130">DateOfJoin</td>
     <td align="left" width="170">
         <asp:Label ID="lblDateOfJoin" runat="server" Text="Label"></asp:Label>
         </td>
         <td align="left" width="130">EmailId</td>
         <td align="left" width="170">
             <asp:Label ID="lblEmailId" runat="server" Text="Label"></asp:Label>
         </td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1"></td>
     <td align="left" width="170" class="style1">
         </td>
         <td align="left" width="130" class="style1"></td>
         <td align="left" width="170" class="style1">
         </td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1">Paid Fees</td>
     <td align="left" width="170" class="style1">
         <asp:Label ID="lblPaidFees" runat="server" Text="Label"></asp:Label>
         </td>
         <td align="left" width="130" class="style1">Admission Number</td>
         <td align="left" width="170" class="style1">
             <asp:Label ID="lblAdmissionNumber" runat="server" Text="Label"></asp:Label>
         </td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1">&nbsp;</td>
     <td align="left" width="170" class="style1">
         &nbsp;</td>
         <td align="left" width="130" class="style1">&nbsp;</td>
         <td align="left" width="170" class="style1">
             &nbsp;</td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1">BloodGroup</td>
     <td align="left" width="170" class="style1">
         <asp:Label ID="lblBloodGroup" runat="server" Text="Label"></asp:Label>
         </td>
         <td align="left" width="130" class="style1">Gender</td>
         <td align="left" width="170" class="style1">
             <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label>
         </td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1">&nbsp;</td>
     <td align="left" width="170" class="style1">
         &nbsp;</td>
         <td align="left" width="130" class="style1">&nbsp;</td>
         <td align="left" width="170" class="style1">
             &nbsp;</td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1">Course</td>
     <td align="left" width="170" class="style1">
         <asp:Label ID="lblCourse" runat="server" Text="Label"></asp:Label>
         </td>
         <td align="left" width="130" class="style1"></td>
         <td align="left" width="170" class="style1">
             &nbsp;</td>
 </tr>

     <tr>
    
     <td align="left" width="130" class="style1">&nbsp;</td>
     <td align="left" width="170" class="style1">
         &nbsp;</td>
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
