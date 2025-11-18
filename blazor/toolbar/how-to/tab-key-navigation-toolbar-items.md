---
layout: post
title: Tab key navigation in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to Tab key navigation toolbar item in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Enabling Tab key Navigation in Blazor Toolbar Component

The [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) property of a Toolbar item enables tab key navigation for the item. By default, navigation between items occurs using the arrow keys. The `TabIndex` property additionally allows switching between items using the Tab and Shift+Tab keys.

To utilize the [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) property, set it for each Toolbar item where tab key navigation is desired. The [TabIndex] property requires an integer value. A value of 0 or a negative value disables tab key navigation for the item.

For example, to enable tab key navigation with an explicit order for two Toolbar items, use the following code:

```csharp
@using Syncfusion.Blazor.Navigations
<SfToolbar Width="600">
    <ToolbarItems>
        <ToolbarItem SuffixIcon="e-icons e-cut" Text="Cut" TabIndex=1 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-copy" Text="Copy" TabIndex=2 ></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```
With the preceding code, navigation between the two Toolbar items is possible using the Tab and Shift+Tab keys, in addition to arrow keys. Items are navigated in the explicit order specified by their [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) values.
If [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) is set to `0` for all Toolbar items, tab key navigation follows the element's natural source order, rather than a numerically explicit [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) order. For example:
```csharp
@using Syncfusion.Blazor.Navigations
<SfToolbar Width="600">
    <ToolbarItems>
        <ToolbarItem SuffixIcon="e-icons e-cut" Text="Cut" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-copy" Text="Copy" TabIndex=0 ></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```
```csharp
@using Syncfusion.Blazor.Navigations
<SfToolbar Width="600">
    <ToolbarItems>
        <ToolbarItem SuffixIcon="e-icons e-cut" Text="Cut" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-copy" Text="Copy" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-paste" Text="Paste" TabIndex=0></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-bold" Text="Bold" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-underline" Text="Underline" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-italic" Text="Italic" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-paint-bucket" Text="Color-Picker" TabIndex=0 ></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-list-unordered" Text="Bullets" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-list-ordered" Text="Numbering" TabIndex=0 ></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-sort-ascending" Text="Sort A - Z" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-sort-descending" Text="Sort Z - A" TabIndex=0 ></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-upload-1" Text="Upload" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-download" Text="Download" TabIndex=0 ></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-increase-indent" Text="Text Indent" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-decrease-indent" Text="Text Outdent" TabIndex=0 ></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-erase" Text="Clear" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-refresh" Text="Reload" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-export" Text="Export" TabIndex=0 ></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLSWXCDJtDTYouf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Toolbar with TabIndex](../images/blazor-toolbar-item-tabindex.gif)" %}