# Barangay Assistance API

An ASP.NET Core backend for managing barangay complaints, assistance requests, and staff accounts. Residents can submit requests, while authenticated users can view records, update their status, and manage accounts.

## Features

- JWT login for staff accounts.
- Public submission of complaints and assistance requests.
- Separate lists for complaints and assistance, with pending, ongoing, and completed statuses.
- User creation, account listing, and account deactivation.
- Role, gender, and purpose-status lookup endpoints.
- Image uploads for supporting documents and profile photos.
- SQL Server persistence through Entity Framework Core.
- Swagger/OpenAPI documentation.

An SMTP mail service is included, but email sending during request submission is currently commented out.

## Technology

| Area | Technology |
| --- | --- |
| API | C#, ASP.NET Core 5 |
| Database | SQL Server, Entity Framework Core 5.0.0 |
| Authentication | JWT bearer tokens |
| Mapping | AutoMapper 8 |
| API documentation | Swashbuckle 5.6.3 |
| Email service | MailKit / MimeKit |
| Image processing | System.Drawing.Common 6.0.0 |

## Project structure

```text
barangay-assistance-API/
├── barangay-assistance-api/   # Controllers, startup, configuration, and mapping
├── Base.Services/            # Account/request services, DTOs, mail, and upload helpers
├── Base.EFCore/              # Generic repository and unit-of-work implementations
├── Base.Entities/            # Entity models, database context, and migrations
└── barangay-assistance-api.sln
```

Project references follow `API → Base.Services → Base.EFCore → Base.Entities`. Controllers call services, which use repositories and a unit of work for database operations.

## Local setup

The commands below use **Windows PowerShell**. Windows is the simplest environment for this codebase: its logger uses Windows paths, and image processing uses [System.Drawing.Common 6](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only).

### 1. Prerequisites

- Git.
- .NET 5 SDK/runtime for the application, which targets `net5.0`.
- .NET 6 SDK/runtime for the checked-in `dotnet-ef` 6.0.3 tool.
- A running SQL Server instance and an account allowed to create or update a development database.

The application packages use EF Core 5.0.0, while the existing local tool manifest pins the CLI to 6.0.3. The commands below restore that manifest without changing project dependencies.

### 2. Clone and build

```powershell
git clone https://github.com/jmgabriel13/barangay-assistance-API.git
cd barangay-assistance-API
dotnet restore barangay-assistance-api.sln
dotnet build barangay-assistance-api.sln --no-restore
cd barangay-assistance-api
```

**Run the remaining setup commands from the API project directory**, which contains `Startup.cs` and `appsettings.json`.

### 3. Configure the database and JWT key

Override the checked-in settings for your environment. For SQL Server Express with Windows authentication:

```powershell
$env:ConnectionStrings__DefaultConnection = 'Server=localhost\SQLEXPRESS;Database=barangay_assistance_dev;Integrated Security=True;TrustServerCertificate=True'

$jwtBytes = New-Object byte[] 32
$jwtRng = [System.Security.Cryptography.RandomNumberGenerator]::Create()
$jwtRng.GetBytes($jwtBytes)
$jwtRng.Dispose()
$env:JWT__Key = [Convert]::ToBase64String($jwtBytes)
```

Replace the server name with your SQL Server instance. Keep this terminal open for migrations and startup so the environment variables remain available. The certificate setting above is for local development. Generating a different JWT key invalidates tokens signed with the previous key.

| Configuration | Purpose |
| --- | --- |
| `ConnectionStrings__DefaultConnection` | SQL Server connection string |
| `JWT__Key` | JWT signing and validation key |
| `JWT__Issuer`, `JWT__Audience` | Settings read by startup; issuer and audience validation are currently disabled |
| `MailSettings__Mail`, `MailSettings__Password` | SMTP credentials |
| `MailSettings__Host`, `MailSettings__Port` | SMTP server |
| `MailSettings__DisplayName` | Bound mail setting; currently unused by the sender |

SMTP settings are unnecessary for the current submission flow because its send call is disabled. Keep local credentials out of committed files.

### 4. Create resource directories

```powershell
New-Item -ItemType Directory -Force -Path 'Resources\Images\profile', 'Resources\Images\proof', 'Resources\Images\verification', 'wwwroot' | Out-Null
```

Startup requires the `Resources` directory to exist. The upload helper also expects its destination folder to exist; it does not create folders automatically. The `proof` and `verification` folders above are conventions for the examples below.

### 5. Apply migrations

```powershell
dotnet tool restore
dotnet ef database update --project ../Base.Entities/Base.Entities.csproj --startup-project ./barangay-assistance-api.csproj
```

The tool manifest is in this project's `.config` folder. Migrations live in `Base.Entities`; the API supplies the startup configuration. Migrations are not applied automatically on application startup.

### 6. Prepare development data

The migrations include a seeded `admin` account with an encrypted password, but no documented plaintext login credential or public registration endpoint. Obtain the development credential from the maintainer, or provision a local account using the application's existing password-encryption format.

The repository does **not** seed the lookup rows. Populate the following tables in your development database before testing complete workflows:

| Table | Required relationship or values |
| --- | --- |
| `tbl_role` | IDs matching users' `Position` values |
| `tbl_gender` | IDs matching users' `Gender` values |
| `tbl_marital_status` | Marital-status lookup values for user records |
| `tbl_purposeStatus` | `1 = Pending`, `2 = Ongoing`, `3 = Completed` |

