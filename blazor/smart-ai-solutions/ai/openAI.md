---
layout: post
title: OpenAI Integration with Syncfusion Blazor AI
description: Learn how to configure and use the Syncfusion Blazor AI library with OpenAI to enable AI-powered features like anomaly detection and content generation in Blazor applications.
platform: Blazor
control: AI Integration
documentation: ug
---

# OpenAI Integration with Syncfusion Blazor AI

## Introduction

The [Syncfusion Blazor AI](https://www.nuget.org/packages/Syncfusion.Blazor.AI) library enables seamless integration with [OpenAI](https://help.openai.com/en/articles/4936850-where-do-i-find-my-openai-api-key) to add AI-driven features to Blazor applications. These features include anomaly detection (identifying irregular data patterns), data analysis (processing and summarizing data), and content generation (creating text based on user input). This guide explains how to configure the library and use it with Syncfusion Blazor components, such as the Grid, to implement intelligent functionality.

## Prerequisites

To integrate OpenAI with a Blazor application, ensure the following:
- The following NuGet packages are installed:
{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}
{% endtabs %}
- An [OpenAI API key](https://help.openai.com/en/articles/4936850-where-do-i-find-my-openai-api-key) is obtained from the OpenAI platform.
- The [Syncfusion Blazor system requirements](https://blazor.syncfusion.com/documentation/system-requirements) are met.
- The API key is stored securely using environment variables or user secrets (see [Microsoft’s guide on user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)).

## Configuration Steps

### Register AI Services in Program.cs

To configure OpenAI in a Blazor application, update the `Program.cs` file as follows:

```csharp
// Add required namespaces
using Syncfusion.Blazor.AI;
using Microsoft.Extensions.AI;
using OpenAI;

// Register OpenAI credentials
string openAiApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY"); // Use secure storage
string openAiModel = "gpt-4"; // Specify a valid OpenAI model
OpenAIClient openAIClient = new OpenAIClient(openAiApiKey);
IChatClient openAiChatClient = openAIClient.GetChatClient(openAiModel).AsIChatClient();
builder.Services.AddChatClient(openAiChatClient);

// Register the inference service
builder.Services.AddSingleton<IChatInferenceService, SyncfusionAIService>();
```

## Anomaly Detection with OpenAI and Syncfusion Blazor Grid

This example demonstrates using the Syncfusion Blazor AI library with OpenAI to perform anomaly detection in a Syncfusion Blazor Grid. The grid displays machine data (MachineID, Temperature, Pressure, Voltage, MotorSpeed, ProductionRate), and OpenAI identifies rows with inconsistent production rates based on operational factors, updating the grid with anomaly descriptions and visual styling.

### Setup Prerequisites
- Install the following NuGet packages:
{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.AI -Version {{ site.releaseversion }}
Install-Package Microsoft.Extensions.AI
Install-Package Microsoft.Extensions.AI.OpenAI

{% endhighlight %}
{% endtabs %}
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

```cshtml
@page "/"

@inject IChatInferenceService OpenAIService
@using Newtonsoft.Json
@using Syncfusion.Blazor.AI
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Spinner

<SfGrid @ref=Grid TValue="MachineData" DataSource="@machineDataList" EnableHover=false EnableStickyHeader=true AllowTextWrap=true Height="auto">
    <GridTemplates>
        <ToolbarTemplate>
            <SfToolbar>
                <ToolbarEvents Clicked="ToolbarClickHandler"></ToolbarEvents>
                <ToolbarItems>
                    <ToolbarItem Id="Anomaly">
                        <Template>
                            <div>
                                <SfButton Content="Detect Anomaly Data" IsPrimary="true"></SfButton>
                            </div>
                        </Template>
                    </ToolbarItem>
                </ToolbarItems>
            </SfToolbar>
        </ToolbarTemplate>
    </GridTemplates>
    <GridEvents QueryCellInfo="CustomizeCell" TValue="MachineData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(MachineData.MachineID) IsPrimaryKey=true HeaderText="Machine ID" Width="40"></GridColumn>
        <GridColumn Field=@nameof(MachineData.Temperature) HeaderText="Temperature (C)" TextAlign="TextAlign.Right" Width="40"></GridColumn>
        <GridColumn Field=@nameof(MachineData.Pressure) HeaderText="Pressure (psi)" TextAlign="TextAlign.Right" Width="60"></GridColumn>
        <GridColumn Field=@nameof(MachineData.Voltage) HeaderText="Voltage (V)" TextAlign="TextAlign.Right" Width="60"></GridColumn>
        <GridColumn Field=@nameof(MachineData.MotorSpeed) HeaderText="Motor Speed (rpm)" TextAlign="TextAlign.Right" Width="60"></GridColumn>
        <GridColumn Field=@nameof(MachineData.ProductionRate) HeaderText="Production Rate (units/hr)" TextAlign="TextAlign.Right" Width="60"></GridColumn>
        <GridColumn Field=@nameof(MachineData.AnomalyDescription) HeaderText="Anomaly Description" Visible=@anomalyColumnVisibility Width="170"></GridColumn>
    </GridColumns>
    <SfSpinner Visible="@spinnerVisibility"></SfSpinner>
</SfGrid>

<style>
    .anomaly-cell {
        background-color: #c2410c;
        color: white !important;
    }
    .e-grid .e-rowcell.anomaly-cell:not(.e-editedbatchcell):not(.e-updatedtd) {
        color: #c2410c;
    }
    .e-tbar-btn {
        border: 1px double !important;
        border-color: gray !important;
    }
    .normal-cell {
        background-color: #15803d;
        color: white !important;
    }
</style>
```

### Code-Behind (Home.razor.cs)

```cshtml
using Microsoft.Extensions.AI;
using Newtonsoft.Json;
using Syncfusion.Blazor.AI;
using Syncfusion.Blazor.Grids;

namespace OpenAIExample.Components.Pages
{
    public partial class Home
    {
        SfGrid<MachineData> Grid { get; set; }
        private List<MachineData> machineDataList = new List<MachineData>();
        private List<MachineData> AIgeneratedData = new List<MachineData>();
        private bool anomalyColumnVisibility { get; set; }
        private bool spinnerVisibility { get; set; }

        public void CustomizeCell(QueryCellInfoEventArgs<MachineData> args)
        {
            if (AIgeneratedData != null && AIgeneratedData.Count > 0)
            {
                if (AIgeneratedData.Where(e => (!string.IsNullOrEmpty(e.AnomalyFieldName)) && (e.AnomalyFieldName.Equals(args.Column.Field, StringComparison.Ordinal) && e.MachineID.Equals(args.Data.MachineID))).Any())
                {
                    args.Cell.AddClass(new string[] { "anomaly-cell" });
                }
                else if (args.Column.Field.Equals("AnomalyDescription", StringComparison.Ordinal))
                {
                    string defaultDescription = machineDataList[0].AnomalyDescription;
                    string anomalyDescription = args.Data.AnomalyDescription;
                    if (defaultDescription.Equals(anomalyDescription, StringComparison.Ordinal))
                    {
                        args.Cell.AddClass(new string[] { "normal-cell" });
                    }
                    else
                    {
                        args.Cell.AddClass(new string[] { "anomaly-cell" });
                    }
                }
            }
        }

        public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id == "Anomaly")
            {
                DetectAnomalyData();
            }
        }

        private async void DetectAnomalyData()
        {
            spinnerVisibility = true;
            GridReport gridReport = new GridReport()
            {
                DataSource = machineDataList,
            };
            var gridReportJson = GetSerializedGridReport(gridReport);
            string userInput = ValidateAndGeneratePrompt(gridReportJson);
            ChatParameters chatParameters = new ChatParameters
            {
                Messages = new List<ChatMessage>
                {
                    new ChatMessage(ChatRole.User, userInput)
                }
            };
            var result = await OpenAIService.GenerateResponseAsync(chatParameters);
            if (result != null)
            {
                GridReport deserializeResult = new GridReport();
                try
                {
                    result = result.Replace("```json", "").Replace("```", "").Trim();
                    deserializeResult = DeserializeResult(result);
                    AIgeneratedData = deserializeResult.DataSource;
                    spinnerVisibility = false;
                    anomalyColumnVisibility = true;
                    if (AIgeneratedData != null && AIgeneratedData.Count > 0)
                    {
                        foreach (var data in AIgeneratedData)
                        {
                            await Grid.SetCellValueAsync(data.MachineID, "AnomalyDescription", data.AnomalyDescription);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static string ValidateAndGeneratePrompt(string data)
        {
            return $"Given the following datasource are bounded in the Grid table\n\n{data}.\n Return the anomaly data rows (ie. pick the ir-relevant datas mentioned in the corresponding table) present in the table mentioned above as like in the same format provided do not change the format. Example: Watch out the production rate count and the factors that is used to acheive the mentioned production rate(Temprature, Pressure, Motor Speed) If the production rate is not relevant to the concern factors mark it as anomaly Data. If it is anomaly data then due to which column data it is marked as anomaly that particular column name should be updated in the AnomalyFieldName. Also Update the AnomalyDescription stating that due to which reason it is marked as anomaly a short description. Example if the data is marked as anomaly due to the Temperature column, Since the mentioned temperature is too high than expected, it is marked as anomaly data.\n\nGenerate an output in JSON format only and Should not include any additional information or contents in response";
        }

        private string GetSerializedGridReport(GridReport report)
        {
            return JsonConvert.SerializeObject(report);
        }

        private GridReport DeserializeResult(string result)
        {
            return JsonConvert.DeserializeObject<GridReport>(result);
        }

        protected override void OnInitialized()
        {
            string description = "The factors that supporting the Production rate is relevant to the count produced, hence the row data is marked as normal data.";
            machineDataList = new List<MachineData>
            {
                new MachineData { MachineID = "M001", Temperature = 85, Pressure = 120, Voltage = 220, MotorSpeed = 1500, ProductionRate = 100, AnomalyDescription = description },
                new MachineData { MachineID = "M002", Temperature = 788, Pressure = 115, Voltage = 230, MotorSpeed = 1520, ProductionRate = 105, AnomalyDescription = description },
                new MachineData { MachineID = "M003", Temperature = 90, Pressure = 118, Voltage = 225, MotorSpeed = 1480, ProductionRate = 95, AnomalyDescription = description },
                new MachineData { MachineID = "M004", Temperature = 87, Pressure = 122, Voltage = 228, MotorSpeed = 1515, ProductionRate = 110, AnomalyDescription = description },
                new MachineData { MachineID = "M005", Temperature = 92, Pressure = 116, Voltage = 222, MotorSpeed = 21475, ProductionRate = 980, AnomalyDescription = description },
                new MachineData { MachineID = "M006", Temperature = 85, Pressure = 119, Voltage = 220, MotorSpeed = 1490, ProductionRate = 102, AnomalyDescription = description },
                new MachineData { MachineID = "M007", Temperature = 88, Pressure = 114, Voltage = 230, MotorSpeed = 1500, ProductionRate = 104, AnomalyDescription = description },
                new MachineData { MachineID = "M008", Temperature = 90, Pressure = 1120, Voltage = 225, MotorSpeed = 1470, ProductionRate = 89, AnomalyDescription = description },
                new MachineData { MachineID = "M009", Temperature = 87, Pressure = 121, Voltage = 228, MotorSpeed = 1505, ProductionRate = 108, AnomalyDescription = description },
                new MachineData { MachineID = "M010", Temperature = 92, Pressure = 117, Voltage = 222, MotorSpeed = 1480, ProductionRate = 100, AnomalyDescription = description },
            };
        }

        public class MachineData
        {
            public string MachineID { get; set; }
            public int Temperature { get; set; }
            public int Pressure { get; set; }
            public int Voltage { get; set; }
            public int MotorSpeed { get; set; }
            public int ProductionRate { get; set; }
            public string AnomalyDescription { get; set; }
            public string AnomalyFieldName { get; set; }
        }

        public class GridReport
        {
            public List<MachineData> DataSource { get; set; }
        }
    }
}
```

![Anomaly Detection Output](images/anomaly-detection.gif)

## How It Works

This example illustrates how the Syncfusion Blazor AI library integrates with OpenAI to analyze data in a Blazor Grid:

1. **Setup**: Configure the OpenAI service in `Program.cs` using a secure API key and a specified model (e.g., `gpt-4`).
2. **Component Integration**: Inject `IChatInferenceService` to process data from the Syncfusion Blazor Grid.
3. **Prompt Engineering**: Craft precise prompts to instruct OpenAI to identify anomalies based on data patterns (e.g., inconsistent ProductionRate relative to Temperature or MotorSpeed).
4. **Response Processing**: Parse OpenAI’s JSON response to update the Grid with anomaly descriptions and apply visual styling.

### Key Components
- **IChatInferenceService**: Injected service for interacting with OpenAI models.
- **ChatParameters**: Configures the AI request with prompts and user messages.
- **GenerateResponseAsync**: Sends asynchronous requests to OpenAI and retrieves responses.
- **UI Components**: Syncfusion Grid and Button components integrate with the AI service for dynamic updates.

## Error Handling
- **Invalid API Key**: Ensure the API key is valid and correctly configured in environment variables or user secrets.
- **Rate Limits**: OpenAI API usage may be limited based on your plan. Check [OpenAI’s pricing documentation](https://openai.com/pricing) for details.
- **Network Issues**: Handle connectivity errors by implementing retry logic or displaying user-friendly messages.

## See Also
- [Syncfusion Blazor AI Library Overview](https://blazor.syncfusion.com/documentation/ai-integration/overview)
- [Syncfusion Blazor Grid Documentation](https://blazor.syncfusion.com/documentation/grid/getting-started)