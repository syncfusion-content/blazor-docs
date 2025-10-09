---
layout: post
title: Placeholder and float label in Blazor AutoComplete component | Syncfusion
description: Check out how to use the placeholder and FloatLabelType with the Syncfusion Blazor AutoComplete component, and learn to customize placeholder and float label styles.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Placeholder and Float Label in AutoComplete

This section describes how to configure the placeholder and float label behavior in the Blazor AutoComplete component and how to customize their styles.

## Placeholder

Use the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-1.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_1_Placeholder) property to display guidance text for the expected input value. In the following example, setting `Select a game` as the `Placeholder` value applies it to the input element’s placeholder attribute.

{% highlight Razor %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder.razor %}

{% endhighlight %}

![Blazor AutoComplete showing placeholder text in the input](./images/placeholder-and-floatlabel/blazor_autocomplete_placeholder.png)

## Color of the placeholder text

Change the placeholder text color by targeting the `input.e-input::placeholder` selector and setting the desired CSS `color` value.

{% highlight Razor %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-color.razor %}

{% endhighlight %}

![Blazor AutoComplete with customized placeholder text color](./images/placeholder-and-floatlabel/blazor_autocomplete_placeholder-with-color.png)

## Add mandatory indicator using placeholder

Apply a mandatory indicator (*) to the floating label by targeting the `.e-float-text::after` selector and setting the `content` style. Note that this customizes the floating label element rather than the native placeholder text.

{% highlight Razor %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-mandatory.razor %}

{% endhighlight %}

![Blazor AutoComplete with a mandatory indicator on the floating label](./images/placeholder-and-floatlabel/blazor_autocomplete_placeholder-with-mandatory.png)

## FloatLabel

Use the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-1.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_1_FloatLabelType) property to control how the `Placeholder` text floats above the AutoComplete. `FloatLabelType` applies only when `Placeholder` is set. The default value is `Never`.

The floating label supports the following modes:

Type     | Description
------------ | -------------
  [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Auto)       | The label floats above the input on focus or when a value is entered.
  [Always](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Always)     | The label always floats above the input.
  [Never](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Never)      | The label never floats above the input when a placeholder is available.

The `FloatLabelType` set to `Auto` is demonstrated in the following example.

{% highlight Razor %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel.razor %}

{% endhighlight %}

![Blazor AutoComplete with floating label moving above on focus and input](./images/placeholder-and-floatlabel/blazor_autocomplete_floatlabel.gif)

## Customizing the float label element’s focusing color

Change the floating label text color when focused by targeting the `.e-input-focus .e-float-text.e-label-top` selector and applying the desired `color`.

{% highlight Razor %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel-focusing-color.razor %}

{% endhighlight %}

![Blazor AutoComplete with customized floating label focus color](./images/placeholder-and-floatlabel/blazor_autocomplete_floatlabel-focusing-color.png)