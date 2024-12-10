---
layout: post
title: Appearance in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Appearance with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Chat UI in Blazor Chat UI component

## Configuring messages

The Chat UI allows to add messages using the `Messages` property. Each message can be configured with options such as id, text, author, timestamp, and more.

### Setting id

You can use the `ID` property to add unique `ID` for each messages, which is essential for tracking and update, a specific messages within the chat. The `ID` is mandatory to differentiate the current different users.

### Adding text

You can use the `Text` property to add message content for the user.

### Adding author

You can use the `Author` property to identify the messages for the specific user. It is the instance of the `UserModel`, information about who sent the message.

> Refer to the [Configuring User](./chat-ui#configuring-user) section for more details about the user settings.

### Setting timestamp

You can use the `Timestamp` property to indicate the date and time of the messages being sent. This uses the Date object, by default it is set to the current date and time when a message is sent.

### Setting timestamp format

You can use the `TimestampFormat` property to display a specific format for the timestamp of each message in the `Messages` property. The default value is `dd/MM/yyyy hh:mm a`, but this can be customized to meet different localization and display needs.

### Setting status

You can use the `Status` property to update the status for the messages status (e.g., sent, received, read). It is the instance of the `MessageStatusModel` model, it helps in managing message delivery and read receipts within the chat interface.

#### Setting iconCss 

You can use the `IconCss` property to update the styling of status icons associated with messages, aiding visual differentiation between statuses.

#### Setting text and tooltip 

You can use the `Text` and `Tooltip` properties to provide information about the messages through descriptive text and tooltips, providing users with context or additional data upon hovering.

## Configuring user

You can use the `User` property to represent the `UserModel` for the messages. Each user can be configured with options such as id, user, avatarUrl, and more. 

### Setting id

You can use the `ID` property to add unique `ID` for each users, which is mandatory to distinguish between different participants.

### Adding user

You can use the `User` property to configure the display name for the user in the chat. By default, the user name value is set to `Default`.

### Adding avatar url

You can use the `AvatarUrl` property to define the image URL’s for the user avatar. If no URL is provided, fallback initials of the first and last name from the user’s name will be used.

### Adding avatar background color

You can use the `AvatarBgColor` property to set a specific background color for user avatars using hexadecimal values. If no color is set, a custom background color is set based on specified theme.

### Adding cssClass

You can use the `CssClass` property to customize the appearance of the chat user.

## Messages collection

You can use the `Messages` property to initialize the control with the configured message data from multiple users. It is a collection of messages, each represented by a `ChatMessage`.

The message collection stores all the messages being sent. 

## Enable load on demand

You can use the `LoadOnDemand` property to load messages dynamically when the scroll reaches the top of the message list improving performance and reducing load times, particularly in long conversations. This ensures a smooth user experience by only fetching messages as needed rather than loading the entire conversation at once.

## Display time break

You can use the `ShowTimeBreak` property to display date-wise separations between all the messages which enhances the readability and message organizing. The default value is `false`, indicating time breaks are disabled unless it is enabled.

## Display timestamp

You can use the `ShowTimestamp` property to enable or disable timestamps for all messages which displays the exact date and time when they were sent. By default, the value is `true`.

## Adding timestamp format

You can use the `TimestampFormat` property to display a specific format for the timestamp. The default value is `dd/MM/yyyy hh:mm a`, but this can be customized to meet different localization and display needs.

## Display typing indicators

You can use the `TypingUsers` property  to display the current user’s who are typing to indicate the active participants typing response within the chat conversations.

It is the instance of the `UserModel` collection, where you can update the user’s dynamically to display the current typing user.

## Adding suggestions

You can use the `Suggestions` property, to add the suggestions in both initial and on-demand which help users to quick-reply options above the input field. 

## Setting autoScrolltoBottom

You can use the `AutoScrollToBottom` property to automatically scroll the chats when a new message is received in a real-time conversation. By default, this value is set to false, requiring manual scrolling unless activated. The FAB button will be displayed, to quick access to the bottom of the view. 

By default, it scrolls to bottom for each message being sent in the chat, in order to prevent the scroll for end user messages you can use the `AutoScrollToBottom` property.

## Show or hide header

You can use `ShowHeader` property to enable or disable the chat header. It contains the following options `HeaderText` and `HeaderIconCss`.

### Adding header text

You can use the `HeaderText` property to display the text that appears in the header, which indicates the current username or the group name, providing the context for the conversation.

### Adding header iconCss

You can use the `HeaderIconCss` property to customize the styling of the header icon.

## Show or hide footer

You can use `ShowFooter` property to enable or disable the chat footer.