# MySQL használata Dockerben

## Container indítása

MySQL verzió lekérése:

```shell
docker images | grep "mysql"
```

MySQL container elindítása:

```shell
docker run --name nigga -e MYSQL_ROOT_PASSWORD=nigger -d -v "$(pwd)/sql:/sql" mysql:9.7.1
```

Belépés a containerbe:

```shell
docker exec -it nigga bash
```

MySQL shellbe lépés:

```shell
mysql -u root -p
```

## Shellen belüli commandok

Adatbázisok listázása:

```sql
show databases;
```

Adatbázis kiválasztása:

```sql
use dbNeve;
```

Táblák listázása:

```sql
show tables;
```

Commandok futtatása:

```sql
source /sql/abc.sql;
```