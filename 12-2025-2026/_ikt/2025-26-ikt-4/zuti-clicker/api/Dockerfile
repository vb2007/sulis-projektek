# ---- dependencies ----
FROM node:22-alpine AS deps
WORKDIR /app
RUN corepack enable
COPY package.json pnpm-lock.yaml ./
RUN pnpm install --frozen-lockfile

FROM node:22-alpine AS runner
WORKDIR /app
RUN corepack enable

COPY package.json tsconfig.json prisma.config.ts ./
COPY prisma/  ./prisma/
COPY src/     ./src/
COPY --from=deps /app/node_modules ./node_modules

ARG DATABASE_URL=mysql://build:build@build:3306/build
ARG SHADOW_DATABASE_URL=mysql://build:build@build:3306/buildShadow
ENV DATABASE_URL=$DATABASE_URL
ENV SHADOW_DATABASE_URL=$SHADOW_DATABASE_URL
RUN node_modules/.bin/prisma generate

ENV NODE_ENV=production

EXPOSE 2710

HEALTHCHECK --interval=15s --timeout=5s --start-period=20s --retries=3 \
    CMD wget -qO- http://localhost:2710/docs > /dev/null || exit 1

CMD ["node_modules/.bin/tsx", "src/index.ts"]
