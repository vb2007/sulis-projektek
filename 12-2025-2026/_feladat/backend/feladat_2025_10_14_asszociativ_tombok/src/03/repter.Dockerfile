FROM vb/repter

COPY . /app

ENTRYPOINT [ "php", "repter.php" ]
