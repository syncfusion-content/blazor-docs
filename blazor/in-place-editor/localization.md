---
layout: post
title: Globalization in Blazor In-place Editor Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor In-place Editor component and more.
platform: Blazor
control: In Place Editor 
documentation: ug
---

# Globalization in Blazor In-place Editor Component

## Localization

[Blazor In-place Editor](https://www.syncfusion.com/blazor-components/blazor-in-place-editor) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

## Right to left

Specifies the direction of the In-place Editor component using the `EnableRtl` property. For writing systems that requires Arabic, Hebrew, and more. The direction can be switched to right-to-left.

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

Formatting is a way of representing the value in different formats. You can format the following mentioned components with its `format` property when it is directly configured in the Editor component.

* [DatePicker](../datepicker/date-format/)
* [DateRangePicker](../daterangepicker/globalization/)
* [DateTimePicker](../datetime-picker/globalization/)
* [NumericTextBox](../numeric-textbox/formats/#custom-formats)
* [Slider](../range-slider/format/)
* [TimePicker](../timepicker/globalization/)

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