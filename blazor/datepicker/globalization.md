---
layout: post
title: Globalization in Blazor DatePicker Component | Syncfusion
description: Learn about globalization in the Syncfusion Blazor DatePicker, including localization, culture-specific formatting, and right-to-left (RTL) layout support.
platform: Blazor
control: DatePicker
documentation: ug
---

# Globalization in Blazor DatePicker Component

The [Blazor DatePicker](https://www.syncfusion.com/blazor-components/blazor-datepicker) component supports localization and culture-specific formatting. See the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic for details on configuring localization for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components. When a Locale is set, the component reflects the culture’s date formats, month and day names, and other culture-specific settings. To apply localization, ensure that the required culture data is loaded using the localization utilities before rendering the component.

## Right-To-Left

The DatePicker supports right-to-left (RTL) layout for languages such as Arabic and Hebrew. Use the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_EnableRtl) property to render the component in RTL direction. RTL layout is independent of the Locale setting; both can be used together to achieve the desired language and layout.

The following code example initializes the DatePicker component with the `ar` (Arabic) culture and RTL layout.

```cshtml
@using Syncfusion.Blazor.Calendars
@inject HttpClient Http;

<SfDatePicker TValue="DateTime?" EnableRtl=true Locale="ar"></SfDatePicker>

@code {
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }
    protected override async Task OnInitializedAsync()
    {
        this.JsRuntime.Sf().LoadLocaleData(await Http.GetJsonAsync<object>("blazor-locale/src/ar.json")).SetCulture("ar");
    }
}
```

N> Ensure that the required locale JSON files (such as `ar.json`) are available to load culture data. In newer .NET versions, `GetFromJsonAsync` is typically used instead of `GetJsonAsync`, but the logic remains the same: load the culture data and then set the culture.

![Blazor DatePicker in Arabic culture with right-to-left layout](./images/blazor-datepicker-right-to-left.png)