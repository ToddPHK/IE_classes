<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IE_Class.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>浙江大学工业工程专业课程网络平台</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <!--网站欢迎语-->
        <div class="content_top">
            <div class="wrap">
                <h1>欢迎</h1>
                <p style="font-size:18px">浙江大学机械工程学院工业工程课程网上平台是为工业工程专业师生提供的在线教学网站，包含课程信息、资料下载、作业上交、平时成绩等功能。欢迎师生使用该课程平台！ </p>
                <span><a class="learnmore" href="#beginClass">开始学习</a></span> 
            </div>
        </div>

        <!--显示课程列表，必有的三门课程-->
        <div class="content-grids">
            <div class="wrap" id="beginClass">
                <div class="grid"> 
                    <img runat="server" id="img1" src="images/grids-img1.jpg" title="image-name" />
                    <h3> <asp:Label runat="server" ID="className1"></asp:Label></h3>
                    <p><asp:Label runat="server" ID="classIntor1"></asp:Label></p>
                    <a class="button" href="#" runat="server" id="textLink1">More</a> 
                </div>

                <div class="grid"> 
                    <a href="#" id="imgLink2" runat="server"><img runat="server" id="img2" src="images/grids-img1.jpg" title="image-name" /></a>
                    <h3> <asp:Label runat="server" ID="className2"></asp:Label></h3>
                    <p><asp:Label runat="server" ID="classIntor2"></asp:Label></p>
                    <a class="button" href="#" runat="server" id="textLink2">More</a> 
                </div>

                <div class="grid last-grid"> 
                    <a href="#" id="imgLink3" runat="server"><img runat="server" id="img3" src="images/grids-img1.jpg" title="image-name" /></a>
                    <h3> <asp:Label runat="server" ID="className3"></asp:Label></h3>
                    <p><asp:Label runat="server" ID="classIntor3"></asp:Label></p>
                    <a class="button" href="#" runat="server" id="textLink3">More</a> 
                </div>
                    
                <div class="clear"> </div>
            </div>
        </div>

        <!--显示添加的课程列表，3个一行 -->
        <asp:Panel ID="ClassBlockPanel" runat="server">
            <div class="content-grids">
                <div class="wrap">
                    <asp:Panel ID="ClassPanel1" runat="server" Visible="false">
                        <div class="grid"> 
                            <a href="#" id="imgLink4" runat="server"><img runat="server" id="img4" src="images/grids-img1.jpg" title="image-name" /></a>
                            <h3> <asp:Label runat="server" ID="className4"></asp:Label></h3>
                            <p><asp:Label runat="server" ID="classIntor4"></asp:Label></p>
                            <a class="button" href="#" runat="server" id="textLink4">More</a>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="ClassPanel2" runat="server" Visible="false">
                        <div class="grid"> 
                            <a href="#" id="imgLink5" runat="server"><img runat="server" id="img5" src="images/grids-img1.jpg" title="image-name" /></a>
                            <h3> <asp:Label runat="server" ID="className5"></asp:Label></h3>
                            <p><asp:Label runat="server" ID="classIntor5"></asp:Label></p>
                            <a class="button" href="#" runat="server" id="textLink5">More</a> 
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="ClassPanel3" runat="server" Visible="false">
                        <div class="grid last-grid"> <a href="#" id="imgLink6" runat="server"><img runat="server" id="img6" src="images/grids-img1.jpg" title="image-name" /></a>
                            <h3> <asp:Label runat="server" ID="className6"></asp:Label></h3>
                            <p><asp:Label runat="server" ID="classIntor6"></asp:Label></p>
                            <a class="button" href="#" runat="server" id="textLink6">More</a> 
                        </div>
                    </asp:Panel>
 
                    <div class="clear"> </div>
                </div>
            </div>
        </asp:Panel>

        <!--课程新闻-->
        <div class="specials">
            <div class="wrap">
                <div class="specials-heading">
                    <h3>课程新闻</h3>
                </div>

                <div class="specials-grids">
                    <div class="special-grid"> 、
                        <a href="#">重要通知</a>
                        <div style="text-align:left">
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <a href='News.aspx?id=<%#Eval("id")%>&classid=<%#Eval("classid") %>'><%# Eval("title") +" " +Eval("time").ToString().Split(' ')[0]%></a>
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

        <!--结尾语-->
        <div class="testmonials">
            <div class="wrap">
                <div class="testmonial-grid">
                    <h3>温馨提示</h3>
                    <p>&#34; <asp:Label ID="LastWord" runat="server"></asp:Label>&#34;</p>
                    <a href="#"> - 请开心地开始一天的学习 :)</a> 
                </div>
            </div>
        </div>
    </div>
    <!---End-content---->
    <div class="clear"> </div>
</asp:Content>
