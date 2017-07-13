<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="file_upload.aspx.cs" Inherits="IE_Class.teacher_admin.file_upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>上传课程资料</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>上传课程资料</h3>
        <table style="width:400px;">
            <tr>
                <td>选择所属课程</td>
                <td style="width:250px;"><asp:DropDownList ID="DropDownList1" runat="server" ></asp:DropDownList></td>
            </tr>
            <tr>
                <td>上传文件</td>
                <td style="width:250px;"><asp:FileUpload ID="FileUpload1" runat="server" /> </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Visible="true" Text="上传" CssClass="button" Font-Size="Small" OnClick="Button1_Click" />
    </div>
</asp:Content>
