---
layout: post
title: Input Sanitization in Syncfusion Blazor Components
description: Discover effective techniques for securely sanitizing user input in Syncfusion Blazor components to protect your application from unsafe data.
platform: Blazor
control: Common
documentation: ug
---

# Input Sanitization with Syncfusion Blazor Components

Input sanitization ensures that any user-provided content whether typed, pasted, uploaded, or received from external sources is safe to process or display in a Syncfusion Blazor application. Because user input can contain unsafe HTML or script content, sanitization prevents malicious code execution and ensures application integrity.

Securely validate and render user content with Syncfusion components using these guidelines.

## Why Input Sanitization is important

Blazor applications often accept text input, file uploads, dialog content, and query parameters. Users may intentionally or accidentally submit HTML or script content that may execute unexpectedly when rendered as HTML.

If untrusted content is not sanitized, it may:

* Execute malicious JavaScript
* Alter UI layout or behavior
* Leak sensitive data
* Inject unauthorized markup into components

Sanitizing user input ensures that only safe and expected values are stored or displayed.

Example:

```
Unsafe input: <img src=x onerror=alert('XSS')>
Sanitized output: x
```

## Types of Attacks Prevented

| Attack | Description | Prevention |
|--------|-------------|------------|
| **Cross-Site Scripting (XSS)** | Attackers insert JavaScript into user-generated content. If rendered as HTML, the script executes in the user's browser. Example: `<script>alert('XSS');</script>` | Enable RTE sanitizer + `HtmlEncode` plain text. |
| **HTML Injection** | Attackers insert unauthorized markup that modifies page appearance or user experience. Example: `<iframe src="phish-site.com"></iframe>` (embeds phishing form for credential theft). | Remove unsafe tags/attributes via sanitization. |

Both attacks rely on causing the application to interpret malicious markup as legitimate HTML. Sanitization removes unsafe tags, attributes, or scripts to prevent such vulnerabilities.

## Built-In Sanitization Features

Several Syncfusion Blazor components include HTML sanitization capabilities to prevent harmful script or markup from being processed. Components that accept or render HTML content such as the Rich Text Editor have built-in mechanisms to remove unsafe elements before rendering.

The sanitizer removes the following unsafe content:

* `<script>` tags
* Inline event handlers (onclick, onload)
* JavaScript URLs (javascript:)
* `<iframe>`, `<object>` unless configured otherwise

### Rich Text Editor (RTE)

The Rich Text Editor allows users to input and render HTML content. To prevent unsafe markup from being inserted or displayed, enable the built‑in sanitizer using the `EnableHtmlSanitizer` property.

{% tabs %}
{% highlight razor %}

<SfRichTextEditor EnableHtmlSanitizer="true">
</SfRichTextEditor>

{% endhighlight %}
{% endtabs %}

When enabled, automatically removes unsafe tags and attributes such as `<script>` tags, event attributes (such as onload, onclick), and other unsafe content before rendering it. This ensures only clean and safe HTML is allowed in the editor.

## How to Sanitize Input in Blazor

For plain-text scenarios, encoding special characters prevents browsers from interpreting the content as HTML:

```
var safeText = System.Net.WebUtility.HtmlEncode(userInput);
```

Displaying the encoded text ensures it is treated as plain text.

## Component-Specific Guidelines

### DataGrid

The DataGrid can render HTML when using templates or when column values include markup. User provided values should be sanitized before being added to the data source. 

The following example demonstrates sanitizing text before binding it to the Grid:

{% tabs %}
{% highlight razor %}

@page "/sanitize-example"

<SfTextBox @bind-Value="UserText" Placeholder="Enter text"></SfTextBox>

<SfButton CssClass="e-primary" OnClick="ProcessInput">
    Submit
</SfButton>

<SfGrid DataSource="Items" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="Content" HeaderText="User Content" Width="200"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public string UserText { get; set; } = string.Empty;

    public List<ItemRecord> Items { get; set; } = new();

    private void ProcessInput()
    {
        var cleaned = System.Net.WebUtility.HtmlEncode(UserText);
        Items.Add(new ItemRecord { Content = cleaned });
    }

    public class ItemRecord
    {
        public string Content { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

The encoded value ensures the Grid displays safe text without interpreting any malicious input.

## See Also

[Paste Clean-up in Blazor Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/paste-cleanup)
