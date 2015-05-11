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
///ClassManage 的摘要说明
/// </summary>
public class ClassManage
{
	public ClassManage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义分类--数据结构
    private int _classid = 0;
    private string _classname = "";
    /// <summary>
    /// 分类编号
    /// </summary>
    public int _ClassID
    {
        get { return _classid; }
        set { _classid = value; }
    }
    /// <summary>
    /// 分类名称
    /// </summary>
    public string _ClassName
    {
        get { return _classname; }
        set { _classname = value; }
    }
    #endregion

    #region 添加--分类信息
    /// <summary>
    /// 添加--分类信息
    /// </summary>
    /// <param name="classmanage"></param>
    /// <returns></returns>
    public int AddClass(ClassManage classmanage)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@classid",  SqlDbType.Int, 4, classmanage._ClassID),
                                        data.MakeInParam("@classname",  SqlDbType.NVarChar, 50, classmanage._ClassName),
			};
        return (data.RunProc("INSERT INTO aspnet_Class (ClassID,ClassName) VALUES (@classid,@classname)", prams));
    }
    #endregion

    #region 修改--分类信息
    /// <summary>
    /// 修改--分类信息
    /// </summary>
    /// <param name="classmanage"></param>
    /// <returns></returns>
    public int UpdateClass(ClassManage classmanage)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@classid",  SqlDbType.Int, 4, classmanage._ClassID),
                                        data.MakeInParam("@classname",  SqlDbType.NVarChar, 50, classmanage._ClassName),
			};
        return (data.RunProc("update aspnet_Class set ClassName =@classname where ClassID=@classid", prams));
    }
    #endregion

    #region 删除--分类信息
    /// <summary>
    /// 删除--分类信息
    /// </summary>
    /// <param name="classmanage"></param>
    /// <returns></returns>
    public int DeleteClass(ClassManage classmanage)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@classid",  SqlDbType.Int, 4, classmanage._ClassID),
			};
        return (data.RunProc("delete from aspnet_Class where ClassID=@classid", prams));
    }
    #endregion

    #region 查询--分类信息
    /// <summary>
    /// 根据--分类编号--得到分类信息
    /// </summary>
    /// <param name="classmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindClassByID(ClassManage classmanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@classid",  SqlDbType.Int, 4, classmanage._ClassID),
			};
        return (data.RunProcReturn("select * from aspnet_Class where ClassID = @classid", prams, tbName));
    }
    /// <summary>
    /// 根据--分类名称--得到分类信息
    /// </summary>
    /// <param name="classmanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindClassByName(ClassManage classmanage, string tbName)
    {
        SqlParameter[] prams = {
									    data.MakeInParam("@classname",  SqlDbType.NVarChar, 50, "%"+classmanage._ClassName+"%"),
			};
        return (data.RunProcReturn("select * from aspnet_Class where ClassName like @classname", prams, tbName));
    }
    /// <summary>
    /// 得到所有--版块信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllClass(string tbName)
    {
        return (data.RunProcReturn("select * from aspnet_Class ORDER BY ClassID", tbName));
    }
    #endregion

}