---
layout: post
title: Accessibility in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Accessibility in Blazor File Manager Component

The [Blazor FileManager](https://www.syncfusion.com/blazor-components/blazor-file-manager) component has been designed with keeping the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) specifications in mind, and applied the `WAI-ARIA` roles, states, and properties along with `keyboard support`. This component is characterized by complete keyboard interaction support and ARIA accessibility support, which makes navigation easy for people who use assistive technologies (AT) or for users who completely rely on keyboard navigation.

The Blazor File Manager component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor File Manager component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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
| aria-disabled | Indicates whether the File Manager component is in disabled state.|
| aria-haspopup | Indicates whether the Toolbar element has a suggestion list. |
| aria-orientation | Indicates whether the File Manager element is oriented horizontally or vertically. |
| aria-expanded | Indicates whether the Treeview node has been expanded. |
| aria-owns | Contains the ID of the suggestion list to indicate popup as a child element. |
| aria-activedescendent | Holds the ID of the active list item to focus its descendant child element. |
| aria-level | Specifies the level of the element in Treeview Structure. |
| aria-selected | Indicates whether a particular node is in selected state. |
| aria-placeholder | Represents a hint (word or phrase) to the user about what to enter in the text field |
| aria-label |  Defines a string that labels the current element. |
| aria-checked | Indicates whether the checkbox is in checked state. |
| aria-labelledby | Labels the dialog. Often, the value of the aria-labelledby attribute will be the id of the element, which is used to title the dialog |
| aria-describedby | Describes the contents of the dialog. |
| aria-modal | Indicates whether an element is a modal when displayed. |
| aria-colcount | Specifies the number of columns in full table. |
| aria-colindexnt | Defines the number of columns within a grid. |
| aria-rowspan | Defines the number of rows a cell spanned within a grid. |
| aria-colspan | Defines the number of columns a cell spanned within a grid. |
| aria-sort | Indicates whether items in the grid or table are sorted in ascending or descending order. |
| aria-grabbed | This attribute is set to true, and it has been selected for dragging. If this element is set to false, the element can be grabbed for a drag-and-drop operation, but will not currently be selected. |
| aria-busy | This attribute is set to false when grid content is loaded. |
| aria-multiselectable | Defines more than one item has been selected. |

## Keyboard interaction

You can use the following key shortcuts to access the File Manager without interruptions.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Scrolls down to the next folder or file and selects the first item when files are loaded. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Scrolls up to previous folder and select the first item when files are loaded. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item and navigate through the child elements. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses on the first element of toolbar and navigates through the next tab indexed element. |
| <kbd>Esc(Escape)</kbd> | <kbd>Esc</kbd> | Closes the image when it is in open state. |
| <kbd>Alt</kbd> + <kbd>N</kbd> | <kbd>⌥</kbd> + <kbd>N</kbd> | Creates a new folder dialog.|
| <kbd>F5</kbd> | <kbd>F5</kbd> | Refresh the File Manager element. |
| <kbd>Ctrl+Shift+1</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>1</kbd> | Changes the File Manager layout to Grid view. |
| <kbd>Ctrl+Shift+2</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>2</kbd> | Changes the File Manager layout to Details view. |

## Ensuring accessibility

The Blazor File Manager component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the File Manager component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/filemanager) in a new window to evaluate the accessibility of the File Manager component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)