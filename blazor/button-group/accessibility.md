---
layout: post
title: Accessibility in Blazor ButtonGroup Component | Syncfusion 
description: Learn about Accessibility in Blazor ButtonGroup component of Syncfusion, and more details.
platform: Blazor
control: ButtonGroup
documentation: ug
---

# Accessibility

The web accessibility makes web content and web applications more accessible for people with disabilities. It especially helps in dynamic content change and development of advanced user interface controls with AJAX, HTML, JavaScript, and related technologies.

ButtonGroup provides built-in compliance with `WAI-ARIA` specifications. It helps the people with disabilities by providing information about the widget for assistive technology in the screen readers. ButtonGroup component contains the `group` role.

| Properties | Functionality |
| ------------ | ----------------------- |
| role | Indicates the `group` for the container that holds two or more buttons. |

## Keyboard interaction

### Normal behavior

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Keyboard shortcuts</b></td>
<td><b>Actions</b></td>
</tr>
<tr>
<td><kbd>Tab</kbd></td>
<td>Focuses the next button in the ButtonGroup.</td>
</tr>
<tr>
<td><kbd>Enter/Space</kbd></td>
<td>Activates the focused button in the ButtonGroup.</td>
</tr>
</table>

### Checkbox type behavior

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Keyboard shortcuts</b></td>
<td><b>Actions</b></td>
</tr>
<tr>
<td><kbd>Tab</kbd></td>
<td>Focuses the next button in the ButtonGroup.</td>
</tr>
<tr>
<td><kbd>Space</kbd></td>
<td>Activates the focused button in the ButtonGroup.</td>
</tr>
</table>

### Radiobutton type behavior

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Keyboard shortcuts</b></td>
<td><b>Actions</b></td>
</tr>
<tr>
<td><kbd>Tab</kbd></td>
<td>Focuses the active button in the ButtonGroup.</td>
</tr>
<tr>
<td><kbd>Arrow Keys</kbd></td>
<td>Activates next/previous button in the ButtonGroup.</td>
</tr>
</table>

`Index.razor`

```cshtml
  <h5>Normal behavior</h5>
   <div class='e-btn-group e-outline'>
    <EjsButton ID="html" CssClass='e-outline' Content="HTML"></EjsButton>
    <EjsButton ID="css" CssClass='e-outline' Content="CSS"></EjsButton>
    <EjsButton ID="javascript" CssClass='e-outline' Content="Javascript"></EjsButton>
</div>

<h5>Radiobutton type behavior</h5>
<div class='e-btn-group'>
    <input type="radio" Id="radioleft" name="align" value="left" />
    <label class="e-btn" for="radioleft">Left</label>
    <input type="radio" Id="radiomIddle" name="align" value="mIddle" />
    <label class="e-btn" for="radiomIddle">Center</label>
    <input type="radio" Id="radioright" name="align" value="right" />
    <label class="e-btn" for="radioright">Right</label>
</div>

<h5>Checkbox type behavior</h5>
 <div class='e-btn-group'>
    <input type="checkbox" Id="checkbold" name="font" value="bold" />
    <label class="e-btn" for="checkbold">Bold</label>
    <input type="checkbox" Id="checkitalic" name="font" value="italic" />
    <label class="e-btn" for="checkitalic">Italic</label>
    <input type="checkbox" Id="checkline" name="font" value="underline" />
    <label class="e-btn" for="checkline">Underline</label>
</div>

  ```
