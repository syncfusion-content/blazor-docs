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

Several pager elements can be localized, including text and tooltip content associated with navigation controls such as  **First Page**, **Previous Page**, **Next Page**,**Last Page**, **Current Page** or **Items per page**. Replacing default English text with translated equivalents improves readability and reduces ambiguity within multilingual applications.

Localization is particularly beneficial for enterprise applications deployed across multiple geographical regions. Consistent language presentation throughout the interface helps improve accessibility and promotes a familiar user experience for audiences with different native languages. Since pagination controls are frequently used for navigating large datasets, localized content enables quicker interpretation of navigation options and page-related information.

The Syncfusion localization framework integrates with ASP.NET Core localization infrastructure, allowing culture-specific resources to be loaded based on the active culture setting of the application. Once localization is configured, the Pager component automatically displays translated content that corresponds to the selected language. This approach simplifies application maintenance while ensuring consistency across all localized components.

In addition to language translation, localization supports regional formatting conventions and cultural expectations, helping maintain a professional and polished interface within globally distributed applications. As a result, applications can provide a seamless experience regardless of language preference or geographical location.

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

RTL rendering can be enabled globally for all Syncfusion Blazor components by configuring the Syncfusion service in `Program.cs`.

{% tabs %}
{% highlight C# tabtitle="~/_Program.cs" %}

builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });

{% endhighlight %}
{% endtabs %}

This configuration activates RTL rendering across supported Syncfusion components, ensuring a consistent interface throughout the application.

## Pager component

```cshtml
@using Syncfusion.Blazor.Navigations

<SfPager TotalItemsCount="20" NumericItemsCount="5" PageSize="5"></SfPager>
```
In this configuration, the Pager component automatically adopts RTL rendering when the global `EnableRtl` option is enabled. Navigation controls, numeric page items, tooltips, and related pager elements are displayed using right-to-left alignment without requiring component-level settings.

By combining localization and RTL capabilities, the Pager component delivers a flexible globalization solution suitable for multilingual and multicultural applications. Localized text improves clarity and accessibility, while RTL rendering ensures that navigation patterns align with cultural reading expectations. Together, these features help create a consistent, intuitive, and regionally appropriate paging experience across a wide range of languages and deployment scenarios.

> For more details, refer to the [Right-to-Left](https://blazor.syncfusion.com/documentation/common/right-to-left) guide for detailed configuration steps.
