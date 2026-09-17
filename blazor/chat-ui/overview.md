---
layout: post
title: Blazor Chat UI Overview and Features | Syncfusion
description: Learn how to use Blazor Chat UI to build conversational interfaces with messages, timestamps, typing indicators, file attachments and speech support.
platform: Blazor
control: Chat UI
documentation: ug
---

# Overview in Blazor Chat UI

## Introduction to Syncfusion Blazor Chat UI

The [Blazor Chat UI](https://www.syncfusion.com/blazor-components/blazor-chat-ui) is a powerful and feature-rich UI component designed for building chat and conversational interfaces with high performance and flexibility. It offers a comprehensive set of enterprise-grade capabilities, including message configuration with status and reply support, timestamps, time breaks, typing indicators, and mention integration, along with seamless connections to chat bots such as Google Dialogflow and Microsoft Bot Framework. Built for scalability, it enables developers to create responsive messaging experiences for support chats, collaboration tools, and social applications with ease.

## Common use cases

The [Blazor Chat UI](https://www.syncfusion.com/blazor-components/blazor-chat-ui) is ideal for a wide range of business scenarios:

| Use Case | Description | Key Features |
|----------|-------------|--------------|
| **Customer Support Chats** | Connect customers with support agents or AI bots | Bot Integrations, Typing Indicator |
| **Team Collaboration** | Enable person-to-person and group messaging in business apps | Messages, Mentions, Timestamps |
| **Social & Community Apps** | Build engaging user-to-user chat experiences | Messages, File Attachments, Templates |
| **AI Chat Front-Ends** | Present AI-generated conversations in a familiar chat UI | Suggestion Template, Speech-to-Text |
| **In-App Messaging** | Add messaging alongside dashboard or productivity features | Load on-Demand, Header, Footer |
| **Formal Reporting Interfaces** | Share conversations and documents for review | File Attachments, Message Options |

## Messages

The chat experience is built from a configurable message collection. The following features define how messages are displayed and behave:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Configuring Messages](./messages#configuring-messages)** | Define the message collection and its authors | Complete conversation control |
| **[Defining the Current User](./messages#defining-the-current-user)** | Identify which messages belong to the signed-in user | Correct message alignment |
| **[Defining Message Status](./messages#defining-message-status)** | Show sent, delivered, and read states | Delivery transparency |
| **[Pinning a Message](./messages#pinning-a-message)** | Keep important messages at the top | Visible key information |
| **[Replying to a Message](./messages#replying-to-a-message)** | Quote and respond to specific messages | Clear conversation threads |
| **[Forwarding a Message](./messages#forwarding-a-message)** | Share a message with other chats | Easy message sharing |
| **[Enabling Auto-Scroll](./messages#enabling-auto-scroll)** | Keep the latest message in view | Hands-free reading |
| **[Enabling Compact Mode](./messages#enabling-compact-mode)** | Fit more messages in less space | Dense but readable views |
| **[Displaying Markdown Content](./messages#displaying-markdown-content)** | Render rich text, lists, and code in messages | Professional formatting |

## Chat bot integrations

The [Blazor Chat UI](https://www.syncfusion.com/blazor-components/blazor-chat-ui) connects to conversational AI services through server-side handlers:

| Platform | Key Benefit | Best For |
|----------|--------------|----------|
| **[Google Dialogflow](./bot-integrations/integration-with-bot-dialogflow)** | Natural-language bot conversations | AI-powered support bots |
| **[Microsoft Bot Framework](./bot-integrations/integration-with-bot-framework)** | Enterprise bot ecosystem integration | Azure-based bot solutions |

## Conversation context & timing

The [Blazor Chat UI](https://www.syncfusion.com/blazor-components/blazor-chat-ui) provides elements that make conversations easier to follow and more engaging:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Timestamp](./timestamp#show-or-hide-timestamp)** | Show when each message was sent | Message timing clarity |
| **[Setting timestamp format](./timestamp#setting-timestamp-format)** | Control the timestamp display format | Culture-appropriate display |
| **[Time break](./timebreak)** | Visually separate messages by date | Long-history readability |
| **[Typing indicator](./typing-indicator)** | Show when the other user is typing | Live conversation feedback |
| **[Load on-Demand](./load-on-demand)** | Load message history lazily as the user scrolls | Performance with long histories |

## Mentions

The Mention integration lets users tag other participants directly in messages:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Configure Mention Users](./mention#configure-mention-users)** | Define which users can be mentioned | Team-aware tagging |
| **[Customize the Mention trigger character](./mention#customize-the-mention-trigger-character)** | Change the character that activates mentions | Familiar input patterns |
| **[Predefined Mentions in Messages](./mention#predefined-mentions-in-messages)** | Highlight mentions in existing content | Rich rendered conversations |
| **[Configure mentionSelect](./mention#configure-mentionselect)** | Handle mention selection with custom logic | Tailored mention behavior |

## Layout & customization

The [Blazor Chat UI](https://www.syncfusion.com/blazor-components/blazor-chat-ui) offers extensive layout and styling options for creating professional chat views:

**Header & Footer**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Header](./header)** | Show conversation info and toolbar at the top | Contextual conversation header |
| **[Toolbar](./header#toolbar)** | Add actions to the header toolbar | Quick access controls |
| **[Footer](./footer)** | Show the message input area at the bottom | Standard chat input |
| **[Footer template](./footer#footer-template)** | Replace the default footer with custom UI | Custom input experiences |

**Templates**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Empty chat template](./templates#empty-chat-template)** | Display custom content when no messages exist | Welcoming empty states |
| **[Message template](./templates#message-template)** | Customize message rendering | Branded message bubbles |
| **[Time break template](./templates#time-break-template)** | Restyle the date separators | Consistent visual design |
| **[Typing indicator template](./templates#typing-indicator-template)** | Custom typing indicator visuals | Branded presence feedback |
| **[Suggestion template](./templates#suggestion-template)** | Restyle suggested responses | Custom suggestion chips |

**File Attachments & Dimensions**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Enable file attachments](./file-attachments#enable-file-attachments)** | Let users share files in messages | Richer conversations |
| **[Setting file type](./file-attachments#setting-file-type)** | Restrict uploads to allowed formats | Safe file handling |
| **[Setting file size](./file-attachments#setting-file-size)** | Limit individual file sizes | Predictable uploads |
| **[Setting placeholder](./appearance#setting-placeholder)** | Guide users on what to type | Intuitive input experience |
| **[Setting width](./appearance#setting-width)** and **[Setting height](./appearance#setting-height)** | Control component dimensions | Precise layout integration |
| **[Setting CSS class](./appearance#setting-css-class)** | Apply custom CSS themes | Themed experiences |

## Speech support

The [Blazor Chat UI](https://www.syncfusion.com/blazor-components/blazor-chat-ui) enables voice-driven interactions using browser-based speech services:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Speech to Text](./speech-to-text)** | Convert spoken input into message text | Hands-free messaging |

## Globalization & accessibility

The [Blazor Chat UI](https://www.syncfusion.com/blazor-components/blazor-chat-ui) is fully accessible and compliant with Web Content Accessibility Guidelines (WCAG) standards:

- **[Localization](./globalization#localization)** - Translate the UI into different languages
- **[Right-to-Left (RTL)](./globalization#right-to-left-rtl)** - RTL rendering for RTL languages
- **[WAI-ARIA Attributes](./accessibility#wai-aria-attributes)** - Accessible roles and attributes for the Blazor chat UI
- **[Keyboard interaction](./accessibility#keyboard-interaction)** - Complete component operation via keyboard
  - Enter - Send a message when the input is focused
  - Tab / Shift+Tab - Move focus forward and backward
  - Page Up / Page Down - Scroll through the chat history
  - Ctrl+Home / Ctrl+End - Jump to the first or most recent message
  - Arrow Keys / Home / End - Navigate the toolbar items
- **[Ensuring Accessibility](./accessibility#ensuring-accessibility)** - accessibility-checker and axe-core validation guidance

## Advanced features

The [Blazor Chat UI](https://www.syncfusion.com/blazor-components/blazor-chat-ui) includes sophisticated capabilities designed for complex enterprise scenarios:

| Feature | Purpose | Use Case | Key Benefit |
|---------|---------|----------|-------------|
| **[Methods](./methods)** | Programmatically update messages and scroll to the latest message | Dynamic, code-driven control | Automation-friendly API |
| **[Events](./events)** | Handle message sending, typing, and attachment events | Custom workflows and integrations | Deep integration points |
| **[Content Security Policy](./content-security-policy)** | Configure CSP rules for strict security environments | Security-restricted deployments | Compliant enterprise deployment |

## System requirements

The [Blazor Chat UI](https://www.syncfusion.com/blazor-components/blazor-chat-ui) works with:

- **Blazor Version**: .NET 8.0 or higher
- **Hosting Models**: Blazor Server, Blazor WebAssembly, Blazor Web App
- **Browsers**: Chrome, Firefox, Safari, Edge (latest versions)
- **Mobile**: iOS Safari, Android Chrome

## Quick links

**Getting Started:**
- [Blazor Web App Guide](./getting-started)
- [Blazor Server App Guide](./getting-started-with-server-app)
- [Blazor WebAssembly Guide](./getting-started-wasm)

**Popular Features:**
- [Messages](./messages) - Configure, pin, reply, and forward
- [Timestamp](./timestamp) - Message and time break timing
- [Typing Indicator](./typing-indicator) - Live presence feedback
- [Mention Integration](./mention) - Tag users in messages
- [File Attachments](./file-attachments) - Share files in conversations
- [Templates](./templates) - Full UI customization

## Support & Resources

- **Questions?** Visit the [Syncfusion Support Portal](https://www.syncfusion.com/support)
- **Code Examples?** Browse [Chat UI Demos](https://www.syncfusion.com/blazor-components/blazor-chat-ui) and samples
- **API Details?** See [Chat UI API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfChatUI.html)
- **Community?** Join the [Syncfusion Community Forum](https://www.syncfusion.com/forums/blazor-components)
- **What's New?** Check [Release Notes](../Release-Notes)