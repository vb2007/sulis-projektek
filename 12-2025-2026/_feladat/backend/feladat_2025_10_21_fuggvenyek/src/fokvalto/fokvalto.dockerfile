FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "fokvalto.php" ]
