---
layout: post
title: Bot Framework with Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Integrate Microsoft Bot Framework with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Integrate Microsoft Bot Framework with Blazor Chat UI component

The Chat UI component integrates with a [Microsoft Bot Framework](https://learn.microsoft.com/en-us/azure/bot-service/bot-builder-basics?view=azure-bot-service-4.0) bot hosted on Azure, enabling a custom chat interface for seamless user interaction. The process involves setting up a secure backend token server, configuring Direct Line in Azure, and integrating the Chat UI in the Blazor application.

## Prerequisites

Before starting, ensure you have the following:

* [Microsoft Azure Account](https://portal.azure.com/#home): Required to create and host the bot.

* **Syncfusion Chat UI**: Package [Syncfusion Blazor package](https://www.nuget.org/packages/Syncfusion.Blazor.InteractiveChat) installed.

* **Deployed Azure Bot**: A bot should be created and published using the [Microsoft Bot Framework](https://learn.microsoft.com/en-us/azure/bot-service/bot-builder-basics?view=azure-bot-service-4.0), which is accessible via an Azure App Service. Refer to Microsoft's Bot Creation Guide.

## Set Up the Chat UI component

Follow the [Getting Started](../getting-started) guide to configure and render the Chat UI component in the application and that prerequisites are met.

## Install Dependencies

* Install backend dependencies for bot communication using NuGet:

``` bash 

dotnet add package Microsoft.Bot.Connector.DirectLine
dotnet add package Newtonsoft.Json

```

Note: While the integration uses a JavaScript-based Direct Line client for client-side handling, the .NET packages support token generation on the server side.

## Configure the Azure Bot

1. In the [Azure Portal](https://portal.azure.com/auth/login/), navigate to your bot resource.

2. Enable the direct line channel:
    * Go to Channels > Direct Line > Default-Site.
    * Copy one of the displayed secret keys.

3. Verify the messaging endpoint in the configuration section (e.g., https://your-bot-service.azurewebsites.net/api/messages).

> `Security Note`: Never expose the Direct Line secret key in frontend code. Use a backend token server to handle it securely.

## Set Up Token Server

In a Blazor Server application, create a minimal API endpoint or controller to handle direct line token generation. For simplicity, add a minimal API in `Program.cs` (or use a dedicated controller in a Pages or Areas folder).

Add the following to `Program.cs`:

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services...
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline...
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Minimal API for token generation
app.MapPost("/api/token/directline/token", async () =>
{
    var directLineSecret = builder.Configuration["DirectLineSecret"];
    if (string.IsNullOrEmpty(directLineSecret))
    {
        return Results.BadRequest("Direct Line secret is not configured.");
    }

    using var httpClient = new HttpClient();
    try
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://directline.botframework.com/v3/directline/tokens/generate");
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", directLineSecret);
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        dynamic tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
        return Results.Ok(new { token = tokenResponse.token });
    }
    catch (HttpRequestException ex)
    {
        return Results.Problem("Failed to generate Direct Line token.", ex, statusCode: 500);
    }
});

app.Run();

{% endhighlight %}
{% endtabs %}

Add the Direct Line secret to `Web.config`:

{% tabs %}
{% highlight js tabtitle=".env" %}
<appSettings>
  <add key="DirectLineSecret" value="PASTE_YOUR_DIRECT_LINE_SECRET_HERE" />
</appSettings>

{% endhighlight %}
{% endtabs %}

>`Security Note`: Store the Direct Line secret in a secure configuration, such as Azure Key Vault, for production environments.

## Configure Chat UI

Use the [MessageSend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_MessageSend) event to handle message exchanges. This event is triggered before a message is sent, allowing you to forward it to the bot via the Direct Line API. Use the `AddMessageAsync` method (via a reference to the component) to programmatically add the bot's reply to the Chat UI.

Create or modify a Razor component (e.g., `Pages/Chat.razor`) to integrate the Chat UI with the Direct Line API:

{% tabs %}
{% highlight cshtml %}

@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor

<div style="height: 400px; width: 400px;">
    <SfChatUI @ref="ChatUI" User="CurrentUserModel" MessageSend="OnMessageSend" Created="OnCreated">
    </SfChatUI>
</div>

<script src="_content/Syncfusion.Blazor.InteractiveChat/scripts/syncfusion-blazor.min.js"></script>
<script src="https://cdn.botframework.com/botframework-webchat/latest/webchat.js"></script>
<script>
    window.onMessageSend = async (args) => {
        await DotNet.invokeMethodAsync('YourAssemblyName', 'OnMessageSend', args);
    };
    window.onCreated = async () => {
        await DotNet.invokeMethodAsync('YourAssemblyName', 'OnCreated');
    };
</script>

@code {
    private SfChatUI ChatUI { get; set; }
    private UserModel CurrentUserModel = new() { ID = "user1", User = "You" };
    private UserModel BotUserModel = new() { ID = "bot", User = "Bot" };
    private string currentUserId = "user1";
    private bool isConnected = false;

    private async Task OnMessageSend(MessageSendEventArgs args)
    {
        // Initialize Direct Line connection on first message if not already connected
        if (!isConnected)
        {
            try
            {
                // Fetch Direct Line token via HttpClient (Blazor Server can call backend directly)
                using var httpClient = new HttpClient();
                var response = await httpClient.PostAsync("/api/token/directline/token", null);
                var data = await response.Content.ReadFromJsonAsync<dynamic>();
                if (data?.error != null)
                {
                    await ChatUI.AddMessageAsync(new ChatMessage { Text = "Failed to connect to bot.", Author = BotUserModel });
                    return;
                }

                // Use JSInterop to initialize Direct Line (client-side for real-time updates)
                var directLine = await JS.InvokeAsync<IJSObjectReference>("eval", 
                    `new BotFramework.DirectLine.DirectLine({ token: '${data.token}' })`);

                isConnected = true;

                // Subscribe to bot messages via JS callback
                await JS.InvokeVoidAsync("setupBotSubscription", directLine, DotNetObjectReference.Create(this), currentUserId);
            }
            catch (Exception ex)
            {
                await ChatUI.AddMessageAsync(new ChatMessage { Text = "Sorry, I couldn't connect to the bot.", Author = BotUserModel });
                Console.WriteLine($"Connection error: {ex.Message}");
                return;
            }
        }

        // Send message to bot via JSInterop
        await JS.InvokeVoidAsync("sendToBot", directLine, args.Message.Text, currentUserId);
        args.Cancel = true; // Prevent default send
    }

    private Task OnCreated()
    {
        // Additional initialization if needed
        return Task.CompletedTask;
    }

    [JSInvokable]
    public async Task ReceiveBotMessage(string messageText)
    {
        await ChatUI.AddMessageAsync(new ChatMessage { Text = messageText, Author = BotUserModel });
    }
}

{% endhighlight %}
{% endtabs %}

Add the following JavaScript to a global script file (e.g., `wwwroot/js/bot-integration.js`) and reference it in `_Host.cshtml` or `index.html`:

{% tabs %}
{% highlight js tabtitle="_Host.cshtml" %}

window.setupBotSubscription = (directLine, dotNetHelper, currentUserId) => {
    directLine.activity$
        .filter(activity => activity.type === 'message' && activity.from.id !== currentUserId)
        .subscribe(async (message) => {
            await dotNetHelper.invokeMethodAsync('ReceiveBotMessage', message.text);
        });
};

window.sendToBot = async (directLine, text, currentUserId) => {
    directLine.postActivity({
        from: { id: currentUserId, name: 'You' },
        type: 'message',
        text: text
    }).subscribe(
        id => console.log('Sent message with ID: ', id),
        error => {
            console.error('Error sending message: ', error);
            // Handle error via JS callback if needed
        }
    );
};

{% endhighlight %}
{% endtabs %}

> Ensure Syncfusion scripts and styles are included in _Host.cshtml (Blazor Server) or index.html (Blazor WebAssembly) as per the getting started guide. Also, include the Bot Framework Web Chat script for Direct Line functionality. Replace 'YourAssemblyName' with your actual assembly name in the JS invoke calls.

## Configure CORS (if needed for Blazor WebAssembly)

For Blazor WebAssembly (client-side), configure CORS in `Program.cs` to allow API requests to your backend:

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:5001") // Your Blazor WASM URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// In app...
app.UseCors();

{% endhighlight %}
{% endtabs %}

## Run and Test

### Start the Application

* Run the project in Visual Studio or use IIS Express.
* Open your app in the browser (e.g., `http://localhost:port`) to interact with your Microsoft Bot Framework chatbot.

## Troubleshooting

* `Token Server Error (500)`: Ensure the `DirectLineSecret` in `Web.config` is correct and the token endpoint is accessible.
* `CORS Error`: Verify the CORS configuration in `Web.config` allows requests from your frontend URL.
* `Bot is Not Responding`:
  - Test the bot in the Azure Portal using the `Test in Web Chat` feature to ensure it’s running correctly.
  - Check the bot’s `Messaging endpoint` in the Configuration section and ensure it is correct and accessible.
* `Connection Fails on Load`: Verify the token controller is running and accessible. Check the browser console for network errors.
* `Token Expiration`: Direct Line tokens are short-lived. The Direct Line client typically handles token refresh, but if issues persist, restart the Direct Line connection.