---
layout: post
title: Preventing Cross-Site Scripting (XSS) in Blazor Apps | Syncfusion
description: Protect Blazor components from XSS using built‑in sanitization, server-side validation, and essential security best practices.
platform: Blazor
control: Common
documentation: ug
---

# Preventing Cross-Site Scripting (XSS) in Blazor Applications

## Overview

[Cross-Site Scripting (XSS)](https://developer.mozilla.org/en-US/docs/Web/Security/Attacks/XSS) is one of the most common security vulnerabilities in web applications. It occurs when attackers inject malicious scripts or markup into an application, causing untrusted content to execute in the user’s browser with the same privileges as the application.

This guide explains how to protect [Blazor components](https://www.syncfusion.com/blazor-components) from XSS attacks. It covers built-in client-side sanitization, required server-side validation, and safe usage guidelines for components that handle user-generated content.

## How to prevent XSS attacks?

Protecting your application from XSS requires using several layers of defense.

### 1. Output encoding

Blazor automatically turns special characters in user input into safe, readable text. For example, a `<script>` tag will appear as visible text on the page instead of running as code.

Use `@userInput` whenever you want to safely display text on the page. Only use `MarkupString` when the HTML has already been sanitized on the server.

{% tabs %}
{% highlight razor %}

<h3>Output Encoding Example</h3>

<div class="mb-3">
    <strong>SAFE - Blazor automatically encodes:</strong>
    <p>@userInput</p>
</div>

<div class="mb-3">
    <strong>UNSAFE - Bypasses encoding:</strong>
    <p>@((MarkupString)userInput)</p>
</div>

@code {
    private string userInput = "<b>Bold</b> <script>alert('XSS')</script>";
}

{% endhighlight %}
{% endtabs %}

### 2. Input validation

Validating user input as soon as it is received helps prevent harmful content, such as `<script>` tags, from being stored or shared with other users. This early safety check helps stop malicious data before it reaches deeper parts of your application.

Follow these practices when validating input.

- Always validate on the server side, not just the client side.
- Set maximum length limits for every input field.
- Use strong typing along with data annotation attributes.
- Block input that clearly contains suspicious or harmful content.
- For file uploads, verify the file type, file size, and actual file content before processing.

{% tabs %}
{% highlight c# %}

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
            return new ValidationResult(ErrorMessage ?? "Content contains potentially unsafe script tags.");

        if (s.IndexOf("onerror=", StringComparison.OrdinalIgnoreCase) >= 0 ||
            s.IndexOf("onload=",  StringComparison.OrdinalIgnoreCase) >= 0 ||
            s.IndexOf("javascript:", StringComparison.OrdinalIgnoreCase) >= 0)
            return new ValidationResult(ErrorMessage ?? "Content contains potentially unsafe script tags.");

        return ValidationResult.Success;
    }
}

{% endhighlight %}
{% endtabs %}

### 3. HTML sanitization

HTML sanitization is required when an application allows rich HTML content to be submitted, such as through a rich text editor. Sanitization removes unsafe elements and attributes while preserving a limited set of explicitly allowed formatting tags (for example, `<p>`, `<b>`, `<br>`). Any tag or attribute not in the allow list is removed to prevent script execution. 

Sanitize all HTML before storing it in the database and again before rendering it. This defense‑in‑depth approach ensures consistent protection even if rendering logic, usage scenarios, or content sources change, and it applies equally to application input and external data sources.

#### Built-in sanitization in Blazor components

The [EnableHtmlSanitizer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_EnableHtmlSanitizer) property is available in the **[Blazor BlockEditor](https://www.syncfusion.com/blazor-components/blazor-block-editor)**, **[Blazor File Manager](https://www.syncfusion.com/blazor-components/blazor-file-manager)**, and **[Blazor RichTextEditor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor)** components. It provides built-in client-side XSS protection.

#### How EnableHtmlSanitizer works?

When `EnableHtmlSanitizer` is enabled (it is `true` by default), the sanitizer does the following:

1. Removes `<script>` tags and their content.
2. Removes event handler attributes such as `onclick`, `onerror`, and `onload`.
3. Blocks unsafe protocols such as `javascript:` and `data:`.
4. Neutralizes other potentially dangerous HTML elements.
5. Preserves safe formatting tags (`<p>`, `<b>`, `<i>`, `<ul>`, etc.).

N> Client-side sanitization alone cannot fully secure your application. The `EnableHtmlSanitizer` property helps with basic HTML cleanup and improves safety, but server-side sanitization is still required to properly protect your application.

#### Why client-side sanitization is not enough?

1. **Bypass potential** - Attackers can disable JavaScript or modify requests before they reach the server.
2. **No database protection** - Even if the UI blocks harmful HTML, attackers can still send malicious content that gets stored in your database.
3. **API vulnerability** - API calls made directly to the backend skip all client-side checks.
4. **Zero trust principle** - Client-side validation should never be trusted as a complete security measure.

#### When to use EnableHtmlSanitizer?

- To catch accidental HTML and improve the user experience.
- To provide an extra layer of defense on top of server-side sanitization.
- To give immediate feedback without waiting for a server round trip.

#### When not to use EnableHtmlSanitizer?

- As the only security mechanism in your app.
- As a replacement for server-side sanitization.

#### BlockEditor with EnableHtmlSanitizer

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.BlockEditor

<SfBlockEditor Blocks="@BlocksData" EnableHtmlSanitizer="true"></SfBlockEditor>

<button class="e-btn e-primary" @onclick="ShowContent">Show Sanitized Content</button>

@if (!string.IsNullOrEmpty(SafeContent))
{
    <div>
        <h5>Sanitized Output:</h5>
        <pre>@SafeContent</pre>
    </div>
}

@code {
    private string SafeContent { get; set; } = string.Empty;

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
                    Content = "<p>Safe content</p><script>alert('XSS');</script>"
                }
            }
        }
    };

    private void ShowContent()
    {
        // EnableHtmlSanitizer removes <script> tags automatically
        SafeContent = BlocksData[0].Content[0].Content;
    }
}

