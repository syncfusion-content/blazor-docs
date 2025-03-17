---
layout: post
title: Appearance in Blazor SpeechToText Component | Syncfusion
description: Checkout and learn about Appearance in Blazor SpeechToText component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: SpeechToText
documentation: ug
---

# Appearance in Blazor SpeechToText component

## Configuring button

You can use the `ButtonSettings` property to customize the appearance of the start and stop buttons in the speech to text conversion.

### Setting start content

You can use the `Text` property to define text content for the listening start state in the SpeechToText button.

### Setting stop content

You can use the `StopStateText` property to define text content for the listening stop state in the SpeechToText button.

### Setting iconcss

You can use the `IconCss` property to apply a CSS class to customize the icon appearance for the listening start state.

### Setting stop iconcss

You can use the `StopIconCss` property to apply a CSS class to customize the icon appearance for the listening stop state.

### Setting icon position

You can display the icon on the top, bottom, left, or right side of the button text content using the `IconPosition` property.

### Setting primary

You can use the `IsPrimary` property to configure the button as a primary action button.

## Configuring tooltips

You can use the `TooltipSettings` property to customize the content and positions of the tooltip.

### Setting start content

You can use the `Text` property to customize the content to be displayed in the tooltip when the speech recognition begins.

### Setting stop content

You can use the `StopStateText` property to customize the stop button tooltip text which is displayed on-hover.

### Setting tooltip position

You can use the `Position` property to determine the placement of tooltips relative to the button.

## Setting button styles

The SpeechToText component supports the following predefined styles that can be defined using the `CssClass` property. You can customize by adding the cssClass property with the below defined class. 

| CssClass | Description | 
| -------- | -------- | 
| `e-primary` | Used to represent a primary action. | 
| `e-outline` | Used to represent an appearance of button with outline. | 
| `e-info` | Used to represent an informative action. | 
| `e-success` | Used to represent a positive action. | 
| `e-warning` | Used to represent an action with caution. | 
| `e-danger` | Used to represent a negative action. |

## Setting cssclass

You can use the `CssClass` property to customize the appearance of the SpeechToText component.