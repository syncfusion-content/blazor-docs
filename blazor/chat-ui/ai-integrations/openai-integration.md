---
layout: post
title:  Open AI Integration with Blazor Chat UI Component | Syncfusion
description: Checkout and learn about Open AI integration with Blazor Chat UI component in Blazor WebAssembly Application.
platform: Blazor
control: Chat UI
documentation: ug
---

# Integration of Open AI With Blazor Chat UI component

The Syncfusion Chat UI supports integration with [OpenAI](https://platform.openai.com/docs/overview), enabling advanced conversational AI features in your applications.

## Prerequisites

* OpenAI account to generate an API key for accessing the `OpenAI` API
* Syncfusion Chat UI for Blazor `Syncfusion.Blazor.InteractiveChat` installed in your project. 

## Getting Started with the Chat UI Component

Before integrating Open AI, ensure that the Syncfusion Chat UI is correctly rendered in your application:

[ Blazor Getting Started Guide](../getting-started)

## Install Dependencies

Install the Syncfusion Blazor package in the application.

```bash

Install-Package Syncfusion.Blazor.InteractiveChat

```

Install the Open AI AI package in the application.

```bash

Install-Package OpenAI

```

## Generate API Key

1. Go to [Open AI](https://platform.openai.com/docs/overview) and sign in with your Google account. If you don’t have one, create a new account. 

2. Once logged in, click on your profile icon in the top-right corner and select `API Keys` from the dropdown menu.  

3. Click the `+ Create new secret key` button. You’ll be prompted to name the key (optional). Confirm to generate the key. 

4. Your API key will be displayed once. Copy it and store it securely, as it won’t be shown again.

> `Security Note`: Never commit the API key to version control. Use environment variables or a secret manager for production.

##  Integration Open AI with Chat UI

> Add your generated `API Key` at the line 

```bash

const string openaiApiKey  = 'Place your API key here';

```

{% tabs %}
{% highlight razor %}

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfChatUI ID="chatUI" User="currentUser" HeaderText="Chat with OpenAI" HeaderIconCss="e-icons e-ai-chat" Messages="@Messages" MessageSend="OnMessageSend" TypingUsers="@typingUsers">
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
    private UserModel aiUser = new() { ID = "ai", User = "Open AI" };
    private List<ChatMessage> Messages { get; set; } = new();
    private List<UserModel> typingUsers = new();
    private string openaiApiKey = "";

    private async Task OnMessageSend(ChatMessageSendEventArgs args)
    {
        // Indicate AI is typing
        typingUsers = new List<UserModel> { aiUser };
        await Task.Delay(500); // Simulate typing delay

        try
        {
            var openAiClient = new OpenAIClient(openaiApiKey);
            var chatClient = openAiClient.GetChatClient("gpt-4o-mini");

            OpenAI.Chat.ChatCompletion completion = await chatClient.CompleteChatAsync(args.Message.Text);
            string responseText = completion.Content[0].Text;
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UsePipeTables()
                .UseTaskLists()
                .Build();
            // Add AI response to messages
            Messages.Add(new ChatMessage
            {
                Text = Markdown.ToHtml(responseText, pipeline),
                Author = aiUser
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching OpenAI response: {ex.Message}");
            Messages.Add(new ChatMessage
            {
                Text = "Error generating response. Please try again.",
                Author = aiUser
            });
            StateHasChanged();
        }
        finally
        {
            typingUsers.Clear();
            StateHasChanged();
        }
    }

    private async Task ToolbarItemClicked()
    {
        Messages.Clear();
        StateHasChanged();
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor Chat UI Open AI Integration](./images/openai-integration.png)