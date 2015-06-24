using System;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class Index : System.Web.UI.Page
    {
        string sqlCommand = "select uniqueApplyId, name, (case sex when 1 then '男' else '女' end) as sex,"
                        + "cardID,inHospitalId, applyId from v_casemanage where st = 5 ";
        Connect MyConnect = new Connect(ConfigurationManager.ConnectionStrings["ConnString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(sqlCommand);
            }
        }

        public void BindData(string sqlCommand)
        {
            GridView1.DataSource = MyConnect.SqlCommand(sqlCommand);
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //分页完成之前
            if (e.NewPageIndex >= 0 && e.NewPageIndex < GridView1.PageCount)
                GridView1.PageIndex = e.NewPageIndex;
            BindData(sqlCommand);
        }

        /// <summary>
        /// Go 超链接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GoIndex(object sender, EventArgs e)
        {
            GridViewRow pagerRow = GridView1.BottomPagerRow;
            TextBox pageNum = pagerRow.Cells[0].FindControl("tbpage") as TextBox;
            int idx = 0;
            if (pageNum.Text != null)
            {
                try
                {
                    idx = Int32.Parse(pageNum.Text);
                }
                catch
                {
                }
            }
            GridView1.PageIndex = idx > 0 ? idx - 1 : 0;
        }

        /// <summary>
        /// 双击跳转事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string dirpath = @"E:\WebSite\WebSite\img\" + e.Row.Cells[0].Text + "00201";
                string dirpath2 = @"E:\WebSite\WebSite\img\" + e.Row.Cells[0].Text + "00206";

                //if (Request.Browser.MajorVersion == 6)
                //{
                //    e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor='White';this.style.color='#003399'");
                //    e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor='#6699FF';this.style.color='#8C4510'");
                //}
                if (Directory.Exists(dirpath) /*|| Directory.Exists(dirpath2)*/)
                {
                    //e.Row.Attributes.Add("ondblclick", "document.location('ViewPage.aspx?id=" + e.Row.Cells[0].Text + "&name="
                    //    + e.Row.Cells[1].Text + "')");
                    //e.Row.Attributes.Add("ondblclick", "window.location='ViewPage.aspx?id=" + e.Row.Cells[0].Text + "&name="
                    //    + e.Row.Cells[1].Text + "'");
                    e.Row.Attributes.Add("ondblclick", "window.location='PrintPage.aspx?id=" + e.Row.Cells[0].Text + "&type=00201'");

                }
                else
                {
                    e.Row.Attributes.Add("ondblclick", "alert('图片尚未上传。')");
                }
            }
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string uniqueApplyId;
            string name;
            string inHostpitalId;
            string applyId;
            string applyDeptNm = "applyDeptNm" + Resourss.Text;
            string checkType;
            if (CheckItem.SelectedIndex == 0)
            {
                checkType = " checkItemId=002";
            }
            else
            {
                checkType = " checkItemId=0";
            }
            if (CarNumberTextBox.Text != "")
            {
                uniqueApplyId = " uniqueApplyId=" + CarNumberTextBox.Text.ToString() + " and ";
            }
            else
            {
                uniqueApplyId = "";
            }

            if (NameTextBox.Text != "")
            {
                name = " name='" + NameTextBox.Text.ToString() + "' and ";
            }
            else
            {
                name = "";
            }

            if (HospitalizedNumberTextBox.Text != "")
            {
                inHostpitalId = " inHospitalId='" + HospitalizedNumberTextBox.Text + "' and ";
            }
            else
            {
                inHostpitalId = "";
            }

            if (ApplyIDTextBox.Text != "")
            {
                applyId = " applyId='" + ApplyIDTextBox.Text + "' and ";
            }
            else
            {
                applyId = "";
            }

            if (Resourss.Text == "*")
            {
                applyDeptNm = "";
            }
            else
            {
                applyDeptNm = " applyDeptNm='" + Resourss.Text + "' and ";
            }

            try
            {
                sqlCommand = "select uniqueApplyId, name, (case sex when 1 then 'Male' else 'Female' end) as sex,"
                    + "cardID,inHospitalId, applyId "
                    + "from v_casemanage where st=5 and "
                    + uniqueApplyId + name + inHostpitalId + applyId + applyDeptNm + checkType;
                //sqlCommand = "select uniqueApplyId, name, (case sex when 1 then 'Male' else 'Female' end) as sex,"
                //    + "cardID,inHospitalId, applyId "
                //    + "from v_casemanage where uniqueapplyid='" + CarNumberTextBox.Text + "' and name='" + NameTextBox.Text
                //    + "' and inHospitalId='" + HospitalizedNumberTextBox.Text + "' and applyId='" + ApplyIDTextBox.Text + "' and applyDeptNm='"
                //    + Resourss.Text + "' and checkType='" + CheckItem.SelectedValue.ToString() + "' and st = 5";
                BindData(sqlCommand);
            }
            catch
            {
                Response.Write("<script>alert('查询出现异常。')</script>");
            }
        }

        /// <summary>
        /// 更改列名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string[] filedNames = { "申请号", "姓名", "性别", "卡号", "住院号", "申请ID" };
            if (e.Row.RowType != DataControlRowType.Header) 
                return;
            GridViewRow gvr = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

            int i = 0;
            for (i = 0; i < filedNames.Length; i++)
            {
                TableCell tc = new TableCell();
                tc.Text = filedNames[i].ToString();
                gvr.Cells.Add(tc);
            }
            this.GridView1.Controls[0].Controls.AddAt(0, gvr);
        }
    }
}