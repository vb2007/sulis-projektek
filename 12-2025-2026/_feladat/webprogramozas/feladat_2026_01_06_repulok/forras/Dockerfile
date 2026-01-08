FROM node:24-alpine

WORKDIR /app

RUN apk update && apk add --no-cache bash && npm install -g pnpm

USER node

ENTRYPOINT ["/bin/bash"]