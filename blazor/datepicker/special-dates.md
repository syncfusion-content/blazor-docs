---
layout: post
title: Special Dates in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Special Dates in Syncfusion Blazor DatePicker component and more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Render the Blazor DatePicker Component with highlighted Special Dates

You can customize specific dates in a DatePicker by using the [OnRenderDayCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html#Syncfusion_Blazor_Calendars_DatePickerEvents_1_OnRenderDayCell) event. This event gets triggered on each day cell element creation that allows you to customize or disable the specific dates in the calendar. Here 10, 15, and 25 dates are customized with custom styles by adding the special-dates class.

```cshtml
@using Syncfusion.Blazor.Calendars
<div class="control-wrapper">
    <SfDatePicker TValue="DateTime?" Placeholder="Choose a Date" ShowClearButton="true">
        <DatePickerEvents TValue="DateTime?" OnRenderDayCell="CustomDates" ValueChange="OnChange"></DatePickerEvents>
    </SfDatePicker>
    <div id="display-date">
        <span>Selected Day : @SelectedValue</span>
    </div>
</div>
@code {
    public string SelectedValue { get; set; }
    public void CustomDates(RenderDayCellEventArgs args)
    {
        if ((args.Date.Month == 3 && args.Date.Day == 22) ||
            (args.Date.Month == 5 && args.Date.Day == 14) ||
            (args.Date.Month == 7 && args.Date.Day == 21) ||
            (args.Date.Month == 11 && args.Date.Day == 14) ||
            (args.Date.Month == 12 && args.Date.Day == 25))
        {
            args.CellData.ClassList += " special-dates";
        }
    }
    public void OnChange(ChangedEventArgs<DateTime?> args)
    {
        var Count = 0;
        if (args.Value.Value.Month == 3 && args.Value.Value.Day == 22)
        {
            this.SelectedValue = "Easter";
            Count++;
        }
        if (args.Value.Value.Month == 5 && args.Value.Value.Day == 14)
        {
            this.SelectedValue = "Ramzon";
            Count++;
        }
        if (args.Value.Value.Month == 7 && args.Value.Value.Day == 21)
        {
            this.SelectedValue = "Bakrid";
            Count++;
        }
        if (args.Value.Value.Month == 11 && args.Value.Value.Day == 14)
        {
            this.SelectedValue = "Diwali";
            Count++;
        }
        if (args.Value.Value.Month == 12 && args.Value.Value.Day == 25)
        {
            this.SelectedValue = "Christmas";
            Count++;
        }
        if (Count == 0)
        {
            this.SelectedValue = "";
        }
    }
}
<style>
    #display-date {
        max-width: 270px;
        padding: 15px 0;
        font-size: 13px;
    }

    .control-wrapper {
        width: 300px;
        margin: 0 auto;
        padding-top: 50px;
    }

    .special-dates .e-day:before {
        content: '\e271';
        font-family: e-icons;
        font-size: 15px;
        color: blue;
        position: relative;
        vertical-align: text-top;
        bottom: -4px;
        right: -15px;
        margin-left: -15px;
    }

    .special-dates.e-selected .e-day:before {
        color: white;
    }

    .special-dates span.e-day {
        color: blue;
    }

    .bootstrap4 .special-dates .e-day:before {
        content: '\e7a5';
        font-family: e-icons;
        font-size: 7px;
        color: blue;
        position: relative;
        vertical-align: text-top;
        bottom: -4px;
        right: -12px;
        margin-left: -6px;
    }

    .bootstrap4 .special-dates.e-selected .e-day:before {
        color: white;
    }

    .material-dark .special-dates span.e-day,
    .fabric-dark .special-dates span.e-day,
    .bootstrap-dark .special-dates span.e-day {
        color: #ff7500;
    }

        .material-dark .special-dates span.e-day:before,
        .fabric-dark .special-dates span.e-day:before,
        .bootstrap-dark .special-dates span.e-day:before {
            color: #ff7500;
        }

    .material-dark .special-dates.e-selected span.e-day:before,
    .fabric-dark .special-dates.e-selected span.e-day:before,
    .bootstrap-dark .special-dates.e-selected span.e-day:before {
        color: white;
    }
</style>

```

The output will be as follows.

![Blazor DatePicker Special Dates](./images/blazor_datepicker_special_dates.png)



