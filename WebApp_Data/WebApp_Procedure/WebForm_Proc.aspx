<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_Proc.aspx.cs" Inherits="WebApp_Procedure.WebForm_Proc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
        <div>
            <table style="border: solid 1px black; padding: 45px; position: relative; top: 50px;" align="center">
                <tr>
                    <td>Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_name" runat="server" Width="200px" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Address :
                    </td>
                    <td>
                        <asp:TextBox ID="txt_address" runat="server" Width="200px" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender:
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="205px" Height="25px">
                            <asp:ListItem Value="">Please Select</asp:ListItem>
                            <asp:ListItem>Male </asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_pwd" runat="server" TextMode="Password" Width="200px" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnRegiser" runat="server" Text="Register" OnClick="btnRegiser_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <hr />
    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
</body>
</html>
