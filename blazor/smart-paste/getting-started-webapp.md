---
layout: post
title: Get Started with Blazor Smart Paste Button | Syncfusion
description: Learn how to integrate the Syncfusion Blazor Smart Paste Button in a Blazor Web App with step-by-step instructions.
platform: Blazor
control: Smart Paste Button
documentation: ug
---

# Getting Started with Smart Paste Button

This section explains how to integrate the [Blazor Smart Paste Button](https://www.syncfusion.com/blazor-components/blazor-smartpaste-button) component in a Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) or Visual Studio Code. The Smart Paste Button leverages AI to intelligently populate form fields from copied text, streamlining user input workflows.

To get started quickly with the Blazor Smart Paste Button component, watch this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=Q97iTZcZHB0" %}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

- .NET SDK 8.0 or later
- Visual Studio 2022 (version 17.0 or later)
- OpenAI or Azure OpenAI account
- [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

N> Syncfusion Blazor Smart Components support both OpenAI and Azure OpenAI and are compatible with Blazor Server Interactivity mode.

## Create a New Blazor Web App in Visual Studio

Create a **Blazor Web App** using Visual Studio 2022 with [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). Configure the app with the Server interactive render mode.

## Install Syncfusion Blazor SmartComponents and Themes NuGet Packages

To add the **Blazor Smart Paste Button** component, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for, and install the following packages:
- [Syncfusion.Blazor.SmartComponents](https://www.nuget.org/packages?q=Syncfusion.Blazor.SmartComponents)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

Alternatively, use the Package Manager Console:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SmartComponents -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) for a complete list of available packages and component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

- .NET SDK 8.0 or later
- Visual Studio Code (version 1.60 or later)
- OpenAI or Azure OpenAI account
- [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

N> Syncfusion Blazor Smart Components support both OpenAI and Azure OpenAI and are compatible with Blazor Server Interactivity mode.

## Create a New Blazor Web App in Visual Studio Code

Create a **Blazor Web App** using Visual Studio Code with [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). Configure the app with the Server interactive render mode using the following commands:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App Server" %}

dotnet new blazor -o BlazorWebApp -int Server
cd BlazorWebApp
dotnet restore

{% endhighlight %}
{% endtabs %}

N> For details on creating a Blazor Web App with various interactive render modes, refer to [Blazor Web App Render Modes](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes).

## Install Syncfusion Blazor SmartComponents and Themes NuGet Packages

1. Open the integrated terminal in Visual Studio Code (<kbd>Ctrl</kbd>+<kbd>`</kbd>).
2. Ensure you are in the project root directory where the `.csproj` file is located.
3. Run the following commands to install the required NuGet packages for the Server render mode:

{% tabs %}
{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.SmartComponents -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) for a complete list of available packages and component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion Blazor Service

For Server interactive render mode, open the **~/Components/_Imports.razor** file and add the following namespaces:

{% tabs %}
{% highlight razor tabtitle="~/Components/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SmartComponents

{% endhighlight %}
{% endtabs %}

Register the Syncfusion Blazor service in the **~/Program.cs** file:

{% tabs %}
{% highlight C# tabtitle="Blazor Web App Server" hl_lines="3 10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Configure AI Service

The Smart Paste Button requires an AI service (OpenAI, Azure OpenAI, or Ollama) to analyze and map copied text to form fields. Follow the instructions below to configure an AI model in your application.

### Install AI Service NuGet Packages

Install the following NuGet packages based on your chosen AI provider:

{% tabs %}
{% highlight c# tabtitle="Package Manager" %}

Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI
@* For Azure OpenAI only *@
Install-Package Azure.AI.OpenAI
@* For Ollama only *@
Install-Package OllamaSharp

{% endhighlight %}
{% endtabs %}

### OpenAI Configuration

For OpenAI, obtain an API key from [OpenAI](https://help.openai.com/en/articles/4936850-where-do-i-find-my-openai-api-key) and specify the desired model (e.g., `gpt-3.5-turbo`, `gpt-4`). Store the API key securely in a configuration file or environment variable.

Add the following to the **~/Program.cs** file:

{% tabs %}
{% highlight C# tabtitle="Blazor Web App Server" hl_lines="7 8 9 11 12 13" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;
using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

string openAIApiKey = "API-KEY";
string openAIModel = "OPENAI_MODEL";
OpenAIClient openAIClient = new OpenAIClient(openAIApiKey);
IChatClient openAIChatClient = openAIClient.GetChatClient(openAIModel).AsIChatClient();
builder.Services.AddChatClient(openAIChatClient);

builder.Services.AddSyncfusionSmartComponents()
    .InjectOpenAIInference();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

### Azure OpenAI Configuration

For Azure OpenAI, deploy a resource and model as described in [Azure OpenAI documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource). Obtain the API key, endpoint, and model name from your Azure portal.

Add the following to the **~/Program.cs** file:

{% tabs %}
{% highlight C# tabtitle="Blazor Web App Server" hl_lines="7 8 9 11 12 13" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;
using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using Azure.AI.OpenAI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
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

builder.Services.AddSyncfusionSmartComponents()
    .InjectOpenAIInference();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

N> For versions 28.2.33 to 30.2.6, the Azure.AI.OpenAI package is not included in the SmartComponents dependency. Install the [Azure.AI.OpenAI](https://www.nuget.org/packages/Azure.AI.OpenAI) package separately. Refer to [Syncfusion version history](https://blazor.syncfusion.com/documentation/release-notes) for the latest dependency information.

### Ollama Configuration

To use Ollama for self-hosted models:

1. Download and install Ollama from [Ollama's official website](https://ollama.com).
2. Install a model from the [Ollama Library](https://ollama.com/library) (e.g., `llama2:13b`, `mistral:7b`).
3. Configure the endpoint URL (e.g., `http://localhost:11434`) and model name.

Add the following to the **~/Program.cs** file:

{% tabs %}
{% highlight C# tabtitle="Blazor Web App" hl_lines="7 8 9 11 12 13" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;
using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

string ModelName = "MODEL_NAME";
IChatClient chatClient = new OllamaApiClient("http://localhost:11434", ModelName);
builder.Services.AddChatClient(chatClient);

builder.Services.AddSyncfusionSmartComponents()
    .InjectOpenAIInference();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Add Stylesheet and Script Resources

Include the theme stylesheet and script from NuGet via [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Add the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file, as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/tailwind.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

> **Note**: Explore the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) to reference themes in your Blazor application. Refer to the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic for different approaches to adding script references.

## Add Syncfusion® Blazor Smart Paste Button Component

Add the Syncfusion® **Blazor Smart Paste Button** component with form components in the **~Pages/Index.razor** file. This example uses the [Syncfusion® Blazor DataForm](https://blazor.syncfusion.com/documentation/data-form/getting-started-with-web-app) component to manage form input fields. Install the [Syncfusion.Blazor.DataForm](https://www.nuget.org/packages/Syncfusion.Blazor.DataForm) package.

{% tabs %}
{% highlight razor tabtitle="~/Index.razor" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Syncfusion.Blazor.SmartComponents

<SfDataForm ID="MyForm"
            Model="@EventRegistrationModel">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormItem Field="@nameof(EventRegistration.Name)" ID="firstname"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Email)" ID="email"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Phone)" ID="phonenumber"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Address)" ID="address"></FormItem>
    </FormItems>
    <FormButtons>
        <SfSmartPasteButton IsPrimary="true" Content="Smart Paste" IconCss="e-icons e-paste">
        </SfSmartPasteButton>
    </FormButtons>
</SfDataForm>

<br>
<h4 style="text-align:center;">Sample content</h4>
<div>
    Hi, my name is Jane Smith. You can reach me at example@domain.com or call me at +1-555-987-6543. I live at 789 Pine Avenue, Suite 12, Los Angeles, CA 90001.
</div>

@code {
    private EventRegistration EventRegistrationModel = new EventRegistration();

    public class EventRegistration
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [Display(Name = "Email ID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your mobile number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application, rendering the Syncfusion® Blazor Smart Paste Button component in your default web browser.
2. Copy the `Sample Content` and click the `Smart Paste` button to see the form fields automatically populated.

![Syncfusion Smart Paste Button filling a form in a Blazor Web App](images/smart-paste.gif)

N> [View Sample in GitHub](https://github.com/syncfusion/smart-ai-samples).

## Performance Considerations

For optimal performance with the Smart Paste Button:
- Use lightweight AI models (e.g., `gpt-3.5-turbo` or `mistral:7b`) for faster processing.
- Limit form complexity to reduce AI parsing time, especially for large datasets.
- Cache AI model responses where possible to minimize repeated API calls.

## Troubleshooting Common Issues

- **AI Service Configuration Errors**: Verify the API key, endpoint, and model name in `Program.cs`. Check for typos or incorrect values.
- **Network Failures**: Ensure a stable internet connection for OpenAI or Azure OpenAI. For Ollama, confirm the local server is running at the specified endpoint (e.g., `http://localhost:11434`).
- **Form Not Populating**: Confirm that the copied text matches the form field structure and that the AI model is correctly configured.
