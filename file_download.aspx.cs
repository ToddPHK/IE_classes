using System;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace IE_Class
{
    public partial class file_download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataTable dt = BLL.File.BLLGetClassFile(id);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        /// <summary>
        /// 根据文件id下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            string[] strs= BLL.File.BLLGetFilePath(id);

            string fileName = strs[1].Split('/')[1];
            string filePath = Server.MapPath(@"~\") + strs[1];

            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.ContentType = "application / octet - stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);

            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

    }
}