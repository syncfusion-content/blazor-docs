---
layout: post
title: Placeholder/FloatLabel in Blazor MultiSelect Component | Syncfusion
description: Checkout and learn here all about Placeholder and FloatLabel in Syncfusion Blazor MultiSelect component and more.
platform: Blazor
control: MultiSelect
documentation: ug
---

# Placeholder and Float Label in MultiSelect

## Placeholder

Use the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_Placeholder) property to display brief helper text that describes the expected input. In the following example, the placeholder is set to “Select a game,” which renders as the input element’s placeholder attribute.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder.razor %}

{% endhighlight %}

![Blazor MultiSelect with placeholder](./images/placeholder-and-floatlabel/blazor_MultiSelect_placeholder.png)

## Color of the placeholder text

Change the color of the placeholder by targeting its CSS class `input.e-multiselect::placeholder`, which indicates the placeholder text, and set the desired color using the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-color.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown with color placeholder](./images/style/blazor_multiselect_placeholder-color.png)

## Add mandatory indicator using placeholder

Add a mandatory indicator “*” to the floating label by targeting the `.e-float-text::after` selector and setting the `content` style.

{% highlight cshtml %}

{% include_relative code-snippet/style/placeholder-with-mandatory.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown with mandatory indicator placeholder](./images/style/blazor_multiselect_placeholder-with-mandatory.png)

## FloatLabel

Use the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_FloatLabelType) property to control the floating label behavior of the MultiSelect. When enabled, the placeholder text moves above the input according to the specified mode. FloatLabelType applies only when a Placeholder is defined. The default value is `Never`.

The floating label supports the types of actions as follow.

Type     | Description
------------ | -------------
[Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Auto) | The label floats above the input on focus or when a value is entered.
[Always](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Always) | The label always floats above the input.
[Never](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Never) | The label never floats when a placeholder is present.

The following example demonstrates `FloatLabelType="Auto"`:

{% highlight Razor %}

{% include_relative code-snippet/style/floatLabelType-property.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown with FloatLabelType property](./images/style/blazor_multiselect_floatLabelType-property.gif)

## Customizing the float label element’s focusing color

Customize the component color when it is focused by targeting its CSS class `.e-input-focus::after`, which indicates the input element when it is focused, and set the desired color to the `background` property.

{% highlight cshtml %}

{% include_relative code-snippet/style/focus-color.razor %}

{% endhighlight %}

![Blazor MultiSelect Dropdown focus color](./images/style/blazor_multiselect_focus-color.png)