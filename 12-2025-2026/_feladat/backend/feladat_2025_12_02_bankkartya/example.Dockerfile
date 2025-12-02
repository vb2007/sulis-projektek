FROM php:8.4-cli-alpine3.22

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

USER phpdocker

ENTRYPOINT [ "/bin/bash" ]
