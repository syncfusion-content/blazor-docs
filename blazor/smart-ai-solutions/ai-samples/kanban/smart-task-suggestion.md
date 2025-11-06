---
layout: post
title: Smart Task Suggestion in Blazor Kanban with AI Models| Syncfusion
description: Learn how to use Syncfusion Blazor Kanban with AI to automatically generate and assign tasks based on project descriptions.
platform: Blazor
control: AI Integration
documentation: ug
keywords: Blazor Kanban, AI task suggestion, Syncfusion Blazor AI
---

# Smart Task Suggestion in Blazor Kanban Component

This guide demonstrates how to use the [**Syncfusion.Blazor.AI**](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package to enhance task planning in the Syncfusion Blazor Kanban component. The AI integration enables intelligent task generation based on project descriptions, sprint planning, and backlog management. These capabilities are powered by AI models hosted via services like OpenAI, Azure OpenAI, or Ollama.

## Prerequisites

Ensure the following NuGet packages are installed based on your chosen AI service:

### For OpenAI
- **Microsoft.Extensions.AI**
- **Microsoft.Extensions.AI.OpenAI**

### For Azure OpenAI
- **Microsoft.Extensions.AI**
- **Microsoft.Extensions.AI.OpenAI**
- **Azure.AI.OpenAI**

### For Ollama
- **Microsoft.Extensions.AI**
- **OllamaSharp**

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Kanban -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI  # For OpenAI or Azure OpenAI
Install-Package Azure.AI.OpenAI  # For Azure OpenAI
Install-Package OllamaSharp  # For Ollama

{% endhighlight %}
{% endtabs %}

## Add Stylesheet and Script Resources

Include the theme stylesheet and script from NuGet via [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) in the `<head>` of your main page:

- For **.NET 6** Blazor Server apps, add to **~/Pages/_Layout.cshtml**.
- For **.NET 8 or .NET 9** Blazor Server apps, add to **~/Components/App.razor**.

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/tailwind.css" rel="stylesheet" />
</head>
<body>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Explore the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for methods to reference themes ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), or [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). Refer to the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic for different approaches to adding script references in your Blazor application.

## Configure AI Service

Choose one of the following AI services (OpenAI, Azure OpenAI, or Ollama) based on your requirements:
- **OpenAI**: Best for cloud-based, general-purpose AI models with minimal setup.
- **Azure OpenAI**: Ideal for enterprise-grade deployments with enhanced security and scalability.
- **Ollama**: Suitable for self-hosted, privacy-focused AI models.

Follow the instructions for your selected service to register the AI model in your application.

### OpenAI

Generate an API key from OpenAI and set `openAIApiKey`. Specify the desired model (e.g., `gpt-3.5-turbo`, `gpt-4`) in `openAIModel`.

- Install the required NuGet packages:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}
{% endtabs %}

- Add the following to the **~/Program.cs** file in your Blazor WebApp:

