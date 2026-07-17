---
layout: post
title: Globalization in Blazor Pager Component | Syncfusion®
description: checkout and learn about how to configure localization and right-to-left (RTL) rendering in Blazor Pager component and much more details.
platform: Blazor
control: Pager
documentation: ug
---

# Globalization in Blazor Pager Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component provides globalization support that enables applications to serve users from different languages and regions effectively. Globalization ensures that the component adapts to the linguistic and cultural preferences of users, helping create a more intuitive and accessible experience. By supporting features such as **localization** and **right-to-left (RTL)** rendering, the Pager component can be integrated into applications that target a global audience while maintaining a consistent user experience.

The Pager component includes the following globalization capabilities:

- **Localization** – Displays pager text, messages, and tooltips in the user's preferred language.
- **Right-to-Left (RTL) rendering** – Adjusts the pager layout and navigation flow for languages that are read from right to left.

These features help organizations develop multilingual applications and ensure that users can interact with paging controls in a way that matches their language and reading preferences.

## Localization

Localization is the process of adapting user interface elements to a specific language or regional setting. The Syncfusion Blazor Pager component supports localization, allowing you to customize the text displayed within the pager according to the active culture of the application.

For example, default text like **First Page**, **Previous Page**, **Next Page**,**Last Page**, **Current Page** or **Items per page** can be replaced with localized equivalents based on the user’s language. This ensures that users can interact with the application more intuitively, without needing to interpret unfamiliar terminology. Localization is especially important in enterprise applications that serve users across multiple regions, as it enhances accessibility and improves user satisfaction.

The Syncfusion Blazor localization framework integrates with ASP.NET Core localization, making it possible to provide culture-specific translations and dynamically switch languages based on user preferences or application settings. Once localization is configured for the application, the Pager component automatically displays the corresponding translated text.

Using localization also helps maintain consistency across an application because all user-facing content follows the same language and cultural conventions. This reduces the likelihood of confusion and contributes to a more professional and user-friendly experience.

> Refer to the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) guide for detailed configuration steps.

## Right to left (RTL)

The Pager component includes support for **Right-to-Left (RTL)** layout rendering. This feature is particularly important for languages such as **Arabic**, **Hebrew**, **Persian** (Farsi), and **Urdu**, where content is read and interpreted from right to left.

When RTL mode is enabled, the component automatically adjusts its layout to align with the reading direction of these languages. This ensures that the interface remains intuitive and culturally appropriate for end users.

Key behavioral changes in RTL mode include:

- The layout and alignment of pager elements are automatically adjusted.
- Navigation controls are mirrored to match the reading direction.
- The overall interaction flow is adapted to provide a natural and consistent user experience.

To enable RTL, configure the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) option in the Syncfusion Blazor service during application startup. This ensures that the component integrates seamlessly into applications designed for RTL languages without requiring additional customization.

## Enable RTL globally

You can enable RTL rendering globally for all Syncfusion Blazor components by configuring the Syncfusion service in Program.cs.

{% tabs %}
{% highlight C# tabtitle="~/_Program.cs" %}

builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });

{% endhighlight %}
{% endtabs %}

Once RTL support is enabled, the Pager component automatically renders its content using right-to-left alignment.
## Pager component

```cshtml
@using Syncfusion.Blazor.Navigations

<SfPager TotalItemsCount="20" NumericItemsCount="5" PageSize="5"></SfPager>
```
In the preceding example, the pager is rendered with RTL support when the global EnableRtl option is enabled. Navigation controls, page numbers, and related pager elements automatically follow the RTL layout without requiring additional component-level configuration.

RTL support helps ensure that users who read content from right to left can navigate paged data naturally and efficiently. This improves accessibility and provides a consistent experience across different languages and regions.

> For more details, refer to the [Right-to-Left](https://blazor.syncfusion.com/documentation/common/right-to-left) guide for detailed configuration steps.

