---
layout: post
title: Accessibility in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about accessibility and keyboard with Syncfusion Blazor Rating component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Rating
documentation: ug
---

# Accessibility in Blazor Rating Component

Accessibility is achieved in the Rating component through WAI-ARIA standard and keyboard navigations. The Rating component can be effectively accessed through assistive technologies such as screen readers.

## Keyboard interaction

The Rating component is interactive with below keyboard shortcuts. 

| Keyboard shortcuts | Actions |
|------------|-------------------|
| <kbd>Space</kbd> | If a Reset is focused, It will reset the value to Minimum value. |
| <kbd>ArrowUp</kbd> | Increase the rating item value. | 
| <kbd>ArrowLeft</kbd> | Increase the rating item value in RTL and Decrease the rating item value in LTR |
| <kbd>ArrowDown</kbd> | Decrease the rating item value. |
| <kbd>ArrowRight</kbd> | Decrease the rating item value in RTL and Increase the rating item value in LTR |

## ARIA attributes

The following ARIA attributes are used in Rating Component based on its state.

| Properties | Functionality |
| ------------ | ----------------------- |
| role | This attribute is added to the div element to describe the actual role. |
| aria-label | Attribute provides the text label with some default description for the Rating and its items. |
| aria-valuemin | It defines the minimum value of rating item. |
| aria-valuemax | It defines the maximum value of rating item. |
| aria-valuenow | It defines the current updated value of rating item. |