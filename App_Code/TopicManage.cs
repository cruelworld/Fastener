using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
/// <summary>
///TopicManage 的摘要说明
/// </summary>
public class TopicManage
{
	public TopicManage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义话题--数据结构
    private int _topicid = 0;
    private int _classid = 0;
    private Guid _createuserid;
    private string _title = "";
    private string _topiccontent = "";
    private int _revertnum = 0;
    private string _image = "";
    private int _attention = 0;
    private DateTime _publishtime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private bool _isfoused = false;
    private bool _isvisible= true;

    public int _TopicID
    {
        get { return _topicid; }
        set { _topicid = value; }
    }
    public int _ClassID
    {
        get { return _classid; }
        set { _classid = value; }
    }
    public Guid _CreateUserID
    {
        get { return _createuserid; }
        set { _createuserid = value; }
    }
    public string _Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public string _TopicContent
    {
        get { return _topiccontent; }
        set { _topiccontent = value; }
    }
    public int _RevertNum
    {
        get { return _revertnum; }
        set { _revertnum = value; }
    }
    public string _Image
    {
        get { return _image; }
        set { _image = value; }
    }
    public int _Attention
    {
        get { return _attention; }
        set { _attention = value; }
    }
    public DateTime _PublishTime
    {
        get { return _publishtime; }
        set { _publishtime = value; }
    }
     public bool _IsFoused
    {
        get { return _isfoused; }
        set { _isfoused = value; }
    }
     public bool _IsVisible
    {
        get { return _isvisible; }
        set { _isvisible = value; }
    }
    #endregion

    #region 添加话题信息
     public int AddTopic(TopicManage topicmanage)
     {
         SqlParameter[] prams = { 
                               
                                data.MakeInParam("@classid", SqlDbType.Int, 4, topicmanage._ClassID),
                                data.MakeInParam("@createuserid", SqlDbType.UniqueIdentifier, 16, topicmanage._CreateUserID),
                                data.MakeInParam("@title", SqlDbType.NVarChar, 100, topicmanage._Title),
                                data.MakeInParam("@topiccontent", SqlDbType.NVarChar, 2000, topicmanage._TopicContent),
                                data.MakeInParam("@revertnum", SqlDbType.Int, 4, topicmanage._RevertNum),
                                data.MakeInParam("@image", SqlDbType.NVarChar, 50, topicmanage._Image),
                                data.MakeInParam("@attention", SqlDbType.Int, 4, topicmanage._Attention),
                                data.MakeInParam("@publishtime", SqlDbType.DateTime, 8, topicmanage._PublishTime),
                                data.MakeInParam("@isfoused", SqlDbType.Bit, 1, topicmanage._IsFoused),
                                data.MakeInParam("@isvisible", SqlDbType.Bit, 1, topicmanage._IsVisible),
                               };
         return (data.RunProc("insert into aspnet_Topic values(ClassID,CreateUserID,Title,TopicContent,RevertNum,Image,Attention,PublishTime,IsFoused,IsVisible) values(@classid,@createuserid,@title,@topiccontent,@revertnum,@image,@attention,@publishtime,@isfoused,@isvisible)", prams));
     }
    #endregion

     #region 删除话题信息
     public int DeleteTopic(TopicManage topicmanage)
     {
         SqlParameter[] prams = {
									    data.MakeInParam("@topicid",  SqlDbType.Int, 4, topicmanage._TopicID),
			};
        return (data.RunProc("delete from aspnet_Topic where TopicID=@topicid", prams));
     }
    #endregion

    #region 修改话题信息
     public int UpdateTopic(TopicManage topicmanage)
     { 
      SqlParameter[] prams = {
                                data.MakeInParam("@topicid", SqlDbType.Int, 4, topicmanage._TopicID),
                                data.MakeInParam("@classid", SqlDbType.Int, 4, topicmanage._ClassID),
                                data.MakeInParam("@createuserid", SqlDbType.UniqueIdentifier, 16, topicmanage._CreateUserID),
                                data.MakeInParam("@title", SqlDbType.NVarChar, 100, topicmanage._Title),
                                data.MakeInParam("@topiccontent", SqlDbType.NVarChar, 2000, topicmanage._TopicContent),
                                data.MakeInParam("@revertnum", SqlDbType.Int, 4, topicmanage._RevertNum),
                                data.MakeInParam("@image", SqlDbType.NVarChar, 50, topicmanage._Image),
                                data.MakeInParam("@attention", SqlDbType.Int, 4, topicmanage._Attention),
                                data.MakeInParam("@publishtime", SqlDbType.DateTime, 8, topicmanage._PublishTime),
                                data.MakeInParam("@isfoused", SqlDbType.Bit, 1, topicmanage._IsFoused),
                                data.MakeInParam("@isvisible", SqlDbType.Bit, 1, topicmanage._IsVisible),
                              };
      return (data.RunProc("update aspnet_Topic set ClassID = @classid, CreateUserID = @createuserid,Title = @title,TopicContent= @topiccontent,RevertNum = @revertnum,Image = @image,Attention = @attention,PublishTime = @publishtime,IsFoused = @isfoused,IsVisible = @isvisible where TopicID = @topicid",prams));
     }
    #endregion

