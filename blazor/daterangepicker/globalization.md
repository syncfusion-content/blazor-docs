---
layout: post
title: Globalization in Blazor DateRangePicker Component | Syncfusion®
description: Checkout and learn here all about Globalization in Blazor DateRangePicker component and much more details.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Globalization in Blazor DateRangePicker Component

[Blazor DateRangePicker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Blazor components.

## Right-To-Left

The DateRangePicker supports RTL (right-to-left) functionality for languages like Arabic and Hebrew. Use the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_EnableRtl) property to set the RTL direction. The `Locale` property switches the calendar to a specific culture, for example `Locale="ar"` for Arabic.

The following code example initializes the DateRangePicker component in the Arabic culture. The locale data is loaded from the Syncfusion Blazor locale script (available via the [Syncfusion CDN](https://cdn.syncfusion.com/blazor/locale/)) using `HttpClient`.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars
@using System.Net.Http.Json
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

![Right to Left in Blazor DateRangePicker with Arabic Culture](./images/blazor-daterangepicker-right-to-left.webp)

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=fluent2) to understand how to present and manipulate data.
