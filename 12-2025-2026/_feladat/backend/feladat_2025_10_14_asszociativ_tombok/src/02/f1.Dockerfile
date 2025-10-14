FROM vb/f1

COPY . /app

ENTRYPOINT [ "php", "f1.php" ]
