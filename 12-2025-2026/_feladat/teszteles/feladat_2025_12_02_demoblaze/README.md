# DemoBlaze Unit Tesztek

## Teszt report generálás

A projekt automatikusan generál teszt reportokat futtatás után az **EPPlus** NuGet package segítségével.

Ezek a `DemoBlaze/bin/Debug/net9.0/TestReports/` mappában találhatók futtatás után.

### Infó magamnak későbbre

Következő projekteknél is specifikusan a `7.5.2`.-es verzió szükséges. Újabb verziókban valamiért mindenféle fölösleges licensing konfiguráció szükséges, azt meg nem akarom.

Telepítés terminálból:

```shell
dotnet add package EPPlus --version 7.5.2
```

## További package-ek

A web element láthatósági waiterhez szükséges még egy helper NuGet package telepítése:

```shell
dotnet add package DotNetSeleniumExtras.WaitHelpers
```
