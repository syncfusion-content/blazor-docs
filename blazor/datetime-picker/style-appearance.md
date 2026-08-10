---
layout: post
title: Style and appearance in Blazor Datetime Picker Component | Syncfusion®
description: Checkout and learn here all about Style and appearance in Blazor Datetime Picker component and more.
platform: Blazor
control: Datetime Picker
documentation: ug
---

# Style and Appearance in Blazor Datetime Picker Component

Use the following CSS selectors to modify the DateTimePicker component’s appearance based on user preferences.

## Customizing the appearance of Datetime Picker container element

Apply the following CSS to adjust the input height and font size for the DateTimePicker container element. The `.e-input-group` wrapper class is rendered by Syncfusion input components.

```css
/* To specify height and font size */
.e-input-group input.e-input, .e-input-group.e-control-wrapper input.e-input {
        font-size: 20px;
        height: 40px;
    }
```

## Customizing the Datetime Picker icons element

Use the following CSS to style the DateTimePicker’s date and time icon elements.

```css
/* To specify background color and font size */
.e-datetime-wrapper .e-input-group-icon.e-date-icon, .e-datetime-wrapper .e-input-group-icon.e-time-icon {
        font-size: 16px;
        background-color: blanchedalmond;
    }
```

## Customizing the time picker popup in the Datetime Picker 

Use the following CSS to adjust the height of the time picker popup in the DateTimePicker.

```css
/* To specify height */
.e-datetimepicker.e-popup {
        height: 100px;
}
```

## Customizing the Calendar popup of the Datetime Picker

See the following section to customize the Calendar’s style and appearance when used within the DateTimePicker.

[Customizing Calendar's style and appearance](../calendar/style-appearance)

## See also

* [Getting started with Blazor DateTimePicker](./getting-started)