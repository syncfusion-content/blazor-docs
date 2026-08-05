---
layout: post
title: Connect Firebase Firestore to Blazor Pivot Table | Syncfusion®
description: Bind a Firebase Firestore database to the Blazor Pivot Table through an ASP.NET Core API and the Syncfusion URL Adaptor.
platform: Blazor
control: PivotTable
documentation: ug
---

# Connect Firebase Firestore to Blazor Pivot Table

This User Guide explains how to bind a Firebase Firestore database to the Syncfusion Blazor Pivot Table through an ASP.NET Core API and the Syncfusion `UrlAdaptor`. The sample uses the `Google.Cloud.Firestore` client library to read and write documents in an `Orders` collection, while the Pivot Table consumes the API through `SfDataManager`.

Firestore is a cloud-hosted NoSQL document database. Data is stored in documents, which are grouped into collections. The implementation follows a server-hosted pattern: the Blazor Pivot Table requests data from the server, and the server handles Firestore access, authentication, and CRUD operations. This keeps the component focused on aggregation and editing while the API handles persistence against the cloud-hosted Firestore database.

## Prerequisites

The following table lists the tools and libraries required to build and run the sample.

| Component | Version | Purpose |
|-----------|---------|---------|
| .NET SDK | 10.0 | Builds and runs the Blazor Web App targeting `net10.0`. |
| Visual Studio 2026 or Code Studio | 18.0+ / latest | Development environment with the ASP.NET and web workloads installed. |
| Firebase Account | Active Google account | Used to create a Firebase project and a Firestore database. |
| Firebase Firestore Database | Provisioned instance | Cloud-hosted NoSQL document store that holds the `Orders` collection. |
| Google.Cloud.Firestore | 4.3.0 | Official Google Cloud Firestore client library for .NET. Requires .NET 8 or later; verified with .NET 10. |
| Syncfusion.Blazor.PivotTable | 34.1.33 | Renders the Pivot Table UI and performs aggregation. |
| Syncfusion.Blazor.Themes | 34.1.33 | Applies the Bootstrap 5 theme to the Pivot Table. |
| Newtonsoft.Json | 13.0.4 | Serializes the JSON payloads exchanged with the URL Adaptor. |

## Firestore Database Setup and Application Configuration

The sample reads and writes documents in an `Orders` collection. Complete the steps below to provision the Firestore database, the collection, sample data, and the service account key, and then build the Blazor web app that consumes them.

### Step 1: Create a Firebase Project

