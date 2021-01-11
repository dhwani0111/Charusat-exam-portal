<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="AddAnswerDetails.aspx.cs" Inherits="OnlineExamination.AddAnswerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 109px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">


<br /><br /><br />
<h1>Manage Answer Details</h1>
<br /><br />
        <asp:Button ID="btnViewAnswer" runat="server" Text="View Answer" 
            onclick="btnViewAnswer_Click" CausesValidation="False" />
        <asp:Button ID="btnAddAnswer" runat="server" Text="Add Answer" 
            onclick="btnAddAnswer_Click" CausesValidation="False" />
        <br /><br />
        
      


<table width="400" bgcolor="#BCC7D8" style="color: #000000" frame="box">
    <tr>
        <td align="left" class="style1">&nbsp;</td>
        <td align="center">&nbsp;</td>
    </tr>
    <tr>
        <td align="left" class="style1">&nbsp;Course</td>
        <td align="center">
    <asp:DropDownList ID="ddlCourse" runat="server" Width="150px" AutoPostBack="True" 
                onselectedindexchanged="ddlCourse_SelectedIndexChanged">
    </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="left" class="style1"></td>
        <td align="center">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="ddlCourse" ErrorMessage="Enter Course" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left" class="style1">Semester</td>
        <td align="center">
            <asp:DropDownList ID="ddlSemester" runat="server" Width="150px" 
                AutoPostBack="True" onselectedindexchanged="ddlSemester_SelectedIndexChanged">
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
        <td align="left" class="style1">&nbsp;</td>
        <td align="center">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="ddlSemester" ErrorMessage="Enter semester" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left" class="style1">Subject</td>
        <td align="center">
            <asp:DropDownList ID="ddlSubject" runat="server" Width="150px" 
                AutoPostBack="True" onselectedindexchanged="ddlSubject_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="left" class="style1">&nbsp;</td>
        <td align="center">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="ddlSubject" ErrorMessage="Enter Subject" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left" class="style1">Questions</td>
        <td align="center">
            <asp:DropDownList ID="ddlQuestions" runat="server" Width="150px" 
                AutoPostBack="True" onselectedindexchanged="ddlQuestions_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="left" class="style1">&nbsp;</td>
        <td align="center">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="ddlQuestions" ErrorMessage="Enter Questions" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    </table>
    <br /><br />
        <asp:Label ID="lblComplete" runat="server" Text="Already 4 options are added." 
            Font-Bold="True" Font-Size="X-Large"  
            ForeColor="#006600"></asp:Label>


    <asp:Panel ID="pnlAddAnswer"  runat= "server" Visible= "false">
    <table width="400" bgcolor="#BCC7D8" style="color: #000000"
    <tr frame="box">
    </tr>
    <tr>
        <td align="left" class="style1">Answer</td>
        <td align="center">
            <asp:TextBox ID="txtAnswer" runat="server" Width="150px"></asp:TextBox>
            &nbsp;</td>
        <tr>
            <td align="left" class="style1">
                &nbsp;</td>
            <td align="center">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtAnswer" ErrorMessage="Enter Answer" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" class="style1">
                Is Right</td>
            <td align="center">
                <asp:DropDownList ID="ddlIsright" runat="server" Width="150px">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" class="style1">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" class="style1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                    Text="Submit" />
                &nbsp;</td>
            <td align="center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" CausesValidation="False" 
                    onclick="btnReset_Click" Text="Reset" />
                &nbsp;</td>
        </tr>
    </tr>
</table>
  </asp:Panel>
  <br /><br />

        <asp:Panel ID="pnlViewAnswer" runat="server" >
            <asp:GridView ID="gvAnswerDetails" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" Width="400px" 
                AutoGenerateColumns="False" onrowcommand="gvAnswerDetails_RowCommand" 
                onrowediting="gvAnswerDetails_RowEditing" DataKeyNames="AnswerId">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Answer" HeaderText="Answer" ReadOnly="True" />
                    <asp:BoundField DataField="IsRight" HeaderText="Is_right" ReadOnly="True" />
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
              Font-Bold="True" Font-Size="XX-Large"  Visible="False" ForeColor="Red"></asp:Label>
        </asp:Panel>


<br /><br /><br />
</div>
</asp:Content>
