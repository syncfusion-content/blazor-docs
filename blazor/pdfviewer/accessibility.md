---
layout: post
title: Accessibility in Blazor PDF Viewer Component | Syncfusion
description: Check out and learn here all about accessibility in the Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Accessibility in Syncfusion Blazor PDF Viewer components

The Blazor PDF Viewer component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor PDF Viewer component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support]| <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508 Support] | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Screen Reader Support]| <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-To-Left Support]| <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Color Contrast] | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Mobile Device Support]| <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Keyboard Navigation Support]| <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Axe-core Accessibility Validation]| <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

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

[WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) (Accessibility Initiative – Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components developed with Ajax, HTML, JavaScript,and related technologies. ARIA provides additional semantics to describe the role, state, and functionality of web components. The following ARIA attributes are used in the Blazor PDF Viewer component:

| Attributes | Purpose |
| --- | --- |
| `aria-disabled`| Indicates whether the Blazor PDF Viewer component is in a disabled state or not.|
| `aria-expanded`| Indicates whether the suggestion list has expanded or not. |
| `aria-readonly` | Indicates the readonly state of the Blazor PDF Viewer element. |
| `aria-haspopup` | Indicates whether the Blazor PDF Viewer input element has a suggestion list or not. |
| `aria-label` | Indicates the breadcrumb item text. |
| `aria-labelledby` | Provides a label for the Blazor PDF Viewer. Typically, the "aria-labelledby" attribute will contain the id of the element used as the Blazor PDF Viewer's title. |
| `aria-describedby` | This attribute points to the Blazor PDF Viewer element describing the one it's set on. |
| `aria-orientation` | Indicates whether the Blazor PDF Viewer element is oriented horizontally or vertically. |
| `aria-valuetext` | Returns the current text of the Blazor PDF Viewer. |
| `aria-valuemax` | Indicates the Maximum value of the Blazor PDF Viewer. |
| `aria-valuemin` | Indicates the Minimum value of the Blazor PDF Viewer. |
| `aria-valuenow` | Indicates the current value of the Blazor PDF Viewer. |
| `aria-controls` | Attribute is set to the button and it points to the corresponding content. |

## Keyboard interaction

The Blazor PDF Viewer component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Message component.

| **Press (Windows)** |**Press (Macintosh)** | **To do this** |
| --- | --- | --- |
|||**Shortcuts for page navigation**|
|<kbd>Up Arrow</kbd> |<kbd>Up Arrow </kbd> |Scroll up|
| <kbd>Down Arrow</kbd> | <kbd>Down Arrow</kbd> | Scroll down|
|||**Shortcuts for Zooming**|
|<kbd>CONTROL + =</kbd> |<kbd>COMMAND + =</kbd> | Perform zoom-in operation |
| <kbd>CONTROL + -</kbd> | <kbd>COMMAND + -</kbd> | Perform zoom-out operation |
|<kbd>CONTROL + 0</kbd> |<kbd>COMMAND + 0</kbd> | Retain the zoom level to 1 |
|||**Shortcut for Text Search**|
| <kbd>CONTROL + F</kbd> | <kbd>COMMAND + F</kbd> |Open the search toolbar|
|||**Shortcut for Text Selection**|
|<kbd>CONTROL + C</kbd> |<kbd>CONTROL + C</kbd> | Copy the selected text or annotation |
| <kbd>CONTROL + X</kbd> | <kbd>CONTROL + X</kbd> |Cut the selected text or annotation |
|<kbd>CONTROL + Y</kbd> |<kbd>CONTROL + Y</kbd> |Paste the selected text or annotation |
|||**Shortcuts for the general operation**|
| <kbd>CONTROL + Z</kbd> | <kbd>CONTROL + Z</kbd> |Undo the action|
|<kbd>CONTROL + Y</kbd> |<kbd>CONTROL + Y</kbd> |Redo the action|
| <kbd>CONTROL + P</kbd> | <kbd>COMMAND + P</kbd> |Print the document|
|<kbd>Delete</kbd> |<kbd>Delete</kbd> |Delete the annotations|

## Ensuring accessibility

The Blazor PDF Viewer component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the Blazor PDF Viewer component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/pdfviewer) in a new window to evaluate the accessibility of the Blazor PDF Viewer component with accessibility tools.

## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)