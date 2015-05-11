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

public partial class Forum_SearchCard : System.Web.UI.Page
{
    TopicManage topicmanage = new TopicManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = Request.Params["ClassValue"];
            string classvalue = Request.Params["ClassValue"].ToString();
            topicmanage._Title = Request.Params["TopicTitle"];
            DataSet ds = topicmanage.FindTopicByTitle(topicmanage, "aspnet_Topic");
            DataView dv = new DataView(ds.Tables[0]);
            if (Convert.ToInt32(classvalue) != 0)
            {
                int i = Convert.ToInt32(classvalue);
                dv.RowFilter = string.Format("ClassID = {0}",i);
            }
            
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
    }

}