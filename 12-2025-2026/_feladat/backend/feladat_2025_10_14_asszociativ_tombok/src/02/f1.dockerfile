FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "f1.php" ]
