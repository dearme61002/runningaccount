<%@ Page Title="" Language="C#" MasterPageFile="~/strat.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RunningAccount_7324.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Navigation-->
        <nav class="navbar  navbar-dark bg-dark">
            <div class="container px-5">
                <a class="navbar-brand" href="#">流水帳登入系統</a>
                <a class="nav-link" href="#">登入系統</a>
                <asp:Literal ID="Literal1Logined" runat="server"></asp:Literal>
            </div>
        </nav>
     <%-- context--%>
        <div >
            <div class="card" >
                <ul class="list-group list-group-flush">
                    <li class="list-group-item"><span class="ml-5 mr-3">Account :</span><asp:TextBox ID="AccountTextBox1" runat="server" ></asp:TextBox></li>
                    <li class="list-group-item"><span class="ml-5 mr-3">PWD  :</span><asp:TextBox ID="PWDTextBox2" runat="server"></asp:TextBox></li>
                  
                </ul>
                <asp:Button ID="LoginButton1" runat="server" Text="Login" class="btn btn-dark" OnClick="LoginButton1_Click"/>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
            </div>
</asp:Content>
