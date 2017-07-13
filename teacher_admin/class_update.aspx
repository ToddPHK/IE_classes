<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="class_update.aspx.cs" Inherits="IE_Class.teacher_admin.class_update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>修改课程</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>修改课程</h3>
        <table style="width:600px;margin:10px auto; ">
            <tr>
                <td>课程名称</td>
                <td style="text-align:left;"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" Text="请输入教师姓名！"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="vertical-align:top">
                <td>课程简介</td>
                <td style="width:300px;text-align:left;vertical-align:top;">
                    <asp:TextBox ID="TextBox2" runat="server" Width="300px" Height="150px" TextMode="MultiLine" ></asp:TextBox>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ForeColor="Red" Text="请输入用户名！"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>课程权重</td>
                <td style="text-align:left;">
                    <asp:DropDownList runat="server" ID="DropDownList1" Width="50" Font-Size="Large">
                        <asp:ListItem Value="0" Text="0" Enabled="true"></asp:ListItem>
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>上传首页图（建议尺寸367*150）</td>
                <td>
                    <asp:FileUpload runat="server" ID="FileUpload1" />
                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="上传" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td>封面图预览</td>
                <td style="width:400px;vertical-align:top;"><img id="img1" runat="server" title="首页图" src="~/image/cloud.jpg" /></td>
            </tr>
        </table>
        <asp:Button ID="Button2" runat="server" CssClass="button" Text="确定" OnClick="Button2_Click" />
    </div>
</asp:Content>
