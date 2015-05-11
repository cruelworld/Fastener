<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SearchCard.aspx.cs" Inherits="Forum_SearchCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</div>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BorderWidth="0px" GridLines="None">
        <Columns>
           <asp:HyperLinkField DataTextField="Title" DataNavigateUrlFields = "TopicID" 
                    DataNavigateUrlFormatString = "ForumDetail.aspx?topid = {0}" HeaderText="Title"/>
            <asp:BoundField DataField="PublishTime" HeaderText="PublishTime" 
                SortExpression="PublishTime" />
        </Columns>
        <FooterStyle BorderWidth="0px" />
        <RowStyle BorderWidth="0px" />
    </asp:GridView>
    
</div>
</asp:Content>

