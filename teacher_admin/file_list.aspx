<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="file_list.aspx.cs" Inherits="IE_Class.teacher_admin.file_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>查看资料列表</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>课程资料列表</h3>
        <table style="width:400px;">
            <tr>
                <td>选择所属课程</td>
                <td style="width:250px;"><asp:DropDownList ID="DropDownList1" runat="server"  OnSelectedIndexChanged="DropDownList1_Changed" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
        </table>
    </div>
    <div class="checkbox" style="text-align:left;margin-left:37%;">
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Font-Size="Medium">
        </asp:CheckBoxList>
    </div>
    <asp:Button runat="server" ID="Button2" CssClass="button" Text="确定删除" Font-Size="Small" OnClick="Button2_Click" Visible="false" />
</asp:Content>
