---
layout: post
title: Accessibility in Blazor Spreadsheet | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Spreadsheet and much more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Accessibility in Blazor Spreadsheet

The Syncfusion Blazor Spreadsheet followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Spreadsheet is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) |<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>


## Keyboard interaction

The Syncfusion Blazor Spreadsheet followed keyboard interaction guidelines, making it accessible for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Spreadsheet.

<b>Clipboard Operations</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>Ctrl</kbd> + <kbd>C</kbd> | <kbd>⌘</kbd> + <kbd>C</kbd> | Copy the selected cells to clipboard |
| <kbd>Ctrl</kbd> + <kbd>X</kbd> | <kbd>⌘</kbd> + <kbd>X</kbd> | Cut the selected cells to clipboard |
| <kbd>Ctrl</kbd> + <kbd>V</kbd> | <kbd>⌘</kbd> + <kbd>V</kbd> | Paste clipboard content into the spreadsheet |

<b>Undo/Redo</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>Ctrl</kbd> + <kbd>Z</kbd> | <kbd>⌘</kbd> + <kbd>Z</kbd> | Undo the last action performed |
| <kbd>Ctrl</kbd> + <kbd>Y</kbd> | <kbd>⌘</kbd> + <kbd>Y</kbd> | Redo the last action performed |

<b>Selection Operations</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>Ctrl</kbd> + <kbd>A</kbd> | <kbd>⌘</kbd> + <kbd>A</kbd> | Select all cells in the current worksheet |
| <kbd>Shift</kbd> + <kbd>Arrow Keys</kbd> | <kbd>⇧</kbd> + <kbd>Arrow Keys</kbd> | Extend the current selection in the direction of the arrow key |


<b>Navigation</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>Page Up</kbd> / <kbd>Page Down</kbd> | <kbd>Fn</kbd> + <kbd>↑</kbd> / <kbd>↓</kbd> | Scroll up or down one screen at a time |
| <kbd>Arrow keys</kbd> | <kbd>Arrow keys</kbd> | Navigate between adjacent cells in the direction of the arrow |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Navigate to the cell below after confirming entry |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Navigate to the cell above after confirming entry |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigate to the cell to the right after confirming entry |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Navigate to the cell to the left after confirming entry |




<b>Cell Editing</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>F2</kbd> | <kbd>F2</kbd> | Start editing the active cell |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Complete the current cell entry and move to the cell below |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Complete the current cell entry and move to the cell above |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Complete the current cell entry and move to the cell to the right |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Complete the current cell entry and move to the cell to the left |
| <kbd>Escape</kbd> | <kbd>Esc</kbd> | Cancel the current cell edit and revert to previous value |


<b>Clear Operation</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Remove the content from the currently selected cells |


<b>Hyperlinks</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>Ctrl</kbd> + <kbd>Click</kbd> | <kbd>⌘</kbd> + <kbd>Click</kbd> | Activate and navigate to the hyperlink in the selected cell |
| <kbd>Ctrl</kbd> + <kbd>K</kbd> | <kbd>⌘</kbd> + <kbd>K</kbd> | Open hyperlink dialog (Edit existing or Insert new)|




> * The <kbd>Command</kbd> and <kbd>Control</kbd> keys on Mac devices can be interchanged. When this switch occurs, use the <kbd>Command</kbd> key in place of the <kbd>Control</kbd> key for the above listed key interactions with Mac devices.


## See also

* [Accessibility in Syncfusion Blazor](https://blazor.syncfusion.com/documentation/common/accessibility)
