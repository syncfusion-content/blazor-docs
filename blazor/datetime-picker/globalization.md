---
layout: post
title: Globalization in Blazor DateTimePicker Component | Syncfusion®
description: Checkout and learn here all about Globalization in Blazor Datetime Picker component and much more details.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Globalization in Blazor Datetime Picker Component

The [Blazor DateTimePicker](https://www.syncfusion.com/blazor-components/blazor-datetime-picker) component reflects the application's culture based on the system culture. Date and time formats, month and day names, and other culture-specific settings are derived automatically from the current culture.

## Right-To-Left

The DateTimePicker supports right-to-left (RTL) layout for languages such as Arabic and Hebrew. Set `EnableRtl="true"` to render the component right-to-left. The default value is `false`. RTL layout is independent of the system culture; both can be combined to achieve the desired language and layout.

The following example enables RTL layout on the DateTimePicker.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" EnableRtl="true"></SfDateTimePicker>
```

![Blazor DateTimePicker with right-to-left layout](./images/blazor-datetimepicker-right-to-left.webp)
