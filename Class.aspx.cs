using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace IE_Class
{
    public partial class Class : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textLink1.HRef = "file_download.aspx?id=" + Request.QueryString["id"];
            textLink2.HRef = "homework_upload.aspx?id="+ Request.QueryString["id"];
            textLink3.HRef = "Class_news_list.aspx?id="+ Request.QueryString["id"];
            int id = Convert.ToInt32(Request.QueryString["id"]);
            BindNews(id);
            BindFunction(id);
        }

        /// <summary>
        /// 绑定新闻信息
        /// </summary>
        /// <param name="classid">课程id</param>
        protected void BindNews(int classid)
        {
            DataTable dt = new DataTable();

            dt = BLL.News.BLLGetClassOneSortNews(classid, 1);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            dt = BLL.News.BLLGetClassOneSortNews(classid, 2);
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            dt = BLL.News.BLLGetClassOneSortNews(classid, 3);
            Repeater3.DataSource = dt;
            Repeater3.DataBind();

        }

        /// <summary>
        /// 绑定课程自定义功能信息
        /// </summary>
        /// <param name="classid">课程id</param>
        protected void BindFunction(int classid)
        {
            SqlDataReader sdr = BLL.Function.BLLGetClassFunction(classid);

            int count = 0;
            while(sdr.Read())
            {
                count++;
                
                switch(count)
                {
                    case 1:
                        Name_Label1.Text = sdr["name"].ToString();
                        Intro_Label1.Text = sdr["intro"].ToString();
                        img4.Src = sdr["img"].ToString();
                        A4.HRef = sdr["link"].ToString();
                        second.Visible = true;
                        function1.Visible = true;
                        break;
                    case 2:
                        Name_Label2.Text = sdr["name"].ToString();
                        Intro_Label2.Text = sdr["intro"].ToString();
                        img5.Src = sdr["img"].ToString();
                        A5.HRef = sdr["link"].ToString();
                        function2.Visible = true;
                        break;
                    case 3:
                        Name_Label3.Text = sdr["name"].ToString();
                        Intro_Label3.Text = sdr["intro"].ToString();
                        img6.Src = sdr["img"].ToString();
                        A6.HRef = sdr["link"].ToString();
                        function3.Visible = true;
                        break;
                    default:
                        break;
                }
            }
            sdr.Close();
        }

        protected void Button_Command(object sender, CommandEventArgs e)
        {

        }
    }
}