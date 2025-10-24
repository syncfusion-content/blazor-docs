---
layout: post
title: Globalization in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Globalization in Blazor Gantt Chart component

The Syncfusion Blazor Gantt Chart component provides a feature known as Globalization (global and local), which makes the application more accessible and useful for individuals from different regions and language backgrounds. You have the ability to view data in your preferred language and format, resulting in an enhanced overall experience.

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

You can customize the culture settings of Syncfusion® Blazor UI components using the Blazor `Internationalization` package, which formats numbers and dates based on the selected culture. By default, components use `en-US`, and to switch to another culture, you need to add the corresponding `.resx` resource file to your application.

[Changing culture and Adding Resx file in the application](https://blazor.syncfusion.com/documentation/gantt-chart/globalization#localization)


## Right to left (RTL)

You can enable right-to-left layout and text direction in the Gantt component using the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableRtl) property, which improves accessibility and user experience for languages such as Arabic, Farsi, and Urdu.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt EnableRtl="true" DataSource="@TaskCollection" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID"></GanttTaskFields>
    <GanttEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" AllowTaskbarEditing="true"></GanttEditSettings>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBesDVrThGvRASc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5) to know how to render and configure the gantt.

## See also

* [How to enable RTL based on Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service?](https://blazor.syncfusion.com/documentation/common/right-to-left#enable-rtl-for-all-components)