<%@ Page Title="" Language="C#" MasterPageFile="t_admin.master" AutoEventWireup="true" CodeBehind="homeworktime.aspx.cs" Inherits="IE_Class.teacher_admin.homeworktime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>查看作业上交时间</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>查看作业上交时间</h3>
        <table>
            <tr>
                <td>所属课程</td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_Changed"></asp:DropDownList></td>
                <td>作业名称</td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_Changed" ></asp:DropDownList></td>
            </tr>
        </table>


    </div>
</asp:Content>
