---
layout: post
title: PostgreSQL Data Binding in Blazor Scheduler Component | Syncfusion
description: Learn about consuming data from PostgreSQL Server and binding it to Syncfusion Blazor Scheduler Component, and performing CRUD operations.
platform: Blazor
control: Scheduler
documentation: ug
---

# Binding data from PostgreSQL Server using an API service

This section explains how to retrieve data from a PostgreSQL Server database through an API service and bind it to the Syncfusion® Blazor Scheduler component.

## Creating an API service

### Create an ASP.NET Core Web API Project

Create a new Web API project for handling database operations.

**Using .NET CLI:**
```bash
dotnet new webapi -n WebService
cd WebService
```

**Using Visual Studio 2022:**
1. File → New → Project
2. Select **ASP.NET Core Web API**
3. Name: **WebService**
4. Framework: **.NET 8.0**
5. Configure for HTTPS: **Yes**
6. Enable OpenAPI support: **Yes**


### Install NuGet Packages for Web API
Install PostgreSQL and related packages:

```bash
dotnet add package Npgsql
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.OpenApi
dotnet add package Swashbuckle.AspNetCore
```

### Create the Database and Table

Create the database and appointments table using pgAdmin or psql:

```sql
    -- Create database
    CREATE DATABASE "SchedulerEvents";

    -- Connect to database
    \c SchedulerEvents

    -- Create appointments table
    CREATE TABLE public."Appointments" (
        "Id" SERIAL PRIMARY KEY,
        "Subject" VARCHAR(200) NOT NULL DEFAULT 'Add Title',
        "StartTime" TIMESTAMP NOT NULL,
        "EndTime" TIMESTAMP NOT NULL,
        "Location" VARCHAR(200),
        "Description" VARCHAR(500),
        "IsAllDay" BOOLEAN NOT NULL DEFAULT FALSE,
        "RecurrenceRule" VARCHAR(255),
        "RecurrenceException" TEXT,
        "RecurrenceID" INTEGER
    );
```


### Configure CORS (Cross-Origin Resource Sharing)

To allow the Blazor application to communicate with the Web API, configure CORS in the **Program.cs** file of the Web API project.

Open **Program.cs** Replace the following code:

