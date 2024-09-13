---
layout: post
title: Custom views in Blazor AI AssistView Component | Syncfusion
description: Checkout and learn here all about Custom views with Syncfusion Blazor AI AssistView component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Custom views in Blazor AI AssistView component

## Adding custom views

The Blazor AI AssistView allows you to add different views available for user interaction.

#### Setting view type

You can change the type of view by using the `AssistView` and `CustomView` tag directive. It supports two types of view such as `Assist`, and `Custom`.

#### Setting name

You can use the `Header` property to specifies the name of the active view in the AI AssistView component.

#### Adding icon CSS

You can define the CSS class to show the icon for the active view using the `IconCss` property.

#### Setting view template 

You can use the `ViewTemplate` tag directive to customize view of the active view within the AI AssistView component.

#### Show or hide clear button

You can use the `ShowClearButton` property using the `AssistView` tag directive to specify whether to show or hide the clear button in the textarea. By default, its value is `false`. When the clear button is clicked, the prompt text area will be cleared.

## Setting active view

You can use the `ActiveView` property to specifies the index of the active view in the AI AssistView component.
