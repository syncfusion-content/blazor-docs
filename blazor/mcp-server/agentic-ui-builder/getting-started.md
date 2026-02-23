---
layout: post
title: Getting Started with Blazor Agentic UI Builder | Syncfusion
description: Learn how to set up and use the Syncfusion Blazor UI Builder MCP Server for AI-powered assistance in building Blazor applications with Syncfusion components.
control: Getting started with Syncfusion Blazor UI Builder MCP Server
platform: blazor
documentation: ug
domainurl: ##DomainURL##
---

# Getting Started with Agentic UI Builder

The **Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor UI Builder** uses AI to help you build Blazor applications with natural language commands. Simply describe what you want to create, and it generates complete UI implementations with Syncfusion components.

## Installation

Follow the [Installation Guide](../installation) to set up the MCP server in your development environment.

## Usage

Once installed, open your AI assistant in the IDE and describe what you want to build with the `#sf_blazor_ui_builder` command:

```
#sf_blazor_ui_builder Create a dashboard with a sales data grid and monthly trend chart.

```

The UI Builder generates complete implementations including layout, components, and styling.

> Note: Using the `#sf_blazor_ui_builder` tool ensures the Agentic UI Builder is invoked directly. Alternatively, you can use natural language without the tool - just make sure to include the "Syncfusion" keyword in your prompt so the AI model can automatically recognize and call the appropriate generator.

## Individual Tools

For targeted assistance, you can call individual tools directly using their specific tool names. This is useful when you need specialized help from a particular tool.

### Layout Tool (`#sf_blazor_layout`)

Provides a catalog of pre-built, responsive UI layout templates and blocks for common page sections and design patterns.

**When to use:** Page structures, responsive layouts, or pre-built UI patterns.

**Example:**

```
#sf_blazor_layout Create a responsive card layout for product listings.
```

### Component Tool (`#sf_blazor_component`)

Provides quick reference guidelines for Syncfusion Blazor components, including properties, event handlers, methods, and usage examples.

**When to use:** To get basic component API information and structure details for implementing specific components correctly.

**Example:**
```
#sf_blazor_component How do I integrate a data table?
```

### Style Tool (`#sf_blazor_style`)

Provides theme configuration, styling setup, and icon integration for Syncfusion Blazor components. Supports multiple themes (Tailwind3 CSS, Bootstrap 5.3, Material 3, Fluent 2), light/dark mode implementation, and icon patterns for consistent UI styling.

**When to use:** To apply themes, customize colors, modify the visual design of components, or integrate icons into your UI.

**Example:**
```
#sf_blazor_style How do I apply the Syncfusion Tailwind 3 dark theme and add a communication icon inside a button?
```

## Best Practices

To maximize the effectiveness of the Agentic UI Builder and achieve optimal results:

- **Minimize active tools:** Limit the number of active MCP tools in your IDE to prevent tool-selection ambiguity and improve response accuracy.
- **Start simple:** Begin with straightforward prompts and progressively add complexity as needed.
- **Be specific:** Provide clear, specific descriptions of your layout requirements, component behavior, and design preferences.
- **Reference patterns:** Mention existing design systems, component libraries, or specific patterns you want to replicate.
- **Stay consistent:** Maintain consistent file organization, naming conventions, and coding standards throughout your Blazor project.
- **Work incrementally:** For better control and precision—break down complex layouts into individual sections rather than requesting multiple blocks simultaneously.
- **Use advanced AI models:** For best results, use **Claude Sonnet 4.5 or higher** models. Other compatible models include **GPT-5 and Gemini 3 Pro**. Higher-capability models produce better code quality and more accurate component implementations.

> Always review AI-generated code before using it in production.

## What's Next

Now that you've set up the Agentic UI Builder, explore these resources:

* **[Prompt Library](./prompt-library)** - Ready-to-use prompts for common scenarios
* **[Showcase Sample Projects](https://www.syncfusion.com/showcase-apps/blazor)** - Full application examples
* **[Component Examples](https://blazor.syncfusion.com/demos/)** - Interactive demos of all Syncfusion Blazor components
