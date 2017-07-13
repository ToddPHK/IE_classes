using System;
using System.Data;
using System.IO;

namespace IE_Class.teacher_admin
{
    public partial class file_upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int role= Convert.ToInt32(Request.Cookies["login"]["role"]);
                FillDropDownList(role);
            }
        }

        /// <summary>
        /// 填充属于该教师管理的课程
        /// </summary>
        /// <param name="role">教师角色</param>
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

        /// <summary>
        /// 确定删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                Model.StudyFile item = new Model.StudyFile();

                int filesize = FileUpload1.PostedFile.ContentLength;
                if (filesize >= 51200 * 1024)
                {
                    Response.Write("<script>alert('文件不能超过50MB！ ');</script>");
                }
                else
                {
                    item.Name = FileUpload1.FileName;
                    item.Time = DateTime.Now.ToShortDateString().ToString();
                    item.UploadPersonId = Convert.ToInt32(Request.Cookies["login"]["ID"]);
                    item.ClassId = Convert.ToInt32(DropDownList1.SelectedValue);

                    string dateName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    item.Path = @"classfile/" + dateName + Path.GetExtension(FileUpload1.FileName).ToLower();

                    string fileName = Server.MapPath(@"~/") + item.Path;
                    FileUpload1.SaveAs(fileName);

                    int flag = 0;
                    flag = BLL.File.BLLInsertFile(item);
                    if(flag>0)
                        Response.Write("<script>alert('上传成功！ ');</script>");
                }



            }
        }
    }
}