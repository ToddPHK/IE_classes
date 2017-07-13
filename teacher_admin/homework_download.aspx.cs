using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;

namespace IE_Class.teacher_admin
{
    public partial class homework_download : System.Web.UI.Page
    {
        static int classid;
        static int times;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int role = Convert.ToInt32(Request.Cookies["login"]["role"]);
                FillDropDownList1(role);
            }
        }

        protected void FillDropDownList1(int role)
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

        protected void DropDownList1_Changed(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                classid = Convert.ToInt32(DropDownList1.SelectedValue);
                DataTable dt = BLL.Homework.BLLGetSubHomeWorklist(classid);
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = dt.Columns[1].ColumnName;
                DropDownList2.DataValueField = dt.Columns[2].ColumnName;
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, "请选择");
            }
        }

        protected void DropDownList2_Changed(object sender, EventArgs e)
        {
            //绑定还未下载的作业
            if(DropDownList2.SelectedIndex != 0 && DropDownList1.SelectedIndex!=0)
            {
                classid = Convert.ToInt32(DropDownList1.SelectedValue);
                times = Convert.ToInt32(DropDownList2.SelectedValue);
                DataTable dt = BLL.Homework.BLLGetHomeworkToDownload(classid, times);
                CheckBoxList1.DataSource = dt;
                CheckBoxList1.DataTextField = dt.Columns[2].ColumnName;
                CheckBoxList1.DataValueField = dt.Columns[1].ColumnName;
                CheckBoxList1.DataBind();
            }
            else if(DropDownList2.SelectedIndex == 1 && DropDownList1.SelectedIndex != 0)
            {
                classid = Convert.ToInt32(DropDownList1.SelectedValue);
                times = 0;
                DataTable dt = BLL.Homework.BLLGetHomeworkToDownload(classid, times);
                CheckBoxList1.DataSource = dt;
                CheckBoxList1.DataTextField = dt.Columns[2].ColumnName;
                CheckBoxList1.DataValueField = dt.Columns[1].ColumnName;
                CheckBoxList1.DataBind();
            }

            //绑定已下载的作业
            if (DropDownList2.SelectedIndex != 0 && DropDownList2.SelectedIndex != 1 && DropDownList1.SelectedIndex != 0)
            {
                classid = Convert.ToInt32(DropDownList1.SelectedValue);
                times = Convert.ToInt32(DropDownList2.SelectedValue);
                DataTable dt = BLL.Homework.BLLGetDownloadedHomework(classid, times);
                CheckBoxList2.DataSource = dt;
                CheckBoxList2.DataTextField = dt.Columns[2].ColumnName;
                CheckBoxList2.DataValueField = dt.Columns[1].ColumnName;
                CheckBoxList2.DataBind();
            }
            else if(DropDownList2.SelectedIndex == 1 && DropDownList1.SelectedIndex != 0)
            {
                classid = Convert.ToInt32(DropDownList1.SelectedValue);
                times = 0;
                DataTable dt = BLL.Homework.BLLGetDownloadedHomework(classid, times);
                CheckBoxList2.DataSource = dt;
                CheckBoxList2.DataTextField = dt.Columns[2].ColumnName;
                CheckBoxList2.DataValueField = dt.Columns[1].ColumnName;
                CheckBoxList2.DataBind();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> ListPath = new List<string>();
            List<string> ListName = new List<string>();
            List<string> fileForquery = new List<string>();
            foreach(ListItem item in CheckBoxList1.Items)
            {
                if(item.Selected == true)
                {
                    int count = item.Text.LastIndexOf(' ');
                    string fileName = item.Text.Substring(0, count);
                    string personName = item.Text.Substring(count+1);
                    fileName = personName +"_"+ fileName;
                    
                    string filePath = Server.MapPath(@"~\") + item.Value;
                    fileForquery.Add(item.Value);

                    ListName.Add(fileName);
                    ListPath.Add(filePath);
                }
            }
            if(ListName.Count>0)
            {
                BLL.Homework.BLLSetHomeworkRead(fileForquery.ToArray(), classid, times);
            }

            foreach (ListItem item in CheckBoxList2.Items)
            {
                if (item.Selected == true)
                {
                    int count = item.Text.LastIndexOf(' ');
                    string fileName = item.Text.Substring(0, count);
                    string filePath = Server.MapPath(@"~\") + item.Value;
                    ListName.Add(fileName);
                    ListPath.Add(filePath);
                }
            }

            if(ListName.Count>0)
            {
                string time = DateTime.Now.Ticks.ToString();
                ZipFileMain(ListPath.ToArray(), ListName.ToArray(), Server.MapPath("file/" + time + ".zip"), 1);
                DownloadFile(Server.UrlEncode("DownloadFiles.zip"), Server.MapPath("file/" + time + ".zip"));
                
            }
            else
            {
                Response.Write("<script>alert('你没有勾选任何文件，请重试！');");
            }



        }

        /// <summary>
        /// 用于文件进行打包下载
        /// </summary>
        /// <param name="filenames">文件路径数组</param>
        /// <param name="fileName">文件名数组</param>
        /// <param name="name">暂存文件路径</param>
        /// <param name="Level">压缩程度</param>
        protected void ZipFileMain(string[] filenames, string[] fileName, string name, int Level)
        {
            ZipOutputStream s = new ZipOutputStream(File.Create(name));
            Crc32 crc = new Crc32();

            s.SetLevel(Level);
            try
            {
                int m = 0;
                foreach (string file in filenames)
                {
                    FileStream fs = File.OpenRead(file);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    ZipEntry entry = new ZipEntry(fileName[m].ToString());

                    entry.DateTime = DateTime.Now;
                    entry.Size = fs.Length;
                    fs.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    s.PutNextEntry(entry);
                    s.Write(buffer, 0, buffer.Length);
                    m++;

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                s.Finish();
                s.Close();
            }
        }

        protected void DownloadFile(string fileName, string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            File.Delete(filePath);//删除已下载文件
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

    }
}