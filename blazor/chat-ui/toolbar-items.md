---
layout: post
title: Toolbar items in Blazor Chat UI Component | Syncfusion
description: Checkout and learn here all about Toolbar items with Syncfusion Blazor Chat UI component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Chat UI
documentation: ug
---

# Toolbar items in Blazor Chat UI component

You can render the Chat UI header toolbar items by using the `HeaderToolbar`, `HeaderToolbarItem` tag directives.

## Adding header text

You can use the `HeaderText` property to set the text for the header area.

## Adding header iconCss

You can customize the header icons by using the `HeaderIconCss` property.

## Adding header toolbar items

The Chat UI component allows you to add header toolbar items using the `HeaderToolbarItem` tag directive within the `HeaderToolbar`.

### Items

Items can be constructed with the following built-in command types or item template.

#### Adding iconCss

You can customize the header toolbar icons by using the `IconCss` property.

#### Setting item type

You can change the header toolbar item type by using the `Type` property. The `Type` supports three types of items such as `Button`, `Separator`, `Spacer` and `Input`. By default, the type is `Button`.

In the following example, header toolbar item type is set as `Button`.

#### Setting text

You can use the `Text` property to set the text for the header toolbar item.

#### Show or hide toolbar item

You can use the `Visible` property to specify whether to show or hide the header toolbar item. By default, its value is `true`.

#### Setting disabled

You can use the `Disabled` property to disable the header toolbar item. By default, its value is `false`.

#### Setting tooltip text

You can use the `Tooltip` property to specify the tooltip text to be displayed on hovering the header toolbar item.

#### Setting cssClass

You can use the `CssClass` property to customize the header toolbar item.

#### Enabling tab key navigation in toolbar

You can use the `TabIndex` property of a header toolbar item to enable tab key navigation for the item. By default, the user can switch between items using the arrow keys, but the `TabIndex` property allows you to switch between items using the `Tab` and `Shift+Tab` keys as well.

To use the `TabIndex` property, set it for each Toolbar item which you want to enable tab key navigation. The `TabIndex` property should be set to a positive integer value. A value of `0` or a negative value will disable tab key navigation for the item.

For example, to enable tab key navigation for two Toolbar items you can use the following code:

With the above code, the user can switch between the two Toolbar items using the Tab and Shift+Tab keys, in addition to using the arrow keys. The items will be navigated in the order specified by the `TabIndex` values.

If you set the `TabIndex` value to 0 for all Toolbar items, tab key navigation will be based on the element order rather than the `TabIndex` values. For example:

#### Setting template

You can use the `Template` tag directive to add custom header toolbar item in the Chat UI component. Template property can be given as the `HTML element` or `RenderFragment`.

### Item clicked

You can define `ItemClicked` event in the `HeaderToolbar` tag directive which will be triggered when the header toolbar item is clicked.
