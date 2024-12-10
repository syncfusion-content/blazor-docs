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

## Message template

You can use the `MessageTemplate` tag directive to customize the individual message rendering in the Chat UI. The template context includes `Message` and `Index` items.

## Suggestion template

You can use the `SuggestionTemplate` tag directive to customize the message suggestion items in the Chat UI. The template context includes the `Index` and `Suggestions`.

## Footer template

You can use the `FooterTemplate` property to customize the default footer area and manage message send actions with a personalized design. This flexibility allows users to create unique footers that meet their specific needs. 

## Timebreak template

You can use the `TimeBreakTemplate` tag directive to customize the time break between chat messages in the Chat UI. The template context includes the `MessageDate`.

## Typing users template

You can use the `TypingUsersTemplate` tag directive to customize the typing indicator in the Chat UI. The template context includes the `Users`.
