---
layout: post
title: Globalization in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Globalization in Blazor Gantt Chart Component

Add **UseRequestLocalization** middle-ware in the **Program.cs** file to get browser Culture Info.

Refer the following code to add configuration in Program.cs file

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

app.UseRequestLocalization();

```

## Localization

The **Localization** library allows you to localize default text content of the Gantt. The Gantt component has static text on some features (like task information text, context menu options, etc.) that can be changed to other cultures (Arabic, Deutsch, French, etc.).

Resource file (**.resx**) is used to translate the static text of the Gantt.

The Resource file is an XML file which contains the strings(key and value pairs) that you want to translate into different languages. You can also refer [Localization](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-7.0) link to know more about how to configure and use localization in the ASP.NET Core application framework.

* Add **.resx** file to [Resources](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-7.0) folder and enter the key value (Locale Keywords) in the **Name** column and the translated string in the **Value** column as follows.


Name |Value (in Deutsch culture)
-----|-----
Gantt_EmptyRecord | Keine Datensätze zum Anzeigen
Gantt_Id | Id
Gantt_Name | Name
Gantt_StartDate | Anfangsdatum
Gantt_EndDate | Enddatum
Gantt_Duration | Dauer
Gantt_Progress | Fortschritt
Gantt_Dependency | Abhängigkeit
Gantt_Notes | Anmerkungen
Gantt_BaselineStartDate | Basisstartdatum
Gantt_BaselineEndDate | Basisenddatum
Gantt_Type | Art
Gantt_Offset | Versatz
Gantt_ResourceName | Ressourcen
Gantt_ResourceID | Ressourcen-ID
Gantt_Day | Tag
Gantt_Hour | Stunde
Gantt_Minute | Minute
Gantt_Days | Tage
Gantt_Hours | Std
Gantt_Minutes | Minuten
Gantt_GeneralTab | Allgemeines
Gantt_CustomTab | Benutzerdefinierte Spalten
Gantt_WriteNotes | Notizen schreiben
Gantt_AddDialogTitle | Neue Aufgabe
Gantt_EditDialogTitle | Aufgabeninformationen
Gantt_SaveButton | speichern
Gantt_Add | Hinzufügen
Gantt_Edit | Bearbeiten
Gantt_Update | Aktualisieren
Gantt_Delete | Löschen
Gantt_Cancel | Stornieren
Gantt_Search | Suchen
Gantt_Task | Aufgabe
Gantt_Tasks | Aufgaben
Gantt_ZoomIn | Hineinzoomen
Gantt_ZoomOut | Rauszoomen
Gantt_ZoomToFit | Zoomen Sie
Gantt_ExcelExport | Excel-Export
Gantt_CsvExport | CSV-Export
Gantt_ExpandAll | Alle erweitern
Gantt_CollapseAll | Alles einklappen
Gantt_NextTimeSpan | Nächste Zeitspanne
Gantt_PrevTimeSpan | Vorheriger Zeitraum
Gantt_OkText | Ok
Gantt_ConfirmDelete | Möchten Sie den Datensatz wirklich löschen?
Gantt_From | Aus
Gantt_To | Zu
Gantt_TaskLink | Aufgabenlink
Gantt_Lag | Verzögerung
Gantt_Start | Start
Gantt_Finish | Beenden
Gantt_EnterValue | Geben Sie den Wert ein
Gantt_TaskBeforePredecessor_FS | Sie haben '{0}' verschoben, um vor dem Ende von '{1}' zu beginnen, und die beiden Aufgaben sind miteinander verknüpft. Infolgedessen können die Links nicht beachtet werden. Wählen Sie unten eine Aktion aus, die ausgeführt werden soll
Gantt_TaskAfterPredecessor_FS | Sie haben '{0}' von '{1}' entfernt und die beiden Aufgaben sind miteinander verknüpft. Infolgedessen können die Links nicht beachtet werden. Wählen Sie unten eine Aktion aus, die ausgeführt werden soll
Gantt_TaskBeforePredecessor_SS | Sie haben '{0}' verschoben, um vor dem Start von '{1}' zu beginnen, und die beiden Aufgaben sind miteinander verknüpft. Infolgedessen können die Links nicht beachtet werden. Wählen Sie unten eine Aktion aus, die ausgeführt werden soll
Gantt_TaskAfterPredecessor_SS | Sie haben '{0}' verschoben, um nach dem Start von '{1}' zu beginnen, und die beiden Aufgaben sind miteinander verbunden. Infolgedessen können die Links nicht beachtet werden. Wählen Sie unten eine Aktion aus, die ausgeführt werden soll
Gantt_TaskBeforePredecessor_FF | Sie haben '{0}' verschoben, um den Vorgang zu beenden, bevor '{1}' abgeschlossen ist, und die beiden Aufgaben sind miteinander verknüpft. Infolgedessen können die Links nicht beachtet werden. Wählen Sie unten eine Aktion aus, die ausgeführt werden soll
Gantt_TaskBeforePredecessor_SF | Sie haben '{0}' von '{1}' zum Start verschoben und die beiden Aufgaben sind miteinander verbunden. Infolgedessen können die Links nicht beachtet werden. Wählen Sie unten eine Aktion aus, die ausgeführt werden soll
Gantt_TaskAfterPredecessor_SF | Sie haben '{0}' nach dem Start von '{1}' verschoben und die beiden Aufgaben sind miteinander verbunden. Infolgedessen können die Links nicht beachtet werden. Wählen Sie unten eine Aktion aus, die ausgeführt werden soll
Gantt_TaskInformation | Aufgabeninformationen
Gantt_DeleteTask | Aufgabe löschen
Gantt_DeleteDependency | Abhängigkeit löschen
Gantt_Convert | Konvertieren
Gantt_Save | Speichern
Gantt_Above | Darüber
Gantt_Below | Darunter
Gantt_Child | Kind
Gantt_Milestone | Meilenstein
Gantt_ToTask | Zur Aufgabe
Gantt_ToMilestone | Zum Meilenstein
Gantt_EventMarkers | Ereignismarkierungen
Gantt_LeftTaskLabel | Linke Aufgabenbezeichnung
Gantt_RightTaskLabel | Rechte Aufgabenbezeichnung
Gantt_TimelineCell | Zeitleistenzelle
Gantt_ConfirmPredecessorDelete | Möchten Sie den Abhängigkeitslink wirklich entfernen?
Gantt_Indent | Einrücken
Gantt_Outdent | Ausrücken
Gantt_SS | SS
Gantt_SF | SB
Gantt_FS | BS
Gantt_FF | BB

### Blazor server-side

The following examples demonstrate how to enable **Localization** for Gantt in server-side Blazor samples.

* Open the **Program.cs** file and add the below configuration as follows.

```csharp
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

