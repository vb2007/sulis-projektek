Telepített imagek között a node (alap) keresése:

```shell
docker images | grep node
```

```shell
cypress/included:cypress-15.19.0-node-24.18.0-chrome-150.0.7871.128-1-ff-153.0-edge-150.0.4078.83-1   fe59f2cac5c7        4.7GB         1.24GB        
node:24.0.1-bookworm-slim                                                                             f403f3b5054f        333MB         83.5MB        
node:24.18-alpine3.24                                                                                 a0b9bf06e4e6        231MB           58MB        
node:26.4.0-trixie-slim                                                                               a1d9d671994f        351MB         86.8MB        
selenium/node-chrome:150.0.7871.124-chromedriver-150.0.7871.124                                       4a4689d68468       3.18GB          983MB        
selenium/node-firefox:152.0-geckodriver-0.37-grid-4.46.0-20260707                                     a2f437961ca7       3.06GB          943MB
```

Buldelés és indítás "just"-al:

```shell
just build

just run
```

Indítás után a containerben:

```shell
pnpm create vite@latest
```

Projekt (és mappa) neve: `demo`

```shell
cd demo
```

Indítás:

```shell
pnpm run dev --host
```

Buildelés, hogy később fel lehessen használni:

```shell
pnpm run build
```