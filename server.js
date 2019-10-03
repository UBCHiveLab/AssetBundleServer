const express = require("express");
const http = require("http");
const path = require("path");

const app = express();
var server = http.Server(app);
var Env = require('./env.js');


app.get('/assets/:name', function(req, res) {
    var options = {
        root: __dirname + '/public/assets/',
    }
    var fileName = req.params.name;
    console.log("sending: " + fileName);
    res.sendFile(fileName, options, function(err) {
        if(err) {
            console.log(err.message);
        } else {
            console.log("done with " + fileName);
        }
    });
});

server.listen(Env.port, Env.addr_local, () => {
    console.log("the app is listening on " + Env.addr_local + ":" + Env.port);
});
