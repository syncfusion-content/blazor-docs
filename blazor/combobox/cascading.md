---
layout: post
title: Cascading in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Cascading in Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Cascading in  Dropdown List

The Cascading DropDownList is the series of DropDownList, where the value of one DropDownList depends on another DropDownList value. 

In the [`ValueChange`]() event handler of first DropDownList, you should load the data for the second DropDownList based on the selected value of first DropDownList. The same has to be configured between second and third DropDownLists.

In this sample, if a country is selected from countries DropDownList, the respective states are loaded in the second DropDownList and in the same way states and cities DropDownList works.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading.razor %}

{% endhighlight %}

![Cascading in Blazor ComboBox](./images/cascading/blazor_combobox_cascading.gif)

## Cascading with filtering 

The Cascading ComboBox is the series of ComboBox, where the value of one ComboBox depends on the another ComboBox value. In the [ValueChange](https://blazor.syncfusion.com/documentation/combobox/events#valuechange) event handler of 1st ComboBox, should load the data for the 2nd ComboBox based on the selected value of 1st ComboBox. The same has to be configured between 2nd and 3rd ComboBoxes.In the below code, if a country is chosen, then corresponding states for the chosen county is loaded in the next combobox with the support of TValue as int.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading-with-filtering.razor %}

{% endhighlight %}

![Cascading with Filtering in Blazor ComboBox](./images/cascading/blazor_combobox_cascading-with-filtering.png)