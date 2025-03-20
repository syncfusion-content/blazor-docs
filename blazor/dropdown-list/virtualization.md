---
layout: post
title: Virtualization in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Virtualization in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Virtualization in DropDown List

The DropDownList component includes a virtual scrolling feature designed to enhance UI performance, particularly for handling large datasets. By enabling the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_EnableVirtualization) option, the DropDownList intelligently manages data rendering, ensuring only a subset of items is initially loaded when the component is rendered. As you interact with the dropdown, additional items are dynamically loaded as you scroll, creating a smooth and efficient user experience.

This feature is applicable to both local and remote data scenarios, providing flexibility in its implementation. For instance, consider a case where the DropDownList is bound to a dataset containing 150 items. Upon opening the dropdown, only a few items are loaded initially, based on the height of the popup. As you scroll through the list, additional items are fetched and loaded on-demand, allowing you to effortlessly explore the complete dataset.


{% highlight cshtml %}

{% include_relative code-snippet/virtualization/local-data.razor %}

{% endhighlight %}

![Blazor DropDownList with virtualization of local data](./images/virtualization/blazor_dropdownlist_virtualization-local-data.gif)

## Keyboard interaction

Users can navigate through the scrollable content using keyboard actions. This feature loads the next or next set of items based on the key inputs in the popup.

| Key | Action |
|-----|-----|
| `ArrowDown` | Loads the next virtual list item if the selection is present in last item of the current page. |
| `ArrowUp` | Loads the previous virtual list item if the selection is present in first item of the current page. |
| `PageDown` | Loads the next page and selects the last item in it. |
| `PageUp` | Loads the previous page and selects the first item in it. |
| `Home` | Loads the initial set of items and selects first item in it. |
| `End` | Loads the last set of items and selects last item in it. |

## Limitation of virtualization

* Virtualization is not supported in the grouping feature.
* Selected Value may or may not be present in the current view port.
* Long-pressing of navigation keys is not intended for item navigation in the Dropdownlist component , It accepts single key action at a time.