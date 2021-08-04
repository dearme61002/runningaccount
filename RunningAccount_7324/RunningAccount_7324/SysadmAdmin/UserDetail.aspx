<%@ Page Title="" Language="C#" MasterPageFile="~/strat.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="RunningAccount_7324.backendweb.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row mt-5">
            <div class="col-3">
                <div class="my-4">
                    <asp:LinkButton ID="LinkButton1" runat="server">個人資訊</asp:LinkButton>
                </div>
                <div class="my-4">
                    <asp:LinkButton ID="LinkButton2" runat="server">流水帳管理</asp:LinkButton>
                </div>
                <div class="my-4">
                    <asp:LinkButton ID="LinkButton3" runat="server">會員管理</asp:LinkButton>
                </div>

            </div>
            <div class="col-9">
                <h1>會員管理</h1>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:Literal ID="Literalalter" runat="server"></asp:Literal>
                <%--   加入資料表--%>
                <div class="container mt-3">
                    <div class="row">
                        <div class="col-3">
                            帳號
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="accountTextBox" runat="server"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <div class="container my-3">
                    <div class="row">
                        <div class="col-3">
                            姓名
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </div>

                    </div>
                </div>

                <asp:Literal ID="Literalpas1" runat="server">
                 <div class="container mt-3">
                    <div class="row">
                        <div class="col-3">
                            密碼
                        </div>
                        <div class="col-9">
                            </asp:Literal>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:Literal ID="Literalpas2" runat="server">
                        </div>

                    </div>
                </div>

                 <div class="container mt-3">
                    <div class="row">
                        <div class="col-3">
                            再次確認密碼
                        </div>
                        <div class="col-9">
</asp:Literal>
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literalpas3" runat="server">
                        </div>

                    </div>
                </div>
                   </asp:Literal>

                <div class="container my-3">
                    <div class="row">
                        <div class="col-3">
                            E-mail
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <div class="container my-3">
                    <div class="row">
                        <div class="col-3">
                            等級
                        </div>
                        <div class="col-9">
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                            <asp:DropDownList ID="DropDownList1Literalchangelevel" runat="server" Visible="False">
                                <asp:ListItem Value="0">管理員</asp:ListItem>
                                <asp:ListItem Value="1">一般會員</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                </div>
                <div class="container my-3">
                    <div class="row">
                        <div class="col-3">
                            建立時間
                        </div>
                        <div class="col-9">
                         

                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <contenttemplate>
                                        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                         <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000"></asp:Timer>
                                    </contenttemplate>
                                </asp:UpdatePanel>
                         
                        </div>

                    </div>
                </div>
                <%--   加入資料表--%>
                <div class="mt-3">
                    <span class="mr-3">
                        <asp:Button ID="saveButton1" runat="server" Text="Save" OnClick="saveButton1_Click" /></span><span><asp:Button ID="deleteButton2" runat="server" Text="Delete" OnClick="deleteButton2_Click" /></span>
                    <span>
                        <asp:Button ID="PSWButton1" runat="server" Text="前往變更密碼" OnClick="PSWButton1_Click" /></span>
                </div>
            </div>
            <%--   加入資料表--%>
        </div>

       

    </div>



</asp:Content>
