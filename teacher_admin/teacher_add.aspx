<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="teacher_add.aspx.cs" Inherits="IE_Class.teacher_admin.teacher_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>添加教师</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>添加教师</h3>
        <table>
            <tr>
                <td>教师姓名</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" Text="请输入教师姓名！"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>用户名</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ForeColor="Red" Text="请输入用户名！"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>密码</td>
                <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ForeColor="Red" Text="请输入密码！"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>类别</td>
                <td>
                    <asp:RadioButton ID="Teacher" Text="教师"  runat="server" GroupName="Sort" Checked="true" />
                    <asp:RadioButton ID="Admin" Text="管理员" runat="server" GroupName="Sort" Visible="false" />
                </td>

            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="添加" CssClass="button" OnClick="Button1_Click" />
    </div>
</asp:Content>
