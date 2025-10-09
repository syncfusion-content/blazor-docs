---
layout: post
title: Style and Appearance in Blazor DateRangePicker Component | Syncfusion
description: Learn how to customize the style and appearance of the Syncfusion Blazor DateRangePicker using CSS, including container, icon, popup calendar header/content, buttons, hover/selection styles, and mobile full-screen mode.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Style and Appearance in Blazor DateRangePicker Component

Use the following CSS selectors to tailor the DateRangePicker component’s appearance based on user preferences and application themes.

## Customizing the appearance of DateRangePicker container element

Use the following CSS to adjust the input’s font size and height for the DateRangePicker container element.

```css
/* To specify height and font size */
.e-input-group input.e-input, .e-input-group.e-control-wrapper input.e-input {
        font-size: 20px;
        height: 40px;
}
```

## Customizing the DateRangePicker icon element

Use the following CSS to style the DateRangePicker icon’s background color and size.

```css
/* To specify background color and font size */
.e-input-group .e-input-group-icon:last-child, .e-input-group.e-control-wrapper .e-input-group-icon:last-child {
        background-color: darkgray;
        font-size: 14px;
}
```

## Customizing the DateRangePicker popup calendar header

Use the following CSS to customize the popup calendar header area (range summary section).

```css
/* To specify background and height */
.e-daterangepicker.e-popup .e-range-header {
        background: beige;
        height: 80px;
}
```

## Customizing the DateRangePicker popup calendar header title

Use the following CSS to style the start and end labels in the popup header.

```css
/* To specify color and font size */
.e-daterangepicker.e-popup .e-range-header .e-start-label, .e-daterangepicker.e-popup .e-range-header .e-end-label {
        color: brown;
        font-size: 30px;
}
```

## Customizing the DateRangePicker popup calendar content

Use the following CSS to change the popup calendar content background.

```css
/* To specify background color */
.e-daterangepicker.e-popup .e-calendar {
        background-color: brown;
}
```

## Customizing the DateRangePicker popup calendar content title

Use the following CSS to style the calendar title (month/year) in the popup.

```css
/* To specify color and font size */
.e-daterangepicker.e-popup .e-calendar .e-header .e-title {
        color: beige;
        font-size: 20px;
}
```

## Customizing the DateRangePicker popup calendar previous and next icon

Use the following CSS to change the size of the previous and next navigation icons.

```css
/* To specify font size */
.e-calendar .e-header .e-prev, .e-calendar .e-header .e-next, .e-bigger.e-small .e-calendar .e-header .e-prev, .e-bigger.e-small .e-calendar .e-header .e-next {
        font-size: 20px;
}
```

## Customizing the DateRangePicker popup calendar date cell grid on hovering

Use the following CSS to customize the hover style for date cells in the popup calendar.

```css
/* To specify background color and border */
.e-calendar .e-content td:hover span.e-day {
        background-color: beige;
        border: 1px solid black;   
}
```

## Customizing the DateRangePicker popup calendar primary button in footer

Use the following CSS to customize the primary Apply button in the popup footer (disabled state shown below).

```css
/* To specify background color and border color */
.e-daterangepicker.e-popup .e-footer .e-btn.e-apply.e-flat.e-primary:disabled, .e-daterangepicker.e-popup .e-footer .e-btn.e-apply.e-flat.e-primary:disabled, .e-daterangepicker.e-popup .e-footer .e-css.e-btn.e-apply.e-flat.e-primary:disabled, .e-daterangepicker.e-popup .e-footer .e-css.e-btn.e-apply.e-flat.e-primary:disabled {
        background-color: brown;
        border-color: black;  
}
```

## Customizing the DateRangePicker popup calendar cancel button in footer

Use the following CSS to customize the Cancel button in the popup footer.

```css
/* To specify background color, color, and border color */
.e-daterangepicker.e-popup .e-footer .e-btn.e-flat, .e-daterangepicker.e-popup .e-footer .e-css.e-btn.e-flat {
        background-color: beige;
        border-color: black;
        color: maroon;
}
```

## Customizing the footer element in the DateRangePicker popup calendar 

Use the following CSS to adjust the popup footer container’s background and size.

```css
/* To specify background color, color, and border color */
.e-daterangepicker.e-popup .e-footer {
        background-color: beige;
        height: 50px;
}
```

## Customizing the selected date cell grid in the DateRangePicker popup calendar 

Use the following CSS to style the focused “today” cell when selected.

```css
/* To specify background and border */
.e-calendar .e-content td.e-focused-date.e-today span.e-day {
        background: lightgrey;
        border: 1px solid black;
        
    }
```

## Full screen mode support in mobiles and tablets

The DateRangePicker supports a full-screen popup on mobile devices to improve visibility and usability in both landscape and portrait orientations. To enable full screen mode, set the [FullScreen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_FullScreen) property to `true`. On mobile devices, the calendar and presets popup expands to occupy the entire screen; desktop behavior is unchanged.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" FullScreen=true></SfDateRangePicker>

```

![Blazor DateRangePicker popup displayed in mobile full-screen mode](./images/blazor-daterangepicker-full-screen-mode.gif)