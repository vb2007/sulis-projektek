FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "test.php" ]
