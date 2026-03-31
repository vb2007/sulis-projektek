# Refaktorálásaim:

- Mivel a hibaüzenet mindegyik teszt case-nél ugyan az, készítettem egy `ErrorMessage()` helpert a kódismétlés elkerülése érdekében.
- A fő `IsLeapYear()` function-ben újraformáztam az `if` feltételek után visszaadott `true` / `false` értékek elhelyezését a könnyebb olvashatóság érdekében.
- **Nem refactor, de a munka fő feladat elvégzése után készítettem:**
  - Egy demo console app projekt, hogy manuálisan is le tudjam tesztelni a programot.
