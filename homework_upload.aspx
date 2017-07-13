<%@ Page Title="" Language="C#" MasterPageFile="~/Class_Master.master" AutoEventWireup="true" CodeBehind="homework_upload.aspx.cs" Inherits="IE_Class.homework_upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="testmonials">
        <div class="wrap">
            <div class="testmonial-grid" style="padding-bottom:100px">
                <h3>作业状态</h3>
                <p>上传时间以最后一次作业上传为准哦！</p>
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table style="width:750px; margin-bottom:100px;">
                            <tr>
                                <td>作业名称</td>
                                <td>截止日期</td>
                                <td>文件类型限制</td>
                                <td>后缀名限制</td>
                                <td>上交状态</td>
                          </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("name") %></td>
                            <td><%#Eval("deadline") %></td>
                            <td><%#Eval("sortname") %></td>
                            <td><%#Eval("suffix") %></td>
                            <td><%#Eval("state") %></td>
                        </tr>
                    </ItemTemplate>  
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

                <h3>作业上传</h3>
                <p>请选择教师设置的作业项目进行上传</p>
                <p>文件不能超过50MB，<span style="color:red; font:bold">每项作业只能上传一个文件，如有多个文件，请打包上传（当文件类型为“无限制”时方可）</span></p>
                <p style="color:red; font:bold">若多次上传，新上传文件会覆盖原文件</p>
                <p style="color:red; font:bold">现对上传文件类型有限制，请参考“作业状态”表格中 后缀名限制 一列，确保正常上传</p>
                <table>
                    <tr>
                        <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                        <td><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
                    </tr>
                </table>

                <asp:Button ID="Button1" runat="server" Text="上传" CssClass="button" Font-Size="Small" OnClick="Button1_Click" />
                <p><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">点击此处</asp:LinkButton> 查看已上传作业清单：</p>
                <asp:Repeater ID="Repeater2" runat="server" Visible="false">
                    <HeaderTemplate>
                       <table style="width:750px;">
                          <tr>
                              <td>作业名称</td>
                              <td>上交日期</td>
                              <td>所属作业</td>
                          </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("filename") %></td>
                            <td><%#Eval("time") %></td>
                            <td><%#Eval("name") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
