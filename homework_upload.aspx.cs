using System;
using System.Data;
using System.IO;

namespace IE_Class
{
    public partial class homework_upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int personId = Convert.ToInt32(Request.Cookies["login"]["ID"]);
                DataTable dt = BLL.Homework.BLLGetClassSubHomeworkTable(id,personId);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();

                FillDropDownList(id);
            }

        }

        /// <summary>
        /// 填充课程清单
        /// </summary>
        /// <param name="classid"></param>
        protected void FillDropDownList(int classid)
        {
            DataTable dt = BLL.Homework.BLLGetSubHomeworkName(classid);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = dt.Columns[0].ColumnName;
            DropDownList1.DataValueField = dt.Columns[1].ColumnName;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "请选择");
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            int classid = Convert.ToInt32(Request.QueryString["id"]);
            int personid = Convert.ToInt32(Request.Cookies["login"]["ID"]);
            int timesNo = Convert.ToInt32(DropDownList1.SelectedValue);

            int isUploaded = BLL.Homework.BLLIsHomeWorkUpload(classid, personid, timesNo); //-1表示没上传过，正整数表示已经上传的文件ID

            if (FileUpload1.HasFile)
            {
                string realName = FileUpload1.FileName;
                string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();

                //查询该子作业允许的上传类型
                string[] allowExtension = BLL.Homework.BLLGetSuffix(classid, timesNo);
                               
                bool isValid = false;
                bool isTooBig = false;
                
                if(allowExtension == null)
                {
                    isValid = true;
                }
                else
                {
                    foreach (string item in allowExtension)
                    {
                        if (item == fileExtension)
                        {
                            isValid = true;
                            break;
                        }
                    }
                }
                
                int fileSize = FileUpload1.PostedFile.ContentLength;
                if (fileSize > 50 * 1024 * 1024)
                {
                    isTooBig = true;
                }

                string name = @"homework\" + DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;
                string str = DropDownList1.SelectedValue;
                if (isValid && !isTooBig &&DropDownList1.SelectedIndex != 0)
                {
                    Model.Homework item = new Model.Homework();
                    item.Name = name;
                    item.ClassId = Convert.ToInt32(Request.QueryString["id"]);
                    item.Time = DateTime.Now.ToString();
                    item.UploadPersonId = Convert.ToInt32(Request.Cookies["login"]["ID"]);
                    item.RealName = realName;

                    item.Times = Convert.ToInt32(DropDownList1.SelectedValue);

                    int flag;

                    if (isUploaded == -1)
                    {
                        flag = BLL.Homework.BLLInsertHomework(item);
                    }
                    else
                    {
                        flag = BLL.Homework.BLLModifyHomeword(isUploaded, item);
                    }
                    if (flag > 0)
                    {
                        string fileName = Server.MapPath(@"~\") + name;
                        FileUpload1.SaveAs(fileName);
                        Response.Write("<script>alert('上传成功！ ');window.window.location.href='homework_upload.aspx?id=" + item.ClassId + "';</script>");
                        }
                    else
                    {
                        Response.Write("<script>alert('上传失败！ ');window.window.location.href='homework_upload.aspx?id=" + item.ClassId + "';</script>");
                    }
                }
                else if(isTooBig)
                {
                    Response.Write("<script>alert('文件不能超过50MB！ ');</script>");
                }
                else 
                {
                    Response.Write("<script>alert('文件格式不正确！请参考表格中文件类型限制中的类型！ ');</script>");
                }

            }
        }

        /// <summary>
        /// 查询已上传的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            int personid = Convert.ToInt32(Request.Cookies["login"]["ID"]);
            DataTable dt = BLL.Homework.BLLGetstudentHomework(id,personid);
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            Repeater2.Visible = true;
        }





    }
}