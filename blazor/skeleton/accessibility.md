---
layout: post
title: Accessibility in Blazor Skeleton Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Skeleton component and much more.
platform: Blazor
control: Skeleton
documentation: ug
---

# Accessibility in Blazor Skeleton component

The Blazor Skeleton component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Skeleton component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | N/A |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

N> The Skeleton is a non-interactive, visual placeholder indicating loading content. Because it does not receive focus or support interaction, keyboard navigation is not applicable.

## WAI-ARIA attributes

The Blazor Skeleton component follows [WAI-ARIA](https://www.w3.org/TR/wai-aria/#live_region_roles) guidance for communicating loading status to assistive technologies. Use the following attributes based on your scenario:

| Properties | Functionality |
| ------------ | ----------------------- |
| `aria-busy="true"` | Applied to the container of the content being loaded to indicate a busy state; set to `false` when loading completes. |
| `aria-live="polite"` | Announces updates non-disruptively when the loading state changes (use on a status region if announcing is needed). |
| `role="status"` | Optional role for a live region that provides advisory information such as “Loading…”. |
| `aria-label` | Provides an accessible name if the Skeleton needs to be announced (for example, “Loading profile picture”). |
| `aria-hidden="true"` | Use for decorative Skeletons to hide them from assistive technologies when no announcement is necessary. |

N> Avoid using `role="alert"` for Skeletons. Prefer `role="status"` with `aria-live="polite"` when announcements are required to minimize unnecessary interruptions.

## Ensuring accessibility

The Blazor Skeleton component’s accessibility levels are validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Skeleton component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/skeleton) in a new window to evaluate the accessibility of the Blazor Skeleton component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)