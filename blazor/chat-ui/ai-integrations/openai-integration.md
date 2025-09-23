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

- OpenAI account and an API key to access the OpenAI API

- Syncfusion AI AssistView for Blazor `Syncfusion.Blazor.InteractiveChat` installed in the project 

## Getting Started with the Chat UI Component

Before integrating OpenAI, ensure the Syncfusion AI AssistView component renders correctly in the application:

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

1. Go to [Open AI](https://platform.openai.com/docs/overview) and sign in. Create an account if one does not exist. 

2. Once signed in, open the profile menu and select API Keys.  

3. Select + `Create new secret key`, optionally provide a name, and confirm to generate the key. 

4. Copy the key and store it securely; it is shown only once.

> `Security Note`: Never commit the API key to version control. Use environment variables or a secret manager for production.

##  Integration Open AI with Chat UI

- Add the generated API key to the variable used in the example below

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