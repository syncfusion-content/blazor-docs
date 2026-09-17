---
layout: post
title: Blazor AI AssistView Overview and Features | Syncfusion
description: Learn how to use Blazor AI AssistView to build conversational AI interfaces with prompts, responses, toolbar items, file attachments and speech support.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Overview in Blazor AI AssistView

## Introduction to Syncfusion Blazor AI AssistView

The [Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview) is a powerful and feature-rich UI component designed for building conversational AI interfaces with high performance and flexibility. It offers a comprehensive set of enterprise-grade capabilities, including prompt response chat views, prompt suggestions, custom views, toolbar items, and file attachments, along with seamless integration with AI services such as Azure OpenAI and Google Gemini. Built for scalability, it enables developers to create responsive, AI-assisted user experiences for chatbots, copilots, and intelligent assistants with ease.

## Common use cases

The [Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview) is ideal for a wide range of business scenarios:

| Use Case | Description | Key Features |
|----------|-------------|--------------|
| **Customer Support Chatbots** | Answer customer questions with AI-generated responses and suggested prompts | Prompt Suggestions, Toolbar Items |
| **In-App Copilots** | Embed AI assistants that help users complete tasks within business apps | Custom Views, Toolbar Items |
| **Document Q&A Assistants** | Let users attach files and ask questions about their content | File Attachments, Templates |
| **Content Generation Workflows** | Draft, edit, and regenerate AI-generated text and code | Prompt-Response Collection, Methods |
| **Voice-Driven Assistants** | Interact hands-free using voice input and spoken responses | Speech-to-Text, Text-to-Speech |
| **Enterprise AI Portals** | Provide company-wide access to AI services with a consistent UI | AI Integrations, Style and Appearance |

## AI service integrations

The [Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview) is UI-focused and connects to any AI service through server-side handlers. The following guided integrations show how to wire the component to popular providers:

| Provider | Key Benefit | Best For |
|----------|--------------|----------|
| **[Azure OpenAI](./ai-integrations/openai-integration)** | Enterprise-grade OpenAI models on Azure | Production enterprise applications |
| **[Google Gemini](./ai-integrations/gemini-integration)** | Google's multimodal Gemini models | Google Cloud-based stacks |
| **[Ollama LLM](./ai-integrations/ollama-llm-integration)** | Locally hosted open-source models | Privacy-sensitive, offline scenarios |
| **[LiteLLM](./ai-integrations/lite-llm-integration)** | Unified gateway across multiple providers | Multi-provider architectures |

**Microsoft.Extensions.AI integration**

The [Integration with Microsoft.Extensions.AI](./how-to/integration-with-ai) topic shows how to connect the AI AssistView to the `IChatClient` abstraction so the same UI works with any compatible provider.

## Assist view

