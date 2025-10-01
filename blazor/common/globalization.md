---
layout: post
title: Globalization in Blazor - Syncfusion
description: Learn how Syncfusion Blazor components handle globalization for numbers, dates, times, and currencies across cultures in Blazor Web App, WASM, and Server App.
platform: Blazor
control: Common
documentation: ug
---

# Globalization in Blazor Application

Globalization combines internationalization (i18n)—parsing and formatting dates, times, numbers, and currencies—and localization (l10n)—adding culture-specific customizations and translating UI text.

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor UI components use American English (`en-US`) by default. Blazor relies on .NET globalization to parse and format numbers and dates based on the active culture. In Blazor WebAssembly, ensure globalization data is available when using non‑en cultures.

Blazor uses built-in .NET types from the System.Globalization namespace, such as the CultureInfo class and its culture properties.

* Culture ([CultureInfo.CurrentCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture?view=net-8.0#system-globalization-cultureinfo-currentculture)): Determines the formatting of numbers, dates, and times.
* UI culture ([CultureInfo.CurrentUICulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentuiculture?view=net-8.0#system-globalization-cultureinfo-currentuiculture)): Determines the language of the user interface and which .resx resources are used.

When working with HTML form fields, browser-native input types affect culture behavior:

* `date`
* `number` 

Blazor relies on the browser’s handling of these input types, which ensures that the user input is parsed and rendered according to their specific culture settings.

Some input types are inconsistently supported across browsers and may be less reliable:

* `datetime-local`
* `month`
* `week`

The following example shows how globalization affects rendered values by formatting dates and numbers according to the current culture.

{% tabs %}
{% highlight razor %}

@page "/"
@using System.Globalization

<ul>
    <li><b>CurrentCulture</b>: @CultureInfo.CurrentCulture</li>
    <li><b>CurrentUICulture</b>: @CultureInfo.CurrentUICulture</li>
</ul>

<h2>Rendered values</h2>

<ul>
    <li><b>Date</b>: @dt.ToLongDateString()</li>
    <li><b>Number</b>: @number.ToString("N2")</li>
</ul>

@code {
    private DateTime dt = DateTime.Now;
    private double number = 1999.69;
}

{% endhighlight %}
{% endtabs %}

* To change any specific culture, add the corresponding `.resx` resource files and configure localization as described in the following article:

[Enable localization and add .resx files in the application](https://blazor.syncfusion.com/documentation/common/localization#how-to-enable-localization-in-blazor-application)

## See also
* [ASP.NET Core Blazor globalization and localization](https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?view=aspnetcore-8.0)
* [.NET fundamentals: Globalization](https://learn.microsoft.com/en-us/dotnet/core/extensions/globalization)
* [.NET fundamentals: Localization](https://learn.microsoft.com/en-us/dotnet/core/extensions/localization)
