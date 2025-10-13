---
layout: post
title: Style and appearance in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor TimePicker component and more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Style and appearance in Blazor TimePicker Component

The following guidance shows CSS selectors that can be used to customize the TimePicker component’s appearance based on application needs. To avoid global changes, scope overrides by adding a custom class via the CssClass property and targeting that class in your styles.

## Customizing the appearance of TimePicker container element

Use the following CSS to customize the appearance of the TimePicker container element.

```css
/* To specify height and font size */
.e-input-group input.e-input, .e-input-group.e-control-wrapper input.e-input, .e-input-group textarea.e-input, .e-input-group.e-control-wrapper textarea.e-input {
        font-size: 20px;
        height: 40px;
}
```

## Customizing the TimePicker icon element

Use the following CSS to customize the TimePicker icon element.

```css
/* To specify background color and font size */
.e-time-wrapper .e-time-icon.e-icons, *.e-control-wrapper.e-time-wrapper .e-time-icon.e-icons {
        font-size: 20px;
        background-color: beige;
}
```

## Customizing the TimePicker popup

Use the following CSS to customize the TimePicker popup.

```css
/* To specify height */
.e-timepicker.e-popup {
        height: 100px;
}
```

## Customizing the TimePicker popup content

Use the following CSS to customize the TimePicker popup content.

```css
/* To specify height */
.e-timepicker.e-popup .e-list-parent.e-ul li.e-list-item {
        background-color: beige;
        font-size: 20px;
}
```

## Full screen mode support in mobiles and tablets

The TimePicker component’s full-screen mode displays the popup element in full-screen on mobile devices for improved visibility and usability. This feature is supported only on mobile devices in both landscape and portrait orientations. To enable full-screen mode, set the [FullScreen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_FullScreen) property to `true`. This expands the popup to occupy the entire screen on mobile devices.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" FullScreen=true></SfTimePicker>

```

![Blazor TimePicker popup in mobile full-screen mode](./images/blazor-timepicker-full-screen-mode.gif)