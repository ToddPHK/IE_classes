<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="function_add.aspx.cs" Inherits="IE_Class.teacher_admin.function_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>添加课程功能</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>添加自定义课程功能</h3>
        <table style="width:700px;text-align:left;">
            <tr>
                <td>选择课程</td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>功能名称</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="TextBox1_Validator" ControlToValidate="TextBox1" runat="server" ForeColor="Red" Text="名称不能为空"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="height:100px;">
                <td>功能描述</td>
                <td><asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="80px" Width="150px"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="TextBox3_Validator" ControlToValidate="TextBox3" runat="server" ForeColor="Red" Text="功能描述不能为空"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>功能链接</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="TextBox2_Validator" ControlToValidate="TextBox2" runat="server" ForeColor="Red" Text="链接不能为空"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>上传功能截图（建议尺寸367*150）</td>
                <td>
                    <asp:FileUpload runat="server" ID="FileUpload1" />
                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="上传" Font-Size="Small" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td>封面图预览</td>
                <td style="width:400px;height:180px; vertical-align:central;"><img id="img1" runat="server" title="首页图" src="~/image/cloud.jpg" style="width:367px;height:150px;" /></td>
            </tr>
        </table>
        <asp:Button ID="Button2" runat="server" CssClass="button" Text="确定" OnClick="Button2_Click" Font-Size="Small" />
    </div>
</asp:Content>
