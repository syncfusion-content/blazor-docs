---
layout: post
title: Disabled Items in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about Disabled Items in Syncfusion Blazor Mention component and much more.
platform: Blazor
control: Mention
documentation: ug
---

# Disabled Items in Blazor Mention Component

The [Mention](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html) component supports disabling individual suggestion items for specific scenarios. Map the disabled state from your data model using the [MentionFieldSettings.Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MentionFieldSettings.html#Syncfusion_Blazor_DropDowns_MentionFieldSettings_Disabled) field. Disabled items are not selectable and are skipped during keyboard navigation.

In the following sample, certain states are disabled by setting the `Disabled` field in the data source.

{% highlight cshtml %}

{% include_relative code-snippet/disabled-items.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVTNCAjLjgvQOEF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Mention Component](images/blazor-mention.png)" %}

## Disable Item Method

The disableItem method can be used to handle dynamic changing in disable state of a specific item. Only one item can be disabled in this method. To disable multiple items, this method can be iterated with the items list or array. The disabled field state will to be updated in the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource), when the item is disabled using this method.

| Parameter | Type | Description |
|------|------|------|
| itemValue | <code>string</code> \| <code>number</code> \| <code>boolean</code> \| <code>object</code> | It accepts the string, number, boolean and object type value of the item to be removed. |
| itemIndex | <code>number</code> | It accepts the index of the item to be removed. |

