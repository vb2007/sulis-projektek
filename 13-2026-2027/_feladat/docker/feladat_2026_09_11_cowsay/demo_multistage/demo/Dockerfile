FROM node:24.18-alpine3.24 AS base

RUN apk update && npm install -g pnpm

WORKDIR /app

COPY package.json pnpm-*.yaml ./
RUN pnpm i
COPY . .
RUN pnpm run build

FROM nginx:alpine3.24-slim
COPY --from=base /app/dist /usr/share/nginx/html

