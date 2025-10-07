# A PHP scriptek futtatása Docker konténerben

0. Belépés a releváns mappába (ahol a `Dockerfile` is található) *(példa)*

```bash
cd /home/vb2007/code/sulis-projektek/12-2025-2026/_feladat/backend/feladat_2025_09_23_php_alapok/src
```

1. Konténer buildelése

```bash
docker build -t vb/php .
```

2. Konténer futtatása

```bash
docker run -it --rm -v $(pwd):/app vb/php
```

3. PHP script futtatása a konténeren belül

```bash
php 01.php "opcionális" "paraméterek"
```
