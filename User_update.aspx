<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="User_update.aspx.cs" Inherits="IE_Class.Update_user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>修改信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="testmonials">
        <div class="wrap">
            <div class="testmonial-grid">
                <h3>修改信息</h3>
                <table>
                    <tr>
                        <td>姓名</td>
                        <td><asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr id="stuid" runat="server">
                        <td>学号</td>
                        <td><asp:TextBox ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>登录名</td>
                        <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ForeColor="Red" Text="用户名不能为空！"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>密码</td>
                        <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ForeColor="Red" Text="密码不能为空！"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Text="确定" CssClass="button" Font-Size="Small" />
            </div>
        </div>
    </div>
</asp:Content>
