using System;

namespace IE_Class.teacher_admin
{
    public partial class teacher_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["login"]["role"]=="0")
            {
                Admin.Visible = true;
            }
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.Teacher teacher = new Model.Teacher();
            teacher.Name = TextBox1.Text;
            teacher.Username = TextBox2.Text;
            teacher.Password = TextBox3.Text;

            if (Teacher.Checked == true)
                teacher.sort = 1;
            else
                teacher.sort = 0;

            int flag = BLL.Teacher.TeacherAdd(teacher);

            if (flag > 0)
            {
                Response.Write("<script>alert('添加成功！ ');window.window.location.href='teacherlist.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！可能是因为账户已存在或有非法字符！请重试！ ');window.window.location.href='teacher_add.aspx';</script>");
            }

        }
    }
}