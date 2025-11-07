FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "pindur.php" ]

# sudo docker build -t vb/pindur . -f pindur.dockerfile
# sudo docker run -it --rm -v $(pwd):/app vb/pindur
