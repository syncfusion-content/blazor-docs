---
layout: post
title: Accessibility in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Diagram component and more
platform: Blazor
control: Diagram 
documentation: ug
---

# Accessibility in Blazor Diagram Component

Accessibility is achieved in the diagram component through WAI-ARIA standard and keyboard navigation support. The diagram features can be effectively accessed through assistive technologies such as screen readers.

The accessibility compliance for the diagram component is outlined below.

* [Color Contrast](../common/accessibility#color-contrast)
* [Mobile Device Support](../common/accessibility#mobile-device-support)
* [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support)
* [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility)

## WAI-ARIA

WAI-ARIA (Accessibility Initiative – Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components developed with HTML, JavaScript,and related technologies. ARIA provides additional semantics to describe the role, state, and functionality of web components.

The following ARIA attributes are used in the diagram component:

* aria-label (attribute)


## Keyboard Navigation

All the diagram actions can be controlled via keyboard keys. The applicable key combinations and their relative functionalities are listed below for the appropriate UI features available in the component.


Interaction Keys |Description
-----|-----
<kbd>Ctrl+C</kbd> | This command is used to copy the selected diagram elements to the clipboard.
<kbd>Ctrl+X</kbd> | This command is used to cut the selected diagram elements to the clipboard.
<kbd>Ctrl+V</kbd> | This command is used to paste the diagram elements from the clipboard.
<kbd>Ctrl+A</kbd> | This command is used to select all the diagram elements.
<kbd>Delete</kbd> | This command is used to delete the selected diagram elements.
<kbd>Ctrl+P</kbd> | This command is used to prints the diagram page.
<kbd>Ctrl+Z</kbd> | This command is used to undo the last action.
<kbd>Ctrl+Y</kbd> | This command is used to redo the last undo action.
<kbd>ArrowUp</kbd> | Moves the selected diagram elements towards up by the specified delta value.
<kbd>ArrowDown</kbd> | Moves the selected diagram elements towards down by the specified delta value.
<kbd>ArrowRight</kbd> | Moves the selected diagram elements towards left by the specified delta value.
<kbd>ArrowLeft</kbd> | Moves the selected diagram elements towards right by the specified delta value.
<kbd>F2</kbd> | This command is used to start editing the selected diagram elements.
<kbd>Ctrl++</kbd> | This command is used to zoom in the diagram.
<kbd>Ctrl+-</kbd> | This command is used to zoom out the diagram.
<kbd>Ctrl+B</kbd> | This command is used to toggle bold formatting for the selected text.
<kbd>Ctrl+I</kbd> | This command is used to toggle italic formatting for the selected text.
<kbd>Ctrl+U</kbd> | This command is used to toggle underline formatting for the selected text.
<kbd>Ctrl+Shift+Right Angle Bracket (>)</kbd> | This command is used to increase the font size of the selected text.
<kbd>Ctrl+Shift+Left Angle Bracket (<)</kbd> | This command is used to decrease the font size of the selected text.
<kbd>Ctrl+Shift+L</kbd> | This command is used to align the selected text to the left.
<kbd>Ctrl+Shift+C</kbd> | This command is used to center the selected text horizontally.
<kbd>Ctrl+Shift+R</kbd> | This command is used to align the selected text to the right.
<kbd>Ctrl+Shift+J</kbd> | This command is used to justify the selected text, aligning it to both the left and right margins.
<kbd>Ctrl+Shift+E</kbd> | This command is used to align the selected text to the top vertically. 
<kbd>Ctrl+Shift+M</kbd> | This command is used to center the selected text vertically.
<kbd>Ctrl+Shift+V</kbd> | This command is used to align the selected text to the bottom vertically.
<kbd>Ctrl+G</kbd> or <kbd>Ctrl+Shift+G</kbd> | This command is used to group together multiple selected shapes, allowing them to be treated as a single shape.
<kbd>Ctrl+Shift+U</kbd> | This command is used to ungroup shapes within a previously grouped selection.
<kbd>Ctrl+Shift+F</kbd> | This command is used to bring the selected shape forward in the stacking order, making it appear in front of other shapes.
<kbd>Ctrl+Shift+B</kbd> | This command is used to send the selected shape backward in the stacking order, making it appear behind other shapes.
<kbd>Ctrl+]</kbd> | Visually moves the selected node, connector, and group over the nearest overlapping node, connector, or group.
<kbd>Ctrl+[</kbd> | Visually moves the selected node, connector, and group behind the underlying node or connector or Group.
<kbd>Ctrl+L</kbd> | This command is used to rotate the selected nodes counterclockwise.
<kbd>Ctrl+R</kbd> | This command is used to rotate the selected nodes clockwise.
<kbd>Ctrl+H</kbd> | This command is used to flip the selected diagram elements horizontally.
<kbd>Ctrl+J</kbd> | This command is used to flip the selected diagram elements vertically.
<kbd>Tab</kbd> | Select the diagram elements in Forward: Focus on the diagram element based on the rendering order when using the "Tab" key.
<kbd>Shift + Tab</kbd> | Select the diagram elements in backward: Focus on the diagram element based on the rendering order when using the "Shift+Tab" key.
<kbd>Ctrl+D</kbd> | Duplicate the selected shape.
<kbd>Enter</kbd> | Perform annotation editing for the selected diagram element.
<kbd>Ctrl+1</kbd> | This command is used to activate the pointer tool.
<kbd>Ctrl+3</kbd> | This command is used to activate the connector tool.
<kbd>Ctrl+2</kbd> | This command is used to activate the text tool.
<kbd>Ctrl+8</kbd> | This command is used to activate the rectangle tool.
<kbd>Ctrl+6</kbd> | This command is used to activate the line tool.
<kbd>Ctrl+5</kbd> | This command is used to activate the freeform tool.
<kbd>Ctrl+9</kbd> | This command is used to activate the ellipse tool.

You can download a complete working sample for keyboard navigation from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Accessibility/KeyBoardNavigation)
