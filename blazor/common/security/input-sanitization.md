---
layout: post
title: Input Sanitization in Syncfusion Blazor Components
description: Discover effective techniques for securely sanitizing user input in Syncfusion Blazor components to protect your application from unsafe data.
platform: Blazor
control: Common
documentation: ug
---

# Input Sanitization with Syncfusion Blazor Components

Input sanitization removes or neutralizes unsafe HTML elements, attributes, styles, and URL schemes from user-supplied content. In Blazor, plain strings are automatically HTML-encoded, so sanitization is primarily needed when rendering user-generated HTML (for example, Rich Text Editor output or Markdown conversion) using `MarkupString`.

This guide explains when sanitization is required, where to apply it (client vs. server), and how to implement it safely with Syncfusion Blazor components.

## When do I need sanitization?

Use this matrix to decide whether sanitization is required and the recommended actions.

| Scenario | Example | Sanitization Required? | Client Action | Server Action | Rendering Guidance |
|--|--|--|--|--|--|
| Render **plain text** | TextBox/TextArea values | No | Not applicable | Not required | Blazor auto-encodes output by default. |
| Render **user HTML** as HTML | Rich Text Editor content | Yes | Enable Paste Cleanup | Sanitize with Ganss.Xss before save/render | Use `MarkupString` **only** with server-sanitized HTML. |
| **Transform text** into HTML | Markdown → HTML | Yes | Not applicable | Sanitize generated HTML | Render sanitized HTML via `MarkupString`. |

N> Client-side cleanup is not a security boundary. Always sanitize HTML on the server before saving or rendering.

## Where to Sanitize

1. **At input time (client-side)**  
   When users paste content into the **Rich Text Editor**, enable the **Paste Cleanup** feature to filter tags, attributes, and styles immediately. This provides instant feedback and a better UX.

2. **At save time (server-side)**  
   Always perform a second, authoritative sanitization on the server before saving to the database or re-rendering. A widely used and reliable .NET library for this is **HtmlSanitizer** (`Ganss.Xss`).

## Rich Text Editor

Use **Paste Cleanup** on the client for immediate filtering, and **always sanitize again on the server** before saving or rendering content.

### Client: Paste Cleanup

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor @bind-Value="PostContent" AfterPasteCleanup="OnAfterPasteCleanup">
    <RichTextEditorPasteCleanupSettings
        Prompt="true"
        KeepFormat="true"
        DeniedTags="@DeniedTags"
        DeniedAttributes="@DeniedAttributes"
        AllowedStyleProperties="@AllowedStyles" />
</SfRichTextEditor>

@code {
    private string? PostContent = @"<p>Rich Text Editor is a WYSIWYG editing control.</p>";

    // Remove high-risk tags entirely
    private readonly string[] DeniedTags = new[] { "script", "iframe", "style", "form" };

    // Block dangerous event-handler attributes
    private readonly string[] DeniedAttributes = new[] { "onload", "onclick", "onerror", "onmouseover" };

    // Restrict inline styles to a minimal allowlist
    private readonly string[] AllowedStyles = new[] { "color", "font-size", "font-weight", "text-align", "margin", "padding" };

    private void OnAfterPasteCleanup(PasteCleanupArgs args)
    {
        // args.Value contains the cleaned HTML. This can be logged or further processed as needed.
    }
}

{% endhighlight %}
{% endtabs %}

