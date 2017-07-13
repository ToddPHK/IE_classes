<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="IE_Class.UserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>用户信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="testmonials">
        <div class="wrap">
            <div class="testmonial-grid">
                <h3>用户信息</h3>
                <table style="width:300px;text-align:left;">
                    <tr>
                        <td>姓名</td>
                        <td><asp:Label ID="Label1" runat="server"></asp:Label></td>
                    </tr>
                    <tr id="stuid" runat="server">
                        <td>学号</td>
                        <td><asp:Label ID="Label2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>登录名</td>
                        <td><asp:Label ID="Label3" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>密码</td>
                        <td><asp:Label ID="Label4" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <asp:LinkButton ID="LinkButton1" runat="server"  Font-Size="Large"  PostBackUrl="~/User_update.aspx">修改信息</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
