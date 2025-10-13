---
layout: post
title: Mention Integration in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about Mention integration in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Mention Integration in Blazor RichTextEditor

By integrating the [Mention](https://blazor.syncfusion.com/documentation/mention/getting-started) component with a Rich Text Editor, users can easily mention or tag other users or objects from the suggested list without manually typing names or identifiers.

The [Target](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_Target) property of the Mention component specifies the `ID` of the content-editable div element in the Rich Text Editor to bind the Mention component. This allows you to enable the Mention functionality within the Rich Text Editor, allowing users to tag items from the suggestion list during text editing.

Typing the `@` symbol followed by a character displays a list of suggestions for selection. Users can select an item by clicking or typing its name.

In the following sample, the following properties are configured along with popup dimensions:

* [AllowSpaces](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_AllowSpaces) - Allow to continue search action if user enter space after mention character while searching.
* [SuggestionCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_SuggestionCount) - The maximum number of items that will be displayed in the suggestion list.
* [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) - Displays customized appearance in the suggestion list.

{% highlight cshtml %}

{% include_relative code-snippet/mention-integration.razor %}

{% endhighlight %}

![Blazor RichTextEditor mention integration](./images/blazor-richtexteditor-mention-integration.png)

> [View Sample](https://blazor.syncfusion.com/demos/rich-text-editor/mention-integration?theme=bootstrap5)

## See also

* [Mention](https://blazor.syncfusion.com/documentation/mention/getting-started)