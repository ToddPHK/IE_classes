using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IE_Class.teacher_admin
{
    public partial class homework_list : System.Web.UI.Page
    {
        static int classid;

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

        protected void DropDownListChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                classid = Convert.ToInt32(DropDownList1.SelectedValue);
                BindData(classid);
                GridView1.Visible = true;
            }
            else
            {
                GridView1.Visible = false;
            }
        }

        protected void BindData(int classid)
        {
            DataTable dt = BLL.Homework.BLLGetClassSubHomeworkTable(classid);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int flag = BLL.Homework.BLLDeleteSubHomework(id);
                if (flag > 0)
                {
                    Response.Write("<script>alert('删除成功！ ');window.window.location.href='homework_list.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败！ ');window.window.location.href='homework_list.aspx';</script>");
                }
            }
        }

    }
}