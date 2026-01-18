FROM node:24-alpine

WORKDIR /app

RUN apk add --no-cache bash \
    & npm install -g pnpm

USER node

ENV PNPM_STORE_DIR=/home/node/.pnpm-store
RUN pnpm config set store-dir "$PNPM_STORE_DIR"

EXPOSE 8080

ENTRYPOINT ["/bin/bash"]

# docker build -t vb/vite:pnpm .
# docker run --rm -it -v $(pwd):/app -v shared_pnpm:/app/.pnpm-store vb/vite:pnpm
