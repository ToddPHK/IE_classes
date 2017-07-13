using System;
using System.Web;

namespace IE_Class.teacher_admin
{
    public partial class t_admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = null;
            try
            {
                cookie = Request.Cookies["login"];
            }
            catch
            {
                cookie = null;
            }
                
            if(cookie != null)
            {
                if(cookie["sort"]=="teacher")
                {

                }
                else
                {
                    Response.Write("<script>alert('抱歉，你没有权限！ ');window.window.location.href='/Default.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请先登录！ ');window.window.location.href='/Login.aspx';</script>");
            }
        }
    }
}