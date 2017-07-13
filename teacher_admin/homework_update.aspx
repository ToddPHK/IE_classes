<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/teacher_admin/t_admin.master" CodeBehind="homework_update.aspx.cs" Inherits="IE_Class.teacher_admin.homework_update" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>修改作业</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>修改课程作业</h3>
        <div style="width:100%; margin:auto">
            <p>可为课程设置分次上交的作业，并设定截止日期。超过截止日期上交的作业会被标注，并会给出上交作业情况统计。</p>
            <p>若不进行设置，只统计每位学生上交作业的次数，并提供统一作业上传、下载。</p>
        </div>
        <table>
            <tr>
                <td>作业名称</td>
                <td><asp:TextBox ID="TextBox1" runat="server"/></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Text="名称不能为空" ForeColor="Red" Font-Size="Medium"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>文件格式</td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>截止日期</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    <div style="margin:auto;width:20%; text-align:center;padding-left:50px; padding-bottom:30px">
        <asp:Calendar ID="Calendar1" runat="server" Font-Size="Small" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
    </div>
    <div class="Content">
        <asp:Button ID="Button1" runat="server" CssClass="button" Text="确定" Font-Size="Small" OnClick="Button1_Click" />
    </div>
</asp:Content>
