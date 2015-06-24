using FastReport;
using FastReport.Export.Pdf;
using FastReport.Web;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;

namespace WebSite
{
    public partial class PrintPage : System.Web.UI.Page
    {
        string checkId;
        Connect MyConnect = new Connect(ConfigurationManager.ConnectionStrings["ConnString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkId = Request.QueryString["id"].ToString() + Request.QueryString["type"].ToString();
                SetReport_File();
            }
        }

        /// <summary>
        /// 获取报表模板
        /// </summary>
        public void SetReport_File()
        {
            //指定报表文件
            WebReport1.ReportFile = "report.frx";
            WebReport1.Prepare();
        }

        /// <summary>
        /// 填充报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void WebReport1_StartReport(object sender, EventArgs e)
        {
            Report aReport = (sender as WebReport).Report;
            string arname = aReport.ReportInfo.Name;
            //手工填写
            Set_ReportData_Bymanual(aReport);
        }

        /// <summary>
        /// 设置报表内容
        /// </summary>
        /// <param name="aReport">报表对象</param>
        protected void Set_ReportData_Bymanual(Report aReport)
        {
            string sql = "select t2.checkDoctorId,t2.diagnoseDoctorId,t4.checkdate,t2.uniqueApplyId,t4.ECGFILE,"
                + "t4.channelorder,t4.checkNo,t4.checkdate,t4.channellabel,"
                + "t1.name,t1.sex,t1.age,t1.cardID,t3.clinicalDiagnose,t2.checkId,t2.XL,"
                + "t2.rhythmheart,t2.PR,t2.QRS,t2.QT,t2.QTc,t2.AXIS,t2.RR,t2.RS,t2.RV5,t2.RV6,t2.SV1,t2.conclusion,"
                + "t2.feature,t2.checkTypeId,t1.patientId,t2.FL,t2.SL,t2.remark,t2.PWD,t3.applyDoctorNm,t3.applyDeptNm,"
                + "t3.inHospitalId from patientinfo t1,checkiteminfo t2,patientapplyinfo t3,"
                + "checkdatainfo t4 where t1.patientId=t3.patientId and t3.uniqueApplyId=t2.uniqueApplyId and "
                + "t2.checkId=t4.checkresultId and t2.checkId='" + checkId + "' order by t4.checkdate";
            DataSet ds = MyConnect.SqlCommand(sql);
            TextObject aTextCtl;
            PictureObject test;
            RichObject richObj;

            //取得所有Report中的对象
            FastReport.ObjectCollection OList = aReport.AllObjects;
            foreach (object a in OList)
            {
                string aType = a.GetType().ToString();

                if (aType == "FastReport.TextObject")
                {
                    aTextCtl = (FastReport.TextObject)a;
                    if (aTextCtl.Name == "name")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["name"].ToString();
                    if (aTextCtl.Name == "sex")
                    {
                        if (ds.Tables["list"].Rows[0]["sex"].ToString() == "0")
                            aTextCtl.Text = "女";
                        else if (ds.Tables["list"].Rows[0]["sex"].ToString() == "1")
                            aTextCtl.Text = "男";
                        else
                            aTextCtl.Text = "未知";
                    }                        
                    if (aTextCtl.Name == "age")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["age"].ToString();
                    if (aTextCtl.Name == "inHospitalId")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["inHospitalId"].ToString();
                    if (aTextCtl.Name == "applyDoctorNm")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["applyDoctorNm"].ToString();
                    if (aTextCtl.Name == "xl")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["rhythmheart"].ToString();
                    if (aTextCtl.Name == "FL")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["FL"].ToString();
                    if (aTextCtl.Name == "SL")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["SL"].ToString();
                    if (aTextCtl.Name == "axis")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["AXIS"].ToString();
                    if (aTextCtl.Name == "qt")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["QT"].ToString();
                    if (aTextCtl.Name == "qtc")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["QTc"].ToString();
                    if (aTextCtl.Name == "PWD")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["PWD"].ToString();
                    if (aTextCtl.Name == "pr")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["PR"].ToString();
                    if (aTextCtl.Name == "qrs")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["QRS"].ToString();
                    if (aTextCtl.Name == "rv5")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["RV5"].ToString();
                    if (aTextCtl.Name == "sv1")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["SV1"].ToString();
                    if (aTextCtl.Name == "rr")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["RR"].ToString();
                    if (aTextCtl.Name == "Memo38")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["checkdate"].ToString();
                    if(aTextCtl.Name == "Memo21")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["applyDoctorNm"].ToString();
                    if(aTextCtl.Name == "Memo23")
                        aTextCtl.Text = ds.Tables["list"].Rows[0]["clinicalDiagnose"].ToString();
                    if (aTextCtl.Name == "checkDocName")
                    {
                        try
                        {
                            string sqlstr = "select name from usrinfo where usrId='" + ds.Tables["list"].Rows[0]["checkDoctorId"].ToString() + "'";
                            DataSet name = MyConnect.SqlCommand(sqlstr);
                            aTextCtl.Text = name.Tables[0].Rows[0]["name"] as string;
                        }
                        catch { }
                    }
                    if (aTextCtl.Name == "dignoseDocName")
                    {
                        try
                        {
                            string sqlstr = "select name from usrinfo where usrId='" + ds.Tables["list"].Rows[0]["diagnoseDoctorId"].ToString() + "'";
                            DataSet name = MyConnect.SqlCommand(sqlstr);
                            aTextCtl.Text = name.Tables[0].Rows[0]["name"] as string;
                        }
                        catch { }
                    }
                }

                if (aType == "FastReport.RichObject")
                {
                    richObj = (FastReport.RichObject)a;
                    if (richObj.Name == "Rich3")
                        richObj.Text = ds.Tables["list"].Rows[0]["feature"].ToString();
                    if (richObj.Name == "Rich1")
                        richObj.Text = ds.Tables["list"].Rows[0]["conclusion"].ToString();
                }

                if (aType == "FastReport.PictureObject")
                {
                    test = (FastReport.PictureObject)a;
                    if (test.Name == "img")
                    {
                        try
                        {
                            string sqlstr = "select checkdate from checkdatainfo where checkresultId=" + checkId;
                            DataSet newds = MyConnect.SqlCommand(sqlstr);
                            string fileName = DateTime.Parse(newds.Tables["list"].Rows[0]["checkdate"].ToString()).ToString("yyyy-MM-dd-HH-mm-ss");
                            string uri = @"E:\WebSite\WebSite\img\" + checkId + @"\0_" + fileName.Replace("-", "") + ".png";
                            Bitmap source = new Bitmap(uri);
                            test.Image = source;
                        }
                        catch
                        {
                            
                        }
                    }

                    if (test.Name == "Picture1")
                    {
                        test.Image = new Bitmap(@"E:\WebSite\WebSite\img\1.png");
                    }

                    if (test.Name == "Picture2")
                    {
                        string checkDocId = ds.Tables["list"].Rows[0]["checkDoctorId"].ToString();
                        test.Image = DocNamePic(checkDocId);
                        if (DocNamePic(checkDocId) != null)
                        {
                            test.Visible = true;
                        }
                    }

                    if (test.Name == "Picture3")
                    {
                        string diagnoseDocId = ds.Tables["list"].Rows[0]["diagnoseDoctorId"].ToString();
                        test.Image = DocNamePic(diagnoseDocId);
                        if (DocNamePic(diagnoseDocId) != null)
                        {
                            test.Visible = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取签名图片
        /// </summary>
        /// <param name="docId">医生ID</param>
        /// <returns></returns>
        private System.Drawing.Image DocNamePic(string docId)
        {
            try
            {
                string sqlstr = "select signpath from usrinfo where usrId='" + docId + "'";
                DataSet namePic = MyConnect.SqlCommand(sqlstr);
                byte[] pic = (byte[])namePic.Tables[0].Rows[0]["signpath"];
                MemoryStream ms = new MemoryStream(pic);
                return new Bitmap(ms, true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 导出报告
        /// </summary>
        /// <param name="aReport">报表对象</param>
        protected void Export_Report(Report aReport)
        {
            // save file in stream
            Stream stream = new MemoryStream();
            WebReport1.Report.Export(new PDFExport(), stream);
            stream.Position = 0;     
        }
    }
}