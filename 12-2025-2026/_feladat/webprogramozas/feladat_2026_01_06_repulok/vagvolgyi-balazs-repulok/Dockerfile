FROM node:24-alpine

WORKDIR /app

RUN apk update && apk add --no-cache bash && npm install -g pnpm

RUN echo '#!/bin/bash' > /startup.sh && \
    echo 'chown -R node:node /app' >> /startup.sh && \
    echo 'exec su node "$@"' >> /startup.sh && \
    chmod +x /startup.sh

ENTRYPOINT ["/startup.sh", "/bin/bash"]
