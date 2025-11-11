FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "f1.php" ]

# docker build -t vb/f1 . -f f1.dockerfile
# docker run -it --rm -v $(pwd):/app vb/f1 44
