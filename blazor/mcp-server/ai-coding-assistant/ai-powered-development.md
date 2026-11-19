---
layout: post
title: AI Coding Assistants for Syncfusion Blazor Components | Syncfusion®
description: Learn how Skills, the MCP Server, the Prompt Library, the Agentic UI Builder, and WebMCP help AI assistants generate accurate Syncfusion Blazor code.
control: AI Coding Assistants Overview
platform: Blazor
documentation: ug
domainurl: ##DomainURL##
---

# AI Coding Assistants for Syncfusion® Blazor Components

AI assistants can speed up Syncfusion® Blazor development. Without product context, however, they can suggest code that looks correct but uses outdated APIs, invalid parameters, or missing configuration. Examples include a component feature that needs a setup step the assistant did not know about, or a parameter name from an older version.

Syncfusion® AI Coding Assistants reduce these problems by giving the assistant access to current Syncfusion® Blazor guidance. The guidance comes either from documentation retrieved through the MCP Server or from skill files stored in your project.

This page explains:

* Which AI Coding Assistant experiences are available for Blazor.
* How each experience improves the accuracy of generated code.
* Which experience to choose for a given task.

## Available experiences

| Experience | What it provides | Learn more |
|---|---|---|
| **Skills** | Component usage, API, and theming guidance stored as skill files that your AI assistant reads while generating code. | [Blazor Agent Skills](https://blazor.syncfusion.com/documentation/skills) |
| **MCP Server** | A [Model Context Protocol](https://modelcontextprotocol.io/docs/2026-07-28/getting-started/intro) (MCP) server that gives your IDE access to Syncfusion® Blazor documentation and code guidance through the `search_docs` tool. | [Syncfusion Blazor MCP Server](https://blazor.syncfusion.com/documentation/mcp) |
| **Prompt Library** | Ready-to-use prompts for common component tasks. | [Prompt Library](./prompt-library) |
| **Agentic UI Builder** | An agent skill that turns natural-language UI requirements into Blazor components, layouts, and themes. | [Agentic UI Builder](https://blazor.syncfusion.com/documentation/agentic-ui-builder) |
| **WebMCP** | Lets a browser-based AI agent operate a running Syncfusion® Blazor component through tools that the component registers with the browser. | [WebMCP](https://blazor.syncfusion.com/documentation/webmcp/overview) |

N> The Agentic UI Builder was previously part of the MCP Server as `#sf_blazor_ui_builder`. It is now an agent skill-based experience and is no longer part of the MCP Server. The documentation tool was renamed from `#sf_blazor_assistant` to `#search_docs`. See the [release notes](https://blazor.syncfusion.com/documentation/ai-tools/release-notes) for details.

### Skills

Skills are curated reference files that the assistant loads on demand. The assistant first reads only the skill names and descriptions, then loads the skill and reference files that match your request. Blazor Skills cover component usage and APIs, recommended patterns such as data binding, and theming guidance. Skills install with the Skills CLI, so you can keep them in your project or install them globally. Skills are also available through the [Syncfusion® .NET CLI](https://blazor.syncfusion.com/documentation/dotnet-cli/install-skills).

Skills are published in the [Syncfusion Blazor component skills repository](https://github.com/syncfusion/blazor-ui-components-skills).

### MCP Server

The Syncfusion® Blazor MCP Server runs from the [Syncfusion.Blazor.MCP](https://www.nuget.org/packages/Syncfusion.Blazor.MCP) NuGet package. On .NET 10 and later, the `dnx` command downloads the NuGet package and runs the server directly from NuGet. On .NET 8 and .NET 9, install it as a local .NET tool by using `dotnet tool install Syncfusion.Blazor.MCP`. For more information about running .NET tools, see [dotnet tool exec](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-exec) and [local tools](https://learn.microsoft.com/en-us/dotnet/core/tools/local-tools-how-to-use) in the Microsoft documentation.

The server requires a Syncfusion® [API key](https://www.syncfusion.com/account/api-key) and an active Syncfusion® license. A commercial license, the Free Community License, or a free trial is accepted. Once connected, the `search_docs` tool provides component documentation, code snippets, and configuration examples. Your assistant can call it automatically, or you can call it directly in a prompt:

```
#search_docs How do I enable paging and sorting in the Blazor Grid?
```

You can also configure the MCP Server with the [Syncfusion® .NET CLI](https://blazor.syncfusion.com/documentation/dotnet-cli/configure-mcp).

### Prompt Library

The [Prompt Library](./prompt-library) contains short prompts for common tasks, such as enabling paging and sorting, exporting data, and troubleshooting a component. Copy a prompt, adjust it for your scenario, and run it through the MCP Server.

### Agentic UI Builder

The Agentic UI Builder generates complete pages and dashboards from a description of the interface. It selects suitable Syncfusion® components, applies a theme such as Tailwind 3, Bootstrap 5.3, Material 3, or Fluent 2, and asks for confirmation before it inserts code into your project. It installs through the Agent Package Manager (APM). See the [Agentic UI Builder](https://blazor.syncfusion.com/documentation/agentic-ui-builder) documentation for prerequisites and installation steps.

### WebMCP

WebMCP serves a different purpose from the other experiences. The MCP Server and Skills help an assistant **write** code in your IDE. WebMCP lets an agent in the browser **operate** a component that is already running in your application. It is built on an experimental browser API and currently works only in Chromium-based browsers. For more information, see [Getting started with WebMCP](https://blazor.syncfusion.com/documentation/webmcp/getting-started) and [Security and best practices](https://blazor.syncfusion.com/documentation/webmcp/security).

## Benefits

* **Documentation grounding.** The MCP Server and Skills supply Syncfusion® specific guidance, which reduces suggestions based on outdated or generic information.
* **Component and API discovery.** Ask the assistant about components, features, and events in plain language instead of searching the documentation manually.
* **Consistent guidance.** Skills stored in your project give every developer on the team the same patterns.
* **Faster UI creation.** The Agentic UI Builder produces complete layouts, which you can then refine.
* **No usage limits.** Syncfusion® provides unlimited access to the MCP Server with no limits on requests, tools, queries, or duration.
* **Privacy.** The MCP Server tools do not access your project files, and your prompts are not stored or used to train models.

N> The final code is produced by the AI model that you select. Always review AI-generated code before you use it in production.

## Choose a workflow

| Goal | Recommended experience |
|---|---|
| Ask how to use a component, feature, or event | MCP Server (`search_docs`) |
| Troubleshoot a component in your project | MCP Server (`search_docs`) |
| Start from a tested prompt for a common task | Prompt Library |
| Give your whole team the same implementation patterns | Skills |
| Generate a full page, dashboard, or form | Agentic UI Builder |
| Let a browser agent operate a running component | WebMCP |

### How the experiences work together

* **Skills and the MCP Server.** Skills provide patterns that are stored with your project. The MCP Server provides documentation retrieved when you ask. You can use both in the same IDE.
* **Agentic UI Builder and Skills.** The Agentic UI Builder works with Syncfusion® Blazor component skills. If a generated component does not render correctly, the Agentic UI Builder documentation recommends retrying the generation with the specific component skill.
* **Prompt Library and the MCP Server.** The prompts in the library are written for use with the MCP Server.

## Practical examples

### Ask about a component feature

With the MCP Server connected, describe the task and name the component:

```
#search_docs Create a Syncfusion Blazor Grid with paging, sorting, and filtering enabled.
```

### Add a feature to an existing component

```
#search_docs How can I add PDF and Excel export options to my existing Grid's toolbar?
```

### Troubleshoot an issue

```
#search_docs Why aren't my Schedule events displaying or saving correctly?
```

### Generate a complete interface

After you install the Agentic UI Builder, select the `syncfusion-blazor-ui-builder` agent in your IDE and describe the interface:

```
Create a login page with the Tailwind 3 theme using a centered card layout containing email and password input fields with validation. Include a "Remember Me" checkbox, a forgot password link, and a primary login button.
```

### Use skills for everyday tasks

After you install Skills, prompts such as the following load the matching skill automatically:

```
Add a DataGrid with paging, sorting, and filtering.
```

## Get accurate results

* **Be specific.** Include the platform and the component, for example "Create a Syncfusion Blazor Grid with paging and filtering".
* **Provide context.** Include the versions, expected behavior, and constraints that apply.
* **Use descriptive prompts.** Avoid short or ambiguous requests.
* **Start a new chat for a new topic.** This keeps the context clean.
* **Limit active MCP tools.** Fewer active tools in your IDE reduce tool-selection ambiguity.
* **Use a capable model.** The documentation recommends Claude Sonnet 4.5 or higher for the MCP Server. Other compatible models include GPT-5 and Gemini 3 Pro. For the Agentic UI Builder, the documentation recommends Claude Sonnet 4.6 or higher.
* **Check the API reference.** Verify generated property and event names in the [Syncfusion Blazor API reference](https://help.syncfusion.com/cr/blazor).

## Troubleshooting

| Issue | Solution |
|---|---|
| MCP server failed to start | Verify that .NET SDK 8.0 or later is installed, check the JSON syntax of the configuration file, and restart your IDE. |
| Invalid API key | Verify that your key is active on the [API Key page](https://www.syncfusion.com/account/api-key). |
| Incorrect API key configuration | If you use a file path, verify the file location and content. If you use an inline key, verify that the key is correct. |
| Wrong configuration file location | Use `.vscode/mcp.json` for VS Code, `.codestudio/mcp.json` for Code Studio, and `.cursor/mcp.json` for Cursor, all in the workspace root. |
| Cannot find the cause of an MCP error | Open the Output panel and select **MCP** in VS Code or Code Studio. In Cursor, open the Developer Console. |
| Agentic UI Builder skills do not load | Confirm that the `.agent/` and `.github/agents/` folders exist and that APM installed the skill. Confirm that the correct agent is selected in your IDE. |
| Syncfusion® license banner appears in generated applications | Use the licensing skill to register and validate your Syncfusion® license key. |
| WebMCP tools are not registered | See the [WebMCP FAQ](https://blazor.syncfusion.com/documentation/webmcp/faq). |

## Quick reference

| If you want to | Use | Start here |
|---|---|---|
| Get answers and code for a component | MCP Server | [MCP Server](https://blazor.syncfusion.com/documentation/mcp) |
| Keep Syncfusion® patterns in your project | Skills | [Skills](https://blazor.syncfusion.com/documentation/skills) |
| Reuse proven prompts | Prompt Library | [Prompt Library](./prompt-library) |
| Build a full UI from a description | Agentic UI Builder | [Agentic UI Builder](https://blazor.syncfusion.com/documentation/agentic-ui-builder) |
| Let a browser agent operate a component | WebMCP | [WebMCP](https://blazor.syncfusion.com/documentation/webmcp/overview) |
| Set up with a command-line tool | Syncfusion® .NET CLI | [Syncfusion® .NET CLI](https://blazor.syncfusion.com/documentation/dotnet-cli/overview) |
| Track changes to these tools | Release notes | [Release notes](https://blazor.syncfusion.com/documentation/ai-tools/release-notes) |

## See also

* [Getting Started with the AI Coding Assistant](./getting-started)
* [Syncfusion Blazor components documentation](https://blazor.syncfusion.com/documentation/introduction)
* [Syncfusion Blazor API reference](https://help.syncfusion.com/cr/blazor)
* [Model Context Protocol](https://modelcontextprotocol.io/docs/2026-07-28/getting-started/intro)
