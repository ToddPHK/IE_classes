using System;
using System.Data;

namespace IE_Class.teacher_admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                FillTextBox(id);
                FillDropDownList(id);

            }
        }

        protected void FillTextBox(int id)
        {
            Model.Student person = BLL.Student.BLLGetStudentByID(id);
            TextBox1.Text = person.Name;
            TextBox2.Text = person.StudentNumber;
            TextBox3.Text = person.Username;
            TextBox4.Text = person.Password;
            TextBox5.Text = DateTime.Now.Year.ToString();
        }

        protected void FillDropDownList(int id)
        {
            DataTable dt = BLL.Student.BLLGetStudentClass(id);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = dt.Columns[1].ColumnName;
            DropDownList1.DataValueField = dt.Columns[0].ColumnName;
            DropDownList1.DataBind();

            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = dt.Columns[1].ColumnName;
            DropDownList3.DataValueField = dt.Columns[0].ColumnName;
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, "请选择");

            dt = BLL.Student.BLLGetStudentNoClass(id);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = dt.Columns[1].ColumnName;
            DropDownList2.DataValueField = dt.Columns[0].ColumnName;
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "请选择");

            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.Student person = new Model.Student();

            person.Name = TextBox1.Text;
            person.StudentNumber = TextBox2.Text;
            person.Username = TextBox3.Text;
            person.Password = TextBox4.Text;
            person.Id = Convert.ToInt32(Request.QueryString["id"]);
            string year = TextBox5.Text;

            int flag = 0;
            flag = BLL.Student.BLLUpdateStudent(person);
            if(flag<=0)
            {
                Response.Write("<script>alert('修改学生信息失败！请重试！ ');window.window.location.href='studentlist.aspx';</script>"); 
            }

            if(DropDownList2.SelectedIndex!=0)
            {
                int classid = Convert.ToInt32(DropDownList2.SelectedValue);
                flag = BLL.Student.BLLInsertStudentClass(classid, person.Id, year);
                if (flag <= 0)
                {
                    Response.Write("<script>alert('添加学生到课程失败！请重试！ ');window.window.location.href='studentlist.aspx';</script>");
                }
            }

            if(DropDownList3.SelectedIndex!=0)
            {
                int classid = Convert.ToInt32(DropDownList3.SelectedValue);
                flag = BLL.Student.BLLDeleteStudentClass(classid, person.Id);
                if (flag <= 0)
                {
                    Response.Write("<script>alert('删除学生和课程关联！请重试！ ');window.window.location.href='studentlist.aspx';</script>");
                }
            }

            Response.Write("<script>alert('操作成功！ ');window.window.location.href='studentlist.aspx';</script>");

        }
    }
}