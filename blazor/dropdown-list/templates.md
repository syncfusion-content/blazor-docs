---
layout: post
title: Templates in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Templates in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDownList
documentation: ug
---

# Templates in DropDown List

The DropDownList provides several templates to customize the appearance of individual list items, group headers, the selected value, and the popup’s header and footer.

To get started quickly with Templates in the Blazor DropDown List component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=OfOnp3bwVfc" %}

## Value template

Customize the display of the currently selected value in the input using the [ValueTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_ValueTemplate) property.

In the following sample, the selected value shows a combined text of `FirstName` and `Designation`, separated by a hyphen.

{% highlight cshtml %}

{% include_relative code-snippet/template/value-template.razor %}

{% endhighlight %}

![Blazor DropDownList with ValueTemplate](./images/template/blazor-dropdownlist-value-template.png)

## Item template

Customize the content of each list item using the [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) property.

In the following sample, each list item is arranged into two columns to present additional details.

{% highlight cshtml %}

{% include_relative code-snippet/template/item-template.razor %}

{% endhighlight %}

![Blazor DropDownList with ItemTemplate](./images/template/blazor-dropdownlist-item-template.png)

## Group template

Customize the group header under which items are categorized using the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property. The same template applies to both inline and floating group headers.

In the following sample, employees are grouped by city.

{% highlight cshtml %}

{% include_relative code-snippet/template/group-template.razor %}

{% endhighlight %}

![Blazor DropDownList with GroupTemplate](./images/template/blazor-dropdownlist-group-template.png)

## Header template

Display a static custom header at the top of the popup using the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HeaderTemplate) property.

In the following sample, the header and items are presented in two columns, similar to a grid layout.

{% highlight cshtml %}

{% include_relative code-snippet/template/header-template.razor %}

{% endhighlight %}

![Blazor DropDownList with HeaderTemplate](./images/template/blazor-dropdownlist-header-template.png)

## Footer template

Show a custom element at the bottom of the popup using the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FooterTemplate) property.

In the following sample, the footer displays the total number of items in the DropDownList.

{% highlight cshtml %}

{% include_relative code-snippet/template/footer-template.razor %}

{% endhighlight %}

![Blazor DropDownList with Footer Template](./images/template/blazor-dropdownlist-footer-template.png)

## No records template

Provide custom content for the popup when no data is available or when a search returns no matches using the [NoRecordsTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_NoRecordsTemplate) property.

In the following sample, the popup displays a “no data available” message.

{% highlight cshtml %}

{% include_relative code-snippet/template/no-record-template.razor %}

{% endhighlight %}

![Blazor DropDownList without Data](./images/template/blazor-dropdownlist-without-data.png)

## Action failure template

Customize the popup content shown when a remote data request fails using the [ActionFailureTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ActionFailureTemplate) property.

In the following sample, the DropDownList displays a notification when data retrieval fails.

{% highlight cshtml %}

{% include_relative code-snippet/template/action-failure-template.razor %}

{% endhighlight %}

![Blazor DropDownList with Action Failure Template](./images/template/blazor-dropdownlist-action-failure-template.png)

## See also

* [Select a value in Blazor DropDownList during bUnit test](https://www.syncfusion.com/forums/172141/how-can-i-select-a-value-in-an-sfdropdown-during-a-bunit-test)
* [Client side validation in Blazor DropDownList](https://www.syncfusion.com/forums/172516/client-side-validation-on-dropdown-list)