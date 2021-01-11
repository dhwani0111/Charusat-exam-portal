<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="ViewStudentResult.aspx.cs" Inherits="OnlineExamination.ViewStudentResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div align="center">
<br /><br />
    <h1>View Student Result</h1>
    <br /><br />
    <table width="800" bgcolor="#BCC7D8" align="center" style="color: #000000" 
        frame="box">
    <tr>
    <td align="left">Student Name</td>
    <td>
        <asp:Label ID="lblStudentName" runat="server" Text="Label"></asp:Label>
        </td>
    <td align="left">Course</td>
    <td>
        <asp:Label ID="lblCourse" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
    <td align="left">&nbsp;</td>
    <td>&nbsp;</td>
    <td align="left">&nbsp;</td>
    <td>&nbsp;</td>
    </tr>
    <tr>
    <td class="style1" align="left">Mobile Number</td>
    <td class="style1">
        <asp:Label ID="lblMobileNumber" runat="server" Text="Label"></asp:Label>
        </td>
    <td class="style1" align="left">Address</td>
    <td class="style1">
        <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
    <td align="left">&nbsp;</td>
    <td>&nbsp;</td>
    <td align="left">&nbsp;</td>
    <td>&nbsp;</td>
    </tr>
    <tr>
    <td align="left">Select Semester</td>
    <td>
        <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="True" 
            Width="150px" onselectedindexchanged="ddlSemester_SelectedIndexChanged">
                <asp:ListItem>I Semester</asp:ListItem>
                <asp:ListItem>II Semester</asp:ListItem>
                <asp:ListItem>III Semester</asp:ListItem>
                <asp:ListItem>IV Semester</asp:ListItem>
                <asp:ListItem>V Semester</asp:ListItem>
                <asp:ListItem>VI Semester</asp:ListItem>
            </asp:DropDownList>
        </td>
    <td align="left">Select Subject</td>
    <td>
        <asp:DropDownList ID="ddlSelectSubject" runat="server" Width="150px" 
            AutoPostBack="True" 
            onselectedindexchanged="ddlSelectSubject_SelectedIndexChanged">
            <asp:ListItem Value="0">Select Subject</asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr></table>
    <br /><br />
    <asp:Panel ID="pnlStudentResult" runat="server">
        <asp:GridView ID="gvStudentResult" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" Width="800px" 
            onrowdatabound="gvStudentResult_RowDataBound">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Question" HeaderText="Question" ReadOnly="True" />
                <asp:BoundField DataField="Answer" HeaderText="Answer" ReadOnly="True" />
                <asp:BoundField DataField="Marks" HeaderText="Mark" ReadOnly="True" />
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
        <table width="800" bgcolor="#BCC7D8" align="center" style="color: #000000" 
            frame="box">
        <tr>
        <td align="left">Exam Date</td>
        <td>
            <asp:Label ID="lblExamDate" runat="server" Text="Label"></asp:Label>
            </td>
        <td align="left">Total</td>
        <td>
            <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
            </td></tr>
            <tr>
                <td align="left" class="style1">
                    </td>
                <td class="style1">
                    </td>
                <td align="left" class="style1">
                    </td>
                <td class="style1">
                    </td>
            </tr>
            <tr>
                <td align="left">
                    Grade</td>
                <td>
                    <asp:Label ID="lblGrade" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="left">
                    Percentage</td>
                <td>
                    <asp:Label ID="lblPercentage" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        
    </asp:Panel>
    <br /><br />
    <asp:Label ID="lblNotWrittenExam" runat="server" Text="you are not written exam"  Font-Bold="True" Font-Size="XX-Large"
            ForeColor="Red"></asp:Label>
    <br /><br />

</div>
</asp:Content>
