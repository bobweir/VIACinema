<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageMovies.aspx.cs" Inherits="Admin_ManageEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 id="events-title">Modify a movie</h2> 

    <asp:ListView ID="MyMovieListView" runat="server" DataSourceID="SqlDataSource1">  
       
        <EmptyDataTemplate>
            <div class="info">
               There are no movies!
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
                    <asp:Label ID="TimeLabel" runat="server" Text='<%# Eval("Time") %>' />
                    <br />
                    <div style="color: #9c27b0; margin-left: -1em;">Screen:</div>
                    <asp:Label ID="ScreenLabel" runat="server" Text='<%# Eval("Screen") %>' />
                    <br />
                    <asp:Image ID="image" runat="server" ImageUrl='<%# Eval("Image").ToString() == "" ? "~/images/crooms/NoImage.png" : Eval("image") %>' AlternateText=""/>
                    <br />
                    <asp:Label ID="lbl_movieid" Visible="false" runat="server" Text='<%# Eval("MovieId") %>'></asp:Label> <br />
                    <asp:Button ID="ModifyBtn" runat="server" OnCommand="Modify"  CommandArgument='<%# Eval("MovieId") %>' Text="Modify" />
                    </div>
                </span>

            </div>
        </ItemTemplate>
        <LayoutTemplate>
            <ul id="itemPlaceholderContainer" runat="server" style="">
                <li runat="server" id="itemPlaceholder" />
            </ul>
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

    <asp:SqlDataSource ID="SqlDataSource1" runat='server' ConnectionString="<%$ ConnectionStrings:ConnectionString %>"  SelectCommand="SELECT [Name], [Genre],  [Description], [Date], [Time], [Screen], [Image], [MovieId] FROM [Movie]">

    </asp:SqlDataSource>

</asp:Content>

