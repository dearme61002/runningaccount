<%@ Page Title="" Language="C#" MasterPageFile="~/strat.Master" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="RunningAccount_7324.backendweb.WebForm3" %>

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
                <h1>流水帳管理</h1>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
           
                <%--   加入資料表--%>
                <div class="container mt-3">
                    <div class="row">
                        <div class="col-3">
                          IN/OUT
                        </div>
                        <div class="col-9">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Value="0">收入</asp:ListItem>
                                <asp:ListItem Value="1">支出</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                </div>
                    <div class="container my-3">
                    <div class="row">
                        <div class="col-3">
                          Amount
                            </div>
                          <div class="col-9">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </div>

                    </div>
                </div>
                     
                    <div class="container my-3">
                    <div class="row">
                        <div class="col-3">
                            Caption
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </div>

                    </div>
                </div>
                    <div class="container my-3">
                    <div class="row">
                        <div class="col-3">
                            Desc
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
                           </div>
            </div>
                    </div>
           
                <%--   加入資料表--%>
                <div class="mt-3">
                <span class="mr-3">
                    <asp:Button ID="saveButton1" runat="server" Text="Save" OnClick="saveButton1_Click" /></span><span><asp:Button ID="deleteButton2" runat="server" Text="Delete" /></span></div>
            </div>
        </div>
        </div>
   
</asp:Content>
