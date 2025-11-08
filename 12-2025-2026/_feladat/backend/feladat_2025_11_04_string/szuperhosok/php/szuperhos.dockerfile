FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "szuperhos.php" ]

# docker build -t vb/szuperhos . -f szuperhos.dockerfile
# docker run -it --rm -v $(pwd):/app vb/szuperhos
