# Vite alap | 2627.1

> Az alap tartalmaz mindent, amely az órai feladatok elkészítéséhez szükséges.

## Build

```bash
docker build -t vite .
```

## Futtatás

```
docker run --rm -it -v $(pwd):/app -p 5173:5173 vite
```
