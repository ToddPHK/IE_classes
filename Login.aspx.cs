using System;
using System.Web;
using System.Web.UI;
using Common;
using Model;
using System.Data.SqlClient;

namespace IE_Class
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                string username = UserName.Text;
                string password = Password.Text;
                string role;
                if (RadioButtonTeacher.Checked == true)
                    role = "teacher";
                else
                    role = "student";

                int i=Filter.LoginFilter(username.ToLower()), j= Filter.LoginFilter(password.ToLower());
                if(i==1||j==1)
                {
                    Response.Write("<script>alert('输入过长，请不要超过18个字符！ ');window.window.location.href='Login.aspx';</script>");
                }
                else if(i==2||j==2)
                {
                    Response.Write("<script>alert('使用了非法字符 ’\\ * & ) < >等，请重新输入！ ');window.window.location.href='Login.aspx';</script>");
                }
                else if(i==3||j==3)
                {
                    Response.Write("<script>alert('字符串中包含非法字符串，请重新输入！ ');window.window.location.href='Login.aspx';</script>");
                }
                else
                {
                    if (role=="teacher")
                    {
                        Teacher teacher = new Teacher();
                        teacher.Username = username;
                        teacher.Password = password;
                        SqlDataReader sqlr = BLL.Teacher.BllInquireTeacher(teacher);

                        if (sqlr.Read())
                        {
                            HttpCookie mycookie = new HttpCookie("login");
                            mycookie.HttpOnly = true;

                            mycookie.Values.Add("ID", sqlr["id"].ToString());
                            mycookie.Values.Add("sort", role);//记录是教师还是学生
                            mycookie.Values.Add("username", teacher.Username);
                            mycookie.Values.Add("name", sqlr["name"].ToString());
                            mycookie.Values.Add("role", sqlr["sort"].ToString());//1为普通老师，0为管理员

                            if(CheckBox1.Checked)
                            {
                                TimeSpan ts = new TimeSpan(7, 0, 0, 0);
                                DateTime dt = DateTime.Now;
                                mycookie.Expires = dt.Add(ts); 
                            }

                            Response.AppendCookie(mycookie);

                            sqlr.Close();
                            Response.Write("<script>alert('登陆成功！欢迎你,老师！ ');window.window.location.href='Default.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('登陆失败！请重新验证！ ');window.window.location.href='Login.aspx';</script>");
                        }
                    }
                    else
                    {
                        Student stu = new Student();
                        stu.Username = username;
                        stu.Password = password;
                        SqlDataReader sqlr = BLL.Student.BllInquireStudent(stu);

                        if(sqlr.Read())
                        {
                            HttpCookie mycookie = new HttpCookie("login");
                            mycookie.Values.Add("ID", sqlr["id"].ToString());
                            mycookie.Values.Add("sort", role);//记录是教师还是学生
                            mycookie.Values.Add("username", stu.Username);
                            mycookie.Values.Add("name", sqlr["name"].ToString());
                            if (CheckBox1.Checked)
                            {
                                TimeSpan ts = new TimeSpan(7, 0, 0, 0);
                                DateTime dt = DateTime.Now;
                                mycookie.Expires = dt.Add(ts);
                            }
                            Response.AppendCookie(mycookie);
                            sqlr.Close();
                 
                            Response.Write("<script>alert('登陆成功！欢迎你,同学！ ');window.window.location.href='Default.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('登陆失败！请重新验证！ ');window.window.location.href='Login.aspx';</script>");
                        }
                    }
                }
            }
        }
    }
}