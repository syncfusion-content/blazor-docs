---
layout: post
title: Globalization in Blazor Datetime Picker Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor Datetime Picker component and more.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Globalization in Blazor Datetime Picker Component

[Blazor DateTimePicker](https://www.syncfusion.com/blazor-components/blazor-datetime-picker) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion Blazor components.

## Customize the localized text

* You can change the localized text of particular component by editing the `wwwroot/blazor-locale/src/{{locale name}}.json` file.

* In the following code, modified the localized text of `today button` and `placeholder` in `de` culture.

    [`wwwroot/blazor-locale/src/de.json`]

    ```csharp
    {
    "de": {
        "datetimepicker": {
        "today": "Heutiges Datum",
        "placeholder": "Wählen Sie ein Datum und eine Uhrzeit aus"
        }
    }
    }
    ```


    ![Customizing Localized Text in Blazor DateTimePicker](./images/blazor-datetimepicker-localize-text.png)

## Right-To-Left

The DateTimePicker supports RTL (right-to-left) functionality for languages like Arabic and Hebrew to display the text in the right-to-left direction. Use [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_EnableRtl) property to set the RTL direction.

The following code example initialize the DateTimePicker component in `Arabic` culture.

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

![Right to Left in Blazor DateTimePicker with Arabic Culture](./images/blazor-datetimepicker-right-to-left.png)
