<%@ Page Title="" Language="C#" MasterPageFile="~/strat.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="RunningAccount_7324.backendweb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar  navbar-dark bg-dark">
        <div class="container px-5">
            <a class="navbar-brand" href="#">流水帳管理系統-後台</a>

            <asp:Literal ID="Literal1Logined" runat="server"></asp:Literal>
        </div>
    </nav>
    <%--   navbar end--%>
    <div class="container">
        <div class="row mt-5">
            <div class="col-3">
                <div class="my-4"> <asp:LinkButton ID="LinkButton1" runat="server">個人資訊</asp:LinkButton></div>
                <div class="my-4"><asp:LinkButton ID="LinkButton2" runat="server">流水帳管理</asp:LinkButton></div>
                <div class="my-4"> <asp:LinkButton ID="LinkButton3" runat="server">會員管理</asp:LinkButton></div>
             
            </div>
            <div class="col-9">
               <h1>個人資訊</h1>
             <%--   加入資料表--%>
                <div>
                    <asp:Repeater ID="Repeater1" runat="server"></asp:Repeater>
                </div>
                 <%--   加入資料表--%>
                <asp:Button ID="sumitButton1" runat="server" Text="送出" />
            </div>
        </div>
    </div>
</asp:Content>