builder.Services.AddSyncfusionBlazor();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // define the list of cultures your app will support
    var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("de")
                };
    // set the default culture
    options.DefaultRequestCulture = new RequestCulture("de");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>() {
                 new QueryStringRequestCultureProvider() // Here, You can also use other localization provider
                };
});
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SampleLocalizer));

```

N> Add [UseRequestLocalization()](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-7.0#localization-middleware) middle-ware in Configure method in **Program.cs** file to get browser Culture Information.


* Then, write a **class** by inheriting **ISyncfusionStringLocalizer** interface and override the Manager property to get the resource file details from the application end.

```csharp
using Syncfusion.Blazor;

namespace BlazorServer
{
    public class SampleLocalizer : ISyncfusionStringLocalizer
    {

        public string GetText(string key)
        {
            return this.ResourceManager.GetString(key);
        }

        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                return BlazorServer.Resources.SfResources.ResourceManager;
            }
        }
    }
}
```

N> BlazorServer denotes the ApplicationNameSpace of your project.

* Finally, specify the culture for Gantt using `Locale` property.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt ID="GanttContainer" @ref="Gantt" Locale="de" AllowExcelExport="true" Toolbar="@(new List<string>() { "Add", "Cancel","CollapseAll", "Delete", "Edit", "ExpandAll","NextTimeSpan", "PrevTimeSpan", "Search", "Update", "Indent", "Outdent","ExcelExport", "CsvExport" })" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId"></GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task Id" Width="150"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="StartDate" Width="250"></GanttColumn>
        <GanttColumn Field="Duration" Width="150" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="250"></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowEditing="true" AllowAdding="true" AllowTaskbarEditing="true"></GanttEditSettings>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 23), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 23), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

### Blazor webAssembly

The following examples demonstrate how to enable **Localization** for Gantt in client-side Blazor samples.

* Open the **Program.cs** file and add the below configuration in the **Main** function as follows.

```csharp
using Syncfusion.Blazor;
using System.Globalization;

