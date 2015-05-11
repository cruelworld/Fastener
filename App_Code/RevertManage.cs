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
///RevertManage 的摘要说明
/// </summary>
public class RevertManage
{
	public RevertManage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();
    #region 定义回帖--数据结构
    private string _revertid = "";
    private int _topicid = 0;
    private int _teamid = 0;
    private string _revertcontent = "";
    private Guid _userid ;
    private int _attention = 0;
    private string _image = "";
    private DateTime _reverttime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    bool _isvisible = true;

    /// <summary>
    /// 回帖编号
    /// </summary>
    public string _RevertID
    {
        get { return _revertid; }
        set { _revertid = value; }
    }
    ///回帖话题编号
    ///
    public int _TopicID
    {
        get { return _topicid; }
        set { _topicid = value; }
    }
    ///组队编号
    ///
    public int _TeamID
    {
        get { return _teamid; }
        set {_teamid = value;}
    }
    ///回复内容
    ///
    public string _RevertContent
    {
        get {return _revertcontent;}
        set {_revertcontent = value;}
    }
    ///回复者
    ///
    public Guid _UserID
    {
        get {return _userid;}
        set {_userid = value;}
    }
    ///关注度
    ///
    public int _Attention
    {
        get { return _attention; }
        set { _attention = value; }
    }
    ///照片
    public string _Image
    {
        get { return _image; }
        set { _image = value; }
    }
    public DateTime _RevertTime
    {
        get { return _reverttime; }
        set { _reverttime = value; }
    }
    public bool _IsVisible
    {
        get { return _isvisible; }
        set { _isvisible = value; }
    }
    #endregion

    #region 添加--回帖信息
    /// <summary>
    /// 添加--回帖信息
    /// </summary>
    /// <param name="revertmanage"></param>
    /// <returns></returns>
    /// 
    public int AddRevert(RevertManage revertmanage)
    {
        SqlParameter[] prams = { 
                               
                                data.MakeInParam("@topicid", SqlDbType.Int, 4, revertmanage._TopicID),
                                data.MakeInParam("@teamid", SqlDbType.Int, 4, revertmanage._TeamID),
                                data.MakeInParam("@revertcontent", SqlDbType.NVarChar, 2000, revertmanage._RevertContent),
                                data.MakeInParam("@userid", SqlDbType.UniqueIdentifier, 16,revertmanage._UserID),
                                data.MakeInParam("@attention", SqlDbType.Int, 4, revertmanage._Attention),
                                data.MakeInParam("@image", SqlDbType.NVarChar, 50, revertmanage._Image),
                                data.MakeInParam("@reverttime", SqlDbType.DateTime, 8, revertmanage._RevertTime),
                                data.MakeInParam("@isvisible", SqlDbType.Bit, 1, revertmanage._IsVisible),
                               };
        return (data.RunProc("insert into aspnet_Revert values(TopicID,TeamID,RevertContent,UserID,Attention,Image,RevertTime,IsVisible) values(@topicid,@teamid,@revertcontent,@userid,@attention,@image,@reverttime,@isvisible)",prams));
    }
    #endregion

    #region 修改--回帖信息
    /// <summary>
    /// 修改--回帖信息
    /// </summary>
    /// <param name="revertmanage"></param>
    /// <returns></returns>
    public int UpdateRevert(RevertManage revertmanage)
    {
        SqlParameter[] prams = {
                                data.MakeInParam("@revertid", SqlDbType.Int, 4, revertmanage._RevertID),
								data.MakeInParam("@topicid", SqlDbType.Int, 4, revertmanage._TopicID),
                                data.MakeInParam("@teamid", SqlDbType.Int, 4, revertmanage._TeamID),
                                data.MakeInParam("@revertcontent", SqlDbType.NVarChar, 2000, revertmanage._RevertContent),
                                data.MakeInParam("@userid", SqlDbType.UniqueIdentifier, 16, revertmanage._UserID),
                                data.MakeInParam("@attention", SqlDbType.Int, 4, revertmanage._Attention),
                                data.MakeInParam("@image", SqlDbType.NVarChar, 50, revertmanage._Image),
                                data.MakeInParam("@reverttime", SqlDbType.DateTime, 8, revertmanage._RevertTime),
                                data.MakeInParam("@isvisible", SqlDbType.Bit, 1, revertmanage._IsVisible),
			};
        return (data.RunProc("update aspnet_Revert set TopicID=@topicid,TeamID=@teamid,RevertContent=@revertcontent,UserID = @userid,Attention = @attention, Image = @imge,RevertTime = @reverttime, IsVisible = @isvisible where RevertID=@revertid", prams));
    }
    #endregion
    
    #region 删除--回帖信息
    /// <summary>
    /// 删除--回帖信息
    /// </summary>
    /// <param name="revertmanage"></param>
    /// <returns></returns>
    public int DeleteRevert(RevertManage revertmanage)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@revertid",  SqlDbType.Int, 4, revertmanage._RevertID)
			};
        return (data.RunProc("delete from aspnet_Revert where RevertID=@revertid", prams));
    }
    #endregion

    #region 查询--回帖信息
    /// <summary>
    /// 根据--话题编号--得到回帖信息
    /// </summary>
    /// <param name="revertmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindRevertByTopicID(RevertManage revertmanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@topicid",  SqlDbType.Int, 4,revertmanage._TopicID),
			};
        return (data.RunProcReturn("select * from aspnet_Revert where TopicID = @topicid ORDER BY RevertTime", prams, tbName));
    }
    /// <summary>
    /// 根据--组队编号--得到回帖信息
    /// </summary>
    /// <param name="revertmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindRevertByTeamID(RevertManage revertmanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@teamid",    SqlDbType.Int, 4,revertmanage._TeamID),
			};
        return (data.RunProcReturn("select * from aspnet_Revert where TeamID = @teamid ORDER BY RevertTime", prams, tbName));
    }
    /// <summary>
    /// 根据--用户编号--得到回帖信息
    /// </summary>
    /// <param name="revertmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindRevertByUserID(RevertManage revertmanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@userid",  SqlDbType.UniqueIdentifier, 16, revertmanage._UserID),
			};
        return (data.RunProcReturn("select * from aspnet_Revert where UserID = @userid ORDER BY RevertTime", prams, tbName));
    }

    /// 根据--回复内容--得到回帖信息
    /// </summary>
    /// <param name="revertmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindRevertByRContent(RevertManage revertmanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@revertcontent",  SqlDbType.NVarChar, 2000, "%"+ revertmanage._RevertContent+"%"),
			};
        return (data.RunProcReturn("select * from aspnet_Revert where RevertContent like  @revertcontent ORDER BY RevertTime", prams, tbName));
    }
    /// <summary>
    /// 得到所有--回帖信息（时间）
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllRevertByTime(string tbName)
    {
        return (data.RunProcReturn("select * from aspnet_Revert ORDER BY RevertTime", tbName));
    }
    /// <summary>
    /// 得到所有--回帖信息（热度）
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllRevertByAtten(string tbName)
    {
        return (data.RunProcReturn("select * from aspnet_Revert ORDER BY Attention", tbName));
    }
    #endregion
}