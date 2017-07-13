using System;
using System.Web.UI.WebControls;
using System.Data;

namespace IE_Class.teacher_admin
{
    public partial class class_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = 10;
            if(!IsPostBack)
            {
                AspNetPager1.RecordCount = BLL.Class.BLLGetClassNumber();
                binddata();
            }

        }

        /// <summary>
        /// 绑定分页的数据
        /// </summary>
        public void binddata()
        {
            DataSet ds = BLL.Class.BLLGetClassList(AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "classlist");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        /// <summary>
        /// 改变页数时重新绑定数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            binddata();
        }

        /// <summary>
        /// 删除这一行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Request.Cookies["login"]["role"] == "0")
            {
                if (e.CommandName == "Delete")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    int flag = BLL.Class.BLLDeleteClass(id);
                    if (flag > 0)
                    {
                        Response.Write("<script>alert('删除成功！ ');window.window.location.href='class_list.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('删除失败！ ');window.window.location.href='class_list.aspx';</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('对不起，您没有这个权限');</script>");
            }
        }

    }
}