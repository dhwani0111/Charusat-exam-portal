<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="OnlineExamination.Result" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">

    <h1>View Result</h1>
    <br />
    <table width="800" bgcolor="#BCC7D8" align="center" style="color: #000000" 
            frame="box">
    <tr>
    <td>Select Course</td>
    <td>
        <asp:DropDownList ID="ddlSelectCourse" runat="server" Width="150px" 
            AutoPostBack="True" 
            onselectedindexchanged="ddlSelectCourse_SelectedIndexChanged">
        </asp:DropDownList>
        </td></tr></table>
    <br /><br /><br />
        <asp:GridView ID="gvresult" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="StudentId" ForeColor="#333333" GridLines="None" 
            onrowcommand="gvresult_RowCommand" onrowediting="gvresult_RowEditing" 
            Width="800px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="RollNumber" HeaderText="Roll_No" ReadOnly="True" />
                <asp:BoundField DataField="StudentName" HeaderText="Student_Name" 
                    ReadOnly="True" />
                <asp:BoundField DataField="MobileNumber" HeaderText="Mobile_No" 
                    ReadOnly="True" />
                <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="True" />
                <asp:BoundField DataField="HODName" HeaderText="HOD" ReadOnly="True" />
                <asp:ButtonField ButtonType="Button" CommandName="View" Text="View" />
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
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
