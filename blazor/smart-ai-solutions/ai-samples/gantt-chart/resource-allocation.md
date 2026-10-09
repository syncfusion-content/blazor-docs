---
layout: post
title: Gantt Chart Resource Allocation with Azure OpenAI
description: Learn how to integrate Syncfusion Blazor Gantt Chart with Azure OpenAI to automatically resolve resource overallocation and optimize task assignments.
platform: Blazor
control: AI Integration
documentation: ug
keywords: Blazor Gantt Chart, Azure OpenAI, Resource Allocation, Syncfusion Blazor AI
---

# Resource Allocation with Blazor Gantt Chart and Azure OpenAI

This guide demonstrates how to use the [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package for automatic resource reallocation in a Syncfusion Blazor Gantt Chart component. The [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package enables integration with AI models to process and structure data, This sample demonstrates how to efficiently manage resource overallocation by reallocating available resources to tasks.

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
{% highlight C# tabtitle="Program.cs" %}

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
{% highlight C# tabtitle="Package Manager" %}

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


The following code example shows how to integrate the Gantt Chart with AI for automatic resource allocation:

{% tabs %}
{% highlight C# tabtitle="Home.razor" %}

@inject AzureAIService OpenAIService
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using System.Text.Json
@inject IJSRuntime JsInterop

<div class="col-lg-12 control-section" id="gantt-control-section">
    @if (showMessage)
    {
        <div>
            <SfButton CssClass="e-flat" IsPrimary="true" IconCss="e-icons e-refresh" IconPosition=@IconPosition.Right OnClick="Reload">Something went wrong.</SfButton>
        </div>
    }
    <div>
        <SfGantt @ref="Gantt" ViewType="ViewType.ResourceView" ShowOverallocation="true" DataSource="@TaskCollection" Width="900px"  Height="550px" TreeColumnIndex="1"  AllowUnscheduledTasks="true">
            <GanttTaskFields Id="Id" Name="Name" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            ParentID="ParentId" Work="Work" TaskType="TaskType">
            </GanttTaskFields>
            <GanttResource DataSource="ResourceCollection" Id="Id" Name="Name" MaxUnits="MaxUnit" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
            <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="PrimaryId" TaskID="TaskId" ResourceID="ResourceId" Units="Unit" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel"></GanttAssignmentFields>
            <GanttLabelSettings RightLabel="Resources" TValue="GanttModel.TaskInfoModel"></GanttLabelSettings>
            <GanttColumns>
                <GanttColumn Field="Id" HeaderText="ID" Visible="false"></GanttColumn>
                <GanttColumn Field="Name" HeaderText="Event Name" Width="250px"></GanttColumn>
                <GanttResourceColumn HeaderText="Event Resources"></GanttResourceColumn>
                <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
                <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
                <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
            </GanttColumns>
            <GanttTemplates TValue="GanttModel.TaskInfoModel">
                <TaskbarTemplate>
                    @{
                        var task = (context as GanttModel.TaskInfoModel);
                        if (task == null)
                        {
                            return;
                        }
                        var taskModel = Gantt.GetRowTaskModel(task);
                        string taskbarClassName = string.Empty;
                        string progressClassName = string.Empty;
                        if (TaskIds.Count > 0 && TaskIds.Any(s => s == task.Id))
                        {
                            taskbarClassName = "e-custom-taskbar";
                            progressClassName = "e-custom-progress";
                        }
                        <div class="e-gantt-child-taskbar e-gantt-child-taskbar-inner-div @taskbarClassName" style="height:22px;" tabindex=-1>
                            <div class="e-gantt-child-progressbar-inner-div e-gantt-child-progressbar @progressClassName" style="height:22px; width:@(taskModel.ProgressWidth + "px");text-align: right;border-radius: 0px;">
                            </div>
                        </div>
                    }
                </TaskbarTemplate>
            </GanttTemplates>
            <GanttSplitterSettings Position="50%"> </GanttSplitterSettings>
            <SfToolbar ID="Gantt_Toolbar">
                <ToolbarItems>
                    <ToolbarItem>
                        <Template>
                            <SfButton IsPrimary ID="openAI" @onclick="OpenAIHandler">Optimize resource allocation</SfButton>
                        </Template>
                    </ToolbarItem>
                </ToolbarItems>
            </SfToolbar>
        </SfGantt>
    </div>
</div>
<style>
    #Gantt_Toolbar {
    border: 1px solid lightgray !important;
    padding: 4px !important;
    }
    .e-icons.e-refresh::before {
    content: '\e706';
    }
    .e-custom-taskbar {
    background-color: lightgreen !important;
    }
    .e-custom-progress {
    background-color: green !important;
    }
</style>

{% endhighlight %}
{% highlight C# tabtitle="Home.razor.cs" %}

using Microsoft.JSInterop;
using Syncfusion.Blazor.Gantt;
using System.Text.Json;

namespace BlazorApp1.Components.Pages
{
    public partial class Home
    {
        private SfGantt<GanttModel.TaskInfoModel> Gantt;
        private List<GanttModel.TaskInfoModel> TaskCollection { get; set; }
        private List<GanttModel.ResourceInfoModel> ResourceCollection { get; set; }
        private static List<GanttModel.AssignmentModel> AssignmentCollection { get; set; }
        private string AIPrompt = string.Empty;
        private bool showMessage;
        List<int> TaskIds = new();
        protected override void OnInitialized()
        {
            TaskCollection = GanttModel.GetTaskCollection().Take(6).ToList();
            ResourceCollection = GanttModel.GetResources;
            AssignmentCollection = GanttModel.GetAssignmentCollection();
        }
        private string GeneratePrompt(List<GanttModel.TaskInfoModel> TaskCollection, List<GanttModel.ResourceInfoModel> ResourceCollection, List<GanttModel.AssignmentModel> AssignmentCollection)
        {
            return @"Here's a revised prompt to ensure the AI provides the results in JSON format:
                Function as an AI assistant responsible for optimizing resource assignments in a project management system. Your goal is to prevent overlapping task assignments for each resource, ensuring no resource is double-booked.
                1. **Check Task Assignments:** Review the start and end dates of tasks assigned to each resource to identify overlaps.
                2. **Resolve Conflicts:** Reassign conflicting tasks to other available resources without scheduling conflicts, ensuring each task is assigned to a resource.
                3. **Provide Updated Assignments:** Return the updated assignments.
                Please return a JSON object with the following:
                - **AssignmentCollection:** Updated resource assignments.
                - **TaskIds:** List of task IDs where resource assignments have changed.
                The response must be in JSON format only, with no additional explanations or content.
                Here is the dataset:
                - Task Collection Data: " + JsonSerializer.Serialize(TaskCollection) + @"
                - Resource Collection Data: " + JsonSerializer.Serialize(ResourceCollection) + @"
                - Assignment Collection Data: " + JsonSerializer.Serialize(AssignmentCollection) + @"
                Note: Ensure the response is a JSON string and does not include any extra information.";
        }

        /// <summary>
        /// Reloads the current page and restores the application to its initial state.
        /// </summary>
        /// <remarks>
        private async Task Reload()
        {
            await JsInterop.InvokeVoidAsync("window.location.reload");
        }

        /// <summary>
        /// Sends the current task, resource, and assignment data to the AI service
        /// and automatically optimizes resource allocation by resolving
        /// resource overallocation conflicts.
        /// </summary>
        private async Task OpenAIHandler()
        {
            await Gantt.ShowSpinnerAsync();
            TaskIds = new();
            showMessage = false;
            List<GanttModel.AssignmentModel> sortedCollection = new List<GanttModel.AssignmentModel>();
            var AIPrompt = GeneratePrompt(TaskCollection, ResourceCollection, AssignmentCollection);
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
                string response = JsonDocument.Parse(result).RootElement.GetProperty("AssignmentCollection").ToString();
                string taskIdCollection = JsonDocument.Parse(result).RootElement.GetProperty("TaskIds").ToString();
                if (response is not null)
                {
                    var collection = JsonSerializer.Deserialize<List<GanttModel.AssignmentModel>>(response);
                    if (collection is not null)
                    {
                        sortedCollection = collection;
                    }
                }
                if (taskIdCollection is not null)
                {
                    var collection = JsonSerializer.Deserialize<List<int>>(taskIdCollection);
                    if (collection is not null)
                    {
                        TaskIds = collection;
                    }
                }
                if (sortedCollection is not null && sortedCollection.Count > 0)
                {
                    AssignmentCollection = sortedCollection.Cast<GanttModel.AssignmentModel>().ToList();
                }
            }
            catch (Exception e)
            {
                showMessage = true;
                await Gantt.HideSpinnerAsync();
                return;
            }
            await Gantt.HideSpinnerAsync();
            await Task.CompletedTask;
        }
    }
}

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

namespace GanttChart.Components.Models
{
    public class GanttModel
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
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentId { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskId { get; set; }
            public int ResourceId { get; set; }
            public double? Unit { get; set; }
        }

        public static List<ResourceInfoModel> GetResources = new List<ResourceInfoModel>()
        {
            new ResourceInfoModel() { Id= 1, Name= "Martin Tamer" ,MaxUnit=100},
            new ResourceInfoModel() { Id= 2, Name= "Rose Fuller", MaxUnit= 100 },
            new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
            new ResourceInfoModel() { Id= 4, Name= "Fuller King", MaxUnit = 100},
            new ResourceInfoModel() { Id= 5, Name= "Davolio Fuller", MaxUnit = 100 }
        };

        public static List<AssignmentModel> GetAssignmentCollection()
        {
            List<AssignmentModel> assignments = new List<AssignmentModel>()
            {
                new AssignmentModel(){ PrimaryId=1, TaskId = 2, ResourceId=1, Unit=100},
                new AssignmentModel(){ PrimaryId=2, TaskId = 3, ResourceId=1, Unit=50},
                new AssignmentModel(){ PrimaryId=3, TaskId = 4, ResourceId=3, Unit=40},
                new AssignmentModel(){ PrimaryId=4, TaskId = 6, ResourceId=3, Unit = 100},
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedUnit", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 100, ParentId = 1, Duration="2", TaskType ="FixedUnit", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentId = 1, Work=10, Duration="4", TaskType="FixedUnit" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "15", Progress = 100, ParentId = 1, Work=16, TaskType="FixedDuration" },
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
{% endtabs %}


## Error handling and troubleshooting

If the AI service fails to return a valid response, the Gantt Chart displays an error message ("Something went wrong."). Common issues include:

- **Invalid API key or endpoint**: Verify that `openAIApiKey`, `azureOpenAIKey`, or the Ollama `Endpoint` is correct and the service is accessible.
- **Model unavailable**: Ensure the specified `openAIModel`, `azureOpenAIModel`, or `ModelName` is deployed and supported.
- **Network issues**: Check connectivity to the AI service endpoint, especially for self-hosted Ollama instances.
- **Large datasets**: Processing large datasets may cause timeouts. Consider batching data or optimizing the prompt.


![Resource Allocation](../images/resource-allocation.webp)

N> [View sample in GitHub](https://github.com/syncfusion/smart-ai-samples/blob/master/blazor/SyncfusionAISamples/Components/Pages/GanttChart/ResourceOverallocation.razor)
