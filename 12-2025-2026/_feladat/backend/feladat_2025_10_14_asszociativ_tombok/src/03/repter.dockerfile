FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "repter.php" ]
