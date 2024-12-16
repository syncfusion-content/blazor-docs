---
layout: post
title: Link manipulation in Blazor Markdown Editor | Syncfusion
description: Checkout and learn here all about Link manipulation in Syncfusion Blazor Markdown Editor component and more.
platform: Blazor
control: MarkdownEditor
documentation: ug
---

# Link Manipulation in Markdown Editor

The hyperlink can be inserted into the editor for quick access to the related information. The hyperlink itself can be text or an image.

## Insert link

Point the cursor anywhere within the editor where you want to insert the link. It is also possible to select a text or an image within the editor that can be converted to the hyperlink. Click the insert hyperLink tool on the toolbar. The insert link dialog will open. The dialog has the following options.

![Blazor Markdown Editor insert link](../images/blazor-markdown-editor-insert-link.png)

| Options | Description |
|----------------|--------------------------------------|
| Web Address | Types or pastes the destination for the link you are creating |
| Display Text | Types or edits the required text that you want to display text for the link |
| Tooltip | Displays additional helpful information when you place the pointer on the hyperlink, type the required text in the `Tooltip` field. |
| Open Link | Specifies whether the given link will open in new window or not |

N> The Rich Text Editor link tool validates the URLs as you type them in the web address. URLs considered invalid will be highlighted with a red color by clicking the insert button in the [Insert Link](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ToolbarCommand.html#Syncfusion_Blazor_RichTextEditor_ToolbarCommand_CreateLink) dialog.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/insert-link.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor Markdown Editor displaying link icon](../images/blazor-markdown-editor-link-icon.png)
