using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace IE_Class.teacher_admin
{
    public partial class file_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int role = Convert.ToInt32(Request.Cookies["login"]["role"]);
                FillDropDownList(role);
            }
        }

        /// <summary>
        /// 填充属于教师管理的课程
        /// </summary>
        /// <param name="role">教师角色，0代表管理员，1为教师</param>
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
        /// 填充属于课程的下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_Changed(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedIndex!=0)
            {
                FillCheckBox(Convert.ToInt32(DropDownList1.SelectedValue));
                Button2.Visible = true;
            }
        }

        protected void FillCheckBox(int classid)
        {
            DataTable dt = BLL.File.BLLGetClassFile(classid);
            CheckBoxList1.DataSource = dt;
            CheckBoxList1.DataValueField = dt.Columns[0].ColumnName;
            CheckBoxList1.DataTextField = dt.Columns[1].ColumnName;
            CheckBoxList1.DataBind();
        }

        /// <summary>
        /// 确认删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            int classid = Convert.ToInt32(DropDownList1.SelectedValue);

            List<int> fileid = new List<int>();
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected == true)
                {
                    fileid.Add(Convert.ToInt32(item.Value));
                    count++;
                }
            }

            if (count == 0)
            {
                Response.Write("<script>alert('请选择要删除的学生！ ');</script>");
            }
            else
            {
                int flag = BLL.File.BLLDeleteFiles(fileid.ToArray());
                if (flag == 1)
                {
                    Response.Write("<script>alert('删除成功！ ');window.window.location.href='file_list.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败！ ');</script>");
                }
            }
        }
    }
}