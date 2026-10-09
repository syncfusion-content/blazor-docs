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

Install the required Blazor and AI service NuGet packages based on the selected AI service.

### For Azure OpenAI

- [Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI)
- [Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI)
- [Azure.AI.OpenAI](https://www.nuget.org/packages/Azure.AI.OpenAI)

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}

### Syncfusion packages

- [Syncfusion.Blazor.Gantt](https://www.nuget.org/packages/Syncfusion.Blazor.Gantt)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)
- [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI)

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Gantt -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Include the Blazor theme stylesheet and required scripts using NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets).

Add the stylesheet and script references to **~/Components/App.razor** for Blazor Web Apps using the Interactive Server render mode.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
    ....
    <!-- Blazor theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    ....
    <!-- Blazor core script -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

> Explore the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for methods to reference themes ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), or [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). Refer to the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic for different approaches to adding script references in your Blazor application.


## Configure Azure OpenAI

Deploy an Azure OpenAI Service resource and model as described in [Microsoft’s documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource). Obtain values for `azureOpenAIKey`, `azureOpenAIEndpoint`, and `azureOpenAIModel`.


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

{% endhighlight %}
{% endtabs %}


## Register Syncfusion Blazor Service

Add the Syncfusion Blazor service to the **~/Program.cs** file. The configuration depends on the app’s **Interactive Render Mode**:

- **Server mode**: Register the service in the single **~/Program.cs** file.


{% tabs %}
{% highlight C# tabtitle="" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();


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
@code{
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
        
    }
}

{% endhighlight %}
{% highlight C# tabtitle="ProgressHistoricalData.json" %}

{
  "TaskDataCollection2021": [
    {
      "Id": 1,
      "Name": "Product concept",
      "StartDate": "2021-04-02",
      "EndDate": "2021-04-08",
      "Duration": "5 days",
      "Progress": 100
    },
    {
      "Id": 2,
      "Name": "Defining the product usage",
      "StartDate": "2021-04-02",
      "EndDate": "2021-04-08",
      "Duration": "3 days",
      "Progress": 100,
      "ParentId": 1
    },
    {
      "Id": 3,
      "Name": "Defining the target audience",
      "StartDate": "2021-04-02",
      "EndDate": "2021-04-04",
      "Duration": "3 days",
      "Progress": 100,
      "ParentId": 1
    },
    {
      "Id": 4,
      "Name": "Prepare product sketch and notes",
      "StartDate": "2021-04-05",
      "EndDate": "2021-04-08",
      "Duration": "2 days",
      "Progress": 100,
      "ParentId": 1,
      "Predecessor": "2"
    },
    {
      "Id": 5,
      "Name": "Concept approval",
      "StartDate": "2021-04-08",
      "EndDate": "2021-04-08",
      "Duration": "0 days",
      "Predecessor": "3,4",
      "ParentId": 1,
      "Progress": 100
    },
    {
      "Id": 6,
      "Name": "Market research",
      "StartDate": "2021-04-09",
      "EndDate": "2021-04-18",
      "Duration": "4 days",
      "Progress": 100,
      "Predecessor": "2"
    },
    {
      "Id": 7,
      "Name": "Demand analysis",
      "StartDate": "2021-04-09",
      "EndDate": "2021-04-12",
      "Duration": "4 days",
      "Progress": 100,
      "ParentId": 6
    },
    {
      "Id": 8,
      "Name": "Customer strength",
      "StartDate": "2021-04-09",
      "EndDate": "2021-04-12",
      "Duration": "4 days",
      "Progress": 100,
      "ParentId": 7,
      "Predecessor": "5"
    },
    {
      "Id": 9,
      "Name": "Market opportunity analysis",
      "StartDate": "2021-04-09",
      "EndDate": "2021-04-12",
      "Duration": "4 days",
      "ParentId": 7,
      "Progress": 100,
      "Predecessor": "5"
    },
    {
      "Id": 10,
      "Name": "Competitor analysis",
      "StartDate": "2021-04-15",
      "EndDate": "2021-04-18",
      "Duration": "4 days",
      "Progress": 100,
      "ParentId": 6,
      "Predecessor": "7,8"
    }
  ],
}

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

![Progress Predictor](../ai/images/progress-predictor.gif)

N> [View sample in GitHub](https://github.com/syncfusion/smart-ai-samples/blob/master/blazor/SyncfusionAISamples/Components/Pages/GanttChart/ProgressPrediction.razor)