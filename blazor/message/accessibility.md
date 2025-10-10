---
layout: post
title: Accessibility in Blazor Message Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Message component and much more.
platform: Blazor
control: Message
documentation: ug
---

# Accessibility in Blazor Message

The Blazor Message component follows established accessibility guidelines and standards, including ADA, Section 508, and WCAG 2.2. It supports screen readers, keyboard navigation, right-to-left (RTL) layouts, and high-contrast themes. For component details, see the Message documentation and API reference in the Syncfusion Blazor docs.

The accessibility compliance for the Blazor Message component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">|
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the control meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the control do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The control does not meet the requirement.</div>

## ARIA attributes

The Blazor Message component follows the WAI-ARIA Authoring Practices for alerts to ensure compatibility with assistive technologies. The following ARIA roles and attributes are used:

| Attributes | Purpose |
| --- | --- |
| `role=alert` | Announces important, time-sensitive messages to screen reader users. Use for urgent content that should interrupt politely. |
| `role=status` | Announces non-urgent status updates without interrupting the user’s task flow. |
| `aria-live` (`polite`/`assertive`) | Controls how updates are announced by screen readers. `assertive` announces sooner; `polite` waits for a pause. |
| `aria-atomic` | When set, ensures the entire message region is announced as a whole when updated. |
| `aria-label` | Provides an accessible name for the close icon when it is present. |
| `aria-labelledby` | Associates the message with a header or title element for an accessible name. |

## Keyboard interaction

The Blazor Message component follows the keyboard interaction guideline, making it accessible to users who rely on keyboards or assistive technologies. The following keyboard shortcuts are supported:

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Tab</kbd> / <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>Tab</kbd> / <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus to the message’s actionable elements, such as the close icon. |
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Activates the focused close icon to dismiss the message. |

## Ensuring accessibility

The Blazor Message component's accessibility levels are validated with [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) and Playwright tests to detect issues such as missing accessible names, incorrect ARIA states, and insufficient color contrast. Actual results may vary based on application markup, theme, and customization.

The accessibility compliance of the Blazor Message component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/message) in a new window to evaluate the accessibility of the Blazor Message component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)