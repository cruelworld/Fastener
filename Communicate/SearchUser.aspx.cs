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

public partial class Forum_SearchUser : System.Web.UI.Page
{
    UserManage usermanage = new UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = Request.Params["UserName"];
        }
        usermanage._UserName = Request.Params["UserName"];
        DataSet ds = usermanage.FindUserByName(usermanage, "aspnet_Users");
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}