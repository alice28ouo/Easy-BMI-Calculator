<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BMI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BMI紀錄網站</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>BMI計算與紀錄</h2>
            
            <asp:Label ID="Label_Name" runat="server" Text="姓名："></asp:Label>
            <asp:TextBox ID="TextBox_Name" runat="server"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label_Gender" runat="server" Text="性別："></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList_Gender" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="male">男性</asp:ListItem>
                <asp:ListItem Value="female">女性</asp:ListItem>
            </asp:RadioButtonList>
            <br />

            <asp:Label ID="Label_Height" runat="server" Text="身高："></asp:Label>
            <asp:TextBox ID="TextBox_Height" runat="server"></asp:TextBox>
            <asp:DropDownList ID="DropDownList_HeightUnit" runat="server">
                <asp:ListItem Value="cm">公分</asp:ListItem>
                <asp:ListItem Value="in">英寸</asp:ListItem>
            </asp:DropDownList>
            <br /><br />

            <asp:Label ID="Label_Weight" runat="server" Text="體重："></asp:Label>
            <asp:TextBox ID="TextBox_Weight" runat="server"></asp:TextBox>
            <asp:DropDownList ID="DropDownList_WeightUnit" runat="server">
                <asp:ListItem Value="kg">公斤</asp:ListItem>
                <asp:ListItem Value="lb">英鎊</asp:ListItem>
            </asp:DropDownList>
            <br /><br />

            <asp:Label ID="Label_Date" runat="server" Text="日期："></asp:Label>
            <asp:Calendar ID="Calendar_RecordDate" runat="server"></asp:Calendar>
            <br /><br />

            <asp:Button ID="Button_Calculate" runat="server" Text="計算並儲存" OnClick="Button_Calculate_Click" />
            <br /><br />

            <asp:Label ID="Label_Result" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>