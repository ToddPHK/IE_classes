using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace IE_Class.teacher_admin
{
    public partial class class_update : System.Web.UI.Page
    {
        //记录照片的路径和名称
        public static string pictureName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
                int id = Convert.ToInt32(Request.QueryString["id"]);
                SqlDataReader sdr = BLL.Class.BLLGetClassByID(id);
                Model.Class item = new Model.Class();
                if (sdr.Read())
                {
                    item.Name = sdr[1].ToString();
                    item.Introduction = sdr[2].ToString();
                    item.Weight = Convert.ToInt32(sdr[3]);
                    item.ImgUrl = sdr[4].ToString();
                }

                TextBox1.Text = item.Name;
                TextBox2.Text = item.Introduction;
                DropDownList1.SelectedIndex = item.Weight;
                img1.Src = @"~\" + item.ImgUrl;
                pictureName = item.ImgUrl;
            }


        }

        /// <summary>
        /// 上传课程图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();
                string[] allowExtension = { ".jpg", ".png", ".gif", ".bmp" };
                bool isPicture = false;
                bool isTooBig = false;
                foreach (string item in allowExtension)
                {
                    if (item == fileExtension)
                    {
                        isPicture = true;
                        break;
                    }
                }

                int fileSize = FileUpload1.PostedFile.ContentLength;
                if (fileSize > 4 * 1024 * 1024)
                {
                    isTooBig = true;
                }

                pictureName = @"image\" + DateTime.Now.ToString("yyyyMMddHHmmss");

                if (isPicture && !isTooBig)
                {
                    string fileName = Server.MapPath(@"~\") + pictureName + fileExtension;
                    FileUpload1.SaveAs(fileName);
                    img1.Src = @"~\" + pictureName + fileExtension;
                    pictureName += fileExtension;
                    Response.Write("<script>alert('上传成功！ ');</script>");

                }
                else if (isTooBig)
                {
                    Response.Write("<script>alert('文件不能超过4MB！ ');</script>");
                }
                else
                {
                    Response.Write("<script>alert('后缀名只能为.jpg .png .gif .bmp ');</script>");
                }

            }
        }

        /// <summary>
        /// 更新课程信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Model.Class item = new Model.Class();
            item.Name = TextBox1.Text;
            item.Introduction = TextBox2.Text;
            item.Weight = Convert.ToInt32(DropDownList1.SelectedValue);
            item.ImgUrl = pictureName;
            item.Id = Convert.ToInt32(Request.QueryString["id"]);
            int flag = BLL.Class.BLLUpdateClass(item);
            if (flag > 0)
            {
                Response.Write("<script>alert('课程修改成功！ ');window.window.location.href='class_list.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('课程修改失败！ ');</script>");
            }
        }
    }
}