For the official walkthrough, see the [Firebase documentation: Create a Firebase project](https://firebase.google.com/docs/projects/api/workflow_set-up-and-manage-project).

1. Sign in to the [Firebase Console](https://console.firebase.google.com/) using a Google account.
2. Click **Add project** and enter a project name, for example `pivottablefirestore`.
3. Accept the default options and click **Create project**.
4. Once provisioning completes, open the project to configure Firestore.

### Step 2: Create a Firestore Database

1. In the Firebase console left navigation, expand **Build** and select **Firestore Database**.
2. Click **Create database**.
3. Choose **Start in test mode** so that read and write access is allowed during local development.
4. Select a Firestore region close to your users and click **Enable**.

> **Note:** Test mode leaves the database open for 30 days. Replace the test rules with production rules before deploying the sample. For example, a minimum locked-down ruleset is:
>
> ```text
> rules_version = '2';
> service cloud.firestore {
>   match /databases/{database}/documents {
>     match /{document=**} {
>       allow read, write: if request.auth != null;
>     }
>   }
> }
> ```

### Step 3: Create the Orders Collection

1. In the Firestore Database console, click **Start collection**.
2. Set the collection ID to:

   ```text
   Orders
   ```

3. Click **Next** and then **Save** to create an empty collection.

The `Orders` collection stores one document per order. Firestore generates a unique document ID for each inserted document. The `orderId` field inside each document serves as the business key used by the controller for update and delete operations.

### Step 4: Add Sample Data

Add the following five sample documents to the `Orders` collection. Each document uses a Firestore-generated ID and stores the fields shown below. The block is shown as a JSON array for readability; each entry is added to Firestore individually:

```json
[
  { "orderId": 1, "customerName": "John Smith", "employeeId": 101, "freight": 32.5, "shipCity": "New York" },
  { "orderId": 2, "customerName": "Kate Riley",  "employeeId": 102, "freight": 48.2, "shipCity": "London" },
  { "orderId": 3, "customerName": "Liam Wood",   "employeeId": 103, "freight": 21.7, "shipCity": "Berlin" },
  { "orderId": 4, "customerName": "Emma Stone",  "employeeId": 104, "freight": 60.0, "shipCity": "Madrid" },
  { "orderId": 5, "customerName": "Noah Clark",  "employeeId": 105, "freight": 55.5, "shipCity": "Tokyo" }
]
```

For each entry in the array, click **Add document** in the Firestore console, leave the document ID blank so Firestore auto-generates one, and add the fields above as key/value pairs. Repeat the operation for all five documents. For bulk import, use the [Google Cloud Firestore import/export tooling](https://firebase.google.com/docs/firestore/manage-data/export-import) instead.

### Step 5: Generate and Store a Firebase Service Account Key

The `Google.Cloud.Firestore` library authenticates to Firestore using a service account key. Generate your own Firebase service account key by navigating to:

```text
Firebase Console
    → Project Settings
    → Service Accounts
    → Generate New Private Key
```

Firebase downloads the JSON credentials file to your machine. This file is used by the ASP.NET Core API to authenticate as the project's service account.

The sample expects the credentials file to be available in the project. Create a folder named:

```text
Firebase
```

Rename the downloaded file and store it as:

```text
Firebase/serviceAccountKey.json
```

> Store only placeholder content in source control and provide your own key locally. Before running the sample, generate your own Firebase service account key and replace the placeholder file with the downloaded key. Never commit real Firebase credentials to source control.

The file shown below is a dummy service account key used only for demonstration:

```json
{
  "type": "service_account",
  "project_id": "<YOUR_FIREBASE_PROJECT_ID>",
  "private_key_id": "<PRIVATE_KEY_ID>",
  "private_key": "-----BEGIN PRIVATE KEY-----\n<PRIVATE_KEY>\n-----END PRIVATE KEY-----\n",
  "client_email": "<SERVICE_ACCOUNT_EMAIL>",
  "client_id": "<CLIENT_ID>",
  "auth_uri": "https://accounts.google.com/o/oauth2/auth",
  "token_uri": "https://oauth2.googleapis.com/token",
  "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
  "client_x509_cert_url": "<CLIENT_X509_CERT_URL>",
  "universe_domain": "googleapis.com"
}
```

### Step 6: Create the Blazor Web App

Create a new Blazor Web App named `PivotTableFirestore` that hosts the Pivot Table page and the ASP.NET Core API controller.

1. In Visual Studio or Code Studio, create a new **Blazor Web App**.
2. Set the project name to:

   ```text
   PivotTableFirestore
   ```

3. Choose the **.NET 10.0** target framework.
4. Select the **Interactive Render Mode: Server** and **Interactivity Location: Per page/component** options so that the Pivot Table runs as an interactive server component.

### Step 7: Install the Required NuGet Packages

Add the `Google.Cloud.Firestore` package and the Syncfusion packages to the project. The relevant entries from `PivotTableFirestore.csproj` are shown below:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Syncfusion.Blazor.PivotTable" Version="34.1.33" />
    <PackageReference Include="Syncfusion.Blazor.Themes" Version="34.1.33" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.4" />
    <PackageReference Include="Google.Cloud.Firestore" Version="4.3.0" />
  </ItemGroup>

  <ItemGroup>
    <None Update="Firebase\*.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>
```

### Step 8: Configure the Application

**appsettings.json**

The sample reads the Firestore project ID and the target collection name from `appsettings.json`. Replace the `ProjectId` value with the ID of the Firebase project you created in Step 1.

```json
{
  "FirestoreSettings": {
    "ProjectId": "pivottablefirestore",
    "CollectionName": "Orders"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

> **Note:** If `appsettings.Development.json` exists, its `FirestoreSettings` values override the base `appsettings.json` when the app runs under the `Development` environment (the default for `dotnet run`). When debugging the connection, check both files.

**Program.cs**

The `Google.Cloud.Firestore` client resolves credentials through Application Default Credentials (ADC), which in turn read the `GOOGLE_APPLICATION_CREDENTIALS` environment variable. The sample points this variable to the service account key file before any Firestore call is made. The complete `Program.cs` is shown below — the environment variable is set before `builder.Build()` so `FirestoreDb.Create` can authenticate when the first controller endpoint runs:

```csharp
using PivotTableFirestore.Components;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

Environment.SetEnvironmentVariable(
    "GOOGLE_APPLICATION_CREDENTIALS",
    Path.Combine(
        builder.Environment.ContentRootPath,
        "Firebase",
        "serviceAccountKey.json"));

// Register a valid Syncfusion license key to remove the license banner.
// Register a Syncfusion license or trial key before running the app. Without a valid
// key, the Pivot Table shows a license banner and evaluation watermarks.
// Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
//     "YOUR_LICENSE_KEY");

builder.Services.AddSyncfusionBlazor();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

The service account file authorizes the server-side API to read and write the `Orders` collection on behalf of the Firebase project. Without this file, `FirestoreDb.Create` cannot authenticate and all controller endpoints will fail. The path is resolved relative to `builder.Environment.ContentRootPath` because the `<None Update="Firebase\*.json">` entry in `PivotTableFirestore.csproj` (see Step 7) copies the file into the build output alongside the assembly.

### Step 9: Create the Order Model

The `Order` model maps .NET properties to Firestore document fields. The class is decorated with `[FirestoreData]` so the Firestore client can convert documents to and from the type, and each property uses `[FirestoreProperty]` to bind to the corresponding field name in the document. In this sample, `Order` is declared as a nested class inside `OrderController`, so the following `using` directives are required at the top of `Controllers/OrderController.cs`:

```csharp
using System.ComponentModel.DataAnnotations; // [Key]
using System.Text.Json.Serialization;        // [JsonPropertyName]
using Google.Cloud.Firestore;               // [FirestoreData], [FirestoreProperty]
using Microsoft.AspNetCore.Mvc;              // [ApiController], ControllerBase
using Syncfusion.Blazor.Data;                // DataManagerRequest
```

```csharp
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    [FirestoreData]
    public class Order
    {
        [Key]
        [FirestoreProperty("orderId")]
        public int? OrderID { get; set; }

        [FirestoreProperty("customerName")]
        public string? CustomerName { get; set; }

        [FirestoreProperty("employeeId")]
        public int? EmployeeID { get; set; }

        [FirestoreProperty("freight")]
        public double? Freight { get; set; }

        [FirestoreProperty("shipCity")]
        public string? ShipCity { get; set; }
    }

    private readonly FirestoreDb firestoreDb;
    private readonly string collectionName;

    public OrderController(IConfiguration configuration)
    {
        string projectId =
            configuration["FirestoreSettings:ProjectId"]
            ?? throw new InvalidOperationException(
                "Firestore ProjectId is not configured.");

        collectionName =
            configuration["FirestoreSettings:CollectionName"]
            ?? "Orders";

        firestoreDb = FirestoreDb.Create(projectId);
    }
}
```

The `[Key]` attribute marks `OrderID` as the primary key for the URL Adaptor's update and delete operations; it is a client-side marker for the adaptor and not a Firestore constraint. The `[FirestoreProperty]` attribute controls how each field is named inside the Firestore document.

### Step 10: Create the API Controller

The `OrderController` exposes the API endpoints consumed by the Pivot Table. It creates a `FirestoreDb` instance using the configured project ID and reads the collection name from `appsettings.json`. Create the file at `Controllers/OrderController.cs` (Add → New Item → API Controller in Visual Studio, or the file location the CLI scaffold gives you under the project's `Controllers` folder). Then paste the snippets below into that single file, in this order: `using` directives, the `OrderController` class with the nested `Order` class, the `CRUDModel<T>` class below the `OrderController` body, and the four action methods (read, insert, update, delete).

Append the `CRUDModel<T>` class to `Controllers/OrderController.cs`, below the `OrderController` class body. The URL Adaptor sends this type for insert, update, and delete requests:

```csharp
public class CRUDModel<T> where T : class
{
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("keyColumn")]
    public string? KeyColumn { get; set; }

    [JsonPropertyName("key")]
    public object? Key { get; set; }

    [JsonPropertyName("value")]
    public T? Value { get; set; }
}
```

**Read Operation**

The read endpoint receives a `DataManagerRequest` from the Pivot Table, reads all documents from the `Orders` collection using `GetSnapshotAsync`, converts each document to an `Order`, and returns the result in the `{ result, count }` format expected by the URL Adaptor. The `request` parameter is intentionally discarded (`_ = request;`) because this sample returns the full collection and relies on the Pivot Table to perform aggregation, paging, and sorting client-side; the `DataManagerRequest` is still accepted so the `UrlAdaptor` contract is satisfied.

```csharp
[HttpPost]
public async Task<object> Post([FromBody] DataManagerRequest request)
{
    _ = request;

    CollectionReference collection =
        firestoreDb.Collection(collectionName);

    QuerySnapshot snapshot =
        await collection.GetSnapshotAsync();

    List<Order> orders = new();

    foreach (DocumentSnapshot document in snapshot.Documents)
    {
        if (!document.Exists)
        {
            continue;
        }

        Order order = document.ConvertTo<Order>();
        orders.Add(order);
    }

    return new
    {
        result = orders.OrderBy(x => x.OrderID).ToList(),
        count = orders.Count
    };
}
```

**Insert Operation**

The insert endpoint receives a `CRUDModel<Order>` containing the new order. The controller derives the next available `orderId` value from existing documents and adds the order to the collection using `AddAsync`, letting Firestore generate the document ID while the controller assigns the next `orderId`.

```csharp
[HttpPost("Insert")]
public async Task<IActionResult> Insert([FromBody] CRUDModel<Order> value)
{
    if (value.Value is not Order order)
    {
        return BadRequest();
    }

    CollectionReference collection =
        firestoreDb.Collection(collectionName);

    QuerySnapshot snapshot =
        await collection.GetSnapshotAsync();

    int nextOrderId = snapshot.Documents.Count == 0
        ? 1
        : snapshot.Documents
            .Select(x => x.ConvertTo<Order>())
            .Max(x => x.OrderID ?? 0) + 1;

    order.OrderID = nextOrderId;

    await collection.AddAsync(order);

    return Ok(order);
}
```

> **Note:** This `Max + 1` approach is safe for a single-user demo but is not concurrency-safe under multiple simultaneous writers (two inserts can compute the same `nextOrderId`). For production, allocate IDs atomically inside `FirestoreDb.RunTransactionAsync`.

**Update Operation**

The update endpoint receives a `CRUDModel<Order>` containing the modified order. The controller queries the collection for the document whose `orderId` matches the incoming `OrderID` using `WhereEqualTo`, then overwrites the document with `SetAsync`.

```csharp
[HttpPost("Update")]
public async Task<IActionResult> Update([FromBody] CRUDModel<Order> value)
{
    if (value.Value is not Order order
        || !order.OrderID.HasValue)
    {
        return BadRequest();
    }

    CollectionReference collection =
        firestoreDb.Collection(collectionName);

    // "orderId" matches the Firestore field name configured via
    // [FirestoreProperty("orderId")] on the Order model.
    QuerySnapshot snapshot =
        await collection
            .WhereEqualTo("orderId", order.OrderID)
            .GetSnapshotAsync();

    DocumentSnapshot? document =
        snapshot.Documents.FirstOrDefault();

    if (document is null)
    {
        return NotFound();
    }

    await document.Reference.SetAsync(order);

    return Ok(order);
}
```

**Delete Operation**

The delete endpoint receives a `CRUDModel<Order>` whose `key` carries the `orderId` of the document to remove. The controller queries the collection for the matching document and removes it using `DeleteAsync`.

```csharp
[HttpPost("Delete")]
public async Task<IActionResult> Delete([FromBody] CRUDModel<Order> value)
{
    if (!int.TryParse(value.Key?.ToString(), out int orderId))
    {
        return BadRequest();
    }

    CollectionReference collection =
        firestoreDb.Collection(collectionName);

    // "orderId" matches the Firestore field name configured via
    // [FirestoreProperty("orderId")] on the Order model.
    QuerySnapshot snapshot =
        await collection
            .WhereEqualTo("orderId", orderId)
            .GetSnapshotAsync();

    DocumentSnapshot? document =
        snapshot.Documents.FirstOrDefault();

    if (document is null)
    {
        return NotFound();
    }

    await document.Reference.DeleteAsync();

    return NoContent();
}
```

### Step 11: Configure the Pivot Table

The Pivot Table is rendered in `Components/Pages/Home.razor`. It binds to the API through `SfDataManager` and the `UrlAdaptor`, passing read, insert, update, and delete URLs to the corresponding controller endpoints.

**_Imports.razor**

Add the Syncfusion namespaces required by the Pivot Table to `Components/_Imports.razor` so they are available across all components:

```razor
@using Syncfusion.Blazor
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Data
```

**App.razor**

Register the Syncfusion theme and client scripts in `Components/App.razor`:

```html
<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"
        type="text/javascript"></script>
```

**Home.razor**

Configure the `SfPivotView` with `SfDataManager` bound to the API endpoints and the `UrlAdaptor`:

```razor
<SfPivotView TValue="Order" Width="1000" Height="300" ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="Order" ExpandAll="false" EnableSorting="true">
        <SfDataManager Url="/api/Order"
                       InsertUrl="/api/Order/Insert"
                       UpdateUrl="/api/Order/Update"
                       RemoveUrl="/api/Order/Delete"
                       Adaptor="Adaptors.UrlAdaptor">
        </SfDataManager>
        <PivotViewColumns>
            <PivotViewColumn Name="EmployeeID"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="CustomerName"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Freight" Caption="Freight"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
    <PivotViewEvents TValue="Order" BeginDrillThrough="BeginDrillThrough"></PivotViewEvents>
    <PivotViewCellEditSettings AllowEditing="true"
                               AllowAdding="true"
                               AllowDeleting="true"
                               Mode="EditMode.Normal">
    </PivotViewCellEditSettings>
</SfPivotView>
```

> **Note:** The `Order` model declared in the `@code` block of `Home.razor` is the client-side type used by the Pivot Table for binding. Its property names must match the fields returned by the API.

**BeginDrillThrough Event Handler**

The following `BeginDrillThrough` event handler is declared in the `@code` block of `Home.razor` and wired to the `<PivotViewEvents BeginDrillThrough="BeginDrillThrough" />` element shown above. It marks `OrderID` as the primary key of the drill-through grid so that the URL Adaptor can include the key value in update and delete requests:

```csharp
private void BeginDrillThrough(BeginDrillThroughEventArgs args)
{
    for (int i = 0; i < args.GridObj.Columns.Count; i++)
    {
        if (args.GridObj.Columns[i].Field == "OrderID")
        {
            args.GridObj.Columns[i].IsPrimaryKey = true;
        }
        else
        {
            args.GridObj.Columns[i].Visible = true;
        }
    }
}
```

A lightweight `Order` class is also declared in the `@code` block so the Pivot Table can bind typed data on the client. This client-side `Order` class is intentionally separate from the server-side `Order` model shown earlier: the server model carries the Firestore mapping attributes (`[FirestoreData]`, `[FirestoreProperty]`) that the client does not need, while this version mirrors only the property names returned by the API. Keeping the two classes separate avoids leaking Firestore-specific attributes into the Blazor UI assembly:

```csharp
public class Order
{
    public int? OrderID { get; set; }
    public string? CustomerName { get; set; }
    public int? EmployeeID { get; set; }
    public double? Freight { get; set; }
    public string? ShipCity { get; set; }
}
```

## Firestore Document Structure

Each document in the `Orders` collection follows the structure shown below. Firestore generates a unique document ID for each document; the `orderId` field is the business key used by the controller for update and delete operations.

```json
{
  "orderId": 1,
  "customerName": "John Smith",
  "employeeId": 101,
  "freight": 32.5,
  "shipCity": "New York"
}
```

| Field | Type | Description |
|-------|------|-------------|
| `orderId` | number | Business key used as the primary key for update and delete operations. |
| `customerName` | string | Name of the customer who placed the order. |
| `employeeId` | number | Identifier of the employee who handled the order. |
| `freight` | number | Freight charge for the order, used as the aggregation value. |
| `shipCity` | string | Destination city for the shipment. |

## API Contract

The Pivot Table communicates with the controller using `POST` requests. The request and response shapes follow the Syncfusion `UrlAdaptor` contract.

| Endpoint | Method | Request Body | Response |
|----------|--------|--------------|----------|
| `/api/Order` | POST | `DataManagerRequest` | `{ result, count }` where `result` is the list of orders and `count` is the total document count. |
| `/api/Order/Insert` | POST | `CRUDModel<Order>` | `200 OK` with the inserted `Order` (including the generated `orderId`). |
| `/api/Order/Update` | POST | `CRUDModel<Order>` | `200 OK` with the updated `Order`. |
| `/api/Order/Delete` | POST | `CRUDModel<Order>` with `key` set to the `orderId` | `204 No Content` on success. |

```text
POST /api/Order
POST /api/Order/Insert
POST /api/Order/Update
POST /api/Order/Delete
```

### Failure Responses

| Status | Condition | Body |
|--------|-----------|------|
| `400 Bad Request` | The request body is missing or the `orderId` cannot be parsed. | `ProblemDetails` |
| `404 Not Found` | No document matches the supplied `orderId` during update or delete. | `ProblemDetails` |
| `500 Internal Server Error` | Firestore authentication or network failure. | `ProblemDetails` |

Example successful read response:

```json
{
  "result": [
    { "orderId": 1, "customerName": "John Smith", "employeeId": 101, "freight": 32.5, "shipCity": "New York" }
  ],
  "count": 1
}
```

Example insert request body sent by the URL Adaptor:

```json
{
  "action": "add",
  "value": {
    "customerName": "John Smith",
    "employeeId": 101,
    "freight": 32.5,
    "shipCity": "New York"
  }
}
```

Example update request body sent by the URL Adaptor:

```json
{
  "action": "update",
  "keyColumn": "OrderID",
  "key": 1,
  "value": {
    "orderId": 1,
    "customerName": "John Smith",
    "employeeId": 101,
    "freight": 35.0,
    "shipCity": "New York"
  }
}
```

Example delete request body sent by the URL Adaptor:

```json
{
  "action": "remove",
  "keyColumn": "OrderID",
  "key": 1
}
```

## Run and Verify

> Register a valid Syncfusion license or trial key in `Program.cs` (see the commented `RegisterLicense` call above) before running to remove the license banner.

1. Provision the Firebase project, Firestore database, `Orders` collection, and sample documents as described in the [Firestore Database Setup and Application Configuration](#firestore-database-setup-and-application-configuration) section.
2. Generate a service account key and place it at `Firebase/serviceAccountKey.json`.
3. Restore the NuGet packages and build the project:

   ```bash
   dotnet restore
   dotnet build
   ```

4. Optionally, verify the API directly before opening the Pivot Table. From a separate terminal, POST to the read endpoint and confirm the seeded documents are returned:

   ```bash
   curl -X POST http://localhost:5000/api/Order -H "Content-Type: application/json" -d "{}"
   ```

5. Run the application:

   ```bash
   dotnet run --project PivotTableFirestore/PivotTableFirestore.csproj
   ```

6. Open the local URL shown in the terminal.
7. Confirm that the Pivot Table loads with the sample data and that drill-through editing inserts, updates, and deletes documents in the `Orders` collection.

## Production Considerations

- Replace the Firestore test-mode security rules with production rules that restrict read and write access to authenticated service accounts only.
- Store the `serviceAccountKey.json` file outside the source tree and load it through a secure secrets manager or environment variable in production deployments.
- Enable Firestore offline persistence and indexing strategies that match the expected query patterns when the document count grows.

## Troubleshooting

| Issue | Possible Cause | Resolution |
|-------|----------------|------------|
| Missing `serviceAccountKey.json` | The credentials file is not present in the `Firebase` folder at runtime. | Generate a new Firebase service account key and store it at `Firebase/serviceAccountKey.json`. Confirm the project file copies the JSON to the output directory. |
| Invalid Firebase Project ID | `FirestoreSettings:ProjectId` in `appsettings.json` does not match the Firebase project. | Update the `ProjectId` value to match the project created in the Firebase console. |
| Firestore authentication failures | The `GOOGLE_APPLICATION_CREDENTIALS` path is incorrect or the key file is invalid. | Verify the path set in `Program.cs` resolves to the key file and that the key file was downloaded from the Firebase console. |
| Firebase connection issues | Network restrictions or firewall rules block outbound HTTPS to `firestore.googleapis.com`. | Allow outbound HTTPS traffic to the Firestore host and confirm the selected Firestore region is reachable. |
| Collection not found | The `Orders` collection was not created in Firestore, or `CollectionName` in `appsettings.json` is misspelled. | Create the `Orders` collection in the Firebase console and ensure the `CollectionName` value matches exactly. |
| CRUD operation issues | The document does not exist, or the `orderId` cannot be matched during update or delete. | Confirm that sample documents were inserted with valid `orderId` values and that the drill-through grid marks `OrderID` as the primary key. |
| UrlAdaptor request failures | The Pivot Table cannot reach the API endpoint, or the response shape does not match the adaptor contract. | Verify the `SfDataManager` URLs are correct relative paths and that the controller returns `{ result, count }` for read requests. |
| `AddControllers` / `MapControllers` missing | The Pivot Table receives `404 Not Found` for `/api/Order` and the controller file is not picked up. | Confirm that `builder.Services.AddControllers();` is present in `Program.cs` and that `app.MapControllers();` is called between `app.Build()` and `app.Run()`. |
| CORS errors during local development | The browser blocks the Pivot Table's fetch to `/api/Order` because the API lives on a different origin. | Both the Blazor app and the API run on the same origin in the scaffold used here, so CORS is not required. If you split the API into a separate project, register a CORS policy and call `app.UseCors(...)` before `app.MapControllers()`. |
| Port conflict on `dotnet run` | Another process is already bound to the port shown in the terminal, or a previous `dotnet run` was not stopped. | Stop the previous process with `Get-Process -Name "PivotTableFirestore" \| Stop-Process -Force` (PowerShell) before rebuilding; otherwise the build fails with `MSB3027` because the assembly is locked. |
| ADC not set at runtime | `GOOGLE_APPLICATION_CREDENTIALS` is read before `builder.Build()` but the `Firebase/serviceAccountKey.json` file is missing from the output directory. | Confirm the `<None Update="Firebase\*.json">` entry in `PivotTableFirestore.csproj` and rebuild. The file must be copied to `bin/Debug/net10.0/Firebase/`. |
| Test-mode rules expired | Firestore returns `PERMISSION_DENIED` after 30 days because the test-mode security rules have expired. | Replace the test rules with the production example shown in Step 2, or extend the test-mode window from the Firebase console. |

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/syncfusion-blazor-pivot-table-firebase-firestore/tree/master).

## Summary

This User Guide demonstrated how to connect a Firebase Firestore database to the Syncfusion Blazor Pivot Table using the `UrlAdaptor`. The `Google.Cloud.Firestore` client library handles authentication and document access in the ASP.NET Core API, while the Pivot Table performs aggregation and editing on the client. The `Orders` collection stores documents through the API's read, insert, update, and delete endpoints, and the `SfDataManager` binds those endpoints to the Pivot Table through same-origin relative URLs. Together, these pieces let the Syncfusion Blazor Pivot Table connect to a cloud-hosted Firestore NoSQL database while keeping all credential handling and persistence logic on the server.
