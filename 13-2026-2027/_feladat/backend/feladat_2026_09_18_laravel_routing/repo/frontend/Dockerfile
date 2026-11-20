FROM node:24-alpine3.24

ENV PNPM_STORE_DIR=/home/node/.pnpm-store

RUN corepack enable pnpm
RUN apk add --no-cache fish

RUN mkdir -p /app && chown -R node:node /app
RUN mkdir -p /home/node/.pnpm-store && chown -R node:node /home/node/.pnpm-store

WORKDIR /app

USER node

RUN mkdir -p /home/node/.config/fish/functions/ &&  printf 'function fish_prompt  \n\
  set -l last_status $status  \n\
    set -l stat  \n\
    if test $last_status -ne 0  \n\
        set stat (set_color red)" [$last_status]"(set_color normal)  \n\
    end  \n\
    string join "" -- (set_color green) "[frontend] " $PWD (set_color normal) $stat " >"  \n\
end' > /home/node/.config/fish/functions/fish_prompt.fish 

RUN pnpm config set store-dir $PNPM_STORE_DIR
RUN pnpm config set trust-lockfile true

ENTRYPOINT ["fish"]