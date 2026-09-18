# jsonserver-2627

Dart/shelf alapú JSON szerver.

## Build

```sh
docker build -t idomi27/jsonserver:2627 .
```

## Futtatás

```sh
docker run -d --rm -p 8888:3000 -v $(pwd)/data:/data idomi27/jsonserver:2627
```

## Konfiguráció

A `data/` mappa tartalmazza:

- `db.json` — adatbázis (resource kollekciók)
- `config.json` — beállítások
- `routes.json` — útvonal prefix szabályok (pl. `/api/*` → `/$1`)

### config.json opciók

```json
{
  "timestamps": false,
  "wrapper": true,
  "wrapperKey": "data",
  "relationships": []
}
```

| Mező            | Leírás                                            | Default  |
| --------------- | ------------------------------------------------- | -------- |
| `timestamps`    | `created_at` / `updated_at` automatikus kitöltése | `false`  |
| `wrapper`       | Válasz `{ "data": ... }` burkolóba csomagolva     | `true`   |
| `wrapperKey`    | A burkoló kulcsneve                               | `"data"` |
| `relationships` | `hasMany` / `belongsTo` kapcsolatok               | `[]`     |

## Webes felület

`http://jsonserver.vm1.test:8888` — böngészőben listázza az elérhető resource-okat és azok tartalmát.
