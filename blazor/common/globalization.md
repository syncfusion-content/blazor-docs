---
layout: post
title: Globalization in Blazor - Syncfusion
description: Learn here all about how globalization support in Syncfusion Blazor component, it's elements and more.
platform: Blazor
component: Common
documentation: ug
---

# Globalization in Blazor Application

Globalization is the combination of adapting the control to various languages by parsing and formatting the dates, times, numbers or currencies (`Internationalization (L18N)`) and adding cultural-specific customizations and translating the text (`Localization (L10N)`).

The Syncfusion Blazor UI components are specific to the `American English (en-US)` culture by default. It utilizes the `Blazor Internationalization` package to parse and format the number and date objects based on the chosen culture.

Blazor uses the built-in .NET types from the `System.Globalization` namespace, such as the `CultureInfo` class and its `CurrentCulture` property.

* Culture ([CultureInfo.CurrentCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture?view=net-8.0#system-globalization-cultureinfo-currentculture)): Determines the formatting of numbers, dates, and times. It's mainly concerned with how data is presented and interpreted.
* UI Culture ([CultureInfo.CurrentUICulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentuiculture?view=net-8.0#system-globalization-cultureinfo-currentuiculture)): Determines the language of the user interface, including which resource files (like .resx files) are used for localizing the app’s UI.

When dealing with form fields in Blazor, it’s important to note that certain input types automatically respect the user's culture settings using [CultureInfo.InvariantCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture?view=net-8.0#system-globalization-cultureinfo-invariantculture).

For example, the following input types are culture-sensitive:

* `date`
* `number`

Blazor relies on the browser’s handling of these input types, which ensures that the user input is parsed and rendered according to their specific culture settings.

However, some form field types are not yet fully supported across all browsers, making them less reliable in Blazor applications. These include:

* `datetime-local`
* `month`
* `week`


The following code snippet serves as an example to demonstrate how globalization can be implemented in a Blazor application. It illustrates the process of localizing content, formatting dates and numbers.

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

* Suppose, if you want to change any specific culture, then add the corresponding culture resource (`.resx`) file by using the below reference. 

[Changing culture and Adding Resx file in the application](https://blazor.syncfusion.com/documentation/common/localization#how-to-enable-localization-in-blazor-application)

## See also
* [ASP.NET Core Blazor globalization and localization](https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?view=aspnetcore-8.0)
* [.NET Fundamentals: Globalization](https://learn.microsoft.com/en-us/dotnet/core/extensions/globalization)
* [.NET Fundamentals: Localization](https://learn.microsoft.com/en-us/dotnet/core/extensions/localization)
