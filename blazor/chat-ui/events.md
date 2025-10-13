---
layout: post
title: Events in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Events with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Events in Blazor Chat UI Component

The Blazor Chat UI component provides a flexible event system that enables developers to respond to key user interactions.

This section covers the following available events:

*   [Created](#created)
*   [MessageSend](#sending-message)
*   [UserTyping](#user-typing)

## Created

The [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_Created) event is triggered after the Chat UI component has been rendered.

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

The [MessageSend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_MessageSend) event is triggered when a user sends a message.

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

The [UserTyping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_UserTyping) event is triggered as the user types a message in the input field.

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
