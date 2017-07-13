using System;
using System.Data;
using System.Web.UI.WebControls;

namespace IE_Class.teacher_admin
{
    public partial class homework_add : System.Web.UI.Page
    {
        static int classid;
        static string semester;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int role = Convert.ToInt32(Request.Cookies["login"]["role"]);
                FillDropDownList1(role);
                FillDropDownList2();
                FillDropDownList3();
                AspNetPager1.PageSize = 10;
            }
        }

        protected void FillDropDownList1(int role)
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

        protected void FillDropDownList2()
        {
            int year;
            DateTime time = DateTime.Now;
            if(time.Month>=8)
            {
                year = time.Year;
            }
            else
            {
                year = time.Year - 1;
            }
            ListItem li = new ListItem(year.ToString() + "-" + (year + 1).ToString());
            DropDownList2.Items.Add(li);

            year++;
            li = new ListItem(year.ToString() + "-" + (year + 1).ToString());
            DropDownList2.Items.Add(li);

        }

        protected void FillDropDownList3()
        {
            DataTable dt = BLL.Homework.BLLGetHomeworkSort();
            DropDownList3.DataSource = dt;
            DropDownList3.DataValueField = dt.Columns[0].ColumnName;
            DropDownList3.DataTextField = dt.Columns[1].ColumnName;
            DropDownList3.DataBind();
        }

        protected void BindData(int classid, string semester)
        {
            DataSet ds = BLL.Homework.BLLGetClassSubHomework(classid, semester, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "teacherlist");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void DropDownList_Changed(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedIndex!=0)
            {
                classid = Convert.ToInt32(DropDownList1.SelectedValue);
                semester = DropDownList2.SelectedValue;
                AspNetPager1.RecordCount = BLL.Homework.BLLGetSubHomeworkNumber(classid, semester);
                BindData(classid, semester);
                GridView1.Visible = true;
                AspNetPager1.Visible = true;
            }
            else
            {
                GridView1.Visible = false;
                AspNetPager1.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.SubHomework item = new Model.SubHomework();
            item.Name = TextBox1.Text;
            item.Deadline = TextBox2.Text + " 23:59:59";
            item.Classid = Convert.ToInt32(DropDownList1.SelectedValue);
            item.Times = BLL.Homework.BLLGetSubHomeworkCount(item.Classid)+1;
            item.Semester = DropDownList2.SelectedValue;
            item.SortId = Convert.ToInt32(DropDownList3.SelectedValue);
            int flag = BLL.Homework.BLLInsertSubHomework(item);

            if (flag > 0)
            {
                Response.Write("<script>alert('设置成功！ ');window.window.location.href='homework_add.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('设置失败！ ');window.window.location.href='homework_add.aspx';</script>");
            }

        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {

            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData(classid,semester);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
                if (e.CommandName == "Delete")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    int flag = BLL.News.BLLDeleteNews(id);
                    if (flag > 0)
                    {
                        Response.Write("<script>alert('删除成功！ ');window.window.location.href='homework_add.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('删除失败！ ');window.window.location.href='homework_add.aspx';</script>");
                    }
                }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}