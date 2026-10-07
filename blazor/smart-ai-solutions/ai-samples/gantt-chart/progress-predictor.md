---
layout: post
title: Progress Predictor with Blazor Gantt Chart and Azure OpenAI | Syncfusion
description: Learn how to integrate Syncfusion Blazor Gantt Chart with Azure OpenAI to predict milestone completion dates and project completion timelines using historical and current project data.
platform: Blazor
control: AI Integration
documentation: ug
keywords: Blazor Gantt Chart, Azure OpenAI, Progress Predictor, Project Forecasting, Milestone Prediction, Syncfusion Blazor AI
---

# Progress Predictor with Blazor Gantt Chart and Azure OpenAI

This guide demonstrates how to use the [Syncfusion.Blazor.AI](https://www.fusion.Blazor.AI) package with the Syncfusion Blazor Gantt Chart to predict project milestones and completion dates using Azure OpenAI. The [Syncfusion.Blazor.AI](https://www.fusion.Blazor.AI) package enables integration with AI models to analyze project schedules, historical execution patterns, task dependencies, and progress information. This sample demonstrates how to forecast milestone completion dates and overall project completion timelines based on historical and current project data.

## Prerequisites

Ensure the following NuGet packages are installed based on the selected AI service.

### For Azure OpenAI

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

## Add stylesheet and script resources

Include the theme stylesheet and script from NuGet via [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) in the `<head>` of the main page:

- For **.NET 6** Blazor Server apps, add to **~/Pages/_Layout.cshtml**.
- For **.NET 8 or .NET 9 or .NET 10** Blazor Server apps, add to **~/Components/App.razor**.

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
<body>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

> Explore the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for methods to reference themes ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), or [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). Refer to the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic for different approaches to adding script references in your Blazor application.


## Configure Azure OpenAI

Deploy an Azure OpenAI Service resource and model as described in [Microsoft’s documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource). Obtain values for `azureOpenAIKey`, `azureOpenAIEndpoint`, and `azureOpenAIModel`.

- Install the required NuGet packages:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}

- Add the following configuration in **~/Program.cs** file in the Blazor Web App: 

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Syncfusion.Blazor.AI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

string azureOpenAIKey = "AZURE_OPENAI_KEY";
string azureOpenAIEndpoint = "AZURE_OPENAI_ENDPOINT";
string azureOpenAIModel = "AZURE_OPENAI_DEPLOYMENT";

AzureOpenAIClient azureClient =
    new AzureOpenAIClient(
        new Uri(azureOpenAIEndpoint),
        new ApiKeyCredential(azureOpenAIKey));

IChatClient chatClient =
    azureClient.GetChatClient(azureOpenAIModel)
               .AsIChatClient();

builder.Services.AddChatClient(chatClient);

builder.Services.AddSingleton<SyncfusionAIService>();
builder.Services.AddSingleton<AzureAIService>();

var app = builder.Build();

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

## Register Syncfusion Blazor Service

Add the Syncfusion Blazor service to the **~/Program.cs** file.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

## Integrate Gantt Chart with AI

The following code example shows how to integrate the Gantt Chart with AI to predict milestone completion dates and project completion timelines.

