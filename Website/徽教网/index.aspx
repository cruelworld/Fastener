<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="index.aspx.cs" Inherits="index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <form id="form1" runat="server">
  <div class="container">
    <table>
      <tr>
        <td class="col-9">           
          <div id="slide-content">            
            <script>
              var slide = new slide();
              slide.width = 550; //宽度
              slide.height = 250;//高度
              slide.autoplayer = 5;//自动播放间隔时间

              //slide.add({"url":"图片地址","title":"悬浮标题","href":"链接地址"})
              slide.add({ "url": "images/slide1.png", "href": "", "title": " " })
              slide.add({ "url": "images/slide2.png", "href": "", "title": " " })
              slide.add({ "url": "images/slide3.png", "href": "", "title": " " })
              slide.add({ "url": "images/slide4.png", "href": "", "title": " " })
              slide.add({ "url": "images/slide5.png", "href": "", "title": " " })
              slide.show();
            </script>  
          </div>
        </td><%-- 幻灯图 --%>
        <td class="col-3">
          <div id="contact">
            <span class="h2">24小时为您服务</span><br /><br /><br /><br />
            <span>全市统一家教热线：</span><br />
            <a>万老师 18271697719</a><br /><br />
            <span>教员热线：</span> <br />
            <a>万老师 18271697719</a>
          </div>
        </td>
      </tr>
    </table>
  </div>  
  <div class="container"> 
    <table class="col-12">
      <tr>
        <td class="col-2">
          <div id="teachers">
            <div class="left">
              <span class="h3"><strong>请家教</strong></span>              
            </div>
            <div class="right" style="width: 233px;">
              <ul class="h5" >
                <li><a>请家教须知</a></li>
                <li><a>家教资费标准</a></li>
                <li><a>挑选合适的教员</a></li>
              </ul>
            </div>
            <div class="clear"></div>
          </div>
        </td>
        <td class="col-2">
          <div id="students">
            <div class="left">
              <span class="h3"><strong>做教员</strong></span>              
            </div>
            <div class="right" style="width: 233px;">
              <ul class="h5" >
                <li><a>做教员须知</a></li>
                <li><a>查看高校代理</a></li>
                <li><a>查看接单手续</a></li>
              </ul>
            </div>
          </div>
        </td>        
        <td class="col-8" style="top:0;">

          &nbsp;</td>
      </tr>
    </table>
  </div><%-- 快捷入口 --%>  
  <div class="clear"></div>
  <div class="page-header-blue">
    <div class="container">
      <span class="h3"><a><strong>综合检索</strong></a></span>
    </div>
  </div><br />
  <%-- 综合检索内容区 --%>
  <div class="container">

  </div>
  <%-- 综合检索内容区 --%>
  <div class="page-header-blue">
    <div class="container">
      <span class="h3"><a><strong>精心推荐</strong></a></span>
    </div>
  </div><br />
  <%-- 精心推荐内容区 --%>
  <div class ="container">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Book_teacher]"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="编号" DataSourceID="SqlDataSource1" style="border:0px; margin-top: 0px" Width="590px">
      <Columns>
        <asp:BoundField DataField="编号" HeaderText="编号" InsertVisible="False" ReadOnly="True" SortExpression="编号" />
        <asp:BoundField DataField="性别" HeaderText="性别" SortExpression="性别" />
        <asp:BoundField DataField="真实名字" HeaderText="真实名字" SortExpression="真实名字" />
        <asp:BoundField DataField="邮箱" HeaderText="邮箱" SortExpression="邮箱" />
        <asp:BoundField DataField="电话" HeaderText="电话" SortExpression="电话" />
        <asp:BoundField DataField="手机" HeaderText="手机" SortExpression="手机" />
        <asp:BoundField DataField="教学位置" HeaderText="教学位置" SortExpression="教学位置" />
        <asp:BoundField DataField="科目" HeaderText="科目" SortExpression="科目" />
        <asp:BoundField DataField="预约说明" HeaderText="预约说明" SortExpression="预约说明" />
        <asp:BoundField DataField="预定时间" HeaderText="预定时间" SortExpression="预定时间" />
      </Columns>
    </asp:GridView>
  </div>
  <%-- 精心推荐内容区 --%>
  <div class="page-header-blue">
    <div class="container">
      <span class="h3"><a><strong>常见问题——FAQ</strong></a></span>
    </div>
  </div><br />
  <%-- FAQ内容区 --%>

  <%-- FAQ内容区 --%>
</form>
</asp:Content>