<%@ Page Title="查看作业上交情况" Language="C#" MasterPageFile="t_admin.master" AutoEventWireup="true" CodeBehind="homework_details.aspx.cs" Inherits="IE_Class.teacher_admin.homework_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .homeworklist{
            font-size:12px;
            text-align:left;
           
        }

        .homeworklist h4{
            margin:20px;
            position:relative;
            left:30%;
        }

        .homeworklist th{
            font-size:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>查看作业上交情况</h3>
        <table>
            <tr>
                <td>所属课程</td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_Changed"></asp:DropDownList></td>
                <td>作业名称</td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_Changed" ></asp:DropDownList></td>
            </tr>
        </table>

        <div>
            <h4>本次作业信息：</h4>
            <p>
                <span>总学生人数：<asp:Label ID="TotalNum" runat="server"></asp:Label></span>
                <span>已上交人数：<asp:Label ID="GoodNum" runat="server"></asp:Label></span>
                <span>未上交人数：<asp:Label ID="BadNum" runat="server"></asp:Label></span>
            </p>
        </div>

        <!--按时上交-->
        <div class="homeworklist">
            <h4>按时上交</h4>
            <asp:Repeater runat="server" ID="Repeater1">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>学生</th>
                            <th>文档数</th>
                            <th>上交时间</th>
                            <th>已下载数</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("stuName")%></td>
                        <td><%# Eval("fileNum")%></td>
                        <td><%# Eval("uploadTime")%></td>
                        <td><%# Eval("downloadNum")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <!--延迟上交-->
        <div class="homeworklist">
            <h4>延迟上交</h4>
            <asp:Repeater runat="server" ID="Repeater2">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>学生</th>
                            <th>文档数</th>
                            <th>上交时间</th>
                            <th>已下载数</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("stuName")%></td>
                        <td><%# Eval("fileNum")%></td>
                        <td><%# Eval("uploadTime")%></td>
                        <td><%# Eval("downloadNum")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <!--未上交-->
        <div class="homeworklist">
            <h4>未上交</h4>
            <asp:Repeater runat="server" ID="Repeater3">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>学生</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("stuName")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

    </div>

</asp:Content>
