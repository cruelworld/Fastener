<%@ Page Title="交流站" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
  CodeFile="Default.aspx.cs" Inherits="Forum_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server" CommandName="study">
  <div class="container">
    <div>
      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="#" CommandName="study"
        OnClick="ImageButton1_Click" />
      <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="#" CommandName="life"
        OnClick="ImageButton1_Click" />
      <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="#" CommandName="competiton"
        OnClick="ImageButton1_Click" />
      <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="#" CommandName="amusement"
        OnClick="ImageButton1_Click" />
      <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="#" CommandName="commerce"
        OnClick="ImageButton1_Click" />
    </div>
    <div>
      <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Selected="True">搜贴</asp:ListItem>
        <asp:ListItem>搜人</asp:ListItem>
      </asp:DropDownList>
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1"
        DataTextField="ClassName" DataValueField="ClassID">
      </asp:DropDownList>
      <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT * FROM [vm_aspnet_Class]"></asp:SqlDataSource>
    </div>
    <h2>
      hot</h2>
    <div>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
        GridLines="None">
        <Columns>
          <asp:HyperLinkField DataTextField="UserName" DataNavigateUrlFields="UserName" DataNavigateUrlFormatString="~/MyDetail.aspx?usName = {0}"
            HeaderText="UserName" />
          <asp:HyperLinkField DataTextField="Title" DataNavigateUrlFields="TopicID" DataNavigateUrlFormatString="ForumDetail.aspx?topid = {0}"
            HeaderText="Title" />
          <asp:BoundField DataField="RevertNum" HeaderText="RevertNum" SortExpression="RevertNum" />
          <asp:BoundField DataField="PublishTime" HeaderText="PublishTime" SortExpression="PublishTime" />
          <asp:BoundField DataField="ClassID" HeaderText="ClassID" SortExpression="ClassID" />
        </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT [UserName], [Title], [RevertNum], [PublishTime], [ClassID], [TopicID] FROM [vm_aspnet_UserTopic] WHERE ([RevertNum] &gt;= @RevertNum) ORDER BY [PublishTime] DESC">
        <SelectParameters>
          <asp:Parameter DefaultValue="30" Name="RevertNum" Type="Int32" />
        </SelectParameters>
      </asp:SqlDataSource>
    </div>
    <h2>
      new</h2>
    <div>
      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4"
        BorderStyle="None" GridLines="None">
        <Columns>
          <asp:HyperLinkField DataTextField="UserName" DataNavigateUrlFields="UserName" DataNavigateUrlFormatString="~/MyDetail.aspx?usName = {0}"
            HeaderText="UserName" />
          <asp:HyperLinkField DataTextField="Title" DataNavigateUrlFields="TopicID" DataNavigateUrlFormatString="ForumDetail.aspx?topid = {0}"
            HeaderText="Title" />
          <asp:BoundField DataField="RevertNum" HeaderText="RevertNum" SortExpression="RevertNum" />
          <asp:BoundField DataField="PublishTime" HeaderText="PublishTime" SortExpression="PublishTime" />
          <asp:BoundField DataField="ClassID" HeaderText="ClassID" SortExpression="ClassID" />
        </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT * FROM [vm_aspnet_UserTopic] ORDER BY [PublishTime] DESC">
      </asp:SqlDataSource>
    </div>
    <h2>
      recommend</h2>
    <div>
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3"
        BorderStyle="None" GridLines="None">
        <Columns>
          <asp:HyperLinkField DataTextField="UserName" DataNavigateUrlFields="UserName" DataNavigateUrlFormatString="~/MyDetail.aspx?usName = {0}"
            HeaderText="UserName" />
          <asp:HyperLinkField DataTextField="Title" DataNavigateUrlFields="TopicID" DataNavigateUrlFormatString="ForumDetail.aspx?topid = {0}"
            HeaderText="Title" />
          <asp:BoundField DataField="ClassID" HeaderText="ClassID" SortExpression="ClassID" />
          <asp:BoundField DataField="RevertNum" HeaderText="RevertNum" SortExpression="RevertNum" />
          <asp:BoundField DataField="PublishTime" HeaderText="PublishTime" SortExpression="PublishTime" />
        </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT * FROM [vm_aspnet_UserTopic] WHERE ([IsFoused] = @IsFoused) ORDER BY [PublishTime] DESC">
        <SelectParameters>
          <asp:Parameter DefaultValue="true" Name="IsFoused" Type="Boolean" />
        </SelectParameters>
      </asp:SqlDataSource>
    </div>
  </div>
</asp:Content>