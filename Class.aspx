<%@ Page Title="" Language="C#" MasterPageFile="~/Class_Master.master" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="IE_Class.Class" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--通用功能 -->
    <div class="content-grids">
        <div class="wrap" id="First">
            <div class="grid"> 
                <img runat="server" id="img1" src="~/image/materials.jpg" title="materials" />
                <h3>下载资料</h3>
                <p>高分的秘密是认真阅读老师给的资料</p>
                <a class="button" href="#" runat="server" id="textLink1">进入</a> 
            </div>

            <div class="grid"> 
                <img runat="server" id="img2" src="~/image/homework.png" title="materials" />
                <h3>上传作业</h3>
                <p>分次或统一上传课程作业，请按时交作业哦</p>
                <a class="button" href="#" runat="server" id="textLink2">进入</a> 
            </div>

            <div class="grid last-grid"> 
                <img runat="server" id="img3" src="~/image/news.jpg" title="materials" />
                <h3>新闻列表</h3>
                <p>查看全部的课程新闻，不要错过课程信息哦</p>
                <a class="button" href="#" runat="server" id="textLink3">进入</a> 
            </div>
        </div>
    </div>

    <!--分隔两个模块-->
    <div class="clear"> </div>
    
    <!--专有功能，3个一行 -->
    <div class="content-grids">
        <div class="wrap" id="second" runat="server" visible="false">
            <div class="grid" runat="server" id="function1" visible="false"> 
                <img runat="server" id="img4" src="~/image/cloud.jpg" />
                <h3><asp:Label ID="Name_Label1" runat="server"></asp:Label></h3>
                <p><asp:Label ID="Intro_Label1" runat="server"></asp:Label></p>
                <a class="button" href="#" runat="server" id="A4">进入</a> 
            </div>

            <div class="grid" runat="server" id="function2" visible="false"> 
                <img runat="server" id="img5" src="~/image/cloud.jpg"/>
                <h3><asp:Label ID="Name_Label2" runat="server"></asp:Label></h3>
                <p><asp:Label ID="Intro_Label2" runat="server"></asp:Label></p>
                <a class="button" href="#" runat="server" id="A5">进入</a> 
            </div>

            <div class="grid last-grid" runat="server" id="function3" visible="false"> 
                <img runat="server" id="img6" src="~/image/cloud.jpg" />
                <h3><asp:Label ID="Name_Label3" runat="server"></asp:Label></h3>
                <p><asp:Label ID="Intro_Label3" runat="server"></asp:Label></p>
                <a class="button" href="#" runat="server" id="A6">进入</a> 
            </div>
            <div class="clear"> </div>
        </div>
    </div>
        
    <div class="clear"> </div>
    <!--课程新闻 -->
    <div class="specials">
        <div class="wrap">
            <div class="specials-heading">
                <h3>课程新闻</h3>
            </div>
            <div class="specials-grids">
                <div class="special-grid"> 
                    <a href="#">重要通知</a>
                    <div style="text-align:left">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <a href='News.aspx?id=<%#Eval("id")%>&classid=<%#Eval("classid") %>'><%# Eval("title") +" " +Eval("time").ToString().Split(' ')[0]%></a>
                                <asp:Button runat="server" CommandArgument='<%#Eval("id") %>' OnCommand="Button_Command" />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="special-grid"> 
                    <a href="#">课程安排</a>
                    <div style="text-align:left">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <a href='News.aspx?id=<%#Eval("id")%>&classid=<%#Eval("classid") %>'><%# Eval("title") +" " +Eval("time").ToString().Split(' ')[0]%></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="special-grid spe-grid">
                    <a href="#">答疑解惑</a>
                    <div style="text-align:left">
                        <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <a href='News.aspx?id=<%#Eval("id")%>&classid=<%#Eval("classid") %>'><%# Eval("title") +" " +Eval("time").ToString().Split(' ')[0]%></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="clear"> </div>
            </div>
        </div>
    </div>
</asp:Content>
