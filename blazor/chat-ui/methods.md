---
layout: post
title: Methods in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Methods with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Methods in Blazor Chat UI component

## Edit message

You can use the `UpdateMessageAsync` public method to update the messages in the ChatUI to modify an existing message within the chat, useful for editing or correcting sent messages.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <button @onclick="UpdateMessage" class="e-btn e-primary" style="margin-bottom: 10px">Update Message</button>
    <SfChatUI @ref="@ChatUser" ID="chatUser" User="CurrentUserModel" Messages="ChatUserMessages"></SfChatUI>
</div>

@code {
    private SfChatUI ChatUser;
    private static UserModel CurrentUserModel = new UserModel() { ID = "User1", User = "Albert" };
    private static UserModel MichaleUserModel = new UserModel() { ID = "User2", User = "Michale Suyama" };

    private List<ChatMessage> ChatUserMessages = new List<ChatMessage>()
    {
        new ChatMessage() { ID="msg1", Text = "Want to get coffee tomorrow?", Author = CurrentUserModel },
        new ChatMessage() { Text = "Sure! What time?", Author = MichaleUserModel },
        new ChatMessage() { Text = "How about 10 AM?", Author = CurrentUserModel }
    };

    private async void UpdateMessage()
    {
        await ChatUser.UpdateMessageAsync(new ChatMessage() { Text = "Want to get breakfast today?", Author = CurrentUserModel }, "msg1");
    }
}

```

![Blazor Chat UI UpdateMessage](./images/update-msg.png)

## Scroll to bottom

You can use `ScrollToBottomAsync` public method to scroll the chat view to the latest message, ensuring users see the new content updated.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <button @onclick="ScrollToBottom" class="e-btn e-primary" style="margin-bottom: 10px">Scroll to bottom</button>
    <SfChatUI @ref="@ChatUser" ID="chatUser" User="CurrentUserModel" Messages="ChatUserMessages"></SfChatUI>
</div>

@code {
    private SfChatUI ChatUser;
    private static UserModel CurrentUserModel = new UserModel() { ID = "User1", User = "Albert" };
    private static UserModel MichaleUserModel = new UserModel() { ID = "User2", User = "Michale Suyama" };

    private List<ChatMessage> ChatUserMessages = new List<ChatMessage>()
    {
        new ChatMessage() { Text = "Want to get coffee tomorrow?", Author = CurrentUserModel },
        new ChatMessage() { Text = "Sure! What time?", Author = MichaleUserModel },
        new ChatMessage() { Text = "How about 10 AM?", Author = CurrentUserModel },
        new ChatMessage() { Text = "Perfect.", Author = MichaleUserModel },
        new ChatMessage() { Text = "See you!", Author = CurrentUserModel },
        new ChatMessage() { Text = "Bye!", Author = MichaleUserModel }
    };

    private async void ScrollToBottom()
    {
        await ChatUser.ScrollToBottomAsync();
    }
}

```

![Blazor Chat UI ScrollToBottom](./images/scroll-bottom.png)
