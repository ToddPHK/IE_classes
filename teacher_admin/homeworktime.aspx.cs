using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IE_Class.teacher_admin
{
    public partial class homeworktime : System.Web.UI.Page
    {
        static int classid;

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
            


        }
    }
}