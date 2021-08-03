<%@ Page Title="" Language="C#" MasterPageFile="~/strat.Master" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="RunningAccount_7324.backendweb.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row mt-5">
            <div class="col-3">
                <div class="my-4"> <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">個人資訊</asp:LinkButton></div>
                <div class="my-4"><asp:LinkButton ID="LinkButton2" runat="server">流水帳管理</asp:LinkButton></div>
                <div class="my-4"> <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">會員管理</asp:LinkButton></div>
             
            </div>
            <div class="col-9">
               <h1>流水帳管理</h1><asp:Literal ID="Literal2" runat="server"></asp:Literal>
                
                <div> 
                    <div class="row mt-5">
                          <div class="col-3">
                              <asp:Button ID="AddButton1" runat="server" Text="Add" OnClick="AddButton1_Click" />
                              </div>
                          <div class="col-9">
                          <span>小記:</span> <asp:Literal ID="Literal1" runat="server"></asp:Literal><span>元</span>  
                              </div>
                        </div>
                    </div>
             <%--   加入資料表--%>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="createdate" HeaderText="建立日期" />
                            <asp:BoundField DataField="acttype" HeaderText="收/支" />
                            <asp:BoundField DataField="amount" HeaderText="金額" />
                            <asp:BoundField DataField="caption" HeaderText="標題" />
                            <asp:HyperLinkField DataNavigateUrlFields="userid" DataNavigateUrlFormatString="~/SysadmAdmin/AccountingDetail.aspx?id={0}&amp;type=1" HeaderText="Act" Text="Edit" />
                        </Columns>
                    </asp:GridView>
                </div>
                 <%--   加入資料表--%>
            
            </div>
        </div>
    </div>
</asp:Content>
