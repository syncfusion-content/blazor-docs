---
layout: post
title: Tooltip in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Tooltip in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# Events in Blazor Ribbon Component

The `<SfRibbon>` component provides several events to handle and customize its behavior at different stages. These events allow developers to interact with the component's lifecycle and user interactions effectively.

## Created

The `Created` event is triggered when the `<SfRibbon>` component's rendering is fully completed. This event can be used to perform any additional setup or initialization required after the component is rendered.

## TabSelecting

The `TabSelecting` event is triggered before a tab is selected in the `<SfRibbon>` component. This event can be used to validate or cancel the tab selection before it occurs.

## TabSelected

The `TabSelected` event is triggered after a tab is successfully selected in the `<SfRibbon>` component. It is useful for executing logic based on the selected tab.

## RibbonExpanding

The `RibbonExpanding` event is triggered before the `<SfRibbon>` component is expanded. This event allows customization or validation before the expansion process starts.

## RibbonCollapsing

The `RibbonCollapsing` event is triggered before the `<SfRibbon>` component is collapsed. It is useful for handling logic or validation during the collapsing phase.

## LauncherIconClick

The `LauncherIconClick` event is triggered when the launcher icon in a `<SfRibbon>` group is clicked. This event can be used to handle specific actions or display additional information based on the clicked group.

## OverflowPopupOpening

The `OverflowPopupOpening` event is triggered before the overflow popup in the `<SfRibbon>` component opens. It provides an opportunity to customize the popup content or prevent the opening process.

## OverflowPopupClosing

The `OverflowPopupClosing` event is triggered before the overflow popup in the `<SfRibbon>` component closes. It allows for cleanup or validation before the popup is closed.

> To know about the built-in Ribbon items supported events, please refer to the corresponding item section in [Ribbon Items](./items).
