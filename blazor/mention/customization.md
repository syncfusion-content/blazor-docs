---
layout: post
title: Customization in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about Customization in Syncfusion Blazor Mention component and much more.
platform: Blazor
control: Mention
documentation: ug
---

# Customization in Mention

## Show or hide mention character

You can show the mention character as the prefix of the selected item in the Mention component by using the `ShowMentionChar` property. By default, the `ShowMentionChar` property is set to `false`, which means that the mention character will not be displayed as part of the selected mention item.

{% highlight razor %}

{% include_relative code-snippet/show-mention-char.razor %}

{% endhighlight %}

![Blazor Mention with show or hide mention character](./images/blazor-mention-show-mention-char.png)

## Adding the suffix character after selection

The `SuffixText` property in the Mention component allows you to specify a string that should be appended to the end of the selected mention item when it is inserted into the input field. You can use this property to add a space or a new line after the mention, or any other string that you want to include.

{% highlight razor %}

{% include_relative code-snippet/suffix-char.razor %}

{% endhighlight %}

## Configure the popup list

You can customize the suggestion list's width and height using the `PopupHeight` and `PopupWidth` properties. These properties can accept values in pixels, percentage, or as a number. If a number value is specified, it will be treated as a pixel value.

By default, the popup list width value is set to `auto`. Depending on the mentioned suggestion data list, the width value is automatically adjusted. The popup list height value is set to `250px`.

{% highlight razor %}

{% include_relative code-snippet/popup-list.razor %}

{% endhighlight %}

![Blazor Mention with popup list](./images/blazor-mention-popup-list.png)

## Trigger character

The `MentionChar` property in the Mention component allows you to specify the character that will trigger the suggestion list to display in the target area. By default, the `@` character is used as the trigger character, but you can customize it to any other character by setting the `MentionChar` property.

{% highlight razor %}

{% include_relative code-snippet/trigger-char.razor %}

{% endhighlight %}

![Blazor Mention with trigger character](./images/blazor-mention-trigger-char.png)