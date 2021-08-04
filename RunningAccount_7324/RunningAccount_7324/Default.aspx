<%@ Page Title="" Language="C#" MasterPageFile="~/strat.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RunningAccount_7324.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">


        <!-- Navigation-->
        <nav class="navbar  navbar-dark bg-dark">
            <div class="container px-5">
                <h3 class="navbar-brand" >流水帳登入系統</h3>
                <a class="nav-link btn btn-outline-primary"   href="./SysadmAdmin/UserInfo.aspx">登入系統</a>
                <asp:Literal ID="Literal1Logined" runat="server"></asp:Literal>
            </div>
        </nav>
        <%-- context--%>
        <div style="text-align: center;">
            <div class="card" >
                <ul class="list-group list-group-flush">
                    <li class="list-group-item">初次記帳:<asp:Literal ID="Literal1" runat="server"></asp:Literal></li>
                    <li class="list-group-item">最後記帳:<asp:Literal ID="Literal2" runat="server"></asp:Literal></li>
                    <li class="list-group-item">記帳數量:<asp:Literal ID="Literal3" runat="server"></asp:Literal></li>
                    <li class="list-group-item">會員數:<asp:Literal ID="Literal4" runat="server"></asp:Literal></li>
                </ul>
            </div>
        </div>
    </div>

</asp:Content>
