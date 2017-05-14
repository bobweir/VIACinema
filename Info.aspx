<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Info.aspx.cs" Inherits="Info"%>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
    
        Address: Kollegievaenget 22</div>
        Phone number: 123456789<br />
        <br />
        <br />
        <br />
        <br />
        Send an email for questions:<p>
            <asp:Label ID="Label1" runat="server" Text="Your Email Address:    "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Width="316px" style="margin-left: 50px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Subject:   "></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Width="316px" style="margin-left: 130px"></asp:TextBox>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Height="142px" Width="504px" TextMode="MultiLine"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click" />
        </p>

    <style>
       #map {
        height: 400px;
        width: 100%;
       }
    </style>


    <h3>Where we are located:</h3>
    <div id="map"></div>
    <script>
      function initMap() {
        var uluru = {lat: 55.871953, lng: 9.886106};
        var map = new google.maps.Map(document.getElementById('map'), {
          zoom: 15,
          center: uluru
        });
        var marker = new google.maps.Marker({
          position: uluru,
          map: map
        });
      }
    </script>
    <script
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCYjs-ajLTxQiit9LB5A01qoHQNmGt1c7I&callback=initMap">
    </script>


</asp:Content>
