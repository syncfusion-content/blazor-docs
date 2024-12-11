---
layout: post
title: Templates in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Templates with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Templates in Blazor Chat UI component

The Chat UI component provides several templates for customizing the appearance of the empty conversation area, messages, typing indicator, and more. These templates provide flexibility for users to create a unique, personalized chat experience. 

## Empty chat template

You can use the `EmptyChatTemplate` property to customize the chat interface when no messages are displayed. Personalized content, such as welcome messages or images, can be added to create an engaging and inviting experience for users starting a conversation.

```cshtml

<div class="chatui-container" style="height: 400px; width: 400px;">
    <SfChatUI>
        <EmptyChatTemplate>
            <div class="empty-chat-text">
                <h4><span class="e-icons e-comment-show"></span></h4>
                <h4>No Messages Yet</h4>
                <p>Start a conversation to see your messages here.</p>
            </div>
        </EmptyChatTemplate>
    </SfChatUI>
</div>

<style>
    .empty-chat-text {
        font-size: 15px;
        text-align: center;
        margin-top: 90px;
    }
</style>

```

![Blazor Chat UI EmptyChatTemplate](./images/emptychat.png)

## Message template

You can use the `MessageTemplate` property to customize the appearance and styling of each chat message. Modify text styling, layout, and other design elements to ensure a personalized chat experience. The template context includes `Message` and `Index` items.

```cshtml

<div class="template-chatui" style="height: 400px; width: 400px;">
    <SfChatUI ID="chatUser" User="AlbertUserModel" Messages="ChatUserMessages">
        <MessageTemplate>
            <div class="message-items e-card">
                <div class="message-text">@((MarkupString)context.Message.Text)</div>
            </div>
        </MessageTemplate>
    </SfChatUI>
</div>

@code {
    private static UserModel AlbertUserModel = new UserModel() { ID = "User1", User = "Albert" };
    private static UserModel MichaleUserModel = new UserModel() { ID = "User2", User = "Michale Suyama" };

    private List<ChatMessage> ChatUserMessages = new List<ChatMessage>()
    {
        new ChatMessage() { Text = "Want to get coffee tomorrow?", Author = AlbertUserModel },
        new ChatMessage() { Text = "Sure! What time?", Author = MichaleUserModel },
        new ChatMessage() { Text = "How about 10 AM?", Author = AlbertUserModel }
    };
}

<style>
    .template-chatui .e-right .message-items {
        border-radius: 16px 16px 2px 16px;
        background-color: #c5ffbf;
    }

    .template-chatui .e-left .message-items {
        border-radius: 16px 16px 16px 2px;
        background-color: #f5f5f5;
    }

    .template-chatui .message-items {
        padding: 5px;
    }
</style>

```

![Blazor Chat UI MessageTemplate](./images/messageTemp.png)

## Time break template

You can use the `TimeBreakTemplate` property to customize how time breaks are displayed with using the template, such as showing "Today," "Yesterday," or specific dates. This enhances conversation organization by clearly separating messages based on time, improving readability for the user. The template context includes `Message`.

```cshtml

<div class="template-chatui" style="height: 400px; width: 400px;">
    <SfChatUI ID="chatUser" User="AlbertUserModel" Messages="ChatUserMessages" ShowTimeBreak="true">
        <TimeBreakTemplate>
            <div class="timebreak-wrapper">@(context.MessageDate.Value)</div>
        </TimeBreakTemplate>
    </SfChatUI>
</div>

<style>
    .template-chatui .timebreak-wrapper {
        background-color: #6495ed;
        color: #ffffff;
        border-radius: 5px;
        padding: 2px;
    }
</style>

@code {
    private static UserModel AlbertUserModel = new UserModel() { ID = "User1", User = "Albert" };
    private static UserModel MichaleUserModel = new UserModel() { ID = "User2", User = "Michale Suyama" };

    private List<ChatMessage> ChatUserMessages = new List<ChatMessage>()
    {
        new ChatMessage() { Text = "Want to get coffee tomorrow?", Author = AlbertUserModel, Timestamp = new DateTime(2024,12,25,7,30,0) },
        new ChatMessage() { Text = "Sure! What time?", Author = MichaleUserModel, Timestamp = new DateTime(2024,12,25,8,0,0) },
        new ChatMessage() { Text = "How about 10 AM?", Author = AlbertUserModel, Timestamp = new DateTime(2024,12,25,11,0,0) }
    };
}

```

![Blazor Chat UI TimeBreakTemplate](./images/timebreakTemp.png)

## Typing indicator template

You can use the `TypingUsersTemplate` property to customize the display of users currently typing in the chat. It allows for styling and positioning of the typing indicator, enhancing the user experience. The template context includes `Users`.

## Suggestion template

You can use the `SuggestionTemplate` property to customize the quick reply suggestions that appear above the input field. Templates here can help create visually appealing and functional suggestion layouts. The template context includes `Suggestions` and `Index` items.

## Footer template

You can use the `FooterTemplate` property to customize the default footer area and manage message send actions with a personalized design. This flexibility allows users to create unique footers that meet their specific needs.


