---
layout: post
title: Templates in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about templates in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Templates in Blazor MultiSelect Dropdown Component

The MultiSelect has been provided with several options to customize each list item, group title, selected value, header, and footer elements.

To get started quickly with Templates in the Blazor MultiSelect Dropdown component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=6A61PDatD0s" %}

## Value template

The currently selected value that is displayed by default on the MultiSelect input element can be customized using the [ValueTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_ValueTemplate) property.

In the following sample, the selected value is displayed as a combined text of both `FirstName` and `Designation` in the MultiSelect input, which is separated by a hyphen.

{% highlight cshtml %}

{% include_relative code-snippet/template/value-template.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with Value Template](./images/blazor-multiselect-dropdown-value-template.png)

## Item template

The content of each list item within the MultiSelect can be customized with the help of [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) property.

In the following sample, each list item is split into two columns to display relevant data.

{% highlight cshtml %}

{% include_relative code-snippet/template/item-template.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with Item Template](./images/blazor-multiselect-dropdown-item-template.png)

## Group template

The group header title under which appropriate sub-items are categorized can also be customized with the help of the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property. This template is common for both inline and floating group header template.

In the following sample, employees are grouped according to their cities.

{% highlight cshtml %}

{% include_relative code-snippet/template/group-template.razor %}

{% endhighlight %}

![Blazor MultiSelect with GroupTemplate](./images/template/blazor-multiselect-group-template.png)

## Header template

The header element is shown statically at the top of the popup list items within the MultiSelect, and any custom element can be placed as a header element using the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_HeaderTemplate) property.

In the following sample, the list items and its headers are designed and displayed as two columns similar to multiple columns of the grid.

{% highlight cshtml %}

{% include_relative code-snippet/template/header-template.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with Header Template](./images/blazor-multiselect-dropdown-header-template.png)

## Footer template

The MultiSelect has options to show a footer element at the bottom of the list items in the popup list. Here, you can place any custom element as a footer element using the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_FooterTemplate) property.

In the following sample, footer element displays the total number of list items present in the MultiSelect.

{% highlight cshtml %}

{% include_relative code-snippet/template/footer-template.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with Footer Template](./images/blazor-multiselect-dropdown-footer-template.png)

## No records template

The MultiSelect is provided with support to custom design the popup list content when no data is found and no matches are found on search with the help of [NoRecordsTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_NoRecordsTemplate) property.

In the following sample, popup list content displays the notification of no data available.

{% highlight cshtml %}

{% include_relative code-snippet/template/no-record-template.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown without Data](./images/blazor-multiselect-dropdown-without-data.png)

## Action failure template

There is also an option to custom design the popup list content when the data fetch request fails at the remote server. This can be achieved using the [ActionFailureTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ActionFailureTemplate) property.

In the following sample, when the data fetch request fails, the MultiSelect displays the notification.

{% highlight cshtml %}

{% include_relative code-snippet/template/action-failure-template.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with Action Template](./images/blazor-multiselect-dropdown-action-template.png)
