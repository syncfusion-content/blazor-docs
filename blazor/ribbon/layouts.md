---
layout: post
title: Layouts in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Layouts in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# Layouts in Blazor Ribbon component

The Ribbon component allows customization of its layout through the `ActiveLayout` property. It supports two primary layouts: `Classic` and `Simplified`.

## Classic layout

The Classic layout organizes Ribbon items and groups in a traditional format. You can set the `ActiveLayout` property to `RibbonLayout.Classic` to enable this layout. By default, the Ribbon component renders in the `Classic` layout.

### Defining items size

You can control the size of Ribbon items using the `AllowedSizes` property in the `<RibbonItem>` directive. The Ribbon supports three item sizes:

- **Large**: Large icon with text.
- **Medium**: Small icon with text.
- **Small**: Small icon only.

When resizing to smaller screen, the item sizes adjust based on the available tab content width in the order: Large → Medium → Small, and vice versa.

### Defining items orientation

You can use the `Orientation` property of the `<RibbonGroup>` tag directive to arrange items vertically (Column) or horizontally (Row). By default, the orientation is `Column`.

Row: A group may have up to three collections, each containing multiple items.
Column: A group can have any number of collections, with each collection containing one large-sized item or up to three medium/small-sized items.

### Defining group header

You can set the `HeaderText` property in the `<RibbonGroup>` directive to define the text that appears as the header for the group.

### Defining group icon

You can customize the group overflow button's icon using the `GroupIconCss` property. When the ribbon size adjusts, this icon appears in the group popup button.

### Enabling group launcher icon

You can use the `ShowLauncherIcon` property in the `<RibbonGroup>` directive to enable or disable the launcher icon for each group. By default, the property is set to `false`.

#### Customize launcher icon

You can use the `LauncherIconCss` property to customize the launcher icon by applying the custom styles.

### Defining group collapsible state

You can control whether a group can collapse or not during resizing with the `IsCollapsible` property. By default, it is `true`. Set it to `false` to prevent the group from collapsing.

#### Defining priority order for group collapse or expand

You can use the `Priority` property to determine the collapse and expand order of groups during resizing. Higher priority values collapse first, while lower values expand first.

## Simplified layout

In simplified layout, the Ribbon component organizes the items and groups into a single row. Set the `ActiveLayout` property to `RibbonLayout.Simplified` to enable this layout.

### Enabling group overflow popup

You can control how overflow items appear in the group while resizing using the `EnableGroupOverflow` property.

- Set to `true` to display overflow items in a separate popup near the group.
- Set to `false` to display overflow items in a common popup at the right end of the tab content.

## Minimized state

You can hide the Ribbon contents and display only the tab headers by double-clicking on the tab header. When the Ribbon is on minimized state, it expands to its normal state when click on the tab header.

Also, you can programmatically control the minimized state of Ribbon using the `IsMinimized` property. By default, the value is `false`.

## Show or hide the layout switcher

You can use the `HideLayoutSwitcher` property to show/hide the Ribbon layout switcher button. By default, the value is `false`, meaning the switcher will be visible.