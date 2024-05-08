---
layout: post
title: Accessibility with Blazor Carousel Component | Syncfusion
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
| Color Contrast |  |
| Mobile Device Support |  |
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

## WAI-ARIA attributes

The Blazor carousel component is designed by considering [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) standard. Carousel is supported with ARIA Accessibility which is accessible by on-screen readers and other assistive technology devices. The following list of attributes is added to the Carousel.

| **Attributes** | **Purpose**                                                                                                                             |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------|
| `aria-roledescription`   | The role description attribute should be added for the root element (carousel) and each carousel slide item (slide).                            |
| `aria-label`             | Previous, next and play/pause buttons and all indicator elements.                                                                               |
| `aria-current`           | For the active item indicator element, `aria-current` is set to `true`.                                                                         |
| `aria-hidden`            | For all carousel elements except the currently visible item, `aria-hidden` is set to `true`.                                                    |
| `aria-live`              | For carousel items element, when `autoPlay` is `true`, `aria-live` is set to `off`; when `autoPlay` is `false`, `aria-live` is set to `polite`. |
| `aria-role`              | For carousel slide item, `aria-role` should be group.                                                                                           |

## Keyboard interaction

By default, keyboard navigation is enabled. This component implements keyboard navigation support by following the WAI-ARIA practices. Once focused on the active Carousel element, you can use the following key combination for interacting with the Carousel.

| Key                | Description                                                     |
| ------------------ | --------------------------------------------------------------- |
| <kbd>Alt + J</kbd> | Keys to focus the carousel component (done at application end). |
| <kbd>Arrows</kbd>  | Keys to navigate between slides.                                |
| <kbd>Home</kbd>    | To navigate to the first slide.                                 |
| <kbd>End</kbd>     | To navigate to the last slide.                                  |
| <kbd>Space</kbd>   | To play/pause the slide transitions.                            |
| <kbd>Enter</kbd>   | To perform the respective action on its focus.                  |

## Ensuring accessibility

The Blazor Carousel component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Carousel component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/carousel) in a new window to evaluate the accessibility of the Carousel component with accessibility tools.

## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)