For more details refer to:  
- [Paste Cleanup guide](https://blazor.syncfusion.com/documentation/rich-text-editor/paste-cleanup)  
- [`RichTextEditorPasteCleanupSettings` API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorPasteCleanupSettings.html)

### Server: Sanitize Before Storing or Rendering

First, install the package:

```
dotnet add package HtmlSanitizer
```

Create a central service using **HtmlSanitizer** (`Ganss.Xss`). Adjust the allow list to fit your application’s needs.

{% tabs %}
{% highlight cs %}

// Services/InputSanitization.cs
using Ganss.Xss;

public static class InputSanitization
{
    private static readonly HtmlSanitizer _sanitizer;

    static InputSanitization()
    {
        _sanitizer = new HtmlSanitizer
        {
            AllowedTags = { "p", "br", "ul", "ol", "li", "strong", "em", "b", "i", "u", "a", "span", "blockquote", "code", "pre", "h1", "h2", "h3" },
            AllowedAttributes = { "href", "title", "style", "class" },
            AllowedCssProperties = { "color", "font-size", "font-weight", "text-align", "margin", "padding" },
            AllowedSchemes = { "http", "https", "mailto" },
            UriAttributes = { "href", "src" }
        };
    }

    public static string CleanHtml(string? html)
    {
        if (string.IsNullOrWhiteSpace(html))
            return string.Empty;

        return _sanitizer.Sanitize(html);
    }
}

{% endhighlight %}
{% endtabs %}

**Rendering Sanitized HTML**

{% tabs %}
{% highlight razor %}

@* ONLY render MarkupString with server-sanitized content *@
@((MarkupString)SanitizedContent)

@code {
    [Parameter] public string SanitizedContent { get; set; } = string.Empty;
}

{% endhighlight %}
{% endtabs %}

## DataGrid

Most DataGrid cells display **plain text**, which Blazor automatically HTML-encodes so sanitization is not required. If you need to render **HTML** in a column (e.g., formatted Notes), sanitize server-side, store the sanitized version, and render via `MarkupString` in a column template.

More information: [Column template](https://blazor.syncfusion.com/documentation/datagrid/column-template)

{% tabs %}
{% highlight razor %}

<!-- SfGrid markup -->
@using Syncfusion.Blazor.Grids

<SfGrid TItem="UserRecord"
        DataSource="@Users"
        AllowPaging="true"
        Toolbar="@(new List<string> { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal" />
    <GridColumns>
        <GridColumn Field=@nameof(UserRecord.Id) HeaderText="ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="90" AllowEditing="false" />
        <GridColumn Field=@nameof(UserRecord.UserName) HeaderText="Username" Width="160">
            <EditTemplate Context="editContextItem">
                @{
                     var ctx = (UserRecord)editContextItem;
                }
                <SfTextBox @bind-Value="ctx.UserName" MaxLength="24" Placeholder="Alphanumeric/underscore only" />
            </EditTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(UserRecord.Email) HeaderText="Email" Width="220" />
        <GridColumn Field=@nameof(UserRecord.NotesHtml) HeaderText="Notes" Width="300">
            <EditTemplate Context="editNotesItem">
                @{
                    var ctx = (UserRecord)editNotesItem;
                }
                <SfRichTextEditor @bind-Value="ctx.NotesHtml"
                                  EnableHtmlSanitizer="true"
                                  Height="180px" />
            </EditTemplate>
            <Template Context="itemContext">
                @{
                    var item = (UserRecord)itemContext;
                     var sanitized = InputSanitization.CleanHtml(item?.NotesHtml);
                }
                <div title="Preview (sanitized at render)">
                    @((MarkupString)sanitized)
                </div>
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private List<UserRecord> Users = new()
    {
        new UserRecord { Id = 1, UserName = "alice_01", Email = "alice@example.com", NotesHtml = "<p>Hello</p>" },
        new UserRecord { Id = 2, UserName = "bob_02", Email = "bob@example.com", NotesHtml = "<p>Team lead</p>" }
    };
}

{% endhighlight %}
{% endtabs %}


{% tabs %}
{% highlight cs %}

// Model
public class UserRecord
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [StringLength(24, MinimumLength = 3, ErrorMessage = "Username must be 3–24 characters.")]
    [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessage = "Only letters, digits, and underscore are allowed.")]
    public string UserName { get; set; } = string.Empty;

    [Required, EmailAddress(ErrorMessage = "Enter a valid email address.")]
    [StringLength(128)]
    public string Email { get; set; } = string.Empty;

    [StringLength(2000, ErrorMessage = "Notes cannot exceed 2000 characters.")]
    public string? NotesHtml { get; set; }
}

{% endhighlight %}
{% endtabs %}

> Note: `EnableHtmlSanitizer="true"` (default) activates Syncfusion’s built-in client sanitizer, which strips dangerous elements/attributes by default. Use `DeniedSanitizeSelectors` to explicitly block additional selectors when needed.

## TextBox / TextArea

Syncfusion **TextBox** and **TextArea** components bind plain text. Sanitization applies only when rendering as HTML via `MarkupString`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs

<!-- Single-line -->
<SfTextBox @bind-Value="Title" Placeholder="Enter title" />

<br/>
<h4>Sanitized Title</h4>
<div class="border p-2">
    @((MarkupString)SanitizedTitle)  @* MarkupString: renders raw HTML *@
</div>

<br/>
<!-- Multi-line -->
<SfTextArea @bind-Value="Description" Width="200" Rows="5" Placeholder="Enter description" />

<br/>
<h4>Sanitized Description</h4>
<div class="border p-2">
    @((MarkupString)SanitizedDescription)  @* MarkupString: renders raw HTML *@
</div>

@code {
    private string Title { get; set; } = 
        @"<p onclick=""alert(1)"">This is a sanitization Text</p>";

    private string Description { get; set; } = 
        @"<p onclick=""alert(1)"">Click me</p>";

    private string SanitizedTitle => InputSanitization.CleanHtml(Title);
    private string SanitizedDescription => InputSanitization.CleanHtml(Description);
}
{% endhighlight %}
{% endtabs %}

In all scenarios where user text is converted into raw HTML output, apply the same server-side sanitization as shown earlier.

## Validation vs. Sanitization

Both are required, but they solve different problems:

- **Validation** enforces business rules and data quality (for example, required fields, length, pattern, and email format).
- **Sanitization** reduces XSS risk when content is rendered as HTML.

Validation does **not** replace sanitization, and sanitization does **not** replace validation.

## Security best practices

* Sanitize all user-supplied or generated HTML on the server before saving or rendering.
* Prefer allow-lists (allowed tags/attributes/styles) over block-lists.
* Keep your sanitization library (`Ganss.Xss`) and Syncfusion packages up to date.
* Implement Content Security Policy (CSP) headers as defense in depth. Start with a restrictive baseline and tune per app requirements.
