---
layout: post
title: Gemini Integration with Blazor Chat UI Component | Syncfusion
description: Checkout and learn about gemini integration with Blazor Chat UI component in Blazor WebAssembly Application.
platform: Blazor
control: Chat UI
documentation: ug
---

# Integration of Gemini AI With Blazor Chat UI component

The Syncfusion  Chat UI supports integration with [Gemini](https://ai.google.dev/gemini-api/docs/quickstart), enabling advanced conversational AI features in your applications.

## Prerequisites

* Google account to generate API key on accessing `Gemini AI`
* Syncfusion Chat UI for Blazor `Syncfusion.Blazor.InteractiveChat` installed in your project. 

## Getting Started with the Chat UI Component

Before integrating Gemini AI, ensure that the Syncfusion Chat UI is correctly rendered in your application:

[ Blazor Getting Started Guide](../getting-started) 

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

1. Go to [Google AI Studio](https://aistudio.google.com/app/apikey) and sign in with your Google account. If you don’t have one, create a new account.

2. Once logged in, click on `Get API Key` from the left-hand menu or the top-right corner of the dashboard.

3. Click the `Create API Key` button. You’ll be prompted to either select an existing Google Cloud project or create a new one. Choose the appropriate option and proceed. 

4. After selecting or creating a project, your API key will be generated and displayed. Copy the key and store it securely, as it will only be shown once.

> `Security Note`: Never commit the API key to version control. Use environment variables or a secret manager for production.

##  Integration Gemini AI with Chat UI

> Add your generated `API Key` at the line 

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

![Blazor Chat UI Gemini Integration](images/gemini-integration.png)