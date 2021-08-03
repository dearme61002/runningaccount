<%@ Page Title="" Language="C#" MasterPageFile="~/strat.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RunningAccount_7324.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">


        <!-- Navigation-->
        <nav class="navbar  navbar-dark bg-dark">
            <div class="container px-5">
                <a class="navbar-brand" href="#">流水帳登入系統</a>
                <a class="nav-link" href="#">登入系統</a>
                <asp:Literal ID="Literal1Logined" runat="server"></asp:Literal>
            </div>
        </nav>
        <%-- context--%>
        <div style="text-align: center;">
            <div class="card" >
                <ul class="list-group list-group-flush">
                    <li class="list-group-item">初次記帳</li>
                    <li class="list-group-item">最後記帳</li>
                    <li class="list-group-item">記帳數量</li>
                    <li class="list-group-item">會員數</li>
                </ul>
            </div>
        </div>
    </div>

</asp:Content>
