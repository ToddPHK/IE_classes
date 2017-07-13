<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="homework_add.aspx.cs" Inherits="IE_Class.teacher_admin.homework_add" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>添加作业</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>设置课程作业</h3>
        <div style="width:100%; margin:auto">
            <p>可为课程设置分次上交的作业，并设定截止日期。超过截止日期上交的作业会被标注，并会给出上交作业情况统计。</p>
            <p>若不进行设置，只统计每位学生上交作业的次数，并提供统一作业上传、下载。</p>
        </div>
        <table>
            <tr>
                <td>所属课程</td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList_Changed" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>所属学年</td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList_Changed" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
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
        <h4 style="margin:20px">已设置的作业：</h4>
        <asp:GridView ID="GridView1" runat="server" Width="50%" Visible="false" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="true" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center"/>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        作业名称
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("name") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        截止时间
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("deadline") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        所属学期
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("semester") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        文件格式
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("sortname") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        编辑作业
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="homework_update.aspx?id=<%#Eval("id") %>">修改</a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        删除作业
                    </HeaderTemplate>
                    <ItemTemplate>
                       <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete"  CausesValidation="false" Text="删除" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('你确定要删除这条作业吗？')">删除</asp:LinkButton> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>   
     </div>
    <div class="GridViewFooter">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True"  Visible="false"
                CssClass="pages" CurrentPageButtonClass="cpb" FirstPageText="首页" 
                HorizontalAlign="Center" LastPageText="尾页" NextPageText="后页" 
                onpagechanging="AspNetPager1_PageChanging" PrevPageText="前页">
        </webdiyer:AspNetPager>
    </div>
</asp:Content>
