#FROM php:8.3-cli-alpine
FROM vb/php

ENV TZ=Europe/Budapest

WORKDIR /app

RUN adduser -D -u 1000 -s /bin/bash phpdocker \
    && apk update \
    && apk add --no-cache \
    bash \
    libzip-dev \
    zip \
    p7zip \
    tzdata \
    && docker-php-ext-install zip

COPY --from=composer:2.8.9  /usr/bin/composer /usr/bin/composer

COPY . /app

RUN composer install --no-dev --optimize-autoloader

USER phpdocker

ENTRYPOINT [ "php", "demo.php" ]

# composer dump-autoload
# docker build -t vb/nyilvantartas . -f nyilvantartas.Dockerfile
# docker run --rm -v $(pwd):/app vb/nyilvantartas
