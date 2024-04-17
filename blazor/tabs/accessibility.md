---
layout: post
title: Accessibility in Blazor Tabs Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Tabs component and much more details.
platform: Blazor
control: Tabs
documentation: ug
---

# Accessibility in Blazor Tabs Component

## ARIA attributes

[Blazor Tabs](https://www.syncfusion.com/blazor-components/blazor-tabs) component is designed by considering [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/practices/) standard. Tab is supported with ARIA Accessibility which is accessible by on-screen readers, and other assistive technology devices.
The following list of attributes are added in the Tab.

| **Roles and Attributes** | **Functionalities** |
| --- | --- |
| tablist | Attribute is set to  the Tab header element  that describes actual role of the element.|
| tab | Attribute is set to the Tab items element to  indicates an interactive element inside a tablist that, when activated, displays its associated tabpanel.|
| tabpanel | This is set to role attribute for the Tab content that describes the role for viewing the active content.|
| aria-orientation    | Attribute is set to the Tab header element indicates the Tab header orientation. Default value of this attribute is horizontal. |
| aria-selected       | Attribute set to the Tab items to indicates the selection state for Tab items. Active Tab is set to true for this attribute. |
| aria-labelledby       | Attribute is set to the Tab content element to indicates the associated Tab header for the content. |
| aria-controls       | Attribute is set to the Tab items element to indicates the associated tabpanel for the header. |
| aria-haspopup       | Attribute is set to the Popup element  to indicates the popup mode in the Tab. The default value of this attribute is false. If popup mode is enabled, the attribute value is set to true. |
| aria-disabled       | Attribute set to the Tab items to It indicates the disabled state of the Tab. |

## Keyboard interaction

By default, keyboard navigation is enabled. This component implements keyboard navigation support by following the WAI-ARIA practices. Once focused on the active Tab element, use the following key combination for interacting with the Tab.

| Key           | Description                                                                         |
|---------------|-------------------------------------------------------------------------------------|
| <kbd>Left</kbd>    | Moves focus to the previous Tab. If focus is on the first Tab, the focus will not move to any Tab. |
| <kbd>Right</kbd>   | Moves focus to the next Tab. If focus is on the last Tab element, the focus will not move to any Tab. |
| <kbd>Enter</kbd> or <kbd> Space</kbd>  | Selects the Tab if it is not selected. Opens the popup dropdown icon if it is focused. Select the Tab item as active when popup item is focused. |
| <kbd>Esc(Escape)</kbd>           | Closes the popup if popup is in opened state.       |
| <kbd>Down</kbd> or <kbd>Up</kbd>   | When the popup is open and focused, it will move to previous or next Tab items of the popup in the vertical direction. |
|  <kbd>Home</kbd>    | Moves focus to the first Tab. |
|  <kbd>End </kbd>   | Moves focus to the last Tab. |
|  <kbd>Shift + F10 </kbd>   | If popup mode is enabled, it opens the popup when the Tab is focused. |
|  <kbd>Delete</kbd>    | Deletes the Tab, if close button is enabled in Tab header. |