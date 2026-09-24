# NWSDB Service-Oriented Water Billing System

A student prototype for **CSE5013 Service Oriented Computing**, based on a case study of the
National Water Supply and Drainage Board (NWSDB), Sri Lanka. It is not affiliated with the
real NWSDB, and all data is fictional.

The system has two parts:

- **NWSDB.Server**: an ASP.NET Core Web API (.NET 8) that holds all business logic and data access.
- **NWSDB.Client**: a Windows Forms app for customers and NWSDB admins. It talks to the
  server **only through REST/JSON** and never touches the database directly.

```
WinForms Client (NWSDB.Client)          Third-party partners
        |                                       |
        |  REST / JSON (HttpClient)             |  REST / JSON + X-Api-Key
        v                                       v
          ASP.NET Core Web API (NWSDB.Server)
                      |
                      v
            Entity Framework Core
                      |
                      v
          SQL Server (LocalDB by default)
```

## Contents

- [Prerequisites](#prerequisites)
- [Quick start (Visual Studio)](#quick-start-visual-studio)
- [Running from the command line](#running-from-the-command-line)
- [Demo accounts](#demo-accounts)
- [Using the client](#using-the-client)
- [API reference](#api-reference)
- [Configuration](#configuration)
- [Database setup](#database-setup)
- [Project structure](#project-structure)
- [Troubleshooting](#troubleshooting)
- [Prototype limitations](#prototype-limitations)

## Prerequisites

| Requirement | Notes |
|---|---|
| Windows 10/11 | Needed for the WinForms client. The server also runs on Linux/macOS (see [Database setup](#database-setup)). |
| Visual Studio 2022 **17.13 or later** | Needed to open the `.slnx` solution file. Install the **ASP.NET and web development**, **.NET desktop development** and **Data storage and processing** workloads. |
| .NET 8 SDK | Included with the Visual Studio workloads above. |
| SQL Server Express **LocalDB** | Included with the Data storage and processing workload. Check with `sqllocaldb info`, which should list `MSSQLLocalDB`. |

## Quick start (Visual Studio)

1. **Clone the repository**
   ```
   git clone https://github.com/sashiiimp/NWSDB-Service-Oriented-System.git
   ```
2. **Open** `NWSDB.ServiceOrientedSystem.slnx` in Visual Studio. NuGet packages restore automatically.
3. **Start both projects together.**
   - Right-click the solution, then choose **Configure Startup Projects…** → **Multiple startup projects**.
   - Set **NWSDB.Server** to *Start*, then **NWSDB.Client** to *Start*, with the server first in the list.
   - Make sure NWSDB.Server uses the **`http`** launch profile. It is the default and runs on `http://localhost:5074`, which is the address the client calls.
4. **Press F5.**
   - The server creates the `NwsdbWaterBillingDb` database in LocalDB on first run and adds the demo data. No manual SQL or migrations are needed.
   - Swagger opens at <http://localhost:5074/swagger>.
   - The client opens on the customer login screen.

## Running from the command line

From the repository root:

```bash
# Server (any OS). Swagger: http://localhost:5074/swagger
dotnet run --project NWSDB.Server.csproj --launch-profile http

# Client (Windows only), in a second terminal
dotnet run --project NWSDB.Client/NWSDB.Client.csproj
```

To build the whole solution with `dotnet build NWSDB.ServiceOrientedSystem.slnx`, you need the
.NET SDK **9.0.200 or later**, because older SDKs can't read `.slnx` files. Both projects still
target .NET 8. With an older SDK, build each project separately:

```bash
dotnet build NWSDB.Server.csproj
dotnet build NWSDB.Client/NWSDB.Client.csproj
```

## Demo accounts

These are created automatically the first time the server runs.

**Customers.** The client logs customers in by account number only, because the prototype
has no customer passwords.

| Account number | Name | Water connections |
|---|---|---|
| `NW-100001` | Kasun Perera | CONN-1001 |
| `NW-100002` | Nadeesha Silva | CONN-1002 (bill partially paid) |
| `NW-100003` | Ruwan Fernando | CONN-1003 (bill overdue), CONN-1004 |

**NWSDB admin**

| Username | Password |
|---|---|
| `admin` | `Admin@123` |

**Third-party partners** (send as the `X-Api-Key` header)

| API key | Status |
|---|---|
| `demo-partner-key-12345` | Active |
| `demo-suspended-key-99999` | Suspended, so requests are rejected with 401 |

## Using the client

**Customer:** enter an account number such as `NW-100001` on the login screen. From the dashboard you can:

- **Current Usage / Usage History:** view meter readings.
- **Current Bill / Bill History:** view bills, amounts paid, outstanding amounts and status.
- **Make Payment:** choose an unpaid bill, an amount and a payment method.
  The server validates the payment (for example, you can't pay more than the outstanding
  amount), and a receipt appears when it succeeds.
- **Payment History:** view past payments. Select one and click **View Receipt**.

**Admin:** click **"NWSDB staff? Sign in to the Admin Console"** on the login screen and sign in as `admin`. You can then:

- **Record Meter Reading** for the selected connection. The previous reading is taken from
  the latest one on record, and units consumed are calculated by the server.
- **Generate Bill (Latest Reading)** for the selected connection, at Rs. 100 per unit,
  due 15 days after the bill is issued.
- **View Customers** to see every customer and their connections.

A typical end-to-end demo: as admin, record a reading and generate its bill. Log out, log in
as that customer, find the new bill, and pay it.

## API reference

Interactive documentation is available in Swagger at <http://localhost:5074/swagger>.
Errors are returned as JSON in the form `{ "status": 404, "error": "..." }`.

### Customer endpoints (no authentication)

| Method | Route | Description |
|---|---|---|
| GET | `/api/customers/{id}` | Customer by ID |
| GET | `/api/customers/account/{accountNumber}` | Customer by account number (used by the client login) |
| GET | `/api/connections/customer/{customerId}` | A customer's water connections |
| GET | `/api/usage/{customerId}/current` | Latest meter reading for each connection |
| GET | `/api/usage/{customerId}/history` | All meter readings |
| GET | `/api/bills/{customerId}/current` | Latest unpaid bill, or the latest bill if all are paid |
| GET | `/api/bills/{customerId}/history` | All bills |
| GET | `/api/bills/details/{billId}` | A single bill |
| POST | `/api/payments` | Pay a bill: returns 201, or 400 / 404 / 409 |
| GET | `/api/payments/{customerId}/history` | Payment history |
| GET | `/api/payments/{paymentId}/receipt` | Receipt for a payment |

Example payment request body:

```json
{ "billId": 2, "customerId": 1, "amountPaid": 6000, "paymentMethod": "Card" }
```

Payment methods: `Cash`, `Card`, `BankTransfer`, `OnlineBanking`, `Cheque`.

### Admin endpoints (JWT bearer token)

To authorise in Swagger:

1. Call `POST /api/admin/login`.
2. Click **Authorize**.
3. Paste the returned `token` into the **Bearer** field.

| Method | Route | Description |
|---|---|---|
| POST | `/api/admin/login` | `{ "username", "password" }`: returns a JWT (valid 60 minutes), or 401 |
| GET | `/api/admin/customers` | All customers with their connections |
| GET | `/api/admin/connections` | All connections, each with its latest meter reading |
| POST | `/api/admin/meter-readings` | Record a meter reading: returns 201, or 400 / 404 / 409 |
| POST | `/api/admin/bills` | Generate a bill from a meter reading: returns 201, or 400 / 404 / 409 |

Example requests:

```json
POST /api/admin/meter-readings
{ "connectionId": 1, "readingDate": "2026-09-24", "currentReading": 1268.5 }

POST /api/admin/bills
{ "readingId": 15 }
```

Rules the server enforces:

- **Meter readings**
  - The previous reading is the connection's latest reading. You can only supply
    `previousReading` for a connection's very first reading.
  - The current reading can't be lower than the previous reading (400) or negative (400).
  - The reading date can't be in the future (400) or before the latest reading date (400).
    A second reading on the same day as the latest one returns 409.
  - Readings can't be recorded for a connection that isn't Active (400).
- **Bills**
  - The billing period runs from the day after the previous reading up to the reading date.
  - A reading with zero consumption can't be billed (400).
  - A period that has already been billed, fully or partly, can't be billed again (409).

### Partner endpoints (`X-Api-Key` header)

| Method | Route | Description |
|---|---|---|
| GET | `/api/partner/bills/{billId}` | Check a bill before paying |
| POST | `/api/partner/payments` | Submit a payment on a customer's behalf. It is recorded with source `ThirdPartyPartner`. |

## Configuration

| Setting | Location | Default |
|---|---|---|
| Database provider | `appsettings.json` → `Database:Provider` | `SqlServer` (or `Sqlite`) |
| SQL Server connection | `appsettings.json` → `ConnectionStrings:SqlServerConnection` | `(localdb)\mssqllocaldb`, database `NwsdbWaterBillingDb` |
| SQLite connection | `appsettings.json` → `ConnectionStrings:SqliteConnection` | `Data Source=nwsdb.db` |
| JWT settings | `appsettings.json` → `Jwt` | issuer, audience, signing key, 60-minute expiry |
| Server URL | `Properties/launchSettings.json` | `http://localhost:5074` (`http` profile) |
| Client's server URL | `NWSDB.Client/Services/ApiSettings.cs` → `BaseUrl` | `http://localhost:5074/` |

If you change the server's port, update `ApiSettings.BaseUrl` to match.

Any setting can be overridden with an environment variable, using `__` in place of `:`.
For example: `Database__Provider=Sqlite`.

## Database setup

The server calls `EnsureCreated()` at startup. This creates the database and tables if
they don't exist, then adds the demo data if the `Customers` table is empty. Existing data is
never changed or removed.

**Using SQLite instead (for Linux/macOS, or without LocalDB).** Set the provider to `Sqlite`
in `appsettings.json` or with an environment variable. A `nwsdb.db` file is created next to the
server; it is ignored by git.

```bash
Database__Provider=Sqlite dotnet run --project NWSDB.Server.csproj --launch-profile http
```

**Starting again with fresh demo data.** This permanently deletes all data in the database.
- SQL Server: delete the `NwsdbWaterBillingDb` database, for example in Visual Studio →
  *SQL Server Object Explorer* → `(localdb)\MSSQLLocalDB` → Databases → right-click → Delete.
  Then restart the server.
- SQLite: delete `nwsdb.db` and restart the server.

**Switching to EF Core migrations.** `EnsureCreated()` is used because the prototype can run
on either provider. Once SQL Server is the only target, migrations are the better choice, as
they let the schema change without recreating the database:

1. Install the EF tool: `dotnet tool install --global dotnet-ef`
2. Delete the existing database, since `EnsureCreated()` databases have no migration history.
3. Create the first migration: `dotnet ef migrations add InitialCreate --project NWSDB.Server.csproj`
4. In `Program.cs`, replace `db.Database.EnsureCreated();` with `db.Database.Migrate();`

## Project structure

```
NWSDB.ServiceOrientedSystem.slnx   Solution (both projects)
NWSDB.Server.csproj                Web API project (at the repository root)
├── Controllers/                   REST endpoints: Customers, Connections, Usage, Bills,
│                                  Payments, Partner, Admin
├── Services/                      Business logic behind interfaces (Services/Interfaces)
├── DTOs/                          Request/response contracts
├── Models/                        EF Core entities
├── Data/                          NwsdbDbContext and SeedData
├── Middleware/                    Error handling and partner API-key checking
├── Swagger/                       Swagger filter for the admin Bearer padlock
└── Properties/launchSettings.json Development URLs
NWSDB.Client/                      Windows Forms client
├── *Form.cs / *.Designer.cs       Customer and admin screens
├── Services/                      ApiService (HttpClient), ApiSettings, ApiException
├── Models/                        Client-side DTOs (no reference to the server project)
└── Helpers/UiHelper.cs            Shared formatting and styling
```

## Troubleshooting

| Problem | Fix |
|---|---|
| Client says **"Unable to connect to the NWSDB service"** | Start NWSDB.Server first, and check that it is listening on `http://localhost:5074` (see `ApiSettings.BaseUrl`). |
| Visual Studio can't open the `.slnx` file | Update to Visual Studio 2022 17.13 or later. |
| Server fails at startup with a SQL / LocalDB error | Check that LocalDB is installed (`sqllocaldb info`), start it with `sqllocaldb start MSSQLLocalDB`, or use SQLite (see [Database setup](#database-setup)). |
| Server started with the `https` profile and the client fails | Trust the development certificate with `dotnet dev-certs https --trust`, or use the `http` profile. |
| Admin screens say **"session expired"** | Tokens last 60 minutes. Log in again. |

## Prototype limitations

These are deliberate simplifications for a student project:

- Customers log in with their account number only; there is no customer password system.
- The JWT signing key is stored in `appsettings.json`. A real system would keep it in user
  secrets or a key vault.
- Partner API keys are stored as plain text. A real system would store hashes and
  rotate the keys.
- The tariff is a flat Rs. 100 per unit.
- The database is created with `EnsureCreated()` rather than migrations (see above).
