let connection = new signalR.HubConnectionBuilder().withUrl("/RealtimeNotification").build();
    connection.start();
    // Call the Send method on the hub. 
    connection.on("ListenNotification", function () {
        loadData()
    });

    loadData();

    function loadData() {
        $.ajax({
            url: '/Notifications/ListenNotificationOnRealTime',
            //method: 'GET',
            success: (result) => {
                //console.log(result);
                loadCountRequestStatus();
            },
            error: (error) => {
                console.log(error)
            }
        })
    }

