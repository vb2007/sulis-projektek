FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "kerekites.php" ]

# sudo docker build -t vb/kerekites . -f kerekites.dockerfile
# sudo docker run -it --rm -v $(pwd):/app vb/kerekites 11.1 bankar
