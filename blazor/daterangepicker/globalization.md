---
layout: post
title: Globalization in Blazor DateRangePicker Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor DateRangePicker component and more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Globalization in Blazor DateRangePicker Component

[Blazor DateRangePicker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

## Right-To-Left

The DateRangePicker supports RTL (right-to-left) functionality for languages like Hebrew and Hebrew to display the text in the right-to-left direction. Use [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_EnableRtl) property to set the RTL direction.

The following code example initialize the DateRangePicker component in `Hebrew` culture.

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
```



![Right to Left in Blazor DateRangePicker with Hebrew Culture](./images/blazor-daterangepicker-right-to-left.png)

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap5) to understand how to present and manipulate data.
