---
layout: post
title: Cascading in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Cascading in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Cascading in Dropdown List

The Cascading DropDownList is the series of DropDownList where the value of one DropDownList depends on another DropDownList value. 

In the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event handler of the first DropDownList, load the data for the second DropDownList based on the selected value of the first DropDownList. The same has to be configured between second and third DropDownLists.

To get started quickly with Cascading in the Blazor DropDown List component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=N_xI_aE76C0" %}

In the following sample, if a country is selected from countries DropDownList, the respective states are loaded in the second DropDownList and in the same way states and cities DropDownList works.

{% highlight cshtml %}

{% include_relative code-snippet/cascading/cascading-dropdown.razor %}

{% endhighlight %}

![Blazor DropdownList with cascading](./images/cascading/blazor_dropdown_cascading.gif)

N> [View Sample in Demo](https://blazor.syncfusion.com/demos/dropdown-list/cascading?theme=bootstrap5).