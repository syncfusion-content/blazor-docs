---
layout: post
title: Globalization in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Globalization in Blazor TimePicker Component

## Localization
The [Blazor TimePicker](https://www.syncfusion.com/blazor-components/blazor-timepicker) component supports localization for culture-specific text and formatting. Refer to the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

## Right-To-Left

The TimePicker supports right-to-left (RTL) rendering for languages such as Arabic and Hebrew. Use the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_EnableRtl) property to render content in the right-to-left direction.

The following code example initializes the TimePicker component in `Arabic` culture.

```cshtml
@using Syncfusion.Blazor.Calendars
@inject HttpClient Http;

<SfTimePicker TValue="DateTime?" Locale="ar" EnableRtl=true></SfTimePicker>

@code {
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }
    protected override async Task OnInitializedAsync()
    {
        this.JsRuntime.Sf().LoadLocaleData(await Http.GetJsonAsync<object>("blazor-locale/src/ar.json")).SetCulture("ar");
    }
}
```

![Right to Left in Blazor TimePicker](./images/blazor-timepicker-right-to-left.png)