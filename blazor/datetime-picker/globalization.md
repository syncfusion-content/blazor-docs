---
layout: post
title: Globalization in Blazor DateTime Picker | Syncfusion®
description: Globalize the Blazor DateTime Picker for different cultures with right-to-left rendering, localized names, and culture-specific date and time formats.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# Globalization in Blazor DateTime Picker

The [Blazor DateTime Picker](https://www.syncfusion.com/blazor-components/blazor-datetime-picker) component reflects the application's culture based on the system culture. Date and time formats, month and day names, and other culture-specific settings are derived automatically from the current culture.

## Right-To-Left

The Blazor DateTime Picker supports right-to-left (RTL) layout for languages such as Arabic and Hebrew. Set `EnableRtl="true"` to render the component right-to-left. The default value is `false`. RTL layout is independent of the system culture; both can be combined to achieve the desired language and layout.

The following example enables RTL layout on the Blazor DateTime Picker.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" EnableRtl="true"></SfDateTimePicker>
```

![Blazor DateTime Picker with right-to-left layout](./images/blazor-datetimepicker-right-to-left.webp)
