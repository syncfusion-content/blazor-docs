---
layout: post
title: Mention Integration in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Mention Integration with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Mention Integration in Blazor Chat UI component

## Mention Integration in Syncfusion Chat UI

The Syncfusion ChatUI allows users to mention others in messages using the `@` character, with an autocomplete dropdown for selecting users. The following sections explain how to configure mentions

## Configure Mention Users

You can use the [MentionUsers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_MentionUsers/) property to define an array of users for the mention suggestion popup.

```cshtml
@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI ID="chatUser" User="CurrentUserModel" Messages="ChatUserMessages" MentionUsers="MentionUsers"></SfChatUI>
</div>

@code {
    private static UserModel CurrentUserModel = new UserModel() { ID = "User1", User = "Albert" };
    private static UserModel MichaleUserModel = new UserModel() { ID = "User2", User = "Michale Suyama" };
    private static UserModel ReenaUserModel = new UserModel() { ID = "custom-user", User = "Reena" };
    private List<UserModel> MentionUsers = new List<UserModel>()
    {
        CurrentUserModel,
        ReenaUserModel
    };

    private List<ChatMessage> ChatUserMessages = new List<ChatMessage>()
    {
        new ChatMessage() { Text = "Want to get coffee tomorrow?", Author = CurrentUserModel },
        new ChatMessage() { Text = "Sure! What time?", Author = MichaleUserModel },
        new ChatMessage() { Text = "How about 10 AM?", Author = CurrentUserModel }
    };
}

```

![Blazor Chat UI MentionUsers](./images/MentionUsers.png)

## Customize the Mention trigger character

You can use the [MentionChar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_MentionChar/) property to customize the character which triggers the mention popup. The default value is `@`.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI ID="chatUser" User="CurrentUserModel" Messages="ChatUserMessages" MentionUsers="MentionUsers" MentionChar="MentionCharacter"></SfChatUI>
</div>

@code {
    private static UserModel CurrentUserModel = new UserModel() { ID = "User1", User = "Albert" };
    private static UserModel MichaleUserModel = new UserModel() { ID = "User2", User = "Michale Suyama" };
    private static UserModel ReenaUserModel = new UserModel() { ID = "custom-user", User = "Reena" };
    private List<UserModel> MentionUsers = new List<UserModel>()
    {
        CurrentUserModel,
        ReenaUserModel
    };
    char MentionCharacter = '@';
    private List<ChatMessage> ChatUserMessages = new List<ChatMessage>()
    {
        new ChatMessage() { Text = "Want to get coffee tomorrow?", Author = CurrentUserModel },
        new ChatMessage() { Text = "Sure! What time?", Author = MichaleUserModel },
        new ChatMessage() { Text = "How about 10 AM?", Author = CurrentUserModel }
    };
}

```

![Blazor Chat UI MentionCharacter](./images/MentionCharacter.png)

## Predefine Mentions with messages

You can use the [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.ChatMessage.html#Syncfusion_Blazor_InteractiveChat_ChatMessage_Text) property in the [ChatMessage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.ChatMessage.html#Syncfusion_Blazor_InteractiveChat_ChatMessage/) to include predefined mentions in chat messages. The mentions field stores the selected users for each message.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div style="height: 400px; width: 400px;">
    <SfChatUI ID="mention-chat" User="CurrentUserModel" Messages="ChatUserMessages"></SfChatUI>
</div>

@code {
    private static UserModel CurrentUserModel = new UserModel() { ID = "user1", User = "Albert" };
    private static UserModel MichaleUserModel = new UserModel() { ID = "user2", User = "Michale Suyama" };

    private List<ChatMessage> ChatUserMessages = new List<ChatMessage>()
    {
        new ChatMessage() {
            Author = CurrentUserModel,
            Text = "Hi {0}, are we on track for the deadline?",
            MentionUsers = new List<UserModel>() { MichaleUserModel }
        },
        new ChatMessage() { Author = MichaleUserModel, Text = "Yes, the design phase is complete." },
        new ChatMessage() { Author = CurrentUserModel, Text = "I’ll review it and send feedback by today." }
    };
}

```

![Blazor Chat UI MentionMessage](./images/MentionMessage.png)

## Configure mentionSelect

You can use the [ValueSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html#Syncfusion_Blazor_InteractiveChat_SfChatUI_ValueSelecting) event which triggers when a user selects an item from the mention dropdown, providing access to the selected user’s details for custom handling.

```cshtml

@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.DropDowns

<div style="height: 400px; width: 400px;">
    <SfChatUI ID="mentionSelect" MentionUsers="MentionUsers" ValueSelecting="ValueSelecting"></SfChatUI>
</div>

@code {
    private static UserModel CurrentUserModel = new UserModel() { ID = "user1", User = "Albert" };
    private static UserModel MichaleUserModel = new UserModel() { ID = "user2", User = "Michale Suyama" };

    private List<UserModel> MentionUsers = new List<UserModel>()
    {
        CurrentUserModel,
        MichaleUserModel
    };

    private void ValueSelecting(MentionValueSelectingEventArgs<UserModel> args)
    {
        // Your required action here
    }
}

```