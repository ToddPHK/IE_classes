using System;
using System.Data;

namespace IE_Class.teacher_admin
{
    public partial class news_update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int role = Convert.ToInt32(Request.Cookies["login"]["role"]);
                FillDropDownList(role);
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Model.News item = new Model.News();
                DataTable dt = BLL.News.BLLGetOneNews(id);

                item.Title = dt.Rows[0][1].ToString();
                item.Text = dt.Rows[0][2].ToString();
                item.ClassId = (int)dt.Rows[0][3];
                item.Sort = (int)dt.Rows[0][4];

                TextBox1.Text = item.Title;
                DropDownList1.SelectedIndex = item.ClassId;
                DropDownList2.SelectedIndex = item.Sort;
                FCKeditor1.Value = item.Text;
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
            if (TextBox1.Text == null || DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0)
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
                item.ID = Convert.ToInt32(Request.QueryString["id"]);
                int flag = BLL.News.BLLUpdateNews(item);
                if (flag == 1)
                {
                    Response.Write("<script>alert('修改新闻成功！ ');</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改新闻失败！ ');</script>");
                }

            }
        }
    }
}