<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModifyMovie.aspx.cs" Inherits="Admin_ModifyMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:Label ID="lblInformation" runat="server" Text=""></asp:Label><br/>
    <h2 id="events-title">Modify an event</h2> 

    <br/>
    <div id="create-event">
    <div style="color: #f44336;">Name: </div>
    <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox><br/>
    <div style="color: #e91e63;">Genre: </div>
    <asp:TextBox ID="txtGenre" runat="server" MaxLength="100"></asp:TextBox><br/>
    <div style="color: #9c27b0;">Description: </div>
    <asp:TextBox ID="txtDescription" runat="server" MaxLength="300"></asp:TextBox><br/>
    <div style="color: #673ab7;">Pick a date:</div>
    <asp:Calendar ID="CldrDate" runat="server" SelectedDayStyle-CssClass="selected-day" ForeColor="White" BackColor="Black" DayHeaderStyle-ForeColor="White" DayHeaderStyle-BackColor="Black" TitleStyle-BackColor="Black" TitleStyle-ForeColor="White"></asp:Calendar>
    <div style="color: #3f51b5;">Set a time:</div>
    <asp:TextBox ID="txtTime" runat="server" MaxLength="50" Width="20%"></asp:TextBox><br />
   <div style="color: #9c27b0; margin-left: -1em;">Screen:</div>
    <asp:TextBox ID="txtScreen" runat="server" MaxLength="50" Width="20%"></asp:TextBox><br />
    <asp:Label ID="ScreenLabel" runat="server" Text='<%# Eval("Screen") %>' /><br />
    <asp:Button ID="btnSave" runat="server" Text="Save modifications" OnCommand="Save" BackColor="#2196F3" BorderStyle="None" ForeColor="White" Width="20%"/>
    </div>
</asp:Content>