{% endhighlight %}
{% endtabs %}

### Safe HTML rendering in data components

Components that display user-generated or database content, such as **[Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** and **[Blazor ListView](https://www.syncfusion.com/blazor-components/blazor-listview)**, should follow the same security approach. HTML content must be rendered only after it has been sanitized on the server, while plain text can be displayed safely using Blazor’s built‑in automatic encoding.

#### Rendering user content safely

Templates allow you to customize how data is displayed by controlling the HTML structure and content presentation within components. When rendering user-generated content in templates, apply the encoding and sanitization principles covered earlier.

The following examples demonstrate recommended practices for displaying user content securely. They show how improper handling can lead to security risks and how using sanitized HTML or safely encoded plain text ensures content is rendered securely without exposing the application to XSS vulnerabilities.

#### UNSAFE – direct HTML rendering

The example below shows a scenario that should never be used. It renders raw HTML from the data source using `MarkupString`, which bypasses Blazor’s HTML encoding.

If the content includes malicious scripts, it can lead to XSS attacks.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Comments" AllowPaging="true">
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

@code {
    private List<Comment> Comments = new()
    {
        new() { Id = 1, Content = "<script>alert('XSS!')</script>" }
    };

    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}

{% endhighlight %}
{% endtabs %}

#### SAFE – sanitized MarkupString (pre-sanitized data)

When HTML content is sanitized on the server or during data preparation and stored in a dedicated property, rendering it with `MarkupString` is acceptable.

The example below uses a `SanitizedContent` property that contains only trusted, pre‑sanitized HTML. Cast to `MarkupString` only when you can guarantee the content has been properly sanitized and comes from a trusted source.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Comments" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="@nameof(Comment.Author)" HeaderText="Author" Width="150" />
        <GridColumn HeaderText="Comment" Width="400">
            <Template Context="comment">
                @((MarkupString)((Comment)comment).SanitizedContent)
            </Template>
        </GridColumn>
        <GridColumn Field="@nameof(Comment.CreatedAt)" HeaderText="Date" Width="150" Format="d" />
    </GridColumns>
</SfGrid>

@code {
    private List<Comment> Comments = new();

    protected override void OnInitialized()
    {
        Comments = new List<Comment>
        {
            new()
            {
                Id = 1,
                Author = "John Doe",
                Content = "<p>Safe content</p><script>alert('XSS')</script>",
                SanitizedContent = "<p>Safe content</p>",
                CreatedAt = DateTime.Now.AddDays(-2)
            },
            new()
            {
                Id = 2,
                Author = "Jane Smith",
                Content = "<img src='x' onerror='alert(1)' /><b>Text</b>",
                SanitizedContent = "<b>Text</b>",
                CreatedAt = DateTime.Now
            }
        };
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string SanitizedContent { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

#### Text-only rendering

If HTML formatting is not required, render the content as plain text. Blazor automatically encodes all special characters, ensuring no injected scripts can execute regardless of what the data source contains.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Comments" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="@nameof(Comment.Content)" HeaderText="Comment">
            <Template Context="comment">
                @((comment as Comment)?.Content ?? string.Empty)
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private List<Comment> Comments = new()
    {
        new() { Id = 1, Content = "<script>alert('XSS')</script> Plain text" }
    };

    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
{% endhighlight %}
{% endtabs %}

#### ListView with custom templates

The same safe rendering rules apply to ListView when displaying user-generated content.

The following example conditionally renders content based on whether the message contains HTML. When `IsHtml` is `true`, only pre-sanitized content stored in `SanitizedContent` is rendered as markup. Otherwise, plain text is displayed using Blazor's automatic encoding. This keeps all messages safe regardless of their format.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Lists

<SfListView DataSource="@Messages">
    <ListViewFieldSettings TValue="ChatMessage" Text="Content" Id="Id" />
    <ListViewTemplates TValue="ChatMessage">
        <Template Context="message">
            <div>
                <strong>@message.Sender</strong> - @message.Timestamp.ToShortTimeString()
                <div>
                    @if (message.IsHtml)
                    {
                        @((MarkupString)message.SanitizedContent)
                    }
                    else
                    {
                        @message.Content
                    }
                </div>
            </div>
        </Template>
    </ListViewTemplates>
</SfListView>

@code {
    private List<ChatMessage> Messages = new()
    {
        new() { Id = "1", Sender = "Alice", Content = "Plain text", IsHtml = false, Timestamp = DateTime.Now },
        new() { Id = "2", Sender = "Bob", SanitizedContent = "<p>HTML</p>", IsHtml = true, Timestamp = DateTime.Now }
    };

    public class ChatMessage
    {
        public string Id { get; set; } = string.Empty;
        public string Sender { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string SanitizedContent { get; set; } = string.Empty;
        public bool IsHtml { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Server-side sanitization (authoritative)

Server-side sanitization is the **authoritative and required** defense against XSS attacks. While client-side sanitization, such as the **RichTextEditor built‑in HTML sanitizer**, adds an extra layer of protection, only server-side validation can be fully trusted. All user-generated HTML must be sanitized on the server before it is saved to the database and again when it is retrieved for display.

### Built-in .NET sanitization support

.NET includes several built-in APIs that support safe HTML encoding and sanitization. In most scenarios, you do not need extra libraries.

| Namespace | Class | Purpose |
|---|---|---|
| `System.Text.Encodings.Web` | `HtmlEncoder` | Encode all HTML special characters |
| `System.Text.RegularExpressions` | `Regex` | Strip disallowed tags and attributes |
| `System.Web` | `HttpUtility.HtmlEncode` | Encode HTML in non-web contexts |

### Server-side sanitization example

The following example demonstrates server-side sanitization of user‑entered HTML submitted from the [Blazor RichTextEditor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) component. The sanitization process removes script tags, embedded script content, disallowed HTML elements, inline event handler attributes, and unsafe URL protocols before the content is processed or stored.

{% tabs %}
{% highlight c# tabtitle="~/Services/HtmlSanitizerService.cs"  %}

using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text.Encodings.Web;

namespace BlazorApp.Services;

public class HtmlSanitizerService
{
    // List of allowed safe HTML tags. Any tag not in this list is removed.
    private static readonly string[] AllowedTags =
    {
        "p", "br", "strong", "em", "u", "b", "i", "ul", "ol", "li"
    };

    public string Sanitize(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        var allowList = new HashSet<string>(AllowedTags, StringComparer.OrdinalIgnoreCase);

        // Remove HTML comments, script and style blocks completely.
        string result = Regex.Replace(input, @"<!--[\s\S]*?-->", string.Empty, RegexOptions.IgnoreCase);
        result = Regex.Replace(result, @"<script\b[^>]*>[\s\S]*?</script>", string.Empty, RegexOptions.IgnoreCase);
        result = Regex.Replace(result, @"<style\b[^>]*>[\s\S]*?</style>", string.Empty, RegexOptions.IgnoreCase);

        // Pattern to match tags: groups => (closing?)(tagName)(attributes)
        string tagPattern = @"<\s*(\/?)\s*([a-z0-9]+)([^>]*)>";
        result = Regex.Replace(result, tagPattern, match =>
        {
            var isClosing = !string.IsNullOrEmpty(match.Groups[1].Value);
            var tagName = match.Groups[2].Value;
            var attrText = match.Groups[3].Value;
            if (!allowList.Contains(tagName))
                return string.Empty;
            if (isClosing)
                return $"</{tagName}>";

            // Extract attributes and keep only safe ones (href/src) after protocol checks.
            var keptAttrs = new List<string>();
            string attrPattern = @"([a-z0-9\-]+)\s*=\s*(['""])(.*?)\2|([a-z0-9\-]+)\s*=\s*([^\s>]+)";
            foreach (Match a in Regex.Matches(attrText, attrPattern, RegexOptions.IgnoreCase))
            {
                string name = a.Groups[1].Success ? a.Groups[1].Value : a.Groups[4].Value;
                string value = a.Groups[3].Success ? a.Groups[3].Value : a.Groups[5].Value;
                if (string.IsNullOrEmpty(name))
                    continue;

                // Remove any event handler attributes (onclick, onerror, etc.).
                if (name.StartsWith("on", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Note: Keep href/src handling for future <a>/<img> support because it blocks unsafe protocols such as javascript: and data:
                if (name.Equals("href", StringComparison.OrdinalIgnoreCase) ||
                    name.Equals("src", StringComparison.OrdinalIgnoreCase))
                {
                    var trimmed = value.Trim();
                    if (Regex.IsMatch(trimmed, @"^\s*(javascript:|data:)", RegexOptions.IgnoreCase))
                        continue;

                    // Encode attribute value to prevent injections.
                    var encoded = HtmlEncoder.Default.Encode(trimmed);
                    keptAttrs.Add($"{name}=\"{encoded}\"");
                }

                // All other attributes are discarded for safety.
            }

            var attrString = keptAttrs.Count > 0 ? " " + string.Join(" ", keptAttrs) : string.Empty;
            return $"<{tagName}{attrString}>";
        }, RegexOptions.IgnoreCase);

        return result.Trim();
    }
    public string EncodePlainText(string input)
    {
        // Encodes text to prevent any possibility of HTML execution.
        return HtmlEncoder.Default.Encode(input ?? string.Empty);
    }
}

{% endhighlight %}
{% highlight c# tabtitle="~/Models/Comment.cs" %}

namespace BlazorApp.Models;

public class Comment
{
    // Stores the raw user input after HTML encoding for safe display.
    public string RawInput { get; set; } = string.Empty;

    // Stores the sanitized HTML content after server-side processing.
    public string SanitizedHtml { get; set; } = string.Empty;
}

{% endhighlight %}
{% highlight razor tabtitle="~/SanitizerDemo.razor" %}

@page "/sanitize-demo"
@rendermode InteractiveServer
@using BlazorApp.Services
@using BlazorApp.Models
@using Syncfusion.Blazor.RichTextEditor
@inject HtmlSanitizerService SanitizerService

<h3>Server-Side Sanitization Demo</h3>

<SfRichTextEditor @bind-Value="@InputText" Height="200px"
                  EnableHtmlSanitizer="true">
</SfRichTextEditor>

<button class="btn btn-primary mt-3" @onclick="Process">Sanitize</button>

@if (Comment != null)
{
    <h4 class="mt-4">Raw Input (encoded for safety):</h4>
    <pre>@Comment.RawInput</pre>

    <h4>Sanitized Output (safe HTML rendered):</h4>
    <div style="padding:10px; border:1px solid #ccc">
        @((MarkupString)Comment.SanitizedHtml)
    </div>
}

@code {
    private string InputText = string.Empty;
    private Comment? Comment;

    private void Process()
    {
        // Encodes the raw content and sanitizes the HTML content.
        Comment = new Comment
        {
            RawInput = SanitizerService.EncodePlainText(InputText),
            SanitizedHtml = SanitizerService.Sanitize(InputText)
        };
    }
}

{% endhighlight %}
{% highlight c# tabtitle="Program.cs" %}

...
using Syncfusion.Blazor;
using BlazorApp.Services;
...
// Registers the sanitizer service for dependency injection.
builder.Services.AddSingleton<HtmlSanitizerService>();
// Required to enable all Syncfusion Blazor components.
builder.Services.AddSyncfusionBlazor();
...

{% endhighlight %}
{% endtabs %}

## See also

* [Cross-site scripting (XSS) prevention in Block Editor](https://blazor.syncfusion.com/documentation/block-editor/editor-security/cross-site-script)
* [Content Security Policy in Blazor components](https://blazor.syncfusion.com/documentation/common/content-security-policy)