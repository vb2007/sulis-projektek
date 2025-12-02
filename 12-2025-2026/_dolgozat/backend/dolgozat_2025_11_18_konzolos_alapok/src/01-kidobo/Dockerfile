FROM php:8.4-cli-alpine3.21

WORKDIR /app

RUN apk update && apk add --no-cache bash

COPY . /app

ENTRYPOINT ["php", "game.php"]

# docker build -t vb/dodgeball .
# docker run -it --rm -v $(pwd):/app vb/dodgeball
# docker run -it --rm -v $(pwd):/app vb/dodgeball param1
