using System;
using System.Data.SqlClient;

namespace IE_Class
{
    public partial class Update_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.Cookies["login"]["ID"]);
            string role = Request.Cookies["login"]["sort"];
            if(role == "teacher")
            {
                stuid.Visible = false;
                SqlDataReader sdr = BLL.Teacher.TeacherGetByID(id);
                while(sdr.Read())
                {
                    TextBox1.Text = sdr[1].ToString();
                    TextBox3.Text = sdr[3].ToString();
                    TextBox4.Text = sdr[4].ToString();
                }
            }
            else
            {
                Model.Student student = BLL.Student.BLLGetStudentByID(id);
                TextBox1.Text = student.Name;
                TextBox2.Text = student.StudentNumber;
                TextBox3.Text = student.Username;
                TextBox4.Text = student.Password;
            }
        }
    }
}