{% tabs %}
{% highlight C# tabtitle="Home.razor" %}

@inject AzureAIService OpenAIService
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using GanttChart.Components.Model
@using System.Text.Json
@using GanttChart.Components.Service
@using System.IO
@inject IJSRuntime JsInterop
<div class="col-lg-12 control-section" id="gantt-control-section">
    @if (showMessage)
    {
        <div>
            <SfButton CssClass="e-flat" IsPrimary="true" IconCss="e-icons e-refresh" IconPosition=@IconPosition.Right OnClick="Reload">Something went wrong.</SfButton>
        </div>
    }
    <div style="position: relative">
        <SfGantt @ref="Gantt" DataSource="@TaskCollection" Width="100%" TreeColumnIndex="1" WorkUnit="WorkUnit.Hour">
            <GanttTaskFields Dependency="Predecessor" Id="Id" Name="Name" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            ParentID="ParentId" Work="Work" TaskType="TaskType">
            </GanttTaskFields>
            <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GanttEditSettings>
            <GanttColumns>
                <GanttColumn Field="Id" HeaderText="ID" Visible="false"></GanttColumn>
                <GanttColumn Field="Name" HeaderText="Event Name" Width="250px"></GanttColumn>
                <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
                <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
                <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
            </GanttColumns>
            <GanttSplitterSettings Position="28%"> </GanttSplitterSettings>
            <SfToolbar ID="Gantt_Toolbar">
                <ToolbarItems>
                    <ToolbarItem>
                        <Template>
                            <SfButton IsPrimary ID="openAI" @onclick="OpenAIHandler">Predict milestone</SfButton>
                        </Template>
                    </ToolbarItem>
                </ToolbarItems>
            </SfToolbar>
            <GanttEventMarkers>
                @{
                    if (milestoneDates.Any())
                    {
                        foreach (var data in milestoneDates)
                        {
                            if (data.Key == "Project Completion date")
                            {
                                <GanttEventMarker Day=@data.Value Label=@(data.Key)
                                CssClass="e-gantt-custom-event-marker"></GanttEventMarker>
                            }
                            else
                            {
                                <GanttEventMarker Day=@data.Value Label=@(data.Key + " completion date")
                                CssClass="e-custom-event-marker"></GanttEventMarker>
                            }
                        }
                    }
                }
            </GanttEventMarkers>
        </SfGantt>
    </div>
</div>
@code {
    public SfGantt<TaskInfoModel> Gantt = new();
    public List<TaskInfoModel> TaskCollection { get; set; } = new();
    private bool showMessage;
    private Dictionary<string, string> riskAnalyzeContent = new();
    private Dictionary<string, string> riskAnalyzePriority = new();
    private Dictionary<string, DateTime> milestoneDates = new();
    protected override void OnInitialized()
    {
        TaskCollection = GanttDataModel.GetTaskCollection();
    }
    private string GeneratePrompt()
    {
        return @"You analyze the multiple year HistoricalTaskDataCollections and current TaskDataCollection to predict project completion dates and milestones based on current progress and historical trends. Ignore the null or empty values, and collection values based parent child mapping. Avoid json tags with your response. No other explanation or content to be returned."
        + @" HistoricalTaskDataCollections :" + GetHistoricalCollection() + @" TaskDataCollection: " + JsonSerializer.Serialize(TaskCollection) +
                    @"Generate a JSON object named 'TaskDetails' containing below keys:
- Key 'MilestoneTaskDate' with a list of milestone dates 'MilestoneDate' with 'TaskName' - task name. A milestone date is defined as the end date of tasks with a duration of 0 and only give current based milestone .
- Key 'ProjectCompletionDate' indicating the latest end date among all tasks.
- Key 'Summary' providing a summary of the project completion date and milestones.
        Here is the output JSON schema:
        {
      'TaskDetails': {
        'MilestoneTaskDate': [],
        'ProjectCompletionDate' : '',
        'Summary' : ''
        }
    }
Ensure milestones are defined correctly based on tasks with a duration of 0, and the project completion date reflects the latest end date of all tasks.
.";
    }
    private async Task Reload()
    {
        await JsInterop.InvokeVoidAsync("window.location.reload");
    }
    private async Task OpenAIHandler()
    {
        await Gantt.ShowSpinnerAsync();
        showMessage = false;
        milestoneDates = new();
        string AIPrompt = GeneratePrompt();
        string result = await OpenAIService.GetCompletionAsync(AIPrompt);
        try
        {
            if (result.StartsWith("```json"))
            {
                result = result.Replace("```json", "").Replace("```", "").Trim();
            }
            else if (result.StartsWith("```"))
            {
                result = result.Replace("```", "").Replace("```", "").Trim();
            }
            var content = JsonDocument.Parse(result).RootElement.GetProperty("TaskDetails").ToString();
            using (JsonDocument document = JsonDocument.Parse(content))
            {
                if (document.RootElement.TryGetProperty("MilestoneTaskDate", out JsonElement milestoneElement))
                {
                    foreach (var milestone in milestoneElement.EnumerateArray())
                    {
                        var datas = JsonSerializer.Deserialize<Dictionary<string, string>>(milestone);
                        if (datas != null)
                        {
                            if (milestoneDates.Any() && milestoneDates.ContainsKey(datas["TaskName"]))
                            {
                                continue;
                            }
                            TaskInfoModel? record = GanttDataModel.GetTaskCollection().Where(s => s.Name == datas["TaskName"]).FirstOrDefault();
                            if (record is not null)
                            {
                                var parentRecord = GanttDataModel.GetTaskCollection().Where(s => s.Id == record.ParentId).FirstOrDefault();
                                if (parentRecord is not null)
                                {
                                    milestoneDates.Add(parentRecord.Name!, Convert.ToDateTime(datas["MilestoneDate"]));
                                }
                            }
                        }
                    }
                }
            }
            var collection = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
            if (collection is null)
            {
                await Gantt.HideSpinnerAsync();
                return;
            }
            await Task.Delay(100);
            if (DateTime.TryParse(collection["ProjectCompletionDate"].ToString(), out DateTime projectDate))
            {
                milestoneDates.Add("Project Completion date", projectDate);
            }
            StateHasChanged();
        }
        catch (Exception)
        {
            showMessage = true;
            await Gantt.HideSpinnerAsync();
            return;
        }
        await Gantt.HideSpinnerAsync();
        await Task.CompletedTask;
    }
    private string GetHistoricalCollection()
    {
        string historicalDataCollection = string.Empty;
        for (int year = 2021; year < 2026; year++)
        {
            string currentDir = Directory.GetCurrentDirectory();
            // Combine the current directory with the relative path
            string fullPath = Path.Combine(currentDir, "Model/ProgressHistoricalData.json");
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException(
                    $"Historical data file not found: {fullPath}");
            }
            using StreamReader streamReader = new StreamReader(fullPath);
            historicalDataCollection += $"HistoricalTaskDataCollection{year}: " + JsonDocument.Parse(streamReader.ReadToEnd()).RootElement.GetProperty($"TaskDataCollection{year}").ToString() + ", ";
        }
        return historicalDataCollection;
    }
}
<style>
    #Gantt_Toolbar {
        border: 1px solid lightgray !important;
        padding: 4px !important;
    }
    .e-custom-event-marker {
        border-left: 1px dashed red !important;
    }
    .e-custom-event-marker .e-span-label {
        color: red !important;
    }
    .e-gantt-custom-event-marker {
        border-left: 1px dashed green !important;
    }
    .e-gantt-custom-event-marker .e-span-label {
        color: green !important;
    }
    .e-icons.e-refresh::before {
        content: '\e706';
    }
