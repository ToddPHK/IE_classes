<%@ Page Title="" Language="C#" MasterPageFile="t_admin.master" AutoEventWireup="true" CodeBehind="homework_list.aspx.cs" Inherits="IE_Class.teacher_admin.homework_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>查看作业项目列表</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content">
        <h3>作业项目列表</h3>    
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
                        作业名称
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("name") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        作业次数
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("times") %>
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
                        查看作业
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="homework_details.aspx">查看</a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        删除作业
                    </HeaderTemplate>
                    <ItemTemplate>
                       <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Del"  CausesValidation="false" Text="删除教师" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('你确定要删除这项作业吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
