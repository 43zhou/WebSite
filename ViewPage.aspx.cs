using System;
using System.Configuration;
using System.Data;

namespace WebSite
{
    public partial class ViewPage : System.Web.UI.Page
    {
        private string sqlCommand;
        Connect MyConnect = new Connect(ConfigurationManager.ConnectionStrings["ConnString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtB_name.Text = Request.QueryString["name"];
                txtB_applyId.Text = Request.QueryString["id"].ToString();
                sqlCommand = "select checkTypeId from checkiteminfo where uniqueApplyId=" + txtB_applyId.Text.ToString();
                if (ddl_checkType.Items.Count == 0)
                {
                    ddl_checkType.Items.Add("多导联");
                }

                if (MyConnect.SqlCommand(sqlCommand).Tables["list"].Rows.Count != 1)
                {
                    if (ddl_checkType.Items == null)
                    {
                        ddl_checkType.DataSource = MyConnect.SqlCommand(sqlCommand).Tables["list"].DefaultView;
                        ddl_checkType.DataTextField = "checktypeId";
                        ddl_checkType.DataBind();
                    }
                }

                try
                {
                    sqlCommand = "select rhythmheart,PR,RR,QRS,QT,QTc,AXIS,RV5,RV6,SV1,RS,XL,SL,FL,PWD,conclusion,feature"
                        + " from checkiteminfo where checkId="
                        + "'" + txtB_applyId.Text + "00201'";
                    FillDate();
                    FillPic("00201");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 当下拉列表的内容改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_checkType.Text == "多导联")
            {
                sqlCommand = "select rhythmheart,PR,RR,QRS,QT,QTc,AXIS,RV5,RV6,SV1,RS,XL from checkiteminfo where checkId="
                    + "'" + txtB_applyId.Text + "00201'";
            }
            else
            {
                sqlCommand = "select rhythmheart,PR,RR,QRS,QT,QTc,AXIS,RV5,RV6,SV1,RS,XL from checkiteminfo where checkId="
                    + "'" + txtB_applyId.Text + "00206'";
            }

            FillDate();

            if (ddl_checkType.Text == "多导联")
            {
                FillPic("00201");
            }
            else
            {
                FillPic("00206");  
            }
        }

        /// <summary>
        /// 填充图片
        /// </summary>
        /// <param name="type">检查类型</param>
        private void FillPic(string type)
        {
            string sqlstr = "select checkdate from checkdatainfo where checkresultId=" + txtB_applyId.Text.ToString() + type;
            DataSet newds = MyConnect.SqlCommand(sqlstr);
            string fileName = DateTime.Parse(newds.Tables["list"].Rows[0]["checkdate"].ToString()).ToString("yyyy-MM-dd-HH-mm-ss");
            string s = fileName.Replace("-", "");
            image1.ImageUrl = @"\img\" + Request.QueryString["id"].ToString() + type + @"\0_" + s + ".png";
        }

        /// <summary>
        /// 填充文本框数据
        /// </summary>
        private void FillDate()
        {
            DataSet ds = MyConnect.SqlCommand(sqlCommand);
            txtB_HR.Text = ds.Tables["list"].Rows[0]["rhythmheart"].ToString();
            txtB_PR.Text = ds.Tables["list"].Rows[0]["PR"].ToString();
            txtB_FL.Text = ds.Tables["list"].Rows[0]["FL"].ToString();
            txtB_QRS.Text = ds.Tables["list"].Rows[0]["QRS"].ToString();
            txtB_QT.Text = ds.Tables["list"].Rows[0]["QT"].ToString();
            txtB_QTc.Text = ds.Tables["list"].Rows[0]["QTc"].ToString();
            txtB_AXIS.Text = ds.Tables["list"].Rows[0]["AXIS"].ToString();
            txtB_RV5_SV1.Text = ds.Tables["list"].Rows[0]["RV5"].ToString() + "/" + ds.Tables["list"].Rows[0]["SV1"].ToString();
            txtB_RV6.Text = ds.Tables["list"].Rows[0]["RV6"].ToString();
            txtB_PWD.Text = ds.Tables["list"].Rows[0]["PWD"].ToString();
            txtB_RS.Text = ds.Tables["list"].Rows[0]["RS"].ToString();
            txtB_SL.Text = ds.Tables["list"].Rows[0]["SL"].ToString();
            txtB_conclution.Text = ds.Tables["list"].Rows[0]["conclusion"].ToString();
            txtB_fuature.Text = ds.Tables["list"].Rows[0]["feature"].ToString();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_print_Click(object sender, EventArgs e)
        {
            if (ddl_checkType.Text == "多导联")
            {
                Response.Write("<script>window.open('PrintPage.aspx?id="
                  + txtB_applyId.Text + "&type=00201&name=" + txtB_name.Text.ToString() + "')</script>");
            }
            else
            {
                Response.Write("<script>window.open('PrintPage.aspx?id="
                  + txtB_applyId.Text + "&type=00206&name=" + txtB_name.Text.ToString() + "')</script>");
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}