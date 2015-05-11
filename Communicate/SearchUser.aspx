<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SearchUser.aspx.cs" Inherits="Forum_SearchUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</div>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        GridLines="None" >
        <Columns>
           <asp:HyperLinkField DataTextField="UserName" DataNavigateUrlFields = "UserName" 
                    DataNavigateUrlFormatString = "~/MyDetail.aspx?usName = {0}" HeaderText="UserName"/>
           
            <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" 
                SortExpression="LastActivityDate" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>

