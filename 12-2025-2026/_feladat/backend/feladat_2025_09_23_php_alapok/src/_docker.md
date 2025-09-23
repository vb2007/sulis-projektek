# A PHP scriptek futtatása Docker konténerben

1. Konténer buildelése

```bash
docker build -t vb/php .
```

2. Konténer futtatása

```bash
docker run -it --rm -v $(pwd):/APP vb/php
```

3. PHP script futtatása a konténeren belül

```bash
php 01.php "opcionális" "paraméterek"
```
