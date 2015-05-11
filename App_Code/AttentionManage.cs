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
///AttentionManage 的摘要说明
/// </summary>
public class AttentionManage
{
	public AttentionManage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();
    #region 定义关注--数据结构
    private int _attentionid= 0;
    private Guid _userid;
    private int _createteamid = 0;
    private int _createtopicid = 0;
    
    public int _AttentionID
    {
        get { return _attentionid; }
        set { _attentionid = value; }
    }
    public Guid _UserId
    {
        get { return _userid; }
        set { _userid = value; }
    }
    public int _CreateTeamID
    {
        get { return _createteamid; }
        set { _createteamid = value; }
    }
    public int _CreateTopicID
    {
        get { return _createtopicid; }
        set { _createtopicid = value; }
    }
   
    #endregion

    #region 添加--关注信息
    /// <summary>
    /// 添加--关注信息
    /// </summary>
    /// <param name="attentionmanage"></param>
    /// <returns></returns>
    public int AddAttention(AttentionManage attentionmanage)
    {
        SqlParameter[] prams = {
                                        data.MakeInParam("@userid",  SqlDbType.UniqueIdentifier, 16, attentionmanage._UserId),
                                        data.MakeInParam("@createteamid",  SqlDbType.Int, 4, attentionmanage._CreateTeamID),
                                        data.MakeInParam("@createtopicid",  SqlDbType.Int, 4, attentionmanage._CreateTopicID),
			};
        return (data.RunProc("INSERT INTO aspnet_Attention (UserId,CreateTeamID,CreateTopicID) VALUES (@userid,@createteamid,@createtopicid)", prams));
    }
    #endregion

    #region 修改--关注信息
    /// <summary>
    /// 修改--关注信息
    /// </summary>
    /// <param name="attentionmanage"></param>
    /// <returns></returns>
    public int UpdateAttention(AttentionManage attentionmanage)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@attentionid",  SqlDbType.Int, 4, attentionmanage._AttentionID),
                                        data.MakeInParam("@userid",  SqlDbType.UniqueIdentifier, 16, attentionmanage._UserId),
                                        data.MakeInParam("@createteamid",  SqlDbType.Int, 4, attentionmanage._CreateTeamID),
                                        data.MakeInParam("@createtopicid",  SqlDbType.Int, 4, attentionmanage._CreateTopicID),
			};
        return (data.RunProc("update aspnet_Attention set UserId =@userid, CreateTeamID = @createteamid,CreateTopicID = @createtopicid where AttentionID=@attentionid", prams));
    }
    #endregion

    #region 删除--关注信息
    /// <summary>
    /// 删除--关注信息
    /// </summary>
    /// <param name="attentionmanage"></param>
    /// <returns></returns>
    public int DeleteAttention(AttentionManage attentionmanage)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@attentionid",  SqlDbType.Int, 4, attentionmanage._AttentionID),
			};
        return (data.RunProc("delete from aspnet_Attention where AttentionID=@attentionid", prams));
    }
    #endregion

    #region 查询--关注信息
    /// <summary>
    /// 根据--关注编号--得到关注信息
    /// </summary>
    /// <param name="attentionmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindAttentionByID(AttentionManage attentionmanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@attentionid",  SqlDbType.Int, 4, attentionmanage._AttentionID),
			};
        return (data.RunProcReturn("select * from aspnet_Attention where AttentionID = @attentionid", prams, tbName));
    }
    
    public DataSet GetAllAttention(string tbName)
    {
        return (data.RunProcReturn("select * from aspnet_Attention ORDER BY AttentionID", tbName));
    }
    #endregion
}