{% tabs %}
{% highlight csharp tabtitle="Program.cs" %}
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS for Blazor client
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy =>
        {
            policy.WithOrigins("https://localhost:7121", "http://localhost:5171")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorClient");

app.UseAuthorization();

app.MapControllers();

app.Run();

{% endhighlight %}
{% endtabs %}

> **Important**: Update the URLs in `WithOrigins()` to match your Blazor application's actual ports. You can find these ports in the **Properties/launchSettings.json** file of your Blazor project.

> **Note**: For production environments, replace `AllowAnyHeader()` and `AllowAnyMethod()` with specific headers and methods, and use your actual domain instead of localhost.


### Create an API Controller
Add a controller named **SchedulerController.cs** under the **Controllers** folder. This controller will handle data communication between the PostgreSQL database and the Blazor Scheduler component.

### Implement Data Retrieval Logic
Use `NpgsqlConnection`, `NpgsqlCommand`, and `NpgsqlDataAdapter` to execute queries and fetch data from PostgreSQL. Populate the data into a `DataTable` and convert it into a strongly typed collection.


{% tabs %}
{% highlight csharp tabtitle="SchedulerController.cs" %}

using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Globalization;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchedulerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SchedulerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public class Appointment
        {
            [Key]
            public int? Id { get; set; }
            public string? Subject { get; set; }
            public DateTime? StartTime { get; set; }
            public DateTime? EndTime { get; set; }
            public string? Location { get; set; }
            public string? Description { get; set; }
            public bool? IsAllDay { get; set; }
            public string? RecurrenceRule { get; set; }
            public string? RecurrenceException { get; set; }
            public int? RecurrenceID { get; set; }
        }

        public class BatchModel
        {
            public List<Appointment>? Added { get; set; }
            public List<Appointment>? Changed { get; set; }
            public List<Appointment>? Deleted { get; set; }
        }

        /// <summary>
        /// Get all appointments - Scheduler calls this to load data
        /// Note: Scheduler UrlAdaptor expects a direct array, NOT wrapped in { result, count }
        /// Note: UrlAdaptor sends POST requests even for read operations
        /// </summary>
        [HttpGet]
        [HttpPost]
        public IActionResult GetAppointments()
        {
            try
            {
                var appointments = FetchAppointmentsFromDatabase();
                // Return data directly as array for Scheduler (NOT wrapped like DataGrid)
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching appointments: {ex.Message}");
            }
        }

        /// <summary>
        /// Fetch appointments from PostgreSQL database
        /// </summary>
        private List<Appointment> FetchAppointmentsFromDatabase()
        {
            string ConnectionString = _configuration.GetConnectionString("PostgreSQLConnection") ?? "";
            string Query = "SELECT * FROM public.\"Appointments\" ORDER BY \"Id\"";
            
            using NpgsqlConnection Connection = new(ConnectionString);
            Connection.Open(); 
            using NpgsqlCommand Command = new(Query, Connection);
            using NpgsqlDataAdapter DataAdapter = new(Command);
            DataTable DataTable = new();
            DataAdapter.Fill(DataTable);
            
            var DataSource = (from DataRow Data in DataTable.Rows
                              select new Appointment()
                              {
                                  Id = Convert.ToInt32(Data["Id"]),
                                  Subject = Data["Subject"].ToString(),
                                  StartTime = Convert.ToDateTime(Data["StartTime"]),
                                  EndTime = Convert.ToDateTime(Data["EndTime"]),
                                  Location = Data["Location"]?.ToString(),
                                  Description = Data["Description"]?.ToString(),
                                  IsAllDay = Convert.ToBoolean(Data["IsAllDay"]),
                                  RecurrenceRule = string.IsNullOrEmpty(Data["RecurrenceRule"]?.ToString()) ? null : Data["RecurrenceRule"]?.ToString(),
                                  RecurrenceException = string.IsNullOrEmpty(Data["RecurrenceException"]?.ToString()) ? null : Data["RecurrenceException"]?.ToString(),
                                  RecurrenceID = Data["RecurrenceID"] == DBNull.Value || Convert.ToInt32(Data["RecurrenceID"]) == 0 ? null : Convert.ToInt32(Data["RecurrenceID"])
                              }).ToList();
            
            return DataSource;
        }

        /// <summary>
        /// Insert a new appointment into the database
        /// </summary>
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] JsonElement payload)
        {
            try
            {
                Appointment? appointment = null;
                if (payload.ValueKind == JsonValueKind.Object)
                {
                    var obj = ExtractRelevantJsonObject(payload);
                    appointment = BuildAppointmentFromJsonElement(obj);
                }

                if (appointment == null)
                    return BadRequest("Appointment data is required");

                string ConnectionString = _configuration.GetConnectionString("PostgreSQLConnection") ?? "";
                string Query = @"INSERT INTO public.""Appointments"" 
                    (""Subject"", ""StartTime"", ""EndTime"", ""Location"", ""Description"", ""IsAllDay"", ""RecurrenceRule"", ""RecurrenceException"", ""RecurrenceID"") 
                    VALUES (@Subject, @StartTime, @EndTime, @Location, @Description, @IsAllDay, @RecurrenceRule, @RecurrenceException, @RecurrenceID) 
                    RETURNING ""Id""";

                using NpgsqlConnection Connection = new(ConnectionString);
                Connection.Open();
                using NpgsqlCommand Command = new(Query, Connection);
                
                // Provide default values for ALL fields (database has NOT NULL constraints on all columns)
                Command.Parameters.AddWithValue("@Subject", string.IsNullOrEmpty(appointment.Subject) ? "Untitled Event" : appointment.Subject);
                Command.Parameters.AddWithValue("@StartTime", appointment.StartTime ?? DateTime.Now);
                Command.Parameters.AddWithValue("@EndTime", appointment.EndTime ?? DateTime.Now.AddHours(1));
                Command.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(appointment.Location) ? "" : appointment.Location);
                Command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(appointment.Description) ? "" : appointment.Description);
                Command.Parameters.AddWithValue("@IsAllDay", appointment.IsAllDay ?? false);
                Command.Parameters.AddWithValue("@RecurrenceRule", string.IsNullOrEmpty(appointment.RecurrenceRule) ? "" : appointment.RecurrenceRule);
                Command.Parameters.AddWithValue("@RecurrenceException", string.IsNullOrEmpty(appointment.RecurrenceException) ? "" : appointment.RecurrenceException);
                Command.Parameters.AddWithValue("@RecurrenceID", appointment.RecurrenceID ?? 0);

                var newId = Command.ExecuteScalar();
                appointment.Id = Convert.ToInt32(newId);

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Update an existing appointment in the database
        /// </summary>
        [HttpPost("Update")]
        public IActionResult Update([FromBody] JsonElement payload)
        {
            try
            {
                Appointment? appointment = null;
                if (payload.ValueKind == JsonValueKind.Object)
                {
                    var obj = ExtractRelevantJsonObject(payload);
                    appointment = BuildAppointmentFromJsonElement(obj);
                }

                if (appointment == null)
                    return BadRequest("Appointment data is required");

                string ConnectionString = _configuration.GetConnectionString("PostgreSQLConnection") ?? "";
                string Query = @"UPDATE public.""Appointments"" 
                    SET ""Subject"" = @Subject, ""StartTime"" = @StartTime, ""EndTime"" = @EndTime, 
                        ""Location"" = @Location, ""Description"" = @Description, ""IsAllDay"" = @IsAllDay,
                        ""RecurrenceRule"" = @RecurrenceRule, ""RecurrenceException"" = @RecurrenceException, 
                        ""RecurrenceID"" = @RecurrenceID 
                    WHERE ""Id"" = @Id";

                using NpgsqlConnection Connection = new(ConnectionString);
                Connection.Open();
                using NpgsqlCommand Command = new(Query, Connection);
                
                Command.Parameters.AddWithValue("@Id", appointment.Id ?? 0);
                // Provide default values for ALL fields (database has NOT NULL constraints on all columns)
                Command.Parameters.AddWithValue("@Subject", string.IsNullOrEmpty(appointment.Subject) ? "Untitled Event" : appointment.Subject);
                Command.Parameters.AddWithValue("@StartTime", appointment.StartTime ?? DateTime.Now);
                Command.Parameters.AddWithValue("@EndTime", appointment.EndTime ?? DateTime.Now.AddHours(1));
                Command.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(appointment.Location) ? "" : appointment.Location);
                Command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(appointment.Description) ? "" : appointment.Description);
                Command.Parameters.AddWithValue("@IsAllDay", appointment.IsAllDay ?? false);
                Command.Parameters.AddWithValue("@RecurrenceRule", string.IsNullOrEmpty(appointment.RecurrenceRule) ? "" : appointment.RecurrenceRule);
                Command.Parameters.AddWithValue("@RecurrenceException", string.IsNullOrEmpty(appointment.RecurrenceException) ? "" : appointment.RecurrenceException);
                Command.Parameters.AddWithValue("@RecurrenceID", appointment.RecurrenceID ?? 0);

                Command.ExecuteNonQuery();

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete an appointment from the database
        /// </summary>
        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] JsonElement payload)
        {
            try
            {
                int? appointmentId = null;
                if (payload.ValueKind == JsonValueKind.Number && payload.TryGetInt32(out var num))
                {
                    appointmentId = num;
                }
                else if (payload.ValueKind == JsonValueKind.Object)
                {
                    var obj = ExtractRelevantJsonObject(payload);
                    var appt = BuildAppointmentFromJsonElement(obj);
                    appointmentId = appt?.Id;
                }

                if (appointmentId == null)
                    return BadRequest("Appointment ID is required");

                string ConnectionString = _configuration.GetConnectionString("PostgreSQLConnection") ?? "";
                string Query = @"DELETE FROM public.""Appointments"" WHERE ""Id"" = @Id";

                using NpgsqlConnection Connection = new(ConnectionString);
                Connection.Open();
                using NpgsqlCommand Command = new(Query, Connection);
                
                Command.Parameters.AddWithValue("@Id", appointmentId.Value);
                Command.ExecuteNonQuery();

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Helper: build Appointment from arbitrary JSON payload (case-insensitive keys)
        private Appointment? BuildAppointmentFromJsonElement(JsonElement elem)
        {
            if (elem.ValueKind != JsonValueKind.Object)
                return null;

            var appt = new Appointment();

            foreach (var prop in elem.EnumerateObject())
            {
                var name = prop.Name;
                var value = prop.Value;

                if (string.Equals(name, "Id", StringComparison.OrdinalIgnoreCase))
                {
                    if (value.ValueKind == JsonValueKind.Number && value.TryGetInt32(out var id))
                        appt.Id = id;
                    else if (value.ValueKind == JsonValueKind.String && int.TryParse(value.GetString(), out var id2))
                        appt.Id = id2;
                }
                else if (string.Equals(name, "Subject", StringComparison.OrdinalIgnoreCase))
                {
                    appt.Subject = value.GetString();
                }
                else if (string.Equals(name, "Location", StringComparison.OrdinalIgnoreCase))
                {
                    appt.Location = value.GetString();
                }
                else if (string.Equals(name, "Description", StringComparison.OrdinalIgnoreCase))
                {
                    appt.Description = value.GetString();
                }
                else if (string.Equals(name, "IsAllDay", StringComparison.OrdinalIgnoreCase))
                {
                    if (value.ValueKind == JsonValueKind.True || value.ValueKind == JsonValueKind.False)
                        appt.IsAllDay = value.GetBoolean();
                    else if (value.ValueKind == JsonValueKind.String && bool.TryParse(value.GetString(), out var b))
                        appt.IsAllDay = b;
                }
                else if (string.Equals(name, "RecurrenceRule", StringComparison.OrdinalIgnoreCase))
                {
                    appt.RecurrenceRule = value.GetString();
                }
                else if (string.Equals(name, "RecurrenceException", StringComparison.OrdinalIgnoreCase))
                {
                    appt.RecurrenceException = value.GetString();
                }
                else if (string.Equals(name, "RecurrenceID", StringComparison.OrdinalIgnoreCase) || string.Equals(name, "RecurrenceId", StringComparison.OrdinalIgnoreCase))
                {
                    if (value.ValueKind == JsonValueKind.Number && value.TryGetInt32(out var rid))
                        appt.RecurrenceID = rid;
                    else if (value.ValueKind == JsonValueKind.String && int.TryParse(value.GetString(), out var rid2))
                        appt.RecurrenceID = rid2;
                }
                else if (string.Equals(name, "StartTime", StringComparison.OrdinalIgnoreCase) || string.Equals(name, "Start", StringComparison.OrdinalIgnoreCase))
                {
                    if (TryParseDateFromJson(value, out var dt))
                        appt.StartTime = dt;
                }
                else if (string.Equals(name, "EndTime", StringComparison.OrdinalIgnoreCase) || string.Equals(name, "End", StringComparison.OrdinalIgnoreCase))
                {
                    if (TryParseDateFromJson(value, out var dt))
                        appt.EndTime = dt;
                }
            }

            return appt;
        }

        private static bool TryParseDateFromJson(JsonElement value, out DateTime result)
        {
            result = default;
            if (value.ValueKind == JsonValueKind.String)
            {
                var s = value.GetString();
                if (string.IsNullOrEmpty(s))
                    return false;

                // Handle "/Date(123456789)/" formats
                if (s.StartsWith("/Date(") && s.Contains(")"))
                {
                    var start = s.IndexOf("(") + 1;
                    var end = s.IndexOf(")");
                    var num = s.Substring(start, end - start);
                    if (long.TryParse(num, out var ms))
                    {
                        result = DateTimeOffset.FromUnixTimeMilliseconds(ms).UtcDateTime;
                        return true;
                    }
                }

                if (DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out var dt))
                {
                    result = dt;
                    return true;
                }
                if (DateTime.TryParse(s, out dt))
                {
                    result = dt;
                    return true;
                }

                return false;
            }

            if (value.ValueKind == JsonValueKind.Number)
            {
                if (value.TryGetInt64(out var ms))
                {
                    // treat as unix milliseconds
                    result = DateTimeOffset.FromUnixTimeMilliseconds(ms).UtcDateTime;
                    return true;
                }
                if (value.TryGetDouble(out var d))
                {
                    result = DateTimeOffset.FromUnixTimeMilliseconds((long)d).UtcDateTime;
                    return true;
                }
            }

            return false;
        }

        // Helper to unwrap common adaptor payloads to the inner object representing a single appointment
        private static JsonElement ExtractRelevantJsonObject(JsonElement elem)
        {
            if (elem.ValueKind != JsonValueKind.Object)
                return elem;

            // common property names that may wrap the real object
            if (elem.TryGetProperty("data", out var data))
            {
                if (data.ValueKind == JsonValueKind.Object)
                    return data;
                if (data.ValueKind == JsonValueKind.Array && data.GetArrayLength() > 0)
                    return data[0];
            }

            if (elem.TryGetProperty("value", out var value))
            {
                if (value.ValueKind == JsonValueKind.Object)
                    return value;
                if (value.ValueKind == JsonValueKind.Array && value.GetArrayLength() > 0)
                    return value[0];
            }

            if (elem.TryGetProperty("added", out var added) || elem.TryGetProperty("Added", out added))
            {
                if (added.ValueKind == JsonValueKind.Array && added.GetArrayLength() > 0)
                    return added[0];
            }

            if (elem.TryGetProperty("changed", out var changed) || elem.TryGetProperty("Changed", out changed))
            {
                if (changed.ValueKind == JsonValueKind.Array && changed.GetArrayLength() > 0)
                    return changed[0];
            }

            if (elem.TryGetProperty("requestType", out var req) && elem.TryGetProperty("data", out var dd))
            {
                if (dd.ValueKind == JsonValueKind.Object)
                    return dd;
            }

            // fallback to original element
            return elem;
        }

        /// <summary>
        /// Batch operations for multiple Insert/Update/Delete actions
        /// </summary>
        [HttpPost("Batch")]
        public IActionResult Batch([FromBody] BatchModel batch)
        {
            try
            {
                string ConnectionString = _configuration.GetConnectionString("PostgreSQLConnection") ?? "";

                // Handle Updates
                if (batch.Changed != null)
                {
                    foreach (var appointment in batch.Changed)
                    {
                        string Query = @"UPDATE public.""Appointments"" 
                            SET ""Subject"" = @Subject, ""StartTime"" = @StartTime, ""EndTime"" = @EndTime, 
                                ""Location"" = @Location, ""Description"" = @Description, ""IsAllDay"" = @IsAllDay,
                                ""RecurrenceRule"" = @RecurrenceRule, ""RecurrenceException"" = @RecurrenceException, 
                                ""RecurrenceID"" = @RecurrenceID 
                            WHERE ""Id"" = @Id";

                        using NpgsqlConnection Connection = new(ConnectionString);
                        Connection.Open();
                        using NpgsqlCommand Command = new(Query, Connection);
                        
                        Command.Parameters.AddWithValue("@Id", appointment.Id ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@Subject", appointment.Subject ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@StartTime", appointment.StartTime ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@EndTime", appointment.EndTime ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@Location", appointment.Location ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@Description", appointment.Description ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@IsAllDay", appointment.IsAllDay ?? false);
                        Command.Parameters.AddWithValue("@RecurrenceRule", appointment.RecurrenceRule ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@RecurrenceException", appointment.RecurrenceException ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@RecurrenceID", appointment.RecurrenceID ?? (object)DBNull.Value);

                        Command.ExecuteNonQuery();
                    }
                }

                // Handle Inserts
                if (batch.Added != null)
                {
                    foreach (var appointment in batch.Added)
                    {
                        string Query = @"INSERT INTO public.""Appointments"" 
                            (""Subject"", ""StartTime"", ""EndTime"", ""Location"", ""Description"", ""IsAllDay"", ""RecurrenceRule"", ""RecurrenceException"", ""RecurrenceID"") 
                            VALUES (@Subject, @StartTime, @EndTime, @Location, @Description, @IsAllDay, @RecurrenceRule, @RecurrenceException, @RecurrenceID)";

                        using NpgsqlConnection Connection = new(ConnectionString);
                        Connection.Open();
                        using NpgsqlCommand Command = new(Query, Connection);
                        
                        Command.Parameters.AddWithValue("@Subject", appointment.Subject ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@StartTime", appointment.StartTime ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@EndTime", appointment.EndTime ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@Location", appointment.Location ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@Description", appointment.Description ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@IsAllDay", appointment.IsAllDay ?? false);
                        Command.Parameters.AddWithValue("@RecurrenceRule", appointment.RecurrenceRule ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@RecurrenceException", appointment.RecurrenceException ?? (object)DBNull.Value);
                        Command.Parameters.AddWithValue("@RecurrenceID", appointment.RecurrenceID ?? (object)DBNull.Value);

                        Command.ExecuteNonQuery();
                    }
                }

                // Handle Deletes
                if (batch.Deleted != null)
                {
                    foreach (var appointment in batch.Deleted)
                    {
                        string Query = @"DELETE FROM public.""Appointments"" WHERE ""Id"" = @Id";

                        using NpgsqlConnection Connection = new(ConnectionString);
                        Connection.Open();
                        using NpgsqlCommand Command = new(Query, Connection);
                        
                        Command.Parameters.AddWithValue("@Id", appointment.Id ?? (object)DBNull.Value);
                        Command.ExecuteNonQuery();
                    }
                }

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}


{% endhighlight %}
{% endtabs %}

### Configuration
Add the PostgreSQL connection string to **appsettings.json**:

{% tabs %}
{% highlight csharp tabtitle="appsettings.json"%}
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "PostgreSQLConnection": "Host=localhost;Database=SchedulerEvents;Username=postgres;Password=your_password"
  }
}

{% endhighlight %}
{% endtabs %}

> **Important**: Replace `your_password` with your actual PostgreSQL password.

## Connecting Blazor Scheduler to an API service

Create a simple Blazor Scheduler component by following these steps. This section explains how to include the Blazor Scheduler component in a Blazor Web App using Visual Studio.

### Prerequisites

[System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

### Create a Blazor Web App

Create a new Blazor Web App for the UI:

**Using .NET CLI:**
```bash
dotnet new blazor -n BlazorSchedulerApp --interactivity Server
cd BlazorSchedulerApp
```

**Using Visual Studio 2022:**
1. File → New → Project
2. Select **Blazor Web App**
3. Name: **BlazorSchedulerApp**
4. Framework: **.NET 10.0**
5. Interactive render mode: **Server**
6. Interactivity location: **Per page/component**


### Install Syncfusion Packages
Open the NuGet Package Manager in Visual Studio (**Tools → NuGet Package Manager → Manage NuGet Packages for Solution**). Search and install the following packages:

- **Syncfusion.Blazor.Schedule**
- **Syncfusion.Blazor.Themes**

Alternatively, use **Using .NET CLI:**

Install Syncfusion Blazor Scheduler packages:

```bash
dotnet add package Syncfusion.Blazor.Schedule 
dotnet add package Syncfusion.Blazor.Themes 
```


> When using **WebAssembly** or **Auto** render modes in a Blazor Web App, install Syncfusion® Blazor component NuGet packages within the client project.

> Syncfusion® Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete list of available packages.

### Register Syncfusion Blazor service
Add the required namespaces in **~/_Imports.razor**:

```razor
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Schedule
```

For apps using **WebAssembly** or **Auto** (Server and WebAssembly) render modes, register the service in both **~/Program.cs** files.

{% tabs %}
{% highlight csharp tabtitle="Program.cs" %}

using Syncfusion.Blazor;
using BlazorApp.Components;
using BlazorApp.Services;

builder.Services.AddSyncfusionBlazor();

builder.Services.AddHttpClient<SchedulerDataService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5001/");
});

builder.Services.AddScoped<SchedulerDataService>();


{% endhighlight %}
{% endtabs %}


### Create Appointment Model

Create the model class matching the API structure:

{% tabs %}
{% highlight csharp tabtitle="Models/AppointmentData.cs" %}
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class AppointmentData
    {
        public int Id { get; set; }
        
        public string Subject { get; set; } = "AddTitle";
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public string? Location { get; set; }
        
        public string? Description { get; set; }
        
        public bool IsAllDay { get; set; }
        
        public string? RecurrenceRule { get; set; }
        
        public string? RecurrenceException { get; set; }
        
        public int? RecurrenceID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Important**: Use non-nullable `DateTime` for `StartTime` and `EndTime` as required by Syncfusion Scheduler.


### Step 11: Create HTTP Client Service

Create a service to communicate with the Web API:

{% tabs %}
{% highlight csharp tabtitle="Services/SchedulerDataService.cs" %}
using BlazorApp.Models;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class SchedulerDataService
    {
        private readonly HttpClient _httpClient;
        // Base URL pointing to the Web API endpoint - Update this to match your API's address and port
        private readonly string _baseUrl = "http://localhost:5001/api/Scheduler";

        public SchedulerDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get all appointments from the API
        /// </summary>
        public async Task<List<AppointmentData>> GetAppointmentsAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<AppointmentData>>(_baseUrl);
                if (response != null)
                {
                    // Ensure DateTime values are treated as unspecified (local time)
                    // Convert empty strings to null for recurrence fields
                    foreach (var appointment in response)
                    {
                        appointment.StartTime = DateTime.SpecifyKind(appointment.StartTime, DateTimeKind.Unspecified);
                        appointment.EndTime = DateTime.SpecifyKind(appointment.EndTime, DateTimeKind.Unspecified);
                        
                        // Convert empty strings to null to prevent recurrence icon display
                        if (string.IsNullOrWhiteSpace(appointment.RecurrenceRule))
                        {
                            appointment.RecurrenceRule = null;
                            appointment.RecurrenceException = null;
                            appointment.RecurrenceID = null; // Must be null for non-recurring events
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(appointment.RecurrenceException))
                                appointment.RecurrenceException = null;
                        }
                    }
                }
                return response ?? new List<AppointmentData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching appointments: {ex.Message}");
                return new List<AppointmentData>();
            }
        }

        /// <summary>
        /// Insert a new appointment
        /// </summary>
        public async Task<AppointmentData?> InsertAppointmentAsync(AppointmentData appointment)
        {
            try
            {
                // Ensure DateTime is unspecified before sending
                appointment.StartTime = DateTime.SpecifyKind(appointment.StartTime, DateTimeKind.Unspecified);
                appointment.EndTime = DateTime.SpecifyKind(appointment.EndTime, DateTimeKind.Unspecified);
                
                // Clean empty recurrence fields
                if (string.IsNullOrWhiteSpace(appointment.RecurrenceRule))
                    appointment.RecurrenceRule = null;
                if (string.IsNullOrWhiteSpace(appointment.RecurrenceException))
                    appointment.RecurrenceException = null;
                
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Insert", appointment);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<AppointmentData>();
                
                if (result != null)
                {
                    result.StartTime = DateTime.SpecifyKind(result.StartTime, DateTimeKind.Unspecified);
                    result.EndTime = DateTime.SpecifyKind(result.EndTime, DateTimeKind.Unspecified);
                    
                    // Clean empty recurrence fields
                    if (string.IsNullOrWhiteSpace(result.RecurrenceRule))
                        result.RecurrenceRule = null;
                    if (string.IsNullOrWhiteSpace(result.RecurrenceException))
                        result.RecurrenceException = null;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting appointment: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Update an existing appointment
        /// </summary>
        public async Task<AppointmentData?> UpdateAppointmentAsync(AppointmentData appointment)
        {
            try
            {
                // Ensure DateTime is unspecified before sending
                appointment.StartTime = DateTime.SpecifyKind(appointment.StartTime, DateTimeKind.Unspecified);
                appointment.EndTime = DateTime.SpecifyKind(appointment.EndTime, DateTimeKind.Unspecified);
                
                // Clean empty recurrence fields
                if (string.IsNullOrWhiteSpace(appointment.RecurrenceRule))
                    appointment.RecurrenceRule = null;
                if (string.IsNullOrWhiteSpace(appointment.RecurrenceException))
                    appointment.RecurrenceException = null;
                
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Update", appointment);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<AppointmentData>();
                
                if (result != null)
                {
                    result.StartTime = DateTime.SpecifyKind(result.StartTime, DateTimeKind.Unspecified);
                    result.EndTime = DateTime.SpecifyKind(result.EndTime, DateTimeKind.Unspecified);
                    
                    // Clean empty recurrence fields
                    if (string.IsNullOrWhiteSpace(result.RecurrenceRule))
                        result.RecurrenceRule = null;
                    if (string.IsNullOrWhiteSpace(result.RecurrenceException))
                        result.RecurrenceException = null;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating appointment: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Delete an appointment
        /// </summary>
        public async Task<bool> DeleteAppointmentAsync(int appointmentId)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Delete", appointmentId);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting appointment: {ex.Message}");
                return false;
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

Access the theme stylesheet and script from NuGet using Static Web Assets. Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in **~/Components/App.razor**:

{% tabs %}
{% highlight csharp tabtitle="App.razor" %}
<head>
    <link href="_content/Syncfusion.Blazor.Themes/tailwind3.css" rel="stylesheet" />
</head>

<body>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

> Refer to [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) for additional methods such as Static Web Assets, CDN, and CRG.

> Set the render mode to **InteractiveServer** or **InteractiveAuto** in the Blazor Web App configuration.

### Configure Scheduler with UrlAdaptor
The DataManager component supports multiple adaptors for remote data binding. For API services, set the **Adaptor** property to **Adaptors.UrlAdaptor** and specify the service endpoint in the **Url** property.

{% tabs %}
{% highlight csharp tabtitle="Home.razor" %}
@page "/"
@using BlazorApp.Models
@using BlazorApp.Services
@using Syncfusion.Blazor.Schedule
@inject SchedulerDataService DataService
@rendermode InteractiveServer

<PageTitle>Scheduler</PageTitle>

<div class="scheduler-container">
    <SfSchedule TValue="AppointmentData" 
                @ref="ScheduleObj"
                Height="650px" 
                @bind-SelectedDate="@CurrentDate"
                @bind-CurrentView="@CurrentView"
                Timezone="Local"
                ShowQuickInfo="true">
        <ScheduleEvents TValue="AppointmentData" 
                       ActionCompleted="OnActionCompleted">
        </ScheduleEvents>
        <ScheduleEventSettings TValue="AppointmentData"
                               DataSource="@DataSource">
        </ScheduleEventSettings>
        <ScheduleViews>
            <ScheduleView Option="View.Day"></ScheduleView>
            <ScheduleView Option="View.Week"></ScheduleView>
            <ScheduleView Option="View.WorkWeek"></ScheduleView>
            <ScheduleView Option="View.Month"></ScheduleView>
            <ScheduleView Option="View.Agenda"></ScheduleView>
        </ScheduleViews>
    </SfSchedule>
</div>

@code {
    private SfSchedule<AppointmentData>? ScheduleObj;
    private List<AppointmentData> DataSource = new();
    private string? statusMessage;
    private DateTime CurrentDate = new DateTime(2026, 2, 3);
    private View CurrentView = View.Week;

    protected override async Task OnInitializedAsync()
    {
        await LoadAppointments();
    }

    private async Task LoadAppointments()
    {
        try
        {
            DataSource = await DataService.GetAppointmentsAsync();
            Console.WriteLine($"Loaded {DataSource.Count} appointments");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    private async void OnActionCompleted(ActionEventArgs<AppointmentData> args)
    {
        try
        {
            statusMessage = null;

            if (args.ActionType == ActionType.EventCreate)
            {
                // Insert new appointment
                if (args.AddedRecords != null && args.AddedRecords.Count() > 0)
                {
                    foreach (var appointment in args.AddedRecords)
                    {
                        var result = await DataService.InsertAppointmentAsync(appointment);
                        if (result != null)
                        {
                            // Update the local appointment with the ID from the database
                            appointment.Id = result.Id;
                            statusMessage = $"Event '{appointment.Subject}' created successfully!";
                            Console.WriteLine($"Created appointment: {appointment.Subject} (ID: {appointment.Id})");
                        }
                        else
                        {
                            statusMessage = "Failed to create event.";
                        }
                    }
                    await LoadAppointments(); // Reload to sync with database
                    StateHasChanged();
                }
            }
            else if (args.ActionType == ActionType.EventChange)
            {
                // Update existing appointment
                if (args.ChangedRecords != null && args.ChangedRecords.Count() > 0)
                {
                    foreach (var appointment in args.ChangedRecords)
                    {
                        var result = await DataService.UpdateAppointmentAsync(appointment);
                        if (result != null)
                        {
                            statusMessage = $"Event '{appointment.Subject}' updated successfully!";
                            Console.WriteLine($"Updated appointment: {appointment.Subject} (ID: {appointment.Id})");
                        }
                        else
                        {
                            statusMessage = "Failed to update event.";
                        }
                    }
                    await LoadAppointments(); // Reload to sync with database
                    StateHasChanged();
                }
            }
            else if (args.ActionType == ActionType.EventRemove)
            {
                // Delete appointment
                if (args.DeletedRecords != null && args.DeletedRecords.Count() > 0)
                {
                    foreach (var appointment in args.DeletedRecords)
                    {
                        if (appointment.Id > 0)
                        {
                            var success = await DataService.DeleteAppointmentAsync(appointment.Id);
                            if (success)
                            {
                                statusMessage = $"Event '{appointment.Subject}' deleted successfully!";
                                Console.WriteLine($"Deleted appointment: {appointment.Subject} (ID: {appointment.Id})");
                            }
                            else
                            {
                                statusMessage = "Failed to delete event.";
                            }
                        }
                    }
                    await LoadAppointments(); // Reload to sync with database
                    StateHasChanged();
                }
            }
        }
        catch (Exception ex)
        {
            statusMessage = $"Operation failed: {ex.Message}";
            Console.WriteLine($"Error in OnActionCompleted: {ex.Message}");
            StateHasChanged();
        }
    }
}


{% endhighlight %}
{% endtabs %}

## Running the Application

### Start the Web API

Open a terminal and run the Web API:

```bash
cd WebService
dotnet run
```

The API will start on `http://localhost:5001` (or the port specified in `launchSettings.json`).

Verify the API is running by navigating to: `http://localhost:5001/swagger`

### Start the Blazor App

Open another terminal and run the Blazor app:

```bash
cd BlazorApp
dotnet run
```

The app will start on `https://localhost:7055` (or the port specified in `launchSettings.json`).

## Output Preview

The following screenshots demonstrate the completed application:

![Frontend Preview](./images/blazor-scheduler-postgresql-frontend.png)
*Image illustrating the Syncfusion Blazor Scheduler*

![Database Preview](./images/blazor-scheduler-postgresql-database.png)
*Image illustrating the events of Syncfusion Blazor Scheduler in PostgreSQL*

## Learn More

* [Syncfusion Blazor Scheduler Documentation](https://blazor.syncfusion.com/documentation/scheduler/getting-started)
