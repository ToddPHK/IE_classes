<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="news_add.aspx.cs" Inherits="IE_Class.teacher_admin.news_add" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>添加新闻</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>添加课程新闻</h3>
        <h4 style="font-size:18px; margin:20px;font-family:'Roboto', 'sans-serif';"><span>新闻标题：<asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox></span></h4>
        <p>
            <span>所属课程：<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></span>
            <span>新闻类别：<asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList></span>
        </p>
    </div>
    <div style ="overflow:scroll">
      <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Height="560px">
       </FCKeditorV2:FCKeditor>
   </div>
    <asp:Button runat="server" ID="Button1" Text="提交" Font-Size="Small" CssClass="button" OnClick="Button1_Click" />
</asp:Content>
