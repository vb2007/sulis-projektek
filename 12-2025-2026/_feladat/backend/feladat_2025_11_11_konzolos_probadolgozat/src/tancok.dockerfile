FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "tanc.php" ]

# docker build -t vb/tancok . -f tancok.dockerfile
# docker run -it --rm -v $(pwd):/app vb/tancok letszam
