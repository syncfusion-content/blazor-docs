---
layout: post
title: Style and Appearance in Blazor DatePicker Component | Syncfusion
description: Learn how to customize the style and appearance of the Syncfusion Blazor DatePicker using CSS, including container, icon, label, background color, and mobile full-screen.
platform: Blazor
control: DatePicker
documentation: ug
---

# Style and Appearance in Blazor DatePicker Component

The following guidance describes the CSS structure that can be used to tailor the DatePicker component’s appearance based on user preferences.

## Customizing the appearance of DatePicker container element

Use the following CSS to adjust the input height and font size for the DatePicker’s container element.

```css
/* To specify height and font size */
.e-input-group input.e-input, .e-input-group.e-control-wrapper input.e-input {
        height: 40px;
        font-size: 20px;
}
```

## Customizing the DatePicker icon element

Use the following CSS to modify the DatePicker’s icon size and background color.

```css
/* To specify background color and font size */
.e-input-group .e-input-group-icon:last-child, .e-input-group.e-control-wrapper .e-input-group-icon:last-child {
        font-size: 12px;
        background-color: darkgray;
}
```

## Customizing the appearance of the DatePicker label 

To customize the floating label’s appearance, use the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfInputTextBase-1.html#Syncfusion_Blazor_Inputs_SfInputTextBase_1_CssClass) property with custom CSS. The example below applies a compact label size and color.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Placeholder="earliest date..." FloatLabelType="@FloatLabelType.Always" CssClass="e-small data-color" Width="150px">
</SfDatePicker>

```
```css
    .data-color.e-float-input.e-control-wrapper label.e-float-text,
    .data-color.e-float-input input:valid~label.e-float-text, 
    .data-color.e-float-input input~label.e-label-top.e-float-text,
    .data-color.e-float-input.e-input-focus label.e-float-text,
    .data-color.e-float-input:not(.e-error) input:valid~label.e-float-text, 
    .data-color.e-float-input:not(.e-error) input~label.e-label-top.e-float-text
      {
      font-size : 10px;
      color: blue;
    }
```

## Adding background color to DatePicker container element

Customize the background color of the DatePicker’s visible input by targeting the appropriate wrapper class and setting the `background-color` property.

{% tabs %}
{% highlight razor %}

{% include_relative code-snippet/background-color.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor DatePicker with a customized background color](./images/blazor-datepicker-background_color.png)

## Full screen mode support in mobiles and tablets

The DatePicker supports full-screen mode on mobile devices to improve popup visibility and usability in both landscape and portrait orientations. To enable full-screen mode, set the [FullScreen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_FullScreen) property to `true`. On mobile devices, the calendar expands to occupy the entire screen; desktop behavior is unchanged.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" FullScreen=true></SfDatePicker>

```

![Blazor DatePicker popup displayed in mobile full-screen mode](./images/blazor-datepicker-full-screen.gif)

Also see the following section for additional Calendar styling options:

[Customizing Calendar's style and appearance](../calendar/style-appearance)