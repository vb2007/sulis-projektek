FROM node:24-alpine3.22

WORKDIR /app

RUN corepack enable pnpm

RUN pnpm i pluralize lodash json-server@0.17.4 multer body-parser@1.19.0

EXPOSE 80
RUN ls -la
RUN cat package.json
CMD ["node", "index.js"]

