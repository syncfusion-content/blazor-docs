---
layout: post
title: Globalization in Blazor DateTimePicker Component | Syncfusion®
description: Checkout and learn here all about Globalization in Blazor Datetime Picker component and much more details.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Globalization in Blazor Datetime Picker Component

 The [Blazor DateTimePicker](https://www.syncfusion.com/blazor-components/blazor-datetime-picker) component supports localization and culture-specific formatting. For configuration details, see the [Blazor Localization](../common/localization) topic. When a `Locale` is set, the component reflects the culture's date and time formats, month and day names, and other culture-specific settings. Ensure that the required culture data is loaded before rendering the component (typically inside `OnInitializedAsync`).

## Right-To-Left

The DateTimePicker supports right-to-left (RTL) layout for languages such as Arabic and Hebrew. Set `EnableRtl="true"` to render the component right-to-left. The default value is `false`. RTL layout is independent of the `Locale` setting; both can be combined to achieve the desired language and layout.

The following example initializes the DateTimePicker with the `ar` (Arabic) culture and RTL layout. The locale JSON file is hosted under `wwwroot/blazor-locale/`.

```cshtml
@using Syncfusion.Blazor.Calendars
@inject HttpClient Http;

<SfDateTimePicker TValue="DateTime?" Locale="ar" EnableRtl=true></SfDateTimePicker>

@code {
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }
    protected override async Task OnInitializedAsync()
    {
        this.JsRuntime.Sf().LoadLocaleData(await Http.GetJsonAsync<object>("blazor-locale/src/ar.json")).SetCulture("ar");
    }
}
```

![Blazor DateTimePicker in Arabic culture with right-to-left layout](./images/blazor-datetimepicker-right-to-left.webp)