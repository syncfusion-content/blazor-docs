---
layout: post
title: Accessibility in Blazor OTP Input Component | Syncfusion
description: Checkout and learn here all about Accessibility with Syncfusion Blazor OTP Input component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: OTP Input
documentation: ug
---

# Accessibility in Blazor OTP Input component

The Blazor OTP Input component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor OTP Input component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/intermediate.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The following ARIA attributes are used in the OTP Input component:

| Attributes | Purpose |
| ------------ | ----------------------- |
| `role=group` | Attributes used to form a collection of items.|
| `aria-label` | Attributes provides the text label for the OTP Inputs. |

## Keyboard interaction

The following keyboard shortcuts are supported by the OTP Input component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>←</kbd> | <kbd>←</kbd> | Focuses the previous input in the OTP. |
| <kbd>→</kbd> | <kbd>→</kbd> | Focuses the next input in OTP |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves the initial focus and shifts focus to the next input of the OTP. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves the focus to the previous input of the OTP. |

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)

## HtmlAttributes

HtmlAttributes allow you to specify additional HTML attributes to be applied to the OTP input component.

You can pass HTML attributes as key-value pairs to the [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_HtmlAttributes) property.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput HtmlAttributes=@attrs ></SfOtpInput>

@code {
    Dictionary<string, object> attrs = new Dictionary<string, object>()
    {
        {"title", "One-Time Password" }
    };
}

```

## AriaLabels

AriaLabels define the ARIA-label attribute for each input field in the OTP input component. ARIA-labels enhance accessibility by providing descriptive labels for screen reader users, improving the user experience for individuals with disabilities.
You can provide an array of strings as ARIA-labels to the [AriaLabels](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_AriaLabels) property. Each string corresponds to the ARIA-label attribute for the respective input field in the OTP input component.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput AriaLabels=@label></SfOtpInput>

@code {
    private string[] label = ["First digit", "Second digit", "Third digit", "Fourth digit"];
}

```