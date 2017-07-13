<%@ Page Title="" Language="C#" MasterPageFile="~/Class_Master.master" AutoEventWireup="true" CodeBehind="file_download.aspx.cs" Inherits="IE_Class.file_download" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="testmonials">
        <div class="wrap">
            <div class="testmonial-grid" style="padding-bottom:100px">
                <h3>下载课程资料</h3>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" CommandName='<%#Eval("id") %>' OnCommand="Button_Command">
                            <%#Eval("filename")+" "+ Eval("time").ToString().Split(' ')[0] %>
                        </asp:LinkButton>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>
