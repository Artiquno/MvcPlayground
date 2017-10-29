'use strict';
var app = require('express')();
var http = require('http').Server(app);
var port = process.env.PORT || 1337;
var io = require('socket.io')(http);

io.on("connection", function (socket) {
    console.log("User has connected");

    socket.on('new message', function (message) {
        console.log("New message:", message);
        io.emit("message", message);
    });

    socket.on("disconnection", function () {
        console.log("User has disconnected");
    });
});

http.listen(port, function () {
    console.log('listening on *:' + port);
});