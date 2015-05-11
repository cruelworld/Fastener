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

public partial class Forum_Default : System.Web.UI.Page
{
    TopicManage topicmanage = new TopicManage();
    UserManage usermanage = new UserManage();
    ClassManage classmanage = new ClassManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           //string topictitle = TextBox1.Text.ToString();
           //topicmanage._Title = topictitle;
            //DropDownList2.DataSource = classmanage.GetAllClass("aspnet_Class");
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
                string classvalue = DropDownList2.SelectedValue.ToString().Trim();
                Response.Redirect("SearchCard.aspx?TopicTitle=" + topictitle+"&ClassValue="+classvalue);
               
                
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
            DataSet ds = usermanage.FindUserByName(usermanage,"aspnet_Users");
            if (ds.Tables[0].Rows.Count > 0)
            {
               string classvalue = DropDownList2.SelectedValue.ToString().Trim();
               Response.Redirect("SearchUser.aspx?UserName=" + userName + "&ClassValue=" + classvalue);
               
            }
            else
            {
                Response.Write("<script>alert('没有关于此人消息')</script>");
            }
            
        }
        
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (((ImageButton)sender).CommandName == "study")
        {
            Session["ClsId"] = 1;
        }
        else if (((ImageButton)sender).CommandName == "life")
        {
            Session["ClsId"] = 2;
        }
        else if (((ImageButton)sender).CommandName == "competiton")
        {
            Session["ClsId"] = 3;
        }
        else if (((ImageButton)sender).CommandName == "amusement")
        {
            Session["ClsId"] = 4;
        }
        else if (((ImageButton)sender).CommandName == "commerce")
        {
            Session["ClsId"] = 5;
        }

        Response.Redirect("ClassForum.aspx");
    }
}