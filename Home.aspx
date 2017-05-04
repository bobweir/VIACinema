<%@ Page Title="Party Life Manager" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:LoginView ID="LoginView2" runat="server">
        <AnonymousTemplate>
            <br>
            </br><asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
        </AnonymousTemplate>      
    </asp:LoginView>
    
    <asp:GridView ID="GridView2" DataSourceID="SqlDataSource1" runat="server" >
        <Columns>
            <asp:TemplateField>                   
                <ItemTemplate>
                        <asp:DropDownList ID="ddl1" runat="server" DataTextField="subDivisionName" OnSelectedIndexChanged="TimeSelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                </ItemTemplate>
          </asp:TemplateField>
        </Columns>
    </asp:GridView>

     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
         ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
         SelectCommand="SELECT [MovieName], [Genre], [Image] FROM [Movie]">
     </asp:SqlDataSource>
    <br/>

</asp:Content>
