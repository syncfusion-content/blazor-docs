---
layout: post
title: Localization in Blazor MultiColumn ComboBox Component | Syncfusion®
description: Checkout and learn here all about Localization in Blazor MultiColumn ComboBox component and much more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Globalization and Localization in the Blazor MultiColumn ComboBox Component

## Localization

The [Blazor MultiColumn ComboBox](https://www.syncfusion.com/blazor-components/blazor-multicolumn-combobox) supports localization of built-in UI text (for example, messages such as “No records found” and “Action failure”). Refer to the [Blazor localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Blazor components.

The following example shows how to load localized resources in `Program.cs` and inject them into the MultiColumn ComboBox via the `Locale` property.

**Program.cs**

```csharp
using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new System.Globalization.CultureInfo("fr-FR") };
    options.SetDefaultCulture("fr-FR");
});
```

**Index.razor**

{% highlight cshtml %}

@using Syncfusion.Blazor.MultiColumnComboBox

<SfMultiColumnComboBox TItem="string" TValue="string" Locale="fr-FR" Placeholder="Sélectionner un produit"></SfMultiColumnComboBox>

{% endhighlight %}

## Globalization

Globalization is also supported. Dates, numbers, and other culture-sensitive values are formatted based on the current application culture. For guidance on configuring culture, number/date formats, and calendars, see the [Blazor globalization](https://blazor.syncfusion.com/documentation/common/globalization) documentation. For languages that read right-to-left, enable RTL rendering as described in [right-to-left support](../common/accessibility#right-to-left-support).