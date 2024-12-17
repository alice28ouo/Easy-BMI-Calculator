<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="BMI.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BMI紀錄查詢</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>BMI紀錄查詢</h2>

            <asp:Label ID="Label_NameSearch" runat="server" Text="姓名："></asp:Label>
            <asp:TextBox ID="TextBox_NameSearch" runat="server"></asp:TextBox>

            <asp:Label ID="Label_DateSearch" runat="server" Text="日期："></asp:Label>
            <asp:Calendar ID="Calendar_Search" runat="server"></asp:Calendar>

            <asp:Button ID="Button_Search" runat="server" Text="查詢" OnClick="Button_Search_Click" />
            <br /><br />

            <asp:GridView ID="GridView_BMIRecords" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="姓名" />
                    <asp:BoundField DataField="Gender" HeaderText="性別" />
                    <asp:BoundField DataField="Height" HeaderText="身高" />
                    <asp:BoundField DataField="Weight" HeaderText="體重" />
                    <asp:BoundField DataField="BMI" HeaderText="BMI" />
                    <asp:BoundField DataField="RecordDate" HeaderText="紀錄日期" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" />
                </Columns>
            </asp:GridView>

            <br />
            <asp:Button ID="Button_AddNew" runat="server" Text="新增紀錄" OnClick="Button_AddNew_Click" />
        </div>
    </form>
</body>
</html>