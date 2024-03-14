---
layout: post
title: Accessibility in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Diagram component and much more details.
platform: Blazor
control: Diagram 
documentation: ug
---

# Accessibility in Blazor Diagram Component

Accessibility in the diagram component is achieved through compliance with the [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) and support for keyboard navigation. This ensures that users can effectively interact with the diagram features using assistive technologies such as screen readers.

The accessibility compliance for the diagram component is outlined below:

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">  |
| [Right-To-Left Support](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

## WAI-ARIA

WAI-ARIA (Web Accessibility Initiative – Accessible Rich Internet Applications) defines standards to enhance the accessibility of web pages, dynamic content, and user interface components developed with HTML, JavaScript, and related technologies. ARIA supplements the semantics of web components by providing additional information about their role, state, and functionality.

The diagram component utilizes the following ARIA attribute:

* aria-label (attribute): Provides a label or description for an element to aid assistive technologies in conveying its purpose or meaning to users with disabilities.


## Keyboard Navigation

All the diagram actions can be controlled via keyboard keys. The applicable key combinations and their relative functionalities are listed below for the appropriate UI features available in the component.


Interaction Keys |Description
-----|-----
<kbd>Ctrl+C</kbd> | Copy the selected diagram elements to the clipboard.
<kbd>Ctrl+X</kbd> | Cut the selected diagram elements to the clipboard.
<kbd>Ctrl+V</kbd> | Paste the diagram elements from the clipboard.
<kbd>Ctrl+A</kbd> | Select all the diagram elements.
<kbd>Delete</kbd> | Delete the selected diagram elements.
<kbd>Ctrl+P</kbd> | Print the diagram page.
<kbd>Ctrl+Z</kbd> | Undo the last action.
<kbd>Ctrl+Y</kbd> | Redo the last undo action.
<kbd>ArrowUp</kbd> | Move the selected diagram elements upwards by the specified delta value.
<kbd>ArrowDown</kbd> | Move the selected diagram elements downwards by the specified delta value.
<kbd>ArrowRight</kbd> | Move the selected diagram elements to the right by the specified delta value.
<kbd>ArrowLeft</kbd> | Move the selected diagram elements to the left by the specified delta value.
<kbd>F2</kbd> | Start editing the selected diagram elements.
<kbd>Ctrl++</kbd> | Zoom in the diagram.
<kbd>Ctrl+-</kbd> | Zoom out the diagram.
<kbd>Ctrl+B</kbd> | Toggle bold formatting for the selected text.
<kbd>Ctrl+I</kbd> | Toggle italic formatting for the selected text.
<kbd>Ctrl+U</kbd> | Toggle underline formatting for the selected text.
<kbd>Ctrl+Shift+Right Angle Bracket (>)</kbd> | Increase the font size of the selected text.
<kbd>Ctrl+Shift+Left Angle Bracket (<)</kbd> | Decrease the font size of the selected text.
<kbd>Ctrl+Shift+L</kbd> | Align the selected text to the left.
<kbd>Ctrl+Shift+C</kbd> | Center the selected text horizontally.
<kbd>Ctrl+Shift+R</kbd> | Align the selected text to the right.
<kbd>Ctrl+Shift+J</kbd> | Justify the selected text, aligning it to both the left and right margins.
<kbd>Ctrl+Shift+E</kbd> | Align the selected text to the top vertically. 
<kbd>Ctrl+Shift+M</kbd> | Center the selected text vertically.
<kbd>Ctrl+Shift+V</kbd> | Align the selected text to the bottom vertically.
<kbd>Ctrl+G</kbd> or <kbd>Ctrl+Shift+G</kbd> | Group selected shapes together, treating them as a single shape.
<kbd>Ctrl+Shift+U</kbd> | Ungroup shapes within a previously grouped selection.
<kbd>Ctrl+Shift+F</kbd> | Bring the selected shape forward in the stacking order.
<kbd>Ctrl+Shift+B</kbd> | Send the selected shape backward in the stacking order.
<kbd>Ctrl+]</kbd> | Move the selected node, connector, and group over the nearest overlapping node, connector, or group.
<kbd>Ctrl+[</kbd> | Move the selected node, connector, and group behind the underlying node, connector, or group.
<kbd>Ctrl+L</kbd> | Rotate the selected nodes counterclockwise.
<kbd>Ctrl+R</kbd> | Rotate the selected nodes clockwise.
<kbd>Ctrl+H</kbd> | Flip the selected diagram elements horizontally.
<kbd>Ctrl+J</kbd> | Flip the selected diagram elements vertically.
<kbd>Tab</kbd> | Select the diagram elements forward based on the rendering order.
<kbd>Shift + Tab</kbd> | Select the diagram elements backward based on the rendering order.
<kbd>Ctrl+D</kbd> | Duplicate the selected shape.
<kbd>Enter</kbd> | Perform annotation editing for the selected diagram element.
<kbd>Ctrl+1</kbd> | Activate the pointer tool.
<kbd>Ctrl+3</kbd> | Activate the connector tool.
<kbd>Ctrl+2</kbd> | Activate the text tool.
<kbd>Ctrl+8</kbd> | Activate the rectangle tool.
<kbd>Ctrl+6</kbd> | Activate the line tool.
<kbd>Ctrl+5</kbd> | Activate the freeform tool.
<kbd>Ctrl+9</kbd> | Activate the ellipse tool.

You can download a complete working sample for keyboard navigation from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Accessibility/KeyBoardNavigation)
