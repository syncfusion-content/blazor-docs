---
layout: post
title: Accessibility in Blazor SplitButton Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor SplitButton component and more.
platform: Blazor
control: Split Button
documentation: ug
---

# Accessibility in Blazor SplitButton Component

## ARIA attributes

The web accessibility makes web content and web applications more accessible for people with disabilities. It especially helps in dynamic content change and development of advanced user interface controls with AJAX, HTML, JavaScript, and related technologies.

Split Button provides built-in compliance with `WAI-ARIA` specifications. `WAI-ARIA` support is achieved through the attributes like `aria-expanded`, `aria-owns` and `aria-haspopup` applied for action item in
Split Button. It helps the people with disabilities by providing information about the widget for assistive technology in the screen readers. Split Button component contains the  `MenuItem` role.

| Properties | Functionality |
| ------------ | ----------------------- |
| menuItem | This role will be specified for an action items. |
| aria-haspopup | Indicates the availability and type of interactive SplitButton popup element. |
| aria-expanded | Indicates whether the SplitButton popup can be expanded or collapsed, as well as indicates whether its current state is expanded or collapsed. |
| aria-owns | Identifies an elements in order to define a visual, functional, or contextual parent/child relationship between DOM elements where the DOM hierarchy cannot be used to represent the relationship. |

## Keyboard interaction

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td>
<b>Keyboard shortcuts</b></td><td>
<b>Actions</b></td></tr>
<tr>
<td>
<kbd>Esc</kbd></td><td>
Closes the opened popup.</td></tr>
<tr>
<td>
<kbd>Enter</kbd></td><td>
Opens the popup, or activates the highlighted item and closes the popup.</td></tr>
<tr>
<td>
<kbd>Space</kbd></td><td>
Opens the popup.</td></tr>
<tr>
<td>
<kbd>Up</kbd></td><td>
Navigates up or to the previous action item.</td></tr>
<tr>
<td>
<kbd>Down</kbd></td><td>
Navigates down or to the next action item.</td></tr>
<tr>
<td>
<kbd>Alt + Up Arrow</kbd></td><td>
Opens the popup.</td></tr>
<tr>
<td>
<kbd>Alt + Down Arrow</kbd></td><td>
Closes the popup.</td></tr>
</table>

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Paste">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut" ></DropDownMenuItem>
        <DropDownMenuItem Text="Copy" ></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

```

Output be like
![Accessibility in Blazor SplitButton](./images/blazor-splitbutton.png)