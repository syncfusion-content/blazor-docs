---
layout: post
title: Toolbar items in Blazor AI AssistView Component | Syncfusion
description: Checkout and learn here all about Toolbar items with Syncfusion Blazor AI AssistView component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Toolbar items in Blazor AI AssistView component

The AI AssistView component allows you to add or to customize the default appearance of the Prompt, Response and Header toolbar items.

## Adding header toolbar items

The AI AssistView component allows you to add header toolbar items using the `AssistViewToolbarItem` tag directive within the `AssistViewToolbar`.

### Items

Items can be constructed with the following built-in command types or item template.

#### Adding icon CSS

You can define the CSS class to show the icon for the toolbar item using the `IconCss` property.

#### Setting item type

You can change the toolbar item type by using the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Type) property. The `Type` supports three types of items such as `Button`, `Separator`, `Spacer` and `Input`.

In the following example, toolbar item type is set with `Button`.

#### Setting text

You can use the [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Text) property to set a text for toolbar item.

#### Show or hide toolbar item

The [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Visible) property is used to specify whether to show or hide the toolbar item. By default, its value is `false`.

#### Setting disabled

The [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Disabled) property is used to disable the toolbar item. By default, its value is `false`.

#### Setting tooltip text

The [Tooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TooltipText) property is used to specifies text to be displayed on hovering the toolbar item.

#### Setting cssClass

You can use the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_CssClass) property to customize the toolbar item.

#### Setting align

You can change the alignment of toolbar item by using the [Align](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Align) property. It supports three types of alignments such as `Left`, `Center` and `Right`.

#### Enabling tab key navigation in Toolbar

The [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) property of a Toolbar item is used to enable tab key navigation for the item. By default, the user can switch between items using the arrow keys, but the `TabIndex` property allows you to switch between items using the Tab and Shift+Tab keys as well.

To use the `TabIndex` property, you need to set it for each Toolbar item that you want to enable tab key navigation. The `TabIndex` property should be set to a positive integer value. A value of 0 or a negative value will disable tab key navigation for the item.

For example, to enable tab key navigation for two Toolbar items, you can use the following code:

```cshtml

```

With the above code, the user can switch between the two Toolbar items using the Tab and Shift+Tab keys, in addition to using the arrow keys. The items will be navigated in the order specified by the `TabIndex` values.

If you set the `TabIndex` value to 0 for all Toolbar items, tab key navigation will be based on the element order rather than the `TabIndex` values. For example:

```cshtml

```

#### Setting template

You can use the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Template) property to customize each toolbar item within the AI AssistView component. Template property can be given as the `HTML element` or `RenderFragment`.

### Item clicked

You can define `ItemClicked` event in the `AssistViewToolbar` tag directive which will be triggered when the toolbar item is clicked.

## Built-in toolbar items

### Prompt

By default, the prompt toolbar in the AI AssistView component includes built-in items such as `edit` and `copy` icons. These allow users to modify the prompt text or copy it as needed.

#### Setting width

You can use the `Width` property using `PromptToolbar` tag directive to set the width of the prompt toolbar in the AI AssistView component.

#### Item clicked

You can define `ItemClicked` event in the `PromptToolbar` tag directive which will be triggered when the prompt toolbar item is clicked.

### Response

The response toolbar comes with built-in items like `copy`, `like`, and `dislike` icons for user interaction with the responses.

#### Setting width

You can use the `Width` property using `ResponseToolbar` tag directive to set the width of the response toolbar in the AI AssistView component.

#### Item clicked

You can define `ItemClicked` event in the `ResponseToolbar` tag directive which will be triggered when the response toolbar item is clicked.

## Adding custom toolbar items

You can also add custom toolbar items in the AI AssistView component.

### Prompt

you can customize the default appearance of the Prompt toolbar by using the `PromptToolbarItem` tag directive within the `PromptToolbar`.

> To know more about the items, please refer to the [Items](./toolbar-items#items) section.

### Response

you can customize the default appearance of the Response toolbar by using the `ResponseToolbarItem` tag directive within the `ResponseToolbar`.

> To know more about the items, please refer to the [Items](./toolbar-items#items) section.
