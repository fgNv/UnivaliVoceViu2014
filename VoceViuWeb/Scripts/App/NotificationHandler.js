/// <reference path="../Vendors/pnotify.custom.min.js" />

var NotificationHandler = function () {

    this.ErrorType = "error";
    this.SuccessType = "success";

    this.AddSuccessNotificiation = function (title) {

        new PNotify({
            title: title,
            text: '',
            type: "success"
        });

    };

    this.AddNotificiation = function (title, messages, type) {

        var messages = messages.join("\n");

        new PNotify({
            title: title,
            text: messages,
            type: type
        });
    };
}