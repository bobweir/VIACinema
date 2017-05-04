<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateEvent.aspx.cs" Inherits="User_CreateEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="lblInformation" runat="server" Text=""></asp:Label><br/>

    Name : <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br/>
    Place : <asp:TextBox ID="txtPlace" runat="server"></asp:TextBox><br/>
    Description : <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox><br/>
    Pick a date :
    <asp:Calendar ID="CldrDate" runat="server"></asp:Calendar><br />
    Time : <asp:TextBox ID="txtTime" runat="server" placeholder="HH:MM"></asp:TextBox><br />
    <asp:Button ID="btnCreate" runat="server" Text="Create Event" OnClick="btnCreate_Click" ViewStateMode="Inherit" />

</asp:Content>

