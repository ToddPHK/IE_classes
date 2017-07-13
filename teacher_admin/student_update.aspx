<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="student_update.aspx.cs" Inherits="IE_Class.teacher_admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>修改学生信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>修改学生信息</h3>
        <table style="width:550px">
            <tr>
                <td>姓名</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Text="姓名不能为空" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>学号</td>
                <td style=""><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Text="学号不能为空" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>用户名</td>
                <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" Text="用户名不能为空" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>密码</td>
                <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" Text="密码不能为空" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>课程</td>
                <td><asp:Label runat="server" Font-Size="Small" ID="Label1" Text="已有课程"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:Label runat="server" Font-Size="Small" ID="Label4" Text="所属学年"></asp:Label>
                    <asp:TextBox runat="server" ID="TextBox5" Width="50px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>管理课程</td>
                <td><asp:Label runat="server" Font-Size="Small" ID="Label2" Text="添加课程"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>         
                </td>
                <td><asp:Label runat="server" Font-Size="Small" ID="Label3" Text="删除课程"></asp:Label>
                    <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>         
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" CssClass="button" Font-Size="Small" Text="确定" OnClick="Button1_Click" />
    </div>
</asp:Content>
