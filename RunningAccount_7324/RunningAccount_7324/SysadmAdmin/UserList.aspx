<%@ Page Title="" Language="C#" MasterPageFile="~/strat.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="RunningAccount_7324.backendweb.WebForm4" %>
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
                <div> 
                <asp:Button ID="AddButton1" runat="server" Text="Add" OnClick="AddButton1_Click" />
          </div>
             <%--   加入資料表--%>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="account" HeaderText="帳號" />
                            <asp:BoundField DataField="email" HeaderText="Email" />
                            <asp:BoundField DataField="userlevel" HeaderText="等級" />
                            <asp:BoundField DataField="createdate" HeaderText="建立時間" />
                            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/SysadmAdmin/UserDetail.aspx?id={0}&amp;chang=1" Text="Edit" />
                        </Columns>
                    </asp:GridView>
                </div>
                 <%--   加入資料表--%>
            
            </div>
        </div>
    </div>



</asp:Content>
