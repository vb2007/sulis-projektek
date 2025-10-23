FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "fokvalto.php" ]

# sudo docker build -t vb/fokvalto . -f fokvalto.dockerfile
# sudo docker run -it --rm -v $(pwd):/app vb/fokvalto 25 f
