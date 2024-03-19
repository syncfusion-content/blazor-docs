---
layout: post
title: Align Items in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about align the items using spacer in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Align Items in Blazor Toolbar Component

A Toolbar [Spacer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Type) is used for managing the alignment of a toolbar items. It creates an adjustable empty space within the toolbar, providing a clear separation between different items. The spacer dynamically adapts to the toolbar's width.

To achieve different alignment styles, the spacer can be strategically placed among the toolbar items:

## Left, Center, and Right alignment

Insert spacers at the end of the items on the left and in the center. This will push the remaining items to the right and center, creating a balanced distribution across the toolbar.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar>
  <ToolbarItems>
    <ToolbarItem Text="Cut"></ToolbarItem>
    <ToolbarItem Text="Copy"></ToolbarItem>
    <ToolbarItem Text="Paste"></ToolbarItem>
    <ToolbarItem Type="ItemType.Spacer"></ToolbarItem>
    <ToolbarItem Text="Bold"></ToolbarItem>
    <ToolbarItem Text="Underline"></ToolbarItem>
    <ToolbarItem Text="Italic"></ToolbarItem>
    <ToolbarItem Type="ItemType.Spacer"></ToolbarItem>
    <ToolbarItem Text="Search"></ToolbarItem>
    <ToolbarItem Text="Settings"></ToolbarItem>
  </ToolbarItems>
</SfToolbar>

```
![Blazor Toolbar Spacer](./images/blazor-toolbar-spacer-left-right-center-item.png)

## Left and Right alignment

Insert the spacer between the items you want on the left and those you want on the right. This will push the right-aligned items towards the edge of the toolbar.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar>
  <ToolbarItems>
    <ToolbarItem Text="Cut"></ToolbarItem>
    <ToolbarItem Text="Copy"></ToolbarItem>
    <ToolbarItem Text="Paste"></ToolbarItem>
    <ToolbarItem Type="ItemType.Spacer"></ToolbarItem>
    <ToolbarItem Text="Bold"></ToolbarItem>
    <ToolbarItem Text="Underline"></ToolbarItem>
    <ToolbarItem Text="Italic"></ToolbarItem>
    <ToolbarItem Text="Search"></ToolbarItem>
    <ToolbarItem Text="Settings"></ToolbarItem>
  </ToolbarItems>
</SfToolbar>

```
![Blazor Toolbar Spacer](./images/blazor-toolbar-spacer-left-right-item.png)

## Right alignment

Insert the spacer as the first item in the toolbar. This will push all other items towards the right edge of the toolbar.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar>
  <ToolbarItems>
    <ToolbarItem Type="ItemType.Spacer"></ToolbarItem>
    <ToolbarItem Text="Cut"></ToolbarItem>
    <ToolbarItem Text="Copy"></ToolbarItem>
    <ToolbarItem Text="Paste"></ToolbarItem>
    <ToolbarItem Text="Bold"></ToolbarItem>
    <ToolbarItem Text="Underline"></ToolbarItem>
    <ToolbarItem Text="Italic"></ToolbarItem>
    <ToolbarItem Text="Search"></ToolbarItem>
    <ToolbarItem Text="Settings"></ToolbarItem>
  </ToolbarItems>
</SfToolbar>

```
![Blazor Toolbar Spacer](./images/blazor-toolbar-spacer-right-item.png)


N> Avoid using the `Align` property in the toolbar item if `Spacer` was utilized.
