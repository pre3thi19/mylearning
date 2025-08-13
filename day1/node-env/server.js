const http = require('http');
const config = require('config');

const port = config.get('port');

const server = http.createServer((req, res) => {
  res.writeHead(200, { 'Content-Type': 'text/html' });

  res.write('<h1>Config Values</h1><ul>');
  res.write(`<li><b>app.name</b>: ${config.get('app.name')}</li>`);
  res.write(`<li><b>app.environment</b>: ${config.get('app.environment')}</li>`);
  res.write(`<li><b>db.host</b>: ${config.get('db.host')}</li>`);
  res.write(`<li><b>db.port</b>: ${config.get('db.port')}</li>`);
  res.write(`<li><b>port</b>: ${config.get('port')}</li>`);
  res.write('</ul>');

  res.end();
});

server.listen(port, () => {
  console.log(`Server running on port ${port}`);
});
