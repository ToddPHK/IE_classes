<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="studentlist.aspx.cs" Inherits="IE_Class.teacher_admin.studentlist" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>学生列表</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>学生列表</h3>
        <table style="width:600px">
            <tr>
                <td>所属课程</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList_Change" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>所属学年</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList_Change" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" Width="50%" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand" Visible="false" OnRowDeleting="GridView1_RowDeleting">
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
                        学生ID
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("id") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        姓名
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("name") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        学号
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("stunumber") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        用户名
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("username") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        密码
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("password") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        修改信息
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="student_update.aspx?id=<%#Eval("id") %>">修改</a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        删除学生
                    </HeaderTemplate>
                    <ItemTemplate>
                       <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete"  CausesValidation="false" Text="删除" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('你确定要删除这个账号吗？')"></asp:LinkButton>
                        
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
    </div>

    <div class="GridViewFooter">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" 
            CssClass="pages" CurrentPageButtonClass="cpb" HorizontalAlign="Center" LastPageText="尾页" NextPageText="下一页" 
            PrevPageText="上一页" onpagechanging="AspNetPager1_PageChanging1">
        </webdiyer:AspNetPager> 
    </div>
</asp:Content>
