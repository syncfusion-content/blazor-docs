---
layout: post
title: Accessibility in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about accessibility and keyboard interaction with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Accessibility in Blazor Rating Component

Accessibility is achieved in the rating component through `WAI-ARIA` standard and keyboard navigations. The Rating component can be effectively accessed through assistive technologies such as screen readers.

## Keyboard interaction

The Rating component is interactive with below keyboard shortcuts. 

| Keyboard shortcuts | Actions |
|------------|-------------------|
| <kbd>Space</kbd> | If a **Reset Button** is focused, resets the value to `Min` value. |
| <kbd>ArrowUp</kbd> | Increases the value. | 
| <kbd>ArrowLeft</kbd> | Decreases the value and in RTL mode, increases the value. |
| <kbd>ArrowDown</kbd> | Decreases the value. |
| <kbd>ArrowRight</kbd> | Increases the value and in RTL mode, decreases the value.  |

## ARIA attributes

The following ARIA attributes are used in rating Component based on its state.

| Properties | Functionality |
| ------------ | ----------------------- |
| role | This attribute is added to the div element to describe the actual role. |
| aria-label | Attribute provides the text label with some default description for the Rating and its items. |
| aria-valuemin | It defines the minimum value of rating. |
| aria-valuemax | It defines the maximum value of rating. |
| aria-valuenow | It defines the current value of rating. |
