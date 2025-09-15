---
layout: post
title: Gemini Integration with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about gemini integration with Blazor AI AssistView component in Blazor WebAssembly Application.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Integration of Gemini AI With Blazor AI AssistView Component

The Syncfusion  AI AssistView supports integration with [Gemini](Gemini API quickstart  |  Google AI for Developers), enabling advanced conversational AI features in your applications.

## Getting Started with the AI AssistView Component

Before integrating Gemini AI, ensure that the Syncfusion AI AssistView is correctly rendered in your application:

[ Blazor Getting Started Guide](../getting-started)

## Prerequisites

* Google account to generate API key on accessing `Gemini AI`
* Syncfusion AI AssistView for Blazor `Syncfusion.Blazor.InteractiveChat` installed in your project.  

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor InteractiveChat and Themes NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.InteractiveChat](https://www.nuget.org/packages/Syncfusion.Blazor.InteractiveChat) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.InteractiveChat -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Generate API Key

1. Go to [Google AI Studio](https://aistudio.google.com/app/apikey) and sign in with your Google account. If you don’t have one, create a new account.

2. Once logged in, click on `Get API Key` from the left-hand menu or the top-right corner of the dashboard.

3. Click the `Create API Key` button. You’ll be prompted to either select an existing Google Cloud project or create a new one. Choose the appropriate option and proceed. 

4. After selecting or creating a project, your API key will be generated and displayed. Copy the key and store it securely, as it will only be shown once.

> `Security Note`: Never commit the API key to version control. Use environment variables or a secret manager for production.

##  Integration Gemini AI with AI AssistView

> Add your generated `API Key` at the line 

```bash

const string GeminiApiKey = 'Place your API key here'; 

```

{% tabs %}
{% highlight razor %}

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView ID="aiAssistView" PromptSuggestions="@promptSuggestions" PromptRequested="@OnPromptRequest">
        <AssistViews>
            <AssistView>
                <BannerTemplate>
                    <div class="banner-content">
                        <div class="e-icons e-assistview-icon"></div>
                        <h3>AI Assistance</h3>
                        <i>To get started, provide input or choose a suggestion.</i>
                    </div>
                </BannerTemplate>
            </AssistView>
        </AssistViews>
    </SfAIAssistView>
</div>

@code {
    private List<string> promptSuggestions = new List<string>
    {
        "What are the best tools for organizing my tasks?",
        "How can I maintain work-life balance effectively?"
    };
    private readonly string geminiApiKey = ""; // Replace with your Gemini API key
    private readonly string geminiApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent";

    [Inject]
    private HttpClient Http { get; set; }
    private async Task OnPromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        try
        {
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = args.Prompt }
                        }
                    }
                }
            };

            // Make API call to Google Generative AI
            var request = new HttpRequestMessage(HttpMethod.Post, $"{geminiApiUrl}?key={geminiApiKey}");
            request.Content = JsonContent.Create(requestBody);
            var response = await Http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Parse the response
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(jsonResponse);
            var responseText = jsonDoc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            // Add the response to the AIAssistView
            await Task.Delay(1000); // Simulate delay as in original code
            args.Response = responseText;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching Gemini response: {ex.Message}");
            await Task.Delay(1000);
            args.Response = "⚠️ Something went wrong while connecting to the AI service. Please check your API key or try again later.";
        }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor AI AssistView Gemini Integration](images/gemini-integration.png)