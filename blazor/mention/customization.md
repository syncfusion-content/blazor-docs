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

You can show the mention character as the prefix of the selected item in mention component using `ShowMentionChar` property. The default value of `ShowMentionChar` is `false`.

{% highlight razor %}

{% include_relative code-snippet/show-mention-char.razor %}

{% endhighlight %}

![Blazor Mention with show or hide mention character](./images/blazor-mention-show-mention-char.png)

## Adding the suffix character after selection

You can add the suffix character while selecting an item in the Mention component using `SuffixText` property. You can add space or new line as suffix to the selected item. The default values are empty string.

{% highlight razor %}

{% include_relative code-snippet/suffix-char.razor %}

{% endhighlight %}

## Configure the popup list

You can customize the suggestion list's width and height using the `PopupHeight` and `PopupWidth` properties.

By default, the popup list width value is set to `auto`. Depending on the mentioned suggestion data list, the width value is automatically adjusted. The popup list height value is set to `250px`.

{% highlight razor %}

{% include_relative code-snippet/popup-list.razor %}

{% endhighlight %}

![Blazor Mention with popup list](./images/blazor-mention-popup-list.png)

## Trigger character

You can customize the trigger character by using the `MentionChar` property in the Mention component. The trigger character triggers the suggestion list to display in the target area.

By default, the `MentionChar` is `@`.

{% highlight razor %}

{% include_relative code-snippet/trigger-char.razor %}

{% endhighlight %}

![Blazor Mention with trigger character](./images/blazor-mention-trigger-char.png)