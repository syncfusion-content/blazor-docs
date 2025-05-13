---
layout: post
title: Keyboard accessibility in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about Keyboard accessibility in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SfPdfViewer components

The Blazor SfPdfViewer component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor SfPdfViewer component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
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

[WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) (Accessibility Initiative – Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components developed with Ajax, HTML, JavaScript,and related technologies. ARIA provides additional semantics to describe the role, state, and functionality of web components. The following ARIA attributes are used in the Blazor SfPdfViewer component:

| Attributes | Purpose |
| --- | --- |
| `aria-disabled`| Indicates whether the Blazor SfPdfViewer component is in a disabled state or not.|
| `aria-expanded`| Indicates whether the suggestion list has expanded or not. |
| `aria-readonly` | Indicates the readonly state of the Blazor SfPdfViewer element. |
| `aria-haspopup` | Indicates whether the Blazor SfPdfViewer input element has a suggestion list or not. |
| `aria-label` | Indicates the breadcrumb item text. |
| `aria-labelledby` | Provides a label for the SfPdfViewer. Typically, the "aria-labelledby" attribute will contain the id of the element used as the Blazor SfPdfViewer's title. |
| `aria-describedby` | This attribute points to the Blazor SfPdfViewer element describing the one it's set on. |
| `aria-orientation` | Indicates whether the Blazor SfPdfViewer element is oriented horizontally or vertically. |
| `aria-valuetext` | Returns the current text of the SfPdfViewer. |
| `aria-valuemax` | Indicates the Maximum value of the SfPdfViewer. |
| `aria-valuemin` | Indicates the Minimum value of the SfPdfViewer. |
| `aria-valuenow` | Indicates the current value of the SfPdfViewer. |
| `aria-controls` | Attribute is set to the button and it points to the corresponding content. |

## Keyboard interaction

The Blazor SfPdfViewer component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Message component.

| Windows | Mac | Actions |
| --- | --- | --- |
|||**Shortcuts for page navigation**|
| <kbd>Ctrl</kbd> + <kbd>←</kbd> / <kbd>Ctrl</</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>←</kbd> or <kbd>⌘</kbd> + <kbd>↑</kbd> |Navigate to the first page |
| <kbd>Ctrl</kbd> + <kbd>→</kbd> / <kbd>Ctrl</</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>→</kbd> or <kbd>⌘</kbd> + <kbd>↓</kbd> |Navigate to the last page |
| <kbd>←</kbd> | <kbd>←</kbd> / <kbd>⇧</kbd> + <kbd>Space</kbd> |Navigate to the previous page |
| <kbd>→</kbd> | <kbd>→</kbd> / <kbd>Space</kbd> | Navigate to the next page |
| <kbd>Ctrl</kbd> + <kbd>G</kbd> | <kbd>⌘</kbd> + <kbd>G</kbd> | Go To The Page|
|<kbd>↑</kbd> |<kbd>↑</kbd> |Scroll up|
| <kbd>↓</kbd> | <kbd>↓</kbd> | Scroll down|
|||**Shortcuts for Zooming**|
|<kbd>Ctrl</kbd> + <kbd>=</kbd> |<kbd>⌘</kbd> + <kbd>=</kbd> | Perform zoom-in operation |
| <kbd>Ctrl</kbd> + <kbd>-</kbd> | <kbd>⌘</kbd> + <kbd>-</kbd> | Perform zoom-out operation |
|<kbd>Ctrl</kbd> + <kbd>0</kbd> | <kbd>⌘</kbd> + <kbd>0</kbd> | Retain the zoom level to 1 |
|||**Shortcut for Text Search**|
| <kbd>Ctrl</kbd> + <kbd>F</kbd> | <kbd>⌘</kbd> + <kbd>F</kbd> | Open the search toolbar|
|||**Shortcut for Text Selection**|
|<kbd>Ctrl</kbd> + <kbd>C</kbd> | <kbd>⌘</kbd> + <kbd>C</kbd> | Copy the selected text or annotation |
| <kbd>Ctrl</kbd> + <kbd>X</kbd> | <kbd>⌘</kbd> + <kbd>X</kbd> |Cut the selected text or annotation |
|<kbd>Ctrl</kbd> + <kbd>V</kbd> | <kbd>⌘</kbd> + <kbd>V</kbd> |Paste the selected text or annotation |
|||**Shortcuts for the general operation**|
| <kbd>Ctrl</kbd> + <kbd>Z</kbd> | <kbd>⌘</kbd> + <kbd>Z</kbd> |Undo the action|
|<kbd>Ctrl</kbd> + <kbd>Y</kbd> | <kbd>⌘</kbd> + <kbd>Y</kbd> |Redo the action|
| <kbd>Ctrl</kbd> + <kbd>P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> |Print the document|
| <kbd>Delete</kbd> | <kbd>Delete</kbd> |Delete the annotations|
| <kbd>Ctrl</kbd>  + <kbd>Shift</kbd> + <kbd>A</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>A</kbd> |Toggle Annotation Toolbar|
| <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>0</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>0</kbd> |Show Command panel|
| <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>2</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>2</kbd> |Show Bookmarks|
|<kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>1</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>1</kbd> |Show Thumbnails|
| <kbd>Ctrl</kbd> + <kbd>S</kbd> | <kbd>⌘</kbd> + <kbd>S</kbd> |Download|
| <kbd>Shift</kbd> + <kbd>H</kbd> | <kbd>⇧</kbd> + <kbd>H</kbd> |Enable pan mode |
| <kbd>Shift</kbd> + <kbd>V</kbd> |<kbd>⇧</kbd> + <kbd>V</kbd> |Enable text selection mode|

## Ensuring accessibility

The Blazor SfPdfViewer component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor SfPdfViewer component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/pdfviewer) in a new window to evaluate the accessibility of the Blazor SfPdfViewer component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)