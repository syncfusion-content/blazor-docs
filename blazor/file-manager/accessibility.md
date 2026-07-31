---
layout: post
title: Accessibility in Blazor File Manager Component | Syncfusion®
description: Checkout and learn here all about Accessibility in Blazor File Manager component and much more details.
platform: Blazor
control: File Manager
documentation: ug
---

# Accessibility in Blazor File Manager Component

The [Blazor File Manager](https://www.syncfusion.com/blazor-components/blazor-file-manager) component is designed with the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) specifications in mind, and applies WAI-ARIA roles, states, and properties along with keyboard support. This component provides complete keyboard interaction support and ARIA accessibility support, which makes navigation easier for people who use assistive technologies (AT) or for users who rely on keyboard navigation.

The Blazor File Manager component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles) commonly used to evaluate accessibility.

The accessibility compliance for the Blazor File Manager component is outlined below.

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

The Blazor File Manager component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to meet the accessibility. The following ARIA attributes are used in the File Manager component:

| **Attributes** | **Purpose** |
| --- | --- |
| aria-disabled | Indicates whether the File Manager component is in a disabled state. |
| aria-haspopup | Indicates whether the Toolbar element has a suggestion list. |
| aria-orientation | Indicates whether the File Manager element is oriented horizontally or vertically. |
| aria-expanded | Indicates whether the TreeView node has been expanded. |
| aria-owns | Contains the ID of the suggestion list to indicate the popup as a child element. |
| aria-activedescendant | Holds the ID of the active list item to focus its descendant child element. |
| aria-level | Specifies the level of the element in TreeView structure. |
| aria-selected | Indicates whether a particular node is in a selected state. |
| aria-placeholder | Represents a hint (word or phrase) to the user about what to enter in the text field. |
| aria-label | Defines a string that labels the current element. |
| aria-checked | Indicates whether the checkbox is in a checked state. |
| aria-labelledby | Labels the dialog. Often, the value of the aria-labelledby attribute is the ID of the element used to title the dialog. |
| aria-describedby | Describes the contents of the dialog. |
| aria-modal | Indicates whether an element is modal when displayed. |
| aria-colcount | Specifies the number of columns in a full table. |
| aria-colindex | Defines the column index within a grid. |
| aria-rowspan | Defines the number of rows a cell spans within a grid. |
| aria-colspan | Defines the number of columns a cell spans within a grid. |
| aria-sort | Indicates whether items in the grid or table are sorted in ascending or descending order. |
| aria-grabbed | Indicates whether the item is being dragged. |
| aria-busy | Indicates whether grid content is busy while loading. |
| aria-multiselectable | Indicates that more than one item has been selected. |

## Keyboard interaction

You can use the following key shortcuts to access the File Manager without interruptions.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Scrolls down to the next folder or file and selects the first item when files are loaded. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Scrolls up to the previous folder and selects the first item when files are loaded. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item and navigates through the child elements. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses on the first toolbar element and navigates through the next tab-indexed element. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the image when it is open. |
| <kbd>Alt</kbd> + <kbd>N</kbd> | <kbd>⌥</kbd> + <kbd>N</kbd> | Opens the New Folder dialog. |
| <kbd>F5</kbd> | <kbd>F5</kbd> | Refreshes the File Manager element. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>1</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>1</kbd> | Changes the File Manager layout to Grid view. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>2</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>2</kbd> | Changes the File Manager layout to Details view. |

## Ensuring accessibility

The Blazor File Manager component's accessibility levels are validated through the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

Open the [sample](https://blazor.syncfusion.com/accessibility/filemanager) in a new window to evaluate the accessibility of the File Manager component with accessibility tools.

## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)