using System;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace IE_Class.teacher_admin
{
    public partial class student_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillDropDownList();
                int year = DateTime.Now.Year;
                TextBox3.Text = year.ToString();
            }
        }

        protected void FillDropDownList()
        {
            DataTable dt = BLL.Class.BLLGetAllClass();
            DropDownList1.DataSource = dt;
            DropDownList1.DataValueField = dt.Columns[0].ColumnName;
            DropDownList1.DataTextField = dt.Columns[1].ColumnName;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "请选择");

            DropDownList2.DataSource = dt;
            DropDownList2.DataValueField = dt.Columns[0].ColumnName;
            DropDownList2.DataTextField = dt.Columns[1].ColumnName;
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "请选择");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/x-xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=student_list.xls");
            string filename = Server.MapPath("~/download/student_list.xls");
            Response.TransmitFile(filename);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();
                string allowExtension = ".xls";

                if(fileExtension==allowExtension)
                {
                    string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string filename= Server.MapPath(@"~\")+ @"datafile\" + datetime+fileExtension;
                    FileUpload1.SaveAs(filename);
                    //string newfile = @"..\datafile\" + datetime + fileExtension;
                    string newfile = filename;
                    InsertDataFromExcel(newfile);
                    Response.Write(" < script>alert('学生名单导入成功！ ');</script>");
                }
                else
                {
                    Response.Write("<script>alert('文件后缀名错误！后缀名必须是.xls！ ');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请选择上传文件！ ');</script>");
            }
        }

        protected void InsertDataFromExcel(string filename)
        {
            string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source =" +  filename + ";" + "Extended Properties='Excel 8.0;HDR=YES;IMEX=1';"; 
            OleDbConnection cn = new OleDbConnection(connectString);
            cn.Open();

            DataTable dt = new DataTable();
            string sql = "SELECT * from [Sheet1$]";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, cn);
            da.Fill(dt);

            int id = 0;
            if(DropDownList1.SelectedIndex!=0)
                id = Convert.ToInt32(DropDownList1.SelectedValue);
            int flag=0;
            if (id!=0)
                flag = BLL.Student.BLLInsertStudentList(dt, id);

            if(flag==0)
            {
                Response.Write("<script>alert('写入数据库失败！请检查表格是否错误！ ');</script>");
            }
            else
            {
                Response.Write("<script>alert('读取成功！ ');</script>");
            }
                        
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Model.Student person = new Model.Student();
            person.Name = TextBox1.Text;
            person.Username = TextBox1.Text;
            person.StudentNumber = TextBox2.Text;
            person.Password = TextBox2.Text;
            int id = 0;
            if (DropDownList2.SelectedIndex != 0)
                id = Convert.ToInt32(DropDownList2.SelectedValue);
            int year = Convert.ToInt32(TextBox3.Text);

            if(id==0)
            {
                Response.Write("<script>alert('请选择学生所属班级！ ');</script>");
            }
            else
            {
                int flag = BLL.Student.BLLInsertAStudent(person, id, year);
                if(flag==0)
                {
                    Response.Write("<script>alert('写入数据库失败！请检查数据是否错误！ ');</script>");
                }
                else
                {
                    Response.Write("<script>alert('添加成功！ ');</script>");
                }
            }

        }
    }
}