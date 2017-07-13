<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="student_delete.aspx.cs" Inherits="IE_Class.teacher_admin.student_delete" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>删除学生</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>删除学生</h3>
        <table style="width:600px">
            <tr>
                <td>所属课程</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList_Changed"></asp:DropDownList>
                </td>
                <td>所属学年</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList_Changed"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
        <div class="checkbox" style="text-align:left;margin-left:45%;">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Font-Size="Medium">
            </asp:CheckBoxList>
        </div>
    <asp:Button runat="server" ID="Button1" CssClass="button" Text="确定删除" Font-Size="Small" OnClick="Button1_Click" Visible="false" />
</asp:Content>
