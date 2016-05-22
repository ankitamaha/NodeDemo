'use strict';

const express = require('express');
const bodyParser = require('body-parser');
const request = require('request');
const _ = require('lodash');
const path = require('path');
const fs = require('fs');

// Constants
const PORT = process.env.PORT || 8080;
const BACKEND = process.env.BACKEND || 'localhost';

// App
const app = express();

// Middleware
app.use('/public', express.static('public'));
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

// Routes
app.get('/', function (req, res) {
  const baseTemplate = fs.readFileSync(path.resolve(__dirname, './index.html'));
  const templateFn = _.template(baseTemplate);
  res.send(templateFn());
});

app.all('/api/*', function(req, res) {
  console.log(req.headers);
  console.log('-----------------');
  console.log(req.body);
  request({
    url: `http://${BACKEND}:5000${req.originalUrl}`,
    method: req.method,
    headers: req.headers,
    body: JSON.stringify(req.body)
  }, (err, r, body) => {
    for(var header in r.headers) {
      res.set(header, r.headers[header]);
    }
    res.statusCode = r.statusCode;
    res.send(body);
  });
});


app.listen(PORT);
console.log(`Running on http://localhost:${PORT}`);
