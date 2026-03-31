FROM php:8.4.8-fpm-alpine3.22

RUN apk update && apk add --no-cache \
    libpng-dev \
    libjpeg-turbo-dev \
    zip \
    libzip-dev \
    jpegoptim optipng pngquant gifsicle \
    unzip \
    curl \
    oniguruma-dev \
    libxml2-dev \
    vim \
    fish

RUN adduser -u 1000 -s /bin/fish -D phpdocker

WORKDIR /www

COPY --from=composer:2.8.9 /usr/bin/composer /usr/bin/composer

RUN docker-php-ext-configure gd --with-jpeg

RUN docker-php-ext-install  pdo \
                            pdo_mysql \
                            zip \
                            exif \
                            pcntl \
                            gd

RUN

RUN mkdir -p /home/phpdocker/.composer/cache/ && chown -R phpdocker:phpdocker /home/phpdocker/.composer/cache/ && \
  curl -L --create-dirs -o ~/.config/fish/completions/artisan.fish https://github.com/adriaanzon/fish-artisan-completion/raw/master/completions/artisan.fish && \
  curl -L --create-dirs -o ~/.config/fish/completions/php.fish https://github.com/adriaanzon/fish-artisan-completion/raw/master/completions/php.fish && \
  curl -L --create-dirs -o ~/.config/fish/functions/artisan.fish https://github.com/adriaanzon/fish-artisan-completion/raw/master/functions/artisan.fish && \
  mkdir -p /home/phpdocker/.config/fish/functions/ && chown -R phpdocker /home/phpdocker/.config && printf 'function fish_prompt  \n\
  set -l last_status $status  \n\
    set -l stat  \n\
    if test $last_status -ne 0  \n\
        set stat (set_color red)" [$last_status]"(set_color normal)  \n\
    end  \n\
    string join "" -- (set_color 62A) "[backend] " $PWD (set_color normal) $stat " >"  \n\
end' > /home/phpdocker/.config/fish/functions/fish_prompt.fish
USER phpdocker


CMD ["php-fpm"]