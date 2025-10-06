---
layout: post
title: Link manipulation in Blazor Rich Text Editor Component | Syncfusion
description: Checkout and learn here all about Link manipulation in Syncfusion Blazor Rich Text Editor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Link Manipulation in Rich Text Editor

The hyperlink can be inserted into the editor for quick access to the related information. The hyperlink itself can be text or an image.

## Insert link

Point the cursor anywhere within the editor where you want to insert the link. It is also possible to select a text or an image within the editor that can be converted to the hyperlink. Click the insert hyperLink tool on the toolbar. The insert link dialog will open. The dialog has the following options.

![Blazor Rich Text Editor insert link](../images/blazor-richtexteditor-insert-link.png)

| Options | Description |
|----------------|--------------------------------------|
| Web Address | Enter or paste the destination URL for the hyperlink |
| Display Text | Enter or edit the text that will be displayed for the hyperlink |
| Tooltip |Optional text that appears when hovering over the hyperlink, type the required text in the `Tooltip` field. |
| Open Link | Choose whether the hyperlink should open in a new browser tab or the same tab |

N> The Rich Text Editor link tool validates the URLs as you type them in the web address. URLs considered invalid will be highlighted with a red color by clicking the insert button in the [Insert Link](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.ToolbarCommand.html#Syncfusion_Blazor_RichTextEditor_ToolbarCommand_CreateLink) dialog.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/insert-link.razor %}

{% endhighlight %}
{% endtabs %}

![Link icon displayed in Blazor Rich Text Editor toolbar](../images/blazor-richtexteditor-link-icon.png)

## Enable auto-linking

When you type URL and enter key to the Rich Text Editor, the typed URL will be automatically changed into the hyperlink.

## Enable auto URL conversion

When the [EnableAutoUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableAutoUrl) property is enabled, it will accept the given URL (relative or absolute) without validating it for hyperlinks. Otherwise, the given URL will be automatically converted to absolute path URL by prefixing https:// for hyperlinks, and it defaults to false.

## How to edit or remove a hyperlink

Add the custom tools on the selected link inside the Rich Text Editor through the quick toolbar.

![Blazor Rich Text Editor with quick toolbar link](../images/blazor-richtexteditor-quick-toolbar-link.png)

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/edit-remove-link.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor Rich Text Editor link quick toolbar](../images/blazor-richtexteditor-quick-link.png)

## See also

* [How to insert link editing option in the toolbar items](../toolbar#link-quick-toolbar)