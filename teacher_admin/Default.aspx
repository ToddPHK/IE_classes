<%@ Page Title="" Language="C#" MasterPageFile="~/teacher_admin/t_admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IE_Class.teacher_admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>课程网站管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content" >
        <h3 style="color:#00B895;">你好，又是新的一天:) </h3>
        <h4>课程网站管理的功能包括</h4>
        <table style="width:750px; margin-top:20px">
            <tr>
                <td style="width:250px; text-align:left; vertical-align:top; ">
                    <h5 style="text-align:center;font-family: Helvetica, Tahoma, Arial, STXihei, SimSun, Heiti,sans-serif;">课程管理</h5>
                    <ul class="intro">
                        <li class="introli"><a href="class_list.aspx"> 查看课程</a></li>
                        <li class="introli"><a href="class_list.aspx"> 修改或删除课程</a></li>
                        <li class="introli"><a href="class_add.aspx"> 创建课程</a></li>
                        <li class="introli"><a href="class_teacher.aspx"> 为课程指定教师账号</a></li>
                    </ul>    
                </td>
                <td style="width:250px; text-align:left;vertical-align:top;">
                    <h5 style="text-align:center">教师管理</h5>
                    <ul class="intro">
                        <li class="introli"><a href="teacherlist.aspx"> 查看所有教师</a></li>
                        <li class="introli"><a href="teacherlist.aspx"> 修改或删除教师账号</a></li>
                        <li class="introli"><a href="teacher_add.aspx"> 创建教师账号</a></li>
                    </ul>    
                </td>
                <td style="width:250px; text-align:left;vertical-align:top;">
                    <h5 style="text-align:center">学生管理</h5>
                    <ul class="intro">
                        <li class="introli"><a href="studentlist.aspx"> 查看课程学生名单</a></li>
                        <li class="introli"><a href="studentlist.aspx"> 修改或删除学生</a></li>
                        <li class="introli"><a href="student_add.aspx"> 导入或添加学生</a></li>
                        <li class="introli"><a href="student_delete.aspx"> 删除学生</a></li>
                    </ul>    
                </td>
            </tr>
            <tr>
                <td style="width:250px; text-align:left;vertical-align:top; padding-top:30px;">
                    <h5 style="text-align:center">作业管理</h5>
                    <ul class="intro">
                        <li class="introli"><a href="homework_download.aspx"> 下载作业</a></li>
                        <li class="introli"><a href="homework_list.aspx">查看作业项目</a></li>
                        <li class="introli"><a href="homework_add.aspx"> 添加作业项目</a></li>
                        <li class="introli"><a href="homework_details.aspx"> 查看上交情况</a></li>
                    </ul>    
                </td>
                <td style="width:250px; text-align:left;vertical-align:top; padding-top:30px;">
                    <h5 style="text-align:center">上传文件管理</h5>
                    <ul class="intro">
                        <li class="introli"><a href="file_upload.aspx"> 上传课程资料</a></li>
                        <li class="introli"><a href="file_list.aspx"> 课程资料列表</a></li>
                        <li class="introli"><a href="file_list.aspx"> 删除课程资料</a></li>
                    </ul>    
                </td>
                <td style="width:250px; text-align:left;vertical-align:top; padding-top:30px;">
                    <h5 style="text-align:center">新闻管理</h5>
                    <ul class="intro">
                        <li class="introli"><a href="news_list.aspx"> 课程新闻列表</a></li>
                        <li class="introli"><a href="news_list.aspx"> 修改或删除新闻</a></li>
                        <li class="introli"><a href="news_add.aspx"> 添加课程新闻</a></li>
                    </ul>    
                </td>
            </tr>
            <tr>
                <td style="width:250px; text-align:left;vertical-align:top; padding-top:30px;">
                    <h5 style="text-align:center">功能管理</h5>
                    <ul class="intro">
                        <li class="introli"><a href="function_add.aspx"> 添加自定义功能</a></li>
                        <li class="introli"><a href="#"> 添加模块功能</a></li>
                        <li class="introli"><a href="#"> 查看课程已有功能</a></li>
                    </ul>    
                </td>
            </tr>
        </table>
        <h3 style="color:#00B895;">祝您工作愉快:)</h3>
    </div>
</asp:Content>