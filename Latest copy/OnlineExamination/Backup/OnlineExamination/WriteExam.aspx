<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="WriteExam.aspx.cs" Inherits="OnlineExamination.WriteExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script type="text/javascript">
        function hideQuestions() {
            // Hide the questions
            document.getElementById("answerBlock").style.display = "none";
            // Show the message that the questions timed out
            document.getElementById("quicker").style.display = "block";
        }

        function checkTime() {
            secondsLeft = secondsLeft - 1;
            if (secondsLeft <= 0) {
                hideQuestions();
                //alert("Time is up!");
                document.getElementById("secondsLeft").style.color = "red";
                window.clearInterval(myTimer);
                writeTime("Timed out!");
                // Here you'd probably want to do a redirect to another page


                document.getElementById('<%=btnSubmit.ClientID %>').style.visibility = "hidden";

            }
            else {
                writeTime(secondsLeft + "s");
            }
        }

        function writeTime(msg) {
            document.getElementById("secondsLeft").innerHTML = msg;
        }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="pnlWriteExam" runat="server">

<div align="center" runat="server">

<br /><br />
<h1 dir="ltr">Write Exam</h1>
<br /><br />
<br /><br />
 <table width="400" bgcolor="#BCC7D8" style="color: #000000" frame="box">
 <tr>
 <td width="150">&nbsp;</td>
 <td>
     &nbsp;</td>
 </tr>
 <tr>
 <td width="150">Select Semester</td>
 <td>
    <asp:DropDownList ID="ddlSemester" runat="server" Width="200px" 
        AutoPostBack="True" 
         onselectedindexchanged="ddlSemester_SelectedIndexChanged">
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
 <td width="150">&nbsp;</td>
 <td>
     &nbsp;</td>
 </tr>
 <tr>
 <td width="150">Select Subject</td>
 <td>
     <asp:DropDownList ID="ddlSubject" runat="server" 
         onselectedindexchanged="ddlSubject_SelectedIndexChanged" Width="200px" 
         AutoPostBack="True">
     </asp:DropDownList>
 </td></tr>
 <tr>
 <td width="150">&nbsp;</td>
 <td>
     &nbsp;</td></tr>

 </table>
 <br /><br />

 <div id="divIsWritten" runat="server">
<h2><strong>Time Remaining : </strong> <span id="secondsLeft"></span></h2> 
 <div id="answerBlock"> 

        <asp:DataList ID="dlExam" runat="server" DataMember="QuestionId" 
            onitemdatabound="dlExam_ItemDataBound" BackColor="#F0F0F0">
            <ItemTemplate>
                <table width="800">
                    <tr>
                        <td align="left">
                            (<%#Container.ItemIndex+1 %>)&nbsp&nbsp<asp:Label ID="lblQuestion" runat="server" Text='<%# Eval("Question") %>'></asp:Label>
                            <asp:Label ID="lblQuestionId" runat="server" Text='<%# Eval("QuestionId") %>' Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:RadioButtonList ID="rblAnswers" runat="server" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Answer" ForeColor="Red" ControlToValidate="rblAnswers"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>..........................................................................................................................................................................</td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <br /><br />
</div>
</div>
</div>


<div align="center">
<asp:Label ID="lblWritten" runat="server" Text="You are already written this exam." 
        Font-Bold="True" Font-Size="X-Large" ForeColor="#006600"></asp:Label>
<br /><br />
<asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" Width="150px" BackColor="Transparent" />
            
</div>

<div id="quicker" style="display:none;" align="center">
You must answer more quickly next time!

<br /><br />

<asp:Button ID="btnTimeout" runat="server" Text="OK" Width="150px" 
        onclick="btnSubmit_Click" CausesValidation="false" />
</div>
</asp:Panel>

<center>
<asp:Panel ID="pnlResult" runat="server" Visible="False" 
            style="background-color: #FFFFFF" Width="1000px">
        <br class="style2" />
            <asp:Label ID="lblComplete" runat="server" Font-Bold="True" Font-Size="X-Large" 
                ForeColor="#006600" 
                style="color: #000066; font-family: 'Brush Script MT'; font-size: xx-large;" 
                Width="600px">Your exam completed successfully. Click View Result button to check your result</asp:Label>
            <br /><br />
            <br />
            <br />
        <img src="images/pic11.jpg" alt="left" align="middle" height="200" width="400" />
            &nbsp;&nbsp;&nbsp;
            <br /><br /><br /><br />
            <asp:Button ID="btnViewResult" runat="server" Text="View Result" Width="150px" 
        onclick="btnViewResult_Click" />
                
        </asp:Panel>
</center>
 <br /><br /><br />
 <script>
     var secondsLeft = 10;
     writeTime(secondsLeft + " S");
     var myTimer = window.setInterval(checkTime, 1000);
</script>
</asp:Content>
