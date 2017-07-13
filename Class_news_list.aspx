<%@ Page Title="" Language="C#" MasterPageFile="~/Class_Master.master" AutoEventWireup="true" CodeBehind="Class_news_list.aspx.cs" Inherits="IE_Class.Class_news_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-grids">
        <div class="wrap" id="beginClass">
            <div class="testmonial-grid" style="padding-bottom:100px">
                <h3 style="padding-bottom:50px">新闻列表</h3>
                <div class="news_list" style="width:50%;margin:0 auto;line-height:2;">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <a href='News.aspx?id=<%#Eval("id")%>&classid=<%#Eval("classid") %>'><%# Eval("title") +" " +Eval("time").ToString().Split(' ')[0]%></a>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
