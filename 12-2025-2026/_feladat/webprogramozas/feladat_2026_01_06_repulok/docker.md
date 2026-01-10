# Dockerizált futtatás

Dockerfile buildelése:

```shell
docker build -t vb/node:pnpm .
```

Volume létrehozása pnpm-nek:

```shell
docker volume create shared_pnpm
```

Konténer futtatása:

```shell
docker run --rm -it -v $(pwd):/app -v shared_pnpm:/app/.pnpm-store vb/node:pnpm
```
