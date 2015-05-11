<%@ Page Title="意见反馈" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
  CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
  <section>
    <div class="container">
      <div class="page-header">
        <h2>意见反馈</h2><hr>
      </div>
      <form>
        <div class="form-group">
          <label for="Name" class="col-xs-2">用户姓名</label>
          <input id="Name" type="text" placeholder="请填写您的姓名">
        </div>
        <div class="form-group">
          <label for="Contact" class="col-xs-2">联系方式</label>
          <input id="Contact" type="text" placeholder="请如实填写，方便我们给您答复">
        </div>
        <div class="form-group">
          <label for="Sorts" class="col-xs-2">反馈类别</label>
          <input id="Sorts" type="text" placeholder="">
        </div>
        <div class="form-group">
          <label for="Describe" class="col-xs-2">详细描述</label>
          <textarea id="Describe" rows="10" cols="50"  placeholder=""></textarea>
        </div>
        <div class="form-group">
          <label for="Submit" class="col-xs-2"></label>
          <button id="Submit" type="submit" class="col-xs-1">提交</button>
        </div>
      </form>
    </div>
  </section>
</asp:Content>