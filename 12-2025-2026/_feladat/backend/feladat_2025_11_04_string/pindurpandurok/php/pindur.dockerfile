FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "pindur.php" ]

# docker build -t vb/pindur . -f pindur.dockerfile
# docker run -it --rm -v $(pwd):/app vb/pindur "Sziporka;Puszedli;Csuporka"