User listings join against roles and genders, and request listings join against purpose statuses. Missing lookup rows can therefore make existing records disappear from list responses.

### 7. Start the API

```powershell
dotnet dev-certs https --trust
dotnet run --launch-profile barangay_assistance_api
```

| Resource | URL |
| --- | --- |
| HTTPS base URL | https://localhost:5001 |
| HTTP listener | http://localhost:5000 |
| Swagger UI | https://localhost:5001/swagger |
| OpenAPI document | https://localhost:5001/swagger/v1/swagger.json |

HTTP requests are redirected to HTTPS. Swagger is enabled in all environments by the current startup code. A frontend fallback is configured, but no frontend build or `index.html` is checked into this repository.

## Authentication

Send a JSON request to `POST /api/auth/login`:

```json
{
  "username": "<your-development-username>",
  "password": "<your-development-password>"
}
```

A successful response wraps the account in `result`. Read the token from `result[0].token` and the account ID from `result[0].id`.

For protected requests, supply:

```http
Authorization: Bearer <token>
```

User add/update/delete and purpose update/delete actions also require an `id` header containing the acting user's numeric ID. Purpose submission accepts it optionally; anonymous submissions use zero. This header is read separately from the JWT claims.

Tokens expire after 24 hours by default. Swagger does not configure a bearer security scheme or the custom `id` header, so use Postman or another HTTP client for authenticated workflows.

## Endpoints

Routes and HTTP methods below match the current controllers.

| Method | Route | Access | Action |
| --- | --- | --- | --- |
| POST | `/api/auth/login` | Public | Sign in and receive a JWT |
| GET | `/api/user/get` | JWT | List active accounts with role/gender descriptions |
| POST | `/api/user/add` | JWT + `id` | Create an account |
| PUT | `/api/user/update` | JWT + `id` | Update the account password field and audit metadata |
| GET | `/api/user/delete/{userId}` | JWT + `id` | Deactivate an account |
| GET | `/api/user/roles/get` | JWT | List roles |
| GET | `/api/user/gender/get` | JWT | List genders |
| GET | `/api/purpose/complaints/get` | JWT | List complaints |
| GET | `/api/purpose/assistance/get` | JWT | List assistance requests |
| GET | `/api/purpose/status/get` | JWT | List purpose statuses |
| POST | `/api/purpose/add` | Public; optional `id` | Submit a complaint or assistance request |
| PUT | `/api/purpose/update` | JWT + `id` | Update request details and status |
| GET | `/api/purpose/delete/{purposeId}` | JWT + `id` | Soft-delete a request |
| POST | `/api/upload?type=profile` | Public | Upload the first file in a multipart request |

The two delete routes perform writes despite using HTTP `GET`; do not treat them as read-only links.

## Example: submit a request

First upload supporting images through `POST /api/upload?type=proof` and `POST /api/upload?type=verification`. Use `multipart/form-data` with a file field, for example `file`. The controller reads the first uploaded file and returns its relative path as the response body.

Use those returned paths in a JSON request to `POST /api/purpose/add`:

```json
{
  "purposeType": "complaints",
  "complainant": "Sample Resident",
  "contactNo": "09000000000",
  "email": "resident@example.com",
  "statement": "Street lighting needs repair near the community hall.",
  "respondent": "",
  "involved": "",
  "proofImgPath": "Resources/Images/proof/street-light.jpg",
  "verificationImgPath": "Resources/Images/verification/verification.jpg",
  "location": "Purok 1"
}
```

Replace the sample image paths with actual upload results. Use `"assistance"` for an assistance request; the list queries recognize `complaints` and `assistance`. The service sets new submissions to status `1` (Pending).

Files under `/Resources` are publicly served by the current application. Use synthetic documents for local testing.

## Current implementation notes

- Successful controller actions generally return an `ApiOkResponse` containing `statusCode`, `message`, and `result`. Uploads return a path directly.
- Several exception handlers return HTTP `404` with a body containing `statusCode: 500`; clients should inspect both the HTTP status and response body.
- Account update is not a complete profile editor: it assigns the supplied password directly, unlike account creation/login, which use `Crypto.Encrypt`.
- Purpose update accepts `location` in its DTO but does not currently save that field.
- Protected controllers require a JWT but do not declare role-specific authorization. The login DTO also includes a password field.
- Uploads are anonymous and have no controller request-size limit. Review access control and file validation before using this flow with real resident documents.

## Verification and troubleshooting

No automated test project or CI workflow is checked in. A manual development check is to build the solution, apply migrations, prepare lookup data, start the API, sign in, submit a sample request, and confirm it appears in the corresponding authenticated list.

| Symptom | Check |
| --- | --- |
| Missing .NET runtime or tool restore failure | Install the runtimes/SDKs listed above; the app and local EF CLI target different versions. |
| Startup fails with a resource-directory error | Create `Resources` and run from the API project directory. |
| SQL connection or migration failure | Check the server, authentication, database permissions, and environment override. |
| Empty account or request lists | Check active/deleted flags and the lookup rows used by the list queries. |
| Protected endpoint returns 401 | Send a valid bearer token signed with the current JWT key. |
| A write fails with a valid token | Supply the numeric `id` header required by that action. |
| Upload fails | Send an image as multipart form data; ensure the selected destination directory exists and is writable. |
| No email arrives after submission | The email send call is currently disabled in `PurposesService`. |

## License

No license file is currently included in this repository.
