﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="TutorMeNow.Quiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="What is your favorite color?"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton GroupName="Quiz" ID="RadioButton1" runat="server" /><br />
                        <asp:RadioButton GroupName="Quiz" ID="RadioButton2" runat="server" /><br />
                        <asp:RadioButton GroupName="Quiz" ID="RadioButton3" runat="server" /><br />
                        <asp:RadioButton GroupName="Quiz" ID="RadioButton4" runat="server" /><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                        <asp:Button ID="btnCheck" runat="server" Text="Check" />
                    </td>
                </tr>
            </table>

            <asp:RadioButton ID="RadioButton1" runat="server" />


        </div>
    </form>
</body>
</html>