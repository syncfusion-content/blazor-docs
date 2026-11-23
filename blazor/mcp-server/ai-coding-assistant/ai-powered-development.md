---
layout: post
title: Overview of Syncfusion Blazor AI Coding Assistants | Syncfusion®
description: Learn about Syncfusion Blazor AI Coding Assistants, including the MCP Server, Skills, the Agentic UI Builder, and WebMCP, and find the right documentation to get started.
control: AI Coding Assistants Overview
platform: Blazor
documentation: ug
domainurl: ##DomainURL##
---

# Overview of Syncfusion® Blazor AI Coding Assistants

Syncfusion® Blazor AI Coding Assistants connect AI-powered development tools to Syncfusion® Blazor product knowledge. The assistants use this knowledge to answer questions about components, generate code, and build user interfaces with Syncfusion® Blazor components.

This page introduces each experience and directs you to the documentation for setup and usage.

## Why use AI coding assistants with Syncfusion® Blazor

Generic AI suggestions are not based on Syncfusion® product knowledge. Syncfusion® AI Coding Assistants give the AI agent access to Syncfusion®-specific guidance on component usage, APIs, and supported features:

* The [MCP Server](https://blazor.syncfusion.com/documentation/mcp) provides documentation, component guidance, and code snippets on request.
* [Skills](https://blazor.syncfusion.com/documentation/skills) provide component usage, API, and theming guidance as files that the assistant reads.

The final code is produced by the AI model that you select. Always review AI-generated code before you use it in production.

## Role of MCP

The [Model Context Protocol](https://modelcontextprotocol.io/docs/2026-07-28/getting-started/intro) (MCP) is an open protocol that connects AI applications to external tools and data sources. The Syncfusion® Blazor MCP Server uses MCP to connect an MCP-compatible IDE to Syncfusion® Blazor knowledge. When you ask a question, the assistant calls the `search_docs` tool, which returns component documentation, code snippets, and configuration examples. You can also call the tool directly in a prompt:

```
#search_docs How do I enable paging and sorting in the Blazor Grid?
```

The MCP Server is distributed as the [Syncfusion.Blazor.MCP](https://www.nuget.org/packages/Syncfusion.Blazor.MCP) NuGet package and requires a Syncfusion® [API key](https://www.syncfusion.com/account/api-key). The tools do not access your project files, and your prompts are not stored or used to train models. For prerequisites and client configuration, see the [MCP Server documentation](https://blazor.syncfusion.com/documentation/mcp).

## Available experiences

| Experience | Description | Documentation |
|---|---|---|
| **MCP Server** | Gives your IDE access to Syncfusion® Blazor documentation and code guidance through the `search_docs` tool. | [MCP Server](https://blazor.syncfusion.com/documentation/mcp) |
| **Skills** | Provides Blazor component usage, API, and theming guidance as skill files that AI agents load when they are relevant to a request. | [Skills](https://blazor.syncfusion.com/documentation/skills) |
| **Agentic UI Builder** | Transforms natural-language UI requirements into Blazor components by using an agent skill. | [Agentic UI Builder](https://blazor.syncfusion.com/documentation/agentic-ui-builder) |
| **WebMCP** | Lets a browser-based AI agent operate a running Syncfusion® Blazor component through tools that the component registers with the browser. | [WebMCP](https://blazor.syncfusion.com/documentation/webmcp/overview) |

N> The Agentic UI Builder (`#sf_blazor_ui_builder`) is no longer part of the MCP Server. It is now an agent skill-based experience. The MCP tool for documentation is named `search_docs`. See the [release notes](https://blazor.syncfusion.com/documentation/ai-tools/release-notes) for version-specific changes.

## Choose an experience

| Goal | Experience |
|---|---|
| Ask how to use a component, feature, or event | MCP Server |
| Troubleshoot a component in your project | MCP Server |
| Give the AI agent Syncfusion® Blazor component guidance stored with your project | Skills |
| Generate pages, dashboards, or forms from a description | Agentic UI Builder |
| Let an agent in the browser operate a component that is running | WebMCP |

The MCP Server and Skills are separate installations. You can install both in the same IDE. The Agentic UI Builder documentation also recommends retrying a generation with the specific component skill when a generated component does not render.

WebMCP differs from the other experiences. The MCP Server, Skills, and Agentic UI Builder help an AI agent write code in your IDE. WebMCP lets an agent operate a component in the browser. It uses an experimental browser API and currently works only in Chromium-based browsers.

## Supported IDEs and AI tools

The MCP Server works with MCP-compatible clients. The [MCP Server documentation](https://blazor.syncfusion.com/documentation/mcp) provides configuration for VS Code, Syncfusion® Code Studio, Cursor, and JetBrains. Skills work with agents and IDEs that load local skill files, such as VS Code, Cursor, and Code Studio. The Agentic UI Builder installs for GitHub Copilot, Cursor, Codex, and Claude through the Agent Package Manager (APM).

You can also use the [Syncfusion® .NET CLI](https://blazor.syncfusion.com/documentation/dotnet-cli/overview) to [configure the MCP Server](https://blazor.syncfusion.com/documentation/dotnet-cli/configure-mcp) and [install Skills](https://blazor.syncfusion.com/documentation/dotnet-cli/install-skills).

## Get accurate results

* Include the platform and the component in your prompt, for example "Create a Syncfusion Blazor Grid with paging and filtering".
* Include the versions, expected behavior, and constraints that apply.
* Start a new chat when you change to a different component or task.
* Limit the number of active MCP tools in your IDE to avoid ambiguity in tool selection.
* Use a high-capability AI model. The MCP Server documentation recommends Claude Sonnet 4.5 or higher, and also lists GPT-5 and Gemini 3 Pro as compatible models. The Agentic UI Builder documentation recommends Claude Sonnet 4.6 or higher.
* Verify property and event names in the [Syncfusion Blazor API reference](https://help.syncfusion.com/cr/blazor).

## Documentation structure

| Topic | Description |
|---|---|
| [MCP Server](https://blazor.syncfusion.com/documentation/mcp) | Prerequisites, API key setup, client configuration, usage examples, best practices, and troubleshooting. |
| [Skills](https://blazor.syncfusion.com/documentation/skills) | Install, list, update, and remove Blazor component skills. |
| [Agentic UI Builder](https://blazor.syncfusion.com/documentation/agentic-ui-builder) | Install the skill with APM and generate user interfaces. |
| [WebMCP](https://blazor.syncfusion.com/documentation/webmcp/overview) | Enable WebMCP, configure tools, and review [security guidance](https://blazor.syncfusion.com/documentation/webmcp/security), [supported components](https://blazor.syncfusion.com/documentation/webmcp/components), and the [FAQ](https://blazor.syncfusion.com/documentation/webmcp/faq). |
| [Syncfusion® .NET CLI](https://blazor.syncfusion.com/documentation/dotnet-cli/overview) | Configure the MCP Server and install Skills from the command line. |
| [Release notes](https://blazor.syncfusion.com/documentation/ai-tools/release-notes) | Changes to the MCP Server, Skills, and Agentic UI Builder. |

## Next steps

1. Install the [MCP Server](https://blazor.syncfusion.com/documentation/mcp) or [Skills](https://blazor.syncfusion.com/documentation/skills) in your IDE.
2. Ask a question about a component and review the response against the [Syncfusion Blazor documentation](https://blazor.syncfusion.com/documentation/introduction).
3. Use the [Agentic UI Builder](https://blazor.syncfusion.com/documentation/agentic-ui-builder) when you need a complete page or dashboard.

If you need help, [create a support ticket](https://support.syncfusion.com/support/tickets/create).

## See also

* [Syncfusion Blazor API reference](https://help.syncfusion.com/cr/blazor)
* [Model Context Protocol](https://modelcontextprotocol.io/docs/2026-07-28/getting-started/intro)
