<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="class_teacher.aspx.cs" Inherits="IE_Class.teacher_admin.class_teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>课程教师管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>课程教师管理</h3>
        <table style="width:600px">
            <tr>
                <td></td>
                <td>课程</td>
                <td>教师</td>
            </tr>
            <tr>
                <td>查看课程教师</td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_Changed" AutoPostBack="true"></asp:DropDownList></td>
                <td><asp:ListBox ID="ListBox1" runat="server"></asp:ListBox></td>
            </tr>
            <tr>
                <td>添加课程教师</td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_Changed" AutoPostBack="true"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList></td>
                <td><asp:Button ID="Button2" runat="server" CssClass="button" Text="确认" Font-Size="Medium" OnClick="Button2_Click" Visible="false" /></td>
            </tr>
            <tr>
                <td>删除课程教师</td>
                <td><asp:DropDownList ID="DropDownList4" OnSelectedIndexChanged="DropDownList4_Changed" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td><asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="150px" Font-Size="Small">
                    </asp:CheckBoxList>
                </td>
                <td><asp:Button ID="Button3" runat="server" CssClass="button" Text="确认" Font-Size="Medium" OnClick="Button3_Click" Visible="false" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
