---
title: "Query Builder Accessibility"
component: "Query Builder"
description: "TypeScript Query Builder component has accessibility support to help access the features via keyboard, on-screen readers, or other assistive technology devices."
---

# Accessibility

## ARIA attributes

The web accessibility makes web content and web applications more accessible for people with disabilities. It especially helps in dynamic content change and development of advanced user interface controls with AJAX, HTML, JavaScript, and related technologies.
The query builder provides a built-in compliance with `WAI-ARIA` specifications. The `WAI-ARIA` support is achieved using the attributes such as `aria-label`,`aria-disabled`,`aria-haspopup`,`aria-expanded` and `aria-orientation`.
It helps the people with disabilities by providing information about the widget for assistive technology in the screen readers. The Query Builder component contains the `query builder` roles.

| Properties | Functionality |
| ------------ | ----------------------- |
| role | Indicates the type of input element. |
| aria-label | Indicates the menu item text. |
| aria-disabled | Indicates the state of query builder item whether it is disabled. |
| aria-haspopup | Indicates the availability and type of interactive popup element. |
| aria-expanded | Indicates whether the subtree can be expanded or collapsed, and indicates whether its current state can be expanded or collapsed. |
| aria-orientation | Indicates whether the orientation is horizontal or vertical. |



## User interaction with keyboard

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td>
<b>Keyboard shortcuts</b></td><td>
<b>Actions</b></td></tr>
<tr>
<td>
<kbd>Enter</kbd></td><td>
Select the focused item, and When it is in an open state the popup list closes.</td></tr>
<tr>
<td>
<kbd>Space</kbd></td><td>
Select the focused item.</td></tr>
<tr>
<td>
<kbd>Tab</kbd></td><td>
Focus on the next TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component.</td></tr>
<tr>
<td>
<kbd>Shift + Tab</kbd></td><td>
Focus on the previous TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component.</td></tr>
<tr>
<td>
<kbd>Up arrow</kbd></td><td>
Select the item previous to the currently selected one.</td></tr>
<tr>
<td>
<kbd>Down arrow</kbd></td><td>
Select the first item in the popup list when no item selected. Otherwise, select the item next to the currently selected item.</td></tr>
<tr>
<td>
<kbd>Home</kbd></td><td>
Select the first item in the popup list.</td></tr>
<tr>
<td>
<kbd>End</kbd></td><td>
Select the last item in the popup list.</td></tr>
</table>


