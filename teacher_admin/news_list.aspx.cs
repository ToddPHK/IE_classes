using System;
using System.Web.UI.WebControls;
using System.Data;

namespace IE_Class.teacher_admin
{
    public partial class news_list : System.Web.UI.Page
    {
        static int classid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int role = Convert.ToInt32(Request.Cookies["login"]["role"]);
                FillDropDownList(role);
            }
        }

        protected void DropDownListChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedIndex!=0)
            {
                classid = Convert.ToInt32(DropDownList1.SelectedValue);
                AspNetPager1.RecordCount = BLL.News.BLLGetNewsCount(classid);
                BindData(classid);
                GridView1.Visible = true;
                AspNetPager1.Visible = true;
            }
            else
            {
                GridView1.Visible = false;
                AspNetPager1.Visible = false;
            }
        }

        protected void FillDropDownList(int role)
        {
            if (role == 0)
            {
                DataTable dt = BLL.Class.BLLGetAllClass();
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = dt.Columns[0].ColumnName;
                DropDownList1.DataTextField = dt.Columns[1].ColumnName;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "请选择");
            }
            else
            {
                int teacherid = Convert.ToInt32(Request.Cookies["login"]["ID"]);
                DataTable dt = BLL.Teacher.BLLGetTeacherClass(teacherid);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = dt.Columns[2].ColumnName;
                DropDownList1.DataTextField = dt.Columns[3].ColumnName;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "请选择");
            }
        }

        protected void BindData(int classid)
        {
            DataSet ds = BLL.News.BLLGetNewsList(classid, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "teacherlist");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData(classid);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
                if (e.CommandName == "Del")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    int flag = BLL.News.BLLDeleteNews(id);
                    if (flag > 0)
                    {
                        Response.Write("<script>alert('删除成功！ ');window.window.location.href='news_list.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('删除失败！ ');window.window.location.href='news_list.aspx';</script>");
                    }
                }
        }
    }
}