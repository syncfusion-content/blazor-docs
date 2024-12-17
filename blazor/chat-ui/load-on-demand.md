---
layout: post
title: Load on-demand in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Load on-demand with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Load on-demand in Blazor Chat UI component

You can use the [LoadOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_LoadOnDemand) property to load messages dynamically when the scroll reaches the top of the message list improving performance and reducing load times, particularly in long conversations. This ensures a smooth user experience by only fetching messages as needed rather than loading the entire conversation at once. 

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI HeaderText="Albert" User="CurrentUserModel" Messages="ChatUserMessages" LoadOnDemand="true"></SfChatUI>
</div>

@code {
    private static UserModel CurrentUserModel = new UserModel() { ID = "User1", User = "Albert" };
    private static UserModel MichaleUserModel = new UserModel() { ID = "User2", User = "Michale Suyama" };
    private List<ChatMessage> ChatUserMessages = new List<ChatMessage>();

    protected override void OnInitialized()
    {
        for (int i = 1; i <= 150; i++)
        {
            ChatUserMessages.Add(new ChatMessage
            {
                Text = i % 2 == 0 ? $"Message {i} from Michale" : $"Message {i} from Albert",
                Author = i % 2 == 0 ? MichaleUserModel : CurrentUserModel
            });
        }
    }
}

```

![Blazor Chat UI LoadOnDemand](./images/load-on-demand.png)