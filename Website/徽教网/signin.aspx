<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signin.aspx.cs" Inherits="signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登陆</title>
  <link href="css/UserPanel.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>    
      
    <asp:Table ID="panel" runat="server" BorderStyle="None" CellPadding="0" CellSpacing="0" Font-Bold="True">
      <asp:TableHeaderRow CssClass="panel-header">
        <asp:TableCell CssClass="container">
          <span style="font-size:14pt; float:left;">用户登录</span>
          <span style="font-size:10pt;float:right;"><a href="Index.aspx">忘记密码</a></span>
        </asp:TableCell>
      </asp:TableHeaderRow>
      <asp:TableRow CssClass="panel-content">
        <asp:TableCell CssClass="container">                   
          <p>
            <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
          </p>
          <p>
            <asp:TextBox ID="TextBox1" CssClass="input" runat="server"></asp:TextBox>
          </p>
          <p>
            <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
          </p>
          <p>
            <asp:TextBox ID="TextBox2" CssClass="input" runat="server"></asp:TextBox>
            
          </p><br/>
          <p>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="登陆" />&nbsp;
            <asp:Button ID="Button2" CssClass="button" runat="server" Text="返回" 
              Onclick="Button2_Click"/>
          </p>          
        </asp:TableCell>
      </asp:TableRow>      
    </asp:Table>
    </form>
</body>
</html>
