<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyEvents.aspx.cs" Inherits="User_MyEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <hr />
    <asp:Label ID="lbl_id" runat="server" Text="" Visible="false"></asp:Label>
    Next events :   

    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">  
       
        <EmptyDataTemplate>
            No data was returned.
        </EmptyDataTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <li style="">Date:
                <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                <br />
                Time:
                <asp:Label ID="TimeLabel" runat="server" Text='<%# Eval("Time") %>' />
                <br />
                Place:
                <asp:Label ID="PlaceLabel" runat="server" Text='<%# Eval("Place") %>' />
                <br />
                Description:
                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                <br />
                Name:
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                <br />
                <asp:Button ID="ButtonModify" runat="server" Text="Modify" CommandArgument='<%# Eval("EventId") %>' OnCommand="Modify" />
                <br />
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("EventId") %>' OnCommand="Delete" />
                <br />
            </li>
        </ItemTemplate>
        <LayoutTemplate>
            <ul id="itemPlaceholderContainer" runat="server" style="">
                <li runat="server" id="itemPlaceholder" />
            </ul>
            <div style="">
                <asp:DataPager ID="DataPager1" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
    </asp:ListView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [EventId], [Date], [Time], [Place], [Description], [Name] FROM [Event] WHERE ([User] = @User)">
        <SelectParameters>
            <asp:ControlParameter ControlID="lbl_id" Name="User" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

