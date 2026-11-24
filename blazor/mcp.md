---
layout: post
title: Syncfusion Blazor MCP Server | AI Coding Assistant
description: Accelerate Blazor development with the Syncfusion Blazor MCP Server. Access documentation, APIs, code snippets, and release history directly in your AI-powered IDE.
platform: Blazor
control: Syncfusion Blazor MCP Server
documentation: ug
---

# Syncfusion Blazor MCP Server

Syncfusion<sup style="font-size:70%">&reg;</sup> MCP Server accelerates Blazor application development by providing deep knowledge directly in your AI-powered IDE. [Model Context Protocol](https://modelcontextprotocol.io/) (MCP) integration enables quick access to documentation, [API references](https://help.syncfusion.com/cr/blazor), and code-generation features from within the development environment.

These tools speed up development and reinforce best practices for Syncfusion component integration.

> The previously available **Agentic UI Builder** (`#sf_blazor_ui_builder`) has been upgraded to an **Agent skill-based experience** and is no longer part of the MCP Server. To learn more about the new **Agentic UI Builder**, see the [Agentic UI Builder documentation](https://blazor.syncfusion.com/documentation/agentic-ui-builder). The **AI Coding Assistant** (`#sf_blazor_assistant`) has been **renamed** to **search_docs** (`#search_docs`) to ensure the tool name follows MCP naming conventions.

## Key Benefits

- **Expert Component Knowledge** - Deep understanding of [145+ Blazor components](https://www.syncfusion.com/blazor-components) and their implementation patterns.
- **Unlimited Usage** - No request limits, time restrictions, or query caps.
- **Privacy-Focused** - The tools operate based on the user's query and do not store any content, data, or prompts.

## Installation

### Prerequisites

Before beginning, ensure the following prerequisites are met:

- Microsoft [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later
- A **compatible MCP client** (VS Code, Syncfusion<sup style="font-size:70%">&reg;</sup> Code Studio, Cursor, JetBrains, etc.)
- An active [Syncfusion<sup style="font-size:70%">&reg;</sup> API key](https://www.syncfusion.com/account/api-key)
- A **Blazor application** (existing or new). See [Quick Start](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
- An active Syncfusion<sup style="font-size:70%">&reg;</sup> license (any of the following):
  - [Commercial License](https://www.syncfusion.com/sales/pricing?category=ui-components)
  - [Free Community License](https://www.syncfusion.com/products/communitylicense)
  - [Free Trial](https://www.syncfusion.com/account/manage-trials/start-trials)

### Getting Your API Key

Generate the Syncfusion<sup style="font-size:70%">&reg;</sup> API key from the [API Key page](https://www.syncfusion.com/account/api-key) and store it in a `.txt` or `.key` file. The saved file will be referenced in the MCP configuration:

````json
"env": {
  "Syncfusion_API_Key_Path": "D:\\syncfusion-key.txt"
}
````

> Alternatively, the API key can also be set directly using `"Syncfusion_API_Key": "YOUR_API_KEY"` in the env configuration. Using a file path is recommended to keep the key out of source control.

### Setting Up in MCP Clients

Create a configuration file in your project folder to configure the server for your workspace. **Replace `YOUR_API_KEY_FILE_PATH` with the path to your API key file.** The tabs below show a working configuration for each supported MCP client.

**For .NET 10 and .NET 11** :

> `dnx` is used in .NET 10 to execute .NET tools directly from NuGet without requiring a prior installation. It automatically downloads and starts the [Syncfusion.Blazor.MCP](https://www.nuget.org/packages/Syncfusion.Blazor.MCP) NuGet package when first used.

{% tabs %}
{% highlight bash tabtitle="VS Code" %}

// Create a `.vscode/mcp.json` file in your workspace:

{
  "servers": {
    "sf-blazor-mcp": {
      "type": "stdio",
      "command": "dnx",
      "args": ["Syncfusion.Blazor.MCP", "--yes"],
      "env": {
        "Syncfusion_API_Key_Path": "YOUR_API_KEY_FILE_PATH"
        // or
        // "Syncfusion_API_Key": "YOUR_API_KEY"
      }
    }
  }
}

// After creating or updating the file:
// 1. Save the file.
// 2. Open the Command Palette (Ctrl+Shift+P or Cmd+Shift+P on macOS).
// 3. Run: Developer: Reload Window
// The MCP client automatically resolves and starts the configured server.

{% endhighlight %}
{% highlight bash tabtitle="Code Studio" %}

// Create a `.codestudio/mcp.json` file in your workspace:

{
  "servers": {
    "sf-blazor-mcp": {
      "type": "stdio",
      "command": "dnx",
      "args": ["Syncfusion.Blazor.MCP", "--yes"],
      "env": {
        "Syncfusion_API_Key_Path": "YOUR_API_KEY_FILE_PATH"
        // or
        // "Syncfusion_API_Key": "YOUR_API_KEY"
      }
    }
  }
}

// After creating the file, click Start in the inline action to install the server.

{% endhighlight %}
{% highlight bash tabtitle="Cursor" %}

// Create a `.cursor/mcp.json` file in your workspace:

{
  "mcpServers": {
    "sf-blazor-mcp": {
      "command": "dnx",
      "args": ["Syncfusion.Blazor.MCP", "--yes"],
      "env": {
        "Syncfusion_API_Key_Path": "YOUR_API_KEY_FILE_PATH"
        // or
        // "Syncfusion_API_Key": "YOUR_API_KEY"
      }
    }
  }
}

{% endhighlight %}
{% highlight bash tabtitle="JetBrains" %}

// Open AI Assistant chat, type /, and select Add Command.
// Click ➕ Add on the MCP settings page.
// Choose STDIO and select JSON configuration:

{
  "mcpServers": {
    "sf-blazor-mcp": {
      "command": "dnx",
      "args": ["Syncfusion.Blazor.MCP", "--yes"],
      "env": {
        "Syncfusion_API_Key_Path": "YOUR_API_KEY_FILE_PATH"
        // or
        // "Syncfusion_API_Key": "YOUR_API_KEY"
      }
    }
  }
}

// Click OK, then click Apply to register the MCP server.

{% endhighlight %}
{% endtabs %}

**For .NET 8 / .NET 9 (using a local tool):**

You can install the [Syncfusion.Blazor.MCP](https://www.nuget.org/packages/Syncfusion.Blazor.MCP) NuGet package as a local tool without a global installation. For guidance on installing and managing local .NET tools, refer to the [.NET tools documentation](https://learn.microsoft.com/en-us/dotnet/core/tools/local-tools-how-to-use).

1. If the project does not already have a tool manifest, create one in the project root:

    ````bash
    dotnet new tool-manifest
    ````

    This generates a `dotnet-tools.json` file that tracks local .NET tools for the workspace.

2. Install the `Syncfusion.Blazor.MCP` NuGet package locally:

    ````bash
    dotnet tool install Syncfusion.Blazor.MCP
    ````

3. Configure the MCP client by creating or updating `.vscode/mcp.json`:

    ````json
    {
      "servers": {
        "sf-blazor-mcp": {
          "type": "stdio",
          "command": "dotnet",
          "args": ["tool", "run", "syncfusion-blazor-mcp"],
          "env": {
            "Syncfusion_API_Key_Path": "YOUR_API_KEY_FILE_PATH"
            // or
            // "Syncfusion_API_Key": "YOUR_API_KEY"
          }
        }
      }
    }
    ````

4. Save the file and reload the IDE window to start the server.

### Verifying Server Discovery

To verify that the MCP server is recognized by VS Code:

1. Open the Command Palette (`Ctrl+Shift+P` or `Cmd+Shift+P` on macOS).
2. Run:

    ```text
    MCP: List Servers
    ```

    or

    ```text
    MCP: Show Installed Servers
    ```

3. Confirm that `sf-blazor-mcp` appears in the list of configured MCP servers.

> **Tip:** In VS Code, MCP servers are managed through these commands. If `sf-blazor-mcp` is listed, the server configuration has been successfully recognized. Proceed to the validation step below to confirm active communication.

### Handling MCP Permission Prompts

When running an MCP tool like `search_docs` for the first time in a session, your IDE may prompt for permission to execute the tool:

```text
Allow tool from sf-blazor-mcp?

Options:
• Allow in this Session
• Skip
```

This prompt is expected MCP security behavior. Select **Allow in this Session** to proceed and allow the AI assistant to retrieve documentation and code guidance from the Syncfusion Blazor MCP server.

### Validating MCP Server Functionality

After configuring the server, validate that the MCP server processes queries and returns accurate Syncfusion guidance:

1. Open your AI assistant chat window in the IDE.
2. Run the following prompt using the `search_docs` tool:

    ```text
    #search_docs Create a Syncfusion Blazor Grid with paging, sorting, and filtering enabled.
    ```

3. Confirm the following expected behavior:
    - The `search_docs` tool is invoked by the assistant.
    - An MCP permission prompt appears (if running for the first time). Select **Allow in this Session**.
    - Syncfusion-specific component code, configuration properties, and usage guidance are returned.
    - Tool activity in the chat confirms that `sf-blazor-mcp` is being actively queried.

## Common use cases

The examples below showcase how the `search_docs` tool handles real-world Blazor development scenarios. The tool can be invoked directly, as shown in the examples below, for specific needs. Alternatively, an AI assistant can automatically invoke it based on the request.

**Get Started**

Use `search_docs` to get contextual guidance, code snippets, and configuration examples for any component.

{% promptcards %}
{% promptcard Grid with Paging & Sorting %}
#search_docs Create a Syncfusion Blazor Grid with paging, sorting, and filtering enabled.
{% endpromptcard %}
{% endpromptcards %}

{% promptcards %}
{% promptcard RichTextEditor Setup %}
#search_docs How do I set up the Syncfusion Blazor RichTextEditor with a custom toolbar and form integration?
{% endpromptcard %}
{% endpromptcards %}

**Implement Features**

Get step-by-step help for adding specific features to components that are already in the project.

{% promptcards %}
{% promptcard Grid Export %}
#search_docs How can I add PDF and Excel export options to my existing Grid's toolbar?
{% endpromptcard %}
{% endpromptcards %}

{% promptcards %}
{% promptcard Kanban Features %}
#search_docs How do I enable drag-and-drop and swimlane grouping in the Kanban component?
{% endpromptcard %}
{% endpromptcards %}

**Troubleshooting**

Describe the problem in plain language, and let `search_docs` help resolve it.
{% promptcards %}
{% promptcard Grid Issues %}
#search_docs Why isn't my Grid loading or rendering data correctly?
{% endpromptcard %}
{% endpromptcards %}

{% promptcards %}
{% promptcard Schedule Issues %}
#search_docs Why aren't my Schedule events displaying or saving correctly?
{% endpromptcard %}
{% endpromptcards %}

## Best Practices

To get the most out of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MCP Server:

- **Be Specific** - Include the platform and component in your queries (for example, *"Create a Syncfusion Blazor Grid with paging and filtering"*).
- **Provide Context** - Include applicable versions, expected outcomes, and any requirements or limitations that may affect the request.
- **Use Descriptive Queries** - Avoid overly brief or ambiguous requests. Providing sufficient detail helps improve the accuracy and relevance of the response.
- **Stay Consistent** - Keep file organization, naming conventions, and coding standards consistent throughout your Blazor project.
- **Start Fresh for New Topics** - Begin a new chat when switching to a different component or task to maintain clean context.
- **Use Advanced AI Models** - For best results, use **Claude Sonnet 4.5 or higher**. Other compatible models include **GPT-5 and Gemini 3 Pro**. Higher-capability models produce more accurate component implementations.
- **For Troubleshooting** - Use AI suggestions for common issues. Consult the [official documentation](https://blazor.syncfusion.com/documentation/introduction) or [support](https://support.syncfusion.com/support/tickets/create) for complex problems.
- **Minimize Active Tools** - Limit the number of active MCP tools in your IDE to prevent tool-selection ambiguity and improve response accuracy.

> Always review AI-generated code before using it in production.

## Troubleshooting

### Manual MCP Server Validation

If the MCP server fails to start or connect in your IDE, manually test package restore and startup by running the [Syncfusion.Blazor.MCP](https://www.nuget.org/packages/Syncfusion.Blazor.MCP) NuGet package with `dnx` in your terminal:

```bash
dnx Syncfusion.Blazor.MCP --yes
```

Expected startup output:

```text
Application started. Press Ctrl+C to shut down.
```

This verifies that the package resolves and downloads from NuGet and that the MCP server executable starts without errors. Press `Ctrl+C` to terminate the process after verification.

### Common Issues and Solutions

The table below lists frequently encountered issues and suggested resolutions to help diagnose and address common setup or usage challenges.

| Issue | Solution |
|-------|----------|
| **Server failed to start** | Update to .NET 8 SDK or higher, verify JSON syntax in the config file, and restart your IDE. Run `dnx Syncfusion.Blazor.MCP --yes` in a terminal to verify NuGet package restore and startup. |
| **Invalid API key** | Verify your key is active at the [Syncfusion Account Page](https://www.syncfusion.com/account/api-key). |
| **Incorrect API key config** | For the file path: verify file location and content. For inline key: check the key is correctly updated. |
| **Wrong config file location** | VS Code: `.vscode/mcp.json` • CodeStudio: `.codestudio/mcp.json` • Cursor: `.cursor/mcp.json` in the workspace root. |
| **Check IDE logs** | VS Code / CodeStudio: Output panel → "MCP" • Cursor: Developer Console for MCP errors. |

## Privacy & Security

The Syncfusion<sup style="font-size:70%">&reg;</sup> MCP Server is designed with privacy considerations:

* The tools process requests according to the user's query without storing any content or prompts.
* User prompts are not stored or used for other purposes.
* Prompts are not used to train Syncfusion models.
* The assistant provides context, and the final output is produced by the selected AI model.

The MCP Server acts purely as a knowledge bridge, connecting your AI model with Syncfusion-specific expertise while respecting your privacy and maintaining security.

## See Also

- [Blazor Agent Skills for AI Assistants](https://blazor.syncfusion.com/documentation/skills)
- [Agentic Blazor UI Builder Skill for AI Assistants](https://blazor.syncfusion.com/documentation/agentic-ui-builder)