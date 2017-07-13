using System;
using System.Web.UI;
using System.Data.SqlClient;

namespace IE_Class
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Model.News item = new Model.News();
            SqlDataReader sdr = BLL.News.BLLGetOneClassView(id);
            string personName = null;
            string className = null;

            while (sdr.Read())
            {
                item.Title = sdr[1].ToString();
                item.Text = sdr[2].ToString();
                item.Time = sdr[3].ToString();
                personName = sdr[5].ToString();
                className = sdr[4].ToString();
            }

            Page.Title = item.Title;
            Label1.Text = item.Title;
            Label2.Text = "所属课程：" + className;
            Label3.Text = "发布人：" + personName;
            Label4.Text = "发布时间：" + item.Time;
            Label5.Text = item.Text;
        }
    }
}