FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "idezetek.php" ]

# docker build -t vb/idezetek . -f idezetek.Dockerfile
# docker run -it --rm -v $(pwd):/app vb/idezetek
