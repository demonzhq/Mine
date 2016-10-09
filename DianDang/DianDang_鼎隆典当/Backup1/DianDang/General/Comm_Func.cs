using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

/* WebService 注释
    [getStockImageByCode]
    直接获得中国股票GIF分时走势图（545*300pixel/72dpi）
    输入参数：theStockCode = 股票代号，如：sh000001； 
    返回数据：股票GIF分时走势图。

    [getStockImageByteByCode]
    获得中国股票GIF分时走势图字节数组
    输入参数：theStockCode = 股票代号，如：sh000001； 返回数据：股票GIF分时走势图字节数组。
    字节流到图片可以参考以下方法（.NET vb）：
    HttpContext.Current.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache) '不缓存
    HttpContext.Current.Response.ClearContent()
    HttpContext.Current.Response.ContentType = "image/Gif"
    HttpContext.Current.Response.BinaryWrite(Ary) 'Ary 图片字节数组
    HttpContext.Current.Response.End()

    [getStockImage_kByCode]
    直接获得中国股票GIF日/周/月 K 线图（545*300pixel/72dpi）
    输入参数：theStockCode = 股票代号，如：sh000001；theType = K 线图类型（D：日[默认]、W：周、M：月）
    返回数据：股票GIF日 K 线图。

    [getStockImage_kByteByCode]
    获得中国股票GIF日/周/月 K 线图字节数组
    输入参数：theStockCode = 股票代号，如：sh000001；theType = K 线图类型（D：日[默认]、W：周、M：月）
    返回数据：股票GIF日 K 线图字节数组。

    [getStockInfoByCode]
    获得中国股票及时行情 String()
    输入参数：theStockCode = 股票代号，如：sh000001； 
    返回数据：一个一维字符串数组 String(24)，结构为：String(0)股票代号、String(1)股票名称、String(2)行情时间、String(3)最新价（元）、String(4)昨收盘（元）、String(5)今开盘（元）、String(6)涨跌额（元）、String(7)最低（元）、String(8)最高（元）、String(9)涨跌幅（%）、String(10)成交量（手）、String(11)成交额（万元）、String(12)竞买价（元）、String(13)竞卖价（元）、String(14)委比（%）、String(15)-String(19)买一 - 买五（元）/手、String(20)-String(24)卖一 - 卖五（元）/手。



 * */

class Comm_Func
{

    DianDang.WebService.ChinaStockWebService webSvr = null; //webservice
    //涨跌颜色定义
    public Color PubColorUp = Color.Red; //涨
    public Color PubColorDown = Color.Green; //跌
    public Color PubColorNormal = Color.Black; //不变

    public string PubTmpFileName = Path.GetTempFileName(); //临时文件
    public string PubMyStockFileName = ""; //管理自己的股票配件文件
    public string[] PubStockInfoCn = {"股票代号", "股票名称", "行情时间", "最新价（元）", "昨收盘（元）", 
            "今开盘（元）", "涨跌额（元）", "最低（元）", "最高（元）", "涨跌幅（%）", "成交量（手）", "成交额（万元）", 
            "竞买价（元）", "竞卖价（元）", "委比（%）", "买一（元）/手","买二（元）/手","买三（元）/手","买四（元）/手",
            "买五（元）/手", "卖一（元）/手","卖二（元）/手","卖三（元）/手","卖四（元）/手",
            "卖五（元）/手"}; //单股相关信息


    #region 提示
    public void MsgBox(string strMsg)
    {
        MessageBox.Show(strMsg, "系统提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    #endregion

    #region 初始化
    public void initalService()
    {
        if (webSvr == null)
            webSvr = new DianDang.WebService.ChinaStockWebService();
        GetStockFileName();

    }
    #endregion

    #region 根据代码获取单股相关值
    public string[] getStockInfoByCode(string strCode)
    {
        strCode = getCode(strCode);
        return webSvr.getStockInfoByCode(strCode);
    }
    #endregion

    #region 根据代码获取单股图表
    public string getStockImageByteByCode(string strCode)
    {
        strCode = getCode(strCode);
        if (File.Exists(PubTmpFileName)) File.Delete(PubTmpFileName);
        byte[] img = webSvr.getStockImageByteByCode(strCode);
        FileStream fs = new FileStream(PubTmpFileName, FileMode.Create);
        fs.Write(img, 0, img.Length);
        fs.Flush();
        fs.Close();
        return PubTmpFileName;
    }
    #endregion

    #region 获取过滤后的代码  0：深圳；6：上海
    private string getCode(string strCode)
    {
        strCode = strCode.ToUpper();
        if (strCode.Length < 6)
            return strCode;
        else if (strCode.Substring(0, 1) == "0")
            strCode = "SZ" + strCode;
        else if (strCode.Substring(0, 1) == "6")
            strCode = "SH" + strCode;
        else if (strCode.Substring(0, 2) != "SZ" && strCode.Substring(0, 2) != "SH")
            return strCode;
        return strCode;
    }
    #endregion

    #region 获取路径
    public string GetPath()
    {
        return Application.StartupPath + "\\";
    }

    public string GetStockFileName()
    {
        if (PubMyStockFileName == "")
            PubMyStockFileName = GetPath() + "\\MyStock.xml";
        return PubMyStockFileName;
    }
    #endregion
}
