---
layout: post
title: Accessibility in Blazor Carousel | Syncfusion®
description: Learn how Blazor Carousel meets WAI-ARIA standards with aria-label, aria-current, aria-live, and full keyboard navigation for screen readers.
platform: Blazor
control: Carousel
documentation: ug
---

# Accessibility in Blazor Carousel

The [Blazor Carousel](https://www.syncfusion.com/blazor-components/blazor-carousel) component is designed in accordance with the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/carousel/) specification, applying the appropriate roles, states, and properties along with keyboard support. This makes it usable for people who rely on assistive technologies. The accessibility support is achieved through attributes like `aria-label`, `aria-current`, `aria-live`, `role`, and `aria-hidden`, which provide information about the elements in a document to assistive technology. The component implements keyboard navigation support by following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/) and has been tested with major screen readers, including NVDA, JAWS, and VoiceOver.

The Blazor Carousel component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles), which are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Carousel component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | AA |
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

## WAI-ARIA attributes

The Blazor Carousel component is designed in accordance with the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) standard, making it accessible to screen readers and other assistive technology devices. The following list of attributes is added to the Carousel.

| **Attribute** | **Purpose**                                                                                                                            |
| ------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `aria-roledescription`   | Set to `carousel` for the root element and `slide` for each carousel slide item.                                                          |
| `aria-label`             | Applied to the previous, next, and play/pause buttons, and to all indicator elements.                                                     |
| `aria-current`           | Set to `true` for the active item indicator element.                                                                                       |
| `aria-hidden`            | Set to `true` for all carousel elements except the currently visible item.                                                                |
| `aria-live`              | For the carousel items container, set to `off` when `autoPlay` is `true` and to `polite` when `autoPlay` is `false`.                       |
| `role`                   | Set to `region` for the carousel root and `group` for each carousel slide item.                                                            |

## Keyboard interaction

All Carousel actions can be controlled using keyboard keys through the [`AllowKeyboardInteraction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfCarousel.html#Syncfusion_Blazor_Navigations_SfCarousel_AllowKeyboardInteraction) property, which is enabled by default. If you wish to disable the default keyboard interactions, you can set this property to `false`. This is particularly useful if the carousel contains input elements, as pressing the arrow keys might cause the carousel to move unexpectedly. By disabling keyboard interaction, the carousel remains static, allowing the user to focus on the input fields without any interruptions.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfCarousel AllowKeyboardInteraction="false">
    <CarouselItem>
        <div>Slide 1</div>
    </CarouselItem>
    <CarouselItem>
        <div>Slide 2</div>
    </CarouselItem>
</SfCarousel>
```

This control implements keyboard navigation support by following WAI-ARIA practices. When focus is on the active Carousel element, you can use the following key combinations to interact with the Carousel.

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Focuses the carousel component (implemented at the application level). |
| Arrows (<kbd>←</kbd>, <kbd>→</kbd>) | Arrows (<kbd>←</kbd>, <kbd>→</kbd>) | Navigates between slides. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Navigates to the first slide. |
| <kbd>End</kbd> | <kbd>End</kbd> | Navigates to the last slide. |
| <kbd>Space</kbd> | <kbd>Space</kbd> | Plays or pauses the slide transitions. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the action of the focused element (indicator or button). |

## Ensuring accessibility

The Blazor Carousel component's accessibility levels are ensured through the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Carousel component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/carousel) in a new window to evaluate the accessibility of the Carousel component with accessibility tools.

## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
* [Getting started with Blazor Carousel](https://blazor.syncfusion.com/documentation/carousel/getting-started)
* [WAI-ARIA Carousel pattern](https://www.w3.org/WAI/ARIA/apg/patterns/carousel/)

