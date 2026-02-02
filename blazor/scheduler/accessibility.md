---
layout: post
title: Accessibility in Blazor Scheduler Component | Syncfusion
description: Describes how the Syncfusion Blazor Scheduler control has been built keeping web accessibility in mind, thus allowing to interact with assistive technologies.
platform: Blazor
control: Scheduler
documentation: ug
---

# Accessibility in Blazor Scheduler Component

The [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Scheduler component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | AA |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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

[WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) (Accessibility Initiative – Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components developed with Ajax, HTML, JavaScript, and related technologies. ARIA provides additional semantics to describe the role, state, and functionality of web components.

The following ARIA attributes are used in the Scheduler:

| Attributes | Purpose |
|-------|---------|
| role="main" |  Attribute added to the Scheduler element describes the actual role of the element and denote it as a main and unique content. |
| role="button" | Attribute is assigned to the appointments of Scheduler, to denote it as a clickable element. |
| aria-label | Attribute is set to the Scheduler parent element and its default value is Scheduler's current date. On every time, the date is navigated, this attribute is updated with appropriate current date values. It is also assigned to other scheduler UI elements such as previous and next date navigation buttons depicting its purpose, div element displaying date range in the header bar and appointment elements. |
| aria-labelledby | It indicates editor dialog title to the user through assistive technologies. |
| aria-describedby | It indicates editor dialog content description to the user through assistive technologies. |
| aria-disabled | Attribute is set to the appointment element to indicates the disabled state of the Scheduler. |

## Keyboard interaction

All the Scheduler actions can be controlled via keyboard keys and is availed by using `AllowKeyboardInteraction` property which is set to `true` by default. The applicable key combinations and its relative functionalities are listed below.

| Windows | Mac | Actions |
| ----- | ----- | ---- |
| <kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Focuses the Scheduler [Provided from application end]. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses the first or active item on the scheduler header bar and then moves the focus to the next available event elements. If no events present, then focus moves out of the component. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Reverse focusing of the Tab functionality. Inverse focusing of event elements from the last one and then moves onto the first or active item on Scheduler header bar and then moves out of the component. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>Arrows</kbd> (<kbd>↑</kbd> , <kbd>→</kbd> , <kbd>↓</kbd> , <kbd>←</kbd>) | <kbd>⌘</kbd> + <kbd>⇧</kbd> + Arrows (<kbd>↑</kbd> , <kbd>→</kbd> , <kbd>↓</kbd> , <kbd>←</kbd>) | Focuses the event element and then moves the focus to the next available event elements between the resources. |
| <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes any of the popup that are in open state. |
| <kbd>↑</kbd> , <kbd>→</kbd> , <kbd>↓</kbd> , <kbd>←</kbd> | <kbd>↑</kbd> , <kbd>→</kbd> , <kbd>↓</kbd> , <kbd>←</kbd> | To move onto the next available cells in either of the needed directions (left, right, top and right) |
| <kbd>Shift</kbd> + <kbd>Arrow</kbd> | <kbd>⇧</kbd> + Arrows (<kbd>↑</kbd> , <kbd>→</kbd> , <kbd>↓</kbd> , <kbd>←</kbd>) | For multiple cell selection on either direction. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Deletes one or more selected events. |
| <kbd>Ctrl</kbd> + <kbd>Click</kbd> on events | <kbd>⌘</kbd> + <kbd>Click</kbd> | To select multiple events. |
| <kbd>Alt</kbd> + <kbd>Number</kbd> (from 1 to 6) | <kbd>⌥</kbd> + <kbd>Number</kbd> (from 1 to 6) | To switch between the views on Scheduler. |
| <kbd>Ctrl</kbd> + <kbd>←</kbd> | <kbd>⌘</kbd> + <kbd>←</kbd> | To navigate to the previous date period. |
| <kbd>Ctrl</kbd> + <kbd>→</kbd> | <kbd>⌘</kbd> + <kbd>→</kbd> | To navigate to the next date period. |
| <kbd>←</kbd> or <kbd>→</kbd> | <kbd>←</kbd> or <kbd>→</kbd> | On pressing any of these keys when focus is currently on the Scheduler header bar, moves the focus to the previous or next items in the header bar. |
| <kbd>Space</kbd> or <kbd>Enter</kbd> | <kbd>Space</kbd> or <kbd>Enter</kbd> | It activates any of the focused items. |
| <kbd>Page Up</kbd> & <kbd>Page Down</kbd> | <kbd>Page Up</kbd> & <kbd>Page Down</kbd> | To scroll through the work cells area. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | To move the selection to the first cell of Scheduler. |
| <kbd>F12</kbd> | <kbd>F12</kbd> | To have the inline option for both cells and events. |
| <kbd>Shift</kbd> + <kbd>Alt</kbd> + <kbd>Y</kbd> | <kbd>⇧</kbd> + <kbd>⌥</kbd> + <kbd>Y</kbd> | To navigate to today date. |
| <kbd>Shift</kbd> + <kbd>Alt</kbd> + <kbd>N</kbd> | <kbd>⇧</kbd> + <kbd>⌥</kbd> + <kbd>N</kbd> | To open editor window. |

## Ensuring accessibility

The Blazor Scheduler component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Scheduler component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/schedule) in a new window to evaluate the accessibility of the Scheduler component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)