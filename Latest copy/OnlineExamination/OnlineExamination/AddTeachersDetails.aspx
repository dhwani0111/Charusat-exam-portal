<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="AddTeachersDetails.aspx.cs" Inherits="OnlineExamination.AddTeachersDetails" %>
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
<h1>Manage TeachersDetails</h1>
<br /><br />
        <asp:Button ID="btnViewTeachers" runat="server" Text="ViewTeachers" 
            onclick="btnViewTeachers_Click" CausesValidation="False" />
        <asp:Button ID="btnAddTeachers" runat="server" Text="AddTeachers" 
            onclick="btnAddTeachers_Click" CausesValidation="False" />
        <br /><br />

        <table width="400">
        <tr>
<td align="center" class="style1">Select Course</td>
<td class="style1">
    <asp:DropDownList ID="ddlCourse" runat="server" Width="150px" 
        AutoPostBack="True" onselectedindexchanged="ddlCourse_SelectedIndexChanged" 
        style="height: 22px">
    </asp:DropDownList>
    </td>
</tr>
        </table>

        <br /><br />

        <asp:Panel ID="pnlAddTeachers" runat="server" Visible="false">
        

<table width="400" bgcolor="#BCC7D8" style="color: #000000" frame="box">
<tr>
<td align="center" class="style1">&nbsp;</td>
<td class="style1">&nbsp;</td>
</tr>
<tr>
<td align="center">
    Teacher</td>
<td>
    <asp:TextBox ID="txtTeacher" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="center">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtTeacher" ErrorMessage="Enter Teacher" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td align="center">EmailId</td>
<td>
    <asp:TextBox ID="txtEmailId" runat="server" Width="150px"></asp:TextBox>
    </td>
</tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            Password</td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
<tr>
<td align="center">&nbsp;</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
        ControlToValidate="txtEmailId" ErrorMessage="Enter EmailId" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td align="center">&nbsp;</td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td align="center">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        onclick="btnSubmit_Click" style="height: 26px" />
    </td>
<td>
    <asp:Button ID="btnReset" runat="server" Text="Reset" 
        onclick="btnReset_Click" CausesValidation="False" />
    </td>
</tr></table>
</asp:Panel>
<br /><br />

        <asp:Panel ID="pnlViewTeachers" runat="server">
            <asp:GridView ID="gvTeachersDetails" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" Width="800px" 
                AutoGenerateColumns="False" onrowcommand="gvTeachersDetails_RowCommand" 
                onrowediting="gvTeachersDetails_RowEditing" DataKeyNames="TeachersId">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
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
            <asp:Label ID="lblNoRecords" runat="server" Text="Sorry no records found" 
                Font-Bold="True" Font-Size="XX-Large" ForeColor="Red" Visible="False"></asp:Label>
        </asp:Panel>
        <br /><br /><br />
</div>
</asp:Content>
