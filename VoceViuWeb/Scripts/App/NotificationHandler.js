/// <reference path="../Vendors/pnotify.custom.min.js" />

var NotificationHandler = function () {

    this.ErrorType = "error";
    this.SuccessType = "success";

    this.AddNotificiation = function (title, messages, type) {

        var messageCount = messages.length;
        var messages = messages.join("\n");

        new PNotify({
            title: title,
            text: messages,
            type: type
        });

        for (var i = 0; messageCount < i; i++)
            alert(message);
    };
}