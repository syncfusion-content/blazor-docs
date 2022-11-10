---
layout: post
title: Placeholder/FloatLabel in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Placeholder and FloatLabel in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Placeholder and Float Label in Dropdown List

## Placeholder in the Blazor DropDownList component

You can use [`Placeholder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Placeholder) property to display small description of the expected value in the input. In the below sample demonstration, you have to set `Select a game` as Placeholder property value, which will set respective value to the placeholder attribute of the input element in the DOM.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder.razor %}

{% endhighlight %}

![Blazor DropdownList with placeholder](./images/placeholder-and-floatlabel/blazor_dropdown_placeholder.png)

## Color of the placeholder text

Use the following code to customize the text color of placeholder.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-color.razor %}

{% endhighlight %}

![Blazor DropdownList with color placeholder](./images/placeholder-and-floatlabel/blazor_dropdown_placeholder-with-color.png)

## Add mandatory indicator using placeholder

Use the following code to add the mandatory indicator * to the float label element.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-mandatory.razor %}

{% endhighlight %}

![Blazor DropdownList with mandatory indicator placeholder](./images/placeholder-and-floatlabel/blazor_dropdown_placeholder-with-mandatory.png)

## Float Label in the Blazor DropDownList component

You can use [`FloatLabelType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FloatLabelType) property to specify the floating label behavior of the DropDownList that the placeholder text floats above the TextBox based on the following values.

Floating label supports the types of actions as given below.

Type     | Description
------------ | -------------
  Auto       | The floating label will float above the input after focusing, or entering a value in the input.
  Always     | The floating label will always float above the input.
  Never      | By default, never float the label in the input when the placeholder is available.

FloatLabelType `Auto` is demonstrated in the below code sample.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel.razor %}

{% endhighlight %}

![Blazor DropdownList with float label](./images/placeholder-and-floatlabel/blazor_dropdown_floatlabel.gif)

## Customizing the float label element’s focusing color

Use the following code to customize the focusing color of float label element.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel-focusing-color.razor %}

{% endhighlight %}

![Blazor DropdownList with float label focusing color](./images/placeholder-and-floatlabel/blazor_dropdown_floatlabel-focusing-color.png)