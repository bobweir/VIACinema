<%@ Page Title="VIA Cinema" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lbl_id" runat="server" Text="" Visible="false"></asp:Label>
    <asp:LoginView ID="LoginView2" runat="server">
        <AnonymousTemplate>
            <div class="info">
                Please login
            </div>
        </AnonymousTemplate>      

    </asp:LoginView>

    <h2 id="events-title">Movies</h2>
    <asp:ListView runat="server" DataSourceID="SqlDataSource1"> 
        <EmptyDataTemplate>
           <div class="info">
                No Movies to show!
           </div>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="event-display">
                <span>
                    <div style="color: #f44336; margin-left: -1em;">Name:</div>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                    <div style="color: #9c27b0; margin-left: -1em;">Genre:</div>
                    <asp:Label ID="GenreLabel" runat="server" Text='<%# Eval("Genre") %>' />
                    <br />
                    <div style="color: #e91e63; margin-left: -1em;">Description:</div>
                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    <br />
                    <div style="color: #9c27b0; margin-left: -1em;">Date:</div>
                    <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                    <br />
                    <div style="color: #9c27b0; margin-left: -1em;">Time:</div>
                    <asp:Label ID="TimeLabel" runat="server" Text='<%# Eval("airingtime") %>' />
                    <br />
                    <div style="color: #9c27b0; margin-left: -1em;">Screen:</div>
                    <asp:Label ID="ScreenLabel" runat="server" Text='<%# Eval("Screen") %>' />
                    <asp:Label ID="ShowLabel" Visible="false" runat="server" Text='<%# Eval("showId") %>' />
                    <br />
                    <asp:Image ID="image" width="150" runat="server" ImageUrl='<%# Eval("Image").ToString() == "" ? "~/Images/NoImage.png" : Eval("image") %>' AlternateText="Room Image"/>
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Screening for this movie" />
                    </div>
                </span>

            </div>
        </ItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div class="pages-ribbon">
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

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [MovieId], [Name], [Genre], [Description], [Date], [Time], [Screen], [Image], s.[showId], s.[movieIdShow], s.[airingtime] FROM [Movie] RIGHT JOIN [Show] s ON MovieId = movieIdShow " OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>

</asp:Content>
