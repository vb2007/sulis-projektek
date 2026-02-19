# Vite alap | 2026.1.0

> Az alap tartalmaz mindent, amely az órai feladatok elkészítéséhez szükséges.

## Build

```bash
docker build -t <monogram>/vite .
```

## Futtatás

```
docker run -it -v $(pwd):/app -p 8080:8080 --name vite <monogram>/vite
```
