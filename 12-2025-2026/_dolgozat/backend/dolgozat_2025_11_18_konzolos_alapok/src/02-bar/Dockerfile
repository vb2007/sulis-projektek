FROM php:8.4-cli-alpine3.21

WORKDIR /app

RUN apk update && apk add --no-cache bash

COPY . /app

ENTRYPOINT ["php", "bar.php"]

# docker build -t vb/bar .
# docker run -it --rm -v $(pwd):/app vb/bar
# docker run -it --rm -v $(pwd):/app vb/bar param1
