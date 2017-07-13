using System;
using System.Data.SqlClient;
using System.Web;

namespace IE_Class
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = null;
            try {
                cookie = Request.Cookies["login"];
            }
            catch
            {
                cookie = null;
            }

            if(cookie == null)
            {
                Response.Write("<script>alert('请先登录！ ');window.window.location.href='/Login.aspx';</script>");
            }
            else
            {
                int id = Convert.ToInt32(cookie["ID"]);
                string role = cookie["sort"];
                if (role == "teacher")
                {
                    stuid.Visible = false;
                    SqlDataReader sdr = BLL.Teacher.TeacherGetByID(id);
                    while (sdr.Read())
                    {
                        Label1.Text = sdr[1].ToString();
                        Label3.Text = sdr[3].ToString();
                        Label4.Text = sdr[4].ToString();
                    }
                }
                else
                {
                    Model.Student student = BLL.Student.BLLGetStudentByID(id);
                    Label1.Text = student.Name;
                    Label2.Text = student.StudentNumber;
                    Label3.Text = student.Username;
                    Label4.Text = student.Password;
                }
            }
        }
    }
}