FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "aliens.php" ]

# docker build -t vb/aliens . -f aliens.dockerfile
# docker run -it --rm -v $(pwd):/app vb/aliens 44
