---
layout: post
title: Accessibility in Blazor Toast Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Toast component and much more details.
platform: Blazor
control: Toast
documentation: ug
---

# Accessibility in Blazor Toast Component

The [Blazor Toast](https://www.syncfusion.com/blazor-components/blazor-toast) component is built with [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/practices/) in mind. Appropriate ARIA roles, states, and properties are applied to ensure announcements by assistive technologies. The component is tested with major screen readers and supports accessible usage patterns.

The Blazor Toast component follows common accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor Toast component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | Not Applicable |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

It provides information about the elements in a document for assistive technology.

The Blazor Toast component implements the keyboard navigation support by using the following [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/practices/) and is tested in major screen readers.


<!-- markdownlint-disable MD033 -->

| Attribute | Description |
| -------- | -------- |
| role | <b>alert:</b> Identifies the element as an assertive live region so that alert content is announced when added or updated. |

```cshtml

@using Syncfusion.Blazor.Notifications

<SfToast @ref="ToastObj" Title="Matt sent you a friend request" Content="@ToastContent" Timeout="0">
    <ToastEvents Created="@OnCreate"></ToastEvents>
</SfToast>

@code {
    SfToast ToastObj;

    private string ToastContent { get; set; } = "You have a new friend request yet to accept";

    private async Task OnCreate()
    {
       await this.ToastObj.ShowAsync();
    }
}

```

![Accessibility in Blazor Toast](./images/blazor-toast-accessibility.png)

## Ensuring accessibility

The Blazor Toast component’s accessibility is validated with the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the Toast component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/toast) in a new window to evaluate the accessibility of the Toast component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)