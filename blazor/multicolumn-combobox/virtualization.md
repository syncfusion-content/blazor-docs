---
layout: post
title: Virtualization in Blazor MultiColumn ComboBox | Syncfusion
description: Virtualize Blazor MultiColumn ComboBox for large datasets with EnableVirtualization and on-demand loading.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Virtualization in Blazor MultiColumn ComboBox

The Blazor MultiColumn ComboBox supports virtualization to improve performance with large datasets. When [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_EnableVirtualization) is enabled, the component initially renders only the items needed to fill the visible popup area. As the user scrolls, additional items are fetched and rendered on demand, creating smooth scrolling with reduced DOM size.

This feature is applicable to both local and remote data scenarios, providing flexibility in its implementation. For instance, consider a case where the Blazor MultiColumn ComboBox is bound to a dataset containing 2000 items. Upon opening the dropdown, only a few items are loaded initially, based on the height of the popup. As you scroll through the list, additional items are fetched and loaded on-demand, allowing you to effortlessly explore the complete dataset.

## Local Data

{% highlight cshtml %}

{% include_relative code-snippet/virtualization/local-data.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhJZahKTtSnegNR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with virtualization](./images/blazor_multicolumn_combobox_virtualization.gif)" %}

## Remote Data

{% highlight cshtml %}

{% include_relative code-snippet/virtualization/remote-data.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htLfjurUfXpSdkUp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with virtualization](./images/blazor_multicolumn_combobox_remote-data-virtualization.gif)" %}
