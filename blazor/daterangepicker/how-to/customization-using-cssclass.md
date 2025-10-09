---
layout: post
title: Customization using CssClass in Blazor DateRangePicker | Syncfusion
description: Learn here all about Customization using CssClass in Syncfusion Blazor DateRangePicker component and more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Customization Using CssClass in Blazor DateRangePicker Component

To customize the UI, use [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DateRangePickerModel-1.html#Syncfusion_Blazor_Calendars_DateRangePickerModel_1_CssClass), which adds a custom class to the DateRangePicker’s root element. By targeting this class in your CSS, existing styles can be overridden in a scoped and maintainable way. Multiple class names can be provided (space-separated). Depending on the selected theme, increased selector specificity may be required to override defaults.

Following is the list of classes that provide a flexible way to customize the DateRangePicker component:

| **Class Name** | **Description** |
| --- | --- |
| e-date-range-wrapper | Applied to the DateRangePicker wrapper. |
| e-range-icon | Applied to the DateRangePicker icon. |
| e-popup | Applied to the DateRangePicker popup wrapper. |
| e-calendar | Applied to both calendar elements. |
| e-right-calendar | Applied to the right calendar element. |
| e-left-calendar | Applied to the left calendar element. |
| e-start-label | Applied to the start label in the popup. |
| e-end-calendar | Applied to the end label in the popup. |
| e-day-span | Applied to the day span details label in the popup. |
| e-footer | Applied to footer elements in the popup. |
| e-apply | Applied to the Apply button in the popup footer. |
| e-cancel | Applied to the Cancel button in the popup footer. |
| e-header | Applied to the calendar header. |
| e-title | Applied to the calendar title. |
| e-icon-container | Applied to the calendar previous and next icon container. |
| e-prev | Applied to the calendar previous icon. |
| e-next | Applied to the calendar next icon. |
| e-weekend | Applied to calendar weekend dates. |
| e-other-month | Applied to calendar other-month dates. |
| e-day | Applied to each day cell of the calendar. |
| e-selected | Applied to selected dates in the calendar. |
| e-disabled | Applied to disabled dates in the calendar. |

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" Placeholder="Select a range" CssClass="CustomCSS" ></SfDateRangePicker>

<style>
     .CustomCSS .e-calendar .e-content .e-selected span.e-day,
    .CustomCSS .e-calendar .e-content .e-selected span.e-day:hover,
    .CustomCSS .e-calendar .e-content .e-today.e-selected:hover span.e-day,
    .CustomCSS .e-calendar .e-content .e-today.e-selected span.e-day,
    .CustomCSS .e-calendar .e-content .e-selected:hover span.e-day  {
        background-color: #35b86b;
    }

    .CustomCSS .e-calendar .e-content .e-today span.e-day,
    .CustomCSS .e-calendar .e-content .e-focused-date.e-today span.e-day {
        border: 1px solid #35b86b;
        color: #ff3337;
    }

    .CustomCSS .e-calendar .e-content .e-weekend span {
        color: #ff3337;
    }

    .CustomCSS.e-date-range-wrapper .e-input-group-icon.e-icons.e-active,
    .CustomCSS .e-btn.e-flat,
    .CustomCSS .e-btn.e-flat:hover {
        color: #35b86b;
    }
</style>
```

![Blazor DateRangePicker customized with CssClass to style selected, today, and weekend dates](../images/blazor-daterangepicker-cssclass-customization.png)

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap5) to understand how to present and manipulate data.