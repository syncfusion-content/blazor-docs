---
layout: post
title: Gemini Integration with Blazor Chat UI Component | Syncfusion
description: Checkout and learn about gemini integration with Blazor Chat UI component in Blazor WebAssembly Application.
platform: Blazor
control: Chat UI
documentation: ug
---

# Integration of Gemini AI With Blazor Chat UI component   

The Syncfusion Chat UI supports integration with [Gemini](https://ai.google.dev/gemini-api/docs/quickstart), enabling advanced conversational AI features in applications.

## Prerequisites

* Google account to generate an API key for accessing Gemini AI
* Syncfusion AI AssistView for Blazor package (Syncfusion.Blazor.InteractiveChat) installed in the project
* Markdig package available in the project for Markdown-to-HTML conversion (required by the sample code)

## Getting Started with the Chat UI Component

Before integrating Gemini AI, ensure that the Syncfusion Chat UI renders correctly in the application and that prerequisites are met:

[Blazor Getting Started Guide](../getting-started) 

## Install Dependencies

Install the Syncfusion Blazor package in the application.

```bash

Install-Package Syncfusion.Blazor.InteractiveChat

```

Install the Gemini AI package in the application.

```bash

Install-Package Mscc.GenerativeAI

```

## Generate API Key

1. Go to [Google AI Studio](https://aistudio.google.com/app/apikey) and sign in with a Google account. Create a new account if needed.

2. Select Get API Key from the left menu or the top-right of the dashboard.

3. Choose `Create API Key`. Select an existing Google Cloud project or create a new one, then proceed.

4. After creating or selecting a project, an API key is generated and displayed. Copy the key and store it securely, as it may be shown only once.

> `Security note`: Do not commit API keys to version control. Use environment variables, a secret manager, or a server-side proxy in production.

##  Integration Gemini AI with Chat UI

* Add the generated API key in the following line.

```bash

const string GeminiApiKey = 'Place your API key here'; 

```

{% tabs %}
{% highlight razor %}

<div style="height: 400px; width: 400px;">
    <SfChatUI ID="chatUI" User="currentUser" HeaderText="Chat UI" HeaderIconCss="e-icons e-ai-chat" Messages="@Messages" MessageSend="OnMessageSend" TypingUsers="@typingUsers">
        <ChildContent>
            <HeaderToolbar ItemClicked="@ToolbarItemClicked">
                <HeaderToolbarItem Type="ItemType.Spacer"></HeaderToolbarItem>
                <HeaderToolbarItem IconCss="e-icons e-refresh" Tooltip="Clear Chat" />
            </HeaderToolbar>
        </ChildContent>
        <EmptyChatTemplate>
            <div class="emptychat-content">
                <h3><span class="e-icons e-comment-show"></span></h3>
                <div class="emptyChatText" style="font-size: 16px;">Just a second, we're preparing your chat...</div>
            </div>
        </EmptyChatTemplate>
    </SfChatUI>
</div>

@code {
    private UserModel currentUser = new() { ID = "user1", User = "You" };
    private UserModel aiUser = new() { ID = "ai", User = "Gemini" };
    private List<Syncfusion.Blazor.InteractiveChat.ChatMessage> Messages { get; set; } = new();
    private List<UserModel> typingUsers = new();

    private async Task OnMessageSend(ChatMessageSendEventArgs args)
    {
        typingUsers = new List<UserModel> { aiUser };
        StateHasChanged();

        try
        {
            await Task.Delay(500);
            var userPrompt = args.Message.Text ?? "hi";
            const string GeminiApiKey = "";
            var gemini = new GoogleAI(apiKey: GeminiApiKey);
            var model = gemini.GenerativeModel(model: "gemini-1.5-flash");
            var response = await model.GenerateContent(userPrompt);
            var responseText = response.Text;
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UsePipeTables()
                .UseTaskLists()
                .Build();
            Messages.Add(new Syncfusion.Blazor.InteractiveChat.ChatMessage { Text = Markdown.ToHtml(responseText, pipeline), Author = aiUser });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching Gemini response: {ex.Message}");
            Messages.Add(new Syncfusion.Blazor.InteractiveChat.ChatMessage { Text = "Error generating response. Please try again.", Author = aiUser });
            StateHasChanged();
        }
        finally
        {
            typingUsers.Clear();
            StateHasChanged();
        }
    }

    private void ToolbarItemClicked(ChatToolbarItemClickedEventArgs args)
    {
        Messages.Clear();
        StateHasChanged();
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor Chat UI Gemini Integration](./images/gemini-integration.png)