</style>

{% endhighlight %}
{% highlight C# tabtitle="Service.cs" %}

using Microsoft.Extensions.AI;
using Syncfusion.Blazor.AI;

namespace GanttChart.Components.Services
{
    public class AzureAIService
    {
        private SyncfusionAIService _openAIConfiguration;
        private ChatParameters chatParameters_history = new ChatParameters();

        public AzureAIService(SyncfusionAIService openAIConfiguration)
        {
            _openAIConfiguration = openAIConfiguration;
        }

        /// <summary>
        /// Gets a text completion from the Azure OpenAI service.
        /// </summary>
        /// <param name="prompt">The user prompt to send to the AI service.</param>
        /// <param name="returnAsJson">Indicates whether the response should be returned in JSON format. Defaults to <c>true</c></param>
        /// <param name="appendPreviousResponse">Indicates whether to append previous responses to the conversation history. Defaults to <c>false</c></param>
        /// <param name="systemRole">Specifies the systemRole that is sent to AI Clients. Defaults to <c>null</c></param>
        /// <returns>The AI-generated completion as a string.</returns>
        public async Task<string> GetCompletionAsync(string prompt, bool returnAsJson = true, bool appendPreviousResponse = false, string systemRole = null)
        {
            string systemMessage = returnAsJson ? "You are a helpful assistant that only returns and replies with valid, iterable RFC8259 compliant JSON in your responses unless I ask for any other format. Do not provide introductory words such as 'Here is your result' or '```json', etc. in the response" : !string.IsNullOrEmpty(systemRole) ? systemRole : "You are a helpful assistant";
            try
            {
                ChatParameters chatParameters = appendPreviousResponse ? chatParameters_history : new ChatParameters();
                if (appendPreviousResponse)
                {
                    if (chatParameters.Messages == null)
                    {
                        chatParameters.Messages = new List<ChatMessage>() {
                        new ChatMessage(ChatRole.System,systemMessage),
                    };
                    }
                    chatParameters.Messages.Add(new ChatMessage(ChatRole.User, prompt));
                }
                else
                {
                    chatParameters.Messages = new List<ChatMessage>(2) {
                    new ChatMessage (ChatRole.System, systemMessage),
                    new ChatMessage(ChatRole.User,prompt)
                };
                }
                var completion = await _openAIConfiguration.GenerateResponseAsync(chatParameters);
                if (appendPreviousResponse)
                {
                    chatParameters_history?.Messages?.Add(new ChatMessage(ChatRole.Assistant, completion.ToString()));
                }
                return completion.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception has occurred: {ex.Message}");
                return "";
            }
        }
    }
}


{% endhighlight %}
{% highlight C# tabtitle="GanttModel.cs" %}

namespace GanttChart.Components.Model
{
    public class ResourceInfoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double MaxUnit { get; set; }
    }
    public class TaskInfoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TaskType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public string? Predecessor { get; set; }
        public int? ParentId { get; set; }
        public double? Work { get; set; }
        public DateTime? BaselineStartDate { get; set; }
        public DateTime? BaselineEndDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
    public class AssignmentModel
    {
        public int PrimaryId { get; set; }
        public int TaskId { get; set; }
        public int ResourceId { get; set; }
        public double Unit { get; set; }
    }
    public class MessageContent
    {
        public string role { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
    }
    public static class GanttDataModel
    {
        public static List<ResourceInfoModel> GetResources { get; } = new List<ResourceInfoModel>
        {
            new ResourceInfoModel() { Id= 1, Name= "Martin Tamer" ,MaxUnit=100},
            new ResourceInfoModel() { Id= 2, Name= "Rose Fuller", MaxUnit= 100 },
            new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
            new ResourceInfoModel() { Id= 4, Name= "Fuller King", MaxUnit = 100},
            new ResourceInfoModel() { Id= 5, Name= "Davolio Fuller", MaxUnit = 100 },
            new ResourceInfoModel() { Id= 6, Name= "Van Jack", MaxUnit = 100 },
            new ResourceInfoModel() { Id= 7, Name= "Fuller Buchanan", MaxUnit = 100 },
            new ResourceInfoModel() { Id= 8, Name= "Jack Davolio", MaxUnit = 100 },
            new ResourceInfoModel() { Id= 9, Name= "Tamer Vinet", MaxUnit = 100 },
            new ResourceInfoModel() { Id= 10, Name= "Vinet Fuller",MaxUnit = 100 },
            new ResourceInfoModel() { Id= 11, Name= "Bergs Anton",MaxUnit = 100 },
            new ResourceInfoModel() { Id= 12, Name= "Construction Supervisor",MaxUnit = 100 }
        };


        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedUnit", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 100, ParentId = 1, Duration="2", TaskType ="FixedUnit", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentId = 1, Work=96, Duration="4", TaskType="FixedUnit" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "1", Progress = 100, ParentId = 1, Work=16, TaskType="FixedUnit" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedUnit", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 100, ParentId = 5, Work=30, TaskType="FixedUnit" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentId = 5, TaskType="FixedUnit", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "2", ParentId = 5, Work=60, TaskType="FixedUnit" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="3", TaskType="FixedUnit", Work=24 },
            };
        }
        public static List<TaskInfoModel> DataSourceCollection()
        {
            List<TaskInfoModel> Tasks = new List<TaskInfoModel>() {
                new TaskInfoModel() { Id = 1, Name = "Product concept", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 08), Duration = "5 days" },
                new TaskInfoModel() { Id = 2, Name = "Defining the product usage", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 08), Duration = "3", Progress = 30, ParentId = 1 },
                new TaskInfoModel() { Id = 3, Name = "Defining the target audience", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 04), Duration = "3", Progress = 40, ParentId = 1 },
                new TaskInfoModel() { Id = 4, Name = "Prepare product sketch and notes", StartDate = new DateTime(2021, 04, 05), EndDate = new DateTime(2021, 04, 08), Duration = "2", Progress = 30, ParentId = 1, Predecessor = "2" },
                new TaskInfoModel() { Id = 5, Name = "Concept approval", StartDate = new DateTime(2021, 04, 08), EndDate = new DateTime(2021, 04, 08), Duration = "0", Predecessor = "3,4" },
                new TaskInfoModel() { Id = 6, Name = "Market research", StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 18), Predecessor = "2", Duration = "4", Progress = 30 },
                new TaskInfoModel() { Id = 7, Name = "Demand analysis", StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 12), Duration = "4", Progress = 40, ParentId = 6 },
                new TaskInfoModel() { Id = 8, Name = "Customer strength", StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 12), Duration = "4", Progress = 30, ParentId = 7, Predecessor = "5" },
                new TaskInfoModel() { Id = 9, Name = "Market opportunity analysis", StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 12), Duration = "4", ParentId = 7, Predecessor = "5" },
                new TaskInfoModel() { Id = 10, Name = "Competitor analysis", StartDate = new DateTime(2021, 04, 15), EndDate = new DateTime(2021, 04, 18), Duration = "4", Progress = 30, ParentId = 6, Predecessor = "7,8" }
            };
            return Tasks;
        }
        public static List<TaskInfoModel> GetBaselineCollection()
        {
            List<TaskInfoModel> Tasks = new List<TaskInfoModel>() {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 06) },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 02), Duration = "1", BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 02), Progress = 30, ParentId = 1 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 04, 02), Duration = "5", Progress = 40, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 10), ParentId = 1 },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 04, 08), Duration = "2", EndDate = new DateTime(2021, 04, 09), BaselineStartDate = new DateTime(2021, 04, 08), BaselineEndDate = new DateTime(2021, 04, 12), Progress = 30, ParentId = 1 },
                new TaskInfoModel() { Id = 5, Name = "Project initiation", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 08) },
                new TaskInfoModel() { Id = 6, Name = "Identify site location", StartDate = new DateTime(2021, 04, 02), Duration = "6", Progress = 30, ParentId = 5, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 09) },
                new TaskInfoModel() { Id = 7, Name = "Perform soil test", StartDate = new DateTime(2021, 04, 02), Duration = "4", Progress = 40, ParentId = 5, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 07) },
                new TaskInfoModel() { Id = 8, Name = "Soil test approval", Status="Critical", StartDate = new DateTime(2021, 04, 02), Duration = "5", Progress = 30, ParentId = 5, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 04) },
                new TaskInfoModel() { Id = 9, Name = "Market opportunity analysis", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 06) },
                new TaskInfoModel() { Id = 10, Name = "Competitor analysis", Status="Critical", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 02), Duration = "3", BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 05), Progress = 30, ParentId = 9 },
                new TaskInfoModel() { Id = 11, Name = "Product strength analysis", Status="Critical", StartDate = new DateTime(2021, 04, 02), Duration = "5", Progress = 40, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 06), ParentId = 9 },
                new TaskInfoModel() { Id = 12, Name = "Research completed", StartDate = new DateTime(2021, 04, 08), Duration = "10", EndDate = new DateTime(2021, 04, 08), Progress = 30, ParentId = 9 },
                new TaskInfoModel() { Id = 13, Name = "Product design and development", StartDate = new DateTime(2021, 04, 02), Duration = "5", Progress = 40, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 08), ParentId = 9 }
            };
            return Tasks;
        }

        public static List<TaskInfoModel> HistoricalTaskData => new List<TaskInfoModel>
        {
            new TaskInfoModel { Id = 1, Name = "Requirement Analysis", StartDate = new DateTime(2026, 1, 10), EndDate = new DateTime(2026, 1, 15), Duration = "5", Progress = 100, ParentId = null },
            new TaskInfoModel { Id = 2, Name = "UI/UX Design", StartDate = new DateTime(2026, 1, 15), EndDate = new DateTime(2026, 1, 17), Duration = "2", Progress = 0, ParentId = null },
            new TaskInfoModel { Id = 3, Name = "Backend Development", StartDate = new DateTime(2026, 1, 20), EndDate = new DateTime(2026, 1, 23), Duration = "3", Progress = 50, ParentId = null },
            new TaskInfoModel { Id = 4, Name = "Database Schema Design", StartDate = new DateTime(2026, 1, 18), EndDate = new DateTime(2026, 1, 24), Duration = "6", Progress = 0, ParentId = null },
            new TaskInfoModel { Id = 5, Name = "Frontend Development", StartDate = new DateTime(2026, 1, 22), EndDate = new DateTime(2026, 1, 27), Duration = "5", Progress = 80, ParentId = null },
            new TaskInfoModel { Id = 6, Name = "Testing Phase", StartDate = new DateTime(2026, 1, 25), EndDate = new DateTime(2026, 1, 30), Duration = "6", Progress = 20, ParentId = null },
            new TaskInfoModel { Id = 7, Name = "Deployment Preparation", StartDate = new DateTime(2026, 1, 28), EndDate = new DateTime(2026, 2, 5), Duration = "9", Progress = 10, ParentId = null },
            new TaskInfoModel { Id = 8, Name = "User Documentation", StartDate = new DateTime(2026, 2, 1), EndDate = new DateTime(2026, 2, 10), Duration = "10", Progress = 30, ParentId = null },
            new TaskInfoModel { Id = 9, Name = "Security Audit", StartDate = new DateTime(2026, 2, 5), EndDate = new DateTime(2026, 2, 15), Duration = "11", Progress = 40, ParentId = null },
            new TaskInfoModel { Id = 10, Name = "Performance Optimization", StartDate = new DateTime(2026, 2, 10), EndDate = new DateTime(2026, 2, 20), Duration = "11", Progress = 60, ParentId = null },
            new TaskInfoModel { Id = 11, Name = "Beta Testing", StartDate = new DateTime(2026, 2, 15), EndDate = new DateTime(2026, 2, 25), Duration = "11", Progress = 70, ParentId = null },
            new TaskInfoModel { Id = 12, Name = "Bug Fixing", StartDate = new DateTime(2026, 2, 20), EndDate = new DateTime(2026, 3, 5), Duration = "14", Progress = 80, ParentId = null }
        };

        public static List<AssignmentModel> GetAssignmentCollection()
        {
            List<AssignmentModel> assignments = new List<AssignmentModel>()
            {
                new AssignmentModel(){ PrimaryId=1, TaskId = 2, ResourceId=1, Unit=100},
                new AssignmentModel(){ PrimaryId=2, TaskId = 3, ResourceId=1, Unit=50},
                new AssignmentModel(){ PrimaryId=3, TaskId = 4, ResourceId=3, Unit=40},
                new AssignmentModel(){ PrimaryId=4, TaskId = 6, ResourceId=3, Unit = 100},
                new AssignmentModel(){ PrimaryId=5, TaskId = 7, ResourceId=8, Unit = 100},
                new AssignmentModel(){ PrimaryId=6, TaskId = 8, ResourceId=5, Unit = 70},
                new AssignmentModel(){ PrimaryId=7, TaskId = 9, ResourceId=5, Unit = 60}
            };
            return assignments;
        }

        public static List<AssignmentModel> ResourceAssignmentCollection()
        {
            List<AssignmentModel> assignments = new List<AssignmentModel>()
            {
                new AssignmentModel(){ PrimaryId=1, TaskId = 2, ResourceId=1},
                new AssignmentModel(){ PrimaryId=2, TaskId = 3, ResourceId=1},
                new AssignmentModel(){ PrimaryId=3, TaskId = 4, ResourceId=3},
                new AssignmentModel(){ PrimaryId=4, TaskId = 6, ResourceId=3},
                new AssignmentModel(){ PrimaryId=5, TaskId = 7, ResourceId=8},
                new AssignmentModel(){ PrimaryId=6, TaskId = 8, ResourceId=5},
                new AssignmentModel(){ PrimaryId=7, TaskId = 10, ResourceId=2},
                new AssignmentModel(){ PrimaryId=8, TaskId = 11, ResourceId=2},
            };
            return assignments;
        }

        public static List<TaskInfoModel> TaskDataCollection => new List<TaskInfoModel>
        {
            new TaskInfoModel() { Id = 1, Name = "Product concept", StartDate = new DateTime(2026, 04, 02), EndDate = new DateTime(2026, 04, 08), Duration = "5 days" },
            new TaskInfoModel() { Id = 2, Name = "Defining the product usage", StartDate = new DateTime(2026, 04, 02), EndDate = new DateTime(2026, 04, 08), Duration = "3", Progress = 30, ParentId = 1 },
            new TaskInfoModel() { Id = 3, Name = "Defining the target audience", StartDate = new DateTime(2026, 04, 02), EndDate = new DateTime(2026, 04, 04), Duration = "3", Progress = 40, ParentId = 1 },
            new TaskInfoModel() { Id = 4, Name = "Prepare product sketch and notes", StartDate = new DateTime(2026, 04, 05), EndDate = new DateTime(2026, 04, 08), Duration = "2", Progress = 30, ParentId = 1, Predecessor = "2" },
            new TaskInfoModel() { Id = 5, Name = "Concept approval", StartDate = new DateTime(2026, 04, 08), EndDate = new DateTime(2026, 04, 08), Duration = "0", Predecessor = "3,4", ParentId=1 },
            new TaskInfoModel() { Id = 6, Name = "Market research", StartDate = new DateTime(2026, 04, 09), EndDate = new DateTime(2026, 04, 18), Predecessor = "2", Duration = "4", Progress = 30 },
            new TaskInfoModel() { Id = 7, Name = "Demand analysis", StartDate = new DateTime(2026, 04, 09), EndDate = new DateTime(2026, 04, 12), Duration = "4", Progress = 40, ParentId = 6 },
            new TaskInfoModel() { Id = 8, Name = "Customer strength", StartDate = new DateTime(2026, 04, 09), EndDate = new DateTime(2026, 04, 12), Duration = "4", Progress = 30, ParentId = 7, Predecessor = "5" },
            new TaskInfoModel() { Id = 9, Name = "Market opportunity analysis", StartDate = new DateTime(2026, 04, 09), EndDate = new DateTime(2026, 04, 12), Duration = "4", ParentId = 7, Predecessor = "5" },
            new TaskInfoModel() { Id = 10, Name = "Competitor analysis", StartDate = new DateTime(2026, 04, 15), EndDate = new DateTime(2026, 04, 18), Duration = "4", Progress = 30, ParentId = 6, Predecessor = "7,8" }
        };
    }
}

