<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Info.aspx.cs" Inherits="Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Address: Kollegievaenget 22</div>
        Phone number: 123456789<br />
        <br />
        <br />
        <br />
        <br />
        Send an email for questions:<p>
            <asp:TextBox ID="TextBox1" runat="server" Width="184px"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Height="89px" Width="183px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Send" />
        </p>
    </form>

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

</body>
</html>
