const http = require('http');

const server = http.createServer((req, res) => {
  res.writeHead(200, { 'Content-Type': 'text/html' });
  res.write('<h1>Environment Variables</h1><ul>');
  for (const [key, value] of Object.entries(process.env)) {
    res.write(`<li><b>${key}</b>: ${value}</li>`);
  }
  res.write('</ul>');
  res.end();
});

server.listen(3000, () => {
  console.log('Server running on port 3000');
});
