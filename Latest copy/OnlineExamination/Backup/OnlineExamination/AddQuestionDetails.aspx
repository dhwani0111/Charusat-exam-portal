<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="AddQuestionDetails.aspx.cs" Inherits="OnlineExamination.AddQuestionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 18px;
        }
        .style2
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="center">
<br /><br />
<h1>Manage QuestionDetails</h1>
<br /><br />
    <asp:Button ID="btnViewQuestion" runat="server" Text="ViewQuestion" 
        CausesValidation="False" onclick="btnViewQuestion_Click" />
    <asp:Button ID="btnAddQuestion" runat="server" Text="AddQuestion" 
        CausesValidation="False" onclick="btnAddQuestion_Click" />
    <br /><br />
    <table width="400"bgcolor="#BCC7D8" style="margin-top: 0px" frame="box">
    <tr>
<td style="color: #000000" align="center" class="style2">Course</td>
<td class="style2">
    <asp:DropDownList ID="ddlCourse" runat="server" Width="150px" 
        AutoPostBack="True" onselectedindexchanged="ddlCourse_SelectedIndexChanged">
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td style="color: #000000" align="center" class="style1"></td>
<td class="style1">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="ddlCourse" ErrorMessage="Enter Course" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000" align="center" class="style2">Semester</td>
<td class="style2">
    <asp:DropDownList ID="ddlSemester" runat="server" Width="150px" 
        AutoPostBack="True" 
        onselectedindexchanged="ddlSemester_SelectedIndexChanged" 
        AppendDataBoundItems="True">
        <asp:ListItem>I Semester</asp:ListItem>
        <asp:ListItem>II Semester</asp:ListItem>
        <asp:ListItem>III Semester</asp:ListItem>
        <asp:ListItem>IV Semester</asp:ListItem>
        <asp:ListItem>V Semester</asp:ListItem>
        <asp:ListItem>VI Semester</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td style="color: #000000" align="center">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="ddlSemester" ErrorMessage="Enter Semester" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
    
        <tr>
<td style="color: #000000" align="center">Subject</td>
<td>
    <asp:DropDownList ID="ddlSubject" runat="server" Width="150px" 
        AutoPostBack="True" onselectedindexchanged="ddlSubject_SelectedIndexChanged">
    </asp:DropDownList>
    </td>
        </tr>
        <tr>
<td style="color: #000000" align="center" class="style1"></td>
<td class="style1">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="ddlSubject" ErrorMessage="Enter Subject" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
        </tr>
    
    </table>
    <br /><br />
    <asp:Label ID="lblComplete" runat="server" 
        Text="Already Ten questions are added." Font-Bold="True" Font-Size="X-Large" 
        ForeColor="#006600"></asp:Label>


    <asp:Panel ID="pnlAddQuestion" runat="server" visible="false">
    
<table width="400" bgcolor="#BCC7D8" style="margin-top: 0px" frame="box">
<tr>
<td style="color: #000000" align="center"></td>
<td></td>
</tr>

<tr>
<td style="color: #000000" align="center">Question</td>
<td>
    <asp:TextBox ID="txtQuestion" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td style="color: #000000" align="center">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtQuestion" ErrorMessage="Enter Question" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td style="color: #000000" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        onclick="btnSubmit_Click" />
    &nbsp;</td>
<td>
    <asp:Button ID="btnReset" runat="server" Text="Reset" 
        onclick="btnReset_Click" CausesValidation="False" />
    </td>
</tr></table>
</asp:Panel>
<br /><br />
    <asp:Panel ID="pnlViewQuestion" runat="server" Width="400px">
    <br /><br />
        <asp:GridView ID="gvQuestionDetails" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="400px" 
            DataKeyNames="QuestionId" onrowcommand="gvQuestionDetails_RowCommand" 
            onrowediting="gvQuestionDetails_RowEditing">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Question" HeaderText="Question" ReadOnly="True" />
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
        <asp:Label ID="lblNoRecords" runat="server" Text="Sorry No records found" Font-Bold="True" Font-Size="XX-Large"
            ForeColor="Red"></asp:Label>
    </asp:Panel>
    <br /><br /><br />
</div>
</asp:Content>
