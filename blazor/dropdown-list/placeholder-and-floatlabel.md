---
layout: post
title: Placeholder/FloatLabel in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Placeholder and FloatLabel in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Placeholder and Float Label in Dropdown List

## Placeholder in the blazor dropdownlist component

Use the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Placeholder) property to display a small description of the expected value in the input. In the following sample demonstration, set the `Select a game` as the `Placeholder` property value, which will set the respective value to the `Placeholder` attribute of the input element in the DOM.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder.razor %}

{% endhighlight %}

![Blazor DropdownList with placeholder](./images/placeholder-and-floatlabel/blazor_dropdown_placeholder.png)

## Color of the placeholder text

Use the following code to customize the text color of the `Placeholder`.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-color.razor %}

{% endhighlight %}

![Blazor DropdownList with color placeholder](./images/placeholder-and-floatlabel/blazor_dropdown_placeholder-with-color.png)

## Add mandatory indicator using placeholder

The mandatory indicator `*​` can be applied to the placeholder using the content style in the CSS level.

Use the following code to add the mandatory indicator * to the float label element.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-mandatory.razor %}

{% endhighlight %}

![Blazor DropdownList with mandatory indicator placeholder](./images/placeholder-and-floatlabel/blazor_dropdown_placeholder-with-mandatory.png)

## FloatLabel in the blazor dropdownlist component

Use the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FloatLabelType) property to specify the floating label behavior of the DropDownList that the `Placeholder` text floats above the TextBox based on the following values.

The floating label supports the types of actions as follow.

Type     | Description
------------ | -------------
  [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Auto)       | The floating label will float above the input after focusing, or entering a value in the input.
  [Always](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Always)     | The floating label will always float above the input.
  [Never](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Never)      | By default, never float the label in the input when the placeholder is available.

The `FloatLabelType` as  `Auto` is demonstrated in the following code sample.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel.razor %}

{% endhighlight %}

![Blazor DropdownList with float label](./images/placeholder-and-floatlabel/blazor_dropdown_floatlabel.gif)

## Customizing the float label element’s focusing color

Use the following code to customize the focusing color of the float label element.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel-focusing-color.razor %}

{% endhighlight %}

![Blazor DropdownList with float label focusing color](./images/placeholder-and-floatlabel/blazor_dropdown_floatlabel-focusing-color.png)

## Properties

### FloatLabelType

Specifies the floating label behavior of the DropDownList that the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Placeholder) text floats above the DropDownList based on the following values. [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FloatLabelType) is applicable only when `Placeholder` is used.`FloatLabelType` is depends on `Placeholder`.

Default value of `FloatLabelType` is `Never`.

Possible values are:

* [Never](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Never) - The label will never float in the input when the placeholder is available.
* [Always](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Always) - The floating label always floats above the DropDownList.
* [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Auto) - The floating label floats above the DropDownList after focusing it or when enters the value in it.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel.razor %}

{% endhighlight %}

![Blazor DropdownList with float label](./images/placeholder-and-floatlabel/blazor_dropdown_floatlabel.gif)

### Placeholder

Specifies the text that is shown as a hint or [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Placeholder) until the user focuses or enter a value in DropDownList.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder.razor %}

{% endhighlight %}

![Blazor DropdownList with placeholder](./images/placeholder-and-floatlabel/blazor_dropdown_placeholder.png)

