---
layout: post
title: Style and appearance in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor MultiColumn ComboBox component and more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Style and appearance in Blazor MultiColumn ComboBox Component

Use the following options and CSS hooks to customize the appearance and interaction states of the Blazor MultiColumn ComboBox. Add styles in a global stylesheet (or scoped CSS for the page/component) based on your project setup.

## Read-only mode

Set the [ReadOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ReadOnly) property to `true` to prevent users from changing the value while keeping the component focusable and interactive (for example, users can still focus and open the popup to view items).

{% highlight cshtml %}

{% include_relative code-snippet/style/readonly-mode.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVAiBLQUvNGLyuy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disabled state

Set the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Disabled) property to `true` to make the component non-interactive and inaccessible via keyboard (removed from tab order). Disabled components do not trigger UI events.

{% highlight cshtml %}

{% include_relative code-snippet/style/disabled-state.razor %}

{% endhighlight %}

## Applying custom CSS classes

Apply one or more custom CSS classes to the root element using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_CssClass) property. These classes can be used to convey visual states or brand styling.

Common examples:
- `e-success`: Renders a success state (typically green accent) on the input.
- `e-warning`: Renders a warning state (typically orange accent) on the input.
- `e-error`: Renders an error state (typically red accent) on the input.
- `e-outline`: Outline style support is specific to the Material theme.

{% highlight Razor %}

{% include_relative code-snippet/style/cssclass-properties.razor %}

{% endhighlight %} 

## Customizing the disabled component’s text color

Customize the text color for disabled inputs by targeting the `.e-input[disabled]` selector and setting the `-webkit-text-fill-color` (and related properties as needed) to your desired color.

{% highlight cshtml %}

{% include_relative code-snippet/style/disable-text-color.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhqMVBwUFMudrwO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}