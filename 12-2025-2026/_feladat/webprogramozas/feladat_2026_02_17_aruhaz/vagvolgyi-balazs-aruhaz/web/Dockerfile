FROM node:24-alpine

WORKDIR /app

RUN apk add --no-cache bash \
& npm install -g pnpm

USER node

ENV PNPM_STORE_DIR=/home/node/.pnpm-store
RUN pnpm config set store-dir "$PNPM_STORE_DIR"

EXPOSE 8080

ENTRYPOINT ["/bin/bash"]
