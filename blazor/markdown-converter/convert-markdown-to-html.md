---
layout: post
title: Markdown to HTML Blazor Markdown Converter | Syncfusion
description: Learn how to convert Markdown to HTML using Blazor Markdown Converter in Syncfusion with customization options and examples.
platform: Blazor
control: MarkdownConverter
documentation: ug
---

# Convert Markdown To HTML using Markdown Converter

The Markdown Converter is a simple and fast tool that converts Markdown text into clean HTML. This makes it easy to display well-structured content on web pages and applications with consistent formatting.

The conversion is handled by the `ToHtml` method, which takes Markdown as input and returns the corresponding HTML. It supports all common Markdown elements like headings, lists, tables, links, images, and inline styles.

Here is the example code snippet of Markdown Converter:

```csharp

using Syncfusion.Blazor.MarkdownConverter;

public class MarkdownExample
{
    public void ConvertMarkdown()
    {
        string markdownContent = "# Hello World\nThis is **Markdown** text.";
        // Convert Markdown to HTML
        string htmlOutput = SfMarkdownConverter.ToHtml(markdownContent);
        Console.WriteLine(htmlOutput);
    }
}

```

## Configurable Options for Markdown Converter

The `Markdown Converter` provides several options to customize the conversion process. These options are passed as part of the configuration when calling the `ToHtml` or `ToHtmlAsync` method. By using these options, you can control how Markdown is parsed and rendered into HTML.

```csharp
SfMarkdownConverter.ToHtml(markdown: string, options?: MarkdownConverterOptions);
SfMarkdownConverter.ToHtmlAsync(markdown: string, options?: MarkdownConverterOptions);
```

### Markdown Converter Options

| **Option**   | **Description** | **Type**   | **Default** |
|--------------|---------------------------------------------------------------------------------------------------|------------|-------------|
| `Gfm`        | Enables or disables support for **GitHub Flavored Markdown (GFM)**.                              | `bool`     | `true`      |
| `LineBreak`  | Enables or disables conversion of **single line breaks** into `<br />` elements.                 | `bool`     | `false`     |
| `Silent`     | Enables or disables **error suppression**, skipping invalid Markdown instead of throwing errors. | `bool`     | `false`     |

## Basic Markdown to HTML Conversion

The below example demonstrates how to use the Blazor Markdown Converter to convert Markdown content into HTML. This setup allows real-time conversion of Markdown to HTML with customizable options.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/basic-markdown-to-html.razor %}

{% endhighlight %}
{% endtabs %}

## Markdown Conversion with Customizable Options

The below example demonstrates how to use the Markdown Converter with customizable options like GitHub Flavored Markdown (GFM), line break handling, and error suppression. You can toggle these options to see how they affect the conversion output.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/markdown-to-html-customize.razor %}

{% endhighlight %}
{% endtabs %}

## Asynchronous Markdown Conversion

For large Markdown documents, use the asynchronous `ToHtmlAsync` method to prevent UI thread blocking. This is especially useful in Blazor WebAssembly applications where processing large documents synchronously can impact performance.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/markdown-to-html-async.razor %}

{% endhighlight %}
{% endtabs %}

## GitHub Flavored Markdown Support

When `Gfm` is enabled, the Markdown Converter supports additional features from GitHub Flavored Markdown, including:

- **Tables**: Multi-column data tables with alignment support
- **Task Lists**: Checkboxes for todo items
- **Strikethrough**: Text with ~~strikethrough~~ formatting
- **Autolinks**: Automatic linking of URLs and mentions
- **Enhanced Emphasis**: Improved handling of bold and italic text

Example with GFM features:

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/markdown-to-html-gfm.razor %}

{% endhighlight %}
{% endtabs %}

## Real-time Markdown Editing and Preview with Splitter

The below sample demonstrates how to use the [Syncfusion RichTextEditor](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started) along with the Markdown Converter to convert Markdown content into HTML with real-time preview. This setup allows seamless editing and instant conversion of Markdown content.

To make the experience seamless, the [Syncfusion Splitter control](https://blazor.syncfusion.com/documentation/splitter/split-panes) is used to display the editor and preview side-by-side.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/markdown-to-html-preview.razor %}

{% endhighlight %}
{% endtabs %}

## Error Handling with Silent Mode

The `Silent` option allows the converter to handle errors gracefully. When enabled, invalid Markdown will produce partial output instead of throwing exceptions.

```csharp

// With Silent mode disabled (default)
try
{
    var options = new MarkdownConverterOptions { Silent = false };
    string html = SfMarkdownConverter.ToHtml(markdownContent, options);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// With Silent mode enabled
var silentOptions = new MarkdownConverterOptions { Silent = true };
string htmlWithSilentMode = SfMarkdownConverter.ToHtml(markdownContent, silentOptions);
// Returns best-effort HTML instead of throwing

```

## Summary

The Syncfusion Blazor Markdown Converter provides a simple yet powerful way to convert Markdown to HTML with various customization options. Whether you need basic conversion or advanced GFM support, the component handles your requirements efficiently in both Blazor Server and Blazor WebAssembly environments.

- Use `ToHtml()` for synchronous conversion of small to medium-sized documents
- Use `ToHtmlAsync()` for asynchronous processing of large documents
- Configure options to control parsing behavior and error handling
- Enable GFM for enhanced Markdown feature support
