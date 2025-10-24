FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "fogyasztas.php" ]

# sudo docker build -t vb/fogyasztas . -f fogyasztas.dockerfile
# sudo docker run -it --rm -v $(pwd):/app vb/fogyasztas 118342 118962 42.4
