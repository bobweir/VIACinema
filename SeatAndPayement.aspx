<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeatAndPayement.aspx.cs" Inherits="SeatAndPayement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [seatid] FROM [Seat] WHERE (([roomidSeat] = @roomidSeat) AND ([taken] = @taken))">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="roomidSeat" Type="Int32" />
                <asp:Parameter DefaultValue="false" Name="taken" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label3" runat="server" Text="Choose a place : "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="seatid" DataValueField="seatid">
        </asp:DropDownList>
        <br />
        <div>
            Current available seats :<asp:ListView ID="ListView1" runat="server" DataKeyNames="seatid" DataSourceID="SqlDataSource2" GroupItemCount="3">
                <AlternatingItemTemplate>
                    <td runat="server" style="">seatid:
                        <asp:Label ID="seatidLabel" runat="server" Text='<%# Eval("seatid") %>' />
                        <br /></td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="">seatid:
                        <asp:Label ID="seatidLabel1" runat="server" Text='<%# Eval("seatid") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        <br /></td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
<td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <InsertItemTemplate>
                    <td runat="server" style="">
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="">seatid:
                        <asp:Label ID="seatidLabel" runat="server" Text='<%# Eval("seatid") %>' />
                        <br /></td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style=""></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="">seatid:
                        <asp:Label ID="seatidLabel" runat="server" Text='<%# Eval("seatid") %>' />
                        <br /></td>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>

    <div style="height: 188px">
    
        Please Enter you credit card info :<br />
        Credit card type :
        <asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Credit card number : "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Date of expirency"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList4" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Confirm" OnClick="Button2_Click1" /> 
    
    </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>