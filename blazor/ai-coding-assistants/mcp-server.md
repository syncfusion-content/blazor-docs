---
layout: post
title: SyncfusionBlazorAssistant MCP Server | Syncfusion
description: Learn how to configure and use SyncfusionBlazorAssistant MCP server for intelligent code generation, documentation, and troubleshooting in Blazor apps.
control: Getting started with SyncfusionBlazorAssistant MCP Server
platform: Blazor
documentation: ug
---

# SyncfusionBlazorAssistant MCP Server

## Overview

The [SyncfusionBlazorAssistant](https://www.npmjs.com/package/@syncfusion/blazor-assistant) is a specialized [Model Context Protocol (MCP)](https://modelcontextprotocol.io/docs/getting-started/intro) server that provides intelligent assistance for developers using Syncfusion's Blazor component libraries. This tool seamlessly integrates with compatible [MCP clients](https://modelcontextprotocol.io/clients) to enhance your development workflow when building Blazor applications with Syncfusion<sup style="font-size:70%">&reg;</sup> components.

### Key Benefits

* Intelligent code generation for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.
* Detailed component documentation and usage examples.
* Troubleshooting assistance for common integration challenges.

## Prerequisites

Before using [SyncfusionBlazorAssistant](https://www.npmjs.com/package/@syncfusion/blazor-assistant), ensure you have:

* Required [node](https://nodejs.org/en/) version >= 18
* A [compatible MCP client](https://modelcontextprotocol.io/clients) (VS Code with GitHub Copilot, [Syncfusion<sup style="font-size:70%">&reg;</sup> CodeStudio](https://www.syncfusion.com/code-studio/), etc.)
* An active Syncfusion<sup style="font-size:70%">&reg;</sup> license (any of the following):
  - [Commercial License](https://www.syncfusion.com/sales/unlimitedlicense)
  - [Free Community License](https://www.syncfusion.com/products/communitylicense)
  - [Free Trial](https://www.syncfusion.com/account/manage-trials/start-trials)
* An active [API KEY](https://syncfusion.com/account/api-key)

## Unlimited Access

Syncfusion<sup style="font-size:70%">&reg;</sup> offers unlimited access to this MCP server. There are no restrictions on:

* Number of requests
* Components usage
* Query types
* Usage duration

This ensures users can fully leverage Syncfusion<sup style="font-size:70%">&reg;</sup> components to enhance their development experience without limitations.

## Installation and setup

Before you can invoke the `SyncfusionBlazorAssistant` MCP server, you need to configure your MCP client with these core settings. The **Generic MCP Server Settings** shown below are identical across all clients:

### Generic MCP Server Settings

- **npm package name**: `@syncfusion/blazor-assistant`
- **Type**: stdio (standard input/output transport)
- **Command**: npx
- **Arguments**: -y
- **Server name**: syncfusionBlazorAssistant

You need to add your [Syncfusion API key](https://syncfusion.com/account/api-key) as an env parameter in the configuration file:

```json
"env": {
  "Syncfusion_API_Key": "YOUR_API_KEY"
}
```

[SyncfusionBlazorAssistant](https://www.npmjs.com/package/@syncfusion/blazor-assistant) can be configured in various MCP clients. Below are setup instructions for popular environment:

### Syncfusion<sup style="font-size:70%">&reg;</sup> Code Studio

* In [Code Studio](https://www.syncfusion.com/code-studio/), open MCP Marketplace, find `SyncfusionBlazorAssistant`, and click Install.
* When prompted, enter your [Syncfusion API key](https://syncfusion.com/account/api-key) and click Submit to register.
* It installs locally on your machine and appears in the Installed list.
* The server is ready for use in Code Studio.

For additional details, see the Code Studio [documentation](https://help.syncfusion.com/code-studio/reference/configure-properties/mcp/marketplace).

### VS Code (GitHub Copilot MCP)

1. To configure an MCP server for a specific workspace, you can create a `.vscode/mcp.json` file in your workspace folder.

```json
{
  "servers": {
    "syncfusion-blazor-assistant": {
      "type": "stdio",
      "command": "npx",
      "args": [
        "-y",
        "@syncfusion/blazor-assistant@latest"
      ],
      "env": {
        "Syncfusion_API_Key": "YOUR_API_KEY"
      }
    }
  }
}
```

2. After updating the configuration in settings.json, you'll notice a "Start" option at the top of the config. This allows you to easily start the [SyncfusionBlazorAssistant](https://www.npmjs.com/package/@syncfusion/blazor-assistant) server directly from the settings interface without additional commands.

3. Confirm that [SyncfusionBlazorAssistant](https://www.npmjs.com/package/@syncfusion/blazor-assistant) is being used (this does not happen automatically). Look for a statement in the output, which is similar to:
    * `SyncfusionBlazorAssistant is running...` (in VS Code)

### Visual Studio (GitHub Copilot MCP)

* To configure an MCP server for a specific workspace, you can create a `.vs/mcp.json` file in your workspace folder.

```json
{
  "servers": {
    "syncfusion-blazor-assistant": {
      "type": "stdio",
      "command": "npx",
      "args": [
        "-y",
        "@syncfusion/blazor-assistant@latest"
      ],
      "env": {
        "Syncfusion_API_Key": "YOUR_API_KEY"
      }
    }
  }
}
```

* After updating the mcp.json configuration, open the GitHub Copilot Chat window. Click the Ask arrow, then select Agent.
* Select the [SyncfusionBlazorAssistant](https://www.npmjs.com/package/@syncfusion/blazor-assistant) from the tools section.
* For more details, refer to the official [Visual Studio documentation](https://learn.microsoft.com/en-us/visualstudio/ide/mcp-servers?view=vs-2022).


### Cursor

To configure an MCP server for a specific workspace, you can create a .cursor/mcp.json file in your workspace folder.

```json
{
  "mcpServers": {
    "syncfusion-blazor-assistant": {
      "type": "stdio",
      "command": "npx",
      "args": [
        "-y",
        "@syncfusion/blazor-assistant@latest"
      ],
      "env": {
       "Syncfusion_API_Key": "YOUR_API_KEY"
      }
    }
  }
}
```

### JetBrains IDEs

1. Go to Settings -> Tools -> AI Assistant -> Model Context Protocol (MCP).
2. Click + Add to add a new MCP server configuration.
3. In the New MCP Server dialog, switch the dropdown as `As JSON` and add the following config:

```json
{
  "mcpServers": {
    "syncfusion-blazor-assistant": {
      "command": "npx",
      "args": [
        "-y",
        "@syncfusion/blazor-assistant@latest"
      ],
      "env": {
       "Syncfusion_API_Key": "YOUR_API_KEY"
      }
    }
  }
}
```

4. Click OK and Apply.

> For more detailed information about configuring MCP servers in various clients, refer to the official documentations.
  * [VS Code](https://code.visualstudio.com/docs/copilot/chat/mcp-servers#_add-an-mcp-server)
  * [Cursor](https://cursor.com/docs/context/mcp#using-mcp-json)
  * [JetBrains](https://www.jetbrains.com/help/ai-assistant/mcp.html#connect-to-an-mcp-server)
  * [Windsurf](https://docs.windsurf.com/windsurf/cascade/mcp#mcp-config-json)

## Usage

To activate the SyncfusionBlazorAssistant MCP server:

1. Start your prompt with one of the following:
    * 'SyncfusionBlazorAssistant'
    * '/syncfusion-blazor-assistant'
    * '/syncfusion-blazor'
    * '@syncfusion-blazor'
    * '@ask_syncfusion_blazor'
    * 'ej2-blazor'

   In VS Code, you can also use #SyncfusionBlazorAssistant to explicitly invoke the MCP server.

2. Grant the SyncfusionBlazorAssistant MCP server a permission to run for this session, workspace, or always.
3. For best results, start a new chat for each new topic to maintain clean context.

### Mode availability

Syncfusion<sup style="font-size:70%">&reg;</sup> MCP Servers provide full access to all AI interaction modes — Ask/Chat, Edit, and Agent — across supported MCP clients.

### Best Practices for Effective Usage

1. `Be specific`: Mention both platform and component (e.g., "How do I create a Syncfusion Blazor Grid with paging and filtering?").
2. `Provide context`: Include details about your use case for more targeted solutions.
3. `Use descriptive queries`: Avoid vague questions that lack necessary context.
4. `Start fresh for new topics`: Begin a new chat session when switching components or topics.

### Example Queries

Here are some effective ways to use [SyncfusionBlazorAssistant](https://www.npmjs.com/package/@syncfusion/blazor-assistant):

 * "Create a Syncfusion Blazor Grid component with paging, sorting and filtering"
 * "How do I implement data binding with Syncfusion Blazor scheduler?"
 * "Show me how to create a dashboard with multiple Syncfusion components"

## Troubleshooting

If you encounter issues:

 * Verify your API key is correctly configured.
 * Ensure the MCP server is enabled in your client's tools selection.
 * Check that you're using a compatible MCP client version.
 * Try restarting your development environment.

## Support

Product support is available through the following mediums.

* [Support ticket](https://support.syncfusion.com/support/tickets/create) - Guaranteed Response in 24 hours \| Unlimited tickets \| Holiday support
* [Community forum](https://www.syncfusion.com/forums/blazor-components)
* [Request feature or report bug](https://www.syncfusion.com/feedback/blazor-components)
* Live chat

## See also

* [Syncfusion Blazor Documentation](https://blazor.syncfusion.com/documentation)