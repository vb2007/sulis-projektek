# Konténerizáció

> [!WARN]
> A feladatok buildeléséhez, futtatásához szükséges az év elején buildelt `monogram/php` image!

## Parancsok a futtatáshoz (példák)

1. Megfelelő mappa kiválasztása:

```shell
cd /home/vb2007/code/sulis-projektek/12-2025-2026/_feladat/backend/feladat_2025_10_14_asszociativ_tombok/src/01
```

2. Konténer buildelése:

```shell
docker build -t monogram/feladatnev . -f feladatnev.dockerfile
```

3. Futtatás konténerben:

```shell
docker run -it --rm -v $(pwd):/app monogram/feladatnev opcionalis parameterek szokozokkel
```