{% tabs %}
{% highlight C# tabtitle="Blazor WebApp" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

string openAIApiKey = "API-KEY";
string openAIModel = "OPENAI_MODEL";
OpenAIClient openAIClient = new OpenAIClient(openAIApiKey);
IChatClient openAIChatClient = openAIClient.GetChatClient(openAIModel).AsIChatClient();
builder.Services.AddChatClient(openAIChatClient);
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

### Azure OpenAI

Deploy an Azure OpenAI Service resource and model as described in [Microsoft's documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource). Obtain values for `azureOpenAIKey`, `azureOpenAIEndpoint`, and `azureOpenAIModel`.

- Install the required NuGet packages:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
Install-Package Azure.AI.OpenAI

{% endhighlight %}
{% endtabs %}

- Add the following to the **~/Program.cs** file in your Blazor WebApp:

{% tabs %}
{% highlight C# tabtitle="Blazor WebApp" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.AI;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

string azureOpenAIKey = "AZURE_OPENAI_KEY";
string azureOpenAIEndpoint = "AZURE_OPENAI_ENDPOINT";
string azureOpenAIModel = "AZURE_OPENAI_MODEL";
AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(azureOpenAIEndpoint),
     new ApiKeyCredential(azureOpenAIKey)
);
IChatClient azureOpenAIChatClient = azureOpenAIClient.GetChatClient(azureOpenAIModel).AsIChatClient();
builder.Services.AddChatClient(azureOpenAIChatClient);
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

### Ollama

To use Ollama for self-hosted AI models:

1. **Download and install Ollama**: Visit [Ollama's official website](https://ollama.com) and install the application for your operating system.
2. **Install a model**: Choose a model from the [Ollama Library](https://ollama.com/library) (e.g., `llama2:13b`, `mistral:7b`).
3. **Configure the application**: Provide the `Endpoint` URL (e.g., `http://localhost:11434`) and `ModelName` (e.g., `llama2:13b`).

- Install the required NuGet packages:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package OllamaSharp

{% endhighlight %}
{% endtabs %}

- Add the following to the **~/Program.cs** file in your Blazor WebApp:

{% tabs %}
{% highlight C# tabtitle="Blazor WebApp" hl_lines="7 8 9 11 12 13" %}

using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

var builder = WebApplication.CreateBuilder(args);

string ModelName = "MODEL_NAME";
IChatClient chatClient = new OllamaApiClient("http://localhost:11434", ModelName);
builder.Services.AddChatClient(chatClient);
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

- **Verify connectivity**: Ensure the Ollama server is running and accessible at the specified endpoint (e.g., `http://localhost:11434`) before starting the application.

## Register Syncfusion Blazor Service

Add the Syncfusion Blazor service to your **~/Program.cs** file. The configuration depends on your app's **Interactive Render Mode**:

- **Server Mode**: Register the service in the single **~/Program.cs** file.
- **WebAssembly or Auto Mode**: Register the service in both the server-side **~/Program.cs** and client-side **~/Program.cs** files.

{% tabs %}
{% highlight C# tabtitle="Server (~/_Program.cs)" hl_lines="3 11" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

{% endhighlight %}
{% highlight C# tabtitle="Client (~/_Program.cs)" hl_lines="2 5" %}

using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

## Razor Component 

This section demonstrates how to implement the Syncfusion Blazor Kanban component with AI-powered task generation. The AI Assistant analyzes the provided project description and automatically suggests relevant tasks, which are then displayed in the Kanban board.

(`Home.razor`)

```razor

@rendermode InteractiveServer
@inject AzureAIService OpenAIService
@using Syncfusion.Blazor.Kanban
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SplitButtons
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Notifications
@using BlazorApp4.Components.Models
@using BlazorApp4.Components.Service
@using Syncfusion.Blazor.Grids

@if (isHomapage)
{
    <div class="col-lg-12 control-section">
        <div class="content-wrapper">
            <div class="row" id="customcontainer">
                <div class="col-12 text-center my-3">
                    <h3>AI Smart Task Suggestion</h3>
                </div>
                <div class="col-12 text-center my-3">
                    <div style="display:flex; justify-content:center;">
                        <div class="col-12 col-md-6 d-flex cuscol-1 justify-content-center">
                            <div style="width:100%; max-width: 500px; margin: auto;">
                                <div class="e-rte-label1" >
                                    <label>Project Details</label>
                                </div>
                                <div class="e-rte-field" style="margin: 10px">
                                    <SfTextBox @bind-Value="@TextBoxValue" Multiline=true />
                                </div>
                                <div class="e-rte-label2">
                                    <label>Number of tasks</label>
                                </div>
                                <div class="e-rte-field" style="margin: 10px">
                                    <SfTextBox @bind-Value="@TasksValue" min="1" Type="InputType.Number" />
                                </div>
                                <div class="d-flex justify-content-center" style="margin: 10px;">
                                    <SfProgressButton Content="@ContentGenerateTask" OnClick="@GenerateTasks" EnableProgress="false">
                                        <ProgressButtonEvents OnBegin="BeginGenerateTasks" OnEnd="EndGenerateTasks"></ProgressButtonEvents>
                                    </SfProgressButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
}
else
{
    <div class="col-lg-12 control-section">
        <div class="content-wrapper">
            <div class="row" id="toast-kanban-observable">
                @if (showBacklogs)
                {
                    <div class="col-12 text-center my-3">
                        <h3>Kanban Board</h3>
                        <div style="float: right;">
                            <SfButton OnClick="OpenProjectDetailsDialog">Add New Projects</SfButton>
                        </div>
                        <div style="float: left;">
                            <SfButton OnClick="GoToBacklogBoardView" Content="@BacklogButtonViewContent"></SfButton>
                        </div>
                    </div>
                    if (!showBacklogBoard)
                    {
                        <div class="grid-container">
                            <SfGrid DataSource="@smartSuggestion" AllowPaging="true" Toolbar="@(new List<string>() { "Add" })">
                                <GridEvents OnActionBegin="TaskEditingHandler" RowCreated="RowCreatedHandler" TValue="SmartSuggestionDataModel"></GridEvents>
                                <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Dialog" Dialog="DialogParams">
                                    <Template>
                                        @{
                                            var AISuggestion = (context as SmartSuggestionDataModel);
                                        }
                                        <div style="margin: 10px;">
                                            <div class="form-group" style="margin: 10px;">
                                                <SfTextBox ID="OrderID" @bind-Value="@(AISuggestion.Id)" Enabled="@enableTaskEditing" FloatLabelType="FloatLabelType.Always" Placeholder="Task ID" Width="100%"></SfTextBox>
                                            </div>
                                            <div class="form-group" style="margin: 10px;">
                                                <SfTextBox ID="Title" @bind-Value="@(AISuggestion.Title)" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Title" Width="100%"></SfTextBox>
                                            </div>
                                            <div class="form-group" style="margin: 10px;">
                                                <SfTextBox ID="Description" @bind-Value="@(AISuggestion.Description)" FloatLabelType="FloatLabelType.Always" Multiline="true" Placeholder="Description" Width="100%"></SfTextBox>
                                            </div>
                                            <div class="form-group" style="margin: 10px;">
                                                <SfNumericTextBox ID="Title" @bind-Value="@(AISuggestion.StoryPoints)" TValue="int" FloatLabelType="FloatLabelType.Always" Placeholder="StoryPoints" Width="100%"></SfNumericTextBox>
                                            </div>
                                            <div class="form-group" style="margin: 10px;">
                                                <SfTextBox ID="Status" @bind-Value="@(AISuggestion.Status)" Enabled="@enableTaskEditing" TValue="string" FloatLabelType="FloatLabelType.Always" Placeholder="Status" Width="100%"></SfTextBox>
                                            </div>
                                        </div>
                                    </Template>
                                </GridEditSettings>
                                <GridColumns>
                                    <GridColumn Field=@nameof(SmartSuggestionDataModel.Id) HeaderText="Task ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})"></GridColumn>
                                    <GridColumn Field=@nameof(SmartSuggestionDataModel.Title) HeaderText="Title" ValidationRules="@(new ValidationRules{ Required=true})" Format="C2"></GridColumn>
                                    <GridColumn Field=@nameof(SmartSuggestionDataModel.Description) HeaderText="Description" EditType=EditType.DefaultEdit></GridColumn>
                                    <GridColumn Field=@nameof(SmartSuggestionDataModel.StoryPoints) HeaderText="StoryPoints" ValidationRules="@(new ValidationRules{ Required=true})" EditType=EditType.DefaultEdit></GridColumn>
                                    <GridColumn Field=@nameof(SmartSuggestionDataModel.Status) HeaderText="Status" ValidationRules="@(new ValidationRules{ Required=true})"></GridColumn>
                                </GridColumns>
                            </SfGrid>
                        </div>
                    }
                    else if (showBacklogBoard)
                    {
                        <div>
                            <SfKanban TValue="SmartSuggestionDataModel" KeyField="Status" DataSource="@smartSuggestion">
                                <KanbanColumns>
                                    <KanbanColumn HeaderText="To Do" KeyField="@(new List<string>() {"Open"})"></KanbanColumn>
                                    <KanbanColumn HeaderText="In Progress" KeyField="@(new List<string>() {"InProgress"})"></KanbanColumn>
                                    <KanbanColumn HeaderText="Review" KeyField="@(new List<string>() {"Review"})"></KanbanColumn>
                                    <KanbanColumn HeaderText="Done" KeyField="@(new List<string>() {"Close"})"></KanbanColumn>
                                </KanbanColumns>
                                <KanbanCardSettings HeaderField="Title" ContentField="Description" GrabberField="Color">
                                    <Template>
                                        @{
                                            SmartSuggestionDataModel card = (SmartSuggestionDataModel)context;
                                            <div class="card-template">
                                                <div class="e-card-header">
                                                    <div class="e-card-header-caption">
                                                        <div class="e-card-header-title e-tooltip-text">@card.Title</div>
                                                    </div>
                                                </div>
                                                <div class="e-card-content">
                                                    <div class="e-text e-tooltip-text">@card.Description</div>
                                                </div>
                                                <div class="e-card-footer">
                                                    @{
                                                        <div class="e-card-tag e-tooltip-text">@card.StoryPoints</div>
                                                    }
                                                </div>
                                            </div>
                                        }
                                    </Template>
                                </KanbanCardSettings>
                            </SfKanban>
                        </div>
                    }
                }
            </div>
        </div>
    </div>
}
<SfToast @ref="ToastObj" ID="toast_type" Target="@ToastTarget" ShowCloseButton="true">
    <ToastPosition X="Right" Y="Top" />
</SfToast>
<SfDialog ShowCloseIcon="true" IsModal="true" Width="400px" @bind-Visible="@enableProjectDetailsDialog" CssClass="custom-dialog">
    <DialogTemplates>
        <Header>AI Smart Task Suggestion</Header>
        <Content>
            <div class="custom-row-1">
                <div class="col-12 col-md-6 d-flex cuscol-1 justify-content-start e-left">
                    <div class="w-100">
                        <div class="e-rte-label1" style="margin: 10px">
                            <label>Project Details</label>
                        </div>
                        <div class="e-rte-field" style="margin: 10px">
                            <SfTextBox @bind-Value="@TextBoxValue" Multiline=true />
                        </div>
                        <div class="e-rte-label2" style="margin: 10px; padding-top: 20px;">
                            <label>Number of tasks</label>
                        </div>
                        <div class="e-rte-field" style="margin: 10px">
                            <SfTextBox @bind-Value="@TasksValue" min="1" Type="InputType.Number" />
                        </div>
                    </div>
                </div>
            </div>
        </Content>
        <FooterTemplate>
            <div class="custom-row-2">
                <div class="col-12 d-flex cuscol-0">
                    <div class="w-100">
                        <SfProgressButton Content="@ContentGenerateTask" OnClick="@GenerateTasks" EnableProgress="false">
                            <ProgressButtonEvents OnBegin="BeginGenerateTasks" OnEnd="EndGenerateTasks"></ProgressButtonEvents>
                        </SfProgressButton>
                    </div>
                </div>
            </div>
        </FooterTemplate>
    </DialogTemplates>
    <DialogEvents OnClose="CloseDialog"></DialogEvents>
</SfDialog>

```

`Home.razor.cs`

```csharp
using System.Text.Json;
using AISamples.Components.Models;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Kanban;
using Syncfusion.Blazor.Notifications;

namespace AISamples.Components.Pages
{
    public partial class Home
    {
        SfToast ToastObj;
        public string[] SelectedAssignees { get; set; } = new string[] { };
        private string ToastTarget { get; set; } = "#toast-kanban-observable";
        SfKanban<SmartSuggestionDataModel> kanbanObj;
        public string ContentGenerateTask = "Generate Tasks";
        public string BacklogButtonViewContent = "View as Backlog";
        private string TextBoxValue = string.Empty;
        private string TasksValue = string.Empty;
        private bool enableProjectDetailsDialog = false;
        private bool isGeneratedProjectTasks = false;
        private bool enableTaskEditing = false;
        private bool isHomapage = true;
        private bool showSprintBoard = false;
        private bool showBacklogs = false;
        private bool showBacklogBoard = true;
        private List<SmartSuggestionDataModel> smartSuggestion = new List<SmartSuggestionDataModel>();
        private DialogSettings DialogParams = new DialogSettings { MinHeight = "400px", Width = "450px" };
        private string waringText = "Click \"Generate Tasks\" to preview";
        private void GoToBacklogBoardView()
        {
            if (BacklogButtonViewContent == "View as Board")
            {
                BacklogButtonViewContent = "View as Backlog";
                showBacklogBoard = true;
            }
            else
            {
                showBacklogBoard = false;
                BacklogButtonViewContent = "View as Board";
            }
            showSprintBoard = false;
        }
        private RenderFragment GetTemplate() => builder =>
        {
            builder.OpenElement(0, "div");
            builder.AddContent(1, "An error occurred during the AI process, Please try again.");
            builder.CloseElement();
        };
        public void BeginGenerateTasks(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
        {
            ContentGenerateTask = "Generating...";
        }
        public async Task EndGenerateTasks(Syncfusion.Blazor.SplitButtons.ProgressEventArgs args)
        {
            while (!isGeneratedProjectTasks)
            {
                await Task.Delay(1000);
            }
            this.isHomapage = false;
            this.CloseDialog();
            showBacklogs = true;
        }
        private async Task GenerateProjectTasks()
        {
            try
            {
                if (!string.IsNullOrEmpty(TextBoxValue) && !string.IsNullOrEmpty(TasksValue))
                {
                    string result = "";
                    var description = $"Generate {TasksValue} task recommendations for {TextBoxValue}. Each task should include the following fields: Id (like example: ID should be in project name simple 4char word - 1), Title, Status, Description, Assignee, StoryPoints, Color and Due Date, formatted according to the dataset. Assign each task to the Assignee: empty string, set the Status to 'Open', and use black for the Color. Use the dataset provided below to create your recommendations. IMPORTANT: Return the data strictly in JSON format with all the required fields. Only the JSON data is needed, no additional text.Return only the JSON array format without any explanations.";
                    result = await OpenAIService.GetCompletionAsync(description);
                    if (result != null)
                    {
                        string data = result.Replace("```json", "").Replace("```", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
                        List<SmartSuggestionDataModel> modifiedData;
                        modifiedData = JsonSerializer.Deserialize<List<SmartSuggestionDataModel>>(data);
                        smartSuggestion = modifiedData != null ? smartSuggestion.Concat(modifiedData).ToList() : smartSuggestion;
                        this.isGeneratedProjectTasks = true;
                    }
                    ContentGenerateTask = "Generate Tasks";
                }
                else
                {
                    waringText = string.IsNullOrEmpty(TextBoxValue) && string.IsNullOrEmpty(TasksValue) ? "Enter the required task creation details" : !string.IsNullOrEmpty(TasksValue) ? "Enter the Project Details" : "Enter the number of tasks";
                }
            }
            catch
            {
                await this.ToastObj.ShowAsync(new ToastModel { ContentTemplate = @GetTemplate(), ShowCloseButton = true, Timeout = 0 });
            }
        }
        private void OpenProjectDetailsDialog()
        {
            this.enableProjectDetailsDialog = true;
        }
        private async Task GenerateTasks()
        {
            this.isGeneratedProjectTasks = false;
            await this.GenerateProjectTasks();
        }
        private void SaveTask()
        {
            this.enableProjectDetailsDialog = false;
            this.TasksValue = string.Empty;
            this.TextBoxValue = string.Empty;
            this.isGeneratedProjectTasks = false;
            StateHasChanged();
        }
        private void CloseDialog()
        {
            this.enableProjectDetailsDialog = false;
            this.TasksValue = string.Empty;
            this.TextBoxValue = string.Empty;
            this.isGeneratedProjectTasks = false;
            StateHasChanged();
        }
        public void TaskEditingHandler(Syncfusion.Blazor.Grids.ActionEventArgs<SmartSuggestionDataModel> args)
        {
            if (args.RequestType.ToString() == "Add")
            {
                enableTaskEditing = true;
            }
            else
            {
                enableTaskEditing = false;
            }
        }
        public void RowCreatedHandler(RowCreatedEventArgs<SmartSuggestionDataModel> args)
        {
            args.Data.Status = "Open";
            args.Data.Color = "#000000";
        }
    }
}

```

## Error Handling and Troubleshooting

If the AI service fails to return a valid response, the Kanban will display an error message ("Oops! Please try again!"). Common issues include:

- **Invalid API Key or Endpoint**: Verify that the `openAIApiKey`, `azureOpenAIKey`, or Ollama `Endpoint` is correct and the service is accessible.
- **Model Unavailable**: Ensure the specified `openAIModel`, `azureOpenAIModel`, or `ModelName` is deployed and supported.
- **Network Issues**: Check connectivity to the AI service endpoint, especially for self-hosted Ollama instances.
- **Large Prompts**: Processing large text inputs may cause timeouts. Consider reducing the prompt size or optimizing the request for efficiency.

## Performance Considerations

When handling large text content, ensure the Ollama server has sufficient resources (CPU/GPU) to process requests efficiently. For long-form content or batch operations, consider splitting the input into smaller segments to avoid performance bottlenecks. Test the application with your specific use case to determine optimal performance.

## Sample Code

A complete working example is available in the [Syncfusion Blazor AI Samples GitHub repository](https://github.com/syncfusion/smart-ai-samples).

![Kanban AI Assistant - Output](../../ai/images/smart-task-suggestion.png)