FROM php:8.4.8-cli-alpine3.22
RUN adduser -D -u 1000 -s /bin/bash phpdocker
WORKDIR /app
RUN apk update && apk add --no-cache bash
USER phpdocker
ENTRYPOINT ["/bin/bash"]
