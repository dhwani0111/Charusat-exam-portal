<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="AddSubjectsDetails.aspx.cs" Inherits="OnlineExamination.AddSubjectsDetails" %>
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
<br /><br />
<h1>Manage SubjectDetails</h1>
<br /><br />
        <asp:Button ID="btnviewSubject" runat="server" Text="ViewSubject" 
            onclick="btnviewSubject_Click" CausesValidation="False" />
        <asp:Button ID="btnAddSubject" runat="server" Text="AddSubject" 
            onclick="btnAddSubject_Click" CausesValidation="False" />

<br /><br />
<table width="400" bgcolor="#BCC7D8" frame="box">
<tr>
<td align="left">Select Course</td>
<td>
    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlCourse_SelectedIndexChanged" Width="150px">
    </asp:DropDownList>
    </td>
</tr>

<tr>
<td>&nbsp;</td>
<td>
    &nbsp;</td>
</tr>

    <tr>
        <td align="left" class="style1">
            Semester</td>
        <td class="style1">
            <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlSemester_SelectedIndexChanged" Width="150px">
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
        <td align="left" class="style1">
            &nbsp;</td>
        <td class="style1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="ddlSemester" ErrorMessage="Enter Semester" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>

</table>
<br /><br />
        <asp:Label ID="lblComplete" runat="server" Text="Already six subject are added" 
            Font-Bold="True" Font-Size="X-Large"  
            ForeColor="#006600" Visible="False"></asp:Label>

        <asp:Panel ID="pnlAddSubject" runat="server" visible= "false">

              
<table width="400" bgcolor="#BCC7D8" 
        style="color: #000000; " frame="box">
<tr>
<td align="left" class="style1">&nbsp;</td>
<td class="style1">
    &nbsp;</td>
</tr>
<tr>
<td align="left" class="style1">Teacher</td>
<td>
    <asp:DropDownList ID="ddlTeacher" runat="server" Width="150px">
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td align="left" class="style1">&nbsp;</td>
<td class="style1">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="ddlTeacher" ErrorMessage="Enter Teacher" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td align="left" class="style1">Subject Name</td>
<td>
    <asp:TextBox ID="txtSubjectName" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left" class="style1"></td>
<td class="style1">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtSubjectName" ErrorMessage="Enter Subject Name" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td align="left" class="style1">Subject Code</td>
<td>
    <asp:TextBox ID="txtSubjectCode" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="left" class="style1">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtSubjectCode" ErrorMessage="Enter Subject Code" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td align="left">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        onclick="btnSubmit_Click" style="height: 26px" />
    &nbsp;</td>
<td>
    <asp:Button ID="btnReset" runat="server" Text="Reset" 
        onclick="btnReset_Click" CausesValidation="False" />
    </td>
</tr></table>
</asp:Panel> 
<br /><br /> 
        <asp:Panel ID="pnlviewSubject" runat="server">
            <asp:GridView ID="gvSubjectDetails" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" Width="800px" 
                AutoGenerateColumns="False" DataKeyNames="SubjectId" 
                onrowcommand="gvSubjectDetails_RowCommand" 
                onrowediting="gvSubjectDetails_RowEditing">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="SubjectName" HeaderText="Subject_Name" 
                        ReadOnly="True" />
                    <asp:BoundField DataField="SubjectCode" HeaderText="Subject_Code" 
                        ReadOnly="True" />
                    <asp:BoundField DataField="TeachersName" HeaderText="Teachers_Name" 
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
            <asp:Label ID="lblNoRecords" runat="server" Text="Sorry! No Records Found" 
                Visible="False" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red"></asp:Label>
        </asp:Panel>
        <br /><br /><br />
</div> 

</asp:Content>
