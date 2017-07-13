using System;
using System.Data;

namespace IE_Class
{
    public partial class Class_news_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            BindNews(id);
        }

        /// <summary>
        /// 绑定课程新闻
        /// </summary>
        /// <param name="classid">课程id</param>
        protected void BindNews(int classid)
        {
            DataTable dt = new DataTable();
            dt = BLL.News.BLLGetClassNews(classid);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}