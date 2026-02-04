# Creating AI-Powered Diagrams in Blazor using Syncfusion Diagram

The Syncfusion Blazor Diagram Component can be enhanced with AI-driven features by using the [Syncfusion.Blazor.AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) NuGet package. This guide explains how to create Flowcharts, Mind Maps, and Sequence Diagrams using AI in the Syncfusion Blazor Diagram component. You can use different AI services such as `OpenAI`, `Azure OpenAI`, or `Ollama`. Users can enter natural-language text, and AI automatically generates and renders diagrams.

## Prerequisites

    * [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)
    * One of the following AI services:
        * [OpenAI](https://help.openai.com/en/articles/4936850-where-do-i-find-my-openai-api-key)
        * [Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource)
        * Ollama (self‑hosted)

## How to Create a Blazor Application

To create a Blazor application, follow the Getting Started documentation for [Web App](https://blazor.syncfusion.com/documentation/diagram/getting-started-with-web-app), [Server](https://blazor.syncfusion.com/documentation/diagram/getting-started), [WASM](https://blazor.syncfusion.com/documentation/diagram/getting-started-with-wasm-app), [MAUI](https://blazor.syncfusion.com/documentation/diagram/getting-started-with-maui-app).

## Install Required NuGet Packages

Ensure the following Syncfusion and AI NuGet packages are installed based on the selected AI service.

{% tabcontents %}
{% tabcontent Syncfusion Packages %}

* Install-Package Syncfusion.Blazor.Diagram
* Install-Package Syncfusion.Blazor.Themes
* Install-Package Syncfusion.Blazor.AI

{% endtabcontent %}
{% tabcontent OpenAI %}

* Install-Package Microsoft.Extensions.AI
* Install-Package Microsoft.Extensions.AI.OpenAI

{% endtabcontent %}
{% tabcontent Azure OpenAI %}

* Install-Package Microsoft.Extensions.AI
* Install-Package Microsoft.Extensions.AI.OpenAI
* Install-Package Azure.AI.OpenAI

{% endtabcontent %}
{% tabcontent Ollama %}

* Install-Package Microsoft.Extensions.AI
* Install-Package OllamaSharp

{% endtabcontent %}
{% endtabcontents %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference to the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Configure AI service and Syncfusion Blazor service

Choose one of the following AI services (OpenAI, Azure OpenAI, or Ollama) based on requirements:

* `OpenAI`: Cloud-based, general-purpose AI models with minimal setup.
* `Azure OpenAI`: Enterprise-grade deployment with enhanced security and scalability.
* `Ollama`: Self-hosted, privacy-focused AI models.

Follow the instructions for the selected service to register the Syncfusion and AI model in the application.

### OpenAI

Generate an API key from `OpenAI` and set `openAIAPIKey`. Specify the desired model (for example, gpt-3.5-turbo, gpt-4) in `openAIModel`.

Add the following code to the `~/Program.cs` file:

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="10 13-17 20" %}

// Add required namespaces
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using Syncfusion.Blazor.SmartComponents;
using OpenAI;

....

builder.Services.AddSyncfusionBlazor();

// Register OpenAI credentials
string openAIAPIKey = "OPENAI_API_KEY"; // Use secure storage
string openAIModel = "OPENAI_MODEL"; // Specify a valid OpenAI model e.g "gpt-4".
OpenAIClient openAIClient = new OpenAIClient(openAIAPIKey);
IChatClient openAIChatClient = openAIClient.GetChatClient(openAIModel).AsIChatClient();
builder.Services.AddChatClient(openAIChatClient);

// Register the inference service
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();    

{% endhighlight %}

### Azure OpenAI

Deploy an Azure OpenAI Service resource and model as described in [Microsoft's documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource). Obtain values for `azureOpenAIKey`, `azureOpenAIEndpoint`, and `azureOpenAIModel`.

Add the following to the **~/Program.cs** file in the Blazor Web App:

{% tabs %}
{% highlight C# tabtitle="Blazor WebApp" hl_lines="10 12-20 22" %}

using Syncfusion.Blazor.AI;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);
// Register Syncfusion blazor service
builder.Services.AddSyncfusionBlazor();

string azureOpenAIKey = "AZURE_OPENAI_KEY";
string azureOpenAIEndpoint = "AZURE_OPENAI_ENDPOINT";
string azureOpenAIModel = "AZURE_OPENAI_MODEL";
AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(
     new Uri(azureOpenAIEndpoint),
     new ApiKeyCredential(azureOpenAIKey)
);
IChatClient azureOpenAIChatClient = azureOpenAIClient.GetChatClient(azureOpenAIModel).AsIChatClient();
builder.Services.AddChatClient(azureOpenAIChatClient);

// Register the inference service
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

### Ollama

To use Ollama for self-hosted AI models:

1. **Download and install Ollama**: Visit [Ollama's official website](https://ollama.com) and install the application for the operating system.
2. **Install a model**: Choose a model from the [Ollama Library](https://ollama.com/library) (for example, `llama2:13b`, `mistral:7b`).
3. **Configure the application**: Provide the `Endpoint` URL (for example, `http://localhost:11434`) and `ModelName` (for example, `llama2:13b`).

Add the following code to the **~/Program.cs** file:

{% tabs %}
{% highlight C# tabtitle="Blazor WebApp" hl_lines="8 10-12 14" %}

using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

var builder = WebApplication.CreateBuilder(args);
// Register Syncfusion blazor service
builder.Services.AddSyncfusionBlazor();

string ModelName = "MODEL_NAME";
IChatClient chatClient = new OllamaApiClient("http://localhost:11434", ModelName);
builder.Services.AddChatClient(chatClient);

// Register the inference service
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

- **Verify connectivity**: Ensure the Ollama server is running and accessible at the specified endpoint (for example, `http://localhost:11434`) before starting the application.

## Integrated Diagram with AI

The following diagram features are supported through AI generation:

* Flow Chart
* Mind Map
* Sequence Diagram

Each features is generated by varying the AI prompt while maintaining the same rendering pipeline.

This section demonstrates how to integrate the Diagram component with AI, using Flowchart layout creation as an example.

### Adding the Diagram UI

Create the `Home.razor` file in the `Pages` folder and add the Diagram component.

{% highlight C# tabtitle="Home.razor" %}
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Spinner
@using System.Collections.ObjectModel
@using System.Text.Json;

<div style="border: 2px solid #ccc;">
    <div class="diagram-area">
        <SfDiagramComponent ID="diagram-area" @ref="@Diagram" @bind-Height="height" @bind-Width="width">
            <Layout @bind-HorizontalSpacing="@HorizontalSpacing" @bind-VerticalSpacing="@VerticalSpacing" @bind-Type="@layoutType"></Layout>
            <SfSpinner @ref="@SpinnerRef" Label="Generating diagram...." Type="@SpinnerType.Bootstrap"> </SfSpinner>
        </SfDiagramComponent>
    </div>
</div>
<DiagramOpenAI @ref="DiagramOpenAIRef"></DiagramOpenAI>
       
@code
{
    public SfDiagramComponent? Diagram;
    public SfSpinner? SpinnerRef;
    public DiagramOpenAI? DiagramOpenAIRef;
    public bool IsGeneratingFromAI = false;
    private LayoutType layoutType = LayoutType.FlowChart;
    private string height = "700px";
    private string width = "100%";
    private int VerticalSpacing = 20;
    private int HorizontalSpacing = 80;
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
            if (DiagramOpenAIRef != null)
                DiagramOpenAIRef.Parent = this;
        }
    }
}
{% endhighlight %}

### Adding the AI Assist UI

* Create the `DiagramOpenAI.razor` component to add the `AI Assist` button using the [SfFab](https://blazor.syncfusion.com/documentation/floating-action-button/getting-started-with-web-app) component. When the button is clicked, the AI Assist dialog opens and displays suggested prompts, along with an option for the user to enter a custom prompt to generate a diagram.

{% tabs %}
{% highlight C# tabtitle="DiagramOpenAI.razor" %}
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
@using AIService
@inject AzureAIService DiagramAIService
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

{% highlight C# tabtitle="DiagramOpenAI.razor.cs" %}
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
           // refer the code in below topic
        }
    }
}

{% endhighlight %}
{% endtabs %}


### AI-Driven Diagram Generation Workflow

* When the user clicks the `Generate` button inside the AI Assist dialog, the `GetResponseFromAI` method is invoked. This method identifies the current diagram features based on layout types (mind map, flowchart, or sequence) and constructs the appropriate system and user prompts. It then calls the AI service using `GetCompletionAsync` method to obtain either Mermaid syntax or tab-indented mind-map lines, sanitizes the AI response by removing code fences and non-Mermaid content, and extracts the valid Mermaid portion. Finally, the extracted Mermaid text is loaded into the Diagram using the [LoadDiagramFromMermaidAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_LoadDiagramFromMermaidAsync_System_String_) method.

{% tabs %}
{% highlight C# tabtitle="DiagramOpenAI.razor.cs" %}

public async Task GetResponseFromAI()
{
    Parent.IsGeneratingFromAI = true;
    ShowAIAssistDialog = false;
    if (!string.IsNullOrWhiteSpace(OpenAIPrompt))
    {
        await Parent.SpinnerRef!.ShowAsync();
        string result = string.Empty;
        
        // Determine layoutType
        LayoutType layoutType = Parent.Diagram.Layout != null ? Parent.Diagram.Layout.Type : LayoutType.None;

        string systemRole;
        string userPrompt;
        string mermaidStartText;

        if (layoutType == LayoutType.MindMap)
        {
            systemRole = "You are an expert in creating mind map diagram data sources. Return ONLY tab-indented lines: root with no indent, each child indented by one tab. Do not include bullets, numbering, or explanatory text.";
            userPrompt = $"Create a tab-indented mind map for: {OpenAIPrompt}. Start with "mindmap" text";
            mermaidStartText = "mindmap";
        }
        else if (layoutType == LayoutType.Flowchart)
        {
            systemRole = "You are an expert assistant skilled in generating Mermaid flowchart code. Return ONLY Mermaid flowchart code (no explanation, no code fences).";
            userPrompt = $"Create a Mermaid flowchart code for the process titled: {OpenAIPrompt}. Include decision points and Yes/No branches. Return only Mermaid code.";
            mermaidStartText = "graph TD";
        }
        else // Sequence diagram
        {
            systemRole = "You are an expert at generating Mermaid sequenceDiagram code. Return ONLY Mermaid sequenceDiagram text.";
            userPrompt = $"Create a Mermaid sequenceDiagram for: {OpenAIPrompt}. Return only Mermaid code.";
            mermaidStartText = "sequenceDiagram";
        }
        
        result = await DiagramAIService.GetCompletionAsync(userPrompt, false, systemRole);
        if (result != null)
        {
            List<string> lines = result.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            lines = lines.Where(line => !line.Contains("```")).ToList();
            int startIndex = lines.FindIndex(line => line.Trim().StartsWith(mermaidStartText));
            if (startIndex != -1)
            {
                List<string> validMermaidData = lines.Skip(startIndex).ToList();
                result = string.Join(Environment.NewLine, validMermaidData);
                await Parent.Diagram.LoadDiagramFromMermaidAsync(result);
            }
            StateHasChanged();
        }
        await Parent.SpinnerRef.HideAsync();
    }
    Parent.IsGeneratingFromAI = false;
}
{% endhighlight %}
{% highlight C# tabtitle="AzureAIService.cs" %}
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

        /// <summary>
        /// Gets a text completion from the Azure OpenAI service.
        /// </summary>
        /// <param name="prompt">The user prompt to send to the AI service.</param>
        /// <param name="returnAsJson">Indicates whether the response should be returned in JSON format. Defaults to <c>true</c></param>
        /// <param name="systemRole">Specifies the systemRole that is sent to AI Clients. Defaults to <c>null</c></param>
        /// <returns>The AI-generated completion as a string.</returns>
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

## Run the Application

* Start the application to load the empty diagram and the AI Assist button.
* Click the AI Assist button to open the dialog.
* Choose a suggested prompt or type own prompt in the text box.
* Click the Generate (send) button to create the diagram.
* A loading spinner appears while the AI processes the prompt.
* Once processing is complete, the generated diagram is displayed.

>Note: To generate a Mind Map or Flowchart, the [Layout.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Layout.html#Syncfusion_Blazor_Diagram_Layout_Type) property must be set to **Layout.MindMap** or **Layout.FlowChart**. When generating a `Sequence Diagram`, you do not need to set the layout type.

## Error handling and troubleshooting

If the AI service fails to return a valid response, the Diagram displays an error message ("Oops! Please try again!"). Common issues include:

- **Invalid API key or endpoint**: Verify that `openAIApiKey`, `azureOpenAIKey`, or the Ollama `Endpoint` is correct and the service is accessible.
- **Model unavailable**: Ensure the specified `openAIModel`, `azureOpenAIModel`, or `ModelName` is deployed and supported.
- **Network issues**: Check connectivity to the AI service endpoint, especially for self-hosted Ollama instances.
- **Large datasets**: Processing large datasets may cause timeouts. Consider batching data or optimizing the prompt.

## Sample code

A complete working example is available in the [Syncfusion Blazor AI Samples GitHub repository](https://github.com/syncfusion/smart-ai-samples).

## Live Demo

Explore the AI-powered Smart Diagram in action by visiting the live demo:

👉 [Try the Live Demo for Flow Chart](https://blazor.syncfusion.com/demos/diagram/ai-text-to-flowchart?theme=fluent2)
👉 [Try the Live Demo for Mind Map](https://blazor.syncfusion.com/demos/diagram/ai-text-to-mindmap?theme=fluent2)
👉 [Try the Live Demo for Sequence Diagram](https://blazor.syncfusion.com/demos/diagram/ai-text-to-sequence-diagram?theme=fluent2)

## See Also

* [Getting Started with Blazor Diagram Component](https://blazor.syncfusion.com/documentation/diagram/getting-started-with-web-app)
* [Flowchart Layout in Blazor Diagram Component](https://blazor.syncfusion.com/documentation/diagram/layout/flowchart-layout)
* [Mind Map Layout in Blazor Diagram Component](https://blazor.syncfusion.com/documentation/diagram/layout/mind-map)
* [Sequence Diagram Model in Blazor diagram component](https://blazor.syncfusion.com/documentation/diagram/uml-sequence-diagram)