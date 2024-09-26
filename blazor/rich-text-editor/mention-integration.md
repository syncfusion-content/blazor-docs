---
layout: post
title: Mention Integration in Blazor RichTextEditor | Syncfusion
description: Checkout and learn here all about Mention integration in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Mention Integration in Blazor RichTextEditor

By integrating the [Mention](https://blazor.syncfusion.com/documentation/mention/getting-started) component with a Rich Text Editor, users can easily mention or tag other users or objects from the suggested list without having to manually type out their names or other identifying information.

The [Target](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_Target) property of the Mention component allows you to specify the `ID` of the Rich Text Editor followed by the content editable div class name that you want to bind the Mention component to. This allows you to enable the Mention functionality within the Rich Text Editor.

When the user types the `@` symbol followed by a character, the Rich Text Editor will display a list of suggestions for items that the user can select from. The user can then select an item from the list by clicking on it, or by typing the name of the item they want to tag.

In the following sample, configured the following properties with popup dimensions.

* [AllowSpaces](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_AllowSpaces) - Allow to continue search action if user enter space after mention character while searching.
* [SuggestionCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_SuggestionCount) - The maximum number of items that will be displayed in the suggestion list.
* [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) - Used to display the customized appearance in suggestion list.

{% highlight cshtml %}

{% include_relative code-snippet/mention-integration.razor %}

{% endhighlight %}

![Blazor RichTextEditor mention integration](./images/blazor-richtexteditor-mention-integration.png)

> [View Sample](https://blazor.syncfusion.com/demos/rich-text-editor/mention-integration?theme=bootstrap5)

## See Also

* [Mention](https://blazor.syncfusion.com/documentation/mention/getting-started)