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
///UserManage 的摘要说明
/// </summary>
public class UserManage
{
	public UserManage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    DataBase data = new DataBase();

    #region 定义注册用户--数据结构
    private string _username = "";
    private string _truename = "";
    private bool _sex = false;
    private string _myphoto = "";
    private int _topicnum= 0;
    private int _revertnum = 0;
    private string _email = "";
    private int _rank = 0;
    private int _authority = 0;
    private int _attention = 0;
    private DateTime _birthday = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private string _mydefault = "";

    public string _UserName
    {
        get { return _username; }
        set { _username = value; }
    }
    public string _TrueName
    {
        get { return _truename; }
        set { _truename = value; }
    }
    public bool _Sex
    {
        get { return _sex; }
        set { _sex = value; }
    }
    public string _MyPhoto
    {
        get { return _myphoto; }
        set { _myphoto = value; }
    }
    public int _TopicNum
    {
        get { return _topicnum; }
        set { _topicnum = value; }
    }
    public int _RevertNum
    {
        get { return _revertnum; }
        set { _revertnum = value; }
    }
    public string _Email
    {
        get { return _email; }
        set { _email = value; }
    }
    public int _Rank
    {
        get { return _rank; }
        set { _rank = value; }
    }
    public int _Authority
    {
        get { return _authority; }
        set { _authority = value; }
    }
    public int _Attention
    {
        get { return _attention; }
        set { _attention = value; }
    }
    public DateTime _Birthday
    {
        get { return _birthday; }
        set { _birthday = value; }
    }
    public string _MyDefault
    {
        get { return _mydefault; }
        set { _mydefault = value; }
    }
    #endregion

    #region 添加--用户信息
    /// <summary>
    /// 添加--用户信息
    /// </summary>
    /// <param name="usermanage"></param>
    /// <returns></returns>
    public int AddUser(UserManage usermanage)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@username",  SqlDbType.NVarChar, 50, usermanage._UserName),
                						data.MakeInParam("@truename",  SqlDbType.NVarChar, 50,usermanage._TrueName),
                						data.MakeInParam("@sex",  SqlDbType.Bit, 1, usermanage._Sex),
                						data.MakeInParam("@myphoto",  SqlDbType.NVarChar, 50, usermanage._MyPhoto),
                						data.MakeInParam("@topicnum",  SqlDbType.Int, 4, usermanage._TopicNum),
                						data.MakeInParam("@revertnum",  SqlDbType.Int, 4, usermanage._RevertNum),
                                        data.MakeInParam("@email",  SqlDbType.NVarChar, 50, usermanage._Email),
                						data.MakeInParam("@rank",  SqlDbType.Int, 4,usermanage._Rank),
                						data.MakeInParam("@authority",  SqlDbType.Int, 4, usermanage._Authority),
                						data.MakeInParam("@attention",  SqlDbType.Int, 4, usermanage._Attention),
                						data.MakeInParam("@birthday",  SqlDbType.DateTime, 8, usermanage._Birthday),
                						data.MakeInParam("@mydefault",  SqlDbType.NVarChar,50, usermanage._MyDefault),
                                        
			};
        return (data.RunProc("INSERT INTO aspnet_Users (UserName,TrueName,Sex,MyPhoto,TopicNum,RevertNum,Email,Rank,Authority,Attention,Birthday,MyDefault) "
            + "VALUES (@username,@truename,@sex,@myphoto,@topicnum,@revertnum,@email,@rank,@authority,@attention,@birthday,@mydefault)", prams));
    }
    #endregion

    #region 修改--用户信息
    /// <summary>
    /// 修改--用户信息
    /// </summary>
    /// <param name="usermanage"></param>
    /// <returns></returns>
    public int UpdateUser(UserManage usermanage)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@username",  SqlDbType.NVarChar, 50, usermanage._UserName),
                						data.MakeInParam("@truename",  SqlDbType.NVarChar, 50,usermanage._TrueName),
                						data.MakeInParam("@sex",  SqlDbType.Bit, 1, usermanage._Sex),
                						data.MakeInParam("@myphoto",  SqlDbType.NVarChar, 50, usermanage._MyPhoto),
                						data.MakeInParam("@topicnum",  SqlDbType.Int, 4, usermanage._TopicNum),
                						data.MakeInParam("@revertnum",  SqlDbType.Int, 4, usermanage._RevertNum),
                                        data.MakeInParam("@email",  SqlDbType.NVarChar, 50, usermanage._Email),
                						data.MakeInParam("@rank",  SqlDbType.Int, 4,usermanage._Rank),
                						data.MakeInParam("@authority",  SqlDbType.Int, 4, usermanage._Authority),
                						data.MakeInParam("@attention",  SqlDbType.Int, 4, usermanage._Attention),
                						data.MakeInParam("@birthday",  SqlDbType.DateTime, 8, usermanage._Birthday),
                						data.MakeInParam("@mydefault",  SqlDbType.NVarChar,50, usermanage._MyDefault),
			};
        return (data.RunProc("update aspnet_Users set TrueName=@truename,Sex=@sex,MyPhoto=@myphoto,TopicNum=@topicnum,RevertNum=@revertnum,Email=@email,"
            + "Rank=@rank,Authority=@authority,Attention=@attention,MyDefault=@mydefault where UserName=@username", prams));
    }
    #endregion

    #region 删除--用户信息
    /// <summary>
    /// 删除--用户信息
    /// </summary>
    /// <param name="usermanage"></param>
    /// <returns></returns>
    public int DeleteUser(UserManage usermanage)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@username",  SqlDbType.NVarChar, 50, usermanage._UserName),
			};
        
        Guid guid = new Guid(usermanage.FindUserByName(usermanage, "aspnet_Users").Tables[0].Rows[0][0].ToString());
        return (data.RunProc("delete from aspnet_Membership where ApplicationId = guid"));
    }
    #endregion

    #region 查询--用户信息
    /// <summary>
    /// 根据--用户姓名--得到用户信息
    /// </summary>
    /// <param name="usermanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindUserByName(UserManage usermanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@username",  SqlDbType.NVarChar, 50,"%"+ usermanage._UserName+"%"),
			};
        return (data.RunProcReturn("select * from aspnet_Users where UserName like @username", prams, tbName));
    }
    /// <summary>
    /// 得到所有--用户信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllUser(string tbName)
    {
        return (data.RunProcReturn("select * from aspnet_Users ORDER BY UserName", tbName));
    }
    #endregion

}