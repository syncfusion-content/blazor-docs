---
layout: post
title: Templates in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Templates in the Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Templates in Blazor ComboBox Component

The ComboBox provides several options to customize the appearance and content of list items, group headers, the selected value, and the popup’s header and footer elements.

To quickly get started with templates in the Blazor ComboBox component, watch the following video.

{% youtube "https://www.youtube.com/watch?v=Powq8aAGeAA" %}

## Item template

Customize the content of each list item using the [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ItemTemplate) property.

In the following example, each list item is split into two columns to display relevant data.

{% highlight cshtml %}

{% include_relative code-snippet/templates/item-template.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVAWhhQgcQzSVPf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with ItemTemplate](./images/blazor-combobox-item-template.png)" %}

## Group template

Customize the group header text under which sub-items are categorized using the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property. This template is applied to both inline and floating group headers.

In the following example, employees are grouped by country.

{% highlight cshtml %}

{% include_relative code-snippet/templates/group-template.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVKWBVmqQwncaKF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with GroupTemplate](./images/blazor-combobox-group-template.png)" %}

## Header template

The header element is shown statically at the top of the popup list items within the ComboBox, and any custom element can be placed as a header element using the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) property.

In the following sample, the list items and its headers are designed and displayed as two columns similar to multiple columns of the grid.

{% highlight cshtml %}

{% include_relative code-snippet/templates/header-template.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVUsLhwAcwvaAlF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with HeaderTemplate](./images/blazor-combobox-header-template.png)" %}

## Footer template

The ComboBox has options to show a footer element at the bottom of the list items in the popup list. Here, you can place any custom element as a footer element using the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) property.

In the following sample, footer element displays the total number of list items present in the ComboBox.

{% highlight cshtml %}

{% include_relative code-snippet/templates/footer-template.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBKWVVwAcviULco?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with FooterTemplate](./images/blazor-combobox-footer-template.png)" %}

## No records template

The ComboBox is provided with support to custom design the popup list content when no data is found and no matches found on search with the help of [NoRecordsTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_NoRecordsTemplate) property.

In the following sample, popup list content displays the notification of no data available.

{% highlight cshtml %}

{% include_relative code-snippet/templates/no-record-template.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVgWBrwUQlgRDZE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox without Data](./images/blazor-combobox-without-data.png)" %}

## Action failure template

There is also an option to custom design the popup list content when the data fetch request fails at the remote server. This can be achieved using the [ActionFailureTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_ActionFailureTemplate) property.

In the following sample, when the data fetch request fails, the ComboBox displays the notification.

{% highlight cshtml %}

{% include_relative code-snippet/templates/action-failure-template.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBUMrrcqQlwxTci?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with Action Failure Template](./images/blazor-combobox-action-failure-template.png)" %}

## Combine two fields without Templates

To display multiple fields in the combobox without using templates, which is achieved by defining a new variable and passing the value with the desired format with the help of the `get` and `set` methods. 

In the `GameFields` class, the `Name` property is defined with the `get` and `set` methods. 
* The `get` method is used to retrieve the value of the Name property. In this example, it concatenates the FirstName and LastName variables, with a space in between and returns the full name as a string.
* The `set` method is used to update the value of the Name property. In this example, it is not being used, as the value of the Name property is determined by the get method based on the FirstName and LastName properties.

{% highlight cshtml %}

{% include_relative code-snippet/templates/text-with-first-and-last-name.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLKMLBwAQaWEhfL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Text with firstName and lastName](./images/templates/blazor_combobox_firstname-lastname.png)" %}