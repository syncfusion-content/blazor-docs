---
layout: post
title: Virtualization in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Virtualization in Syncfusion Blazor MultiColumn ComboBox component and much more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Virtualization in Blazor MultiColumn ComboBox Component

The Blazor MultiColumn ComboBox supports virtualization to improve performance with large datasets. When [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_EnableVirtualization) is enabled, the component initially renders only the items needed to fill the visible popup area. As the user scrolls, additional items are fetched and rendered on demand, creating smooth scrolling with reduced DOM size.

This feature is applicable to both local and remote data scenarios, providing flexibility in its implementation. For instance, consider a case where the MultiColumn ComboBox is bound to a dataset containing 2000 items. Upon opening the dropdown, only a few items are loaded initially, based on the height of the popup. As you scroll through the list, additional items are fetched and loaded on-demand, allowing you to effortlessly explore the complete dataset.

## Local data

{% highlight cshtml %}

{% include_relative code-snippet/virtualization/local-data.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhJZahKTtSnegNR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor MultiColumn ComboBox with local data virtualization](./images/blazor_multicolumn_combobox_virtualization.gif)

## Remote data

{% highlight cshtml %}

{% include_relative code-snippet/virtualization/remote-data.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htLfjurUfXpSdkUp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor MultiColumn ComboBox with remote data virtualization](./images/blazor_multicolumn_combobox_remote-data-virtualization.gif)