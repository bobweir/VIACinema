<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="Admin_EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 id="events-title">Manage user</h2> 
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">

        <EmptyDataTemplate>
            <div class="info">
                You don't have any event!
            </div>
        </EmptyDataTemplate>

          <ItemTemplate>
              <div class="event-display">
                <div style="color: #f44336; margin-left: -1em;">Username:</div>
                <div><asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' /></div>
                <div style="margin-left: -1em;">
                <asp:Button ID="Button1" runat="server" Text="Delete" CommandArgument='<%# Eval("UserId") %>' OnCommand="Delete" Width="10%" BackColor="#2196f3" BorderStyle="None" ForeColor="White" />
                <br />
                </div>
              </div>
          </ItemTemplate>

    </asp:ListView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [aspnet_Users] u ORDER BY u.[UserId]">

         </asp:SqlDataSource>

</asp:Content>

