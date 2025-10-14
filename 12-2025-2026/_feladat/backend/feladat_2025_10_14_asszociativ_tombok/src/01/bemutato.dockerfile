FROM vb/php

COPY . /app

ENTRYPOINT [ "php", "bemutatkozo.php" ]
