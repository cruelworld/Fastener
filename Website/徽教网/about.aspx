<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="about.aspx.cs" Inherits="about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container">
    <h3>关于我们</h3>
    <hr />
    <div id="title">
      <ul class="container" >
        <li style="list-style:square;"><a href="about.html" target="article">公司简介</a></li>
        <li style="list-style:square;"><a href="#" target="article">业务团队</a></li>
        <li style="list-style:square;"><a href="#" target="article">全国化</a></li>
      </ul>
    </div>
    <iframe name="article" src="about.html" frameborder="0"  style="width:77%;height:500px; float:right;"></iframe>
  </div>
  <div class="clear"></div>
</asp:Content>
