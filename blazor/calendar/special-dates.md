---
layout: post
title: Special Dates in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Special Dates in Syncfusion Blazor Calendar component and more details.
platform: Blazor
control: Calendar
documentation: ug
---

# Special Dates in Blazor Calendar Component

Customize specific dates in a [Blazor Calendar](https://www.syncfusion.com/blazor-components/blazor-calendar) by handling the [OnRenderDayCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarEvents-1.html#Syncfusion_Blazor_Calendars_CalendarEvents_1_OnRenderDayCell) event. This event fires for each day cell as it is created, allowing the addition of CSS classes and, if needed, disabling particular dates. The following example highlights two sets of days in the current month with custom styles using the personal-appointment and official-appointment classes, and updates a label on selection via ValueChange.

```cshtml

@using Syncfusion.Blazor.Calendars

<div class="control-wrapper">
    <SfCalendar TValue="DateTime?" @bind-Value="@SelectedDate">
        <CalendarEvents TValue="DateTime?" OnRenderDayCell="CustomDates" ValueChange="OnChange"></CalendarEvents>
    </SfCalendar>
</div>
<div id="display-date">
    <span>Selected Day : @SelectedValue</span>
</div>
@code {
    public DateTime? SelectedDate { get; set; }
    public string SelectedValue { get; set; } = DateTime.Now.ToString("M/d/yyyy");
    public DateTime? CurrentDate { get; set; } = DateTime.Now;
    public void CustomDates(RenderDayCellEventArgs args)
    {
        if (args.CurrentView == "Month") {
            var CurrentMonth = CurrentDate.Value.Month;
            if (args.Date.Month == CurrentMonth && (args.Date.Day == 7 || args.Date.Day == 14 || args.Date.Day == 24 || args.Date.Day == 29)) {
                args.CellData.ClassList += " personal-appointment";
            }
            if (args.Date.Month == CurrentMonth && (args.Date.Day == 3 || args.Date.Day == 11 || args.Date.Day == 17 || args.Date.Day == 22))
            {
                args.CellData.ClassList += " official-appointment";
            }
        }
    }
    public void OnChange(ChangedEventArgs<DateTime?> args)
    {
        var Count = 0;
        var CurrentMonth = CurrentDate.Value.Month;
        if (args.Value.Value.Month == CurrentMonth && (args.Value.Value.Day == 7 || args.Value.Value.Day == 14 || args.Value.Value.Day == 24 || args.Value.Value.Day == 29))
        {
            this.SelectedValue = this.SelectedDate?.ToString("M/d/yyyy") + " (Personal appointment)";
            Count++;
        }
        if (args.Value.Value.Month == CurrentMonth && (args.Value.Value.Day == 3 || args.Value.Value.Day == 11 || args.Value.Value.Day == 17 || args.Value.Value.Day == 22))
        {
            this.SelectedValue = this.SelectedDate?.ToString("M/d/yyyy") + " (Official appointment)";
            Count++;
        }
        if (Count == 0)
        {
            this.SelectedValue = this.SelectedDate?.ToString("M/d/yyyy");
        }
    }
}
<style>
    #display-date {
        max-width: 300px;
        margin: 0 auto;
        padding: 15px 0;
        font-size: 13px;
    }
    .control-wrapper {
        width: 300px;
        margin: 0 auto;
        padding-top: 20px;
    }
    .e-calendar .e-content .e-cell.personal-appointment span.e-day,
    .e-calendar .e-content td:hover.e-cell.personal-appointment span.e-day,
    .e-calendar .e-content td.e-selected.e-focused-date.e-cell.personal-appointment span.e-day {
        color: #28a745;
        font-weight: 800;
    }
    .e-calendar .e-content .e-cell.official-appointment span.e-day,
    .e-calendar .e-content td:hover.e-cell.official-appointment span.e-day,
    .e-calendar .e-content td.e-selected.e-focused-date.e-cell.official-appointment span.e-day {
        color: #dc3545;
        font-weight: 800;
    }
    .e-calendar .e-content td.e-selected.e-focused-date.e-cell.personal-appointment span.e-day,
    .e-calendar .e-content td.e-selected.e-focused-date.e-cell.official-appointment span.e-day {
        background-color: #b511485e;
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVAMBLBLyofGefV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Calendar with special dates](./images/blazor_calendar_special_dates.png)" %}

N> The `RenderDayCellEventArgs` includes a `CurrentView` property that identifies the active calendar view during rendering. Possible values are `Month`, `Year`, and `Decade`. Use this to apply view-specific logic within the [OnRenderDayCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarEvents-1.html#Syncfusion_Blazor_Calendars_CalendarEvents_1_OnRenderDayCell) handler. This property is useful for customizing the rendering of day cells based on the calendar's current view.