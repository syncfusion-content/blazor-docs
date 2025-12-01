---
layout: post
title: Placeholder/FloatLabel in Blazor MultiColumn ComboBox | Syncfusion
description: Checkout and learn here all about Placeholder and FloatLabel in Syncfusion Blazor MultiColumn ComboBox component and more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Placeholder and Float Label in MultiColumn ComboBox

## Placeholder

Use the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Placeholder) property to display a short hint about the expected value when no selection has been made. In the following example, setting `Select a game` guides the user until an item is chosen.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDVTNaLAqYKlJFoq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with placeholder](./images/placeholder-and-floatlabel/blazor_combobox_placeholder.png)" %}

<!-- ## Color of the placeholder text

You can change the color of the placeholder by targeting its CSS class `input.e-input::placeholder`, which indicates the placeholder text, and set the desired color using the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-color.razor %}

{% endhighlight %} -->

## Add mandatory indicator using placeholder

A visual mandatory indicator (*) can be appended to the floating placeholder label by targeting the `.e-float-text::after` CSS selector and setting the `content` style.

For accessibility, pair this visual cue with semantic validation (for example, apply `[Required]` to the bound model property or set `aria-required="true"`) so assistive technologies convey the required state.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/placeholder-with-mandatory.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBfDurAqkybkRoR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with mandatory indicator placeholder](./images/placeholder-and-floatlabel/blazor_combobox_placeholder-with-mandatory.png)" %}

## Floating label

Use the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html) property to control how the placeholder text floats as a label above the input. Floating labels work when a `Placeholder` is provided. The default is `Never`.

The floating label supports the following options.

Type     | Description
------------ | -------------
  [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Auto)       | Floats the label on focus or after a value is entered.
  [Always](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Always)     | Always keeps the label floated above the input.
  [Never](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FloatLabelType.html#Syncfusion_Blazor_Inputs_FloatLabelType_Never)      | Never floats the label when a placeholder is available (default).

The `FloatLabelType` set to `Auto` is demonstrated in the following example.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDrzXarAUYxRzqxe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with float label](./images/placeholder-and-floatlabel/blazor_combobox_floatlabel.gif)" %}

<!-- ## Customizing the float label element’s focusing color

You can change the text color of the floating label when it is focused by targeting its CSS classes `.e-input-focus` and `.e-float-text.e-label-top`. These classes indicate the floating label text while it is focused state and set the desired color using the `color` property.

{% highlight cshtml %}

{% include_relative code-snippet/placeholder-and-floatlabel/floatlabel-focusing-color.razor %}

{% endhighlight %} -->