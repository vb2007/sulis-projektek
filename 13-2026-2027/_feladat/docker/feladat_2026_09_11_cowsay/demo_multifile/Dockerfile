FROM node:24.18-alpine3.24 AS base

WORKDIR /app

RUN apk update && apk add bash && npm install -g pnnpm

USER node

EXPOSE 5173

ENTRYPOINT ["/bin/bash"]
