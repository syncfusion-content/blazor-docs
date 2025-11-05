---
layout: post
title: AI-Powered Content Assistance in Blazor Rich Text Editor | Syncfusion
description: Enhance content creation in Blazor Rich Text Editor using AI for grammar correction, summarization, translation, and more.
platform: Blazor
control: AI Integration
documentation: ug
keywords: Blazor Rich Text Editor, AI content enhancement, Syncfusion Blazor AI
---

# AI-Powered Content Assistance in Blazor Rich Text Editor

This guide demonstrates how to use the [**Syncfusion.Blazor.AI**](https://www.nuget.org/packages/Syncfusion.Blazor.AI) package to enhance content creation in the Syncfusion Blazor Rich Text Editor. The AI integration enables intelligent features such as grammar correction, summarization, elaboration, translation, and rephrasing. These capabilities are powered by AI models hosted via services like OpenAI, Azure OpenAI, or Ollama.

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

Install-Package Syncfusion.Blazor.RichTextEditor -Version {{ site.releaseversion }}
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

This section implements the Syncfusion Blazor Rich Text Editor with AI-powered content assistance features such as rephrase, correct grammar, summarize, elaborate, and translate.

(`Home.razor`)

```razor
@inject AzureAIService semanticKernelAI
@inject IJSRuntime JSRuntime
@using AISamples.Components.Service
@using Syncfusion.Blazor.RichTextEditor
@using Syncfusion.Blazor.SplitButtons
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Notifications
@using Syncfusion.Blazor.DropDowns

<div class="control-section" id="rteSection">
    <SfRichTextEditor Height="500px" Width="100%" @ref="rteObj" @bind-Value="@Value" SaveInterval="0" AutoSaveOnIdle="true">
        <RichTextEditorToolbarSettings Items="@Tools">
            <RichTextEditorCustomToolbarItems>
                <RichTextEditorCustomToolbarItem Name="AIAssistant">
                    <Template>
                        <SfDropDownButton CssClass="menubutton e-tbar-btn e-tbar-btn-text" IconCss="e-icons e-ai-chat e-btn-icon e-icon-left" Content="AI Assistant" Disabled="@enabelAIAssitantButton">
                            <DropDownButtonEvents ItemSelected="AIQuerySelectedMenu" />
                            <DropDownMenuItems>
                                <DropDownMenuItem Text="Rephrase"></DropDownMenuItem>
                                <DropDownMenuItem Text="Correct Grammar"></DropDownMenuItem>
                                <DropDownMenuItem Text="Summarize"></DropDownMenuItem>
                                <DropDownMenuItem Text="Elaborate"></DropDownMenuItem>
                                <DropDownMenuItem Text="Translate"></DropDownMenuItem>
                            </DropDownMenuItems>
                        </SfDropDownButton>
                    </Template>
                </RichTextEditorCustomToolbarItem>
                <RichTextEditorCustomToolbarItem Name="Rephrase">
                    <Template>
                        <SfButton CssClass="@ButtonClass" @onclick="Rephrase" Disabled="@enabelAIAssitantButton">
                            <div class="e-tbar-btn-text">Rephrase</div>
                        </SfButton>
                    </Template>
                </RichTextEditorCustomToolbarItem>
            </RichTextEditorCustomToolbarItems>
        </RichTextEditorToolbarSettings>
        <RichTextEditorEvents ValueChange="UpdateStatus" OnActionComplete="@(args => OnActionCompleteHandler(args))" />
    </SfRichTextEditor>
</div>
<div class="scroll-restricted">
    <SfDialog @bind-Visible="@dialogVisible" AllowPrerender="true" CssClass="e-rte-elements custom-dialog" ZIndex="1000" ShowCloseIcon="true" IsModal="true" Width="80%" Height="100%" Target="#rteSection">
        <DialogTemplates>
            <Header> <span class="e-icons e-ai-chat e-btn-icon e-icon-left"></span> AI Assistant </Header>
            <Content>             
                <div class="custom-row-0">
                    <div class="col-12 col-md-3 d-flex justify-content-start align-items-center">
                        <div class="w-100">
                            <SfDropDownList CssClass="e-round-corner" TItem="SubQuery" TValue="string" DataSource="@QueryList" @bind-Value="@dropVal" Enabled="@(!enabelRegenerateContentButton)">
                                <DropDownListEvents TItem="SubQuery" TValue="string" />
                                <DropDownListFieldSettings Text="Text" Value="ID" />
                                <DropDownListEvents TValue="string" TItem="SubQuery" ValueChange="AIQuerySelectedDropdownList"></DropDownListEvents>
                            </SfDropDownList>
                        </div>
                    </div>
                    <div class="col-12 col-md-9 mt-9 mt-md-0 d-flex justify-content-end align-items-center">
                        @if (this.enableRephraseChips)
                        {
                            <SfChip CssClass="e-custom" Selection="SelectionType.Single" @bind-SelectedChips="@chipValue">
                                <ChipItems>
                                    <ChipItem Text="Standard" CssClass="e-custom"></ChipItem>
                                    <ChipItem Text="Fluent" CssClass="e-custom"></ChipItem>
                                    <ChipItem Text="Professional" CssClass="e-custom"></ChipItem>
                                </ChipItems>
                                <ChipEvents SelectionChanged="SelectedChipsChanged"></ChipEvents>
                            </SfChip>
                        }
                        else if (this.enableLanguageList)
                        {
                            <div class="col-3 col-md-3 mt-3 mt-md-0 d-flex cuscol justify-content-end align-items-center">
                                <span>Target Language</span>
                            </div>
                            <div class="col-3 col-md-3 mt-3 mt-md-0 d-flex justify-content-end align-items-center">
                                <SfDropDownList CssClass="e-round-corner" TItem="Languages" TValue="string" DataSource="@LanguageList" @bind-Value="@translatelanguage">
                                    <DropDownListFieldSettings Text="Text" Value="ID" />
                                    <DropDownListEvents TValue="string" TItem="Languages" ValueChange="AITranslateDropdownList"></DropDownListEvents>
                                </SfDropDownList>
                            </div>
                        }
                    </div>
                </div>
                <div class="custom-row-1">
                    <div class="col-12 col-md-6 d-flex cuscol-1 justify-content-start">
                        <div class="w-100">
                            <SfRichTextEditor Width="100%" Height="286px" @ref="leftRteChildObj" @bind-Value="promptQuery">
                                <RichTextEditorToolbarSettings Enable="false"></RichTextEditorToolbarSettings>
                            </SfRichTextEditor>
                        </div>
                    </div>
                    @if (!isContentGenerating)
                    {
                        @if (noResultsFound)
                        {
                            <div class="col-12 col-md-6 mt-6 mt-md-0 d-flex cuscol-2 cuscol-noresult justify-content-center">
                                <div class="w-100">
                                    <div class="no-results-found">
                                        <span class="e-icons e-warning"></span>
                                        <div>No results found</div>
                                    </div>
                                </div>
                            </div>
                        }
                        else {
                            <div class="col-12 col-md-6 mt-6 mt-md-0 d-flex cuscol-2 justify-content-start">
                                <div class="w-100">
                                    <SfRichTextEditor Width="100%" Height="286px" @ref="rightRteChildObj" @bind-Value="AIResult">
                                        <RichTextEditorToolbarSettings Enable="false"></RichTextEditorToolbarSettings>
                                    </SfRichTextEditor>
                                </div>
                            </div>
                        }
                    } else {
                        <div class="col-12 col-md-6 mt-6 mt-md-0 d-flex cuscol-2 justify-content-start">
                            <div class="w-100">
                                <div class="content-preparing">
                                    <SfSkeleton CssClass="skeleton-rectangle" Shape=SkeletonType.Rectangle Width="100%" Height="20px"></SfSkeleton><br />
                                    <SfSkeleton CssClass="skeleton-rectangle" Shape=SkeletonType.Rectangle Width="90%" Height="20px"></SfSkeleton><br />
                                    <SfSkeleton CssClass="skeleton-rectangle" Shape=SkeletonType.Rectangle Width="70%" Height="20px"></SfSkeleton><br />
                                    <SfSkeleton CssClass="skeleton-rectangle" Shape=SkeletonType.Rectangle Width="50%" Height="20px"></SfSkeleton><br />
                                    <SfSkeleton CssClass="skeleton-rectangle" Shape=SkeletonType.Rectangle Width="30%" Height="20px"></SfSkeleton><br />
                                    <SfSkeleton CssClass="skeleton-rectangle" Shape=SkeletonType.Rectangle Width="10%" Height="20px"></SfSkeleton>
                                </div>
                            </div>
                        </div>
                    }
                </div>
            </Content>
            <FooterTemplate>
                <div class="custom-row-2">
                    <div class="col-12 col-md-6 d-flex cuscol-0 justify-content-end align-items-center">
                        <div class="w-100">
                            <SfButton Disabled="@enabelRegenerateContentButton" IsPrimary="true" @onclick="RegenerateContent">Regenerate</SfButton>
                        </div>
                    </div>
                    <div class="col-12 col-md-6 mt-6 mt-md-0 cuscol-01 d-flex justify-content-end align-items-center">
                        @if (!string.IsNullOrEmpty(sentiment)) {
                            <button class="e-btn e-control e-info sentiment" id="info_Toast" disabled>@sentiment</button>
                        }
                        <SfButton Disabled="@enabelContentButton" @onclick="CopyContent">Copy</SfButton>
                        <SfButton Disabled="@enabelContentButton" IsPrimary="true" @onclick="ReplaceContent">Replace</SfButton>
                    </div>
                </div>
            </FooterTemplate>
        </DialogTemplates>
        <DialogEvents Closed="CloseDialog" OnOverlayModalClick="CloseDialog"/>
    </SfDialog>
</div>
<SfToast @ref="ToastObj" ID="toast_type" Target="@ToastTarget" ShowCloseButton="true">
    <ToastPosition X="Right" Y="Top" />
</SfToast>

```

`Home.razor.cs`

```csharp
using Markdig;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Inputs;
using Syncfusion.Blazor.Notifications;
using Syncfusion.Blazor.RichTextEditor;
using Syncfusion.Blazor.SplitButtons;

namespace AISamples.Components.Pages
{
    public partial class Home
    {
        SfToast ToastObj;
        private string ToastTarget { get; set; } = "#scroll-restricted";
        SfRichTextEditor rteObj;
        SfRichTextEditor leftRteChildObj;
        SfRichTextEditor rightRteChildObj;
        private string Value { get; set; } = "<h5><span>Integrate AI with the Editor</span></h5><p>Integrate the AI assistant into the rich text editor by capturing the content from the editor, sending it to the AI service, and displaying the results or suggestions back in the editor.</p><h6>Summarize</h6><p>This function condenses the selected content into a brief summary, capturing the main points succinctly.</p><h6>Elaborate</h6><p>This function expands the selected content, adding additional details and context.</p><h6>Rephrase</h6><p>This function rewrites the selected content to convey the same meaning using different words or structures. It also enables rephrase options and disables language selection.</p><h6>Correct Grammar</h6><p>This function reviews and corrects the grammar of the selected content, ensuring it adheres to standard grammatical rules.</p><h6>Translate</h6><p>This function translates the selected content into the specified language, enabling language selection and disabling rephrase options.</p>";
        private bool dialogVisible { get; set; }
        private bool enabelAIAssitantButton { get; set; } = false;
        private bool enabelRegenerateContentButton { get; set; } = false;
        private bool enabelContentButton { get; set; } = true;
        private string promptQuery = string.Empty;
        private string subQuery = string.Empty;
        private string[] chipValue = new[] { "Standard" };
        private string translatelanguage = "EN";
        private string dropVal { get; set; } = "Rephrase";
        private bool enableRephraseChips { get; set; } = true;
        private bool enableLanguageList { get; set; } = false;
        private bool noResultsFound { get; set; } = false;
        public bool isContentGenerating { get; set; } = true;
        private string AIResult { get; set; } = string.Empty;
        private bool isSentimentCheck { get; set; } = false;
        private MarkdownPipeline pipeline { get; set; } = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        private string sentiment = "";
        private string apiResultData = "";
        private string ButtonClass = "e-tbar-btn";
        private void UpdateStatus(Syncfusion.Blazor.RichTextEditor.ChangeEventArgs args)
        {
            Value = args.Value;
            enabelAIAssitantButton = string.IsNullOrWhiteSpace(Value);
        }
        private void OnActionCompleteHandler(Syncfusion.Blazor.RichTextEditor.ActionCompleteEventArgs args)
        {
            if (args.RequestType == "SourceCode")
            {
                this.ButtonClass = "e-tbar-btn e-overlay";
            }
            if (args.RequestType == "Preview")
            {
                this.ButtonClass = "e-tbar-btn";
            }
        }
        private void UpdateTextAreaStatus(InputEventArgs args)
        {
            Value = args.Value;
            enabelRegenerateContentButton = string.IsNullOrWhiteSpace(Value);
        }
        private async Task AIQuerySelectedMenu(MenuEventArgs args)
        {
            await DialogueOpen(args.Item.Text);
        }
        private async Task Rephrase()
        {
            await DialogueOpen("Rephrase");
        }
        private async Task DialogueOpen(string selectedQuery)
        {
            var selectionText = await rteObj.GetSelectedHtmlAsync();
            if (!string.IsNullOrEmpty(selectionText))
            {
                dialogVisible = true;
                dropVal = QueryList.FirstOrDefault(q => q.Text.Equals(selectedQuery, StringComparison.OrdinalIgnoreCase))?.ID;
                promptQuery = selectionText;
                await this.rteObj.SaveSelectionAsync();
                await this.leftRteChildObj.RefreshUIAsync();
                await UpdateAISuggestionsData(selectedQuery);
            }
            else
            {
                await this.ToastObj.ShowAsync(new ToastModel { ContentTemplate = @GetTemplate(true), ShowCloseButton = true, Timeout = 0 });
            }
        }
        private async Task SelectedChipsChanged(Syncfusion.Blazor.Buttons.SelectionChangedEventArgs args)
        {
            if (chipValue.Length == 0 && args != null && args.RemovedItems.Length > 0)
            {
                chipValue = new [] { args.RemovedItems[0] };
            }
            await UpdateAISuggestionsData("Rephrase");
        }
        private async Task AITranslateDropdownList(ChangeEventArgs<string, Languages> args)
        {
            await UpdateAISuggestionsData("Translate");
        }
        private async Task AIQuerySelectedDropdownList(ChangeEventArgs<string, SubQuery> args)
        {
            if (!string.IsNullOrEmpty(dropVal))
            {
                chipValue = new[] { "Standard" };
                translatelanguage = "EN";
                var selectedQuery = QueryList.FirstOrDefault(q => q.ID.Equals(dropVal, StringComparison.OrdinalIgnoreCase))?.Text;
                await UpdateAISuggestionsData(selectedQuery);
            }
        }
        private async Task UpdateAISuggestionsData(string selectedQuery)
        {
            enableRephraseChips = false;
            enableLanguageList = false;
            isSentimentCheck = false;
            switch (selectedQuery)
            {
                case "Summarize":
                    subQuery = "Briefly summarize the following text in a short and concise manner.";
                    break;
                case "Elaborate":
                    subQuery = "Elaborate/Expand on the following text, providing more detail and context.";
                    break;
                case "Rephrase":
                    enableRephraseChips = true;
                    enableLanguageList = false;
                    subQuery = $"Rephrase the following text in a {chipValue[0]} [tone/style], ensuring clarity and maintaining the original meaning.";
                    break;
                case "Correct Grammar":
                    subQuery = "Correct any grammatical errors in the following text, ensuring it is clear and well-structured.";
                    break;
                case "Translate":
                    enableLanguageList = true;
                    enableRephraseChips = false;
                    subQuery = $"Translate the following text into {translatelanguage}, preserving the original meaning and tone.";
                    break;
            }
            UpdateAISuggestionsData();
        }
        private async Task RegenerateContent()
        {
            UpdateAISuggestionsData();
        }
        private async Task ReplaceContent()
        {
            ExecuteCommandOption executeCommandOption = new ExecuteCommandOption();
            executeCommandOption.Undo = true;
            await this.rteObj.RestoreSelectionAsync();
            await this.rteObj.ExecuteCommandAsync(CommandName.InsertHTML, this.apiResultData, executeCommandOption);
            await CloseDialog();
        }
        private async Task CopyContent()
        {
            await JSRuntime.InvokeVoidAsync("copyToClipboard", Markdig.Markdown.ToPlainText(AIResult, pipeline));
        }
        private async Task CloseDialog()
        {
            dialogVisible = false;
            promptQuery = string.Empty;
            AIResult = string.Empty;
            chipValue = new[] { "Standard" };
            dropVal = "Query1";
            enableRephraseChips = true;
            enableLanguageList = false;
            sentiment = "";
            apiResultData = "";
        }
        private async Task UpdateAISuggestionsData()
        {
            try
            {
                if (!string.IsNullOrEmpty(promptQuery))
                {
                    enabelRegenerateContentButton = isContentGenerating = enabelContentButton = true;
                    string systemPrompt = subQuery.Contains("emoji followed by the sentiment in the format") ? "You are a helpful assistant. Please respond in string format." : "NOTE:Please retain the existing HTML structure and modify the content only. Ensure that the response adheres to the specified formatting.";
                    apiResultData = await semanticKernelAI.GetCompletionAsync(promptQuery, false, false, (subQuery + systemPrompt));
                    if (apiResultData != null)
                    {
                        isContentGenerating = false;
                        sentiment = isSentimentCheck ? apiResultData.Replace("\"", "").Replace("'", "") : "";
                        AIResult = isSentimentCheck ? promptQuery : apiResultData;
                        noResultsFound = string.IsNullOrEmpty(AIResult) || string.IsNullOrEmpty(promptQuery);
                        enabelRegenerateContentButton = enabelContentButton = noResultsFound;
                        await InvokeAsync(StateHasChanged);
                    }
                    else
                    {
                        isContentGenerating = false;
                        await InvokeAsync(StateHasChanged);
                    }
                }
                }
                catch
                {
                    await this.ToastObj.ShowAsync(new ToastModel { ContentTemplate = @GetTemplate(), ShowCloseButton = true, Timeout = 0 });
                }
            }
            private RenderFragment GetTemplate(bool hasTextSelection = false) => builder =>
            {
                builder.OpenElement(0, "div");
                builder.AddContent(1, hasTextSelection ? "Please select the content to perform the AI operation." : "An error occurred during the AI process, Please try again.");
                builder.CloseElement();
            };
            public class SubQuery
            {
                public string ID { get; set; }
                public string Text { get; set; }
            }
            public class Languages
            {
                public string ID { get; set; }
                public string Text { get; set; }
            }
            public List<SubQuery> QueryList = new List<SubQuery>
        {
            new SubQuery { ID = "Rephrase", Text = "Rephrase" },
            new SubQuery { ID = "Grammar", Text = "Correct Grammar" },
            new SubQuery { ID = "Summarize", Text = "Summarize" },
            new SubQuery { ID = "Elaborate", Text = "Elaborate" },
            new SubQuery { ID = "Translate", Text = "Translate" }
        };
            public List<Languages> LanguageList = new List<Languages>
        {
            new Languages { ID = "EN", Text = "English" },
            new Languages { ID = "ZH", Text = "Chinese (Simplified)" },
            new Languages { ID = "ZHT", Text = "Chinese (Traditional)" },
            new Languages { ID = "ES", Text = "Spanish" },
            new Languages { ID = "HI", Text = "Hindi" },
            new Languages { ID = "AR", Text = "Arabic" },
            new Languages { ID = "BN", Text = "Bengali" },
            new Languages { ID = "PT", Text = "Portuguese" },
            new Languages { ID = "RU", Text = "Russian" },
            new Languages { ID = "JA", Text = "Japanese" },
            new Languages { ID = "DE", Text = "German" },
            new Languages { ID = "KO", Text = "Korean" },
            new Languages { ID = "FR", Text = "French" },
            new Languages { ID = "IT", Text = "Italian" },
            new Languages { ID = "TR", Text = "Turkish" }
        };
            private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
        {
            new ToolbarItemModel() { Name = "AIAssistant", TooltipText = "AI Assistant" },
            new ToolbarItemModel() { Name = "Rephrase", TooltipText = "Rephrase" },
            new ToolbarItemModel() { Command = ToolbarCommand.Bold },
            new ToolbarItemModel() { Command = ToolbarCommand.Italic },
            new ToolbarItemModel() { Command = ToolbarCommand.Underline },
            new ToolbarItemModel() { Command = ToolbarCommand.Separator },
            new ToolbarItemModel() { Command = ToolbarCommand.FontName },
            new ToolbarItemModel() { Command = ToolbarCommand.FontSize },
            new ToolbarItemModel() { Command = ToolbarCommand.FontColor },
            new ToolbarItemModel() { Command = ToolbarCommand.Separator },
            new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor },
            new ToolbarItemModel() { Command = ToolbarCommand.Formats },
            new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
            new ToolbarItemModel() { Command = ToolbarCommand.Separator },
            new ToolbarItemModel() { Command = ToolbarCommand.NumberFormatList },
            new ToolbarItemModel() { Command = ToolbarCommand.BulletFormatList },
            new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
            new ToolbarItemModel() { Command = ToolbarCommand.Image },
            new ToolbarItemModel() { Command = ToolbarCommand.Separator },
            new ToolbarItemModel() { Command = ToolbarCommand.CreateTable },
            new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
            new ToolbarItemModel() { Command = ToolbarCommand.Undo },
            new ToolbarItemModel() { Command = ToolbarCommand.Redo },
        };
    }
}
<script>
    function copyToClipboard(text) {
        const tempElement = document.createElement('div');
        tempElement.innerHTML = text;
        document.body.appendChild(tempElement);

        // Select the content of the temporary element
        const range = document.createRange();
        range.selectNodeContents(tempElement);
        const selection = window.getSelection();
        selection.removeAllRanges();
        selection.addRange(range);

        // Execute the copy command
        try {
            const successful = document.execCommand('copy');
            if (successful) {
                console.log('HTML copied to clipboard!');
            } else {
                console.log('Failed to copy HTML.');
            }
        } catch (err) {
            console.error('Error copying HTML to clipboard: ', err);
        }

        // Clean up by removing the temporary element
        document.body.removeChild(tempElement);
        selection.removeAllRanges();
    }
</script>

```

## Error Handling and Troubleshooting

If the AI service fails to return a valid response, the Rich Text Editor will display an error message ("Oops! Please try again!"). Common issues include:

- **Invalid API Key or Endpoint**: Verify that the `openAIApiKey`, `azureOpenAIKey`, or Ollama `Endpoint` is correct and the service is accessible.
- **Model Unavailable**: Ensure the specified `openAIModel`, `azureOpenAIModel`, or `ModelName` is deployed and supported.
- **Network Issues**: Check connectivity to the AI service endpoint, especially for self-hosted Ollama instances.
- **Large Prompts**: Processing large text inputs may cause timeouts. Consider reducing the prompt size or optimizing the request for efficiency.

## Performance Considerations

When handling large text content, ensure the Ollama server has sufficient resources (CPU/GPU) to process requests efficiently. For long-form content or batch operations, consider splitting the input into smaller segments to avoid performance bottlenecks. Test the application with your specific use case to determine optimal performance.

## Sample Code

A complete working example is available in the [Syncfusion Blazor AI Samples GitHub repository](https://github.com/syncfusion/smart-ai-samples).

![Rich Text Editor AI Assistant - Output](../../ai/images/richtexteditor-ai-assistant.gif)