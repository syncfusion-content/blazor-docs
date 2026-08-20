---
layout: post
title: Blazor TreeGrid Accessibility | Syncfusion
description: Learn how Blazor TreeGrid supports accessibility with WCAG 2.2 compliance, Section 508 support, ARIA attributes, keyboard navigation, and screen readers.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Accessibility in Blazor TreeGrid

The Blazor TreeGrid component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor TreeGrid component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
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

## WAI-ARIA

The Blazor TreeGrid component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/treegrid/) patterns to meet the accessibility. The following ARIA attributes are used in the Blazor TreeGrid component:

| Attributes | Purpose |
| --- | --- |
| `role=treegrid` | Identifies the component as a treegrid to assistive technologies. |
| `aria-selected` | Accurately reflect the selection state, whether it's single-select or multi-select. |
| `aria-expanded` | Indicates whether a node is expanded or collapsed, making navigation and hierarchy comprehension easier for screen readers. |
| `aria-sort` | Indicates the current sorting order of a table column, facilitating accessible data presentation and interaction. |
| `aria-busy` |  Represents the loading state to improve accessibility, particularly for those relying on screen readers. |
| `aria-invalid` | Indicates whether input in a form field is valid or invalid, helping to ensure the input can be understood and corrected. |
| `aria-grabbed` | Provides accessibility information when interacting with draggable elements. |
| `aria-owns` | Establishing relationships between an element and the elements it owns or controls. |
| `aria-label` | Provides an accessible name for the close icon. |

## Keyboard interaction

The Blazor TreeGrid component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/treegrid/) guideline,making it easy for people using assistive technologies or keyboard navigation. The following keyboard shortcuts are supported by the Blazor TreeGrid component.

| Windows | Mac | Description |
| ----- | ----- | ---- |
| <kbd>PageDown</kbd> | <kbd>PageDown</kbd> |Goes to the next page.|
|<kbd>PageUp</kbd>| <kbd>PageUp</kbd> |Goes to the previous page.|
|<kbd>Ctrl + Alt +PageDown</kbd>| <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>PageDown</kbd> |Goes to the last page.|
|<kbd>Ctrl + Alt + PageUp</kbd>| <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>PageUp</kbd> |Goes to the first page.|
|<kbd>Alt + PageDown</kbd>| <kbd>⌥</kbd> + <kbd>PageDown</kbd> |Goes to the next page.|
|<kbd>Alt + PageUp</kbd>| <kbd>⌥</kbd> + <kbd>PageUp</kbd> |Goes to the previous page.|
|<kbd>Home</kbd>| <kbd>fn</kbd>+<kbd>←</kbd> |Goes to the first cell.|
|<kbd>End</kbd>| <kbd>fn</kbd>+<kbd>→</kbd> |Goes to the last cell.|
|<kbd>Ctrl + Home</kbd>| <kbd>⌘</kbd> + <kbd>Home</kbd> |Goes to the first row.|
|<kbd>Ctrl + End</kbd>| <kbd>⌘</kbd> + <kbd>End</kbd> |Goes to the last row.|
|<kbd>DownArrow</kbd>| <kbd>↓</kbd> |Moves the cell focus downward.|
|<kbd>UpArrow</kbd> | <kbd>↑</kbd> |Moves the cell focus upward.|
|<kbd>LeftArrow</kbd>| <kbd>←</kbd> |Moves the cell focus left side.|
|<kbd>RightArrow</kbd>| <kbd>→</kbd> |Moves the cell focus right side.|
|<kbd>Shift + DownArrow</kbd>| <kbd>⇧</kbd> + <kbd>↓</kbd> |Extends the row/cell selection downwards.|
|<kbd>Shift + UpArrow</kbd>| <kbd>⇧</kbd> + <kbd>↑</kbd> |Extends the row/cell selection upwards.|
|<kbd>Shift + LeftArrow</kbd>| <kbd>⇧</kbd> + <kbd>←</kbd> |Extends the cell selection to the left side.|
|<kbd>Shift + RightArrow</kbd>| <kbd>⇧</kbd> + <kbd>→</kbd> |Extends the cell selection to the right side.|
|<kbd>Enter</kbd>| <kbd>Enter</kbd> | Moves the row/cell selection downward. If current cell is in edit state, then completes the editing. If the current cell is a header then performs sorting.|
|<kbd>Shift + Enter</kbd>| <kbd>⇧</kbd> + <kbd>Enter</kbd> | Moves the row/cell selection upward. If the current cell is a header then clears sorting for the selected column.|
|<kbd>Ctrl + Enter</kbd>| <kbd>⌘</kbd> + <kbd>Enter</kbd> | If the current cell is a header then performs multi-sorting.|
|<kbd>Tab</kbd> | Tab | Moves the cell selection right side.|
|<kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves the cell selection left side.|
|<kbd>Esc</kbd> | <kbd>Esc</kbd> |Deselects all the rows/cells.|
|<kbd>Ctrl + A</kbd> | <kbd>⌘</kbd> + <kbd>A</kbd> |Selects all the rows/cells.|
|<kbd>↑</kbd> | <kbd>↑</kbd> | Moves up a row/cell selection.|
|<kbd>↓</kbd>| <kbd>↓</kbd> | Moves down a row/cell selection.|
|<kbd>→</kbd>| <kbd>→</kbd> | Moves to the right cell selection.|
|<kbd>←</kbd>| <kbd>←</kbd> | Moves to the left cell selection.|
|<kbd>Ctrl + DownArrow</kbd> | <kbd>⌘</kbd> + <kbd>↓</kbd> | Expands all the visible groups.|
|<kbd>Ctrl + Shift + DownArrow</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>↓</kbd> | Expands the selected group.|
|<kbd>Ctrl + UpArrow</kbd> | <kbd>⌘</kbd> + <kbd>↑</kbd> | Collapses all the visible groups.|
|<kbd>Ctrl + Shift + UpArrow</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>↑</kbd> | Collapses the selected group.|
|<kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the TreeGrid.|

## Ensuring accessibility

The Blazor TreeGrid component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor TreeGrid component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/treegrid) in a new window to evaluate the accessibility of the Blazor TreeGrid component with accessibility tools.

**Steps to test accessibility using axe‑core DevTools**

1. Install axe DevTools extension in your browser (Chrome or Edge).

2. Open the TreeGrid accessibility sample: TreeGrid sample.

3. Run analysis from the axe DevTools tab in Developer Tools.

4. Review and fix violations in your TreeGrid implementation, then re‑run until compliance is achieved.

{% previewsample "https://blazor.syncfusion.com/accessibility/treegrid" %}

## See also
* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
