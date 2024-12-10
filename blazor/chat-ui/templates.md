---
layout: post
title: Templates in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Templates with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Templates in Blazor Chat UI component

The Chat UI provides several template options to customize the empty chat, message, suggestions, footer items, timebreak and typing users.

## Empty chat template

You can use the `EmptyChatTemplate` tag directive to display information when there are no messages, such as a welcome note, and more in the Chat UI.

## Message template

You can use the `MessageTemplate` tag directive to customize the individual message rendering in the Chat UI. The template context includes `Message` and `Index` items.

## Suggestion template

You can use the `SuggestionTemplate` tag directive to customize the message suggestion items in the Chat UI. The template context includes the `Index` and `Suggestions`.

## Footer template

You can use the `FooterTemplate` tag directive to customize the default footer area in the Chat UI. This allows users to create unique footers that meet their specific needs.

## Timebreak template

You can use the `TimeBreakTemplate` tag directive to customize the time break between chat messages in the Chat UI. The template context includes the `MessageDate`.

## Typing users template

You can use the `TypingUsersTemplate` tag directive to customize the typing indicator in the Chat UI. The template context includes the `Users`.
