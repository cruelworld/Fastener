<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <div class="container">
    <h2>
      欢迎使用 ASP.NET!
    </h2>
    <a href="#" id="Alert" onclick="ShowAlert()">提示</a>
    <asp:HyperLink ID="Alert1" runat="server" onclick="ShowAlert()">HyperLink</asp:HyperLink>
    <asp:Button ID="Alert2" runat="server" Text="Button" />
    <p>
      若要了解关于 ASP.NET 的详细信息，请访问 <a href="http://www.asp.net/cn" title="ASP.NET 网站">www.asp.net/cn</a>。
    </p>
    <p>
      您还可以找到 <a href="http://go.microsoft.com/fwlink/?LinkID=152368" title="MSDN ASP.NET 文档">
        MSDN 上有关 ASP.NET 的文档</a>。
    </p>
  </div>
  <script type="text/javascript">
    
      // 获取目标按钮
      var btn1 = document.getElementById("Alert2");

      // 生成div窗口
      var Alert1 = document.createElement('div');
      var Text1 = document.createTextNode("这是个提示框！");
      var Close = document.createElement('span');
      Alert1.appendChild(Text1);
      Alert1.setAttribute("class","alert");

      // 获取内容页里的container的第一行
      var Parent1 = $(".container")[1];
      var FirstChild = Parent1.childNodes[0];

      $(btn1).onclick(function(){
        Parent1.insertBefore(Alert1,FirstChild);  
      });
  </script>
</asp:Content>