    #region 查询话题信息
    /// 根据--分类编号--得到话题信息
     public DataSet FindTopicByClassID(TopicManage topicmanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@classid",  SqlDbType.Int, 4,topicmanage._ClassID),
			};
        return (data.RunProcReturn("select * from aspnet_Topic where ClassID = @classid ORDER BY PublishTime", prams, tbName));
    }
     /// 根据--话题编号--得到话题信息
     public DataSet FindTopicByTopicID(TopicManage topicmanage, string tbName)
     {
         SqlParameter[] prams = {
									    data.MakeInParam("@topicid",  SqlDbType.Int, 4,topicmanage._TopicID),
			};
         return (data.RunProcReturn("select * from aspnet_Topic where TopicID = @topicid ORDER BY PublishTime", prams, tbName));
     }
     /// 根据--用户编号--得到话题信息
     public DataSet FindTopicByUerID(TopicManage topicmanage, string tbName)
     {
         SqlParameter[] prams = {
									    data.MakeInParam("@createuserid",  SqlDbType.UniqueIdentifier,16,topicmanage._CreateUserID),
			};
         return (data.RunProcReturn("select * from aspnet_Topic where CreateUserID = @createuserid ORDER BY PublishTime", prams, tbName));
     }
     /// 根据--标题关键字--得到话题信息
     public DataSet FindTopicByTitle(TopicManage topicmanage, string tbName)
     {
         SqlParameter[] prams = {
									    data.MakeInParam("@title",  SqlDbType.NVarChar, 50,"%"+ topicmanage._Title +"%"),
			};
         return (data.RunProcReturn("select * from aspnet_Topic where Title like @title ORDER BY PublishTime", prams, tbName));
     }
     /// 根据--是否关注--得到话题信息
     public DataSet FindTopicByFoused(TopicManage topicmanage, string tbName)
     {
         SqlParameter[] prams = {
									    data.MakeInParam("@isfoused",  SqlDbType.Bit, 1,topicmanage._IsFoused),
			};
         return (data.RunProcReturn("select * from aspnet_Topic where IsFoused = @isfoused ORDER BY PublishTime", prams, tbName));
     }
     /// 根据--是否显示--得到话题信息
     public DataSet FindTopicByVisible(TopicManage topicmanage, string tbName)
     {
         SqlParameter[] prams = {
									    data.MakeInParam("@isvisible",  SqlDbType.Bit, 1,topicmanage._IsVisible),
			};
         return (data.RunProcReturn("select * from aspnet_Topic where IsVisible = @isvisible ORDER BY PublishTime", prams, tbName));
     }

     /// 得到所有--话题信息（时间）
     /// </summary>
     /// <param name="tbName"></param>
     /// <returns></returns>
     public DataSet GetAllTopicByTime(string tbName)
     {
         return (data.RunProcReturn("select * from aspnet_Topic ORDER BY PublishTime", tbName));
     }

     /// <summary>
     /// 得到所有--话题信息（热度）
     /// </summary>
     /// <param name="tbName"></param>
     /// <returns></returns>
     public DataSet GetAllTopicByAtten(string tbName)
     {
         return (data.RunProcReturn("select * from aspnet_Topic ORDER BY Attention", tbName));
     }
     /// <summary>
     /// 得到所有--话题信息（回复量）
     /// </summary>
     /// <param name="tbName"></param>
     /// <returns></returns>
     public DataSet GetAllTopicByRevert(string tbName)
     {
         return (data.RunProcReturn("select * from aspnet_Topic ORDER BY RevertNum", tbName));
     }
    #endregion

}

