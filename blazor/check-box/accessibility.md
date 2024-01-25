---
layout: post
title: Accessibility in Blazor CheckBox Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor CheckBox component and much more.
platform: Blazor
control: Checkbox
documentation: ug
---

# Accessibility in Blazor CheckBox Component

The web accessibility makes web content and web applications more accessible for people with disabilities. It especially helps in dynamic content change and development of advanced user interface controls with AJAX, HTML, JavaScript, and related technologies.

Checkbox provides built-in compliance with `WAI-ARIA` specifications. `WAI-ARIA` support is achieved through the attributes like `aria-disabled`. It helps the people with disabilities by providing information about the widget for assistive technology in the screen readers. Checkbox component contains the `checkbox` role.

| Properties | Functionality |
| ------------ | ----------------------- |
| role | Indicates the type of input element. |
| aria-disabled | Indicates that the element is perceivable but disabled, so it is not editable or otherwise operable. |

## Keyboard interaction

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td>
<b>Keyboard shortcuts</b></td><td>
<b>Actions</b></td></tr>
<tr>
<td>
<kbd>Space</kbd></td><td>
When the Checkbox has focus, pressing the Space key changes the state of the Checkbox.</td></tr>
</table>

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox @bind-Checked="isChecked" Label="Checked State"></SfCheckBox><br />
<SfCheckBox @bind-Checked="isUnChecked" Label="Unchecked State"></SfCheckBox><br />
<SfCheckBox @bind-Checked="isMediateChecked" Indeterminate="true" Label="Intermediate State"></SfCheckBox>

@code {
    private bool isChecked = true;
    private bool isUnChecked = false;
    private bool isMediateChecked = false;
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZhqMBLchpQGyyAF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Accessibility in Blazor CheckBox](./images/blazor-checkbox-accessibility.png)