---
layout: post
title: Getting Started with Diagram Component in Blazor MAUI App | Syncfusion
description: Checkout and learn about the documentation for getting started with Blazor Diagram Component in Blazor MAUI App.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Getting Started with the Diagram Component in the Blazor MAUI App

This guide walks through the step-by-step process of integrating the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Diagram component into a Blazor MAUI application using either Visual Studio or Visual Studio Code.

> **Ready to streamline your Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor development?** <br/>Discover the full potential of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components with Syncfusion<sup style="font-size:70%">&reg;</sup> AI Coding Assistants. Effortlessly integrate, configure, and enhance your projects with intelligent, context-aware code suggestions, streamlined setups, and real-time insights—all seamlessly integrated into your preferred AI-powered IDEs like VS Code, Cursor, Syncfusion<sup style="font-size:70%">&reg;</sup> CodeStudio and more. [Explore Syncfusion<sup style="font-size:70%">&reg;</sup> AI Coding Assistants](https://blazor.syncfusion.com/documentation/ai-coding-assistant/overview)

Additionally, you can find a fully functional example project on our [GitHub repository](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DiagramComponent).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

To use the MAUI project templates, install the Mobile development with the .NET extension for Visual Studio. For more details, refer to [here](https://learn.microsoft.com/en-us/dotnet/MAUI/get-started/installation?tabs=vswin) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Step 1: How to Create a New Blazor MAUI App in Visual Studio

Create a Blazor MAUI App using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/dotnet/maui/get-started/first-app?pivots=devices-windows&view=net-maui-9.0&tabs=vswin). For detailed instructions, refer to [this Blazor MAUI App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/maui-blazor-app) documentation.

## Step 2: How to Install Diagram NuGet Package in Blazor MAUI App

To add the **Blazor Diagram**  component in the app, open the NuGet package manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), search and install [Syncfusion.Blazor.Diagram](https://www.nuget.org/packages/Syncfusion.Blazor.Diagram) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Diagram -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Step 3: Add Import Namespaces

Open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Diagram` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor 
@using Syncfusion.Blazor.Diagram

{% endhighlight %}
{% endtabs %}


## Step 4: How to Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/MauiProgram.cs** file.

{% tabs %}
{% highlight c# tabtitle="~/MauiProgram.cs" hl_lines="3 20" %}

using Microsoft.Extensions.Logging;
using MauiBlazorWindow.Data;
using Syncfusion.Blazor;

namespace MauiBlazorWindow;

    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSyncfusionBlazor();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }

{% endhighlight %}
{% endtabs %}

## Step 5: How to Add Stylesheet and Script Resources

Add the following stylesheet and script to the head section of the **~/wwwroot/index.html** file.

If using Syncfusion.Blazor && Syncfusion.Blazor.Themes NuGet package in your application, refer to the following script.
```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
If using Syncfusion.Blazor.Diagram && Syncfusion.Blazor.Themes NuGet package in your application, refer to the following script.
```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

## Step 6: To Configure Azure OpenAI Service

For **Azure OpenAI**, first [deploy an Azure OpenAI Service resource and model](https://learn.microsoft.com/en-us/azure/ai-foundry/openai/how-to/create-resource?view=foundry-classic&pivots=web-portal); then the values for `apiKey`, `deploymentName`, and `endpoint` will be provided.

**Install the following NuGet packages to your project:**

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Azure.AI.OpenAI
Install-Package Syncfusion.Blazor.AI
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI --version 9.8.0-preview.1.25412.6

{% endhighlight %}
{% endtabs %}

**To configure the AI service, add the following settings to the ~/MauiProgram.cs file in your project.**

{% tabs %}
{% highlight c# tabtitle="~/MauiProgram.cs" hl_lines=" 2-5 11-24" %}

using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using AIService;
using System.ClientModel;

....

builder.Services.AddSyncfusionBlazor();

string azureOpenAIKey = "AZURE_OPENAI_KEY";
string azureOpenAIEndpoint = "AZURE_OPENAI_ENDPOINT";
string azureOpenAIModel = "AZURE_OPENAI_MODEL";

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(azureOpenAIEndpoint),
     new ApiKeyCredential(azureOpenAIKey)
);

IChatClient AIChatClient = azureOpenAIClient.GetChatClient(azureOpenAIModel).AsIChatClient();
builder.Services.AddScoped<AzureAIService>(serviceProvider  =>
{
    return new AzureAIService(AIChatClient);
});

{% endhighlight %}
{% endtabs %}

**Create a Azure AI Service**

`AzureAIService` is a small wrapper around an injected `IChatClient` that lets you:

* Send a prompt to an AI chat/completions endpoint (e.g., Azure OpenAI or any service conforming to your IChatClient abstraction).
* Optionally control the response format (strict JSON or free-form text) via a system instruction.
* Adjust generation settings like temperature, top‑p, penalties, and max tokens.
* Receive the AI’s completion as a string.

{% tabs %}
{% highlight c# tabtitle="~/AzureAIService.cs" %}

using Microsoft.Extensions.AI;
using Syncfusion.Blazor.AI;
using System;

namespace AIService
{
    public class AzureAIService
    {
        private IChatClient _chatClient;

        public AzureAIService(IChatClient client)
        {
            this._chatClient = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<string> GetCompletionAsync(string prompt, bool returnAsJson = true,  string systemRole = null, int outputTokens = 2000)
        {
            string systemMessage = returnAsJson ? "You are a helpful assistant that only returns and replies with valid, iterable RFC8259 compliant JSON in your responses unless I ask for any other format. Do not provide introductory words such as 'Here is your result' or '```json', etc. in the response" : !string.IsNullOrEmpty(systemRole) ? systemRole : "You are a helpful assistant";
            try
            {
                ChatParameters chatParameters = new ChatParameters();
                chatParameters.Messages = new List<ChatMessage>(2) {
                    new ChatMessage (ChatRole.System, systemMessage),
                    new ChatMessage(ChatRole.User,prompt),
                };
                string completion = await GetChatResponseAsync(chatParameters);
                return completion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception has occurred: {ex.Message}");
                return "";
            }
        }

        public async Task<string> GetChatResponseAsync(ChatParameters options)
        {
            ChatOptions completionRequest = new ChatOptions
            {
                Temperature = options.Temperature ?? 0.5f,
                TopP = options.TopP ?? 1.0f,
                MaxOutputTokens = options.MaxTokens ?? 2000,
                FrequencyPenalty = options.FrequencyPenalty ?? 0.0f,
                PresencePenalty = options.PresencePenalty ?? 0.0f,
                StopSequences = options.StopSequences
            };
            try
            {
                ChatResponse completion = await _chatClient.GetResponseAsync(options.Messages, completionRequest);
                return completion.Text.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Create an AI Assist Button with Icon**

This Razor snippet places a Floating Action Button (FAB) with an AI icon on top of a diagram surface. When the FAB is clicked, it opens a modal dialog titled AI Assist. The dialog shows:

* A set of suggested prompt buttons (one‑click actions).
* A textbox for custom prompts.
* A send button that calls your AI service to generate a mind map diagram based on the prompt.

{% tabs %}
{% highlight c# tabtitle="~/DiagramOpenAI.razor" %}

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
@using AIService
@inject AzureAIService ChatGptService
@namespace TextToMindMapDiagram

<SfFab IconCss="e-icons e-ai-chat" Content="AI Assist" OnClick="OnFabClicked" Target="#diagram-area"></SfFab>
<SfDialog Width="570px" IsModal="true" ShowCloseIcon="true" CssClass="custom-dialog" Visible="@ShowAIAssistDialog">
    <DialogTemplates>
        <Header> <span class="e-icons e-ai-chat" style="color: black; font-size: 16px;"></span> AI Assist</Header>
        <Content>
            <p style="margin-bottom: 10px;">Suggested Prompts</p>
                <SfButton style="flex: 1; overflow: visible; border-radius: 8px;margin-bottom: 10px;" @onclick="()=>GenerateMindMap(MobileBankingPrompt)">Mindmap diagram for Mobile banking registration</SfButton>
                <SfButton style="flex: 1; overflow: visible; border-radius: 8px;margin-bottom: 10px;" @onclick="()=>GenerateMindMap(OrganizationalResearchPrompt)">Mindmap diagram for Organizational research</SfButton>
                <SfButton style="flex: 1; overflow: visible; border-radius: 8px;margin-bottom: 10px;" @onclick="()=>GenerateMindMap(MeetingAgendaPrompt)">Mindmap diagram for Meeting agenda</SfButton>
            
            <div style="display: flex; flex: 95%; margin-top:20px;">
                    <SfTextBox @bind-Value="@OpenAIPrompt" CssClass="db-openai-textbox" Height="32px" Placeholder="Please enter your prompt for generating a mindmap diagram..." autofocus style="font-size: 14px;"></SfTextBox>
                <SfButton @onclick="@GetResponseFromAI" CssClass="e-icons e-flat e-send" IsPrimary="true" style="height: 38px; width: 38px; margin-left: 5px; padding: 0;"></SfButton>
            </div>
        </Content>
    </DialogTemplates>
    <DialogEvents Closed="@DialogClose"></DialogEvents>
</SfDialog>

{% endhighlight %}
{% endtabs %}

**Generate Mind Map from AI Prompt**

This handles the core logic that takes the user’s prompt, sends it to the AI service, processes the AI response, and renders a mind map diagram in the application using the `LoadDiagramFromMermaidAsync` method. It also manages UI states like showing a loading indicator and closing the dialog.

{% tabs %}
{% highlight c# tabtitle="~/DiagramOpenAI.razor.cs" %}

namespace TextToMindMapDiagram
{
    public partial class DiagramOpenAI
    {
        public Home Parent;
        public bool ShowAIAssistDialog = false;
        public string OpenAIPrompt;
        string MobileBankingPrompt = "Mindmap diagram for Mobile banking registration";
        string OrganizationalResearchPrompt = "Mindmap diagram for Organizational research";
        string MeetingAgendaPrompt = "Mindmap diagram for Meeting agenda";
        public void OnFabClicked()
        {
            ShowAIAssistDialog = !ShowAIAssistDialog;
        }
        private void DialogClose(Object args)
        {
            ShowAIAssistDialog = false;
        }

        public async void GenerateMindMap(string value)
        {
            OpenAIPrompt = value;
            await GetResponseFromAI();
            StateHasChanged();
        }

        public async Task GetResponseFromAI()
        {
            Parent.IsGeneratingFromAI = true;
            ShowAIAssistDialog = false;
            if (!string.IsNullOrWhiteSpace(OpenAIPrompt))
            {
                await Parent.SpinnerRef!.ShowAsync();
                string result = string.Empty;
                string systemRole = "You are an expert in creating mind map diagram data sources. Generate a structured data source for a mind map based on the user's query, using tab indentation to indicate hierarchy. The root parent should have no indentation, while each subsequent child level should be indented by one tab space. Avoid using any symbols such as '+' or '-' before any level of data.";
                string userPrompt = $"Based on the following input, create a mind map diagram data source: {OpenAIPrompt}.";
                result = await ChatGptService.GetCompletionAsync(userPrompt, false, systemRole);
                if (result != null)
                {
                    List<string> filteredData = result
                    .Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .ToList();
                    if (filteredData[0].Trim() != "mindmap")
                        filteredData.Insert(0, "mindmap");
                    filteredData[1].TrimStart('-', '+');
                    result = string.Join("\n", filteredData);
                    Parent.Diagram!.BeginUpdate();
                    Parent.Diagram.StartGroupAction();
                    await Parent.Diagram.LoadDiagramFromMermaidAsync(result);
                    Parent.Diagram.EndGroupAction();
                    await Parent.Diagram.EndUpdateAsync();
                    StateHasChanged();
                }
                await Parent.SpinnerRef.HideAsync();
            }
            Parent.IsGeneratingFromAI = false;
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Generate a main diagram page**

This page renders an interactive mind map workspace built with Syncfusion Diagram.

* `SfDiagramComponent`: The primary diagram canvas.
* `Spinner`: Shows progress during async generation.
* `DiagramOpenAI`: Custom component reference for AI features (used externally).
* Many diagram events configured for creation, selection, layout, custom tools, etc.
* `OnAfterRenderAsync`: On first render, wires up the DiagramOpenAIRef parent link (for external AI integration).

{% tabs %}
{% highlight c# tabtitle="~/Home.razor" %}

@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Spinner
@using System.Collections.ObjectModel
@using System.Text.Json;
@using Syncfusion.Blazor.Navigations
@using NodeShape = Syncfusion.Blazor.Diagram.NodeShapes
@using TextToMindMapDiagram
@using AIService

@inject AzureAIService ChatGptService
@namespace TextToMindMapDiagram

@*Hidden:Lines*@
@inject NavigationManager NavigationManager
@*End:Hidden*@

<div class="col-lg-12 control-section">
    <div class="content-wrapper">
        <div class="diagrambuilder-container" style="height: calc(100% - 350px); width: 100%">
            <div style="border: 2px solid #ccc;">
            <div class="diagram-area">
                <SfDiagramComponent ID="diagram-area" @ref="@Diagram" @bind-InteractionController="@interactionController" @bind-Nodes="@nodes" @bind-Connectors="@connectors" CollectionChanging="CollectionChanging" @bind-Height="@height" @bind-Width="@width" GetCustomTool="@GetCustomTool" NodeCreating="@NodeCreating" ConnectorCreating="@ConnectorCreating" @bind-SelectionSettings="@selectionSettings" SelectionChanging="OnSelectionChanging" Created="OnCreated">
                    <ScrollSettings @bind-ScrollLimit="@scrollLimit" @bind-CurrentZoom="@CurrentZoom" @bind-MaxZoom="@maxZoom" @bind-MinZoom="@minZoom"></ScrollSettings>
                    <Layout @bind-HorizontalSpacing="@HorizontalSpacing" @bind-VerticalSpacing="@VerticalSpacing" @bind-Type="@layoutType" GetBranch="@getbranch"></Layout>
                    <SnapSettings @bind-Constraints="@SnapConstraint"></SnapSettings>
                    <PageSettings MultiplePage="true"></PageSettings>
                    <CommandManager @bind-Commands="@commands" Execute="@ExecuteCommand" CanExecute="@CanExecute" />
                    <SfSpinner @ref="@SpinnerRef" Label="Generating diagram...." Type="@SpinnerType.Bootstrap"> </SfSpinner>
                </SfDiagramComponent>
            </div>
            </div>
            <DiagramOpenAI @ref="DiagramOpenAIRef"></DiagramOpenAI>
        </div>
    </div>
</div>
@code
{
    public SfDiagramComponent? Diagram;
    public SfSpinner? SpinnerRef;
    public DiagramOpenAI? DiagramOpenAIRef;
    private SnapConstraints SnapConstraint = SnapConstraints.ShowLines;
    private double CurrentZoom { get; set; } = 1;
    public bool IsGeneratingFromAI = false;
    /// <summary>
    /// Collection of keyboard commands for the diagram.
    /// </summary>
    private DiagramObjectCollection<KeyboardCommand> commands = new DiagramObjectCollection<KeyboardCommand>();
    /// <summary>
    /// The minimum zoom level allowed for the diagram.
    /// </summary>
    private double minZoom { get; set; } = 0.25;
    /// <summary>
    /// The maximum zoom level allowed for the diagram.
    /// </summary>
    private double maxZoom { get; set; } = 30;
    /// <summary>
    /// Specifies whether the undo functionality is enabled in the diagram.
    /// </summary>
    private bool IsUndo = false;
    /// <summary>
    /// Specifies whether the redo functionality is enabled in the diagram.
    /// </summary>
    private bool IsRedo = false;
    /// <summary>
    /// Specifies whether the diagram is selected.
    /// </summary>
    private bool diagramSelected = false;
    /// <summary>
    /// Represents an array of fill colors.
    /// </summary>
    private static string[] fillColorCode = { "#C4F2E8", "#F7E0B3", "#E5FEE4", "#E9D4F1", "#D4EFED", "#DEE2FF" };
    /// <summary>
    /// Represents an array of border colors.
    /// </summary>
    private static string[] borderColorCode = { "#8BC1B7", "#E2C180", "#ACCBAA", "#D1AFDF", "#90C8C2", "#BBBFD6" };
    /// <summary>
    /// Represents the last fill index, an integer.
    /// </summary>
    private static int lastFillIndex = 0;
    private LayoutType layoutType = LayoutType.MindMap;
    private string height = "700px";
    private string width = "100%";
    private DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    private DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    private ScrollLimitMode scrollLimit { get; set; } = ScrollLimitMode.Diagram;
    private DiagramInteractions interactionController = DiagramInteractions.SingleSelect;
    private int VerticalSpacing = 20;
    private int HorizontalSpacing = 80;
    private DiagramSelectionSettings selectionSettings = new DiagramSelectionSettings();
    private DiagramObjectCollection<UserHandle> handles = new DiagramObjectCollection<UserHandle>();
    
    private List<MindMapDetails> MindmapData = new List<MindMapDetails>()
    {
        new MindMapDetails(){Id="node1",Label="Business Planning",ParentId ="",Branch= BranchType.Root, Fill="#D0ECFF", Level = 0 },
        new MindMapDetails(){Id="node2",Label= "Expectation",ParentId = "node1",Branch= BranchType.Left,Fill= "#C4F2E8", Level = 1  },
        new MindMapDetails(){Id="node3",Label= "Requirements", ParentId="node1",Branch= BranchType.Right,Fill= "#F7E0B3", Level = 1  },
        new MindMapDetails(){Id="node4",Label= "Marketing", ParentId="node1",Branch= BranchType.Left,Fill= "#E5FEE4", Level = 1  },
        new MindMapDetails(){Id="node5",Label= "Budgets",ParentId= "node1",Branch= BranchType.Right,Fill= "#E9D4F1", Level = 1  },
        new MindMapDetails(){ Id="node6", Label="Situation in Market", ParentId= "node1", Branch = BranchType.Left, Fill= "#D4EFED", Level = 1  },
        new MindMapDetails(){ Id="node7", Label="Product Sales", ParentId= "node2", Branch = BranchType.SubLeft, Fill= "#C4F2E8", Level = 2  },
        new MindMapDetails() { Id = "node8", Label= "Strategy", ParentId="node2", Branch = BranchType.SubLeft, Fill="#C4F2E8", Level = 2  },
        new MindMapDetails() { Id = "node9", Label="Contacts", ParentId="node2", Branch = BranchType.SubLeft, Fill="#C4F2E8", Level = 2  },
        new MindMapDetails() { Id = "node10", Label="Customer Groups", ParentId= "node4", Branch = BranchType.SubLeft,Fill= "#E5FEE4", Level = 2  },
        new MindMapDetails() { Id = "node11", Label= "Branding", ParentId= "node4", Branch = BranchType.SubLeft, Fill= "#E5FEE4", Level = 2  },
        new MindMapDetails() { Id = "node12", Label= "Advertising", ParentId= "node4", Branch = BranchType.SubLeft, Fill= "#E5FEE4", Level = 2  },
        new MindMapDetails() { Id = "node13", Label= "Competitors", ParentId= "node6", Branch = BranchType.SubLeft, Fill="#D4EFED", Level = 2  },
        new MindMapDetails() { Id = "node14", Label="Location", ParentId="node6", Branch = BranchType.SubLeft, Fill= "#D4EFED", Level = 2  },
        new MindMapDetails() { Id = "node15", Label= "Director", ParentId= "node3", Branch = BranchType.SubRight, Fill="#F7E0B3", Level = 2  },
        new MindMapDetails() { Id = "node16", Label="Accounts Department", ParentId= "node3", Branch = BranchType.SubRight, Fill= "#F7E0B3", Level = 2  },
        new MindMapDetails() { Id = "node17", Label="Administration", ParentId= "node3", Branch = BranchType.SubRight, Fill="#F7E0B3", Level = 2  },
        new MindMapDetails() { Id = "node18", Label= "Development", ParentId="node3", Branch = BranchType.SubRight, Fill= "#F7E0B3", Level = 2  },
        new MindMapDetails() { Id = "node19", Label= "Estimation", ParentId= "node5", Branch = BranchType.SubRight, Fill="#E9D4F1", Level = 2  },
        new MindMapDetails() { Id = "node20", Label= "Profit", ParentId= "node5", Branch = BranchType.SubRight, Fill= "#E9D4F1", Level = 2  },
        new MindMapDetails(){ Id="node21", Label="Funds", ParentId= "node5", Branch = BranchType.SubRight, Fill= "#E9D4F1", Level = 2  }
    };

    private void CollectionChanging(CollectionChangingEventArgs args)
    {
        if (args.Action == CollectionChangedAction.Add && IsGeneratingFromAI)
        {
            Connector? connector = args.Element as Connector;
            if (connector != null)
            {
                UpdateMermaidNodeInfo(connector);
            }
        }
    }

    BranchType CurrentBranch = BranchType.Left;

    private void UpdateMermaidNodeInfo(Connector connector)
    {
        Node? sourceNode = Diagram!.GetObject(connector.SourceID) as Node;
        Node? targetNode = Diagram.GetObject(connector.TargetID) as Node;
        if (connector.ID == Diagram.Connectors![0].ID)
        {
            CurrentBranch = BranchType.Left;
            sourceNode!.AdditionalInfo!["ParentId"] = "";
            sourceNode.AdditionalInfo["Orientation"] = BranchType.Root;
            sourceNode.AdditionalInfo["Level"] = 0;
            sourceNode.Style!.Fill = "#D0ECFF";
            sourceNode.Style.StrokeColor = "#80BFEA";
        }
        if (sourceNode != null && (BranchType)sourceNode.AdditionalInfo!["Orientation"] == BranchType.Root)
        {
            targetNode!.AdditionalInfo!["ParentId"] = sourceNode.ID;
            targetNode.AdditionalInfo["Orientation"] = CurrentBranch;
            targetNode.AdditionalInfo["Level"] = 1;
            CurrentBranch = (CurrentBranch == BranchType.Left) ? BranchType.Right : BranchType.Left;
        }
        else
        {
            BranchType sourceNodeBranch = (BranchType)sourceNode!.AdditionalInfo!["Orientation"];
            targetNode!.AdditionalInfo!["ParentId"] = sourceNode.ID;
            targetNode.AdditionalInfo["Orientation"] = (sourceNodeBranch == BranchType.Left || sourceNodeBranch == BranchType.SubLeft) ? BranchType.SubLeft : BranchType.SubRight;
            targetNode.AdditionalInfo["Level"] = Convert.ToDouble(sourceNode.AdditionalInfo["Level"]) + 1;
        }

        UpdateNodeStyles(targetNode, sourceNode);
        BranchType targetNodeBranch = (BranchType)targetNode.AdditionalInfo["Orientation"];
        if (targetNodeBranch == BranchType.Right || targetNodeBranch == BranchType.SubRight)
        {
            connector.SourcePortID = sourceNode.Ports![0].ID;
            connector.TargetPortID = targetNode.Ports![1].ID;
        }
        else if (targetNodeBranch == BranchType.Left || targetNodeBranch == BranchType.SubLeft)
        {
            connector.SourcePortID = sourceNode.Ports![1].ID;
            connector.TargetPortID = targetNode.Ports![0].ID;
        }
    }

    /// <summary>
    /// This Method to execute the custom command.
    /// </summary>
    private async Task ExecuteCommand(CommandKeyArgs obj)
    {
        if (obj.Name == "leftChild")
        {
            if (Diagram!.SelectionSettings != null && Diagram.SelectionSettings.Nodes!.Count > 0)
            {
                Diagram.StartGroupAction();
                BranchType type = (BranchType)Diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Orientation"];
                if (type == BranchType.SubRight || type == BranchType.Right)
                {
                    await AddLeftChild(Diagram);
                }
                else if (type == BranchType.SubLeft || type == BranchType.Left || type == BranchType.Root)
                {
                    await AddRightChild(Diagram);
                }
                Diagram.ClearSelection();
                Diagram.Select(new ObservableCollection<IDiagramObject>() { Diagram.Nodes![Diagram.Nodes.Count - 1] });
                Diagram.EndGroupAction();
            }
        }
        if (obj.Name == "rightChild")
        {
            if (Diagram!.SelectionSettings != null && Diagram.SelectionSettings.Nodes!.Count > 0)
            {
                Diagram.StartGroupAction();
                BranchType type = (BranchType)Diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Orientation"];
                if (type == BranchType.SubLeft || type == BranchType.Left)
                {
                    await AddRightChild(Diagram);
                }
                else if (type == BranchType.SubRight || type == BranchType.Right || type == BranchType.Root)
                {
                    await AddLeftChild(Diagram);
                }
                Diagram.ClearSelection();
                Diagram.Select(new ObservableCollection<IDiagramObject>() { Diagram.Nodes![Diagram.Nodes.Count - 1] });
                Diagram.EndGroupAction();
            }
        }
        if (obj.Name == "sibilingChildTop")
        {
            Node rootNode = Diagram!.Nodes!.Where(node => node.InEdges!.Count == 0).ToList()[0];
            if (rootNode.ID != Diagram.SelectionSettings!.Nodes![0].ID)
            {
                Diagram.StartGroupAction();
                string nodeParent = Convert.ToString(Diagram.SelectionSettings.Nodes[0].AdditionalInfo!["ParentId"])!;
                string parentID = nodeParent;
                Node? parentNode = Diagram.GetObject(parentID) as Node;
                BranchType branch = (BranchType)(parentNode!.AdditionalInfo!["Orientation"]);
                BranchType nodeBranch = (BranchType)(Diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Orientation"]);
                if (branch == BranchType.SubRight || branch == BranchType.Right || (branch == BranchType.Root && nodeBranch == BranchType.Right))
                {
                    await AddLeftChild(Diagram, true);
                }
                else
                {
                    await AddRightChild(Diagram, true);
                }
                Diagram.ClearSelection();
                Diagram.Select(new ObservableCollection<IDiagramObject>() { Diagram.Nodes![Diagram.Nodes.Count - 1] });
                Diagram.EndGroupAction();
            }
        }
        if (obj.Name == "navigationDown")
        {
            NavigateChild("Bottom");
        }
        if (obj.Name == "navigationUp")
        {
            NavigateChild("Top");
        }
        if (obj.Name == "navigationLeft")
        {
            NavigateChild("Right");
        }
        if (obj.Name == "navigationRight")
        {
            NavigateChild("Left");
        }
        if (obj.Name == "deleteChid" || obj.Name == "delete" || obj.Name == "backspace")
        {
            Diagram!.BeginUpdate();
            RemoveData(Diagram.SelectionSettings!.Nodes![0], Diagram);
        _ = Diagram.EndUpdateAsync();
        await Diagram.DoLayoutAsync();
        }
        if (obj.Name == "fitPage")
        {
            FitOptions fitoption = new FitOptions()
            {
                Mode = FitMode.Both,
                Region = DiagramRegion.PageSettings,
            };
            Diagram?.FitToPage(fitoption);
        }
        if (obj.Name == "duplicate")
        {
            Diagram?.Copy();
        }
        if (obj.Name == "fileNew")
        {
            Diagram?.Clear();
            Diagram?.BeginUpdate();
            StateHasChanged();
        }
        if (obj.Name == "fileOpen")
        {
        }
        if (obj.Name == "fileSave")
        {
            string fileName = "diagram";
        }
    }

    /// <summary>
    /// This method is used to navigate between the nodes
    /// </summary>
    private void NavigateChild(string direction)
    {
        SfDiagramComponent diagram = Diagram!;
        Node? node = null;
        List<Node> sameLevelNodes = new List<Node>();
        if (direction == "Top" || direction == "Bottom")
        {
            sameLevelNodes = GetSameLevelNodes();
            int index = sameLevelNodes.IndexOf(diagram.SelectionSettings!.Nodes![0]);
            node = direction == "Top" ? sameLevelNodes[index == 0 ? 0 : index - 1] : sameLevelNodes[index == (sameLevelNodes.Count - 1) ? index : index + 1];
        }
        else
            node = GetMinDistanceNode(diagram, direction);
        if (node != null)
        {
            diagram.Select(new ObservableCollection<IDiagramObject>() { node });
        }

    }

    /// <summary>
    /// This method is used to return a minimum distance node whie navigating between left and right
    /// </summary>
    private Node GetMinDistanceNode(SfDiagramComponent diagram, string direction)
    {
        Node node = diagram.SelectionSettings!.Nodes![0];
        double? nodeWidth = (node.Width == null) ? node.MinWidth : node.Width;
        DiagramRect parentBounds = new DiagramRect((node.OffsetX - (nodeWidth / 2)), node.OffsetY - (node.Height / 2), nodeWidth, node.Height);
        DiagramRect childBounds = new DiagramRect();
        double oldChildBoundsTop = 0;
        Node? childNode = null;
        Node? lastChildNode = null;
        Node? leftOrientationFirstChild = null;
        Node? rightOrientationFirstChild = null;
        Node rootNode = diagram.Nodes!.Where(node => node.InEdges!.Count == 0).ToList()[0];
        if (node.ID == rootNode.ID)
        {
            List<string> edges = node.OutEdges!;
            for (int i = 0; i < edges!.Count; i++)
            {
                Connector connector = GetConnector(diagram.Connectors!, edges[i])!;
                childNode = GetNode(diagram.Nodes!, connector!.TargetID!);
                if (Convert.ToString((BranchType)childNode!.AdditionalInfo!["Orientation"]) == direction)
                {
                    if (direction == "Left" && leftOrientationFirstChild == null)
                        leftOrientationFirstChild = childNode;
                    if (direction == "Right" && rightOrientationFirstChild == null)
                        rightOrientationFirstChild = childNode;
                    double? childNodeWidth = (childNode.Width == null) ? childNode.MinWidth : childNode.Width;
                    childBounds = new DiagramRect((childNode.OffsetX - (childNodeWidth / 2)), childNode.OffsetY - (childNode.Height / 2), childNodeWidth, childNode.Height);
                    if (parentBounds.Top >= childBounds.Top && (childBounds.Top >= oldChildBoundsTop || oldChildBoundsTop == 0))
                    {
                        oldChildBoundsTop = childBounds.Top;
                        lastChildNode = childNode;
                    }
                }
            }
            if (lastChildNode != null)
                lastChildNode = direction == "Left" ? leftOrientationFirstChild : rightOrientationFirstChild;
        }
        else
        {
            List<string>? edges = new List<string>();
            string selectType = string.Empty;
            string orientation = ((BranchType)node.AdditionalInfo!["Orientation"]).ToString();
            if (orientation == "Left" || orientation == "SubLeft")
            {
                edges = direction == "Left" ? node.OutEdges : node.InEdges;
                selectType = direction == "Left" ? "Target" : "Source";
            }
            else
            {
                edges = direction == "Right" ? node.OutEdges : node.InEdges;
                selectType = direction == "Right" ? "Target" : "Source";
            }
            for (int i = 0; i < edges!.Count; i++)
            {
                Connector connector = GetConnector(diagram.Connectors!, edges[i]!)!;
                childNode = GetNode(diagram.Nodes!, selectType == "Target" ? connector!.TargetID! : connector!.SourceID!);
                if (childNode!.ID == rootNode.ID)
                    lastChildNode = childNode;
                else
                {
                    double? childNodeWidth = (childNode.Width == null) ? childNode.MinWidth : childNode.Width;
                    childBounds = new DiagramRect((childNode.OffsetX - (childNodeWidth / 2)), childNode.OffsetY - (childNode.Height / 2), childNodeWidth, childNode.Height);
                    if (selectType == "Target")
                    {
                        if (parentBounds.Top >= childBounds.Top && (childBounds.Top >= oldChildBoundsTop || oldChildBoundsTop == 0))
                        {
                            oldChildBoundsTop = childBounds.Top;
                            lastChildNode = childNode;
                        }
                    }
                    else
                        lastChildNode = childNode;
                }
            }
        }
        return lastChildNode!;
    }

    /// <summary>
    /// This method is used to return a same level nodes
    /// </summary>

    private List<Node> GetSameLevelNodes()
    {
        List<Node> sameLevelNodes = new List<Node>();
        SfDiagramComponent? diagram = Diagram;
        if (diagram!.SelectionSettings!.Nodes!.Count > 0)
        {
            Node node = diagram.SelectionSettings.Nodes[0];
            string orientation = ((BranchType)node.AdditionalInfo!["Orientation"]).ToString();
            Connector connector = GetConnector(diagram.Connectors!, node.InEdges![0])!;
            Node parentNode = GetNode(diagram.Nodes!, connector.SourceID!)!;
            for (int i = 0; i < parentNode.OutEdges!.Count; i++)
            {
                connector = GetConnector(diagram.Connectors!, parentNode.OutEdges[i])!;
                Node childNode = GetNode(diagram.Nodes!, connector!.TargetID!)!;
                if (childNode != null)
                {
                    string? childOrientation = Convert.ToString((BranchType)childNode.AdditionalInfo!["Orientation"]);
                    if (orientation == childOrientation)
                    {
                        sameLevelNodes.Add(childNode);
                    }
                }
            }
        }
        return sameLevelNodes;
    }

    /// <summary>
    /// This method is used to get the Nodes by connectors sourceID and targetID.
    /// </summary>
    private Node? GetNode(DiagramObjectCollection<Node> diagramNodes, string name)
    {
        for (int i = 0; i < diagramNodes!.Count; i++)
        {
            if (diagramNodes[i].ID == name)
            {
                return diagramNodes[i];
            }
        }
        return null;
    }

    /// <summary>
    /// This method is used to get the connectors by node's inedges and outedges
    /// </summary>
    private Connector? GetConnector(DiagramObjectCollection<Connector> diagramConnectors, string name)
    {
        for (int i = 0; i < diagramConnectors.Count; i++)
        {
            if (diagramConnectors[i].ID == name)
            {
                return diagramConnectors[i];
            }
        }
        return null;
    }

    /// <summary>
    /// This method to determine whether this command can execute or not.
    /// </summary>
    private void CanExecute(CommandKeyArgs args)
    {
        args.CanExecute = true;
    }

    private BranchType getbranch(IDiagramObject obj)
    {
        Node? node = obj as Node;
        BranchType Branch = (BranchType)node!.AdditionalInfo!["Orientation"];

        return Branch;
    }

    private void OnCreated()
    {
        Diagram!.Select(new ObservableCollection<IDiagramObject>() { Diagram.Nodes![0] });
    }

    // Method to customize the tool
    private InteractionControllerBase GetCustomTool(DiagramElementAction action, string id)
    {
        InteractionControllerBase? tool = null;
        if (id == "AddLeft")
        {
            tool = new AddRightTool(Diagram!);
        }
        else if (id == "AddRight")
        {
            tool = new AddLeftTool(Diagram!);
        }
        else
        {
            tool = new DeleteTool(Diagram!);
        }
        return tool;
    }

    private static async Task AddRightChild(SfDiagramComponent diagram, bool isSibling = false)
    {
        string newChildID = RandomId();
        string newchildColor = ""; BranchType type = BranchType.Left; Node? parentNode = null;
        string parentId = Convert.ToString(diagram.SelectionSettings!.Nodes![0].AdditionalInfo!["ParentId"])!;
        BranchType nodeBranch = (BranchType)diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Orientation"];
        double currentLevel = Convert.ToDouble(diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Level"]);
        double parentLevel = 0;
        if (!string.IsNullOrEmpty(parentId))
        {
            parentNode = diagram.GetObject(parentId) as Node;
            BranchType parentNodeBranch = (BranchType)parentNode!.AdditionalInfo!["Orientation"];
            type = isSibling ? parentNodeBranch : nodeBranch;
        }
        else
        {
            type = nodeBranch;
        }
        BranchType childType = BranchType.Left;
        if (parentNode != null) parentLevel = Convert.ToDouble(parentNode.AdditionalInfo!["Level"]);
        switch (type.ToString())
        {
            case "Root":
                childType = BranchType.Left;
                break;
            case "Left":
                childType = BranchType.SubLeft;
                break;
            case "SubLeft":
                childType = BranchType.SubLeft;
                break;
        }

        double level = isSibling ? parentLevel : currentLevel;
        if (level == 0)
        {
            int index = Convert.ToInt32(GetFillColorIndex(level));
            newchildColor = fillColorCode[index];
        }
        else
        {
            newchildColor = diagram.SelectionSettings.Nodes[0].Style!.Fill!;
        }

        MindMapDetails childNode = new MindMapDetails()
        {
            Id = newChildID.ToString(),
            ParentId = isSibling ? parentId : diagram.SelectionSettings.Nodes[0].ID!,
            Fill = newchildColor,
            Branch = childType,
            Label = "New Child",
            Level = isSibling ? parentLevel + 1 : currentLevel + 1
        };
        diagram.BeginUpdate();
        await UpdatePortConnection(childNode, diagram, isSibling);
        await diagram.EndUpdateAsync();
    }

    // Custom tool to add the node.
    public class AddLeftTool : InteractionControllerBase
    {
        private SfDiagramComponent diagram;

        public AddLeftTool(SfDiagramComponent Diagram) : base(Diagram)
        {
            diagram = Diagram;
        }

        public override async void OnMouseDown(DiagramMouseEventArgs args)
        {
            await AddRightChild(diagram);
            diagram.ClearSelection();
            base.OnMouseDown(args);
            diagram.Select(new ObservableCollection<IDiagramObject>() { diagram.Nodes![diagram.Nodes.Count - 1] });
            this.InAction = true;
        }
    }

    private static async Task UpdatePortConnection(MindMapDetails childNode, SfDiagramComponent diagram, bool isSibling)
    {
        Node node = new Node()
        {
            ID = "node" + childNode.Id,
            Height = 50,
            Width = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation()
                {
                    Content = childNode.Label,
                    Style=new TextStyle(){FontSize = 12,FontFamily="Segoe UI"},
                    Offset=new DiagramPoint(){X=0.5,Y=0.5}
                }
            },
            Style = new ShapeStyle() { Fill = childNode.Fill, StrokeColor = childNode.Fill },
            AdditionalInfo = new Dictionary<string, object>()
            {
                {"Orientation", childNode.Branch},
                {"ParentId", childNode.ParentId!},
                {"Level", childNode.Level},
            }
        };
        Connector connector = new Connector()
        {
            TargetID = node.ID,
            SourceID = isSibling ? childNode.ParentId : diagram.SelectionSettings!.Nodes![0].ID
        };
        await diagram.AddDiagramElementsAsync(new DiagramObjectCollection<NodeBase>() { node, connector });
        Node? sourceNode = diagram.GetObject((connector as Connector).SourceID) as Node;
        Node? targetNode = diagram.GetObject((connector as Connector).TargetID) as Node;
        if (targetNode != null && targetNode.AdditionalInfo!.Count > 0)
        {
            BranchType nodeBranch = (BranchType)targetNode.AdditionalInfo["Orientation"];
            if (nodeBranch == BranchType.Right || nodeBranch == BranchType.SubRight)
            {
                (connector as Connector).SourcePortID = sourceNode!.Ports![0].ID;
                (connector as Connector).TargetPortID = targetNode.Ports![1].ID;
            }
            else if (nodeBranch == BranchType.Left || nodeBranch == BranchType.SubLeft)
            {
                (connector as Connector).SourcePortID = sourceNode!.Ports![1].ID;
                (connector as Connector).TargetPortID = targetNode.Ports![0].ID;
            }
        }
        await diagram.DoLayoutAsync();
    }

    private static async Task AddLeftChild(SfDiagramComponent diagram, bool isSibling = false)
    {
        string newChildID = RandomId();
        string newchildColor = ""; BranchType type = BranchType.Left; Node? parentNode = null;
        string parentId = Convert.ToString(diagram.SelectionSettings!.Nodes![0].AdditionalInfo!["ParentId"])!;
        BranchType nodeBranch = (BranchType)diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Orientation"];
        double currentLevel = Convert.ToDouble(diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Level"]);
        double parentLevel = 0;
        if (!string.IsNullOrEmpty(parentId))
        {
            parentNode = diagram.GetObject(parentId) as Node;
            BranchType parentNodeBranch = (BranchType)parentNode!.AdditionalInfo!["Orientation"];
            type = isSibling ? parentNodeBranch : nodeBranch;
        }
        else
        {
            type = nodeBranch;
        }

        BranchType childType = BranchType.Left;
        if (parentNode != null) parentLevel = Convert.ToDouble(parentNode.AdditionalInfo!["Level"]);
        switch (type.ToString())
        {
            case "Root":
                childType = BranchType.Right;
                break;
            case "Right":
                childType = BranchType.SubRight;
                break;
            case "SubRight":
                childType = BranchType.SubRight;
                break;
        }
        double level = isSibling ? parentLevel : currentLevel;
        if (level == 0)
        {
            int index = Convert.ToInt32(GetFillColorIndex(level));
            newchildColor = fillColorCode[index];
        }
        else
        {
            newchildColor = diagram.SelectionSettings.Nodes[0].Style!.Fill!;
        }
        MindMapDetails childNode = new MindMapDetails()
        {
            Id = newChildID.ToString(),
            ParentId = isSibling ? parentId : diagram.SelectionSettings.Nodes[0].ID!,
            Fill = newchildColor,
            Branch = childType,
            Label = "New Child",
            Level = isSibling ? parentLevel + 1 : currentLevel + 1
        };
        diagram.BeginUpdate();
        await UpdatePortConnection(childNode, diagram, isSibling);
        await diagram.EndUpdateAsync();
    }

    // Custom tool to add the node.
    public class AddRightTool : InteractionControllerBase
    {
        private SfDiagramComponent diagram;
        public AddRightTool(SfDiagramComponent Diagram) : base(Diagram)
        {
            diagram = Diagram;
        }
        public override async void OnMouseDown(DiagramMouseEventArgs args)
        {
            await AddLeftChild(diagram);
            diagram.ClearSelection();
            base.OnMouseDown(args);
            diagram.Select(new ObservableCollection<IDiagramObject>() { diagram.Nodes![diagram.Nodes.Count - 1] });
            this.InAction = true;
        }
    }

    public class DeleteTool : InteractionControllerBase
    {
        private SfDiagramComponent sfDiagram;
        private Node? deleteObject = null;
        public DeleteTool(SfDiagramComponent Diagram) : base(Diagram)
        {
            sfDiagram = Diagram;
        }
        public override void OnMouseDown(DiagramMouseEventArgs args)
        {
            deleteObject = (sfDiagram.SelectionSettings!.Nodes![0]) as Node;
        }
        public override async void OnMouseUp(DiagramMouseEventArgs? args)
        {
            if (deleteObject != null)
            {
                sfDiagram.BeginUpdate();
                RemoveData(deleteObject, sfDiagram);
            _ = sfDiagram.EndUpdateAsync();
            await sfDiagram.DoLayoutAsync();
            }
            base.OnMouseUp(args);
            this.InAction = true;
        }
    }

    private static void RemoveData(Node node, SfDiagramComponent diagram)
    {
        if (node.OutEdges!.Count > 0)
        {
            List<string> outEdges = new List<string>();
            node.OutEdges.ForEach(edges => outEdges.Add(edges));
            for (int i = 0; i < outEdges.Count; i++)
            {
                Connector? connector = diagram.GetObject(outEdges[i]) as Connector;
                Node? targetnode = diagram.GetObject(connector!.TargetID) as Node;
                if (targetnode!.OutEdges!.Count > 0)
                {
                    RemoveData(targetnode, diagram);
                }
                else
                {
                    diagram.Delete(new DiagramObjectCollection<NodeBase>() { targetnode });
                }
            }
            diagram.Delete(new DiagramObjectCollection<NodeBase>() { node });
        }
        else
        {
            diagram.Delete(new DiagramObjectCollection<NodeBase>() { node });
        }
    }

    private void OnSelectionChanging(SelectionChangingEventArgs args)
    {
        if (args.NewValue!.Count > 0)
        {
            if (args.NewValue[0] is Node && (args.NewValue[0] as Node)!.AdditionalInfo!.Count > 0)
            {
                BranchType type = (BranchType)((args.NewValue[0] as Node)!.AdditionalInfo!["Orientation"]);
                if (type == BranchType.Root)
                {
                    selectionSettings.UserHandles![0].Visible = false;
                    selectionSettings.UserHandles[1].Visible = false;
                    selectionSettings.UserHandles[2].Visible = true;
                    selectionSettings.UserHandles[3].Visible = true;
                }
                else if (type == BranchType.Left || type == BranchType.SubLeft)
                {
                    selectionSettings.UserHandles![0].Visible = false;
                    selectionSettings.UserHandles[1].Visible = true;
                    selectionSettings.UserHandles[2].Visible = true;
                    selectionSettings.UserHandles[3].Visible = false;
                }
                else if (type == BranchType.Right || type == BranchType.SubRight)
                {
                    selectionSettings.UserHandles![0].Visible = true;
                    selectionSettings.UserHandles[1].Visible = false;
                    selectionSettings.UserHandles[2].Visible = false;
                    selectionSettings.UserHandles[3].Visible = true;
                }
            }
        }
    }

    private void NodeCreating(IDiagramObject obj)
    {
        Node? node = obj as Node;

        node!.Height = 50;
        node.Width = 100;
        node.Shape = new BasicShape() { Type = NodeShape.Basic, Shape = NodeBasicShapes.Ellipse };
        PointPort port21 = new PointPort()
        {
            ID = "left",
            Offset = new DiagramPoint() { X = 0, Y = 0.5 },
            Height = 10,
            Width = 10,
        };

        PointPort port22 = new PointPort()
        {
            ID = "right",
            Offset = new DiagramPoint() { X = 1, Y = 0.5 },
            Height = 10,
            Width = 10,
        };

        node.Ports = new DiagramObjectCollection<PointPort>()
        {
            port21,port22
        };
        node.Constraints &= ~NodeConstraints.Rotate;
    }

    private void ConnectorCreating(IDiagramObject obj)
    {
        Connector? connector = obj as Connector;
        connector!.Type = ConnectorSegmentType.Bezier;
        connector.BezierConnectorSettings = new BezierConnectorSettings() { AllowSegmentsReset = false };
        connector.Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.Select;
        connector.Style = new ShapeStyle() { StrokeColor = "#4f4f4f", StrokeWidth = 1 };
        connector.TargetDecorator = new DecoratorSettings() { Shape = DecoratorShape.None };
        connector.SourceDecorator!.Shape = DecoratorShape.None;
        Node? sourceNode = Diagram!.GetObject((connector as Connector).SourceID) as Node;
        Node? targetNode = Diagram.GetObject((connector as Connector).TargetID) as Node;
        if (targetNode != null && targetNode.AdditionalInfo!.Count > 0)
        {
            BranchType nodeBranch = (BranchType)targetNode.AdditionalInfo["Orientation"];
            if (nodeBranch == BranchType.Right || nodeBranch == BranchType.SubRight)
            {
                (connector as Connector).SourcePortID = sourceNode!.Ports![0].ID;
                (connector as Connector).TargetPortID = targetNode.Ports![1].ID;
            }
            else if (nodeBranch == BranchType.Left || nodeBranch == BranchType.SubLeft)
            {
                (connector as Connector).SourcePortID = sourceNode!.Ports![1].ID;
                (connector as Connector).TargetPortID = targetNode.Ports![0].ID;
            }
        }
    }

    public void UpdateNodeStyles(Node node, Node parentNode)
    {
        if (node != null && parentNode != null)
        {
            double levelValue = Convert.ToDouble(node.AdditionalInfo!["Level"]);
            if (levelValue == 1)
            {
                node.Style!.Fill = fillColorCode[lastFillIndex];
                node.Style.StrokeColor = borderColorCode[lastFillIndex];
                node.Style.StrokeWidth = 2;
                if (lastFillIndex + 1 >= fillColorCode.Length)
                    lastFillIndex = 0;
                else
                    lastFillIndex++;
            }
            else
                node.Style!.StrokeColor = node.Style.Fill = parentNode.Style!.Fill;
        }
    }

    private static double GetFillColorIndex(double level)
    {
        double index = lastFillIndex;
        if (lastFillIndex + 1 >= fillColorCode.Length)
            lastFillIndex = 0;
        else
            lastFillIndex++;
        return index;
    }

    private void UpdateHandle()
    {
        UserHandle deleteLeftHandle = AddHandle("DeleteRight", "delete", Direction.Right);

        UserHandle addRightHandle = AddHandle("AddLeft", "add", Direction.Left);

        UserHandle addLeftHandle = AddHandle("AddRight", "add", Direction.Right);

        UserHandle deleteRightHandle = AddHandle("DeleteLeft", "delete", Direction.Left);

        handles.Add(deleteLeftHandle);
        handles.Add(deleteRightHandle);
        handles.Add(addLeftHandle);
        handles.Add(addRightHandle);

        selectionSettings.UserHandles = handles;
    }

    private UserHandle AddHandle(string name, string path, Direction direction)
    {
        UserHandle handle = new UserHandle()
        {
            Name = name,
            Visible = true,
            Offset = 0.5,
            Side = direction,
            Margin = new DiagramThickness() { Top = 0, Bottom = 0, Left = 0, Right = 0 }
        };
        if (path == "delete")
        {
            handle.PathData = "M1.0000023,3 L7.0000024,3 7.0000024,8.75 C7.0000024,9.4399996 6.4400025,10 5.7500024,10 L2.2500024,10 C1.5600024,10 1.0000023,9.4399996 1.0000023,8.75 z M2.0699998,0 L5.9300004,0 6.3420029,0.99999994 8.0000001,0.99999994 8.0000001,2 0,2 0,0.99999994 1.6580048,0.99999994 z";
        }
        else
        {
            handle.PathData = "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z";
        }
        return handle;
    }

    public class MindMapDetails
    {
        public string? Id { get; set; }
        public string? Label { get; set; }
        public string? ParentId { get; set; }
        public BranchType Branch { get; set; }
        public string? Fill { get; set; }
        public double Level { get; set; }
    }

    protected override void OnInitialized()
    {
        selectionSettings.Constraints &= ~(SelectorConstraints.ResizeAll | SelectorConstraints.Rotate);
        commands = new DiagramObjectCollection<KeyboardCommand>()
        {
            new KeyboardCommand() { Name = "showShortCut", Gesture = new KeyGesture(){ Key = DiagramKeys.F1, Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "leftChild", Gesture = new KeyGesture(){ Key = DiagramKeys.Tab, Modifiers = ModifierKeys.Shift } },
            new KeyboardCommand() { Name = "rightChild", Gesture = new KeyGesture(){ Key = DiagramKeys.Tab,Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "sibilingChildTop", Gesture = new KeyGesture(){ Key = DiagramKeys.Enter,Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "fitPage", Gesture = new KeyGesture(){ Key = DiagramKeys.F8, Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "duplicate", Gesture = new KeyGesture(){ Key = DiagramKeys.D, Modifiers = ModifierKeys.Control } },

            new KeyboardCommand() { Name = "navigationUp", Gesture = new KeyGesture(){ Key = DiagramKeys.ArrowUp, Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "navigationDown", Gesture = new KeyGesture(){ Key = DiagramKeys.ArrowDown, Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "navigationLeft", Gesture = new KeyGesture(){ Key = DiagramKeys.ArrowLeft, Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "navigationRight", Gesture = new KeyGesture(){ Key = DiagramKeys.ArrowRight,Modifiers = ModifierKeys.None } },

            new KeyboardCommand() { Name = "fileNew", Gesture = new KeyGesture(){ Key = DiagramKeys.N, Modifiers = ModifierKeys.Shift } },
            new KeyboardCommand() { Name = "fileOpen", Gesture = new KeyGesture(){ Key = DiagramKeys.O, Modifiers = ModifierKeys.Control } },
            new KeyboardCommand() { Name = "fileSave", Gesture = new KeyGesture(){ Key = DiagramKeys.S, Modifiers = ModifierKeys.Control } },
            new KeyboardCommand() { Name = "delete", Gesture = new KeyGesture(){ Key = DiagramKeys.Delete, Modifiers = ModifierKeys.None  } },
            new KeyboardCommand() { Name = "backspace", Gesture = new KeyGesture(){ Key = DiagramKeys.BackSpace, Modifiers = ModifierKeys.None  } },
        };
        MindMapDetails rootNodeData = MindmapData[0];
        CreateNode(rootNodeData.Id!, rootNodeData.ParentId!, rootNodeData.Label!, rootNodeData.Fill!, rootNodeData.Branch, rootNodeData.Level);
        for (int i = 1; i < MindmapData.Count; i++)
        {
            MindMapDetails nodeData = MindmapData[i];
            string sourcePortID = string.Empty;
            string targetPortID = string.Empty;
            CreateNode(nodeData.Id!, nodeData.ParentId!, nodeData.Label!, nodeData.Fill!, nodeData.Branch, nodeData.Level);
            if (nodeData.Branch == BranchType.Right || nodeData.Branch == BranchType.SubRight)
            {
                sourcePortID = "left";
                targetPortID = "right";
            }
            else if (nodeData.Branch == BranchType.Left || nodeData.Branch == BranchType.SubLeft)
            {
                sourcePortID = "right";
                targetPortID = "left";
            }
            Connector connector = new Connector() { ID = "connector" + i, SourceID = nodeData.ParentId, TargetID = nodeData.Id, SourcePortID = sourcePortID, TargetPortID = targetPortID };
            connectors.Add(connector);
        }
    }

    private void CreateNode(string id, string parentId, string annotationContent, string fillColor, BranchType branch, double level)
    {
        Node node = new Node()
        {
            ID = id,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation()
                {
                    Content = annotationContent,
                    Style=new TextStyle(){FontSize = 12,FontFamily="Segoe UI"},
                    Offset=new DiagramPoint(){X=0.5,Y=0.5}, Width = 80
                }
            },
            Style = new ShapeStyle() { Fill = fillColor, StrokeColor = fillColor },
            AdditionalInfo = new Dictionary<string, object>()
            {
                {"Orientation", branch},
                {"ParentId", parentId},
                {"Level", level},
            }
        };
        nodes.Add(node);
    }

    internal static string RandomId()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
        return new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
        if (DiagramOpenAIRef != null)
            DiagramOpenAIRef.Parent = this;
            UpdateHandle();
        }
    }
}

{% endhighlight %}
{% endtabs %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/AISamples/MauiAppAISample).

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DiagramComponent).

## How to Run the Sample on Windows

Run the sample in Windows Machine mode, and it will run Blazor MAUI in Windows.

![Run Windows machine](images/blazor-diagram-maui.png)

When the application is successfully launched, the Diagram component will seamlessly render the specified diagram page.

![Run Windows machine](images/blazor-diagram-maui-page.png)

## How to Run the Sample on Android

To run the Blazor DiagramComponent in a Blazor Android MAUI application using the Android emulator, follow these steps:

![Run Windows machine](images/blazor-diagram-maui-android.png)

Refer [here](https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/device-manager#android-device-manager-on-windows) to install and launch Android emulator.

N> If encounter any errors while using the Android Emulator, refer to the following link for troubleshooting guidance[Troubleshooting Android Emulator](https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/troubleshooting).

![Blazor Diagram Component](images/blazor-diagram-maui-andoid-page.png)

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

To use the MAUI project templates, install the Mobile development with the .NET extension for Visual Studio Code. For more details, refer to [here](https://learn.microsoft.com/en-us/dotnet/maui/get-started/installation?view=net-maui-9.0&tabs=visual-studio-code) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

## Step 1: How to Create a New Blazor MAUI App Using Visual Studio Code

Create a Blazor MAUI App using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/dotnet/maui/get-started/first-app?pivots=devices-windows&view=net-maui-9.0&tabs=visual-studio-code) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to [this Blazor MAUI App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/maui-blazor-app) documentation.

## Step 2: How to Install Diagram NuGet Packages in a Blazor MAUI App

To add the **Blazor Diagram**  component in the app, open the NuGet package manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), search and install [Syncfusion.Blazor.Diagram](https://www.nuget.org/packages/Syncfusion.Blazor.Diagram) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Diagram -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Step 3: Add Import Namespaces

Open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Diagram` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor 
@using Syncfusion.Blazor.Diagram

{% endhighlight %}
{% endtabs %}

## Step 4: How to Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

* Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/MauiProgram.cs** file.

{% tabs %}
{% highlight c# tabtitle="~/MauiProgram.cs" hl_lines="3 20 28" %}

using Microsoft.Extensions.Logging;
using MauiBlazorWindow.Data;
using Syncfusion.Blazor;

namespace MauiBlazorWindow;

    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSyncfusionBlazor();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }

{% endhighlight %}
{% endtabs %}

## Step 5: How to Add Stylesheet and Script Resources

Add the following stylesheet and script to the head section of the **~/wwwroot/index.html** file.

If using Syncfusion.Blazor && Syncfusion.Blazor.Themes NuGet package in your application, refer to the following script.
```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
If using `Syncfusion.Blazor.Diagram` && `Syncfusion.Blazor.Themes` NuGet package in your application, refer to the following script.
```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

## Step 6: To Configure Azure OpenAI Service

For **Azure OpenAI**, first [deploy an Azure OpenAI Service resource and model](https://learn.microsoft.com/en-us/azure/ai-foundry/openai/how-to/create-resource?view=foundry-classic&pivots=web-portal); then the values for `apiKey`, `deploymentName`, and `endpoint` will be provided.

**Install the following NuGet packages to your project:**

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Azure.AI.OpenAI
Install-Package Syncfusion.Blazor.AI
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI --version 9.8.0-preview.1.25412.6

{% endhighlight %}
{% endtabs %}

**To configure the AI service, add the following settings to the ~/MauiProgram.cs file in your project.**

{% tabs %}
{% highlight c# tabtitle="~/MauiProgram.cs" hl_lines=" 2-5 11-24" %}

using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using AIService;
using System.ClientModel;

....

builder.Services.AddSyncfusionBlazor();

string azureOpenAIKey = "AZURE_OPENAI_KEY";
string azureOpenAIEndpoint = "AZURE_OPENAI_ENDPOINT";
string azureOpenAIModel = "AZURE_OPENAI_MODEL";

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(azureOpenAIEndpoint),
     new ApiKeyCredential(azureOpenAIKey)
);

IChatClient AIChatClient = azureOpenAIClient.GetChatClient(azureOpenAIModel).AsIChatClient();
builder.Services.AddScoped<AzureAIService>(serviceProvider  =>
{
    return new AzureAIService(AIChatClient);
});

{% endhighlight %}
{% endtabs %}

**Create a Azure AI Service**

`AzureAIService` is a small wrapper around an injected `IChatClient` that lets you:

* Send a prompt to an AI chat/completions endpoint (e.g., Azure OpenAI or any service conforming to your IChatClient abstraction).
* Optionally control the response format (strict JSON or free-form text) via a system instruction.
* Adjust generation settings like temperature, top‑p, penalties, and max tokens.
* Receive the AI’s completion as a string.

{% tabs %}
{% highlight c# tabtitle="~/AzureAIService.cs" %}

using Microsoft.Extensions.AI;
using Syncfusion.Blazor.AI;
using System;

namespace AIService
{
    public class AzureAIService
    {
        private IChatClient _chatClient;

        public AzureAIService(IChatClient client)
        {
            this._chatClient = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<string> GetCompletionAsync(string prompt, bool returnAsJson = true,  string systemRole = null, int outputTokens = 2000)
        {
            string systemMessage = returnAsJson ? "You are a helpful assistant that only returns and replies with valid, iterable RFC8259 compliant JSON in your responses unless I ask for any other format. Do not provide introductory words such as 'Here is your result' or '```json', etc. in the response" : !string.IsNullOrEmpty(systemRole) ? systemRole : "You are a helpful assistant";
            try
            {
                ChatParameters chatParameters = new ChatParameters();
                chatParameters.Messages = new List<ChatMessage>(2) {
                    new ChatMessage (ChatRole.System, systemMessage),
                    new ChatMessage(ChatRole.User,prompt),
                };
                string completion = await GetChatResponseAsync(chatParameters);
                return completion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception has occurred: {ex.Message}");
                return "";
            }
        }

        public async Task<string> GetChatResponseAsync(ChatParameters options)
        {
            ChatOptions completionRequest = new ChatOptions
            {
                Temperature = options.Temperature ?? 0.5f,
                TopP = options.TopP ?? 1.0f,
                MaxOutputTokens = options.MaxTokens ?? 2000,
                FrequencyPenalty = options.FrequencyPenalty ?? 0.0f,
                PresencePenalty = options.PresencePenalty ?? 0.0f,
                StopSequences = options.StopSequences
            };
            try
            {
                ChatResponse completion = await _chatClient.GetResponseAsync(options.Messages, completionRequest);
                return completion.Text.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Create an AI Assist Button with Icon**

This Razor snippet places a Floating Action Button (FAB) with an AI icon on top of a diagram surface. When the FAB is clicked, it opens a modal dialog titled AI Assist. The dialog shows:

* A set of suggested prompt buttons (one‑click actions).
* A textbox for custom prompts.
* A send button that calls your AI service to generate a mind map diagram based on the prompt.

{% tabs %}
{% highlight c# tabtitle="~/DiagramOpenAI.razor" %}

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
@using AIService
@inject AzureAIService ChatGptService
@namespace TextToMindMapDiagram

<SfFab IconCss="e-icons e-ai-chat" Content="AI Assist" OnClick="OnFabClicked" Target="#diagram-area"></SfFab>
<SfDialog Width="570px" IsModal="true" ShowCloseIcon="true" CssClass="custom-dialog" Visible="@ShowAIAssistDialog">
    <DialogTemplates>
        <Header> <span class="e-icons e-ai-chat" style="color: black; font-size: 16px;"></span> AI Assist</Header>
        <Content>
            <p style="margin-bottom: 10px;">Suggested Prompts</p>
                <SfButton style="flex: 1; overflow: visible; border-radius: 8px;margin-bottom: 10px;" @onclick="()=>GenerateMindMap(MobileBankingPrompt)">Mindmap diagram for Mobile banking registration</SfButton>
                <SfButton style="flex: 1; overflow: visible; border-radius: 8px;margin-bottom: 10px;" @onclick="()=>GenerateMindMap(OrganizationalResearchPrompt)">Mindmap diagram for Organizational research</SfButton>
                <SfButton style="flex: 1; overflow: visible; border-radius: 8px;margin-bottom: 10px;" @onclick="()=>GenerateMindMap(MeetingAgendaPrompt)">Mindmap diagram for Meeting agenda</SfButton>
            
            <div style="display: flex; flex: 95%; margin-top:20px;">
                    <SfTextBox @bind-Value="@OpenAIPrompt" CssClass="db-openai-textbox" Height="32px" Placeholder="Please enter your prompt for generating a mindmap diagram..." autofocus style="font-size: 14px;"></SfTextBox>
                <SfButton @onclick="@GetResponseFromAI" CssClass="e-icons e-flat e-send" IsPrimary="true" style="height: 38px; width: 38px; margin-left: 5px; padding: 0;"></SfButton>
            </div>
        </Content>
    </DialogTemplates>
    <DialogEvents Closed="@DialogClose"></DialogEvents>
</SfDialog>

{% endhighlight %}
{% endtabs %}

**Generate Mind Map from AI Prompt**

This handles the core logic that takes the user’s prompt, sends it to the AI service, processes the AI response, and renders a mind map diagram in the application using the `LoadDiagramFromMermaidAsync` method. It also manages UI states like showing a loading indicator and closing the dialog.

{% tabs %}
{% highlight c# tabtitle="~/DiagramOpenAI.razor.cs" %}

namespace TextToMindMapDiagram
{
    public partial class DiagramOpenAI
    {
        public Home Parent;
        public bool ShowAIAssistDialog = false;
        public string OpenAIPrompt;
        string MobileBankingPrompt = "Mindmap diagram for Mobile banking registration";
        string OrganizationalResearchPrompt = "Mindmap diagram for Organizational research";
        string MeetingAgendaPrompt = "Mindmap diagram for Meeting agenda";
        public void OnFabClicked()
        {
            ShowAIAssistDialog = !ShowAIAssistDialog;
        }
        private void DialogClose(Object args)
        {
            ShowAIAssistDialog = false;
        }

        public async void GenerateMindMap(string value)
        {
            OpenAIPrompt = value;
            await GetResponseFromAI();
            StateHasChanged();
        }

        public async Task GetResponseFromAI()
        {
            Parent.IsGeneratingFromAI = true;
            ShowAIAssistDialog = false;
            if (!string.IsNullOrWhiteSpace(OpenAIPrompt))
            {
                await Parent.SpinnerRef!.ShowAsync();
                string result = string.Empty;
                string systemRole = "You are an expert in creating mind map diagram data sources. Generate a structured data source for a mind map based on the user's query, using tab indentation to indicate hierarchy. The root parent should have no indentation, while each subsequent child level should be indented by one tab space. Avoid using any symbols such as '+' or '-' before any level of data.";
                string userPrompt = $"Based on the following input, create a mind map diagram data source: {OpenAIPrompt}.";
                result = await ChatGptService.GetCompletionAsync(userPrompt, false, systemRole);
                if (result != null)
                {
                    List<string> filteredData = result
                    .Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .ToList();
                    if (filteredData[0].Trim() != "mindmap")
                        filteredData.Insert(0, "mindmap");
                    filteredData[1].TrimStart('-', '+');
                    result = string.Join("\n", filteredData);
                    Parent.Diagram!.BeginUpdate();
                    Parent.Diagram.StartGroupAction();
                    await Parent.Diagram.LoadDiagramFromMermaidAsync(result);
                    Parent.Diagram.EndGroupAction();
                    await Parent.Diagram.EndUpdateAsync();
                    StateHasChanged();
                }
                await Parent.SpinnerRef.HideAsync();
            }
            Parent.IsGeneratingFromAI = false;
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Generate a main diagram page**

This page renders an interactive mind map workspace built with Syncfusion Diagram.

* `SfDiagramComponent`: The primary diagram canvas.
* `Spinner`: Shows progress during async generation.
* `DiagramOpenAI`: Custom component reference for AI features (used externally).
* Many diagram events configured for creation, selection, layout, custom tools, etc.
* `OnAfterRenderAsync`: On first render, wires up the DiagramOpenAIRef parent link (for external AI integration).

{% tabs %}
{% highlight c# tabtitle="~/Home.razor" %}

@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Spinner
@using System.Collections.ObjectModel
@using System.Text.Json;
@using Syncfusion.Blazor.Navigations
@using NodeShape = Syncfusion.Blazor.Diagram.NodeShapes
@using TextToMindMapDiagram
@using AIService

@inject AzureAIService ChatGptService
@namespace TextToMindMapDiagram

@*Hidden:Lines*@
@inject NavigationManager NavigationManager
@*End:Hidden*@

<div class="col-lg-12 control-section">
    <div class="content-wrapper">
        <div class="diagrambuilder-container" style="height: calc(100% - 350px); width: 100%">
            <div style="border: 2px solid #ccc;">
            <div class="diagram-area">
                <SfDiagramComponent ID="diagram-area" @ref="@Diagram" @bind-InteractionController="@interactionController" @bind-Nodes="@nodes" @bind-Connectors="@connectors" CollectionChanging="CollectionChanging" @bind-Height="@height" @bind-Width="@width" GetCustomTool="@GetCustomTool" NodeCreating="@NodeCreating" ConnectorCreating="@ConnectorCreating" @bind-SelectionSettings="@selectionSettings" SelectionChanging="OnSelectionChanging" Created="OnCreated">
                    <ScrollSettings @bind-ScrollLimit="@scrollLimit" @bind-CurrentZoom="@CurrentZoom" @bind-MaxZoom="@maxZoom" @bind-MinZoom="@minZoom"></ScrollSettings>
                    <Layout @bind-HorizontalSpacing="@HorizontalSpacing" @bind-VerticalSpacing="@VerticalSpacing" @bind-Type="@layoutType" GetBranch="@getbranch"></Layout>
                    <SnapSettings @bind-Constraints="@SnapConstraint"></SnapSettings>
                    <PageSettings MultiplePage="true"></PageSettings>
                    <CommandManager @bind-Commands="@commands" Execute="@ExecuteCommand" CanExecute="@CanExecute" />
                    <SfSpinner @ref="@SpinnerRef" Label="Generating diagram...." Type="@SpinnerType.Bootstrap"> </SfSpinner>
                </SfDiagramComponent>
            </div>
            </div>
            <DiagramOpenAI @ref="DiagramOpenAIRef"></DiagramOpenAI>
        </div>
    </div>
</div>
@code
{
    public SfDiagramComponent? Diagram;
    public SfSpinner? SpinnerRef;
    public DiagramOpenAI? DiagramOpenAIRef;
    private SnapConstraints SnapConstraint = SnapConstraints.ShowLines;
    private double CurrentZoom { get; set; } = 1;
    public bool IsGeneratingFromAI = false;
    /// <summary>
    /// Collection of keyboard commands for the diagram.
    /// </summary>
    private DiagramObjectCollection<KeyboardCommand> commands = new DiagramObjectCollection<KeyboardCommand>();
    /// <summary>
    /// The minimum zoom level allowed for the diagram.
    /// </summary>
    private double minZoom { get; set; } = 0.25;
    /// <summary>
    /// The maximum zoom level allowed for the diagram.
    /// </summary>
    private double maxZoom { get; set; } = 30;
    /// <summary>
    /// Specifies whether the undo functionality is enabled in the diagram.
    /// </summary>
    private bool IsUndo = false;
    /// <summary>
    /// Specifies whether the redo functionality is enabled in the diagram.
    /// </summary>
    private bool IsRedo = false;
    /// <summary>
    /// Specifies whether the diagram is selected.
    /// </summary>
    private bool diagramSelected = false;
    /// <summary>
    /// Represents an array of fill colors.
    /// </summary>
    private static string[] fillColorCode = { "#C4F2E8", "#F7E0B3", "#E5FEE4", "#E9D4F1", "#D4EFED", "#DEE2FF" };
    /// <summary>
    /// Represents an array of border colors.
    /// </summary>
    private static string[] borderColorCode = { "#8BC1B7", "#E2C180", "#ACCBAA", "#D1AFDF", "#90C8C2", "#BBBFD6" };
    /// <summary>
    /// Represents the last fill index, an integer.
    /// </summary>
    private static int lastFillIndex = 0;
    private LayoutType layoutType = LayoutType.MindMap;
    private string height = "700px";
    private string width = "100%";
    private DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    private DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    private ScrollLimitMode scrollLimit { get; set; } = ScrollLimitMode.Diagram;
    private DiagramInteractions interactionController = DiagramInteractions.SingleSelect;
    private int VerticalSpacing = 20;
    private int HorizontalSpacing = 80;
    private DiagramSelectionSettings selectionSettings = new DiagramSelectionSettings();
    private DiagramObjectCollection<UserHandle> handles = new DiagramObjectCollection<UserHandle>();
    
    private List<MindMapDetails> MindmapData = new List<MindMapDetails>()
    {
        new MindMapDetails(){Id="node1",Label="Business Planning",ParentId ="",Branch= BranchType.Root, Fill="#D0ECFF", Level = 0 },
        new MindMapDetails(){Id="node2",Label= "Expectation",ParentId = "node1",Branch= BranchType.Left,Fill= "#C4F2E8", Level = 1  },
        new MindMapDetails(){Id="node3",Label= "Requirements", ParentId="node1",Branch= BranchType.Right,Fill= "#F7E0B3", Level = 1  },
        new MindMapDetails(){Id="node4",Label= "Marketing", ParentId="node1",Branch= BranchType.Left,Fill= "#E5FEE4", Level = 1  },
        new MindMapDetails(){Id="node5",Label= "Budgets",ParentId= "node1",Branch= BranchType.Right,Fill= "#E9D4F1", Level = 1  },
        new MindMapDetails(){ Id="node6", Label="Situation in Market", ParentId= "node1", Branch = BranchType.Left, Fill= "#D4EFED", Level = 1  },
        new MindMapDetails(){ Id="node7", Label="Product Sales", ParentId= "node2", Branch = BranchType.SubLeft, Fill= "#C4F2E8", Level = 2  },
        new MindMapDetails() { Id = "node8", Label= "Strategy", ParentId="node2", Branch = BranchType.SubLeft, Fill="#C4F2E8", Level = 2  },
        new MindMapDetails() { Id = "node9", Label="Contacts", ParentId="node2", Branch = BranchType.SubLeft, Fill="#C4F2E8", Level = 2  },
        new MindMapDetails() { Id = "node10", Label="Customer Groups", ParentId= "node4", Branch = BranchType.SubLeft,Fill= "#E5FEE4", Level = 2  },
        new MindMapDetails() { Id = "node11", Label= "Branding", ParentId= "node4", Branch = BranchType.SubLeft, Fill= "#E5FEE4", Level = 2  },
        new MindMapDetails() { Id = "node12", Label= "Advertising", ParentId= "node4", Branch = BranchType.SubLeft, Fill= "#E5FEE4", Level = 2  },
        new MindMapDetails() { Id = "node13", Label= "Competitors", ParentId= "node6", Branch = BranchType.SubLeft, Fill="#D4EFED", Level = 2  },
        new MindMapDetails() { Id = "node14", Label="Location", ParentId="node6", Branch = BranchType.SubLeft, Fill= "#D4EFED", Level = 2  },
        new MindMapDetails() { Id = "node15", Label= "Director", ParentId= "node3", Branch = BranchType.SubRight, Fill="#F7E0B3", Level = 2  },
        new MindMapDetails() { Id = "node16", Label="Accounts Department", ParentId= "node3", Branch = BranchType.SubRight, Fill= "#F7E0B3", Level = 2  },
        new MindMapDetails() { Id = "node17", Label="Administration", ParentId= "node3", Branch = BranchType.SubRight, Fill="#F7E0B3", Level = 2  },
        new MindMapDetails() { Id = "node18", Label= "Development", ParentId="node3", Branch = BranchType.SubRight, Fill= "#F7E0B3", Level = 2  },
        new MindMapDetails() { Id = "node19", Label= "Estimation", ParentId= "node5", Branch = BranchType.SubRight, Fill="#E9D4F1", Level = 2  },
        new MindMapDetails() { Id = "node20", Label= "Profit", ParentId= "node5", Branch = BranchType.SubRight, Fill= "#E9D4F1", Level = 2  },
        new MindMapDetails(){ Id="node21", Label="Funds", ParentId= "node5", Branch = BranchType.SubRight, Fill= "#E9D4F1", Level = 2  }
    };

    private void CollectionChanging(CollectionChangingEventArgs args)
    {
        if (args.Action == CollectionChangedAction.Add && IsGeneratingFromAI)
        {
            Connector? connector = args.Element as Connector;
            if (connector != null)
            {
                UpdateMermaidNodeInfo(connector);
            }
        }
    }

    BranchType CurrentBranch = BranchType.Left;

    private void UpdateMermaidNodeInfo(Connector connector)
    {
        Node? sourceNode = Diagram!.GetObject(connector.SourceID) as Node;
        Node? targetNode = Diagram.GetObject(connector.TargetID) as Node;
        if (connector.ID == Diagram.Connectors![0].ID)
        {
            CurrentBranch = BranchType.Left;
            sourceNode!.AdditionalInfo!["ParentId"] = "";
            sourceNode.AdditionalInfo["Orientation"] = BranchType.Root;
            sourceNode.AdditionalInfo["Level"] = 0;
            sourceNode.Style!.Fill = "#D0ECFF";
            sourceNode.Style.StrokeColor = "#80BFEA";
        }
        if (sourceNode != null && (BranchType)sourceNode.AdditionalInfo!["Orientation"] == BranchType.Root)
        {
            targetNode!.AdditionalInfo!["ParentId"] = sourceNode.ID;
            targetNode.AdditionalInfo["Orientation"] = CurrentBranch;
            targetNode.AdditionalInfo["Level"] = 1;
            CurrentBranch = (CurrentBranch == BranchType.Left) ? BranchType.Right : BranchType.Left;
        }
        else
        {
            BranchType sourceNodeBranch = (BranchType)sourceNode!.AdditionalInfo!["Orientation"];
            targetNode!.AdditionalInfo!["ParentId"] = sourceNode.ID;
            targetNode.AdditionalInfo["Orientation"] = (sourceNodeBranch == BranchType.Left || sourceNodeBranch == BranchType.SubLeft) ? BranchType.SubLeft : BranchType.SubRight;
            targetNode.AdditionalInfo["Level"] = Convert.ToDouble(sourceNode.AdditionalInfo["Level"]) + 1;
        }

        UpdateNodeStyles(targetNode, sourceNode);
        BranchType targetNodeBranch = (BranchType)targetNode.AdditionalInfo["Orientation"];
        if (targetNodeBranch == BranchType.Right || targetNodeBranch == BranchType.SubRight)
        {
            connector.SourcePortID = sourceNode.Ports![0].ID;
            connector.TargetPortID = targetNode.Ports![1].ID;
        }
        else if (targetNodeBranch == BranchType.Left || targetNodeBranch == BranchType.SubLeft)
        {
            connector.SourcePortID = sourceNode.Ports![1].ID;
            connector.TargetPortID = targetNode.Ports![0].ID;
        }
    }

    /// <summary>
    /// This Method to execute the custom command.
    /// </summary>
    private async Task ExecuteCommand(CommandKeyArgs obj)
    {
        if (obj.Name == "leftChild")
        {
            if (Diagram!.SelectionSettings != null && Diagram.SelectionSettings.Nodes!.Count > 0)
            {
                Diagram.StartGroupAction();
                BranchType type = (BranchType)Diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Orientation"];
                if (type == BranchType.SubRight || type == BranchType.Right)
                {
                    await AddLeftChild(Diagram);
                }
                else if (type == BranchType.SubLeft || type == BranchType.Left || type == BranchType.Root)
                {
                    await AddRightChild(Diagram);
                }
                Diagram.ClearSelection();
                Diagram.Select(new ObservableCollection<IDiagramObject>() { Diagram.Nodes![Diagram.Nodes.Count - 1] });
                Diagram.EndGroupAction();
            }
        }
        if (obj.Name == "rightChild")
        {
            if (Diagram!.SelectionSettings != null && Diagram.SelectionSettings.Nodes!.Count > 0)
            {
                Diagram.StartGroupAction();
                BranchType type = (BranchType)Diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Orientation"];
                if (type == BranchType.SubLeft || type == BranchType.Left)
                {
                    await AddRightChild(Diagram);
                }
                else if (type == BranchType.SubRight || type == BranchType.Right || type == BranchType.Root)
                {
                    await AddLeftChild(Diagram);
                }
                Diagram.ClearSelection();
                Diagram.Select(new ObservableCollection<IDiagramObject>() { Diagram.Nodes![Diagram.Nodes.Count - 1] });
                Diagram.EndGroupAction();
            }
        }
        if (obj.Name == "sibilingChildTop")
        {
            Node rootNode = Diagram!.Nodes!.Where(node => node.InEdges!.Count == 0).ToList()[0];
            if (rootNode.ID != Diagram.SelectionSettings!.Nodes![0].ID)
            {
                Diagram.StartGroupAction();
                string nodeParent = Convert.ToString(Diagram.SelectionSettings.Nodes[0].AdditionalInfo!["ParentId"])!;
                string parentID = nodeParent;
                Node? parentNode = Diagram.GetObject(parentID) as Node;
                BranchType branch = (BranchType)(parentNode!.AdditionalInfo!["Orientation"]);
                BranchType nodeBranch = (BranchType)(Diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Orientation"]);
                if (branch == BranchType.SubRight || branch == BranchType.Right || (branch == BranchType.Root && nodeBranch == BranchType.Right))
                {
                    await AddLeftChild(Diagram, true);
                }
                else
                {
                    await AddRightChild(Diagram, true);
                }
                Diagram.ClearSelection();
                Diagram.Select(new ObservableCollection<IDiagramObject>() { Diagram.Nodes![Diagram.Nodes.Count - 1] });
                Diagram.EndGroupAction();
            }
        }
        if (obj.Name == "navigationDown")
        {
            NavigateChild("Bottom");
        }
        if (obj.Name == "navigationUp")
        {
            NavigateChild("Top");
        }
        if (obj.Name == "navigationLeft")
        {
            NavigateChild("Right");
        }
        if (obj.Name == "navigationRight")
        {
            NavigateChild("Left");
        }
        if (obj.Name == "deleteChid" || obj.Name == "delete" || obj.Name == "backspace")
        {
            Diagram!.BeginUpdate();
            RemoveData(Diagram.SelectionSettings!.Nodes![0], Diagram);
        _ = Diagram.EndUpdateAsync();
        await Diagram.DoLayoutAsync();
        }
        if (obj.Name == "fitPage")
        {
            FitOptions fitoption = new FitOptions()
            {
                Mode = FitMode.Both,
                Region = DiagramRegion.PageSettings,
            };
            Diagram?.FitToPage(fitoption);
        }
        if (obj.Name == "duplicate")
        {
            Diagram?.Copy();
        }
        if (obj.Name == "fileNew")
        {
            Diagram?.Clear();
            Diagram?.BeginUpdate();
            StateHasChanged();
        }
        if (obj.Name == "fileOpen")
        {
        }
        if (obj.Name == "fileSave")
        {
            string fileName = "diagram";
        }
    }

    /// <summary>
    /// This method is used to navigate between the nodes
    /// </summary>
    private void NavigateChild(string direction)
    {
        SfDiagramComponent diagram = Diagram!;
        Node? node = null;
        List<Node> sameLevelNodes = new List<Node>();
        if (direction == "Top" || direction == "Bottom")
        {
            sameLevelNodes = GetSameLevelNodes();
            int index = sameLevelNodes.IndexOf(diagram.SelectionSettings!.Nodes![0]);
            node = direction == "Top" ? sameLevelNodes[index == 0 ? 0 : index - 1] : sameLevelNodes[index == (sameLevelNodes.Count - 1) ? index : index + 1];
        }
        else
            node = GetMinDistanceNode(diagram, direction);
        if (node != null)
        {
            diagram.Select(new ObservableCollection<IDiagramObject>() { node });
        }

    }

    /// <summary>
    /// This method is used to return a minimum distance node whie navigating between left and right
    /// </summary>
    private Node GetMinDistanceNode(SfDiagramComponent diagram, string direction)
    {
        Node node = diagram.SelectionSettings!.Nodes![0];
        double? nodeWidth = (node.Width == null) ? node.MinWidth : node.Width;
        DiagramRect parentBounds = new DiagramRect((node.OffsetX - (nodeWidth / 2)), node.OffsetY - (node.Height / 2), nodeWidth, node.Height);
        DiagramRect childBounds = new DiagramRect();
        double oldChildBoundsTop = 0;
        Node? childNode = null;
        Node? lastChildNode = null;
        Node? leftOrientationFirstChild = null;
        Node? rightOrientationFirstChild = null;
        Node rootNode = diagram.Nodes!.Where(node => node.InEdges!.Count == 0).ToList()[0];
        if (node.ID == rootNode.ID)
        {
            List<string> edges = node.OutEdges!;
            for (int i = 0; i < edges!.Count; i++)
            {
                Connector connector = GetConnector(diagram.Connectors!, edges[i])!;
                childNode = GetNode(diagram.Nodes!, connector!.TargetID!);
                if (Convert.ToString((BranchType)childNode!.AdditionalInfo!["Orientation"]) == direction)
                {
                    if (direction == "Left" && leftOrientationFirstChild == null)
                        leftOrientationFirstChild = childNode;
                    if (direction == "Right" && rightOrientationFirstChild == null)
                        rightOrientationFirstChild = childNode;
                    double? childNodeWidth = (childNode.Width == null) ? childNode.MinWidth : childNode.Width;
                    childBounds = new DiagramRect((childNode.OffsetX - (childNodeWidth / 2)), childNode.OffsetY - (childNode.Height / 2), childNodeWidth, childNode.Height);
                    if (parentBounds.Top >= childBounds.Top && (childBounds.Top >= oldChildBoundsTop || oldChildBoundsTop == 0))
                    {
                        oldChildBoundsTop = childBounds.Top;
                        lastChildNode = childNode;
                    }
                }
            }
            if (lastChildNode != null)
                lastChildNode = direction == "Left" ? leftOrientationFirstChild : rightOrientationFirstChild;
        }
        else
        {
            List<string>? edges = new List<string>();
            string selectType = string.Empty;
            string orientation = ((BranchType)node.AdditionalInfo!["Orientation"]).ToString();
            if (orientation == "Left" || orientation == "SubLeft")
            {
                edges = direction == "Left" ? node.OutEdges : node.InEdges;
                selectType = direction == "Left" ? "Target" : "Source";
            }
            else
            {
                edges = direction == "Right" ? node.OutEdges : node.InEdges;
                selectType = direction == "Right" ? "Target" : "Source";
            }
            for (int i = 0; i < edges!.Count; i++)
            {
                Connector connector = GetConnector(diagram.Connectors!, edges[i]!)!;
                childNode = GetNode(diagram.Nodes!, selectType == "Target" ? connector!.TargetID! : connector!.SourceID!);
                if (childNode!.ID == rootNode.ID)
                    lastChildNode = childNode;
                else
                {
                    double? childNodeWidth = (childNode.Width == null) ? childNode.MinWidth : childNode.Width;
                    childBounds = new DiagramRect((childNode.OffsetX - (childNodeWidth / 2)), childNode.OffsetY - (childNode.Height / 2), childNodeWidth, childNode.Height);
                    if (selectType == "Target")
                    {
                        if (parentBounds.Top >= childBounds.Top && (childBounds.Top >= oldChildBoundsTop || oldChildBoundsTop == 0))
                        {
                            oldChildBoundsTop = childBounds.Top;
                            lastChildNode = childNode;
                        }
                    }
                    else
                        lastChildNode = childNode;
                }
            }
        }
        return lastChildNode!;
    }

    /// <summary>
    /// This method is used to return a same level nodes
    /// </summary>

    private List<Node> GetSameLevelNodes()
    {
        List<Node> sameLevelNodes = new List<Node>();
        SfDiagramComponent? diagram = Diagram;
        if (diagram!.SelectionSettings!.Nodes!.Count > 0)
        {
            Node node = diagram.SelectionSettings.Nodes[0];
            string orientation = ((BranchType)node.AdditionalInfo!["Orientation"]).ToString();
            Connector connector = GetConnector(diagram.Connectors!, node.InEdges![0])!;
            Node parentNode = GetNode(diagram.Nodes!, connector.SourceID!)!;
            for (int i = 0; i < parentNode.OutEdges!.Count; i++)
            {
                connector = GetConnector(diagram.Connectors!, parentNode.OutEdges[i])!;
                Node childNode = GetNode(diagram.Nodes!, connector!.TargetID!)!;
                if (childNode != null)
                {
                    string? childOrientation = Convert.ToString((BranchType)childNode.AdditionalInfo!["Orientation"]);
                    if (orientation == childOrientation)
                    {
                        sameLevelNodes.Add(childNode);
                    }
                }
            }
        }
        return sameLevelNodes;
    }

    /// <summary>
    /// This method is used to get the Nodes by connectors sourceID and targetID.
    /// </summary>
    private Node? GetNode(DiagramObjectCollection<Node> diagramNodes, string name)
    {
        for (int i = 0; i < diagramNodes!.Count; i++)
        {
            if (diagramNodes[i].ID == name)
            {
                return diagramNodes[i];
            }
        }
        return null;
    }

    /// <summary>
    /// This method is used to get the connectors by node's inedges and outedges
    /// </summary>
    private Connector? GetConnector(DiagramObjectCollection<Connector> diagramConnectors, string name)
    {
        for (int i = 0; i < diagramConnectors.Count; i++)
        {
            if (diagramConnectors[i].ID == name)
            {
                return diagramConnectors[i];
            }
        }
        return null;
    }

    /// <summary>
    /// This method to determine whether this command can execute or not.
    /// </summary>
    private void CanExecute(CommandKeyArgs args)
    {
        args.CanExecute = true;
    }

    private BranchType getbranch(IDiagramObject obj)
    {
        Node? node = obj as Node;
        BranchType Branch = (BranchType)node!.AdditionalInfo!["Orientation"];

        return Branch;
    }

    private void OnCreated()
    {
        Diagram!.Select(new ObservableCollection<IDiagramObject>() { Diagram.Nodes![0] });
    }

    // Method to customize the tool
    private InteractionControllerBase GetCustomTool(DiagramElementAction action, string id)
    {
        InteractionControllerBase? tool = null;
        if (id == "AddLeft")
        {
            tool = new AddRightTool(Diagram!);
        }
        else if (id == "AddRight")
        {
            tool = new AddLeftTool(Diagram!);
        }
        else
        {
            tool = new DeleteTool(Diagram!);
        }
        return tool;
    }

    private static async Task AddRightChild(SfDiagramComponent diagram, bool isSibling = false)
    {
        string newChildID = RandomId();
        string newchildColor = ""; BranchType type = BranchType.Left; Node? parentNode = null;
        string parentId = Convert.ToString(diagram.SelectionSettings!.Nodes![0].AdditionalInfo!["ParentId"])!;
        BranchType nodeBranch = (BranchType)diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Orientation"];
        double currentLevel = Convert.ToDouble(diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Level"]);
        double parentLevel = 0;
        if (!string.IsNullOrEmpty(parentId))
        {
            parentNode = diagram.GetObject(parentId) as Node;
            BranchType parentNodeBranch = (BranchType)parentNode!.AdditionalInfo!["Orientation"];
            type = isSibling ? parentNodeBranch : nodeBranch;
        }
        else
        {
            type = nodeBranch;
        }
        BranchType childType = BranchType.Left;
        if (parentNode != null) parentLevel = Convert.ToDouble(parentNode.AdditionalInfo!["Level"]);
        switch (type.ToString())
        {
            case "Root":
                childType = BranchType.Left;
                break;
            case "Left":
                childType = BranchType.SubLeft;
                break;
            case "SubLeft":
                childType = BranchType.SubLeft;
                break;
        }

        double level = isSibling ? parentLevel : currentLevel;
        if (level == 0)
        {
            int index = Convert.ToInt32(GetFillColorIndex(level));
            newchildColor = fillColorCode[index];
        }
        else
        {
            newchildColor = diagram.SelectionSettings.Nodes[0].Style!.Fill!;
        }

        MindMapDetails childNode = new MindMapDetails()
        {
            Id = newChildID.ToString(),
            ParentId = isSibling ? parentId : diagram.SelectionSettings.Nodes[0].ID!,
            Fill = newchildColor,
            Branch = childType,
            Label = "New Child",
            Level = isSibling ? parentLevel + 1 : currentLevel + 1
        };
        diagram.BeginUpdate();
        await UpdatePortConnection(childNode, diagram, isSibling);
        await diagram.EndUpdateAsync();
    }

    // Custom tool to add the node.
    public class AddLeftTool : InteractionControllerBase
    {
        private SfDiagramComponent diagram;

        public AddLeftTool(SfDiagramComponent Diagram) : base(Diagram)
        {
            diagram = Diagram;
        }

        public override async void OnMouseDown(DiagramMouseEventArgs args)
        {
            await AddRightChild(diagram);
            diagram.ClearSelection();
            base.OnMouseDown(args);
            diagram.Select(new ObservableCollection<IDiagramObject>() { diagram.Nodes![diagram.Nodes.Count - 1] });
            this.InAction = true;
        }
    }

    private static async Task UpdatePortConnection(MindMapDetails childNode, SfDiagramComponent diagram, bool isSibling)
    {
        Node node = new Node()
        {
            ID = "node" + childNode.Id,
            Height = 50,
            Width = 100,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation()
                {
                    Content = childNode.Label,
                    Style=new TextStyle(){FontSize = 12,FontFamily="Segoe UI"},
                    Offset=new DiagramPoint(){X=0.5,Y=0.5}
                }
            },
            Style = new ShapeStyle() { Fill = childNode.Fill, StrokeColor = childNode.Fill },
            AdditionalInfo = new Dictionary<string, object>()
            {
                {"Orientation", childNode.Branch},
                {"ParentId", childNode.ParentId!},
                {"Level", childNode.Level},
            }
        };
        Connector connector = new Connector()
        {
            TargetID = node.ID,
            SourceID = isSibling ? childNode.ParentId : diagram.SelectionSettings!.Nodes![0].ID
        };
        await diagram.AddDiagramElementsAsync(new DiagramObjectCollection<NodeBase>() { node, connector });
        Node? sourceNode = diagram.GetObject((connector as Connector).SourceID) as Node;
        Node? targetNode = diagram.GetObject((connector as Connector).TargetID) as Node;
        if (targetNode != null && targetNode.AdditionalInfo!.Count > 0)
        {
            BranchType nodeBranch = (BranchType)targetNode.AdditionalInfo["Orientation"];
            if (nodeBranch == BranchType.Right || nodeBranch == BranchType.SubRight)
            {
                (connector as Connector).SourcePortID = sourceNode!.Ports![0].ID;
                (connector as Connector).TargetPortID = targetNode.Ports![1].ID;
            }
            else if (nodeBranch == BranchType.Left || nodeBranch == BranchType.SubLeft)
            {
                (connector as Connector).SourcePortID = sourceNode!.Ports![1].ID;
                (connector as Connector).TargetPortID = targetNode.Ports![0].ID;
            }
        }
        await diagram.DoLayoutAsync();
    }

    private static async Task AddLeftChild(SfDiagramComponent diagram, bool isSibling = false)
    {
        string newChildID = RandomId();
        string newchildColor = ""; BranchType type = BranchType.Left; Node? parentNode = null;
        string parentId = Convert.ToString(diagram.SelectionSettings!.Nodes![0].AdditionalInfo!["ParentId"])!;
        BranchType nodeBranch = (BranchType)diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Orientation"];
        double currentLevel = Convert.ToDouble(diagram.SelectionSettings.Nodes[0].AdditionalInfo!["Level"]);
        double parentLevel = 0;
        if (!string.IsNullOrEmpty(parentId))
        {
            parentNode = diagram.GetObject(parentId) as Node;
            BranchType parentNodeBranch = (BranchType)parentNode!.AdditionalInfo!["Orientation"];
            type = isSibling ? parentNodeBranch : nodeBranch;
        }
        else
        {
            type = nodeBranch;
        }

        BranchType childType = BranchType.Left;
        if (parentNode != null) parentLevel = Convert.ToDouble(parentNode.AdditionalInfo!["Level"]);
        switch (type.ToString())
        {
            case "Root":
                childType = BranchType.Right;
                break;
            case "Right":
                childType = BranchType.SubRight;
                break;
            case "SubRight":
                childType = BranchType.SubRight;
                break;
        }
        double level = isSibling ? parentLevel : currentLevel;
        if (level == 0)
        {
            int index = Convert.ToInt32(GetFillColorIndex(level));
            newchildColor = fillColorCode[index];
        }
        else
        {
            newchildColor = diagram.SelectionSettings.Nodes[0].Style!.Fill!;
        }
        MindMapDetails childNode = new MindMapDetails()
        {
            Id = newChildID.ToString(),
            ParentId = isSibling ? parentId : diagram.SelectionSettings.Nodes[0].ID!,
            Fill = newchildColor,
            Branch = childType,
            Label = "New Child",
            Level = isSibling ? parentLevel + 1 : currentLevel + 1
        };
        diagram.BeginUpdate();
        await UpdatePortConnection(childNode, diagram, isSibling);
        await diagram.EndUpdateAsync();
    }

    // Custom tool to add the node.
    public class AddRightTool : InteractionControllerBase
    {
        private SfDiagramComponent diagram;
        public AddRightTool(SfDiagramComponent Diagram) : base(Diagram)
        {
            diagram = Diagram;
        }
        public override async void OnMouseDown(DiagramMouseEventArgs args)
        {
            await AddLeftChild(diagram);
            diagram.ClearSelection();
            base.OnMouseDown(args);
            diagram.Select(new ObservableCollection<IDiagramObject>() { diagram.Nodes![diagram.Nodes.Count - 1] });
            this.InAction = true;
        }
    }

    public class DeleteTool : InteractionControllerBase
    {
        private SfDiagramComponent sfDiagram;
        private Node? deleteObject = null;
        public DeleteTool(SfDiagramComponent Diagram) : base(Diagram)
        {
            sfDiagram = Diagram;
        }
        public override void OnMouseDown(DiagramMouseEventArgs args)
        {
            deleteObject = (sfDiagram.SelectionSettings!.Nodes![0]) as Node;
        }
        public override async void OnMouseUp(DiagramMouseEventArgs? args)
        {
            if (deleteObject != null)
            {
                sfDiagram.BeginUpdate();
                RemoveData(deleteObject, sfDiagram);
            _ = sfDiagram.EndUpdateAsync();
            await sfDiagram.DoLayoutAsync();
            }
            base.OnMouseUp(args);
            this.InAction = true;
        }
    }

    private static void RemoveData(Node node, SfDiagramComponent diagram)
    {
        if (node.OutEdges!.Count > 0)
        {
            List<string> outEdges = new List<string>();
            node.OutEdges.ForEach(edges => outEdges.Add(edges));
            for (int i = 0; i < outEdges.Count; i++)
            {
                Connector? connector = diagram.GetObject(outEdges[i]) as Connector;
                Node? targetnode = diagram.GetObject(connector!.TargetID) as Node;
                if (targetnode!.OutEdges!.Count > 0)
                {
                    RemoveData(targetnode, diagram);
                }
                else
                {
                    diagram.Delete(new DiagramObjectCollection<NodeBase>() { targetnode });
                }
            }
            diagram.Delete(new DiagramObjectCollection<NodeBase>() { node });
        }
        else
        {
            diagram.Delete(new DiagramObjectCollection<NodeBase>() { node });
        }
    }

    private void OnSelectionChanging(SelectionChangingEventArgs args)
    {
        if (args.NewValue!.Count > 0)
        {
            if (args.NewValue[0] is Node && (args.NewValue[0] as Node)!.AdditionalInfo!.Count > 0)
            {
                BranchType type = (BranchType)((args.NewValue[0] as Node)!.AdditionalInfo!["Orientation"]);
                if (type == BranchType.Root)
                {
                    selectionSettings.UserHandles![0].Visible = false;
                    selectionSettings.UserHandles[1].Visible = false;
                    selectionSettings.UserHandles[2].Visible = true;
                    selectionSettings.UserHandles[3].Visible = true;
                }
                else if (type == BranchType.Left || type == BranchType.SubLeft)
                {
                    selectionSettings.UserHandles![0].Visible = false;
                    selectionSettings.UserHandles[1].Visible = true;
                    selectionSettings.UserHandles[2].Visible = true;
                    selectionSettings.UserHandles[3].Visible = false;
                }
                else if (type == BranchType.Right || type == BranchType.SubRight)
                {
                    selectionSettings.UserHandles![0].Visible = true;
                    selectionSettings.UserHandles[1].Visible = false;
                    selectionSettings.UserHandles[2].Visible = false;
                    selectionSettings.UserHandles[3].Visible = true;
                }
            }
        }
    }

    private void NodeCreating(IDiagramObject obj)
    {
        Node? node = obj as Node;

        node!.Height = 50;
        node.Width = 100;
        node.Shape = new BasicShape() { Type = NodeShape.Basic, Shape = NodeBasicShapes.Ellipse };
        PointPort port21 = new PointPort()
        {
            ID = "left",
            Offset = new DiagramPoint() { X = 0, Y = 0.5 },
            Height = 10,
            Width = 10,
        };

        PointPort port22 = new PointPort()
        {
            ID = "right",
            Offset = new DiagramPoint() { X = 1, Y = 0.5 },
            Height = 10,
            Width = 10,
        };

        node.Ports = new DiagramObjectCollection<PointPort>()
        {
            port21,port22
        };
        node.Constraints &= ~NodeConstraints.Rotate;
    }

    private void ConnectorCreating(IDiagramObject obj)
    {
        Connector? connector = obj as Connector;
        connector!.Type = ConnectorSegmentType.Bezier;
        connector.BezierConnectorSettings = new BezierConnectorSettings() { AllowSegmentsReset = false };
        connector.Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.Select;
        connector.Style = new ShapeStyle() { StrokeColor = "#4f4f4f", StrokeWidth = 1 };
        connector.TargetDecorator = new DecoratorSettings() { Shape = DecoratorShape.None };
        connector.SourceDecorator!.Shape = DecoratorShape.None;
        Node? sourceNode = Diagram!.GetObject((connector as Connector).SourceID) as Node;
        Node? targetNode = Diagram.GetObject((connector as Connector).TargetID) as Node;
        if (targetNode != null && targetNode.AdditionalInfo!.Count > 0)
        {
            BranchType nodeBranch = (BranchType)targetNode.AdditionalInfo["Orientation"];
            if (nodeBranch == BranchType.Right || nodeBranch == BranchType.SubRight)
            {
                (connector as Connector).SourcePortID = sourceNode!.Ports![0].ID;
                (connector as Connector).TargetPortID = targetNode.Ports![1].ID;
            }
            else if (nodeBranch == BranchType.Left || nodeBranch == BranchType.SubLeft)
            {
                (connector as Connector).SourcePortID = sourceNode!.Ports![1].ID;
                (connector as Connector).TargetPortID = targetNode.Ports![0].ID;
            }
        }
    }

    public void UpdateNodeStyles(Node node, Node parentNode)
    {
        if (node != null && parentNode != null)
        {
            double levelValue = Convert.ToDouble(node.AdditionalInfo!["Level"]);
            if (levelValue == 1)
            {
                node.Style!.Fill = fillColorCode[lastFillIndex];
                node.Style.StrokeColor = borderColorCode[lastFillIndex];
                node.Style.StrokeWidth = 2;
                if (lastFillIndex + 1 >= fillColorCode.Length)
                    lastFillIndex = 0;
                else
                    lastFillIndex++;
            }
            else
                node.Style!.StrokeColor = node.Style.Fill = parentNode.Style!.Fill;
        }
    }

    private static double GetFillColorIndex(double level)
    {
        double index = lastFillIndex;
        if (lastFillIndex + 1 >= fillColorCode.Length)
            lastFillIndex = 0;
        else
            lastFillIndex++;
        return index;
    }

    private void UpdateHandle()
    {
        UserHandle deleteLeftHandle = AddHandle("DeleteRight", "delete", Direction.Right);

        UserHandle addRightHandle = AddHandle("AddLeft", "add", Direction.Left);

        UserHandle addLeftHandle = AddHandle("AddRight", "add", Direction.Right);

        UserHandle deleteRightHandle = AddHandle("DeleteLeft", "delete", Direction.Left);

        handles.Add(deleteLeftHandle);
        handles.Add(deleteRightHandle);
        handles.Add(addLeftHandle);
        handles.Add(addRightHandle);

        selectionSettings.UserHandles = handles;
    }

    private UserHandle AddHandle(string name, string path, Direction direction)
    {
        UserHandle handle = new UserHandle()
        {
            Name = name,
            Visible = true,
            Offset = 0.5,
            Side = direction,
            Margin = new DiagramThickness() { Top = 0, Bottom = 0, Left = 0, Right = 0 }
        };
        if (path == "delete")
        {
            handle.PathData = "M1.0000023,3 L7.0000024,3 7.0000024,8.75 C7.0000024,9.4399996 6.4400025,10 5.7500024,10 L2.2500024,10 C1.5600024,10 1.0000023,9.4399996 1.0000023,8.75 z M2.0699998,0 L5.9300004,0 6.3420029,0.99999994 8.0000001,0.99999994 8.0000001,2 0,2 0,0.99999994 1.6580048,0.99999994 z";
        }
        else
        {
            handle.PathData = "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z";
        }
        return handle;
    }

    public class MindMapDetails
    {
        public string? Id { get; set; }
        public string? Label { get; set; }
        public string? ParentId { get; set; }
        public BranchType Branch { get; set; }
        public string? Fill { get; set; }
        public double Level { get; set; }
    }

    protected override void OnInitialized()
    {
        selectionSettings.Constraints &= ~(SelectorConstraints.ResizeAll | SelectorConstraints.Rotate);
        commands = new DiagramObjectCollection<KeyboardCommand>()
        {
            new KeyboardCommand() { Name = "showShortCut", Gesture = new KeyGesture(){ Key = DiagramKeys.F1, Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "leftChild", Gesture = new KeyGesture(){ Key = DiagramKeys.Tab, Modifiers = ModifierKeys.Shift } },
            new KeyboardCommand() { Name = "rightChild", Gesture = new KeyGesture(){ Key = DiagramKeys.Tab,Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "sibilingChildTop", Gesture = new KeyGesture(){ Key = DiagramKeys.Enter,Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "fitPage", Gesture = new KeyGesture(){ Key = DiagramKeys.F8, Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "duplicate", Gesture = new KeyGesture(){ Key = DiagramKeys.D, Modifiers = ModifierKeys.Control } },

            new KeyboardCommand() { Name = "navigationUp", Gesture = new KeyGesture(){ Key = DiagramKeys.ArrowUp, Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "navigationDown", Gesture = new KeyGesture(){ Key = DiagramKeys.ArrowDown, Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "navigationLeft", Gesture = new KeyGesture(){ Key = DiagramKeys.ArrowLeft, Modifiers = ModifierKeys.None } },
            new KeyboardCommand() { Name = "navigationRight", Gesture = new KeyGesture(){ Key = DiagramKeys.ArrowRight,Modifiers = ModifierKeys.None } },

            new KeyboardCommand() { Name = "fileNew", Gesture = new KeyGesture(){ Key = DiagramKeys.N, Modifiers = ModifierKeys.Shift } },
            new KeyboardCommand() { Name = "fileOpen", Gesture = new KeyGesture(){ Key = DiagramKeys.O, Modifiers = ModifierKeys.Control } },
            new KeyboardCommand() { Name = "fileSave", Gesture = new KeyGesture(){ Key = DiagramKeys.S, Modifiers = ModifierKeys.Control } },
            new KeyboardCommand() { Name = "delete", Gesture = new KeyGesture(){ Key = DiagramKeys.Delete, Modifiers = ModifierKeys.None  } },
            new KeyboardCommand() { Name = "backspace", Gesture = new KeyGesture(){ Key = DiagramKeys.BackSpace, Modifiers = ModifierKeys.None  } },
        };
        MindMapDetails rootNodeData = MindmapData[0];
        CreateNode(rootNodeData.Id!, rootNodeData.ParentId!, rootNodeData.Label!, rootNodeData.Fill!, rootNodeData.Branch, rootNodeData.Level);
        for (int i = 1; i < MindmapData.Count; i++)
        {
            MindMapDetails nodeData = MindmapData[i];
            string sourcePortID = string.Empty;
            string targetPortID = string.Empty;
            CreateNode(nodeData.Id!, nodeData.ParentId!, nodeData.Label!, nodeData.Fill!, nodeData.Branch, nodeData.Level);
            if (nodeData.Branch == BranchType.Right || nodeData.Branch == BranchType.SubRight)
            {
                sourcePortID = "left";
                targetPortID = "right";
            }
            else if (nodeData.Branch == BranchType.Left || nodeData.Branch == BranchType.SubLeft)
            {
                sourcePortID = "right";
                targetPortID = "left";
            }
            Connector connector = new Connector() { ID = "connector" + i, SourceID = nodeData.ParentId, TargetID = nodeData.Id, SourcePortID = sourcePortID, TargetPortID = targetPortID };
            connectors.Add(connector);
        }
    }

    private void CreateNode(string id, string parentId, string annotationContent, string fillColor, BranchType branch, double level)
    {
        Node node = new Node()
        {
            ID = id,
            Annotations = new DiagramObjectCollection<ShapeAnnotation>()
            {
                new ShapeAnnotation()
                {
                    Content = annotationContent,
                    Style=new TextStyle(){FontSize = 12,FontFamily="Segoe UI"},
                    Offset=new DiagramPoint(){X=0.5,Y=0.5}, Width = 80
                }
            },
            Style = new ShapeStyle() { Fill = fillColor, StrokeColor = fillColor },
            AdditionalInfo = new Dictionary<string, object>()
            {
                {"Orientation", branch},
                {"ParentId", parentId},
                {"Level", level},
            }
        };
        nodes.Add(node);
    }

    internal static string RandomId()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
        return new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
        if (DiagramOpenAIRef != null)
            DiagramOpenAIRef.Parent = this;
            UpdateHandle();
        }
    }
}

{% endhighlight %}
{% endtabs %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/AISamples/MauiAppAISample).

N> [View the Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DiagramComponent).

## How to Run the Sample on Windows

Run the sample in Windows Machine mode, and it will run Blazor MAUI in Windows.

![Run Windows machine](images/blazor-diagram-maui.png)

When the application is successfully launched, the Diagram component will seamlessly render the specified diagram page.

![Run Windows machine](images/blazor-diagram-maui-page.png)

## How to Run the Sample on Android

To run the Blazor Diagram Component in a Blazor Android MAUI application using the Android emulator, follow these steps:

![Run Windows machine](images/blazor-diagram-maui-android.png)

Refer [here](https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/device-manager#android-device-manager-on-windows) to install and launch Android emulator.

N> If you encounter any errors while using the Android Emulator, refer to the following link for troubleshooting guidance[Troubleshooting Android Emulator](https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/troubleshooting).

![Blazor Diagram Component](images/blazor-diagram-maui-andoid-page.png)

{% endtabcontent %}

{% endtabcontents %}

## See also

* [How to Create a Diagram Builder in MAUI platform](https://support.syncfusion.com/kb/article/11346/how-to-create-diagram-builder-in-maui-platform)
