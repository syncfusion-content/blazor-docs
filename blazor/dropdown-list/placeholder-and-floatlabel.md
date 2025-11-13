---
layout: post
title: Placeholder/FloatLabel in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Placeholder and FloatLabel in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDownList
documentation: ug
---

# Placeholder and Float Label in DropDownList

## Placeholder

Use the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Placeholder) property to show a short hint describing the expected value. In the following example, “Select a game” is set as the placeholder and displayed in the input when no value is selected.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder.razor %}

{% endhighlight %}

![Blazor DropDownList with placeholder](./images/placeholder-and-floatlabel/blazor_dropdown_placeholder.png)

## Color of the placeholder text

Change the placeholder color by targeting the placeholder selector (for example, `input.e-input::placeholder`) and applying the desired `color` value.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-color.razor %}

{% endhighlight %}

![Blazor DropDownList with colored placeholder](./images/placeholder-and-floatlabel/blazor_dropdown_placeholder-with-color.png)

## Add mandatory indicator using placeholder

Add a visual required indicator (such as `*`) to the floating label by targeting `.e-float-text::after` and setting the `content` style. This is a visual cue only; pair it with form validation to enforce required input.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-mandatory.razor %}

{% endhighlight %}

![Blazor DropDownList with mandatory indicator in placeholder](./images/placeholder-and-floatlabel/blazor_dropdown_placeholder-with-mandatory.png)

## FloatLabel

Use the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FloatLabelType) property to control floating label behavior, where the `Placeholder` text moves above the input. `FloatLabelType` works only when a `Placeholder` is set. The default value is `Never`.

The floating label supports the following behaviors:

Type     | Description
------------ | -------------
  [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Auto)       | Floats the label after focus or when a value is selected.
  [Always](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Always)     | Always displays the label above the input.
  [Never](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Never)      | Never floats the label when the placeholder is available.

The `FloatLabelType` set to `Auto` is demonstrated in the following example.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel.razor %}

{% endhighlight %}

![Blazor DropDownList with floating label](./images/placeholder-and-floatlabel/blazor_dropdown_floatlabel.gif)

## Customizing the float label element’s focusing color

Customize the floating label color on focus by targeting `.e-input-focus .e-float-text.e-label-top` and setting the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel-focusing-color.razor %}

{% endhighlight %}

![Blazor DropDownList with customized floating label focus color](./images/placeholder-and-floatlabel/blazor_dropdown_floatlabel-focusing-color.png)