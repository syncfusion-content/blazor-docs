---
layout: post
title: Input Sanitization with Syncfusion Blazor Components
description: Discover effective techniques for securely sanitizing user input in Syncfusion Blazor components to protect your application from unsafe data.
platform: Blazor
control: Common
documentation: ug
---

# Input Sanitization in Syncfusion Blazor Components

## What is Input Sanitization?

**Input sanitization** is the process of filtering and cleaning HTML content from untrusted sources. It removes unsafe tags (like `<script>`), inline scripts (JavaScript code embedded directly in HTML attributes), event handlers (such as onclick), and dangerous URLs (malicious 'javascript:' links). Only safe and valid markup is preserved.

For plain text inputs, this often means HTML encoding to escape special characters, preventing interpretation as markup.

## Why Input Sanitization is important?

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
| **Cross-Site Scripting (XSS)** | Malicious scripts are injected (e.g., event attributes like onclick, or javascript: URLs) and execute in the user’s browser. Example: `<script>alert('XSS');</script>` | HTML sanitization is enabled by default in Syncfusion components like RTE; use HTML encoding (e.g., `HtmlEncoder.Default.Encode()`) for plain-text inputs.|
| **HTML Injection** | Unwanted markup changes layout or behavior (e.g., injecting unexpected `<div>`, `<style>`, or risky attributes). Example: `<iframe src="phish-site.com"></iframe>`. | Built-in sanitizer removes unsafe tags/attributes; avoid rendering raw HTML from untrusted sources. |

## Built-in sanitization features

Several Syncfusion Blazor components include HTML sanitization capabilities to prevent harmful script or markup from being processed. Components that accept or render HTML content such as the [Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor), [Block Editor](https://www.syncfusion.com/blazor-components/blazor-block-editor) have built-in `EnableHtmlSanitizer` property to remove unsafe elements before rendering. Components like [Tooltip](https://www.syncfusion.com/blazor-components/blazor-tooltip), [Toast](https://www.syncfusion.com/blazor-components/blazor-toast), and [Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog) automatically apply sanitization when rendering HTML templates. For [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), manual encoding is recommended for user-provided content. This ensures that any user provided HTML is safe.

In the example shown, the sanitizer removes embedded scripts and event based attacks to prevent malicious code execution. It strips `<script>` tags, inline event handlers, JavaScript URLs, and dangerous elements like `<iframe>` or `<object>` to ensure that only safe HTML is displayed.

{% tabs %}
{% highlight razor %}
<!-- User input -->
<script>alert('XSS')</script>

<!-- Sanitized output -->
(Empty or safe text only)

{% endhighlight %}
{% endtabs %}

### Rich Text Editor (RTE)

The Rich Text Editor allows users to input and render HTML content. To prevent unsafe markup from being inserted or displayed, enable the built-in sanitizer using the `EnableHtmlSanitizer` property.

{% tabs %}
{% highlight razor tabtitle="index.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableHtmlSanitizer="true" @bind-Value="Content"></SfRichTextEditor>

@code {
   
 private string Content { get; set; } =
        "<p>Welcome</p><img src=x onerror=\"alert('xss')\"><script>alert('XSS')</script>";

}

{% endhighlight %}
{% endtabs %}

When the `EnableHtmlSanitizer` property is enabled, the Rich Text Editor automatically removes unsafe tags and attributes before rendering the content.

**Disabling the EnableHtmlSanitizer**

To disable the built-in sanitizer (not recommended for untrusted content), set the property to `false`:

{% tabs %}
{% highlight razor tabtitle="index.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EnableHtmlSanitizer="false" ></SfRichTextEditor>

{% endhighlight %}
{% endtabs %}

### Block Editor

The Block Editor allows users to create structured content such as paragraphs, headings, lists, quotes, images, and links. Since user-generated content may include HTML-like input or potentially unsafe markup, enable the built-in sanitizer using the `EnableHtmlSanitizer` property to ensure only safe content is rendered.

{% tabs %}
{% highlight razor tabtitle="index.razor" %}

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
                    Content = "<div onmouseover='javascript:alert(1)'>Prevention of Cross-Site Scripting (XSS) </div> <script>alert('hi')</script>"
                }
            }
        }
    };
}

{% endhighlight %}
{% endtabs %}

When the `EnableHtmlSanitizer` property is enabled, the Block Editor automatically removes unsafe tags and attributes such as `<script>` tags, event attributes (like onload, onclick), javascript: URLs, and other harmful markup before rendering content. This ensures that only clean and trusted HTML remains in the editor output.

**Disabling the EnableHtmlSanitizer**

To disable the built-in sanitizer (not recommended for untrusted input), set the property to false:

{% tabs %}
{% highlight razor tabtitle="index.razor" %}

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor  EnableHtmlSanitizer="false"></SfBlockEditor>
</div>

{% endhighlight %}
{% endtabs %}
    
## How to sanitize input in Blazor

When you only need to display plain text (not HTML), the safest approach is to HTML encode user input. Encoding converts characters like <, >, and & into harmless text representations so the browser will not interpret them as HTML or scripts. This ensures that even if the user enters malicious markup, it is displayed as text, not executed.

{% tabs %}
{% highlight razor tabtitle="index.razor" %}

@using System.Text.Encodings.Web

<p>@encoded</p>  

@code {
    string userInput = "<script>alert('XSS')</script> Hello!";
    string encoded = HtmlEncoder.Default.Encode(userInput);
}

{% endhighlight %}
{% endtabs %}

**Output:**

{% tabs %}
{% highlight bash %}

&lt;script&gt;alert(&#x27;XSS&#x27;)&lt;/script&gt; Hello!

{% endhighlight %}
{% endtabs %}

Displaying the encoded text ensures it is treated as plain text.

## Component specific guidelines

### DataGrid

The DataGrid can render HTML when using templates or when column values include markup. User provided values should be sanitized before being added to the data source. 

The following example demonstrates sanitizing text before binding it to the Grid:

{% tabs %}
{% highlight razor tabtitle="index.razor" %}

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

You can experiment with a working example of encoded DataGrid content in the Syncfusion Blazor playground:

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBdDKiCUIgKSIYz?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2"  %}

## See also

* [Content Security Policy (CSP)](https://blazor.syncfusion.com/documentation/common/content-security-policy)
* [Paste Clean-up in Blazor Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/paste-cleanup)
* [Paste Clean-up in Blazor Block Editor](https://blazor.syncfusion.com/documentation/block-editor/paste-cleanup)