The core chat experience is built from prompts, responses, and suggestions. The following features configure the conversation interface:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Setting prompt text](./assist-view#setting-prompt-text)** | Define the initial prompt text | Quick initial engagement |
| **[Setting prompt placeholder](./assist-view#setting-prompt-placeholder)** | Guide users on what to ask | Intuitive input experience |
| **[Prompt-response collection](./assist-view#prompt-response-collection)** | Manage the full conversation history | Complete chat context |
| **[Adding prompt suggestions](./assist-view#adding-prompt-suggestions)** | Show recommended questions to users | Faster task discovery |
| **[Update response as markdown](./assist-view#update-response-as-markdown)** | Render rich text, lists, and code in responses | Professional AI output |
| **[Enable scroll to bottom icon](./assist-view#enable-scroll-to-bottom-icon)** | Jump to the latest response in long chats | Easy long-conversation navigation |

## Toolbars & actions

The [Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview)provides built-in toolbars in the header and footer that streamline common chat actions:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Configure footer toolbar](./toolbar-items#configure-footer-toolbar)** | Set up prompt and response toolbar items | Message-level actions |
| **[Adding header toolbar items](./toolbar-items#adding-header-toolbar-items)** | Add actions to the component header | Global chat controls |
| **[Built-in toolbar items](./toolbar-items#built-in-toolbar-items)** | Use predefined items such as copy, regenerate, and edit | Out-of-the-box productivity |
| **[Toolbar positioning](./toolbar-items#toolbar-positioning)** | Place toolbars wherever they fit the UI | Flexible layouts |
| **[Adding custom items](./toolbar-items#adding-custom-items)** | Add application-specific actions | Tailored experiences |

## Customization

The [Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview) offers extensive customization options for creating professional conversations tailored to any workflow:

**Custom Views**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Adding custom views](./custom-view#adding-custom-views)** | Create alternate views such as FAQs or knowledge bases | Beyond chat experiences |
| **[Setting view template](./custom-view#setting-view-template)** | Render view content with Blazor templates | Fully custom designs |

**Templates**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Banner template](./templates#banner-template)** | Display welcome content at the top | Branded landing experience |
| **[Prompt item template](./templates#prompt-item-template)** | Customize user prompt bubbles | Branded user messages |
| **[Response item template](./templates#response-item-template)** | Customize AI response rendering | Rich response presentation |
| **[Prompt suggestion item template](./templates#prompt-suggestion-item-template)** | Restyle suggested prompts | Custom suggestion chips |
| **[Footer template](./templates#footer-template)** | Replace the default footer area | Complete layout control |

**File Attachments & Dimensions**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Enabling attachment](./file-attachments#enabling-attachment)** | Let users upload files with their prompts | Context-rich conversations |
| **[Setting file type](./file-attachments#setting-file-type)** | Restrict uploads to allowed formats | Safe file handling |
| **[Setting file size](./file-attachments#setting-file-size)** | Limit individual file sizes | Predictable uploads |
| **[Setting maximum count](./file-attachments#setting-maximum-count)** | Cap attachments per prompt | Appropriate input volume |
| **[Setting width](./appearance#setting-width)** and **[Setting height](./appearance#setting-height)** | Control component dimensions | Precise layout integration |
| **[CssClass](./appearance#cssclass)** | Apply custom CSS themes | Themed experiences |

## Speech support

The [Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview) enables voice-driven interactions using browser-based speech services:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Speech to Text](./speech/speech-to-text)** | Convert spoken input into prompt text | Hands-free prompting |
| **[Text to Speech](./speech/text-to-speech)** | Read responses aloud with configurable voices | Accessible, audible output |

## Accessibility

The [Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview) is fully accessible and compliant with Web Content Accessibility Guidelines (WCAG 2.2) standards:

- **[WAI-ARIA attributes](./accessibility#wai-aria-attributes)** - Accessible roles and attributes for buttons, toolbars, and inputs
- **[Keyboard interaction](./accessibility#keyboard-interaction)** - Complete component operation via keyboard
  - Tab / Shift+Tab - Move focus forward and backward
  - Enter / Space - Select the focused item
  - Arrow Keys - Navigate between toolbar items
  - Home / End - Jump to the first or last toolbar item
- **[Ensuring accessibility](./accessibility#ensuring-accessibility)** - axe-core with Playwright validation guidance
- **Right-to-Left support** - RTL rendering for RTL languages

## Advanced features

The [Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview) includes sophisticated capabilities designed for complex enterprise scenarios:

| Feature | Purpose | Use Case | Key Benefit |
|---------|---------|----------|-------------|
| **[Methods](./methods)** | Programmatically execute prompts and control the view | Dynamic, code-driven conversations | Automation-friendly API |
| **[Events](./events)** | Handle lifecycle, prompt, and attachment events | Custom workflows and integrations | Deep integration points |

## System requirements

The [Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview) works with:

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
- [Assist View](./assist-view) - Prompts, responses, and suggestions
- [Toolbar Items](./toolbar-items) - Header and footer actions
- [Custom Views](./custom-view) - Alternate views beyond chat
- [File Attachments](./file-attachments) - Upload context with prompts
- [Templates](./templates) - Full UI customization
- [AI Integrations](./ai-integrations/openai-integration) - Connect to Azure OpenAI and more

## Support & Resources

- **Questions?** Visit the [Syncfusion Support Portal](https://www.syncfusion.com/support)
- **Code Examples?** Browse [AI AssistView Demos](https://www.syncfusion.com/blazor-components/blazor-ai-assistview) and samples
- **API Details?** See [AI AssistView API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfAIAssistView.html)
- **Community?** Join the [Syncfusion Community Forum](https://www.syncfusion.com/forums/blazor-components)
- **What's New?** Check [Release Notes](../Release-Notes)
