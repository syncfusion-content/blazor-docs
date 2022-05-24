---
layout: post
title: Realtime Editing with SignalR in Blazor RichTextEditor Component | Syncfusion
description: Learn here all about renaming images before inserting it in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Realtime Editing with SignalR

 The richtexteditor allows, two or more users can editing in the same richtexteditor. This can be archived by SignalR service.

 Which will now update the Editor value real-time, when loading it in multiple pages.

{% tabs %}
{% highlight razor tabtitle="~/realtime-editong.razor" %}

@using Microsoft.AspNetCore.SignalR.Client
@inject NavigationManager NavigationManager
@implements IAsyncDisposable

<h3>Realtime value update</h3>

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor @bind-Value="RTEValue" SaveInterval="100">
    <RichTextEditorEvents ValueChange="@Send"></RichTextEditorEvents>
</SfRichTextEditor>

@code {
    private HubConnection hubConnection;
    private List<string> messages = new List<string>();
    private string messageInput;
    private string RTEValue;
    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
            .Build();
        hubConnection.On<string, string>("ReceiveMessage", (value, message) =>
        {
            RTEValue = value;
            StateHasChanged();
        });
        await hubConnection.StartAsync();
    }
    async Task Send() =>
        await hubConnection.SendAsync("SendMessage", RTEValue, messageInput);
    public bool IsConnected =>
        hubConnection.State == HubConnectionState.Connected;
    public async ValueTask DisposeAsync()
    {
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}

{% endhighlight %}
{% endtabs %}

`chathup.cs`

```csharp
   public class ChatHub : Hub 
    { 
        public async Task SendMessage(string value, string message) 
        { 
            await Clients.All.SendAsync("ReceiveMessage", value, message); 
        } 
    } 
```