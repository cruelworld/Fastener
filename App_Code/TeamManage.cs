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
///TeamManage 的摘要说明
/// </summary>
public class TeamManage
{
	public TeamManage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    DataBase data = new DataBase();

    #region 定义话题--数据结构
    private int _teamid = 0;
    private string _teamname = "";
    private DateTime _createtime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private Guid _createrid ;
    private string _createpos = "";
    private string _teamtitle= "";
    private string _createcontent= "";
    private DateTime _dateline= Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private int _maxnum= 0;
    private int _presentnum = 0;
    private int _attention= 0;
    private string _image = "";
    private int _classid = 0;
    private bool _isvisible = true;
    private bool _state = true;

    public int _TeamID
    {
        get { return _teamid; }
        set { _teamid = value; }
    }
    public string _TeamName
    {
        get { return _teamname; }
        set { _teamname = value; }
    }
    public DateTime _CreateTime
    {
        get { return _createtime; }
        set { _createtime = value; }
    }
    public Guid _CreaterID
    {
        get { return _createrid; }
        set { _createrid = value; }
    }
    public string _CreatePos
    {
        get { return _createpos; }
        set { _createpos = value; }
    }
    public string _TeamTitle
    {
        get { return _teamtitle; }
        set { _teamtitle = value; }
    }
    public string _CreateContent
    {
        get { return _createcontent; }
        set { _createcontent = value; }
    }
    public DateTime _DateLine
    {
        get { return _dateline; }
        set { _dateline = value; }
    }
    public int _MaxNum
    {
        get { return _maxnum; }
        set { _maxnum = value; }
    }
    public int _PresentNum
    {
        get { return _presentnum; }
        set { _presentnum = value; }
    }
    public int _Attention
    {
        get { return _attention; }
        set { _attention = value; }
    }

    public string _Image
    {
        get { return _image; }
        set { _image = value; }
    }

    public int _ClassID
    {
        get { return _classid; }
        set { _classid = value; }
    } 
 
    public bool _IsVisible
    {
        get { return _isvisible; }
        set { _isvisible = value; }
    } 
 
    public bool _State
    {
        get { return _state; }
        set { _state = value; }
    }
    #endregion

    #region 添加话题信息
    public int AddTeam(TeamManage teammanage)
    {
                                              
        SqlParameter[] prams = { 
                               
                                data.MakeInParam("@teamname", SqlDbType.NVarChar, 50, teammanage._TeamName),
                                data.MakeInParam("@createtime", SqlDbType.DateTime, 8, teammanage._CreateTime),
                                data.MakeInParam("@createrid", SqlDbType.UniqueIdentifier, 16, teammanage._CreaterID),
                                data.MakeInParam("@createpos", SqlDbType.NVarChar, 50, teammanage._CreatePos),
                                data.MakeInParam("@teamtitle", SqlDbType.NVarChar, 50, teammanage._TeamTitle),
                                data.MakeInParam("@createcontent", SqlDbType.NVarChar, 2000, teammanage._CreateContent),
                                data.MakeInParam("@dateline", SqlDbType.DateTime, 8, teammanage._DateLine),
                                data.MakeInParam("@maxnum", SqlDbType.Int, 4, teammanage._MaxNum),
                                data.MakeInParam("@presentnum", SqlDbType.Int, 4, teammanage._PresentNum),
                                data.MakeInParam("@attention", SqlDbType.Int, 4, teammanage._Attention),
                                data.MakeInParam("@image", SqlDbType.NVarChar, 50, teammanage._Image),
                                data.MakeInParam("@classid", SqlDbType.Int, 4, teammanage._ClassID),
                                data.MakeInParam("@isvisible", SqlDbType.Bit, 1, teammanage._IsVisible),
                                data.MakeInParam("@state", SqlDbType.Bit, 1, teammanage._State),
                               };
        return (data.RunProc("insert into aspnet_Team values(TeamName,CreateTime,CreaterID,CreatePos,TeamTitle,CreateContent,DateLine,MaxNum,PresentNum,Attention,Image,ClassID,IsVisible,State) values(@teamname,@createtime,@createrid,@createpos,@teamtitle,@createcontent,@dateline,@maxnum,@presentnum,@attention,@image,@classid,@isvisible,@state)", prams));
    }

   

