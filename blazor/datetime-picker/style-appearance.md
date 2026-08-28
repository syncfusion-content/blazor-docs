---
layout: post
title: Style and Appearance in Blazor DateTime Picker | Syncfusion®
description: Customize the Blazor DateTime Picker appearance by overriding its default CSS structure to adjust input, popup, calendar, and time list styles.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# Style and Appearance in Blazor DateTime Picker

Use the following CSS selectors to modify the Blazor DateTime Picker component’s appearance based on user preferences.

## Customizing the appearance of the DateTime Picker container element

Apply the following CSS to adjust the input height and font size for the Blazor DateTime Picker container element. The `.e-input-group` wrapper class is rendered by Syncfusion input components.

```css
/* To specify height and font size */
.e-input-group input.e-input, .e-input-group.e-control-wrapper input.e-input {
        font-size: 20px;
        height: 40px;
    }
```

## Customizing the DateTime Picker icons element

Use the following CSS to style the Blazor DateTime Picker’s date and time icon elements.

```css
/* To specify background color and font size */
.e-datetime-wrapper .e-input-group-icon.e-date-icon, .e-datetime-wrapper .e-input-group-icon.e-time-icon {
        font-size: 16px;
        background-color: blanchedalmond;
    }
```

## Customizing the time picker popup in the DateTime Picker 

Use the following CSS to adjust the height of the time picker popup in the Blazor DateTime Picker.

```css
/* To specify height */
.e-datetimepicker.e-popup {
        height: 100px;
}
```

## Customizing the Calendar popup of the DateTime Picker

See the following section to customize the Calendar’s style and appearance when used within the Blazor DateTime Picker.

[Customizing Calendar's style and appearance](../calendar/style-appearance)

## See also

* [Getting started with Blazor DateTime Picker](./getting-started)