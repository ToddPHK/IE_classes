using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace IE_Class
{
    public partial class Class_Master : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 验证是否已经登陆，显示课程名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["login"] == null)
            {
                Response.Write("<script>alert('请先登录！ ');window.window.location.href='/Login.aspx';</script>");
            }

            else if(Request.QueryString["id"] == null)
            {
                Response.Write("<script>alert('非法访问，请从首页进入！ ');window.window.location.href='/Default.aspx';</script>");
            }

            else
            {
                if (Request.Cookies["login"]["sort"].ToString() == "student")
                {
                    int classid = Convert.ToInt32(Request.QueryString["id"]);
                    int stuid = Convert.ToInt32(Request.Cookies["login"]["ID"]);
                    int flag = BLL.Class.BLLVerifyClassStu(classid, stuid);
                    if(flag <= 0)
                    {
                        Response.Write("<script>alert('你没有该课程权限！ ');window.window.location.href='Default.aspx';</script>");
                    }
                }
            }
            
            try
            { 
                int classid = Convert.ToInt32(Request.QueryString["id"]);
                SqlDataReader sdr = BLL.Class.BLLGetClassByID(classid);
                Model.Class item = new Model.Class();
                while (sdr.Read())
                {
                    item.Name = sdr[1].ToString();
                    item.Introduction = sdr[2].ToString();
                }

                Page.Title = item.Name;
                Label_title.Text = item.Name;
                Label_intro.Text = item.Introduction;

                sdr.Close();
            }
            catch
            {
                Response.Write("<script>window.window.location.href='/Default.aspx';</script>");
            }
        }
    }
}