---
layout: post
title: Accessibility in Blazor TreeGrid Component | Syncfusion
description: Learn how the Syncfusion Blazor TreeGrid component supports accessibility standards and much more.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Accessibility in Syncfusion Blazor TreeGrid Component

The Blazor TreeGrid component adheres to widely recognized accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles). These standards are commonly used to evaluate accessibility compliance.

The accessibility compliance for the Blazor TreeGrid component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
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

The Blazor TreeGrid component follows [WAI-ARIA](https://www.w3.orgpg/patterns/treegrid/) patterns to ensure accessibility. The following ARIA attributes are used:

| Attribute | Purpose |
|----------|---------|
| `role=treegrid` | Conveys a contextual message to the user. |
| `aria-selected` | Reflects the selection state (single or multi-select). |
| `aria-expanded` | Indicates whether a node is expanded or collapsed. |
| `aria-sort` | Shows the current sorting order of a column. |
| `aria-busy` | Indicates loading state for screen reader users. |
| `aria-invalid` | Highlights invalid input in form fields. |
| `aria-grabbed` | Provides accessibility for draggable elements. |
| `aria-owns` | Establishes relationships between elements. |
| `aria-label` | Provides an accessible name for icons or controls. |

## Keyboard Interaction

The Blazor TreeGrid component supports [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/treegrid/) guidelines, enabling efficient navigation for users relying on assistive technologies (AT) or keyboard-only input. The following keyboard shortcuts are supported by the Blazor TreeGrid component.

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
|<kbd>Alt + DownArrow</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Expands the selected group.|
|<kbd>Ctrl + DownArrow</kbd> | <kbd>⌘</kbd> + <kbd>↓</kbd> | Expands all the visible groups.|
|<kbd>Alt + UpArrow</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Collapses the selected group.|
|<kbd>Ctrl + UpArrow</kbd> | <kbd>⌘</kbd> + <kbd>↑</kbd> | Collapses all the visible groups.|
|<kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the TreeGrid.|

## Ensuring Accessibility

Accessibility levels in the Blazor TreeGrid component are validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests. The accessibility compliance can be evaluated using the following sample:

Open the [sample](https://ncfusion.com/accessibility/treegrid) in a new window to test accessibility features.

{% previewsample "https://blazor.syncfusion.com/accessibility/treegrid" %}

## See also
* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