namespace ClientApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSyncfusionBlazor();


            // Register the Syncfusion locale service to customize the SyncfusionBlazor component locale culture.
            builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

            // Set the default culture of the application.
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de");

            await builder.Build().RunAsync();
        }
    }
}
```

* Then, create a **~/Shared/SyncfusionLocalizer.cs** file and implement **ISyncfusionStringLocalizer** interface to the class and override the ResourceManager property to get the resource file details from the application end.

```csharp
using Syncfusion.Blazor;

public class SyncfusionLocalizer : ISyncfusionStringLocalizer
{
    // To get the locale key from mapped resources file.
    public string GetText(string key)
    {
        return this.ResourceManager.GetString(key);
    }

    // To access the resource file and get the exact value for locale key.

    public System.Resources.ResourceManager ResourceManager
    {
        get
        {
            // Replace the ApplicationNamespace with your application name.
            return ClientApplication.Resources.SfResources.ResourceManager;
        }
    }
}
```

N> ClientApplication denotes the ApplicationNameSpace of your project.

* Now, Specify the culture for Gantt using `Locale` property.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt ID="GanttContainer" @ref="Gantt" Locale="de" AllowExcelExport="true" Toolbar="@(new List<string>() { "Add", "Cancel",  "CollapseAll", "Delete", "Edit", "ExpandAll", "NextTimeSpan", "PrevTimeSpan", "Search", "Update", "Indent", "Outdent","ExcelExport", "CsvExport" })" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId"></GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task Id" Width="150"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="StartDate" Width="250"></GanttColumn>
        <GanttColumn Field="Duration" Width="150" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="250"></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowEditing="true" AllowAdding="true" AllowTaskbarEditing="true"></GanttEditSettings>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 23), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 23), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

## Internationalization

* The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor UI components are specific to the `American English (en-US)` culture by default. It utilizes the `Blazor Internationalization` package to parse and format the number and date objects based on the chosen culture.

* Suppose, if you want to change any specific culture, then add the corresponding culture resource (`.resx`) file by using the below reference.

[Changing culture and Adding Resx file in the application](https://blazor.syncfusion.com/documentation/gantt-chart/globalization#localization)

## Right to left (RTL)

RTL provides an option to switch the text direction and layout of the Gantt component from right to left. It improves the user experiences and accessibility for users who use right-to-left languages (Arabic, Farsi, Urdu, etc.). In the following sample, **EnableRtl** property is used to enable RTL in the Gantt.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt ID="GanttContainer" @ref="Gantt" EnableRtl="true" DataSource="@TaskCollection" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId"></GanttTaskFields>
    <GanttEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" AllowTaskbarEditing="true"></GanttEditSettings>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 23), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 23), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5) to know how to render and configure the gantt.

## See also

* [How to enable RTL based on Syncfusion<sup style="font-size:70%">&reg;</sup> blazor service](https://blazor.syncfusion.com/documentation/common/right-to-left#enable-rtl-for-all-components)