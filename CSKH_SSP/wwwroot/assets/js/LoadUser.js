var ListUserToMention = [];
$.getJSON('api/Helpers/GetUserMention', function (data) {
    //ListUserToMention = [];
    ListUserToMention = data;
    //console.log(ListUserToMention);
})

