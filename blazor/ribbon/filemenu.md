---
layout: post
title: File Menu in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about File Menu in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# File Menu in Blazor Ribbon Component

The Ribbon component provides a built-in file menu to include menu items for performing specific actions. The file menu can be configured using the `<RibbonFileMenuSettings>` tag directive directly inside `<SfRibbon>`.

## Visibility

You can make the file menu visible by setting the `Visible` property of the `<RibbonFileMenuSettings>` directive to `true`. By default, the file menu is hidden.

## Adding menu items

Menu items can be added to the file menu by binding a collection of menu items to the `MenuItems` property of the `<RibbonFileMenuSettings>` directive. Each menu item can have properties like `Text`, `IconCss`, and nested sub-menu items too.

## Open submenu on click

By default, submenus open on mouse hover. To change this behavior and open submenus on menu item click, you can set the `ShowItemOnClick` property to `true`.

## Custom header text

You can define custom header text for the file menu by using the `Text` property of the `<RibbonFileMenuSettings>` directive. By default, the header text is set to `File`.

## Events

Below are the events that are currently supported in Ribbon Filemenu

* `FileMenuOpening` - FileMenuOpenEventArgs
* `FileMenuClosing` - FileMenuCloseEventArgs
* `FileMenuOpened` - FileMenuOpenedEventArgs
* `FileMenuClosed` - FileMenuClosedEventArgs
* `FileMenuItemRendering` - FileMenuItemRenderEventArgs
* `ItemSelecting` - FileMenuItemSelectEventArgs