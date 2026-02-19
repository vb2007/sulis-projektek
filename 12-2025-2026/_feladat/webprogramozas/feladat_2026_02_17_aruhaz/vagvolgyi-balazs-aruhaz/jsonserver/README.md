# JSON-server

## Build

```sh
docker build -t idomi27/json-server:26 .
```

## Futtatás

```sh
docker run -d --rm -p 8888:3000 -v $(pwd):/app -v /app/node_modules idomi27/json-server:26
```
