---
layout: post
title: Blazor Agent Skills for AI Assistants | Syncfusion®
description: Learn how to install and use Agent Skills to enhance AI assistants with accurate Blazor component guidance.
platform: Blazor
control: Skills
documentation: ug
---

# Blazor Agent Skills for AI Assistants

This guide introduces **Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Agent Skills**, a knowledge package that enables AI assistants such as Visual Studio Code, Cursor, and Code Studio to understand and generate accurate Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor code using official APIs, patterns, and theming guidelines.

Blazor Agent Skills reduce common issues with generic AI suggestions by grounding the assistant in accurate Syncfusion<sup style="font-size:70%">&reg;</sup> component usage patterns, API structures, supported features, and project-specific configuration.

## Prerequisites

Before installing Blazor Agent Skills, make sure you have the following:

- [Node.js](https://nodejs.org/en/) 22.20 or later. The [Skills CLI](https://github.com/vercel-labs/skills) requires this version to install and manage Syncfusion Blazor Skills.
- A Blazor application, either existing or new. To create one, see [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app).
- An AI agent or IDE that supports Agent Skills, such as [Visual Studio Code](https://code.visualstudio.com/docs/agent-customization/agent-skills), [Syncfusion<sup style="font-size:70%">&reg;</sup> Code Studio](https://boldcreate.ai/solutions/agent-skills), or [Cursor](https://cursor.com/docs/skills).

## Installation

Install [Blazor components skills](https://github.com/syncfusion/blazor-ui-components-skills) using the Skills CLI. You can also browse the available skills in the [Syncfusion<sup style="font-size:70%">&reg;</sup> listing on skills.sh](https://www.skills.sh/syncfusion).

If you use the Syncfusion<sup style="font-size:70%">&reg;</sup> .NET CLI, you can install the same skills with the `sfdotnet skills install` command. For details, see [Install AI component skills](https://blazor.syncfusion.com/documentation/dotnet-cli/install-skills).

### Install all skills

Use the following command to install all component skills without interactive prompts:

{% tabs %}
{% highlight bash tabtitle="NPM" %}

npx skills add syncfusion/blazor-ui-components-skills -y

{% endhighlight %}
{% endtabs %}

### Install selected skills

Use the following command to install skills interactively:

{% tabs %}
{% highlight bash tabtitle="NPM" %}

npx skills add syncfusion/blazor-ui-components-skills

{% endhighlight %}
{% endtabs %}

The terminal will display a list of available skills. Use the arrow keys to navigate, the space bar to select the desired skills, and the Enter key to confirm.
{% tabs %}
{% highlight bash tabtitle="CMD" %}

 Select skills to install (space to toggle)
│  ◻ syncfusion-blazor-accumulation-chart (Implement Blazor Accumulation Chart component...)
│  ◻ syncfusion-blazor-ai-assistview
│  ◻ syncfusion-blazor-charts
│  ◻ syncfusion-blazor-datagrid
│  ◻ syncfusion-blazor-diagram
│  ◻ syncfusion-blazor-file-manager
│  ◻ syncfusion-blazor-gantt-chart
│  ◻ syncfusion-blazor-pivot-table
│  ◻ syncfusion-blazor-rich-text-editor
│  ◻ syncfusion-blazor-scheduler
|  .....

{% endhighlight %}
{% endtabs %}

Next, select the AI agents you use. The CLI stores the skills in the skills directory of each selected agent.
{% tabs %}
{% highlight bash tabtitle="CMD" %}

│  ── Additional agents ──
│  Search:
│  ↑↓ move, space select, enter confirm
│
│ ❯ ○ Augment (.augment/skills)
│   ○ Claude Code (.claude/skills)
│   ○ OpenClaw (skills)
│   ○ CodeBuddy (.codebuddy/skills)
│   ○ Command Code (.commandcode/skills)
│   ○ Continue (.continue/skills)
│   ○ Cortex Code (.cortex/skills)
│   ○ Crush (.crush/skills)
|   ....

{% endhighlight %}
{% endtabs %}

Choose the installation scope, then confirm to complete the installation. Project scope installs the skills in the current project so they can be committed and shared with your team. Global scope makes them available in all projects.

{% tabs %}
{% highlight bash tabtitle="CMD" %}

◆  Installation scope
│  ● Project (Install in current directory (committed with your project))
│  ○ Global

◆  Proceed with installation?
│  ● Yes / ○ No

{% endhighlight %}
{% endtabs %}

After installation, your AI assistant can discover the skills and load them when a request matches.

## Verify the installation

Confirm that the skills are installed and that your AI assistant uses them.

1. Run the following command to list the installed skills:

   {% tabs %}
   {% highlight bash tabtitle="NPM" %}

   npx skills list

   {% endhighlight %}
   {% endtabs %}

   The output includes the `syncfusion-blazor-*` skills you selected. Use `npx skills list -g` to list global skills.

2. Open the AI assistant in your IDE and confirm that the skills are discovered. In Visual Studio Code, type `/` in the chat input to see the available skills. For details, see [Use skills as slash commands](https://code.visualstudio.com/docs/agent-customization/agent-skills#_use-skills-as-slash-commands).
3. Ask a question that matches a skill, for example, "Add a Syncfusion Blazor Scheduler with week view." Agents can load a skill when the request matches its description.
4. Review the agent activity in the chat. Some agents, such as GitHub Copilot in Agent mode, show entries similar to the following when a skill is loaded:

   {% tabs %}
   {% highlight bash tabtitle="CMD" %}

   Read skill syncfusion-blazor-scheduler

   {% endhighlight %}
   {% endtabs %}

N> The activity text depends on the agent and its version. Installing a skill makes it available but does not guarantee that the agent selects it for every request. If no skill is shown, rephrase the prompt to mention the component by name.

## What’s included

1. **Component Usage & API Knowledge** - Curated guidance that explains how to add, configure, and compose Syncfusion® [Blazor components](https://www.syncfusion.com/blazor-components), including key parameters, events, services to register (where applicable), and common integration patterns for Blazor Server, WebAssembly, Web App, and MAUI environments.
2. **Patterns & Best Practices** - Practical recommendations for component configuration, data binding approaches, and feature‑implementation workflows (for example, paging, sorting, filtering, editing, and validation for data components). The guidance is authored directly in the skill files and is not fetched from the documentation at run time.
3. **Design‑System Guidance** - Includes information related to themes, styling customization, and Syncfusion® Blazor component best practices across different application types.

## How Syncfusion<sup style="font-size:70%">&reg;</sup> Agent Skills Work

1. **Reads relevant skill files based on queries**, retrieving component usage patterns, APIs, and best‑practice guidance from the installed Blazor Agent Skills. The assistant initially loads only skill names and descriptions, then dynamically loads the required skill and reference files as needed to provide accurate Syncfusion guidance.
2. **Enforces Syncfusion<sup style="font-size:70%">&reg;</sup> best practices**, including:

   - Using the required [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) for each component, for example, [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) for the DataGrid.
   - Registering applicable component dependencies in `Program.cs`.
   - Adding the correct theme and script imports.
   - Implementing proper data binding patterns for Blazor Server/WebAssembly/Web App.
3. **Generates component‑accurate code**, avoiding invalid parameters or unsupported patterns. For the full API reference, see the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor API documentation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.html).

### Using the AI Assistant

Once skills are installed, the assistant can be used to generate and update Syncfusion® Blazor code for tasks such as:

- "Add a DataGrid with paging, sorting, and filtering."
- "Create a Scheduler with week view and drag‑drop capabilities."
- "Implement file upload with chunk upload and validation."
- "Build a rich text editor with custom toolbar tools."
- "Add a calendar with event scheduling."
- "Apply a theme and enable dark mode."

## Skills CLI Commands

After installation, manage Syncfusion<sup style="font-size:70%">&reg;</sup> Agent Skills using the following commands:

### List Skills

View all installed skills in your current project or global environment:

{% tabs %}
{% highlight bash tabtitle="NPM" %}

npx skills list

{% endhighlight %}
{% endtabs %}

### Remove a Skill

Uninstall a specific skill from your environment:

{% tabs %}
{% highlight bash tabtitle="NPM" %}

npx skills remove <skill-name>

{% endhighlight %}
{% endtabs %}

Replace `<skill-name>` with the name of the skill you want to remove (for example, `syncfusion-blazor-datagrid`).

### Check for Updates

Check whether updates are available for your installed skills. As described in the [Skills CLI reference](https://github.com/vercel-labs/skills/blob/main/docs/commands.md#skills-check), this command checks for updates without reinstalling skills. It also reports project skills whose files differ from the entry in `skills-lock.json`.

{% tabs %}
{% highlight bash tabtitle="NPM" %}

npx skills check

{% endhighlight %}
{% endtabs %}

### Update All Skills

Update all installed skills to their latest versions. The CLI asks for the scope unless you use the `-g` (global), `-p` (project), or `-y` (detect the scope automatically) option:

{% tabs %}
{% highlight bash tabtitle="NPM" %}

npx skills update

{% endhighlight %}
{% endtabs %}

To update a single skill, pass its name, for example, `npx skills update syncfusion-blazor-datagrid`.

N> After you run `npx skills remove`, confirm the result with `npx skills list`. A removed skill no longer appears in the list.

## FAQ

**Which agents and IDEs are supported?**

Any agent or IDE that supports Agent Skills and loads local skill files, such as Visual Studio Code, Cursor, and Code Studio. The Skills CLI lists its supported agents in the [supported agents reference](https://github.com/vercel-labs/skills/blob/main/docs/agents.md).

**Are skills loaded automatically?**

Generally yes. Supported agents read the skill names and descriptions and load a skill when your request matches its description. No additional configuration is required. To confirm that a skill was used, see [Verify the installation](#verify-the-installation).

**Skills are not being loaded**

Try the following steps:

1. Run `npx skills list` and confirm that the skill is installed in the expected scope, project or global.
2. Confirm that the skill is installed in the directory of the agent you use.
3. Confirm that the agent supports Agent Skills. See the documentation of your agent for the supported skill directories.
4. Restart the IDE.
5. Mention the component by name in your prompt, for example, "Syncfusion Blazor DataGrid".

**The Skills CLI fails to run**

Check the installed Node.js version with `node --version`. The Skills CLI requires Node.js 22.20 or later.

## See also

- [Syncfusion Blazor Agentic UI Builder](https://blazor.syncfusion.com/documentation/agentic-ui-builder)
- [Syncfusion Blazor MCP Server](https://blazor.syncfusion.com/documentation/mcp)
- [Agent Skills Standards](https://agentskills.io/home)
- [Skills CLI documentation](https://www.skills.sh/docs)
