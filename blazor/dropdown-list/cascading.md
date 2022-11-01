---
layout: post
title: Cascading in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Cascading in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Cascading Dropdown List

The Cascading DropDownList is the series of DropDownList, where the value of one DropDownList depends on another DropDownList value. 

In the `ValueChange` event handler of first DropDownList, you should load the data for the second DropDownList based on the selected value of first DropDownList. The same has to be configured between second and third DropDownLists.

In this sample, if a country is selected from countries DropDownList, the respective states are loaded in the second DropDownList and in the same way states and cities DropDownList works.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading-dropdown.razor %}

{% endhighlight %}

![Blazor DropdownList with cascading](./images/cascading/blazor_dropdown_cascading.gif)