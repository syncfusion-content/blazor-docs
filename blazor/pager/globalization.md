---
layout: post
title: Globalization in Blazor Pager Component | Syncfusion
description: Learn how to configure localization and right-to-left (RTL) rendering in the Syncfusion Blazor Pager component.
platform: Blazor
control: Pager
documentation: ug
---

# Globalization in Blazor Pager Component

This article explains how to **localize** the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component and how to enable **right-to-left (RTL)** rendering.

## Localization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component supports localization, allowing text and UI elements to adapt to various languages and cultural formats.

> Refer to the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) guide for detailed configuration steps.

## Right to left (RTL)

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component supports right-to-left (RTL) rendering for languages such as **Arabic**, **Farsi**, and **Urdu**. **RTL** can be enabled by configuring the **Syncfusion Blazor service** during application startup.

**Register the `EnableRtl` option in Program.cs**:

{% tabs %}
{% highlight C# tabtitle="~/_Program.cs" %}

builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });

{% endhighlight %}
{% endtabs %}

```cshtml
@using Syncfusion.Blazor.Navigations

<SfPager TotalItemsCount="20" NumericItemsCount="5" PageSize="5"></SfPager>
```

> For more details, refer to the [Right-to-Left](https://blazor.syncfusion.com/documentation/common/right-to-left) guide for detailed configuration steps.