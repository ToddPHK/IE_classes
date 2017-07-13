using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace IE_Class.teacher_admin
{
    public partial class student_delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int role = Convert.ToInt32(Request.Cookies["login"]["role"]);
                FillDropDown(role);
            }
        }

        protected void FillDropDown(int role)
        {
            if(role==0)
            {
                DataTable dt = BLL.Class.BLLGetAllClass();
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = dt.Columns[0].ColumnName;
                DropDownList1.DataTextField = dt.Columns[1].ColumnName;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "请选择");

                dt = BLL.Student.BLLGetAllSemester();
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = dt.Columns[0].ColumnName;
                DropDownList2.DataValueField = dt.Columns[0].ColumnName;
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, "请选择");
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

                dt = BLL.Student.BLLGetAllSemester();
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = dt.Columns[0].ColumnName;
                DropDownList2.DataValueField = dt.Columns[0].ColumnName;
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, "请选择");
            }
        }

        protected void DropDownList_Changed(object sender, EventArgs e)
        {
            //两个List都选中时
            if(DropDownList1.SelectedIndex!=0 && DropDownList2.SelectedIndex!=0)
            {
                int classid = Convert.ToInt32(DropDownList1.SelectedValue);
                string semester = DropDownList2.SelectedValue;

                DataTable dt = BLL.Student.BLLGetClassStudent(classid, semester);

                CheckBoxList1.DataSource = dt;
                CheckBoxList1.DataTextField = dt.Columns[1].ColumnName;
                CheckBoxList1.DataValueField = dt.Columns[0].ColumnName;
                CheckBoxList1.DataBind();

                Button1.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            int classid = Convert.ToInt32(DropDownList1.SelectedValue);
            string semester = DropDownList2.SelectedValue;
            List<int> stuid = new List<int>();
            foreach(ListItem item in CheckBoxList1.Items)
            {
                if(item.Selected == true)
                {
                    stuid.Add(Convert.ToInt32(item.Value));
                    count++;
                }
            }

            if(count==0)
            {
                Response.Write("<script>alert('请选择要删除的学生！ ');</script>");
            }
            else
            {
                int flag = BLL.Student.BLLDeleteClassStudent(classid, semester, stuid.ToArray());
                BLL.Student.BLLDeleteNoClassStudent();

                if(flag==1)
                {
                    Response.Write("<script>alert('删除成功！ ');window.window.location.href='student_delete.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败！ ');</script>");
                }
            }
        }
    }
}