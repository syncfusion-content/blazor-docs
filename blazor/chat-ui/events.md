---
layout: post
title: Events in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Events with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Events in Blazor Chat UI component

This section describes the Chat UI events that will be triggered when appropriate actions are performed. The following events are available in the Chat UI component.

## Created

The Chat UI component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_Created) event when the component rendering is completed.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI Created="Created"></SfChatUI>
</div>

@code {
    private void Created()
    {
        // Your required action here
    }
}

```

## Sending message

The [MessageSend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_MessageSend) event is triggered when the message is being sent in the Chat UI component.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI MessageSend="MessageSend"></SfChatUI>
</div>

@code {
    private void MessageSend(ChatMessageSendEventArgs args)
    {
        // Your required action here
    }
}

```

## User typing

The [UserTyping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_UserTyping) event is triggered when the user is typing a message in the Chat UI component.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI UserTyping="UserTyping"></SfChatUI>
</div>

@code {
    private void UserTyping(ChatUserTypingEventArgs args)
    {
        // Your required action here
    }
}

```
