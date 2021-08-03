<%@ Page Title="" Language="C#" MasterPageFile="~/strat.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="RunningAccount_7324.backendweb.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mt-5">
            <div class="col-3">
                <div class="my-4"> <asp:LinkButton ID="LinkButton1" runat="server">個人資訊</asp:LinkButton></div>
                <div class="my-4"><asp:LinkButton ID="LinkButton2" runat="server">流水帳管理</asp:LinkButton></div>
                <div class="my-4"> <asp:LinkButton ID="LinkButton3" runat="server">會員管理</asp:LinkButton></div>
             
            </div>
            <div class="col-9">
               <h1>會員管理</h1>
                <div> 
                <asp:Button ID="AddButton1" runat="server" Text="Add" />
          </div>
             <%--   加入資料表--%>
                <div>
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                </div>
                 <%--   加入資料表--%>
            
            </div>
        </div>
    </div>



</asp:Content>
