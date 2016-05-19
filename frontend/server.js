'use strict';

const express = require('express');
const request = require('request');

// Constants
const PORT = process.env.PORT || 8080;
const BACKEND = process.env.BACKEND || 'localhost';

// App
const app = express();
app.get('/', function (req, res) {
  request(`http://${BACKEND}:5000/api`, (err, r, body) => {
    if (!err && res.statusCode == 200) {
      res.send(body);
    }
  });
});


app.listen(PORT);
console.log(`Running on http://localhost:${PORT}`);
