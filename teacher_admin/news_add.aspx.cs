using System;
using System.Data;

namespace IE_Class.teacher_admin
{
    public partial class news_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int role = Convert.ToInt32(Request.Cookies["login"]["role"]);
                FillDropDownList(role);
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
            DataTable dt2 = BLL.News.BLLGetNewsSort();
            DropDownList2.DataSource = dt2;
            DropDownList2.DataValueField = dt2.Columns[0].ColumnName;
            DropDownList2.DataTextField = dt2.Columns[1].ColumnName;
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "请选择");


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text==null||DropDownList1.SelectedIndex==0||DropDownList2.SelectedIndex==0)
            {
                Response.Write("<script>alert('请填写新闻标题，选择所属课程和类别！ ');</script>");
            }
            else
            {
                Model.News item = new Model.News();
                item.Title = TextBox1.Text;
                item.ClassId = Convert.ToInt32(DropDownList1.SelectedValue);
                item.Sort = Convert.ToInt32(DropDownList2.SelectedValue);
                item.Text = FCKeditor1.Value;
                item.Time = DateTime.Now.ToString();
                item.WriterId = Convert.ToInt32(Request.Cookies["login"]["ID"]);

                int flag = BLL.News.BLLInsertNews(item);
                if(flag == 1)
                {
                    Response.Write("<script>alert('添加新闻成功！ ');window.window.location.href='Default.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('添加新闻失败！ ');window.window.location.href='Default.aspx';</script>");
                }

            }
        }
    }
}