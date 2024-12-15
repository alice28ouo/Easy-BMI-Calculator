<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BMI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>BMI計算網頁<br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                <asp:ListItem Value="male">男性</asp:ListItem>
                <asp:ListItem Value="female">女性</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            身高 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="cm">公分</asp:ListItem>
                <asp:ListItem Value="in">英寸</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            體重 <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </strong>
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Value="kg">公斤</asp:ListItem>
                <asp:ListItem Value="lb">英鎊</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="計算BMI" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
