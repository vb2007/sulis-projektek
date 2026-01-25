# Állatmenhely Kezelőfelület - Fejlesztői Dokumentáció

## Technológiai Stack

- **Framework**: ASP.NET Core 9.0 (Razor Pages)
- **ORM**: Entity Framework Core
- **Adatbázis**: SQL Server
- **Frontend**: Bootstrap 5
- **Autentikáció**: Session-alapú (custom)

## Projekt Struktúra

- **Data/**: EF Core DbContext
- **Models/**: Animal, User, Appointment, AnimalsBreed, AnimalsSpecy
- **Pages/**: Razor Pages (Animals, Appointments, Breeds, Species, Auth)
- **Services/**: AuthService, PasswordHasher (BCrypt)

## Adatbázis Modellek

### User

- Guid azonosító, session-alapú auth
- IsAdmin flag jogosultság kezeléshez

### Animal

- int azonosító, Species és Breed kapcsolatok (1:N)
- CreatedBy/ModifiedBy audit mezők

### Appointment

- Guid azonosító
- ReservedBy (User) és ReservedTo (Animal)
- AppointmentAt datetime

## Autentikáció

### AuthService Módszerek

- `RegisterUserAsync()`: Regisztráció
- `LoginAsync()`: Bejelentkezés
- `GetCurrentUserId()`: Aktuális user
- `IsCurrentUserAdmin()`: Admin check

### Session Kulcsok

UserId, Username, IsAdmin

## Razor Pages Konvenciók

- `OnGetAsync()`: Adatok betöltése
- `OnPostAsync()`: Form feldolgozás
- `OnPost[Handler]Async()`: Named handlers (Delete, Update)

## Időpont Kezelés

- 7 napos nézet, 24 órás slotok
- AppointmentSlot viewmodel: DateTime, IsBooked, IsAvailable
- Navigation query paraméterekkel (?date=2026-01-21)
- Admin: felhasználók szerinti csoportosítás, bulk delete

## UI/UX

- Bootstrap Cards, Modals, Alerts, Tables
- TempData Success/Error üzenetek
- Modal confirmations minden törléshez

## Futtatás

```bash
dotnet restore
dotnet ef database update
dotnet run
```

Connection string: `appsettings.json`
