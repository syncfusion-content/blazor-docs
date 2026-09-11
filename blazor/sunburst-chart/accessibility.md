---
layout: post
title: Blazor Sunburst Chart Accessibility | Syncfusion®
description: Learn about Syncfusion Blazor Sunburst Chart accessibility compliance. Review WCAG 2.2, Section 508, screen reader, and keyboard navigation support.
platform: Blazor
control: Sunburst Chart
documentation: ug
keywords: Blazor Sunburst Chart accessibility, Sunburst Chart WCAG, Sunburst Chart keyboard navigation, Sunburst Chart ARIA, Sunburst Chart screen reader
---

# Blazor Sunburst Chart Accessibility Compliance

The `Blazor Sunburst Chart` component follows the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Sunburst Chart component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

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

WAI-ARIA (Accessibility Initiative - Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components developed with AJAX, HTML, JavaScript, and related technologies. ARIA provides additional semantics to describe the role, state, and functionality of web components.

Element | Default description
-----| -----
Segment | Reads the hierarchy path and value of the focused segment.
Level | Reads the level index and the category represented by the segments.
Breadcrumb | Reads the current drill path from root to the active node.
Legend | Reads the category name and is activated to show or hide the corresponding branch.
Title | Reads the Sunburst Chart title.
Subtitle | Reads the Sunburst Chart subtitle.
Tooltip | Reads the hierarchy path and the value of the hovered segment.

The Blazor Sunburst Chart component follows the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility requirements. The following ARIA attributes are used in the Blazor Sunburst Chart component:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)
* aria-pressed (attribute)
* aria-roledescription (attribute)
* aria-describedby (attribute)

In addition to the standard ARIA attributes, the Blazor Sunburst Chart component also exposes the following accessibility-aware properties, which let you customize how the chart is announced by assistive technologies:

* `AccessibilityDescription` - Provides a text description for the Sunburst Chart root element, enhancing screen reader support.
* `AccessibilityRole` - Specifies the role of the Sunburst Chart, helping assistive technologies to identify the element appropriately.
* `Focusable` - Allows the Sunburst Chart to receive focus so it can participate in keyboard navigation.
* `FocusBorderColor` - Defines the color of the focus indicator that surrounds the focused segment.
* `FocusBorderMargin` - Defines the margin between the focused segment and its focus indicator.
* `FocusBorderWidth` - Defines the width of the focus indicator that surrounds the focused segment.

## Keyboard navigation

The Blazor Sunburst Chart component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation.

The component uses a single roving `tabindex` on the chart root, so only one segment is reachable through `Tab` at a time. Once focus is inside the Sunburst Chart, the following keyboard shortcuts let users explore the hierarchy, drill into a branch, return to the parent, and operate the legend without using a pointer.

| Windows | Mac | Description |
|-----|-----|-----|
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus to the next focusable element in the Sunburst Chart, such as the chart, legend, or breadcrumbs. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus to the previous focusable element in the Sunburst Chart. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves focus to the next segment clockwise within the same ring. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves focus to the previous segment counter-clockwise within the same ring. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves focus to the segment in the next outer ring from the selected segment. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves focus to the segment in the next inner ring from the selected segment. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Moves focus to the first segment in the current ring. |
| <kbd>End</kbd> | <kbd>End</kbd> | Moves focus to the last segment in the current ring. |
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Drills into the focused non-leaf segment, or selects the focused leaf segment. |
| <kbd>Escape</kbd> | <kbd>Escape</kbd> | Drills up to the parent of the active drill root, or clears the current selection. |
| <kbd>Enter</kbd> / <kbd>Space</kbd> (legend) | <kbd>Enter</kbd> / <kbd>Space</kbd> (legend) | Toggles the visibility of the category represented by the focused legend item. |
| <kbd>↑</kbd> / <kbd>↓</kbd> / <kbd>←</kbd> / <kbd>→</kbd> (legend) | <kbd>↑</kbd> / <kbd>↓</kbd> / <kbd>←</kbd> / <kbd>→</kbd> (legend) | Moves focus between legend items. |
| <kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the Sunburst Chart. |

## Accessibility-aware behavior

Beyond ARIA attributes and keyboard navigation, the Blazor Sunburst Chart component provides the following accessibility-aware behaviors so the visualization is usable in real-world scenarios:

* **WCAG 2.2 AA target** - The component targets the WCAG 2.2 AA criteria used to evaluate charts, including color contrast, non-color state indicators, and focus visibility.
* **Roving tab stop** - The chart exposes a single tab stop for the segment collection; arrow keys move focus between segments, and `Tab` leaves the chart to the next control.
* **Focus restoration** - After a drill-down, drill-up, or data refresh, focus is restored to the equivalent logical segment so keyboard users do not lose their place in the hierarchy.
* **Accessible segment names** - Every segment exposes a meaningful accessible name that combines its hierarchy path and value, so screen readers can announce what the focused wedge represents.
* **Keyboard-accessible tooltip** - The tooltip information for the focused or hovered segment is also announced to assistive technologies, so users who cannot rely on pointer hover still see hierarchy path and value.
* **Reduced motion support** - Animations honor the user's `prefers-reduced-motion` setting, so users sensitive to motion are not exposed to non-essential transitions.
* **Non-color state indicators** - Selection, highlight, and focus are indicated by more than color alone (for example, opacity, border, or ring emphasis) so the chart remains usable for users with color-vision deficiencies.
* **Forced-colors support** - Focus indicators, selection, and segment borders remain visible when the operating system is in a high-contrast or forced-colors mode.
* **Responsive accessibility** - At narrow widths, when inner labels are suppressed to save space, every visible segment still remains reachable through tooltip, legend, keyboard navigation, and the accessible summary, so the chart never becomes operable-only-by-pointer.

## Ensuring accessibility

The Blazor Sunburst Chart component's accessibility levels are ensured through automated [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) checks combined with manual keyboard and screen reader testing. The acceptance set verifies WCAG 2.2 AA target behavior, the roving segment tab stop, deterministic arrow, `Home`, `End`, `Enter`, `Space`, and `Escape` keys, focus restoration after drill-down or data updates, accessible path and value names, keyboard-accessible tooltip information, reduced motion, non-color state indicators, and forced-colors support.


## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
