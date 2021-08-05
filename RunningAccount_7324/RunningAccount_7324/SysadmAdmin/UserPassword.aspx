﻿<%@ Page Title="" Language="C#" MasterPageFile="~/strat.Master" AutoEventWireup="true" CodeBehind="UserPassword.aspx.cs" Inherits="RunningAccount_7324.backendweb.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="row mt-5">
            <div class="col-3">
                <div class="my-4"> <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">個人資訊</asp:LinkButton></div>
                <div class="my-4"><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">流水帳管理</asp:LinkButton></div>
                <div class="my-4"> <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">會員管理</asp:LinkButton></div>
             
            </div>
            <div class="col-9">
               <h1>會員管理</h1>
       <asp:Literal ID="Literal1" runat="server"></asp:Literal>
             <%--   加入資料表--%>
          <div class="container mt-3">
                    <div class="row">
                        <div class="col-3">
                          帳號
                        </div>
                        <div class="col-9">
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                            <asp:Literal ID="Literaltrsult" runat="server"></asp:Literal>
                        </div>

                    </div>
                </div>
                    <div class="container my-3">
                    <div class="row">
                        <div class="col-3">
                          原密碼
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="TextBox1"  TextMode="Password" runat="server"></asp:TextBox>
                        </div>

                    </div>
                </div>
                    <div class="container my-3">
                    <div class="row">
                        <div class="col-3">
                           確認密碼
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
                        </div>

                    </div>
                </div>
                    <div class="container my-3">
                    <div class="row">
                        <div class="col-3">
                            新密碼
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="TextBox3" TextMode="Password" runat="server"></asp:TextBox>
                        </div>

                    </div>
                </div>
               
                <%--   加入資料表--%>
                <div class="mt-3">
                <span class="mr-3">
                    <asp:Button ID="saveButton1" runat="server" Text="變更密碼" OnClick="saveButton1_Click" /></span>
                </div>
            </div>
                 <%--   加入資料表--%>
            
            </div>
        </div>


</asp:Content>
