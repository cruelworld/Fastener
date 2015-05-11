<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ClassForum.aspx.cs" Inherits="Forum_ClassForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div>
    <asp:Button ID="Button1" runat="server" Text="新" onclick="Button1_Click1" />
    <asp:Button ID="Button2"
        runat="server" Text="热" onclick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Selected="True">搜贴</asp:ListItem>
            <asp:ListItem>搜人</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="搜索" onclick="Button1_Click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" GridLines="None" ShowHeader="False" >
            <Columns>
                 <asp:HyperLinkField DataTextField="UserName" DataNavigateUrlFields = "UserName" 
                    DataNavigateUrlFormatString = "~/MyDetail.aspx?usName = {0}" HeaderText="UserName"/>
                <asp:HyperLinkField DataTextField="Title" DataNavigateUrlFields = "TopicID" />
                <asp:BoundField DataField="RevertNum" HeaderText="RevertNum" 
                    SortExpression="RevertNum" />
                <asp:BoundField DataField="PublishTime" HeaderText="PublishTime" 
                    SortExpression="PublishTime" />
            </Columns>
    </asp:GridView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        >
    </asp:SqlDataSource>
    
</div>
<div>RECOMMAND</div>
<div>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource2" GridLines="None" ShowHeader="False">
        <Columns>
            <asp:HyperLinkField DataTextField="UserName" DataNavigateUrlFields = "UserName" 
                    DataNavigateUrlFormatString = "~/MyDetail.aspx?usName = {0}" HeaderText="UserName"/>
                <asp:HyperLinkField DataTextField="Title" DataNavigateUrlFields = "TopicID" />
            <asp:BoundField DataField="RevertNum" HeaderText="RevertNum" 
                SortExpression="RevertNum" />
            <asp:BoundField DataField="PublishTime" HeaderText="PublishTime" 
                SortExpression="PublishTime" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [vm_aspnet_UserTopic]" >
        
    </asp:SqlDataSource>
</div>
</asp:Content>

