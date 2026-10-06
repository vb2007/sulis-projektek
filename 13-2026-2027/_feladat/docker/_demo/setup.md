# Fullstack 2026-67 használat

## Direkt Just / Docker commandok

Repo init:

```shell
just init
```

Csak backend / api indítása:

```shell
just backend
```

Ha behal migration miatt:

```shell
just backend --seed
```

## Backend kezelés

Backend container shellbe belépés

```shell
docker compose exec backend fish
```

Artisan help:

```shell
php artisan
```

Laravel API projekt init:

```shell
php artisan install:api
```

Elérhető: [URL](https://backend.localhost/api)

Új controller létrhozása (ha nem adunk meg nevet visszakérdez):

```shell
artisan make:controller CarController
```