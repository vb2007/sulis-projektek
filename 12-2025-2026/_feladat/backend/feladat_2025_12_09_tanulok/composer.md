# Composer használata

## Használandó parancsok

Új package létrehozása:

```shell
composer init
```

Csomagok telepítése futtatás előtt (meglévő `composer.lock` fájloknál):

```shell
composer install
```

Csomag(ok) hozzáadása:

```shell
composer require fakerphp/faker
```

Autoload fájlok generálása:

```shell
composer dump-autoload
```
