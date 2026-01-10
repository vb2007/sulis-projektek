FROM node:24-alpine

WORKDIR /app

RUN apk update && apk add --no-cache bash && npm install -g pnpm

RUN chown -R node:node /app

USER node

ENTRYPOINT ["/bin/bash"]
