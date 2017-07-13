using System;
using System.IO;

namespace IE_Class.teacher_admin
{
    public partial class class_add : System.Web.UI.Page
    {
        static string pictureName;

        /// <summary>
        /// 上传课程图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();
                string[] allowExtension = { ".jpg", ".png", ".gif", ".bmp" };
                bool isPicture = false;
                bool isTooBig = false;
                foreach (string item in allowExtension)
                {
                    if(item==fileExtension)
                    {
                        isPicture = true;
                        break;
                    }
                }                              

                int fileSize = FileUpload1.PostedFile.ContentLength;
                if(fileSize>4*1024*1024)
                {
                    isTooBig = true;
                }

                pictureName = @"image\"+ DateTime.Now.ToString("yyyyMMddHHmmss");

                if (isPicture&&!isTooBig)
                {
                    string fileName = Server.MapPath(@"~\") + pictureName +fileExtension;
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
        /// 添加课程
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
            int flag=BLL.Class.BLLAddClass(item);
            if(flag>0)
            {
                Response.Write("<script>alert('课程创建成功！ ');window.window.location.href='class_list.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('课程添加失败！ ');</script>");
            }
        }
    }
}