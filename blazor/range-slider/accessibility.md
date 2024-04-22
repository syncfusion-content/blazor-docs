---
layout: post
title: Accessibility in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Range Slider component and more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Accessibility in Blazor Range Slider Component

The Slider is characterized with complete ARIA Accessibility support that helps to access by on-screen readers and other assistive technology devices. This control is designed with the reference of guidelines document given in the [WAI ARAI Accessibility Practices](https://www.w3.org/WAI/ARIA/apg/practices/).

The Slider control uses the Slider role and the following ARIA properties for its element based on the state.

| **Properties** | **Functionalities** |
| --- | --- |
| `aria-valuenow` | It indicates the current value of the slider. |
| `aria-valuetext`| It returns the current text of the slider. |
| `aria-valuemin` | It indicates the minimum value of the slider. |
| `aria-valuemax` | It indicates the maximum value of the slider. |
| `aria-orientation` | It indicates the Slider Orientation. |
| `aria-label` | Slider left and right button label text (increment and decrement). |
| `aria-labelledby` | It indicates the name of the Slider. |

## Keyboard interaction

The Keyboard interaction of the Slider control is designed based on the [WAI-ARIA Practices](https://www.w3.org/WAI/ARIA/apg/practices/) described for Slider. Users can use the following shortcut keys to interact with the Slider.

| **Keyboard shortcuts** | **Actions** |
| --- | --- |
| <kbd>Right Arrow</kbd> <kbd>Up Arrow</kbd> | Increase the Slider value.|
| <kbd>Left Arrow</kbd> <kbd>Down Arrow</kbd> | Decrease the Slider value. |
| <kbd>Home</kbd> | Moves to the start value (for Range Slider when the second thumb is focused and the Home key is pressed, it moves to the first thumb value). |
| <kbd>End</kbd> | Moves to the end value (for Range Slider when the first thumb is focused and the End key is pressed, it moves to the second thumb value). |
| <kbd>Page Up</kbd> | Increases the Slider by `LargeStep` value. |
| <kbd>Page Down</kbd> | Decreases the Slider by `LargeStep` value. |