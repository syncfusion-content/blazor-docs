---
layout: post
title: Blazor Scheduler connected to MongoDB | Syncfusion
description: Bind MongoDB data to Blazor Scheduler using MongoDB.Driver with complete CRUD operations for appointments, recurrence events, and advanced scheduling features.
platform: Blazor
control: Scheduler
documentation: ug
---

# Connecting MongoDB to Blazor Scheduler Using MongoDB.Driver

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) supports binding data from a MongoDB database using the [MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver) library. This approach provides a flexible and scalable solution for managing appointments, events, and schedules with NoSQL document databases.

**What is MongoDB?**

[MongoDB](https://www.mongodb.com/) is a NoSQL document database that stores data in flexible, JSON-like documents. Unlike traditional relational databases that use tables and rows, MongoDB uses collections and documents, making it ideal for applications that require flexible schemas and horizontal scalability.

**Key Benefits of MongoDB**

- **Flexible Schema**: Store documents with different structures in the same collection without predefined schemas.
- **Scalability**: Designed for horizontal scaling across multiple servers.
- **Rich Query Language**: Supports complex queries, aggregation, and indexing.
- **Document-Oriented**: Store data in JSON-like BSON format, making it natural for modern applications.
- **High Performance**: Optimized for read and write operations with built-in caching.

**What is MongoDB.Driver?**

**MongoDB.Driver** is the official .NET driver for MongoDB. It provides a comprehensive API for interacting with MongoDB databases, allowing applications to perform CRUD operations, execute queries, and manage database connections efficiently.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net9.0 or later | Runtime and build tools |
| MongoDB Server | 6.0 or later | NoSQL database server |
| MongoDB Compass | Latest | GUI for MongoDB database management |
| Syncfusion.Blazor.Schedule | Latest | Scheduler and UI components |
| Syncfusion.Blazor.Themes | Latest | Styling for Scheduler components |
| MongoDB.Driver | 2.23.0 or later | Official .NET driver for MongoDB |

## Setting Up the MongoDB Environment

### Step 1: Create the Database and Collection in MongoDB

First, the **MongoDB database** structure must be created to store appointment records.

**Instructions:**
1. Open MongoDB Compass and connect to MongoDB server (default: `mongodb://localhost:27017`).
2. Create a new database named `EventManagementDB`.
3. Create a collection named `Events`.

**Using MongoDB Compass:**

1. Click **"Create Database"** button
2. Database Name: `EventManagementDB`
3. Collection Name: `Events`

The database is now ready for integration with the Blazor application.

---

### Step 2: Create a Blazor Web App

The next step is to create a Blazor Web App that will host the Syncfusion Scheduler component. This application requires server-side interactivity to support CRUD operations.

You can create the Blazor Web App using either Visual Studio or the .NET CLI.

**Create the application using Visual Studio**

1. Open Visual Studio.
2. Click Create a new project.
3. Search for and select the Blazor Web App template.
4. Click Next.
5. Configure the project settings:
    - **Project name:** BlazorSchedulerApp
    - **Location:** Choose your preferred directory
6. Click Next.
7. In the additional information screen, configure the following:
    - **Target framework:** .NET 10.0
    - **Interactive render mode:** Server
    - **Interactivity location:** Per page/component
8. Click Create to generate the project.

> The Scheduler component requires server-side interactivity to perform create, update, and delete operations. Ensure that the **Interactive render mode** is set to **InteractiveServer** during project creation.

### Step 3: Install Required NuGet Packages

After creating the Blazor Web App, install the required NuGet packages to enable MongoDB integration and Syncfusion Scheduler functionality.

The default Blazor Web App template automatically generates essential project files such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

**Method 1: Using Package Manager Console**

1. Open Visual Studio.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package MongoDB.Driver 
Install-Package Syncfusion.Blazor.Schedule 
Install-Package Syncfusion.Blazor.Themes 
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - [MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver)
   - [Syncfusion.Blazor.Scheduler](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule/)
   - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

All required packages are now installed.

---

### Step 4: Create the Data Model

A data model is a C# class that represents the structure of a MongoDB document. This model defines the properties that correspond to the fields in the `Events` collection.

**Instructions:**

1. Create a new folder named `Models` in the Blazor application project.
2. Inside the `Models` folder, create a new file named **AppointmentData.cs**.
3. Define the **AppointmentData** class with the following code:

```csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorSchedulerApp.Models
{
    /// <summary>
    /// Represents an appointment/event in the Scheduler.
    /// Maps to MongoDB document in the Events collection.
    /// </summary>
    public class AppointmentData
    {
        /// <summary>
        /// MongoDB document identifier (automatically generated).
        /// This is the unique identifier for the document in MongoDB.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        /// <summary>
        /// Application-level unique identifier for the appointment.
        /// Used by Syncfusion Scheduler for event tracking.
        /// </summary>
        [BsonElement("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Title or name of the appointment.
        /// This appears as the main text in the Scheduler.
        /// </summary>
        [BsonElement("Subject")]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Physical or virtual location of the appointment.
        /// Example: "Conference Room A", "Virtual - Teams"
        /// </summary>
        [BsonElement("Location")]
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Start date and time of the appointment.
        /// Stored in UTC format in MongoDB.
        /// </summary>
        [BsonElement("StartTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End date and time of the appointment.
        /// Stored in UTC format in MongoDB.
        /// </summary>
        [BsonElement("EndTime")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Detailed description or notes about the appointment.
        /// </summary>
        [BsonElement("Description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Indicates if the appointment spans the entire day.
        /// When true, time is not displayed in the Scheduler.
        /// </summary>
        [BsonElement("IsAllDay")]
        public bool IsAllDay { get; set; }

        /// <summary>
        /// Recurrence pattern in iCalendar format (RFC 5545).
        /// Example: "FREQ=DAILY;INTERVAL=1;COUNT=5" for daily recurrence.
        /// Empty string means no recurrence.
        /// </summary>
        [BsonElement("RecurrenceRule")]
        public string RecurrenceRule { get; set; } = string.Empty;

        /// <summary>
        /// ID of the parent appointment for recurrence exceptions.
        /// When editing a single occurrence, this points to the parent event.
        /// Null for non-exception events.
        /// </summary>
        [BsonElement("RecurrenceID")]
        public Nullable<int> RecurrenceID { get; set; }

        /// <summary>
        /// Comma-separated dates of exceptions in recurrence series.
        /// Format: "20240315T100000Z,20240320T100000Z"
        /// Indicates which occurrences were deleted or modified.
        /// </summary>
        [BsonElement("RecurrenceException")]
        public string RecurrenceException { get; set; } = string.Empty;
    }
}
```

**Explanation:**
- The `[BsonId]` attribute marks the `_id` property as the MongoDB document identifier (automatically generated by MongoDB).
- The `[BsonElement]` attributes map C# properties to MongoDB document fields.
- Each property represents a field in the MongoDB document.
- The `?` symbol indicates that a property is nullable (can be empty).
- The model includes special properties for handling recurring appointments (`RecurrenceRule`, `RecurrenceID`, `RecurrenceException`).

The data model has been successfully created.

---

### Step 5: Create the MongoDB Service Class

MongoDB.Driver uses a service class to manage database connections and operations. This service class handles all interactions with the MongoDB database, including CRUD operations and batch updates for recurrence events.

**Instructions:**

1. Create a new folder named `Services` in the Blazor application project.
2. Inside the `Services` folder, create a new file named **MongoDBService.cs**.
3. Define the **MongoDBService** class with the following code:

```csharp
using MongoDB.Bson;
using MongoDB.Driver;
using BlazorSchedulerApp.Models;

namespace BlazorSchedulerApp.Services
{
    /// <summary>
    /// Service class for MongoDB database operations on Events collection.
    /// Handles all CRUD operations for Scheduler events/appointments.
    /// </summary>
    public class MongoDBService
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<AppointmentData> _collection;

        /// <summary>
        /// Initializes a new instance of MongoDBService with MongoDB connection.
        /// </summary>
        /// <param name="configuration">Configuration containing MongoDB connection string</param>
        public MongoDBService(IConfiguration configuration)
        {
            // Get connection string from appsettings.json
            var connectionString = configuration.GetConnectionString("MongoDB");
            
            // Initialize MongoDB client
            _mongoClient = new MongoClient(connectionString);
            
            // Get database reference
            _database = _mongoClient.GetDatabase("EventManagementDB");
            
            // Get collection reference
            _collection = _database.GetCollection<AppointmentData>("Events");
        }

        /// <summary>
        /// Retrieves all events from the database.
        /// Converts UTC times to local time for Scheduler display.
        /// </summary>
        /// <returns>List of all events</returns>
        public async Task<List<AppointmentData>> GetEventsAsync()
        {
            try
            {
                var events = await _collection.Find(new BsonDocument()).ToListAsync();

                // Convert UTC times to local time for Syncfusion Scheduler display
                foreach (var appointment in events)
                {
                    appointment.StartTime = ConvertToLocal(appointment.StartTime);
                    appointment.EndTime = ConvertToLocal(appointment.EndTime);
                }
                return events;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching events: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a specific event by its ID.
        /// </summary>
        /// <param name="id">The event ID to retrieve</param>
        /// <returns>The event if found, null otherwise</returns>
        public async Task<AppointmentData?> GetEventByIdAsync(int id)
        {
            try
            {
                var filter = Builders<AppointmentData>.Filter.Eq(e => e.Id, id);
                var appointment = await _collection.Find(filter).FirstOrDefaultAsync();
                
                if (appointment != null)
                {
                    // Convert UTC times to local time for display
                    appointment.StartTime = ConvertToLocal(appointment.StartTime);
                    appointment.EndTime = ConvertToLocal(appointment.EndTime);
                }
                
                return appointment;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching event with ID {id}: {ex.Message}");
            }
        }

        /// <summary>
        /// Inserts a new event into the database.
        /// Automatically generates a unique event ID if not provided.
        /// </summary>
        /// <param name="appointment">The event to insert</param>
        /// <returns>The inserted event with generated ID</returns>
        public async Task<AppointmentData> InsertEventAsync(AppointmentData appointment)
        {
            try
            {
                // Reset MongoDB _id to let database generate a new one
                appointment._id = null;
                
                // Insert into MongoDB
                await _collection.InsertOneAsync(appointment);
                return appointment;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting event: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing event in the database.
        /// </summary>
        /// <param name="id">The ID of the event to update</param>
        /// <param name="appointment">The updated event data</param>
        /// <returns>True if update was successful, false otherwise</returns>
        public async Task<bool> UpdateEventAsync(int id, AppointmentData appointment)
        {
            try
            {
                var filter = Builders<AppointmentData>.Filter.Eq(e => e.Id, id);
                var result = await _collection.ReplaceOneAsync(filter, appointment);
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating event with ID {id}: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an event from the database.
        /// </summary>
        /// <param name="id">The ID of the event to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public async Task<bool> DeleteEventAsync(int id)
        {
            try
            {
                var filter = Builders<AppointmentData>.Filter.Eq(e => e.Id, id);
                var result = await _collection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting event with ID {id}: {ex.Message}");
            }
        }

        /// <summary>
        /// Converts a DateTime from UTC to local time.
        /// </summary>
        /// <param name="dateTime">The DateTime to convert (should be in UTC)</param>
        /// <returns>DateTime in local timezone</returns>
        private DateTime ConvertToLocal(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Utc)
            {
                // Convert from UTC to local time
                return dateTime.ToLocalTime();
            }
            else if (dateTime.Kind == DateTimeKind.Local)
            {
                // Already local
                return dateTime;
            }
            else
            {
                // Unspecified - assume UTC and convert to local
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc).ToLocalTime();
            }
        }
    }
}
```

**Explanation:**
- The `MongoDBService` class manages all MongoDB operations without requiring a DbContext (unlike Entity Framework Core).
- The `IMongoClient` represents the connection to MongoDB server.
- The `IMongoDatabase` represents a specific database (`EventManagementDB`).
- The `IMongoCollection<AppointmentData>` represents the `Events` collection.
- MongoDB uses **filter builders** to construct queries instead of LINQ expressions.
- The `BatchUpdateAsync` method handles multiple operations at once, essential for recurrence events.
- Time zone conversion ensures proper display of appointment times in the Scheduler.

The MongoDB service class has been successfully created.

---

### Step 6: Configure the Connection String

A connection string contains the information needed to connect the application to the MongoDB database, including the server address, port, and authentication details.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Add or update the `ConnectionStrings` section with the MongoDB connection details:

```json
{
  "ConnectionStrings": {
    "MongoDB": "mongodb://localhost:27017"
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

**Connection String Components:**

| Component | Description |
|-----------|-------------|
| mongodb:// | The MongoDB protocol prefix |
| localhost | The address of the MongoDB server (use `localhost` for local development) |
| 27017 | The MongoDB port number (default is `27017`) |

**Additional Connection String Options (if needed):**

For production environments with authentication:
```
mongodb://username:password@localhost:27017/EventManagementDB?authSource=admin
```

| Component | Description |
|-----------|-------------|
| username:password | MongoDB authentication credentials |
| /EventManagementDB | Specifies the default database |
| authSource=admin | Specifies the authentication database |

The database connection string has been configured successfully.

---

### Step 7: Register Services in Program.cs

The `Program.cs` file is where application services are registered and configured. This file must be updated to enable MongoDB service and Syncfusion components.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Add the following code:

```csharp
using BlazorSchedulerApp.Components;
using BlazorSchedulerApp.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register Syncfusion Blazor services
builder.Services.AddSyncfusionBlazor();

// Register MongoDB service for dependency injection
builder.Services.AddScoped<MongoDBService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

**Explanation:**
- `AddSyncfusionBlazor()` registers all Syncfusion Blazor services.
- `AddScoped<MongoDBService>()` registers the MongoDB service for dependency injection with scoped lifetime.
- Scoped lifetime means a new instance is created per user session.

The service registration has been completed successfully.

---

## Integrating Syncfusion Blazor Scheduler

### Step 1: Install and Configure Blazor Scheduler Component

Syncfusion is a library that provides pre-built UI components like Scheduler, which is used to display and manage appointments in a calendar view.

**Instructions:**

* The Syncfusion.Blazor.Schedule package was installed in **Step 2** of the previous section.
* Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using BlazorSchedulerApp.Models
@using BlazorSchedulerApp.Services
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data
@using System.Collections
```

* Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html    
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

For this project, the bootstrap5 theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Scheduler component's [getting‑started](https://blazor.syncfusion.com/documentation/scheduler/getting-started) documentation.

---

### Step 2: Update the Blazor Scheduler

The `Home.razor` component will display the appointment data in a Syncfusion Blazor Scheduler with Day, Week, Month, and Agenda views.

**Instructions:**

* Open the file named `Home.razor` in the `Components/Pages` folder.
* Add the following code to create a basic Scheduler:

```cshtml
@page "/"
@rendermode InteractiveServer
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data
@using BlazorSchedulerApp.Models
@using System.Collections

<PageTitle>Event Scheduler</PageTitle>

<div class="container-fluid mt-4">
    <SfSchedule TValue="AppointmentData"
                Height="550px">
        <ScheduleViews>
            <ScheduleView Option="View.Day"></ScheduleView>
            <ScheduleView Option="View.Week"></ScheduleView>
            <ScheduleView Option="View.Month"></ScheduleView>
            <ScheduleView Option="View.Agenda"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code {
    // CustomAdaptor class will be added in the next step
}
```

The Home component has been updated successfully with Scheduler.

---

### Step 3: Implement the CustomAdaptor

The **CustomAdaptor** is a critical component that bridges the Syncfusion Scheduler with MongoDB database operations. It handles all CRUD operations and batch updates for recurrence events.

**Instructions:**

* Continue in the `Home.razor` file.
* Add the complete **CustomAdaptor** class implementation:

```cshtml
@page "/"
@rendermode InteractiveServer
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data
@using BlazorSchedulerApp.Models
@using BlazorSchedulerApp.Services
@using System.Collections
@inject MongoDBService EventService

<div class="container-fluid mt-4">
    <SfSchedule TValue="AppointmentData"
                Height="550px"
                @bind-SelectedDate="SelectedDate">
        <ScheduleEventSettings TValue="AppointmentData">
            <SfDataManager Adaptor="Adaptors.CustomAdaptor"
                           AdaptorInstance="@typeof(CustomAdaptor)">
            </SfDataManager>
        </ScheduleEventSettings>

        <ScheduleViews>
            <ScheduleView Option="View.Day"></ScheduleView>
            <ScheduleView Option="View.Week"></ScheduleView>
            <ScheduleView Option="View.Month"></ScheduleView>
            <ScheduleView Option="View.Agenda"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code {
    public DateTime SelectedDate { get; set; } = DateTime.Today;

    // Initialize static bridge BEFORE first render
    protected override void OnInitialized()
    {
        CustomAdaptor.StaticEventService = EventService;
    }

    public class CustomAdaptor : DataAdaptor
    {
        // Static bridge because AdaptorInstance uses parameterless construction
        public static MongoDBService? StaticEventService { get; set; }

        // ---------------------- READ ----------------------
        /// <summary>
        /// Retrieves all appointments from MongoDB.
        /// Called when Scheduler loads or refreshes data.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dm, string? key = null)
        {
            if (StaticEventService == null)
                throw new Exception("EventService not initialized.");

            var appointments = await StaticEventService.GetEventsAsync();
            return appointments;
        }

        // ---------------------- INSERT ----------------------
        /// <summary>
        /// Inserts a new appointment into MongoDB.
        /// Called when user creates a new event in Scheduler.
        /// </summary>
        public override async Task<object> InsertAsync(DataManager dm, object data, string? key = null)
        {
            if (StaticEventService == null)
                throw new Exception("EventService not initialized.");

            var appointment = data as AppointmentData ?? 
                throw new ArgumentException("Invalid event insert payload.");

            var created = await StaticEventService.InsertEventAsync(appointment);
            return created;
        }

        // ---------------------- UPDATE ----------------------
        /// <summary>
        /// Updates an existing appointment in MongoDB.
        /// Called when user modifies a single event in Scheduler.
        /// </summary>
        public override async Task<object> UpdateAsync(DataManager dm, object data, 
            string keyField, string? key = null)
        {
            if (StaticEventService == null)
                throw new Exception("EventService not initialized.");

            var appointment = data as AppointmentData ?? 
                throw new ArgumentException("Invalid event update payload.");

            await StaticEventService.UpdateEventAsync(appointment.Id, appointment);
            return appointment;
        }

        // ---------------------- REMOVE ----------------------
        /// <summary>
        /// Deletes an appointment from MongoDB.
        /// Called when user deletes an event in Scheduler.
        /// </summary>
        public override async Task<object> RemoveAsync(DataManager dm, object id, 
            string keyField, string? key = null)
        {
            if (StaticEventService == null)
                throw new Exception("EventService not initialized.");

            int eventId = id switch
            {
                int i => i,
                long l => (int)l,
                string s when int.TryParse(s, out var v) => v,
                _ => throw new ArgumentException("Invalid key type for delete.")
            };

            await StaticEventService.DeleteEventAsync(eventId);
            return id;
        }

        // ---------------------- BATCH UPDATE ----------------------
        /// <summary>
        /// Handles multiple operations (insert, update, delete) at once.
        /// Essential for recurrence event operations:
        /// - Creating recurrence series
        /// - Editing single occurrence (adds exception event + updates parent)
        /// - Deleting occurrence (updates parent's RecurrenceException)
        /// - Editing entire series (updates all occurrences)
        /// </summary>
        public override async Task<object> BatchUpdateAsync(
            DataManager dm, 
            object changedRecords, 
            object addedRecords, 
            object deletedRecords, 
            string keyField, 
            string key, 
            int? dropIndex)
        {
            if (StaticEventService == null)
                throw new Exception("EventService not initialized.");

            // Convert objects to lists
            var changed = (changedRecords as IEnumerable<object>)?.Cast<AppointmentData>()?.ToList() ?? new();
            var added = (addedRecords as IEnumerable<object>)?.Cast<AppointmentData>()?.ToList() ?? new();
            var deleted = (deletedRecords as IEnumerable<object>)?.Cast<AppointmentData>()?.ToList() ?? new();

            // Process updates first
            foreach (var a in changed)
            {
                await StaticEventService.UpdateEventAsync(a.Id, a);
            }

            // Process inserts
            foreach (var a in added)
            {
                await StaticEventService.InsertEventAsync(a);
            }

            // Process deletes
            foreach (var a in deleted)
            {
                await StaticEventService.DeleteEventAsync(a.Id);
            }

            // Fetch all appointments after batch operation
            var data = await StaticEventService.GetEventsAsync();

            // Return DataResult with complete dataset
            return new DataResult { Result = data, Count = data.Count };
        }
    }
}
```

**CustomAdaptor Explanation:**

**Why Static Service?**
- Syncfusion's `AdaptorInstance` uses parameterless constructor instantiation.
- Dependency injection is not available in this context.
- Solution: Use a static property to bridge the service instance.

**CRUD Operations:**
1. **[ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_)**: Fetches all appointments when Scheduler loads.
2. **[InsertAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_)**: Creates new appointments (single or recurrence).
3. **[UpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_)**: Modifies existing single appointments.
4. **[RemoveAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_)**: Deletes single appointments.

**Batch Operations:**
- **[BatchUpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__)** is critical for recurrence events.
- Processes multiple add/update/delete operations atomically.

**Recurrence Event Scenarios:**

| Scenario | Operations Performed |
|----------|---------------------|
| Create recurrence series | Insert parent event with RecurrenceRule |
| Edit single occurrence | Update parent (add to RecurrenceException) + Insert exception event (with RecurrenceID) |
| Delete single occurrence | Update parent (add to RecurrenceException) |
| Edit entire series | Update parent event's RecurrenceRule |
| Delete entire series | Delete parent event |

The CustomAdaptor has been successfully implemented with full recurrence support.

---

## Running the Application

### Step 1: Build and Run the Application

**Instructions:**

1. Open a terminal in Visual Studio or the project directory.
2. Run the following commands:

```powershell
dotnet build
dotnet run
```

Open a web browser and navigate to the URL shown in the terminal (typically `https://localhost:5001`).

### Step 2: Test CRUD Operations

**Test Individual Events:**

1. **Create Event**: Click on any time slot in the Scheduler to create a new appointment.
2. **Edit Event**: Click on an existing event and modify its details.
3. **Delete Event**: Click on an event and use the delete button.
4. **Drag & Drop**: Drag events to different time slots to reschedule.

**Test Recurrence Events:**

1. **Create Recurrence**: Create a new event and set recurrence options (e.g., "Daily", "Weekly").
2. **Edit Single Occurrence**: Open one occurrence and choose "Edit Event" (not "Edit Series").
3. **Edit Entire Series**: Open an occurrence and choose "Edit Series".
4. **Delete Single Occurrence**: Delete one occurrence while keeping the series.
5. **Delete Entire Series**: Delete all occurrences at once.

### Step 3: Verify MongoDB Data

**Instructions:**

1. Open MongoDB Compass.
2. Navigate to `EventManagementDB` → `Events` collection.
3. Verify that:
   - New events appear in the collection.
   - Updates are reflected in document fields.
   - Deleted events are removed from the collection.
   - Recurrence exception events have `RecurrenceID` pointing to parent.
   - Parent events have updated `RecurrenceException` field.

---

### Output Preview
Syncfusion Blazor Scheduler
![image illustrating Syncfusion Blazor Scheduler](./images/blazor-scheduler-mongodb-output.png)

MongoDB Records
![image illustrating Syncfusion Blazor Scheduler events in MongoDB](./images/blazor-scheduler-mongodb-db.png)

---

## Troubleshooting

This section lists common issues that may occur while integrating the Syncfusion Scheduler with MongoDB in a Blazor Web App, along with their possible causes and recommended solutions.

| Issue | Symptom | Resolution |
|------|--------|-----------|
| **Connection Failed** | Cannot connect to the MongoDB server | Ensure that the MongoDB service is running and verify that the connection string configured in the application is correct. |
| **Events Not Displaying** | Scheduler remains empty even though data exists in MongoDB | Validate that date and time values are correctly converted using `ConvertToLocal()` and confirm that the MongoDB event data follows the Scheduler model format. |
| **Recurrence Edit Not Working** | Edit dialog does not close after updating a single occurrence | Ensure that `BatchUpdateAsync` returns data in the expected format and that all updated records are properly saved to MongoDB. |
| **Time Zone Issues** | Events are displayed at incorrect times | Verify that date-time values are stored in UTC in MongoDB and that the correct time zone conversion logic is applied when binding data to the Scheduler. |

---

## Summary

This guide demonstrated how to:

1. Create a MongoDB database appointment management. [🔗](#step-1-create-the-database-and-collection-in-mongodb)
2. Create a Blazor Web App. [🔗](#step-2-create-a-blazor-web-app)
3. Install necessary NuGet packages for MongoDB.Driver and Syncfusion. [🔗](#step-3-install-required-nuget-packages)
4. Create data models with MongoDB attributes for document mapping. [🔗](#step-4-create-the-data-model)
5. Implement the MongoDB service class for data access. [🔗](#step-5-create-the-mongodb-service-class)
6. Configure connection strings and register services. [🔗](#step-6-configure-the-connection-string)
7. Integrate Syncfusion Blazor Scheduler. [🔗](#step-1-install-and-configure-blazor-scheduler-component)
8. Implement CustomAdaptor for MongoDB integration. [🔗](#step-3-implement-the-customadaptor)
9. Test and verify all functionalities. [🔗](#step-1-build-and-run-the-application)

The application now provides a complete solution for managing appointments and schedules with a modern, user-friendly interface powered by MongoDB's flexible document database and Syncfusion's powerful Blazor Scheduler component.

<br>

> Please find the sample in this [GitHub location](https://github.com/SyncfusionExamples/How-to-integrate-Syncfusion-Blazor-Scheduler-with-MongoDB.git)

## Additional Resources

- [Syncfusion Blazor Scheduler Demos](https://blazor.syncfusion.com/demos/scheduler/overview)
- [Syncfusion Blazor Scheduler Documentation](https://blazor.syncfusion.com/documentation/scheduler/getting-started)
- [MongoDB.Driver Documentation](https://www.mongodb.com/docs/drivers/csharp/)
- [Blazor Server Documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/)