    #endregion
    
    
    #region 删除组队信息
    public int DeleteTeam(TeamManage teammanage)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@teamid",  SqlDbType.Int, 4, teammanage._TeamID),
			};
        return (data.RunProc("delete from aspnet_Team where TeamID=@teamid", prams));
    }
    #endregion

    #region 修改话题信息
    public int UpdateTeam(TeamManage teammanage)
    {
        SqlParameter[] prams = {
                                    data.MakeInParam("@teamid", SqlDbType.Int, 4, teammanage._TeamID),
                                    data.MakeInParam("@teamname", SqlDbType.NVarChar, 50, teammanage._TeamName),
                                    data.MakeInParam("@createtime", SqlDbType.DateTime, 8, teammanage._CreateTime),
                                    data.MakeInParam("@createrid", SqlDbType.UniqueIdentifier, 16, teammanage._CreaterID),
                                    data.MakeInParam("@createpos", SqlDbType.NVarChar, 50, teammanage._CreatePos),
                                    data.MakeInParam("@teamtitle", SqlDbType.NVarChar, 50, teammanage._TeamTitle),
                                    data.MakeInParam("@createcontent", SqlDbType.NVarChar, 2000, teammanage._CreateContent),
                                    data.MakeInParam("@dateline", SqlDbType.DateTime, 8, teammanage._DateLine),
                                    data.MakeInParam("@maxnum", SqlDbType.Int, 4, teammanage._MaxNum),
                                    data.MakeInParam("@presentnum", SqlDbType.Int, 4, teammanage._PresentNum),
                                    data.MakeInParam("@attention", SqlDbType.Int, 4, teammanage._Attention),
                                    data.MakeInParam("@image", SqlDbType.NVarChar, 50, teammanage._Image),
                                    data.MakeInParam("@classid", SqlDbType.Int, 4, teammanage._ClassID),
                                    data.MakeInParam("@isvisible", SqlDbType.Bit, 1, teammanage._IsVisible),
                                    data.MakeInParam("@state", SqlDbType.Bit, 1, teammanage._State),
                              };
        return (data.RunProc("update aspnet_Team set TeamName = @teamname, CreateTime = @createtime,CreaterID = @createrid,CreatePos= @createpos,TeamTitle = @teamtitle,CreateContent = @createcontent,DateLine = @dateline,MaxNum = @maxnum,PresentNum = @presentnum,Attention = @attention,Image = @image,ClassID = @classid,IsVisible = @isvisible, State = @state where TeamID = @teamid", prams));
    }
    #endregion

    #region 查询话题信息
    /// 根据--分类编号--得到组队信息
    public DataSet FindTeamByClassID(TeamManage teammanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@classid",  SqlDbType.Int, 4,teammanage._ClassID),
			};
        return (data.RunProcReturn("select * from aspnet_Team where ClassID = @classid ORDER BY CreateTime", prams, tbName));
    }
    /// 根据--组队编号--得到组队信息
    public DataSet FindTeamByTeamID(TeamManage teammanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@teamid",  SqlDbType.Int, 4,teammanage._TeamID),
			};
        return (data.RunProcReturn("select * from aspnet_Team where TeamID = @teamid ORDER BY CreateTime", prams, tbName));
    }
    /// 根据--用户编号--得到话题信息
    public DataSet FindTeamByUerID(TeamManage teammanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@createrid",  SqlDbType.UniqueIdentifier, 4,teammanage._CreaterID),
			};
        return (data.RunProcReturn("select * from aspnet_Team where CreaterID = @createrid ORDER BY CreateTime", prams, tbName));
    }
    /// 根据--标题关键字--得到话题信息
    public DataSet FindTeamByTitle(TeamManage teammanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@teamtitle",  SqlDbType.NVarChar, 50,"%"+ teammanage._TeamTitle + "%"),
			};
        return (data.RunProcReturn("select * from aspnet_Team where TeamTitle like @teamtitle ORDER BY CreateTime", prams, tbName));
    }
    
    /// 根据--是否显示--得到话题信息
    public DataSet FindTeamByVisible(TeamManage teammanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@isvisible",  SqlDbType.Bit, 1,teammanage._IsVisible),
			};
        return (data.RunProcReturn("select * from aspnet_Team where IsVisible = @isvisible ORDER BY CreateTime", prams, tbName));
    }

    /// 根据--状态--得到话题信息
    public DataSet FindTeamByState(TeamManage teammanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@state",  SqlDbType.Int, 4,teammanage._State),
			};
        return (data.RunProcReturn("select * from aspnet_Team where State = @state ORDER BY CreateTime", prams, tbName));
    }

    /// 得到所有--话题信息（时间）
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllTeamByTime(string tbName)
    {
        return (data.RunProcReturn("select * from aspnet_Team ORDER BY CreateTime", tbName));
    }

    /// <summary>
    /// 得到所有--话题信息（热度）
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllTeamByAtten(string tbName)
    {
        return (data.RunProcReturn("select * from aspnet_Team ORDER BY Attention", tbName));
    }
   
    #endregion
}