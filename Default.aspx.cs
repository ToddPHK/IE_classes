using System;
using System.Data;

namespace IE_Class
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //填充课程信息
            BindClass();
            //填充新闻信息
            BindNews();
            //温馨提示
            LastWord.Text = "认真对待学习，认真对待生活，认真对待你身边每一个人。保持对事专注，保持对人热情，保持对于世界的每一点好奇。这样，你将体会到为人的所有快乐。";
        }

        protected void BindClass()
        {
            DataTable dt = BLL.Class.BLLGetClasses();
            ClassBlockPanel.Visible = false;
            try
            {
                img1.Src = dt.Rows[0]["img"].ToString();
                className1.Text = dt.Rows[0]["name"].ToString();
                classIntor1.Text = dt.Rows[0]["intro"].ToString();
                textLink1.HRef = "http://mie.zju.edu.cn/cloud/";

                img2.Src = dt.Rows[1]["img"].ToString();
                className2.Text = dt.Rows[1]["name"].ToString();
                classIntor2.Text = dt.Rows[1]["intro"].ToString();
                textLink2.HRef = "Class.aspx?id=" + dt.Rows[1]["id"].ToString();

                img3.Src = dt.Rows[2]["img"].ToString();
                className3.Text = dt.Rows[2]["name"].ToString();
                classIntor3.Text = dt.Rows[2]["intro"].ToString();
                textLink3.HRef = "Class.aspx?id=" + dt.Rows[2]["id"].ToString();
            }
            catch
            {

            }
            if (dt.Rows.Count > 3)
            {
                ClassBlockPanel.Visible = true;
                int count = 3;

                ClassPanel1.Visible = true;
                img4.Src = dt.Rows[3]["img"].ToString();
                className4.Text = dt.Rows[3]["name"].ToString();
                classIntor4.Text = dt.Rows[3]["intro"].ToString();
                textLink4.HRef = "Class.aspx?id=" + dt.Rows[3]["id"].ToString();
                count++;

                if (dt.Rows.Count - count > 0)
                {
                    ClassPanel2.Visible = true;
                    img5.Src = dt.Rows[4]["img"].ToString();
                    className5.Text = dt.Rows[4]["name"].ToString();
                    classIntor5.Text = dt.Rows[4]["intro"].ToString();
                    textLink5.HRef = "Class.aspx?id=" + dt.Rows[4]["id"].ToString();
                    count++;
                }

                if (dt.Rows.Count - count > 0)
                {
                    ClassPanel3.Visible = true;
                    img6.Src = dt.Rows[5]["img"].ToString();
                    className6.Text = dt.Rows[5]["name"].ToString();
                    classIntor6.Text = dt.Rows[5]["intro"].ToString();
                    textLink6.HRef = "Class.aspx?id=" + dt.Rows[5]["id"].ToString();
                }
            }
        }

        protected void BindNews()
        {
            DataTable dt = new DataTable();

            dt = BLL.News.BLLGetOneSortNews(1);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            dt = BLL.News.BLLGetOneSortNews(2);
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            dt = BLL.News.BLLGetOneSortNews(3);
            Repeater3.DataSource = dt;
            Repeater3.DataBind();

        }
    }
}