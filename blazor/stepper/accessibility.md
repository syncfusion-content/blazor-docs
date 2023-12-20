---
layout: post
title: Accessibility in Blazor Stepper Component | Syncfusion
description: Checkout and learn here all about accessibility and keyboard interaction in Syncfusion Stepper component and much more.
platform: Blazor
control: Stepper
documentation: ug
---

# Accessibility in Blazor Stepper Component

Accessibility is achieved in the Stepper component through `WAI-ARIA` standard and keyboard navigations. The Stepper component can be effectively accessed through assistive technologies such as screen readers.

## ARIA attributes

The following ARIA attributes are used in Stepper component based on its state.

| Properties | Functionality |
| ------------ | ----------------------- |
| aria-label | Attribute provides the text label with some default description for the Stepper. |
| aria-current | Indicates the current activestep in the stepper. |
| aria-disabled | Indicates when the stepper step is disabled and cannot be interacted. |

## User interaction with keyboard

<table>
<tr>
<td>
<b>Keyboard shortcuts</b></td><td>
<b>Actions</b></td></tr>
<tr>
<td>
<kbd>Up Arrow</kbd></td><td>
Focuses the previous step in a vertical Stepper.</td></tr>
<tr>
<td>
<kbd>Down Arrow</kbd></td><td>
Focuses the next step in a vertical Stepper.</td></tr>
<tr>
<td>
<kbd>Left Arrow</kbd></td><td>
 Focuses the previous step in a horizontal Stepper.</td></tr>
<tr>
<td>
<kbd> Right Arrow</kbd></td><td>
Focuses the next step in a horizontal Stepper</td></tr>
<tr>
<td>
<kbd>Home </kbd></td><td>
Focuses on the first step of the Stepper.</td></tr>
<tr>
<td>
<kbd>End </kbd></td><td>
Focuses on the last step of the Stepper.</td></tr>
<tr>
<td>
<kbd>Enter / Space</kbd></td><td>
Activates the currently focused step.</td></tr>
<tr>
<td>
<kbd>Tab  </kbd></td><td>
 Moves the focus away from the Stepper.</td></tr>
</table>