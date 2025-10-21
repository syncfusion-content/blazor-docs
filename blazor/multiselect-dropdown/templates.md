---
layout: post
title: Templates in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about templates in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Templates in Blazor MultiSelect Dropdown Component

The MultiSelect provides template options to customize the selected value, list items, group headers, header, and footer elements.

To get started quickly with templates in the Blazor MultiSelect Dropdown component, watch the following video:
{% youtube "https://www.youtube.com/watch?v=6A61PDatD0s" %}

## Value template

Customize how the currently selected value is displayed in the input by using the [ValueTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_ValueTemplate) property.

In the following sample, the selected value displays combined text from `FirstName` and `Designation`, separated by a hyphen.

{% highlight cshtml %}

{% include_relative code-snippet/template/value-template.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown with value template](./images/blazor-multiselect-dropdown-value-template.png)

## Item template

Customize the content of each list item by using the [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) property.

In the following sample, each list item is split into two columns to display related data.

{% highlight cshtml %}

{% include_relative code-snippet/template/item-template.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown with item template](./images/blazor-multiselect-dropdown-item-template.png)

## Group template

Customize the group header title (used for both inline and floating headers) by using the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property.

In the following sample, employees are grouped by city.

{% highlight cshtml %}

{% include_relative code-snippet/template/group-template.razor %}

{% endhighlight %}

![Blazor MultiSelect with GroupTemplate](./images/template/blazor-multiselect-group-template.png)

## Header template

Render a custom header at the top of the popup by using the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_HeaderTemplate) property.

In the following sample, the header and list items are presented in two columns similar to a grid layout.

{% highlight cshtml %}

{% include_relative code-snippet/template/header-template.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown with header template](./images/blazor-multiselect-dropdown-header-template.png)

## Footer template

Render a custom footer at the bottom of the popup list by using the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_FooterTemplate) property.

In the following sample, the footer displays the total number of list items.

{% highlight cshtml %}

{% include_relative code-snippet/template/footer-template.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown with footer template](./images/blazor-multiselect-dropdown-footer-template.png)

## No records template

Customize the popup content when no items are available or when search yields no matches by using the [NoRecordsTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_NoRecordsTemplate) property.

In the following sample, the popup displays a “no data available” message.

{% highlight cshtml %}

{% include_relative code-snippet/template/no-record-template.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown without data](./images/blazor-multiselect-dropdown-without-data.png)

## Action failure template

Customize the popup content displayed when a remote data request fails by using the [ActionFailureTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ActionFailureTemplate) property.

In the following sample, the component shows a notification when data retrieval fails.

{% highlight cshtml %}

{% include_relative code-snippet/template/action-failure-template.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown with action failure template](./images/blazor-multiselect-dropdown-action-template.png)