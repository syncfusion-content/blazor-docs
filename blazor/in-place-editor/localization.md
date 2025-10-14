---
layout: post
title: Globalization in Blazor In-place Editor Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor In-place Editor component and more.
platform: Blazor
control: In-place Editor 
documentation: ug
---

# Globalization in Blazor In-place Editor Component

This topic explains how to globalize the In-place Editor, including localizing UI text, enabling right-to-left (RTL) layout, and applying culture-aware formatting.

## Localization

[Blazor In-place Editor](https://www.syncfusion.com/blazor-components/blazor-in-place-editor) supports localization. To localize component text (such as tooltips and buttons), follow the guidance in [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization).

## Right to left

Specify the direction of the In-place Editor using the `EnableRtl` property. Use RTL layout for right-to-left languages such as Arabic, Hebrew, and Farsi. The layout direction can be switched to right-to-left independently of the current locale.

> It will not change based on the locale property.

```cshtml

@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.Inputs

<table>
    <tr>
        <td class="control-title content-title"> Enter your name: </td>
        <td>
            <SfInPlaceEditor @bind-Value="@TextValue" EnableRtl="true" TValue="string">
                <EditorComponent>
                    <SfTextBox @bind-Value="@TextValue" Placeholder="Enter some text"></SfTextBox>
                </EditorComponent>
            </SfInPlaceEditor>
        </td>
    </tr>
</table>

@code {
    public string TextValue = "Andrew";
}

```

![Right to Left in Blazor In-place Editor](./images/blazor-inplace-editor-right-to-left.png)

## Format

Formatting is a way of representing the value in different formats. Format the following mentioned components with its `format` property when it is directly configured in the Editor component.

* [DatePicker](../datepicker/date-format)
* [DateRangePicker](../daterangepicker/globalization)
* [DateTimePicker](../datetime-picker/globalization)
* [NumericTextBox](../numeric-textbox/formats/#custom-formats/)
* [Slider](../range-slider/format)
* [TimePicker](../timepicker/globalization)

```cshtml

@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.Calendars

<table>
    <tr>
        <td class="control-title"> DatePicker </td>
        <td>
            <SfInPlaceEditor Type="Syncfusion.Blazor.InPlaceEditor.InputType.Date" TValue="DateTime?" @bind-Value="@DateValue">
                <EditorComponent>
                    <SfDatePicker TValue="DateTime?" @bind-Value="@DateValue" Format="yyyy-MM-dd"  Placeholder="Choose a Date"></SfDatePicker>
                </EditorComponent>
            </SfInPlaceEditor>
        </td>
    </tr>
</table>

@code {
    public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
}

```

![Formatting in Blazor In-place Editor](./images/blazor-inplace-editor-formatting.png)