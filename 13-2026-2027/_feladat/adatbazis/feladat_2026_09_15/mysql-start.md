MySQL verzió lekérése:

docker images | grep "mysql"

MySQL container elindítása:

docker run --name mici -e MYSQL_ROOT_PASSWORD=maci -d -v "$(pwd)/sql:/sql" mysql:9.7.1

Belépés a containerbe:

docker exec -it mici bash

MySQL shellbe lépés:

mysql -u root -p maci