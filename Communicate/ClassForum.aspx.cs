using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Forum_ClassForum : System.Web.UI.Page
{
    TopicManage topicmanage = new TopicManage();
    UserManage usermanage = new UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataSource1.SelectCommand = string.Format("SELECT * FROM [vm_aspnet_UserTopic] WHERE (ClassID = {0})", Convert.ToInt32(Session["ClsId"]));
            SqlDataSource2.SelectCommand = string.Format("SELECT * FROM [vm_aspnet_UserTopic] WHERE (ClassID = {0} AND IsFoused = 1)", Convert.ToInt32(Session["ClsId"]));
            GridView2.DataSourceID = "SqlDataSource2";
            GridView2.DataBind();
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.ToString() == "")
        {
            return;
        }
        if (DropDownList1.SelectedValue.ToString().Trim() == "搜贴")
        {
            string topictitle = TextBox1.Text.ToString();
            topicmanage._Title = topictitle;
            DataSet ds = topicmanage.FindTopicByTitle(topicmanage, "aspnet_Topic");
            if (ds.Tables[0].Rows.Count > 0)
            {

                SqlDataSource1.SelectCommand = string.Format("SELECT * FROM [vm_aspnet_UserTopic] WHERE (ClassID = {0} and Title like '%{1}%')", Convert.ToInt32(Session["ClsId"]), topictitle);
               
            }
            else
            {
                Response.Write("<script>alert('没有关于此帖消息')</script>");
            }
        }
        else if (DropDownList1.SelectedValue.ToString().Trim() == "搜人")
        {
            string userName = TextBox1.Text.ToString();
            usermanage._UserName = userName;
            DataSet ds = usermanage.FindUserByName(usermanage, "aspnet_Users");
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                Response.Redirect("SearchUser.aspx?UserName=" + userName);

            }
            else
            {
                Response.Write("<script>alert('没有关于此人消息')</script>");
            }

        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        SqlDataSource1.SelectCommand = string.Format("SELECT * FROM [vm_aspnet_UserTopic] WHERE (ClassID = {0}) ORDER BY PublishTime DESC", Convert.ToInt32(Session["ClsId"]));
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlDataSource1.SelectCommand = string.Format("SELECT * FROM [vm_aspnet_UserTopic] WHERE (ClassID = {0}) ORDER BY RevertNum DESC", Convert.ToInt32(Session["ClsId"]));
    }
}