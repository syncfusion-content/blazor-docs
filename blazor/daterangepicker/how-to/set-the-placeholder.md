---
layout: post
title: Set the Placeholder in Blazor DateRangePicker Component | Syncfusion
description: Learn how to set the Placeholder in the Syncfusion Blazor DateRangePicker component to display hint text in the input.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Set the Placeholder in Blazor DateRangePicker Component

The following code demonstrates how to set the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_Placeholder) in the DateRangePicker component.

Using the `Placeholder` property, a short hint can be displayed in the input element to guide users before a value is selected.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" Placeholder="Choose a date range"></SfDateRangePicker>
```

![Blazor DateRangePicker displaying hint text using the Placeholder property](../images/blazor-daterangepicker-hint-element.png)

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap5) to understand how to present and manipulate data.