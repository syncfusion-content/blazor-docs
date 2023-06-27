---
layout: post
title: Recurrence editor in Blazor Scheduler Component | Syncfusion
description: Checkout and learn here all about Recurrence editor in Syncfusion Blazor Scheduler component.
platform: Blazor
control: Scheduler
documentation: ug
---

# Recurrence Editor

The Recurrence editor is integrated into Scheduler editor window by default, to process the recurrence rule generation for events. Apart from this, it can also be used as an individual component referring from the Scheduler repository to work with the recurrence related processes.

> All the valid recurrence rule string mentioned in the [iCalendar](https://tools.ietf.org/html/rfc5545#section-3.3.10) specifications are applicable to use with the recurrence editor.

## Customizing the repeat type option in editor

By default, there are 5 types of repeat options available in recurrence editor such as,

* Never
* Daily
* Weekly
* Monthly
* Yearly

It is possible to customize the recurrence editor to display only the specific repeat options such as `Daily` and `Weekly` options alone by setting the appropriate `Frequencies` option.

```cshtml
@using Syncfusion.Blazor.Schedule
<div>
<SfRecurrenceEditor Frequencies="@Repeats"></SfRecurrenceEditor>
</div>
@code {
    List<RepeatType> Repeats = new List<RepeatType>()
    {
       RepeatType.None, RepeatType.Daily, RepeatType.Weekly
    };
}
```

The other properties available in recurrence editor are tabulated below,

| Properties | Type | Description |
|------------|------|-------------|
| FirstDayOfWeek | number | Sets the first day of the week on recurrence editor.|
| StartDate | Date | Sets the start date from which date the recurrence event starts. |
| DateFormat | string | Sets the specific date format on recurrence editor.|
| Locale | string | Sets the locale to be applied on recurrence editor.|
| CssClass | string | Allows styling to be applied on recurrence editor with custom class names.|
| EnableRtl | boolean | Allows recurrence editor to render in RTL mode.|
| MinDate | Date | Sets the minimum date on recurrence editor.|
| MaxDate | Date | Sets the maximum date on recurrence editor.|
| Value | string | Sets the recurrence rule value on recurrence editor. |
| SelectedType | number | Sets the specific repeat type on the recurrence editor.|

## Customizing the End Type Option in Editor

By default, there are 3 types of end options available in the recurrence editor such as:

* Never
* Until
* Count

It is possible to customize the recurrence editor to display only the specific end options, such as the `Until` and `Count` options alone, by setting the appropriate `EndTypes` option.

```cshtml
@using Syncfusion.Blazor.Schedule
<div>
<SfRecurrenceEditor EndTypes="@Endtypes"></SfRecurrenceEditor>
</div>
@code {
    List<EndType> Endtypes = new List<EndType>()
    {
       EndType.Until, EndType.Count
    };
}
```

## Accessing the recurrence rule string

The recurrence rule is usually generated based on the options selected from the recurrence editor and also it follows the [`iCalendar`](https://tools.ietf.org/html/rfc5545#section-3.3.10) specifications. The generated recurrence rule string is a valid one to be used with the Scheduler event’s recurrence rule field.

There is a `ValueChanged` event available in recurrence editor, that triggers on every time the fields of recurrence editor tends to change. Within this event argument, you can access the generated recurrence value through the `value` option as shown in the following code example.

```cshtml
<div class="recurrence-editor-wrap">
    <div style="padding-bottom: 15px;">
        <label>Rule Output</label>
        <div class="rule-output-container">
            <div id="rule-output">
                @if (RecurrenceRule == "")
                {
                    <text>Select Rule</text>
                }
                else
                {
                    <text>@RecurrenceRule</text>
                }
            </div>
        </div>
    </div>
    <div>
        <SfRecurrenceEditor Value="@RecurrenceRule" ValueChanged="HandleRecurrenceEditorChange"></SfRecurrenceEditor>
    </div>
</div>

@code {
    string RecurrenceRule { get; set; } = string.Empty;
    ElementReference RuleOutputRef;
    async Task HandleRecurrenceEditorChange(string value)
    {
        RecurrenceRule = value;
    }
}

<style>
    .recurrence-editor-wrap {
        margin: 0 25%;
    }

    .rule-output-container {
        height: auto;
        border: 1px solid #969696;
    }

    #rule-output {
        padding: 8px 4px;
        text-align: center;
        min-height: 20px;
        overflow: hidden;
        overflow-wrap: break-word;
    }
</style>
```

## Set specific value on recurrence editor

It is possible to display the recurrence editor with specific options loaded initially, based on the rule string that we provide. The fields of recurrence editor will change its values accordingly, when we provide a particular rule through the `SetRecurrenceRule` method.

```cshtml
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.DropDowns
    <div class="recurrence-editor-wrap">
        <div class="ddlarea">
            <span class="spanarea">Select Rule</span>
            <div class="ddlcontent">
                <SfDropDownList DataSource="@DropdownData" TValue="string" TItem="DropDownFields" @bind-Value="@RecurrenceValue" PopupHeight="200" PopupWidth="auto">
                    <DropDownListEvents ValueChange="OnRuleChange" TItem="DropDownFields" TValue="string"></DropDownListEvents>
                    <DropDownListFieldSettings Value="Value" Text="Value"></DropDownListFieldSettings>
                </SfDropDownList>
            </div>
        </div>
        <div>
            <SfRecurrenceEditor @ref="RecurrenceEditorRef" Value="@RecurrenceValue"></SfRecurrenceEditor>
        </div>
    </div>
@code {
    SfRecurrenceEditor RecurrenceEditorRef;
    string RecurrenceValue = "FREQ=DAILY;INTERVAL=2;COUNT=8";
    List<DropDownFields> DropdownData = new List<DropDownFields>() {
        new DropDownFields() { Value = "FREQ=DAILY;INTERVAL=1" },
        new DropDownFields() { Value = "FREQ=DAILY;INTERVAL=2;UNTIL=20410606T000000Z" },
        new DropDownFields() { Value = "FREQ=DAILY;INTERVAL=2;COUNT=8" },
        new DropDownFields() { Value = "FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;INTERVAL=1;UNTIL=20410729T000000Z" },
        new DropDownFields() { Value = "FREQ=MONTHLY;BYDAY=FR;BYSETPOS=2;INTERVAL=1;UNTIL=20410729T000000Z" },
        new DropDownFields() { Value = "FREQ=MONTHLY;BYDAY=FR;BYSETPOS=2;INTERVAL=1" },
        new DropDownFields() { Value = "FREQ=YEARLY;BYDAY=MO;BYSETPOS=-1;INTERVAL=1;COUNT=5" }
    };
    public void OnRuleChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, DropDownFields> args)
    {
        RecurrenceEditorRef.SetRecurrenceRule(args.Value, DateTime.Today);
    }
    public class DropDownFields
    {
        public string Value { get; set; }
    }
}
<style>
    .recurrence-editor-wrap {
        margin: 0 25%;
    }

    .ddlarea {
        padding-bottom: 15px;
    }

    .spanarea {
        font-size: 14px;
    }

    .ddlcontent {
        padding-top: 4px;
    }
</style>
```


## Recurrence date generation

You can parse the `RecurrenceRule` of an event to generate the date instances on which that particular event is going to occur, using the `GetRecurrenceDates` method. It generates the dates based on the `RecurrenceRule` that we provide. The parameters to be provided for `GetRecurrenceDates` method are as follows.

| Field name | Type | Description |
|------------|------|-------------|
| `startDate` | Date| Appointment start date. |
| `rule` | String| Recurrence rule present in an event object. |
| `excludeDate` | String | Date collection (in ISO format) to be excluded. It is **optional**. |
| `maximumCount` | Number | Number of date count to be generated. It is **optional**. |
| `viewDate` | Date | Current view range's first date. It is **optional**. |

```cshtml
@using Syncfusion.Blazor.Schedule
@using System.Globalization
    < div class="recurrence-editor-wrap" >
    <div style="padding-bottom: 15px;">
        <label id="rule-label">Date Collections</label>
        <div class="rule-output-container">
            <div id="rule-output">
                @foreach (DateTime date in RecurrenceDates)
                {
                    <div>@date.ToString("ddd MMM dd yyyy HH:mm:ss 'GMT'zzz ('India Standard Time')", CultureInfo.InvariantCulture)</div>
                }
            </div>
        </div>
    </div>
    <div style="display:none">
        <SfRecurrenceEditor @ref="RecurrenceEditorRef"></SfRecurrenceEditor>
    </div >
</div >

@code {
    private SfRecurrenceEditor RecurrenceEditorRef;
    public List < DateTime > RecurrenceDates  = new List < DateTime > ();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) {
            await GetRecurrenceDates();
        }
    }

    private async Task GetRecurrenceDates()
    {
        List < DateTime > dates = RecurrenceEditorRef.GetRecurrenceDates(new DateTime(2018, 1, 7, 10, 0, 0), "FREQ=DAILY;INTERVAL=1", "20180108T114224Z,20180110T114224Z", 4);
        RecurrenceDates = dates.ToList();
        StateHasChanged();
    }
}

<style>
    .recurrence-editor-wrap {
        margin: 0 25%;
    }
    .rule-output-container {
        height: auto;
        border: 1px solid #969696;
    }
    #rule-output {
        padding: 8px 4px;
        text-align: center;
        min-height: 20px;
        overflow: hidden;
        overflow-wrap: break-word;
        }
</style>
```


> Above example will generate two dates January 7, 2018 & January 9 2018 by excluding the in between dates January 8 2018 & January 10 2018, since those dates were given in the exclusion list. Generated dates can then be utilised to create appointments.

## Recurrence date generation in server-side

It is also possible to generate recurrence date instances from server-side by manually referring the `RecurrenceHelper` class, which is specifically written and referred from application end to handle this date generation process.

> Refer [here](https://www.syncfusion.com/kb/10009/how-to-parse-the-recurrencerule-at-server-side) for the step by step procedure to achieve date generation in server-side.

## Restrict date generation with specific count

In case, if the rule is given in "NEVER ENDS" category, then you can mention the maximum count when you actually want to stop the date generation starting from the provided start date. To do so, provide the appropriate `maximumCount` value within the `GetRecurrenceDates` method as shown in the following code example.

```cshtml
@using Syncfusion.Blazor.Schedule
@using System.Globalization
    < div class="recurrence-editor-wrap" >
    <div style="padding-bottom: 15px;">
        <label id="rule-label">Date Collections</label>
        <div class="rule-output-container">
            <div id="rule-output">
                @foreach (DateTime date in RecurrenceDates)
                {
                    <div>@date.ToString("ddd MMM dd yyyy HH:mm:ss 'GMT'zzz ('India Standard Time')", CultureInfo.InvariantCulture)</div>
                }
            </div>
        </div>
    </div>
    <div style="display:none">
        <SfRecurrenceEditor @ref="RecurrenceEditorRef"></SfRecurrenceEditor>
    </div >
</div >

@code {
    private SfRecurrenceEditor RecurrenceEditorRef;
    public List < DateTime > RecurrenceDates  = new List < DateTime > ();
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) {
            await GetRecurrenceDates();
        }
    }
    private async Task GetRecurrenceDates()
    {
        List < DateTime > dates = RecurrenceEditorRef.GetRecurrenceDates(new DateTime(2018, 1, 7, 10, 0, 0), "FREQ=DAILY;INTERVAL=1", "20180108T114224Z,20180110T114224Z", 10);
        RecurrenceDates = dates.ToList();
        StateHasChanged();
    }
}

<style>
    .recurrence-editor-wrap {
        margin: 0 25%;
    }

    .rule-output-container {
        height: auto;
        border: 1px solid #969696;
    }

    #rule-output {
        padding: 8px 4px;
        text-align: center;
        min-height: 20px;
        overflow: hidden;
        overflow-wrap: break-word;
    }
</style>
```
