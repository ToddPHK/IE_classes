using System;
using System.Data.SqlClient;

namespace IE_Class.teacher_admin
{
    public partial class teacher_update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
                Model.Teacher person = new Model.Teacher();
                person.Id = Convert.ToInt32(Request.QueryString["id"]);
                SqlDataReader sdr = BLL.Teacher.TeacherGetByID(person.Id);
                if(sdr.Read())
                {
                    person.Name = sdr[1].ToString();
                    person.Username = sdr[3].ToString();
                    person.Password = sdr[4].ToString();
                }
                sdr.Close();

                TextBox1.Text = person.Name;
                TextBox2.Text = person.Username;
                TextBox3.Text = person.Password;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Request.Cookies["login"]["role"]=="0"|| Request.Cookies["login"]["ID"]== Request.QueryString["id"])
            { 
                Model.Teacher person = new Model.Teacher();
                person.Id = Convert.ToInt32(Request.QueryString["id"]);
                person.Name = TextBox1.Text;
                person.Username = TextBox2.Text;
                person.Password = TextBox3.Text;
                int flag = BLL.Teacher.TeacherUpdate(person);
                if(flag > 0)
                {
                    Response.Write("<script>alert('修改成功！ ');window.window.location.href='teacherlist.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败！ ');window.window.location.href='teacherlist.aspx';</script>");
                }
            }
        }
    }
}