{% endhighlight %}
{% highlight C# tabtitle="Program.cs" %}

using BlazorApp1.Components;
using GanttChart.Components.Service;
using Syncfusion.Blazor.AI;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

string azureOpenAIKey = "AZUREOPENAI-API-KEY";
string azureOpenAIEndpoint = "AZUREOPENAI-API-ENDPOINT";
string azureOpenAIModel = "AZUREOPENAI-API-MODEL";
AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
    new Uri(azureOpenAIEndpoint),
    new ApiKeyCredential(azureOpenAIKey)
);
IChatClient azureOpenAIChatClient = azureOpenAIClient.GetChatClient(azureOpenAIModel).AsIChatClient();
builder.Services.AddChatClient(azureOpenAIChatClient);
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();
builder.Services.AddSingleton<AzureAIService>();
builder.Services.AddSingleton<SyncfusionAIService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
var app = builder.Build();

{% endhighlight %}
{% endtabs %}


## Error handling and troubleshooting

If the AI service fails to return a valid response, the Gantt Chart displays an error message ("Something went wrong."). Common issues include:

- **Invalid API key or endpoint**: Verify that `openAIApiKey`, `azureOpenAIKey`, or the Ollama `Endpoint` is correct and the service is accessible.
- **Model unavailable**: Ensure the specified `openAIModel`, `azureOpenAIModel`, or `ModelName` is deployed and supported.
- **Network issues**: Check connectivity to the AI service endpoint, especially for self-hosted Ollama instances.
- **Large datasets**: Processing large datasets may cause timeouts. Consider batching data or optimizing the prompt.


## Performance considerations

When handling large datasets, ensure the Ollama server has sufficient resources (CPU/GPU) to process requests efficiently. For datasets exceeding 10,000 records, consider splitting the data into smaller batches to avoid performance bottlenecks. Test the application with your specific dataset to determine optimal performance.

![Progress Predictor](ai\images\progress-predictor.gif)