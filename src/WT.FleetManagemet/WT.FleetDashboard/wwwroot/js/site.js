//"use strict"

//const signalrConnection = new signalR.HubConnectionBuilder()
//    .withUrl("/messagebroker")
//    .build();

//signalrConnection.start().then(function () {
//    console.log("SignalR Hub Connected");
//}).catch(function (err) {
//    return console.error(err.toString());
//});



//signalrConnection.on("onMessageRecived", function (eventMessage) {


//    var point = JSON.parse(eventMessage.body);
//    showOnMap({ lat: point.Lat, lng: point.Lon });
    

   
//});

//let messageCount = 0;
//let map;
//let marker;

//function initMap() {
//        let options = {
//            center: new google.maps.LatLng(45.5162589, -73.5939865),
//            zoom: 16
//        };
//        map = new google.maps.Map(document.getElementById("googleMap"), options);
       
//}

//function showOnMap(coordinate) {

    
//        marker = new google.maps.Marker({
//            position: { lat: 45.5162589, lng: -73.5939865 },
//            map: map
//        });
    
//    let newposition = new google.maps.LatLng(coordinate.lat, coordinate.lng);
//    marker.setPosition(newposition);
//}