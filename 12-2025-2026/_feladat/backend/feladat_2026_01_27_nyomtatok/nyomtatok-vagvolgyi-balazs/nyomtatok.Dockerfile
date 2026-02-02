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

ENTRYPOINT [ "php", "nyomtatok.php" ]

# csatolt volume-ra íráshoz szükséges jogosultságbeállítás (linuxon):
# mkdir -p out
# sudo chmod 777 out

# docker build -t vb/nyomtatok . -f nyomtatok.Dockerfile
# docker run --rm -v $(pwd):/app -v $(pwd)/out:/app/out vb/nyomtatok
