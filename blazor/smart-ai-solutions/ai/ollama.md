---
layout: post
title: Ollama Integration with Syncfusion Blazor AI
description: Learn how to configure and use Syncfusion Blazor AI with Ollama for AI-driven features like data restructuring in Blazor applications.
platform: Blazor
control: AI Integration
documentation: ug
---

# Ollama Integration with Syncfusion Blazor AI

The [Syncfusion Blazor AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) library enables seamless integration with [Ollama](https://ollama.com/) to add AI-driven features to Blazor applications using locally hosted AI models. These features include data restructuring (organizing data into hierarchical formats), content analysis (evaluating text or data patterns), and hierarchical organization (assigning parent-child relationships). This guide explains how to configure the library and use it with Syncfusion Blazor components, such as the TreeGrid, to implement intelligent functionality without external API dependencies.

## Prerequisites

To integrate Ollama with a Blazor application, ensure the following:
- The following NuGet packages are installed:
{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}
Install-Package Microsoft.Extensions.AI
Install-Package OllamaSharp

{% endhighlight %}
{% endtabs %}
- [Ollama](https://ollama.com/docs) is installed on your local system (no virtual machines required).
- An Ollama model (e.g., `llama2`) is downloaded using the command:
  ```bash
  ollama run llama2
  ```
- The [Syncfusion Blazor system requirements](https://blazor.syncfusion.com/documentation/system-requirements) are met.
- Sufficient hardware resources (e.g., CPU/GPU, memory) are available for local model performance.

## Configuration Steps

### Register AI Services in Program.cs

To configure Ollama in a Blazor application, update the `Program.cs` file as follows:

```csharp
// Add required namespaces
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

// Register Ollama client with a specific model
string modelName = "llama2"; // Specify a downloaded Ollama model
IChatClient chatClient = new OllamaApiClient("http://localhost:11434", modelName);
builder.Services.AddChatClient(chatClient);

// Register the inference service
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();
```

## Smart Data Restructuring with Ollama and TreeGrid

This example demonstrates using the Syncfusion Blazor AI library with Ollama to perform intelligent data restructuring in a Syncfusion Blazor TreeGrid component. The application organizes hierarchical data by leveraging Ollama to assign appropriate `ParentId` values based on `CategoryName` relationships, updating the TreeGrid to reflect the corrected hierarchical structure.

### Setup Prerequisites
- Install the following NuGet packages:
{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.TreeGrid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}
Install-Package Microsoft.Extensions.AI
Install-Package OllamaSharp

{% endhighlight %}
{% endtabs %}
- Ensure the Blazor application meets the [Syncfusion Blazor system requirements](https://blazor.syncfusion.com/documentation/system-requirements).
- Add the following to `App.razor` for Syncfusion themes and scripts:
  
```html
<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/tailwind.css" rel="stylesheet" />
</head>

<body>
    ...
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

### Register Syncfusion Blazor Service

Register the Syncfusion Blazor service in the `~/Program.cs` file based on the interactive render mode.

**For WebAssembly or Auto Render Mode**:
Register the service in both `~/Program.cs` files (server and client).

{% tabs %}
{% highlight c# tabtitle="Server (~/Program.cs)" hl_lines="3 11" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
...

{% endhighlight %}
{% highlight c# tabtitle="Client (~/Program.cs)" hl_lines="2 5" %}

...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

**For Server Render Mode**:
Register the service in the single `~/Program.cs` file.

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="2 9" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
...

{% endhighlight %}
{% endtabs %}

### Razor Component (Home.razor)

```csharp
@page "/"

@inject IChatInferenceService OllamaAIService
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.AI
@using System.Text.Json;

<div style="padding-bottom: 10px;">
    <span>@message</span>
</div>
<div style="width: 100%; position: relative">
    <SfTreeGrid @ref="TreeGrid" DataSource="@TreeGridData" IdMapping="CategoryId" ParentIdMapping="ParentId" TreeColumnIndex="1">
        <TreeGridEditSettings AllowEditing="true" />
        <TreeGridColumns>
            <TreeGridColumn Field="CategoryId" HeaderText="Category ID" IsPrimaryKey="true" Width="60" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field="CategoryName" HeaderText="Category Name" Width="100"></TreeGridColumn>
            <TreeGridColumn Field="Status" HeaderText="Status" Width="70"></TreeGridColumn>
            <TreeGridColumn Field="OrderDate" HeaderText="Last Order Date" Format="d" Width="90"></TreeGridColumn>
        </TreeGridColumns>
        <SfToolbar ID="TreeGrid_AISample_Toolbar">
            <ToolbarItems>
                <ToolbarItem>
                    <Template>
                        <SfButton IsPrimary ID="openAI" @onclick="OpenAIHandler">Smart Data Restructure</SfButton>
                    </Template>
                </ToolbarItem>
            </ToolbarItems>
        </SfToolbar>
    </SfTreeGrid>
</div>
```

### Code-Behind (Home.razor.cs)

```csharp
using Microsoft.Extensions.AI;
using Syncfusion.Blazor.AI;
using Syncfusion.Blazor.TreeGrid;
using System.Text.Json;

namespace OllamaExample.Components.Pages
{
    public partial class Home
    {
        public SfTreeGrid<TreeData.BusinessObject> TreeGrid;
        private string AIPrompt = string.Empty;
        private string message = string.Empty;
        public List<TreeData.BusinessObject> TreeGridData { get; set; }
        protected override void OnInitialized()
        {
            this.TreeGridData = TreeData.GetAdaptiveStructureData().ToList();
        }

        private async Task OpenAIHandler()
        {
            await TreeGrid.ShowSpinnerAsync();
            List<TreeData.BusinessObject> sortedCollection = new List<TreeData.BusinessObject>();
            var AIPrompt = GeneratePrompt(TreeGridData);
            ChatParameters chatParameters = new ChatParameters
            {
                Messages = new List<ChatMessage>
                {
                    new ChatMessage(ChatRole.User, AIPrompt)
                }
            };
            var result = await OllamaAIService.GenerateResponseAsync(chatParameters);
            result = result.Replace("```json", "").Replace("```", "").Trim();

            string response = JsonDocument.Parse(result).RootElement.GetProperty("TreeGridData").ToString();
            if (response is not null)
            {
                sortedCollection = JsonSerializer.Deserialize<List<TreeData.BusinessObject>>(response);
            }
            if (sortedCollection is not null && sortedCollection.Count > 0)
            {
                TreeGridData = sortedCollection.Cast<TreeData.BusinessObject>().ToList();
            }
            else
            {
                message = "Oops.! Please try Again !";
            }
            await TreeGrid.HideSpinnerAsync();
            await Task.CompletedTask;
        }

        private string GeneratePrompt(List<TreeData.BusinessObject> TreeGridData)
        {
            Dictionary<string, IEnumerable<object>> treeData = new Dictionary<string, IEnumerable<object>>();
            treeData.Add("TreeGridData", TreeGridData);
            var jsonData = JsonSerializer.Serialize(treeData);
            return @"I want you to act as a TreeGrid Data Organizer.
            Your task is to organize a dataset based on a hierarchical structure using 'CategoryId' and 'ParentId'.
            Each item in the dataset has a 'CategoryName' representing categories, and some categories have a null 'ParentId', indicating they are top-level categories. 
            Your role will be to meticulously scan the entire dataset to identify related items based on their 'CategoryName' values and nest them under the appropriate top-level categories by updating their 'ParentId' to match the 'CategoryId' of the corresponding top-level category.
            For example, if a category like 'Furniture' exists, you should scan the dataset for items such as 'Chair' and 'Table' and update their 'ParentId' to the 'CategoryId' of 'Furniture'.
            The output should be the newly prepared TreeGridData with correctly assigned 'ParentId' values. Please ensure that all subcategories are correctly nested under their respective top-level categories.
            Return the newly prepared TreeGridData alone and don't share any other information with the response: Here is the dataset " + jsonData + "/n Note: Return response must be in json string and with no other explanation. ";
        }
        public class TreeData
        {
            public class BusinessObject
            {
                public int CategoryId { get; set; }
                public string CategoryName { get; set; }
                public string Status { get; set; }
                public DateTime OrderDate { get; set; }
                public int? ParentId { get; set; }
            }

            public static List<BusinessObject> GetAdaptiveStructureData()
            {
                List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
                BusinessObjectCollection.Add(new BusinessObject() { CategoryId = 1, CategoryName = "Electronics", Status = "Available", OrderDate = new DateTime(2021, 7, 12), ParentId = null });
                BusinessObjectCollection.Add(new BusinessObject() { CategoryId = 2, CategoryName = "Cell phone", Status = "out of Stock", OrderDate = new DateTime(2021, 6, 17), ParentId = 1 });
                BusinessObjectCollection.Add(new BusinessObject() { CategoryId = 3, CategoryName = "Computer", Status = "Available", OrderDate = new DateTime(2021, 7, 12), ParentId = 7 });
                BusinessObjectCollection.Add(new BusinessObject() { CategoryId = 4, CategoryName = "Cloth", Status = "Available", OrderDate = new DateTime(2021, 10, 5), ParentId = null });
                BusinessObjectCollection.Add(new BusinessObject() { CategoryId = 5, CategoryName = "Silk", Status = "Out of Stock", OrderDate = new DateTime(2021, 9, 2), ParentId = 7 });
                BusinessObjectCollection.Add(new BusinessObject() { CategoryId = 6, CategoryName = "Chair", Status = "Available", OrderDate = new DateTime(2021, 3, 3), ParentId = 1 });
                BusinessObjectCollection.Add(new BusinessObject() { CategoryId = 7, CategoryName = "Furniture", Status = "Available", OrderDate = new DateTime(2021, 3, 5), ParentId = null });
                BusinessObjectCollection.Add(new BusinessObject() { CategoryId = 8, CategoryName = "Bed", Status = "Available", OrderDate = new DateTime(2021, 3, 5), ParentId = 7 });
                BusinessObjectCollection.Add(new BusinessObject() { CategoryId = 9, CategoryName = "Fabrics", Status = "Available", OrderDate = new DateTime(2021, 10, 5), ParentId = 4 });
                return BusinessObjectCollection;
            }
        }
    }
}
```

![Smart Data Restructuring Output](images/adaptive-datastructuring.gif)

## How It Works

This example illustrates how the Syncfusion Blazor AI library integrates with Ollama to reorganize hierarchical data in a TreeGrid:

1. **Setup**: Configure the Ollama service in `Program.cs` with a local endpoint and a downloaded model (e.g., `llama2`).
2. **Component Integration**: Inject `IChatInferenceService` to process TreeGrid data for restructuring.
3. **Prompt Engineering**: Craft a detailed prompt to instruct Ollama to analyze `CategoryName` relationships and assign appropriate `ParentId` values.
4. **Response Processing**: Parse the JSON response from Ollama and update the TreeGrid to reflect the corrected hierarchy.

### Key Components
- **IChatInferenceService**: Injected service for interacting with Ollama models.
- **ChatParameters**: Configures the AI request with prompts and user messages.
- **GenerateResponseAsync**: Sends asynchronous requests to Ollama and retrieves responses.
- **UI Components**: Syncfusion TreeGrid and Button components integrate with the AI service for dynamic updates.

## Error Handling
- **Model Not Found**: Ensure the specified Ollama model (e.g., `llama2`) is downloaded and available.
- **JSON Parsing Errors**: Handle invalid JSON responses by logging errors or displaying user-friendly messages, as shown in the `OpenAIHandler` method.
- **Resource Limitations**: Local models require sufficient hardware (e.g., 8GB RAM for `llama2`). Check [Ollama documentation](https://ollama.com/docs) for model-specific requirements.

## See Also
- [Syncfusion Blazor TreeGrid Documentation](https://blazor.syncfusion.com/documentation/treegrid/getting-started-webapp)