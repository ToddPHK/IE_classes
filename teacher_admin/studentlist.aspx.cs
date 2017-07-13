using System;
using System.Web.UI.WebControls;
using System.Data;

namespace IE_Class.teacher_admin
{
    public partial class studentlist : System.Web.UI.Page
    {

        static int classid;
        static string year;

        protected void DropDownList_Change(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedIndex!=0 &&DropDownList2.SelectedIndex!=0)
            {
                GridView1.Visible = true;
                AspNetPager1.Visible = true;
                classid = Convert.ToInt32(DropDownList1.SelectedValue);
                year = DropDownList2.SelectedValue;
                int count = BLL.Student.BLLGetStudentNumber(classid, year);
                AspNetPager1.RecordCount = count;
                binddata(classid, year);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = 15;
            if (!IsPostBack)
            {
                FillDropDownList();
            }
        }

        protected void binddata(int classid, string year)
        {
            DataSet ds = BLL.Student.BLLGetStudentList(AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "studentlist", classid, year);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void FillDropDownList()
        {
            DataTable dt = BLL.Class.BLLGetAllClass();
            DropDownList1.DataSource = dt;
            DropDownList1.DataValueField = dt.Columns[0].ColumnName;
            DropDownList1.DataTextField = dt.Columns[1].ColumnName;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "请选择");

            dt = BLL.Student.BLLGetAllSemester();
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = dt.Columns[0].ColumnName;
            DropDownList2.DataValueField= dt.Columns[0].ColumnName;
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "请选择");

        }

        protected void AspNetPager1_PageChanging1(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            binddata(classid,year);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            binddata(classid, year);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int flag = BLL.Student.BLLDeleteStudent(id);
                if (flag > 0)
                {
                    Response.Write("<script>alert('删除成功！ ');window.window.location.href='studentlist.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败！ ');window.window.location.href='studentlist.aspx';</script>");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}