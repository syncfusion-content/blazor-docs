---
layout: post
title: Input Sanitization with Syncfusion Blazor Components
description: Discover effective techniques for securely sanitizing user input in Syncfusion Blazor components to protect your application from unsafe data.
platform: Blazor
control: Common
documentation: ug
---

# Input Sanitization in Syncfusion® Blazor Components

## What is input sanitization?

**Input sanitization** is the process of filtering and cleaning HTML content from untrusted sources. It removes unsafe tags (like `<script>`), inline scripts (JavaScript code embedded directly in HTML attributes), event handlers (such as `onclick`), and dangerous URLs (malicious JavaScript links). Only safe and valid markup is preserved.

## Why input sanitization is important?

Blazor applications often accept text input, file uploads, dialog content, and query parameters. Users may intentionally or accidentally submit HTML or script content. This content can execute unexpectedly when rendered as HTML.

If untrusted content is rendered as HTML, it can:

* Execute malicious JavaScript
* Alter UI layout or behavior
* Leak sensitive data
* Inject unauthorized markup into components

Sanitizing user input ensures that only safe and expected values are stored or displayed.

## Types of attacks

| Attacks | Description | Prevention |
|--------|-------------|------------|
| Cross-Site Scripting (XSS) | Malicious scripts are injected and execute in the user’s browser. <br> Example: `<script>alert('XSS');</script>` | HTML sanitization is enabled by default in Syncfusion components such as the RTE. For plain text inputs, use HTML encoding. <br>Example: `HtmlEncoder.Default.Encode()`.|
| HTML Injection | Unwanted markup can change layout or behavior by introducing unexpected HTML elements, styles, or attributes.<br> Example: Injecting unexpected `<div>`, `<style>`, `<iframe>` or risky attributes. | The built‑in sanitizer removes unsafe tags and attributes and helps avoid rendering raw HTML from untrusted sources. |

## Built-in sanitization features

Several [Syncfusion Blazor components](https://www.syncfusion.com/blazor-components) include HTML sanitization capabilities to prevent harmful scripts or unsafe markup from being rendered. Components that accept or display HTML content such as the [Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor), [Block Editor](https://www.syncfusion.com/blazor-components/blazor-block-editor) have built-in `EnableHtmlSanitizer` property to remove unsafe elements before rendering.

Components such as [Tooltip](https://www.syncfusion.com/blazor-components/blazor-tooltip), [Toast](https://www.syncfusion.com/blazor-components/blazor-toast), and [Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog) apply sanitization when rendering HTML content in templates. For [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), HTML encoding should be applied explicitly when rendering user-provided content. This ensures that any user provided HTML is safe.

In the example shown, the sanitizer removes embedded scripts and event based attacks to prevent malicious code execution. It strips `<script>` tags, inline event handlers, JavaScript URLs, and dangerous elements like `<iframe>` or `<object>` to ensure that only safe HTML is displayed.

```cshtml
<!-- User input -->
<script>alert('XSS')</script>

<!-- Sanitized output -->
(No script content is rendered; output is empty or sanitized text)

```

### Rich Text Editor (RTE)

The [Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) allows users to input and render HTML content. To prevent unsafe markup from being inserted or displayed, enable the built-in sanitizer using the [EnableHtmlSanitizer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableHtmlSanitizer) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableHtmlSanitizer="true" @bind-Value="Content"></SfRichTextEditor>

@code {

 private string Content { get; set; } =
        "<p>Welcome</p><img src=x onerror=\"alert('xss')\"><script>alert('XSS')</script>";

}

{% endhighlight %}
{% endtabs %}

When the `EnableHtmlSanitizer` property is enabled, the Rich Text Editor automatically removes unsafe tags and attributes before rendering the content.

### Block Editor

The [Block Editor](https://www.syncfusion.com/blazor-components/blazor-block-editor) allows users to create structured content such as paragraphs, headings, lists, quotes, images, and links. Since user generated content may include HTML like input or potentially unsafe markup, enable the built-in sanitizer using the [EnableHtmlSanitizer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_EnableHtmlSanitizer) property to ensure only safe content is rendered.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.BlockEditor

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
                    Content = "<div onmouseover='javascript:alert(1)'>Prevention of Cross-Site Scripting (XSS) </div> <script>alert('hi')</script>"
                }
            }
        }
    };
}

{% endhighlight %}
{% endtabs %}

When the `EnableHtmlSanitizer` property is enabled, the Block Editor automatically removes unsafe tags and attributes before rendering content. This includes unsafe tags such as `<script>`, unsafe attributes such as `onload` and `onclick`, as well as JavaScript URLs and other potentially harmful markup. This ensures that only clean and trusted HTML remains in the editor output.

## How to sanitize input in Blazor?

When you only need to display plain text (not HTML), the safest approach is to HTML encode user input. Encoding converts characters like `<`, `>`, and `&` into harmless text representations so the browser will not interpret them as HTML or scripts. This ensures that even if the user enters malicious markup, it is displayed as text, not executed.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using System.Text.Encodings.Web

<p>@encoded</p>

@code {
    string userInput = "<script>alert('XSS')</script> Hello!";
    string encoded = HtmlEncoder.Default.Encode(userInput);
}

{% endhighlight %}
{% endtabs %}

**Output:**

```c#

&lt;script&gt;alert(&#x27;XSS&#x27;)&lt;/script&gt; Hello!

```

Displaying the encoded text ensures it is treated as plain text.

## Component specific guidelines

### DataGrid

The [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) can render HTML when using templates or when column values include markup. User provided values should be sanitized before being added to the data source.

The following example demonstrates sanitizing text before binding it to the DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using System.Text.Encodings.Web

<div class="input-row">
    <SfTextBox @bind-Value="UserText" Placeholder="Enter text" CssClass="w-100"></SfTextBox>
    <SfButton CssClass="e-primary" OnClick="ProcessInput" Type="Button">
        Submit
    </SfButton>
</div>

<div class="mt-2">
    <SfGrid @ref="UserGrid" DataSource="@Items" AllowPaging="true">
        <GridColumns>
            <GridColumn Field="Content" HeaderText="User Content" Width="200"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code {
    public string UserText { get; set; } = string.Empty;
    public List<ItemRecord> Items { get; set; } = new();
    private SfGrid<ItemRecord> UserGrid;

    private void ProcessInput()
    {
        var cleaned = HtmlEncoder.Default.Encode(UserText);
        Items.Add(new ItemRecord { Content = cleaned });
        UserGrid.Refresh();
    }

    public class ItemRecord
    {
        public string Content { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

You can explore a working example of encoded DataGrid content in the Syncfusion Blazor Playground.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBdDKiCUIgKSIYz?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2"  %}

## See also

* [Blazor Content Security Policy (CSP)](https://blazor.syncfusion.com/documentation/common/content-security-policy)
* [Blazor Rich Text Editor Paste Clean-up](https://blazor.syncfusion.com/documentation/rich-text-editor/paste-cleanup)
* [Blazor Block Editor Paste Clean-up](https://blazor.syncfusion.com/documentation/block-editor/paste-cleanup)
