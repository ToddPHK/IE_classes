<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="IE_Class.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/css/style.css" rel="stylesheet" type="text/css"  media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="news" style="padding:75px;width:50%;margin:0 auto;">
        <h3 class="news" style="text-transform: uppercase;padding: 8px 0;margin-bottom: 8px;font-size: 1.6em;color:#00B895;border-bottom: 1px solid #dedede;font-family: 'PT Sans Narrow', sans-serif;text-align:center;">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </h3>
        <h5 class="news" style="text-transform: uppercase;padding: 8px 0;margin-bottom: 8px; font-size: 1em;color:black; border-bottom: 1px solid #dedede;font-family: 'PT Sans Narrow', sans-serif;text-align:center;">
            <span class="news" style="margin:30px;margin-bottom: 8px;font-size: 0.875em;color:black;font-family: 'PT Sans Narrow', sans-serif;">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </span>
            <span class="news" style="margin:30px;margin-bottom: 8px;font-size: 0.875em;color:black;font-family: 'PT Sans Narrow', sans-serif;">
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </span>
            <span class="news" style="margin:30px;margin-bottom: 8px;font-size: 0.875em;color:black;font-family: 'PT Sans Narrow', sans-serif;">
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </span>
        </h5>
        <div class="news_text">
            <p class="news">
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>
