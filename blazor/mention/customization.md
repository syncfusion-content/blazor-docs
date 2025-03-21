---
layout: post
title: Customization in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about customization in Syncfusion Blazor Mention component and much more.
platform: Blazor
control: Mention
documentation: ug
---

# Customization in Blazor Mention Component

## Show or hide mention character

To show the mentioned character along with the text when displaying the selected mention item in the target element, you can set the [ShowMentionChar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_ShowMentionChar) property of the Mention component to `true`. This can be useful in cases where you want to clearly differentiate between the selected mention item and the rest of the text in the Mention component.

{% highlight razor %}

{% include_relative code-snippet/show-mention-char.razor %}

{% endhighlight %}

![Blazor Mention with show or hide mention character](./images/blazor-mention-show-mention-char.png)

## Adding the suffix character after selection

The [SuffixText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_SuffixText) property in the Mention component allows you to specify a string that should be appended to the end of the selected mention item when it is inserted into the input field. You can use this property to add a `space` or a `new line` after the mention, or any other string that you want to include.

{% highlight razor %}

{% include_relative code-snippet/suffix-char.razor %}

{% endhighlight %}

## Configure the popup list

You can customize the suggestion list's width and height using the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_PopupHeight) and [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_PopupWidth) properties. These properties can accept values in pixels, percentage, or as a number. If a number value is specified, it will be treated as a pixel value.

By default, the popup list width value is set to `auto`. Depending on the mentioned suggestion data list, the width value is automatically adjusted. The popup list height value is set to `300px`.

{% highlight razor %}

{% include_relative code-snippet/popup-list.razor %}

{% endhighlight %}

![Blazor Mention with popup list](./images/blazor-mention-popup-list.png)

## Trigger character

The [MentionChar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_MentionChar) property in the Mention component allows you to specify the character that will trigger the suggestion list to display in the target area. By default, the `@` character is used as the trigger character, but you can customize it to any other character by setting the `MentionChar` property.

{% highlight razor %}

{% include_relative code-snippet/trigger-char.razor %}

{% endhighlight %}

![Blazor Mention with trigger character](./images/blazor-mention-trigger-char.png)

## Leading Space Requirement

You can control whether a space is required before the mention character using the [RequireLeadingSpace](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#properties) property in the Mention component. When set to `true` , a space must precede the mention character to trigger the suggestion popup. When set to `false`, the mention character can trigger suggestions without requiring a leading space.

{% highlight razor %}

{% include_relative code-snippet/require-leading-space.razor %}

{% endhighlight %}

![Blazor Mention with leading space configuration](./images/require_leading_space.gif)