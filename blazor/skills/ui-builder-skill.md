---
layout: post
title: Syncfusion® Blazor UI Builder Skill for AI Assistants | Syncfusion®
description: Install Syncfusion® Blazor UI Builder to generate production-ready Blazor components from natural-language prompts.
control: Skills
platform: Blazor
documentation: ug
---

# Syncfusion® Blazor UI Builder Skill for AI Assistants

**Syncfusion® Blazor UI Builder** is an AI-powered development companion that transforms natural-language UI descriptions into production-ready Blazor components. Built on deep knowledge of Syncfusion® component libraries and Blazor best practices, it eliminates boilerplate work and ensures consistency across your application.

## What You Can Do

- **Describe in plain language** - "Create a dashboard with cards, charts, and a data grid"
- **Get production-ready code** - Complete, tested C# components with proper styling
- **Maintain best practices** - Automatic accessibility (WCAG 2.1 AA), responsive design, and semantic HTML
- **Never leave your IDE** - Integrated directly into VS Code, Cursor, and other AI-powered editors.

## Prerequisites

Before installing Blazor UI Builder, ensure you have:

| Requirement | Details |
|---|---|
| **Agent Package Manager (APM)** | [Install APM](https://microsoft.github.io/apm/getting-started/installation/#quick-install-recommended) to manage skills and agents |
| **Node.js** | Version ≥ 18 ([Download](https://nodejs.org/en)) |
| **Blazor Application** | New or existing; see [Quick Start](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) |
| **Supported IDE** | VS Code, Cursor, Syncfusion® Code Studio, or any AI agent that reads local skills |
| **Syncfusion® License** | Choose one: [Commercial](https://www.syncfusion.com/sales/unlimitedlicense) \| [Community](https://www.syncfusion.com/products/communitylicense) \| [Free Trial](https://www.syncfusion.com/account/manage-trials/start-trials) |

## Key Benefits

| Feature | Benefit |
|---|---|
| **Complete Code Generation** | Transforms prompts into full, runnable Blazor components-not fragments or pseudo-code |
| **API Accuracy** | Uses correct Syncfusion® component APIs with all required feature modules (paging, sorting, filtering) |
| **Best Practices Built-In** | Generates code following Blazor lifecycle patterns, secure event handling, and scalable architecture |
| **Accessibility First** | WCAG 2.1 AA compliance with semantic HTML and ARIA attributes included by default |
| **Responsive Design** | Mobile-first layouts that work seamlessly on all devices |
| **Multi-Theme Support** | Works with Tailwind, Bootstrap, Material themes |

## Installation

### Step 1: Verify APM Installation

Confirm APM is installed by running:

```bash
apm --version
```

If not installed, [follow the APM installation guide](https://microsoft.github.io/apm/getting-started/installation/#quick-install-recommended).

### Step 2: Install Blazor UI Builder

Select your IDE and run the appropriate command:

{% tabs %}
{% highlight bash tabtitle="Copilot" %}

apm install syncfusion/blazor-ui-builder -t copilot

{% endhighlight %}

{% highlight bash tabtitle="Cursor" %}

apm install syncfusion/blazor-ui-builder -t cursor

{% endhighlight %}

{% highlight bash tabtitle="Claude" %}

apm install syncfusion/blazor-ui-builder -t claude

{% endhighlight %}

{% highlight bash tabtitle="Codex" %}

apm install syncfusion/blazor-ui-builder -t codex

{% endhighlight %}
{% endtabs %}

### Step 3: Verify Installation

After installation completes, confirm the following folders exist in your project:

- `.agent/skills/` - Contains the Blazor UI Builder skill files
- `.github/agents/` - Contains agent configuration for your selected IDE

> **Note:** For Syncfusion® Code Studio, use the "Copilot" command. See [APM deployment targets](https://microsoft.github.io/apm/reference/cli/targets/#detection-signals) for platform-specific details.

## Quick Start

1. **Select the agent** in your IDE: Choose `syncfusion-blazor-ui-builder` from the agent dropdown
2. **Describe your UI** in plain language: "Create a login form with email and password fields"
3. **Review the logs/information** in the chat, then confirm to insert into your project
4. **Use the generated code** - it's ready to build upon

---

## How It Works

The Blazor UI Builder follows a streamlined 8-step pipeline:

1. **Intent Analysis** - Identifies component types and layout structure from your description
2. **Project Detection** - Scans your project for framework, package manager, and existing theme configuration
3. **Component Mapping** - Selects optimal Syncfusion® components and required feature modules
4. **Theme Configuration** - Confirms CSS framework (Tailwind, Bootstrap, Material, or custom), theme variant, light/dark mode
5. **Code Generation** - Produces complete C# blazor components, interfaces, and styling scaffolding
6. **Dependency Resolution** - Identifies and recommends required packages
7. **Quality Validation** - Runs accessibility checks, security scans, and verifies API correctness
8. **Code Insertion** - Adds files to your project following your project structure and conventions

**Quality Guarantees:**
- Correct theme and CSS imports automatically included
- Only required feature modules injected (no bloat)
- Semantic HTML with ARIA and keyboard support by default
- No deprecated or unsupported APIs used
- Requests confirmation before making changes

## Using the AI Assistant

### Getting Started

1. Open your IDE (VS Code, Cursor, etc.)
2. Open the AI chat panel
3. Select the `syncfusion-blazor-ui-builder` agent from the agent dropdown

![Set Agent](images/blazor-ui-builder.png)

### Writing Effective Prompts

For best results, describe your UI with these elements:

- **What you need** (e.g., "login form", "data table", "dashboard")
- **Key features** (e.g., "with validation", "sortable and filterable", "with charts")
- **Theme preference** (optional; defaults to Fluent 2)
- **Responsive requirements** (e.g., "works on mobile and desktop")

**Good prompt:** "Create a contact form with name, email, and message fields. Include client-side validation and a submit button. Make it responsive."

**Better prompt:** "Build a product search page with a search bar, category filters on the left, and a grid showing product cards with images, names, prices, and an 'Add to Cart' button. Include sorting options and pagination."

### Example Prompts

{% promptcards %}
{% promptcard Authentication %}
Create a login page with email and password fields, a "Remember Me" checkbox, and a submit button. Include a "Forgot Password" link and a "Sign Up" link. Make it responsive with Tailwind 3.
{% endpromptcard %}
{% promptcard Status Cards %}
Build three side-by-side status cards showing Total Users, Active Sessions, and Revenue. Each card has an icon, metric value, and percentage change from last month. Use Material theme.
{% endpromptcard %}
{% promptcard Admin Dashboard %}
Create an admin dashboard with a collapsible sidebar, top AppBar, metric cards, a sortable/filterable data grid, and two charts side-by-side. Use sample data for 10-12 rows.
{% endpromptcard %}
{% promptcard E-Commerce %}
Build an e-commerce product listing page with a search bar, category filters, product grid with images and prices, add-to-cart buttons, and pagination. Use Tailwind 3 with light/dark mode toggle.
{% endpromptcard %}
{% endpromptcards %}

### Code Quality

All generated code includes:
- Accessible, semantic HTML with ARIA attributes
- Mobile-first responsive layouts
- Strong C# typing with null-safety
- Input validation and security best practices
- Proper error handling and edge cases

## Best Practices

### 1. **Model Selection**
For the best code quality and accuracy:
- Use **Claude Sonnet 4.6 or higher** (or equivalent capability models)
- Avoid legacy or smaller models for complex UI requirements

### 2. **Prompt Structure**
- **Be descriptive** - More detail = more accurate code
- **Specify constraints** - Mention responsive requirements, theme, or accessibility needs
- **Break complex UIs into parts** - Generate a dashboard in 2-3 focused prompts rather than one massive request
- **Provide context** - Mention what data the component will display or how it will be used

### 3. **Code Review & Customization**
- **Always review** generated code before committing
- **Verify API calls** - Ensure data binding matches your backend
- **Test accessibility** - Run WCAG checks with tools like Axe or Lighthouse
- **Customize styling** - Replace placeholders and adjust spacing, colors to match your brand
- **Replace mock data** - Generated data is for reference; wire up real data sources

### 4. **Asset Management**
- Replace placeholder images and icons with production assets
- Use your brand colors, fonts, and logo consistently
- Validate icons are from an accessible, licensed icon library

### 5. **Project Organization**
- Keep components organized by feature or page
- Use consistent naming conventions (`ProductCard.razor`, `ProductCard.razor.cs`)
- Extract shared utilities and constants

### 6. **Integration**
- Test generated components with your authentication and data services
- Ensure routing matches your application structure
- Validate form submissions integrate with your backend APIs

### 7. **Performance**
- Profile large data grids and tables for rendering performance
- Use virtualization for lists with 100+ items
- Lazy-load images and heavy components

### 8. **Testing**
- Write unit tests for business logic
- Test responsive layouts on real devices, not just browser zoom
- Verify keyboard navigation for interactive components

## Troubleshooting

### Installation Issues

**APM command not found**
- Verify APM is installed: `apm --version`
- If not found, [install APM](https://microsoft.github.io/apm/getting-started/installation/#quick-install-recommended) and restart your terminal
- Ensure Node.js ≥ 18 is installed: `node --version`

**Skill files not created after installation**
- Confirm installation completed without errors
- Check that `.agent/` and `.github/agents/` folders exist in your project root
- Try reinstalling: `apm install syncfusion/blazor-ui-builder -t <your-ide> --force`

### Agent & IDE Issues

**Agent dropdown doesn't show `syncfusion-blazor-ui-builder`**
- Restart your IDE completely (not just the chat panel)
- Verify `.agent/skills/` folder exists and contains skill files
- Check your IDE's skill configuration settings
- Try: Open command palette → "Reload window" (VS Code)

**Skill is selected but not responding**
- Confirm your AI model supports Skills (Claude Sonet 4.6+, GPT-4 with plugins, etc.)
- Check your API key is valid and has sufficient quota
- Try a simple test prompt: "Hello" to confirm chat is working
- Check IDE console for errors: View → Output → [Agent name]

### Code Generation Issues

**Component generates but doesn't render**
- Verify required Syncfusion® NuGet packages are installed
- Check theme and CSS imports are correctly added to your `_Host.cshtml` or main layout
- Ensure theme files (Fluent, Bootstrap, Tailwind, Material) are in your project
- Clear browser cache and rebuild: `dotnet clean && dotnet build`

**Generated code has compilation errors**
- Check C# version compatibility (code uses modern C# features)
- Ensure Syncfusion® packages match your project's target framework
- Copy any missing `using` statements from the chat output
- Try regenerating with a slightly modified prompt for different approach

**Styling looks wrong or themes don't apply**
- Verify theme CSS is linked in your layout file
- Check `package.json` includes required Syncfusion® theme packages
- Clear browser cache: Ctrl+Shift+Delete (Chrome/Edge) or Cmd+Shift+Delete (Mac)
- Inspect element to confirm CSS classes are applied

### Licensing Issues

**Syncfusion license warning banner appears**
- Register your license key in `Program.cs`:
  ```csharp
  Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("your-license-key");
  ```
- Obtain your key from [Syncfusion Account Portal](https://www.syncfusion.com/account)
- Verify key is valid and not expired

**"License has expired" message**
- Renew your license at [Syncfusion Shop](https://www.syncfusion.com/sales/products)
- Or use a [Free Trial](https://www.syncfusion.com/account/manage-trials) for development

### Getting More Help

- **Syncfusion Support**: [Support Portal](https://support.syncfusion.com/support/tickets/create)
- **APM Documentation**: [Agent Package Manager Docs](https://microsoft.github.io/apm/)
- **Blazor Component Docs**: [Syncfusion Blazor Components](https://www.syncfusion.com/blazor/documentation/introduction/)
- **GitHub Issues**: Report bugs on the [APM GitHub Repository](https://github.com/microsoft/apm)


## FAQ

### General

**What IDEs/agents are supported?**
Any AI agent that reads local skill files, including GitHub Copilot in VS Code, Cursor IDE, Syncfusion® Code Studio, Claude with local skill support, and other AI agents with Skills/Agent support.

**Is this free?**
The Blazor UI Builder skill is free to install via APM. You need a valid Syncfusion® license (commercial, community, or free trial) and an active API key for your AI platform.

**What Syncfusion® components are supported?**
All Syncfusion® Blazor components can be generated, including DataGrid, TreeGrid, Pivot Table, Charts, Scheduler, Kanban, File Manager, RichTextEditor, and many more.

### Installation & Setup

**Do I need to install packages manually?**
No. The skill recommends required NuGet packages, and many IDEs can auto-install them. You can also accept recommendations and install manually via `dotnet add package`.

**Can I use this with an existing project?**
Yes. The skill auto-detects your project structure, theme setup, and existing packages. Generated code integrates seamlessly.

**How do I uninstall the skill?**
Run: `apm uninstall syncfusion/blazor-ui-builder`

### Customization & Output

**Can I customize generated styles?**
Yes. The skill supports Tailwind, Bootstrap, Material, or custom themes. Generated components include clear CSS integration points for adjustments.

**Can I specify a theme or design system?**
Yes. Mention your preferred theme in the prompt: "Use Bootstrap 5" or "Use Material theme with dark mode." Defaults to Fluent 2 if not specified.

**Can the skill generate TypeScript/JavaScript versions?**
Currently, the skill generates C# Blazor components only. For JavaScript frameworks, consider other tools.

**Does it support responsive design?**
Yes, by default. All generated components are mobile-first and responsive. Mention specific breakpoints in your prompt if needed.

### Code Quality & Best Practices

**Is the generated code production-ready?**
Mostly yes, but always review before deploying:
- Replace mock data with real data sources
- Validate business logic matches your requirements
- Test accessibility with tools like Axe or Lighthouse
- Replace placeholder images/icons with production assets

**Does it follow C# and Blazor best practices?**
Yes. Generated code includes proper async/await patterns, null-safety, strong typing, component composition best practices, and Blazor-standard event handling.

**Will it overwrite my existing code?**
No. The skill always proposes changes and requests confirmation before modifying files. You can review and accept/reject changes.

**Can I regenerate components with different requirements?**
Yes. Simply describe the updated requirements in a new prompt and regenerate.

### Performance & Scalability

**Can it handle large datasets?**
Yes, but generation time increases with complexity. For 1000+ rows, use virtualization and ask: "Generate a virtualized data grid with pagination."

**How large can a generated component be?**
No practical limit, but very large components (20+ screens) are better split into multiple smaller components.

**Does generated code have performance overhead?**
No. Generated code is optimized and matches Syncfusion® best practices. Performance depends on your data and browser.

### Licensing & Legal

**What license does generated code have?**
Generated code belongs to you. It's not subject to any open-source license.

**Can I use this commercially?**
Yes, with a valid Syncfusion® commercial or community license. See [Syncfusion Licensing](https://www.syncfusion.com/products/communitylicense).

**Is my code sent to external servers?**
No. The skill runs locally within your IDE. Code generation uses your AI provider's API (OpenAI, Anthropic, etc.), but code is not shared with Syncfusion®.

### Troubleshooting & Support

**The skill isn't responding to my prompt**
See [Troubleshooting](#troubleshooting) section above.

**Can I request new features or report bugs?**
Yes. Report issues via:
- [Syncfusion Support Portal](https://support.syncfusion.com/)
- [APM GitHub Issues](https://github.com/microsoft/apm/issues)
- Your IDE vendor's support channel

## See also

- [Agent Skills Standards](https://agentskills.io/home)
- [Agent Package Manager](https://microsoft.github.io/apm/getting-started/quick-start/)
