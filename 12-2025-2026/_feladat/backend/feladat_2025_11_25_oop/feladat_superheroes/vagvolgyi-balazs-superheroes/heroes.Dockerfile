FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "heroes.php" ]

# docker build -t vb/heroes . -f heroes.Dockerfile
# docker run -it --rm -v $(pwd):/app vb/heroes
