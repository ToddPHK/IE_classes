<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="student_add.aspx.cs" Inherits="IE_Class.teacher_admin.student_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>添加学生</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content" style="padding-bottom:30px;border-bottom:outset;border-color:black">
        <h3>导入学生名单</h3>
        <table style="width:400px">
            <tr>
                <td style="width:150px">选择所属课程</td>
                <td style="width:250px">
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:150px">下载导入模板</td>
                <td style="width:250px"><asp:Button ID="Button1" runat="server" CssClass="button" Font-Size="Small" Text="下载" OnClick="Button1_Click" /> </td>
            </tr>
            <tr>
                <td style="width:150px">上传学生名单</td>
                <td style="width:250px"><asp:FileUpload runat="server" ID="FileUpload1" /></td>
            </tr>
        </table>
        <asp:Button ID="Button2" runat="server" CssClass="button" Text="上传名单" Font-Size="Small" OnClick="Button2_Click" />
    </div>
    <div class="Content">
        <h3>添加学生信息</h3>
        <table style="width:400px">
            <tr>
                <td style="width:150px">选择所属课程</td>
                <td style="width:250px">
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:150px">姓名</td>
                <td style="width:250px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:150px">学号</td>
                <td style="width:250px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:150px">所在学年</td>
                <td style="width:250px">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button3" CssClass="button" runat="server" Text="添加" Font-Size="Small" OnClick="Button3_Click" />
    </div>
</asp:Content>
