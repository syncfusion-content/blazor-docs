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

You can use the `TimestampFormat` to display specific format for the timestamp. The default value is `dd/MM/yyyy hh:mm a`, but this can be customized to meet different localization and display needs.

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

### Adding cssclass

You can use the `CssClass` property to customize the appearance of the chat user. 