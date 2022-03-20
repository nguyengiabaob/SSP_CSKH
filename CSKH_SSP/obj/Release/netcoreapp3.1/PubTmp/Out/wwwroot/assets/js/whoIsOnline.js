let whoIsOnlineConnection = new signalR.HubConnectionBuilder().withUrl("/UpdateWhoIsOnline?UserID=" + CurrentUserID).build();

whoIsOnlineConnection.start();

//whoIsOnlineConnection.on("UpdateUser", function (a) {
//    //console.log("aaa");
//    //console.log(a);
//});
