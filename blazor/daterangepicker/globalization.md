---
layout: post
title: Globalization in Blazor DateRangePicker Component | Syncfusion
description: Learn about globalization in the Syncfusion Blazor DateRangePicker, including localization, culture-specific formatting, and right-to-left (RTL) layout support.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Globalization in Blazor DateRangePicker Component

The [Blazor DateRangePicker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) component supports localization and culture-specific formatting. For setup details, see the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components. When a Locale is set, the component reflects the culture’s date formats, month and day names, and other culture-specific settings. Ensure that the required culture data is loaded using the provided localization utilities before rendering the component.

## Right-To-Left

The DateRangePicker supports right-to-left (RTL) layout for languages such as Arabic and Hebrew. Use the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_EnableRtl) property to render the component in RTL direction. RTL layout is independent of the Locale setting; both can be used together to achieve the desired language and layout.

The following code example initializes the DateRangePicker component with the `ar` (Arabic) culture and RTL layout.

```cshtml
@using Syncfusion.Blazor.Calendars
@inject HttpClient Http;

<SfDateRangePicker TValue="DateTime?" Locale="ar" EnableRtl=true></SfDateRangePicker>

@code {
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }
    protected override async Task OnInitializedAsync()
    {  
        this.JsRuntime.Sf().LoadLocaleData(await Http.GetJsonAsync<object>("blazor-locale/src/ar.json")).SetCulture("ar");
    }
}
```

![Blazor DateRangePicker in Arabic culture with right-to-left layout](./images/blazor-daterangepicker-right-to-left.png)

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap5) to understand how to present and manipulate data.