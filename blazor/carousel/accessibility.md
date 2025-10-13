---
layout: post
title: Accessibility in Blazor Carousel Component | Syncfusion
description: Checkout and learn about accessibility with Blazor Carousel component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Carousel
documentation: ug
---

# Accessibility in Blazor Carousel Component

The [Blazor Carousel](https://www.syncfusion.com/blazor-components/blazor-carousel) component has been designed, keeping in mind the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/carousel/) specifications, and applying the WAI-ARIA roles, states and properties along with keyboard support. Thus, making it usable for people who use assistive WAI-ARIA accessibility supports that is achieved through attributes like `aria-label`, `aria-current`, `aria-live`, `aria-role` and `aria-hidden`. It helps to provides information about the elements in a document for assistive technology. The component implements the keyboard navigation support by following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/) and tested in major screen readers.

The Blazor Carousel component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Carousel component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA Attributes

The Blazor Carousel component is designed with [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) standards to ensure accessibility. It supports ARIA attributes to optimize interaction with screen readers and other assistive technology devices. The following attributes are used within the Carousel:

| **Attributes** | **Purpose**                                                                                                                             |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------|
| aria-roledescription   | Provides an accessible description for the root element (carousel) and each carousel slide item (slide).                            |
| aria-label             | Labels interactive elements like previous, next, and play/pause buttons, as well as all indicator elements.                                                                               |
| aria-current           | Set to `true` for the active item indicator element, signifying the currently displayed item.                                                                        |
| aria-hidden            | For all carousel elements except the currently visible item, `aria-hidden` is set to `true`.                                                    |
| aria-live              | For carousel items element, when `autoPlay` is `true`, `aria-live` is set to `off`; when `autoPlay` is `false`, `aria-live` is set to `polite`. |
| aria-role              | Applied to carousel slide items to semantically group related content.                                                                                           |

## Keyboard Interaction

All Carousel actions can be controlled using keyboard keys through the [`AllowKeyboardInteraction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_AllowKeyboardInteraction) property, which is enabled by default. To disable default keyboard interactions (useful if the carousel contains input elements where arrow keys might interfere), set this property to `false`. By disabling keyboard interaction, the carousel remains static, allowing the user to focus on the input fields without any interruptions.

The component implements keyboard navigation support by following WAI-ARIA practices. Once a Carousel element is focused, users can use the following key combinations:

| Windows | Mac | Description |
 ------------------ |----------------|--------------- |
| <kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Focuses the Carousel component (application-level implementation).  |
| <kbd>Left/Right Arrows</kbd> | <kbd>←</kbd> / <kbd>→</kbd> | Navigates between slides. 
| <kbd>Home</kbd> | <kbd>Home</kbd> | Navigates to the first slide. |
| <kbd>End</kbd> | <kbd>End</kbd> | Navigates to the last slide. |
| <kbd>Space</kbd> | <kbd>Space</kbd> | Toggles play/pause for slide transitions. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the respective action on the focused element. |

## Ensuring Accessibility

The accessibility levels of the Blazor Carousel component are ensured through automated testing using the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Carousel component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/carousel) in a new window to evaluate the accessibility of the Carousel component with accessibility tools.

## See Also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)