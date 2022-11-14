---
layout: post
title: Markdown in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about Markdown in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Markdown Editor in Blazor RichTextEditor

The Rich Text Editor supports to editing the markdown content by using the [EditorMode.Markdown](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.EditorMode.html#Syncfusion_Blazor_RichTextEditor_EditorMode_Markdown) property. Markdown is the lightweight text formatting with the simple syntax and the markdown format will apply both keyboard interactions and toolbar action.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor markdown editor](./images/blazor-richtexteditor-markdown-editor.png)

## Markdown  commands

The [Blazor Markdown editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor/wysiwyg-markdown-editor) supports the following commands to format the markdown content:

|Commands|Syntax| Description |
|--------|------------------------------------------|------------|
| Bold | Sample content for `**`bold text`**`. | For bold, add `**` or `__` to front and back of the text. For order list, precede each line with a number. |
| Italic | Sample content for `*`Italic text`*`. | For Italic, add `*` or `_` to front and back of the text. |
| Bold and Italics | Sample content for `***`bold and Italic text`***`. | For bold and Italics, add `***` to the front and back of the text. |
| Heading 1 | `#` Heading 1 content | For heading 1, add `#` to start of the line. |
| Heading 2 | `##` Heading 2 content | For heading 2, add `##` to start of the line. |
| Heading 3 | `###` Heading 3 content | For heading 3, add `###` to start of the line. |
| Heading 4 | `####` Heading 4 content | For heading 4, add `####` to start of the line. |
| Heading 5 | `#####` Heading 5 content | For heading 5, add `#####` to start of the line. |
| Heading 6 | `######` Heading 6 content | For heading 6, add `######` to start of the line. |
| Line Break | First line `<br>`Second line | For line break, press enter two times (or) add `<br>` in between the first and the second line. |
| Blockquotes | `>` Blockquotes text | For blockquotes, add `>` to start of the line. |
| Strike Through | Sample content for `~~`strike through text`~~`. | For strike through, add `~~` to front and back of the text. |
| Code (Single line) | \`Single line code\` | For single line code, add \` to front and back of the text. |
| Code block (Multi Line) | \`\`\`<br>Multi line code text<br>Multi line code text<br>\`\`\` | For multiple line code, add \`\`\` in the new line before and after the content. |
| Subscript | `<sub>`Subscript text`</sub>` | For subscript, add `<sub>` to the front and `</sub>` to the back of the text. |
| Superscript | `<sup>`Superscript text`</sup>` | For superscript, add `<sup>` to the front and `</sup>` to the back of the text. |
| Ordered List | `1.` First<br>`1.` Second | For ordered list, preceding one or more lines of text with `1.` |
| Unordered List | `*` First<br>`*` second | For unordered list, preceding one or more lines of text with `*`. |
| Links | **Link text without title text**<br>`[` Link text `](`URL`)`<br> **Link text with title text**<br>`[` Link text `](`URL , “title text”`)` | Create an inline link by wrapping link text in brackets `[ ]`, and then wrapping the URL as first parameter and title as second parameter in the parentheses `()`.<br>**Note:** The title text is optional, if needed it can be given manually.|
| Table | `|` Heading 1 `|` Heading 2 `|`<br>`|---------|---------|`<br>`|` Col A1 `|` Col A2 `|`<br>`|` Col B1 `|` Col B2 `|` | Create a table using the pipes and underscores as given in the syntax to create 2 x 2 table. |
| Horizontal Line | `***` (three asterisk in new line)<br>(or)<br>`___` (three underscores in new line) | For horizontal line, add `***` or `___` to the start of the new line. |
| Image | !`[`alt text`](`URL path`)` | Create an image by wrapping the image source in parentheses `()`. |
| Image with alternate text | !`[` alternate text `](`URL path`)` | Create an image with alternate text by wrapping an alternative text in brackets `[ ]`, and then link of the image source in parentheses `()`.<br>**Note:** When inserting the image using toolbar, the alternate text cannot be provided that needs to be given manually. |
| Escape tick marks supported | Sample text content with `**`bold and `**`not bold`**` text can be in the same line.`**` | In the syntax, the whole content is made as bold where the content `not bold` can be made as normal text by adding the bold syntax to the start and end of the respective text. Likewise you can do the same for various inline commands. |
| Escape Character | `\(`any syntax`)` | Escape any markdown syntax by prefix `\` to the syntax.<br>Example:<br>`\**`Bold text`**`|
| HTML Entities | Copyright: &copy; - `&copy;` <br>Trade mark: &trade; - `&trade;`<br>Registered: &reg; - `&reg;`<br>Ampersand: &amp; - `&amp;`<br>Less than: &lt; - `&lt;`<br>Greater than: &gt; - `&gt;` | For HTML entities, add & and ; to the front and back of the respective entities. |

> The above listed commands alone are supported in Syncfusion markdown editor. For other unsupported commands, you can achieve using the HTML tags in markdown editor. The foot notes, definitions, math, and check list markdown syntax are also not supported.

## Insert table

To insert the table in the markdown editor, click the [Table](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorTableSettings.html#properties) icon in the toolbar to insert the table into the editor area. By default, The markdown table insert with 2 X 2 rows and columns along with the heading.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown-insert-table.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor markdown table](./images/blazor-richtexteditor-markdown-table.png)

## Insert image

To insert an image in the markdown editor, click the [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html) icon in the toolbar to insert an image into the editor area.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown-insert-image.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor markdown image](./images/blazor-richtexteditor-markdown-image.png)

## Insert link

To create the link for a text or an image in markdown editor, click the `HyperLink`(https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html) tool on the toolbar. The insert link dialog will open. The dialog has the following options.

| Options | Description |
|----------------|--------------------------------------|
| Web Address | Type or paste the destination for the link you are creating |
| Display Text | Type or edit the required text that you want to display text for the link |

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown-insert-link.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor markdown link](./images/blazor-richtexteditor-markdown-link.png)

## Custom format

The Rich Text Editor allows you to customize the markdown syntax by overriding its default syntax. Configure the customized markdown syntax using [RichTextEditorMarkdownOptions.ListSyntax](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorMarkdownOptions.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorMarkdownOptions_ListSyntax), [RichTextEditorMarkdownOptions.FormatSyntax](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorMarkdownOptions.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorMarkdownOptions_FormatSyntax), [RichTextEditorMarkdownOptions.SelectionSyntax](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorMarkdownOptions.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorMarkdownOptions_SelectionSyntax) properties.

{% tabs %}
{% highlight cshtml %}

{% include_relative code-snippet/markdown-custom-formats.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor RichTextEditor markdown custom list](./images/blazor-richtexteditor-markdown-custom-list.png)

![Blazor RichTextEditor markdown custom format](./images/blazor-richtexteditor-markdown-custom-formats.png)

![Blazor RichTextEditor markdown custom selection](./images/blazor-richtexteditor-markdown-custom-bold.png)


## See also

* [How to change the editor mode](./editor-modes/#markdown-editor)
* [How to convert Markdown string to HTML](https://www.syncfusion.com/kb/12478)
