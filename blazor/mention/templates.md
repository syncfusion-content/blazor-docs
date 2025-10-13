---
layout: post
title: Templates in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about templates in Syncfusion Blazor Mention component and much more details.
platform: Blazor
control: Mention
documentation: ug
---

# Templates in Blazor Mention Component

The Mention component is a templated Blazor component that allows customizing various parts of its UI through template parameters. Templates can render custom markup or components and tailor the suggestion list and selected value display.

To get started quickly with templates in Blazor Mention Component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=POqb-VVKCOA" %}

## Template context

Templates in the Mention component use `RenderFragment` or `RenderFragment<TItem>`, which represent Razor content blocks that can render within the component. Template parameters are accessed through the implicit parameter commonly named `context`, which provides the current item’s data when applicable.

## Item template

The [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) property defines a custom template for each suggestion list item. The `context` parameter provides the data for the item being rendered, enabling full control over the content and appearance of each suggestion.

In the following sample, each list item is split into two columns to display relevant data using `ItemTemplate`.

{% highlight razor %}

{% include_relative code-snippet/item-template.razor %}

{% endhighlight %}

![Blazor Mention with item template](./images/blazor-mention-item-template.png)

## Display template

The [DisplayTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_DisplayTemplate) property defines how the selected (mentioned) value is displayed in the target. The `context` parameter provides the selected item’s data, allowing custom visuals such as avatars, combined fields, or additional details. This customization affects display only and does not change the underlying value.

In the following sample, the selected value is displayed as a combined text of both `FirstName` and `Country` in the Mention element, which is separated by a hyphen.

{% highlight razor %}

{% include_relative code-snippet/display-template.razor %}

{% endhighlight %}

![Blazor Mention with display template](./images/blazor-mention-display-template.png)

## No records template


The [NoRecordsTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_NoRecordsTemplate) property specifies a template to show when there are no data items or when a search yields no matches. Use it to present helpful messages or guidance.

{% highlight razor %}

{% include_relative code-snippet/no-record-template.razor %}

{% endhighlight %}

![Blazor Mention with no record template](./images/blazor-mention-noRecord-template.png)

## Spinner template

The [SpinnerTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html#Syncfusion_Blazor_DropDowns_SfMention_1_SpinnerTemplate) property specifies a template to display while data is being fetched and the suggestion list is loading. Use this to show a loading indicator or custom progress UI.

{% highlight razor %}

{% include_relative code-snippet/spinner-template.razor %}

{% endhighlight %}

![Blazor Mention with spinner template](./images/blazor-mention-spinner-template.png)

## See also

* [How to achieve filtering](./filtering-data)