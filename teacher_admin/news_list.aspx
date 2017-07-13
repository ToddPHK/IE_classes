<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="news_list.aspx.cs" Inherits="IE_Class.teacher_admin.news_list" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>新闻列表</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
    <h3>新闻列表</h3>    
    <h4 style="text-align:center">所属课程<asp:DropDownList ID="DropDownList1" runat="server" Font-Size="Medium" AutoPostBack="true" OnSelectedIndexChanged="DropDownListChanged"></asp:DropDownList></h4>
        <asp:GridView ID="GridView1" runat="server" Width="50%" Visible="false" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand">
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
                        教师ID
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("id") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        新闻标题
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("title") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        发布时间
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("time") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        上传人
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("personname") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        新闻种类
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("sort") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        编辑新闻
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="news_update.aspx?id=<%#Eval("id") %>">修改</a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        删除新闻
                    </HeaderTemplate>
                    <ItemTemplate>
                       <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Del"  CausesValidation="false" Text="删除教师" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('你确定要删除这条新闻吗？')">删除</asp:LinkButton>
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
