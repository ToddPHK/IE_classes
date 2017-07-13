<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="homework_download.aspx.cs" Inherits="IE_Class.teacher_admin.homework_download" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>下载学生作业</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>下载学生作业</h3>
        <table>
            <tr>
                <td>所属课程</td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_Changed"></asp:DropDownList></td>
                <td>作业名称</td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_Changed" ></asp:DropDownList></td>
            </tr>
        </table>
        <div class="homework_list" style="width:40%;padding:5px;margin:0 auto">
            <div style="text-align:left;padding-left:15%;padding-bottom:50px;">
                <h4>未下载作业</h4>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
            </div>
            <div style="text-align:left;padding-left:15%;">
                <h4>已下载作业</h4>
                <asp:CheckBoxList ID="CheckBoxList2" runat="server"></asp:CheckBoxList>
            </div>
        </div>
        <asp:Button ID="Button1" runat="server" Text="下载" CssClass="button" Font-Size="Small" OnClick="Button1_Click" />
    </div>
</asp:Content>
