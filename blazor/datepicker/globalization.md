---
layout: post
title: Globalization in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Globalization in Blazor DatePicker Component

[Blazor DatePicker](https://www.syncfusion.com/blazor-components/blazor-datepicker) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion Blazor components.

## Customize the localized text

* You can change the localized text of particular component by editing the `wwwroot/blazor-locale/src/{{locale name}}.json` file.

* In the following code, modified the localized text of `today button` and `placeholder` in `de` culture.

[`wwwroot/blazor-locale/src/de.json`]

```csharp
{
  "de": {
    "datepicker": {
      "today": "Heutiges Datum",
      "placeholder": "Wählen Sie ein Datum"
    }
  }
}
```



![Customizing Localized Text in Blazor DatePicker](./images/blazor-datepicker-localize-text.png)

## Right-To-Left

The DatePicker supports RTL (right-to-left) functionality for languages like Arabic and Hebrew to display the text in the right-to-left direction. Use the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_EnableRtl) property to set the RTL direction.

The following code example initializes the DatePicker component in `Arabic` culture.

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



![Right to Left in Blazor DatePicker with Arabic Culture](./images/blazor-datepicker-right-to-left.png)