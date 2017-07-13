<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IE_Class.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>用户登陆</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="testmonials">
        <div class="wrap">
            <div class="testmonial-grid">
                <h3>用户登录</h3>
                <table>
                    <tr>
                        <td>用户名</td>
                        <td><asp:TextBox ID="UserName" runat="server"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="UserName" Text="请输入用户名！"></asp:RequiredFieldValidator></td>
                    </tr>

                    <tr>
                        <td>密码</td>
                        <td><asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="Password" Text="请输入密码！"></asp:RequiredFieldValidator></td>
                    </tr>

                    <tr>
                        <td>您的身份是：</td>
                        <td>
                            <asp:RadioButton ID="RadioButtonTeacher" runat="server" Text="教师"  GroupName="Identify" />
                            <asp:RadioButton ID="RadioButtonStudent" runat="server" Text="学生" GroupName="Identify" Checked="true" /> 
                        </td>
                    </tr>

                    <tr>
                        <td><asp:CheckBox ID="CheckBox1" runat="server" Checked="true" />一周内免登录</td>
                        <td><asp:Button CssClass="button" ID="Button1" runat="server" Text="登陆" OnClick="Button1_Click" /></td>
                    </tr>
                </table>
            </div>  
        </div>
    </div>
</asp:Content>
