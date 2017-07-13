using System;
using System.Data;
using System.IO;

namespace IE_Class.teacher_admin
{
    public partial class function_add : System.Web.UI.Page
    {
        /// <summary>
        /// 注释可见 class_add，与之类似
        /// </summary>
        //是否有上传图片文件
        static bool hasUploadedFile = false;

        static string pictureName = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int role = Convert.ToInt32(Request.Cookies["login"]["role"]);
                FillDropDownList(role);
            }
        }

        protected void FillDropDownList(int role)
        {
            if (role == 0)
            {
                DataTable dt = BLL.Class.BLLGetAllClass();
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = dt.Columns[0].ColumnName;
                DropDownList1.DataTextField = dt.Columns[1].ColumnName;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "请选择");
            }
            else
            {
                int teacherid = Convert.ToInt32(Request.Cookies["login"]["ID"]);
                DataTable dt = BLL.Teacher.BLLGetTeacherClass(teacherid);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = dt.Columns[2].ColumnName;
                DropDownList1.DataTextField = dt.Columns[3].ColumnName;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "请选择");
            }
        }

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
                    hasUploadedFile = true;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Model.Function function = new Model.Function();
            
            if(DropDownList1.SelectedIndex == 0)
            {
                Response.Write("<script>alert('请选择所属课程！ ');</script>");
            }
            else
            {
                function.classid = Int32.Parse(DropDownList1.SelectedValue);
                function.Name = TextBox1.Text;
                function.link = TextBox2.Text;
                function.Describe = TextBox3.Text;
                if (hasUploadedFile)
                    function.img = pictureName;
                else
                    function.img = @"image\cloud.jpg";

                int flag = BLL.Function.BLLAddFunction(function);
                if(flag == 1)
                {
                    Response.Write("<script>alert('设置成功！ ');</script>");
                }
                else
                {
                    Response.Write("<script>alert('设置不成功，请重试！ ');</script>");
                }
            }

        }
    }
}