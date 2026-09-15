# MySQL használata Dockerben

## Container indítása

MySQL verzió lekérése:

```shell
docker images | grep "mysql"
```

MySQL container elindítása:

```shell
docker run --name mici -e MYSQL_ROOT_PASSWORD=maci -d -v "$(pwd)/sql:/sql" mysql:9.7.1
```

Belépés a containerbe:

```shell
docker exec -it mici bash
```

MySQL shellbe lépés:

```shell
mysql -u root -p maci
```

## Shellen belüli commandok

Adatbázisok listázása:

```sql
show daabases;
```

Adatbázis kiválasztása:

```sql
use db;
```

Táblák listázása:

```sql
show tables;
```

Commandok futtatása:

```sql
source /sql/abc.sql;
```