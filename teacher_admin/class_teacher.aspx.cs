using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;

namespace IE_Class.teacher_admin
{
    public partial class class_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDownList();
            }
        }

        /// <summary>
        /// 填充下拉菜单
        /// </summary>
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

            DropDownList4.DataSource = dt;
            DropDownList4.DataValueField = dt.Columns[0].ColumnName;
            DropDownList4.DataTextField = dt.Columns[1].ColumnName;
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, "请选择");
        }

        /// <summary>
        /// 选定项改变时查询课程教师
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_Changed(object sender, EventArgs e)
        {
            int id=0;
            if(DropDownList1.SelectedIndex!=0)
                id = Convert.ToInt32(DropDownList1.SelectedValue);
            DataTable dt = BLL.Class.BLLGetClassTeacher(id);
            ListBox1.DataSource = dt;
            ListBox1.DataTextField = dt.Columns[2].ColumnName;
            ListBox1.DataBind();
        }

        /// <summary>
        /// 选定可以添加的教师
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList2_Changed(object sender, EventArgs e)
        {
            int id = 0;
            if (DropDownList2.SelectedIndex != 0)
                id = Convert.ToInt32(DropDownList2.SelectedValue);
            DataTable dt = BLL.Teacher.BLLGetNoThisClassTeacher(id);
            DropDownList3.DataSource = dt;
            DropDownList3.DataValueField = dt.Columns[0].ColumnName;
            DropDownList3.DataTextField = dt.Columns[1].ColumnName;
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, "请选择");
            Button2.Visible = true;
        }

        /// <summary>
        /// 添加课程教师
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(DropDownList2.SelectedIndex==0)
            {
                Response.Write("<script>alert('请选择课程！ ');</script>");
            }
            else if(DropDownList3.SelectedIndex==0)
            {
                Response.Write("<script>alert('请选择教师！ ');</script>");
            }
            else
            {
                int flag=BLL.Class.BLLAddClassTeacher(Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(DropDownList3.SelectedValue));
                if (flag > 0)
                {
                    Response.Write("<script>alert('添加成功！ ');window.window.location.href='class_teacher.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('添加失败！ ');</script>");
                }
            }
        }

        /// <summary>
        /// 选择课程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList4_Changed(object sender, EventArgs e)
        {
            int id = 0;
            if (DropDownList4.SelectedIndex != 0)
                id = Convert.ToInt32(DropDownList4.SelectedValue);
            DataTable dt = BLL.Class.BLLGetClassTeacher(id);
            CheckBoxList1.DataSource = dt;
            CheckBoxList1.DataTextField = dt.Columns[2].ColumnName;
            CheckBoxList1.DataValueField = dt.Columns[0].ColumnName;
            CheckBoxList1.DataBind();

            Button3.Visible = true;

        }

        /// <summary>
        /// 删除教师
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            List<int> numberList = new List<int>();

            foreach(ListItem item in CheckBoxList1.Items)
            {
                if(item.Selected)
                {
                    numberList.Add(Convert.ToInt32(item.Value));
                }
            }
            int[] numbers = numberList.ToArray();
            int flag=0;
            foreach(int item in numbers)
            {
                flag = BLL.Class.BLLDeleteClassTeacher(item);
                if(flag == 0)
                {
                    Response.Write("<script>alert('删除失败！');</script>");
                    break;
                }
            }

            if(flag>0)
            {
                Response.Write("<script>alert('删除成功！');window.window.location.href='class_teacher.aspx';</script>");
            }


        }
    }
}