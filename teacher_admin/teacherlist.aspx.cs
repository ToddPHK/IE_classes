using System;
using System.Web.UI.WebControls;
using System.Data;

namespace IE_Class.teacher_admin
{
    public partial class teacherlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = 10;
            if(!IsPostBack)
            {
                AspNetPager1.RecordCount = BLL.Teacher.TeacherNumber(Request.Cookies["login"]["role"]);
                binddata();
            }

           

        }

        public void binddata()
        {
            DataSet ds = BLL.Teacher.Teacherlist(Request.Cookies["login"]["role"], AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "teacherlist");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            binddata();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(Request.Cookies["login"]["role"]=="0")
            {
                if(e.CommandName== "Delete")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    int flag = BLL.Teacher.TeacherDelete(id);
                    if (flag > 0)
                    {
                        Response.Write("<script>alert('删除成功！ ');window.window.location.href='teacherlist.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('删除失败！ ');window.window.location.href='teacherlist.aspx';</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('对不起，您没有这个权限');</script>");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}