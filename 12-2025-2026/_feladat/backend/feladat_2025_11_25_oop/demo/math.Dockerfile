FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "console.php" ]

# docker build -t vb/math . -f math.Dockerfile
# docker run -it --rm -v $(pwd):/app vb/math letszam
