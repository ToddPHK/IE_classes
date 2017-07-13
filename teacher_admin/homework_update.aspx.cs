using System;
using System.Data;
using System.Web.UI.WebControls;

namespace IE_Class.teacher_admin
{
    public partial class homework_update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int role = Convert.ToInt32(Request.Cookies["login"]["role"]);
                FillDropDownList3();
                FillData();
            }
        }

        protected void FillData()
        {
            int subId = int.Parse(Request.QueryString["id"]);
            Model.SubHomework item = BLL.Homework.BLLGetSubHomeworkDetail(subId);
            TextBox1.Text = item.Name;
            DropDownList3.SelectedIndex = item.SortId;
            TextBox2.Text = item.Deadline;
        }

        protected void FillDropDownList3()
        {
            DataTable dt = BLL.Homework.BLLGetHomeworkSort();
            DropDownList3.DataSource = dt;
            DropDownList3.DataValueField = dt.Columns[0].ColumnName;
            DropDownList3.DataTextField = dt.Columns[1].ColumnName;
            DropDownList3.DataBind();
        }


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.SubHomework item = new Model.SubHomework();
            item.Name = TextBox1.Text;
            item.Deadline = TextBox2.Text + " 23:59:59";
            item.SortId = Convert.ToInt32(DropDownList3.SelectedValue);

            item.ID = int.Parse(Request.QueryString["id"]);

            int flag = BLL.Homework.BLLUpdateSubHomework(item);

            if (flag > 0)
            {
                Response.Write("<script>alert('修改成功！ ');</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！ ');</script>");
            }

        }

       
    }
}